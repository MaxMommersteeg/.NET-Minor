using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Minor.Dag58.SecureWebDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["user"] = User?.Identity?.Name ?? "UNKOWN";
            return View();
        }

        [Authorize( Roles = "Docent")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
