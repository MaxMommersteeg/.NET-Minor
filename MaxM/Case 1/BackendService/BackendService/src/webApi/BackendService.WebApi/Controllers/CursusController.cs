using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using System.Net;
using Microsoft.EntityFrameworkCore;
using BackendService.WebApi.Errors;
using BackendService.Entities.Entities;
using BackendService.DAL.DAL;
using System.Diagnostics;
using System.Linq;
using BackendService.WebApi.Extensions;

namespace BackendService.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class CursusController : Controller
    {
        private readonly IRepository<Cursus, int> _cursusRepository;

        public CursusController(IRepository<Cursus, int> cursusRepository)
        {
            _cursusRepository = cursusRepository;
        }

        // GET api/v1/cursus/{weekyearViewModel}
        [HttpGet("{year}/{weeknumber}")]
        [ProducesResponseType(typeof(IEnumerable<Cursus>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        public IActionResult GetByWeekAndYear(int weeknumber, int year)
        {
            try
            {
                // Find cursussen for given weeknumber and year 
                var cursussen = _cursusRepository.FindBy
                (
                    x => x.StartDate.GetIso8601WeekOfYear() == weeknumber &&
                    x.StartDate.Year == year
                )
                .OrderBy(x => x.StartDate); // Sort by StartDate
                // Return curssuen
                return new OkObjectResult(cursussen);
            }
            catch (Exception)
            {
                var error = new ErrorMessage(ErrorTypes.Unknown, "Oops, something went wrong");
                return BadRequest(error);
            }
        }

        // GET api/v1/cursus/{cursuscode}/{startdate}
        [HttpGet("{cursuscode}/{year}/{month}/{day}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        public IActionResult GetByCursusCodeAndStartDateExists(string cursuscode, int year, int month, int day)
        {
            try
            {
                // Check if cursus exist for code and date
                var exists = _cursusRepository.FindBy(x => x.StartDate.Year == year && x.StartDate.Month == month && x.StartDate.Day == day).FirstOrDefault() != null;
                // return result
                return new OkObjectResult(exists);
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
        [ProducesResponseType(typeof(Cursus), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody]Cursus cursus)
        {
            // Check if given cursus is valid
            if (!ModelState.IsValid)
            {
                var error = new ErrorMessage(ErrorTypes.BadRequest, "Modelstate invalid");
                return BadRequest(error);
            }

            try
            {
                // Insert cursus
                _cursusRepository.Insert(cursus);
                return Ok();
            }
            catch (DbUpdateException due)
            {
                Debug.WriteLine(due);
                var error = new ErrorMessage(ErrorTypes.DuplicateKey, "This key already exist", "Use a non-existing key");
                return BadRequest(error);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                var error = new ErrorMessage(ErrorTypes.Unknown, "Oops, something went wrong");
                return NotFound(error);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _cursusRepository?.Dispose();
            base.Dispose(disposing);
        }
    }
}
