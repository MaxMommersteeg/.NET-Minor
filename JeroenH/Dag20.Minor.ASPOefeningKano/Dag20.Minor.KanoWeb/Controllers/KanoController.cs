using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dag20.Minor.KanoWeb.Agents;
using Dag20.Minor.KanoWeb.Models;
using Models;

namespace Dag20.Minor.KanoWeb.Controllers
{
    public class KanoController : Controller
    {
        private IAgent<Kano,int> _KanoAgent { get; set; }

        public KanoController(IAgent<Kano,int> kanoAgent)
        {
            _KanoAgent = kanoAgent;
        }
        // GET: Kano
        public ActionResult Index()
        {
            
            return View((List<Kano>)_KanoAgent.FindAll());
        }

        // GET: Kano/Details/5
        public ActionResult Details(int id)
        {

            return View(_KanoAgent.FindById(id));
        }

        // GET: Kano/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kano/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var kano = new Kano() {kanoID = int.Parse(collection["KanoID"][0]), kanoType = (KanoTypes) Enum.Parse(typeof(KanoTypes),collection["KanoType"][0]) };
                _KanoAgent.Add(kano);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kano/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_KanoAgent.FindById(id));
        }

        // POST: Kano/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var kano = new Kano() { kanoID = int.Parse(collection["KanoID"][0]), kanoType = (KanoTypes)Enum.Parse(typeof(KanoTypes), collection["KanoType"][0]) };

                _KanoAgent.Update(kano);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kano/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_KanoAgent.FindById(id));
        }

        // POST: Kano/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var kano = _KanoAgent.FindById(id);
                _KanoAgent.Delete(kano);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}