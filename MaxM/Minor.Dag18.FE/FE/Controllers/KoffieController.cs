using System;
using FE.Agents;
using Microsoft.AspNetCore.Mvc;

namespace FE.Controllers
{
    public class KoffieController : Controller
    {
        private IKoffieAgent _koffieAgent;

        public KoffieController(IKoffieAgent koffieAgent)
        {
            _koffieAgent = koffieAgent;
        }

        public IActionResult Index()
        {
            var model = _koffieAgent.GetAll();
            return View(model);
        }

        public IActionResult Details(int koffieId)
        {
            var model = _koffieAgent.GetById(koffieId);
            return View(model);
        }

        public IActionResult Delete(int koffieId)
        {
            _koffieAgent.Delete(koffieId);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
