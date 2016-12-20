using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minor.Dag17.FirstASPdemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag17.FirstASPdemo.Controllers
{
    public class SlakController : Controller
    {
        private SlakkenContext _context;

        public SlakController(SlakkenContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var model = _context.Slakken.ToList();
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Slakjson()
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=NaaktslakkenDB;Integrated Security=true";
            var builder = new DbContextOptionsBuilder<SlakkenContext>();
            builder.UseSqlServer(connectionString);
            var options = builder.Options;

            IEnumerable<Slak> model = null;
            using (var context = new SlakkenContext(options))
            {
                model = context.Slakken.ToList();
            }
            return Json(model);
        }

    }
}
