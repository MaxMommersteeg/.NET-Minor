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
    public class CursusController : Controller
    {
        private IRepository<CursusInstantie, int> _repo;

        public CursusController(IRepository<CursusInstantie, int> repo)
        {
            _repo = repo;
        }

        // GET api/values
        [HttpGet]
        [SwaggerOperation("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<CursusInstantie>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Foutmelding), (int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            try
            {
                
                return new OkObjectResult(_repo.FindAll().OrderBy(c => c.Startdatum));

            }
            catch (Exception)
            {
                var error = new Foutmelding(ErrorTypes.Unknown , "Oops, something went wrong");
                return BadRequest(error);
            }
        }

        // GET api/values/
        [HttpGet("{datum}")]
        [SwaggerOperation("GetByWeek")]
        [ProducesResponseType(typeof(IEnumerable<CursusInstantie>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Foutmelding), (int)HttpStatusCode.BadRequest)]
        public IActionResult GetByWeek(string datum)
        {
            try
            {
                DateTime eersteDagWeek = DateTime.Parse(datum).StartOfWeek(DayOfWeek.Monday);
                DateTime laatsteDagWeek = eersteDagWeek.AddDays(7);
                return new OkObjectResult(_repo.FindBy(c => c.Startdatum >= eersteDagWeek && c.Startdatum < laatsteDagWeek).OrderBy(c => c.Startdatum));
            }
            catch (FormatException)
            {

                var error = new Foutmelding(ErrorTypes.IncorrectInputFormat, "datum is niet in juiste format");
                return BadRequest(error);
            }
            catch (Exception)
            {

                var error = new Foutmelding(ErrorTypes.Unknown, "Oops, something went wrong");
                return BadRequest(error);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerOperation("GetByID")]
        [ProducesResponseType(typeof(CursusInstantie), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Foutmelding), (int)HttpStatusCode.NotFound)]
        public IActionResult Get(int? id)
        {
            try
            {
                return new OkObjectResult(_repo.Find(id.Value));

            }
            catch (ArgumentNullException){
                var error = new Foutmelding(ErrorTypes.NotFound, "Object not found");
                return NotFound(error);
            }
            catch (Exception)
            {
                var error = new Foutmelding(ErrorTypes.Unknown, "Oops, something went wrong");
                return BadRequest(error);
            }
        }

        // POST api/values
        [HttpPost]        
        [SwaggerOperation("Post")]
        [ProducesResponseType(typeof(CursusInstantie), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Foutmelding), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody]CursusInstantie value)
        {
            if(!ModelState.IsValid)
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

        // PUT api/values/5
        [HttpPut]
        [SwaggerOperation("Update")]
        [ProducesResponseType(typeof(CursusInstantie), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Foutmelding), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Foutmelding), (int)HttpStatusCode.NotFound)]
        public IActionResult Put([FromBody]CursusInstantie value)
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

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [SwaggerOperation("Delete")]
        [ProducesResponseType(typeof(Cursus), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Foutmelding), (int)HttpStatusCode.BadRequest)]
        public IActionResult Delete(int id)
        {       
            try
            {
                _repo.Delete(id);
                return Ok();

            }
            catch (DbUpdateException)
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

        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }
    }
}
