using System;
using System.Collections.Generic;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;

[Route("api/v1/[controller]")]
public class MonumentController : Controller
{
    private IRepository<Monument, long> _MonumentenRepository;
    public MonumentController(IRepository<Monument, long> repository)
    {
        _MonumentenRepository = repository;
    }

    // GET api/values
    [HttpGet]
    public IEnumerable<Monument> Get()
    {
        return _MonumentenRepository.FindAll();
    }

    // GET api/values/5
    [HttpGet("{id}")]
    [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Monument))]
    [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Type = typeof(FunctionalError))]
    public IActionResult Get(int monumentId)
    {
        try
        {
            return Ok(_MonumentenRepository.Find(monumentId));
        }
        catch(Exception)
        {
            var error = new FunctionalError("Userstory code", "Error message: Object not found", "Remedy");
            return NotFound(error);
        }

    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody]Monument monument)
    {
        _MonumentenRepository.Add(monument);
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _MonumentenRepository.Remove(id);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int monument, [FromBody]Monument dummyMonument)
    {
        _MonumentenRepository.Update(dummyMonument);
    }
}