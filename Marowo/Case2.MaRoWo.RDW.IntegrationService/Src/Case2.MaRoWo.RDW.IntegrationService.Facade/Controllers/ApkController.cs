
using Microsoft.AspNetCore.Mvc;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Incoming;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Managers;
using Swashbuckle.SwaggerGen.Annotations;
using System.Net;
using Case2.MaRoWo.RDW.IntegrationService.Facade.ErrorModel;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Converters;
using System.Collections.Generic;
using Case2.MaRoWo.Logger.Services;
using System;
using Case2.MaRoWo.Logger.Entities;
using Microsoft.AspNetCore.Diagnostics;

namespace Case2.MaRoWo.RDW.IntegrationService.Facade.Controllers
{
    [Route("api/v1/[controller]")]
    public class ApkController : Controller
    {
        private readonly IRdwApkManager _apkManager;
        private readonly ILogService _logger;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apkManager"></param>
        public ApkController(IRdwApkManager apkManager, ILogService logger)
        {
            _apkManager = apkManager;
            _logger = logger;
        }

        /// <summary>
        ///  POST api/v1/apk/apkRequestCommand
        ///  
        /// </summary>
        /// <param name="apkKeuringsVerzoekCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation("MakeApkRequest")]
        [ProducesResponseType(typeof(KeuringsVerzoekAntwoord), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequest), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody]ApkKeuringsVerzoekCommand command)
        {
            if (!ModelState.IsValid)
            {
                var badRequest = new BadRequest() { Message = $"Request bevat: {ModelState.ErrorCount} fouten", InvalidProperties = ModelState.Keys };
                _logger.Log(new LogMessage(badRequest.Message));
                return BadRequest(badRequest);
            }
            try
            {
                var result = _apkManager.HandleApkKeuringsVerzoek(command);
                return new JsonResult(result);
            }
            catch(Exception ex)
            {
                var badRequest = new BadRequest { Message = "RDW niet bereikbaar", InvalidProperties = new List<string>() };
                _logger.LogException(new LogMessage($"{badRequest.Message}", ex.StackTrace));
                return BadRequest(badRequest);
            }
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var error = feature?.Error;
            if(error == null)
            {
                _logger.LogException(new LogMessage("Unknown error"));
                return new JsonResult("Error");
            }
            _logger.LogException(new LogMessage(error.Message, error.StackTrace));
            return new JsonResult("Error");
        }
    }
}
