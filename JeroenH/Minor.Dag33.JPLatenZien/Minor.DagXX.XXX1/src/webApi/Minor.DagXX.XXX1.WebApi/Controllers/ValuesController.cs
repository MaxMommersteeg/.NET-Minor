using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Minor.DagXX.XXX1.WebApi.Errors;

namespace Minor.DagXX.XXX1.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IRepository<Value, int> _repo;

        public ValuesController(IRepository<Value, int> repo)
        {
            _repo = repo;
        }

        // GET api/values
        [HttpGet]
        [SwaggerOperation("GetAll")]
        [ProducesResponseType(typeof(Value), (int)HttpStatusCode.OK)]
        public IEnumerable<Value> Get()
        {
            try
            {
                return Ok(_repo.FindAll());

            }
            catch (Exception)
            {
                var error = new ErrorMessage(ErrorTypes.Unknown , "Oops, something went wrong");
                return BadRequest(error);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerOperation("GetByID")]
        [ProducesResponseType(typeof(Value), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_repo.Find(id));

            }
            catch (ArgumentNullException){
                var error = new ErrorMessage(ErrorTypes.NotFound, "Object not found");
                return NotFound(error);
            }
            catch (Exception)
            {
                var error = new ErrorMessage(ErrorTypes.Unknown, "Oops, something went wrong");
                return BadRequest(error);
            }
        }

        // POST api/values
        [HttpPost]        
        [SwaggerOperation("Post")]
        [ProducesResponseType(typeof(Value), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody]Value value)
        {
            if(!ModelState.IsValid)
            {
                var error = new ErrorMessage(ErrorTypes.BadRequest, "Modelstate invalid");
                return BadRequest(error);
            }
                    
            try
            {
                return Ok(_repo.Insert(value));
            }
            catch (DbUpdateException)
            {
                var error = new ErrorMessage(ErrorTypes.DuplicateKey, "This key already exist");
                return BadRequest(error);
            }
            catch (Exception)
            {
                var BadRequest = new ErrorMessage(ErrorTypes.Unknown, "Oops, something went wrong");
                return NotFound(error);
            }
        }

        // PUT api/values/5
        [HttpPut]
        [SwaggerOperation("Update")]
        [ProducesResponseType(typeof(Value), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public IActionResult Put([FromBody]Value value)
        {
            if (!ModelState.IsValid)
            {
                var error = new ErrorMessage(ErrorTypes.BadRequest, "Modelstate invalid");
                return BadRequest(error);
            }

            try
            {
                return Ok(_repo.Update(value));

            }
            catch (DbUpdateException)
            {
                var error = new ErrorMessage(ErrorTypes.NotFound, "This object does not exist");
                return NotFound(error);
            }
            catch (Exception)
            {
                var error = new ErrorMessage(ErrorTypes.Unknown, "Oops, something went wrong");
                return BadRequest(error);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [SwaggerOperation("Delete")]
        [ProducesResponseType(typeof(Value), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        public IActionResult Delete(int id)
        {       
            try
            {
                return Ok(_repo.Delete(id));

            }
            catch (DbUpdateException)
            {
                var error = new ErrorMessage(ErrorTypes.NotFound, "Object not found");
                return NotFound(error);
            }
            catch (Exception)
            {
                var error = new ErrorMessage(ErrorTypes.Unknown, "Oops, something went wrong");
                return BadRequest(error);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }
    }
}
