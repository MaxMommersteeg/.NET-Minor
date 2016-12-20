using Case2.MaRoWo.Logger.Entities;
using Case2.MaRoWo.Logger.Services;
using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Services;
using Case2.MaRoWo.OnderhoudBeheer.Service.Facade.ResultModels;
using Case2.MaRoWo.OnderhoudBeheer.Service.Incoming.Commands;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Facade.Controllers
{
    [Route("api/v1/[controller]")]
    public class OnderhoudController : Controller
    {
        private readonly IOnderhoudsopdrachtService _onderhoudsopdrachtService;
        private readonly ILogService _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="onderhoudsopdrachtService"></param>
        public OnderhoudController(IOnderhoudsopdrachtService onderhoudsopdrachtService, ILogService logger)
        {
            _onderhoudsopdrachtService = onderhoudsopdrachtService;
            _logger = logger;
        }

        [HttpPost]
        [SwaggerOperation("AddOnderhoudsopdracht")]
        [ProducesResponseType(typeof(ValidRequest), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InvalidRequest), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody]CreateOnderhoudCommand onderhoudCommand)
        {
            if(!ModelState.IsValid)
            {
                var badRequestMessage = $"Request bevat: {ModelState.ErrorCount} fouten";
                _logger.Log(new LogMessage($"{badRequestMessage} | {GetType().Name}"));
                var badRequest = new InvalidRequest(badRequestMessage, ModelState.Keys);
                return BadRequest(badRequest);
            }
            try
            {
                // Proces command using OnderhoudService (DomainService)
                _onderhoudsopdrachtService.AddOnderhoudsopdracht(onderhoudCommand);
                return new OkResult();
            }
            catch(Exception ex)
            {
                var badRequestMessage = "Er ging iets mis. Onderhoud niet geplaatst.";
                _logger.LogException(new LogMessage(ex.Message, ex.StackTrace));
                var badRequest = new InvalidRequest(badRequestMessage, new List<string>());
                return BadRequest(badRequest);
            }
        }

        [HttpPut]
        [SwaggerOperation("UpdateOnderhoudsopdracht")]
        [ProducesResponseType(typeof(ValidRequest), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InvalidRequest), (int)HttpStatusCode.BadRequest)]
        public IActionResult Put([FromBody]UpdateOnderhoudCommand updateOnderhoudCommand)
        {
            if (!ModelState.IsValid)
            {
                var badRequestMessage = $"Request bevat: {ModelState.ErrorCount} fouten";
                _logger.Log(new LogMessage($"{badRequestMessage} | {GetType().Name}"));
                var badRequest = new InvalidRequest(badRequestMessage, ModelState.Keys);
                return BadRequest(badRequest);
            }
            try
            {
                // Proces command using OnderhoudService (DomainService)
                _onderhoudsopdrachtService.UpdateOnderhoudsopdracht(updateOnderhoudCommand);
                return new OkResult();
            }
            catch (Exception ex)
            {
                var badRequestMessage = "Er ging iets mis. Onderhoud niet geupdated.";
                _logger.LogException(new LogMessage(ex.Message, ex.StackTrace));
                var badRequest = new InvalidRequest(badRequestMessage, new List<string>());
                return BadRequest(badRequest);
            }
        }

        [Route("Afmelden")]
        [HttpPut]
        [SwaggerOperation("OnderhoudsopdrachtAfmelden")]
        [ProducesResponseType(typeof(ValidRequest), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InvalidRequest), (int)HttpStatusCode.BadRequest)]
        public IActionResult OnderhoudsopdrachtAfmelden([FromBody]OnderhoudAfmeldenCommand onderhoudAfmeldenCommand)
        {
            if (!ModelState.IsValid)
            {
                var badRequestMessage = $"Request bevat: {ModelState.ErrorCount} fouten";
                _logger.Log(new LogMessage($"{badRequestMessage} | {GetType().Name}"));
                var badRequest = new InvalidRequest(badRequestMessage, ModelState.Keys);
                return BadRequest(badRequest);
            }
            try
            {
                // Proces command using OnderhoudService (DomainService)
                _onderhoudsopdrachtService.OnderhoudsopdrachtAfmelden(onderhoudAfmeldenCommand);
                return new OkResult();
            }
            catch (Exception ex)
            {
                var badRequestMessage = "Er ging iets mis. Onderhoud niet afgemeld.";
                _logger.LogException(new LogMessage(ex.Message, ex.StackTrace));
                var badRequest = new InvalidRequest(badRequestMessage, new List<string>());
                return BadRequest(badRequest);
            }
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
