using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Minor.Dag39.SpelbeheerServiceBackend.WebApi.Errors;
using Minor.Dag39.SpelbeheerServiceBackend.DAL.DAL;
using Minor.Dag39.SpelbeheerServiceBackend.Domain;

namespace Minor.Dag39.SpelbeheerServiceBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class SpelController : Controller
    {
        private IRepository<Spel, int> _repo;

        public SpelController(IRepository<Spel, int> repo)
        {
            _repo = repo;
        }



        // POST api/values
        [HttpPost]        
        [SwaggerOperation("Post")]
        [ProducesResponseType(typeof(Spel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody]Spel spel)
        {
            if(!ModelState.IsValid)
            {
                var error = new ErrorMessage(ErrorTypes.BadRequest, "Modelstate invalid");
                return BadRequest(error);
            }
                    
            try
            {
                _repo.Insert(spel);
                return Ok();
            }
            catch (DbUpdateException)
            {
                var error = new ErrorMessage(ErrorTypes.DuplicateKey, "This key already exist");
                return BadRequest(error);
            }
            catch (Exception)
            {
                var error = new ErrorMessage(ErrorTypes.Unknown, "Oops, something went wrong");
                return NotFound(error);
            }
        }

         protected override void Dispose(bool disposing)
        {
            _repo?.Dispose();
            base.Dispose(disposing);
        }
    }
}
