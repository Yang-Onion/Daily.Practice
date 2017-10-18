using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiDemo.Models;
using WebApiDemo.Services;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var models = _personService.GetAll();

            return Ok(models);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = _personService.Get(id);

            return Ok(model);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Person model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = _personService.Add(model);

            return CreatedAtAction("Get", new { id = person.Id }, person);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Person model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _personService.Update(id, model);

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }

    }
}
