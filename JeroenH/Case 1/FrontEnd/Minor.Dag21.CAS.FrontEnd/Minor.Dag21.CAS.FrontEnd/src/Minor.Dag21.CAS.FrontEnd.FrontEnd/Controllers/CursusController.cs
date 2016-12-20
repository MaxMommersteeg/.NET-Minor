using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minor.Dag21.CAS.FrontEnd.FrontEnd.ViewModels;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Globalization;
using Minor.Dag21.CASServiceClient.Agents;
using Minor.Dag21.CASServiceClient.Agents.Models;
using System.Net;

namespace Minor.Dag21.CAS.FrontEnd.FrontEnd.Controllers
{
    public class CursusController : Controller
    {
        private ICASService _CursusAgent { get; set; }

        public CursusController(ICASService cursusAgent)
        {
            _CursusAgent = cursusAgent;
        }

        // GET: Cursus
        public ActionResult Index()
        {
            return RedirectToAction("Overzicht");
        }

        private static DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }

        private static int WeekOfYearISO8601(DateTime date)
        {
            var day = (int)CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date);
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date.AddDays(4 - (day == 0 ? 7 : day)), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }



        [HttpGet]
        [ActionName("Overzicht")]
        // GET: Cursus/Index/5
        public ActionResult Index(int? weekNummer, int? jaarNummer)
        {
            int jaarNummerReal = jaarNummer ?? DateTime.Now.Year;
            int weekNummerReal = weekNummer ?? WeekOfYearISO8601(DateTime.Now);

            DateTime gekozenWeek = FirstDateOfWeekISO8601(jaarNummerReal, weekNummerReal);
            ViewBag.weekSelectie = weekNummerReal;
            ViewBag.jaarSelectie = jaarNummerReal;

            ViewBag.volgendeWeekNummer = WeekOfYearISO8601(gekozenWeek.AddDays(7));
            ViewBag.volgendeWeekJaar = gekozenWeek.AddDays(7).Year;

            ViewBag.vorigeWeekNummer = WeekOfYearISO8601(gekozenWeek.AddDays(-7));
            ViewBag.vorigeWeekJaar = gekozenWeek.AddDays(-7).Year;

            ViewBag.currentDatum = gekozenWeek;
            gekozenWeek.ToString("yyyy-MM-dd"); 
            var model = (IEnumerable<CursusInstantie>)_CursusAgent.GetByWeek(gekozenWeek.ToString("yyyy-MM-dd"));
            return View("CursusWeergeven", (IEnumerable<CursusInstantie>)model);
        }

        [HttpGet]
        [ActionName("Inschrijven")]
        // GET: Cursus/Inschrijven/5
        public ActionResult Inschrijven(int cursusID)
        {
            ViewBag.cursusID = cursusID;
            return View("CursistInvoeren");
        }

        // GET: Cursus/Details/5
        public ActionResult Details(int id)
        {

            ViewBag.cursusID = id;
            return View("CursusInschrijven",(IEnumerable<Cursist>)_CursusAgent.GetCursistenByInschrijving(id));
        }

        // GET: Cursus/Create
        public ActionResult Create()
        {
            return View("CursusInvoeren");
        }

        // POST: Cursus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormFile file)
        {
            try
            {
                int totalInsertCount = 0;
                int OKResponsesCount = 0;
                if (file.Length > 0)
                {
                    int currentIndex = 1;
                    using (var reader = new StreamReader(file.OpenReadStream()))
                    {                        
                        List<CursusInstantie> cursusLijst = new List<CursusInstantie>();
                        while (reader.Peek() >= 0)
                        {
                            string rawtitel = reader.ReadLine();
                            if(!rawtitel.StartsWith("Titel: "))
                            {
                                CursusCreateMessageViewModel formatError = new CursusCreateMessageViewModel() { ErrorAtLine=currentIndex };
                                return View("CursusCreateMessage", formatError);
                            }
                            string cursusTitel = Regex.Replace(rawtitel, @"^(Titel: )",
                                string.Empty);
                            currentIndex++;

                            string rawCursuscode = reader.ReadLine();
                            if (!rawCursuscode.StartsWith("Cursuscode: "))
                            {
                                CursusCreateMessageViewModel formatError = new CursusCreateMessageViewModel() { ErrorAtLine = currentIndex };
                                return View("CursusCreateMessage", formatError);
                            }
                            string cursusCode = Regex.Replace(
                                rawCursuscode,
                                @"^(Cursuscode: )",
                                string.Empty);
                            currentIndex++;

                            string rawCursusDuur = reader.ReadLine();
                            if (!rawCursusDuur.StartsWith("Duur: "))
                            {
                                CursusCreateMessageViewModel formatError = new CursusCreateMessageViewModel() { ErrorAtLine = currentIndex };
                                return View("CursusCreateMessage", formatError);
                            }
                            int cursusDuur = int.Parse(
                                Regex.Match(rawCursusDuur,
                                @"(\d)").Value
                                );
                            currentIndex++;

                            string rawCursusStartDatum = reader.ReadLine();
                            if (!rawCursusStartDatum.StartsWith("Startdatum: "))
                            {
                                CursusCreateMessageViewModel formatError = new CursusCreateMessageViewModel() { ErrorAtLine = currentIndex };
                                return View("CursusCreateMessage", formatError);
                            }
                            DateTime cursusStartDatum = DateTime.Parse(
                                Regex.Match(rawCursusStartDatum,
                                @"(\d{1,2}\/\d{1,2}\/\d{4})").Value
                                );
                            currentIndex++;

                            reader.ReadLine();
                            
                            Cursus cursus = new Cursus() { Titel = cursusTitel, Cursuscode = cursusCode, Duur = cursusDuur };
                            CursusInstantie cursusInstantie = new CursusInstantie() { Startdatum= cursusStartDatum, Cursus = cursus};
                            cursusLijst.Add(cursusInstantie);
                        }
                        
                        for (int i = 0; i < cursusLijst.Count; i++)
                        {
                            var response = _CursusAgent.PostWithHttpMessagesAsync(cursusLijst[i]);
                            var code = response.Result.Response.StatusCode;
                            if (code== HttpStatusCode.OK)
                            {
                                OKResponsesCount++;
                            }
                            totalInsertCount++;
                        } 
                    }
                    

                }
                CursusCreateMessageViewModel message = new CursusCreateMessageViewModel() { SuccesInsertCount = OKResponsesCount, TotalInsertCount = totalInsertCount };
                return View("CursusCreateMessage", message);
            }
            catch
            {
                return View();
            }
        }

        // GET: Cursus/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cursus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cursus/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cursus/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}