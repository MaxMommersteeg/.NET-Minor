using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minor.Dag21.CASServiceClient.Agents;
using Minor.Dag21.CASServiceClient.Agents.Models;

namespace Minor.Dag21.CAS.FrontEnd.FrontEnd.Controllers
{
    public class CursistController : Controller
    {
        private ICASService _CursistAgent { get; set; }

        public CursistController(ICASService cursistAgent)
        {
            _CursistAgent = cursistAgent;
        }

        // GET: Cursist
        public ActionResult Index()
        {
            return View("Cursisten", (IEnumerable<Cursist>)_CursistAgent.CursistGetAllWithHttpMessagesAsync());
        }

        // GET: Cursist/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cursist/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Cursist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cursist cursist)
        {
            try
            {
                _CursistAgent.PostCursistWithHttpMessagesAsync(cursist);

                return RedirectToAction("Index","Cursus");
            }
            catch(Exception)
            {
                return View();
            }
        }

        // GET: Cursist/Create
        public ActionResult CursusInschrijven(int id)
        {
            ViewBag.cursistId = id;
            return View("CursistInschrijven",(IEnumerable<CursusInstantie>)_CursistAgent.GetAll());
        }

        // POST: Cursist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CursusInschrijven(int cursistId, int cursusInstantie)
        {
            try
            {
                Cursist cursist = (Cursist)_CursistAgent.GetByID(cursistId);

                _CursistAgent.PostCursistWithHttpMessagesAsync();

                return View("Cursisten", (IEnumerable<Cursist>)_CursistAgent.CursistGetAll());
            }
            catch
            {
                return View();
            }
        }

        // GET: Cursist/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cursist/Edit/5
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

        // GET: Cursist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cursist/Delete/5
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