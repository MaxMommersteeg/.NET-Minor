using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Backend.Entities;
using Backend.DAL;

namespace Backend.Controllers
{
    [Route("api/v1/[controller]")]
    public class KoffieController : Controller
    {
        private readonly IRepository<Koffie, int> _koffieRepository;

        public KoffieController(IRepository<Koffie, int> koffieRepository)
        {
            _koffieRepository = koffieRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Koffie> Get()
        {
            return _koffieRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Koffie Get(int id)
        {
            return _koffieRepository.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Koffie item)
        {
            _koffieRepository.Insert(item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Koffie value)
        {
            value.Id = id;
            _koffieRepository.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _koffieRepository.Delete(id);
        }
    }
}
