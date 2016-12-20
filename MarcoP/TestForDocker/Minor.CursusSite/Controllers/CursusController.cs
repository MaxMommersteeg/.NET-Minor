using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minor.CursuSite.Cursusbeheer.Agents.Models;
using Minor.CursuSite.Cursusbeheer.Agents;

namespace Minor.CursusSite.Controllers
{
    public class CursusController : Controller
    {
        // GET: Cursus
        public ActionResult Index()
        {
            var model = new Cursus[]
            {
                new Cursus { Id=1, Naam="C# for Dummies", Duur = 3 },
                new Cursus { Id=2, Naam="MVC for Dummies", Duur = 2 },
                new Cursus { Id=3, Naam=".NET for Dummies", Duur = 1 },
            };
            return View(model);
        }

        // GET: Cursus
        public ActionResult Index2()
        {
            var agent = new CursusBeheerClient(new Uri("http://minor.cursusbeheer"));
            var model = agent.ApiCursusGet();
            return View("Index", model);
        }

        //// GET: Cursus/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Cursus/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Cursus/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Cursus/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Cursus/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Cursus/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Cursus/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}