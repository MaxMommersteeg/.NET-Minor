using Case2.MaRoWo.Logger.Entities;
using Case2.MaRoWo.Logger.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Case2.MaRoWo.GarageAdministratie.Facade.Controllers
{
    public class MainController : Controller
    {
        private readonly ILogService _logger;

        public MainController(ILogService logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var error = feature?.Error;
            if (error == null)
            {
                _logger.LogException(new LogMessage("Unknown error"));
                return new JsonResult("Error");
            }
            _logger.LogException(new LogMessage(error.Message, error.StackTrace));
            return new JsonResult("Error");
        }
    }
}
