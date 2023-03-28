using ElderCareServerSide.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderCareServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        // GET: api/<ApplicationsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ApplicationsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApplicationsController>
        [HttpPost]
        public IActionResult Post([FromBody] Application application)
        {
            int numEffected = application.Insert();
            if (numEffected == 1)
                return Ok(application);
            else
                return NotFound();
        }

        // PUT api/<ApplicationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApplicationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
