using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Minor.Cursusbeheer.Controllers
{
    [Route("api/[controller]")]
    public class CursusController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Cursus> Get()
        {
            return new Cursus[]
            {
                new Cursus { ID=101, Naam="C# Programming", Duur = 5 },
                new Cursus { ID=121, Naam="Advanced C#", Duur = 2 },
                new Cursus { ID=134, Naam="Entity Framework", Duur = 5 },
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
