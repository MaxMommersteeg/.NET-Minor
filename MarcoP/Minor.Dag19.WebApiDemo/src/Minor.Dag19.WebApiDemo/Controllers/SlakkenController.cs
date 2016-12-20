using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minor.Dag19.WebApiDemo.DAL;
using Minor.Dag19.WebApiDemo.Entities;
using Swashbuckle.SwaggerGen.Annotations;
using System.Net;

namespace Minor.Dag19.WebApiDemo.Controllers
{
    [Route("api/v1/[controller]")]
    public class SlakkenController : Controller
    {
        private IRepository<Slak, long> _repository;

        public SlakkenController(IRepository<Slak, long> repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        [SwaggerOperation("GetAll")]
        public IEnumerable<Slak> Get()
        {
            return _repository.FindAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerOperation("GetByID")]
        [ProducesResponseType(typeof(Slak), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FunctionalError), (int)HttpStatusCode.NotFound)]
        public IActionResult Get(long id)
        {
            try
            {
                return Ok(_repository.FindBy(id));
            }
            catch
            {
                var error = new FunctionalError("US002.1a", "Geen Slak met deze ID");
                return this.NotFound(error);
            }
        }


        // POST api/values
        [HttpPost]
        [SwaggerOperation("Insert")]
        public void Post([FromBody, Bind("Naam")]Slak value)
        {
            _repository.Insert(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [SwaggerOperation("Update")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [SwaggerOperation("Delete")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FunctionalError), (int)HttpStatusCode.NotFound)]
        public IActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return Ok();
            }
            catch
            {
                var error = new FunctionalError("US002.1a", "Geen Slak met deze ID");
                return NotFound(error);
            }

        }
    }
}
