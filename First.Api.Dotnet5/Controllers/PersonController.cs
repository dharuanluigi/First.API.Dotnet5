using First.API.Business;
using First.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace First.API.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        [HttpGet]
        public IActionResult GetAllPeople()
        {
            var result = _personBusiness.FindAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonById(long id)
        {
            var result = _personBusiness.FindById(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult AddPerson([FromBody] Person person)
        {
            if (person != null)
            {
                var result = _personBusiness.Create(person);

                return Ok(result);
            }

            return BadRequest("One or more fields are invalid");
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            if (person != null)
            {
                var result = _personBusiness.Update(person);

                return Ok(result);
            }

            return BadRequest("One or more fields are invalid");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}