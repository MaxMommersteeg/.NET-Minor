using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Dag17.Minor.ASPNETOefenen.Controllers
{
    public class MonumentenTestController : Controller
    {
        private IAgent _MonumentAgent;

        public MonumentenTestController(IAgent monumentAgent)
        {
            _MonumentAgent = monumentAgent;
        }
        // GET: MonumentenTest
        public ActionResult Index()
        {
            return View((List<Monument>)_MonumentAgent.FindAll());
        }

        // GET: MonumentenTest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MonumentenTest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonumentenTest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Monument monument = new Monument() { MonumentNaam = collection.First().Value };
                _MonumentAgent.Add(monument);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MonumentenTest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MonumentenTest/Edit/5
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

        // GET: MonumentenTest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MonumentenTest/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Monument monument = new Monument() { MonumentNaam = collection.First().Value };
                _MonumentAgent.Remove(monument);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}