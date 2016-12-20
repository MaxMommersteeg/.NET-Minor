using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LoggingDemo.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            try
            {
                ViewData["Message"] = "Your application description page.";
                throw new ArgumentNullException();
            }
            catch(Exception ex)
            {
                _logger.LogError("aww" + ex.ToString());
                _logger.LogCritical("uh oh! " + ex.ToString());

            }


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
