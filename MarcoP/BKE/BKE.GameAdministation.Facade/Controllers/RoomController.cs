using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BKE.GameAdministation.Commands;
using BKE.GameAdministration.Domain;
using BKE.Common;
using Swashbuckle.SwaggerGen.Annotations;
using System.Net;

namespace BKE.GameAdministation.Facade.Controllers
{
    [Route("[controller]")]
    public class RoomController : Controller
    {
        private RoomService _roomService;

        public RoomController(RoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        [Route("createroom")]
        [SwaggerOperation("CreateRoom")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FunctionalError[]), (int)HttpStatusCode.NotFound)]
        public IActionResult Post([FromBody]CreateRoomCommand command)
        {
            try
            {
                _roomService.Execute(command);
                return Ok();
            }
            catch (FunctionalException ex)
            {
                return BadRequest(ex.FunctionalErrors.ToArray());
            }
        }

        [HttpPost]
        [Route("joinroom")]
        [SwaggerOperation("JoinRoom")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FunctionalError[]), (int)HttpStatusCode.NotFound)]
        public IActionResult Post([FromBody]JoinRoomCommand command)
        {
            try
            {
                _roomService.Execute(command);
                return Ok();
            }
            catch (FunctionalException ex)
            {
                return BadRequest(ex.FunctionalErrors.ToArray());
            }
        }
    }
}
