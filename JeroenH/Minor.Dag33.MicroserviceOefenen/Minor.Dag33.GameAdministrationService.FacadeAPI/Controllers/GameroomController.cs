using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Minor.Dag33.GameAdministrationService.FacadeAPI.Controllers
{
    public class GameroomController : Controller
    {
        private IRepository _repo;

        public GameroomController(IRepository repo)
        {
           _repo = repo;
        }

        // GET: Gameroom
        public ActionResult Index()
        {
            return View();
        }

        // GET: Gameroom/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Gameroom/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(CreateGameroomCommand command)
        {
            Gameroom room = new Gameroom(_repo);
            room.Create(command.Roomname, command.Gamename, command.Colour);

            return View();
        }

        // POST: Gameroom/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Gameroom/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Gameroom/Edit/5
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

        // GET: Gameroom/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Gameroom/Delete/5
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