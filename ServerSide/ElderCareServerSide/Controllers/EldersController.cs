using ElderCareServerSide.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderCareServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EldersController : ControllerBase
    {
        // GET: api/<EldersController>
        [HttpGet]
        public IEnumerable<Elder> Get()
        {
            return Elder.Read();
        }

        // GET api/<EldersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EldersController>
        [HttpPost]
        public IActionResult Post([FromBody] Elder elder)
        {
            int numEffected = elder.Insert();
            if (numEffected == 1)
                return Ok(elder);
            else
                return NotFound();
        }

        // PUT api/<EldersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EldersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
