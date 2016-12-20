using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Minor.Dag21.CAS.BackEnd.WebApi.Errors;
using Minor.Dag21.CAS.BackEnd.Entities.Entities;
using Minor.Dag21.CAS.BackEnd.DAL.DAL;


namespace Minor.Dag21.CAS.BackEnd.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CursistController : Controller
    {
        private IRepository<Cursist, int> _repo;

        public CursistController(IRepository<Cursist, int> repo)
        {
            _repo = repo;
        }

        // GET api/values
        [HttpGet]
        [SwaggerOperation("CursistGetAll")]
        [ProducesResponseType(typeof(IEnumerable<Cursist>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Foutmelding), (int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            try
            {

                return new OkObjectResult(_repo.FindAll());

            }
            catch (Exception)
            {
                var error = new Foutmelding(ErrorTypes.Unknown, "Oops, something went wrong");
                return BadRequest(error);
            }
        }

 

        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }

        // POST api/values
        [HttpPost]
        [SwaggerOperation("PostCursist")]
        [ProducesResponseType(typeof(Cursist), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Foutmelding), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody]Cursist value)
        {
            if (!ModelState.IsValid)
            {
                var error = new Foutmelding(ErrorTypes.BadRequest, "Modelstate invalid");
                return BadRequest(error);
            }

            try
            {
                _repo.Insert(value);
                return Ok();
            }
            catch (DbUpdateException)
            {
                var error = new Foutmelding(ErrorTypes.DuplicateKey, "This key already exist");
                return BadRequest(error);
            }
            catch (Exception)
            {
                var error = new Foutmelding(ErrorTypes.Unknown, "Oops, something went wrong");
                return NotFound(error);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerOperation("GetByIDCursist")]
        [ProducesResponseType(typeof(Cursist), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Foutmelding), (int)HttpStatusCode.NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                return new OkObjectResult(_repo.Find(id));

            }
            catch (ArgumentNullException)
            {
                var error = new Foutmelding(ErrorTypes.NotFound, "Object not found");
                return NotFound(error);
            }
            catch (Exception)
            {
                var error = new Foutmelding(ErrorTypes.Unknown, "Oops, something went wrong");
                return BadRequest(error);
            }
        }

        // PUT api/values/5
        [HttpPut]
        [SwaggerOperation("UpdateCursist")]
        [ProducesResponseType(typeof(Cursist), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Foutmelding), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Foutmelding), (int)HttpStatusCode.NotFound)]
        public IActionResult Put([FromBody]Cursist value)
        {
            if (!ModelState.IsValid)
            {
                var error = new Foutmelding(ErrorTypes.BadRequest, "Modelstate invalid");
                return BadRequest(error);
            }

            try
            {
                _repo.Update(value);
                return Ok();

            }
            catch (DbUpdateException)
            {
                var error = new Foutmelding(ErrorTypes.NotFound, "This object does not exist");
                return NotFound(error);
            }
            catch (Exception)
            {
                var error = new Foutmelding(ErrorTypes.Unknown, "Oops, something went wrong");
                return BadRequest(error);
            }
        }

        // GET api/values/5
        [HttpGet("{cursusId}")]
        [SwaggerOperation("GetCursistenByInschrijving")]
        [ProducesResponseType(typeof(IEnumerable<Cursist>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Foutmelding), (int)HttpStatusCode.NotFound)]
        public IActionResult GetInschrijvingen(int cursusId)
        {
            try
            {
                return new OkObjectResult(_repo.FindBy(c=>c.CursusInstantieID == cursusId));
            }            
            catch (Exception)
            {
                var error = new Foutmelding(ErrorTypes.Unknown, "Oops, something went wrong");
                return BadRequest(error);
            }
        }
    }
}
