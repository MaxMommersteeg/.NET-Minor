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
            var vm = new MinorViewModel() { Docent = "Marco" };
            return View(vm);
        }

        public IActionResult About()
        {
            _logger.LogInformation("Informatie log");
            try
            {
                _logger.LogDebug("Debug info :-)");

                ViewData["Message"] = "Your application description page.";
                throw new Exception("Hier gaat die stuk");
            }
            catch (Exception ex)
            {
                _logger.LogError("Stuk! " + ex.ToString());
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
