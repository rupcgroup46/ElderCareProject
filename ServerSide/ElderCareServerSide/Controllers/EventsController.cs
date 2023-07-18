using ElderCareServerSide.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderCareServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        // GET: api/<EventsController>
        [HttpGet]
        public Object Get()
        {
            Eventt e = new Eventt();
            return e.ReadAll();
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EventsController>
        [HttpPost]
        public IActionResult Post([FromBody] Eventt eventt)
        {
            int numEffected = eventt.Insert();
            if (numEffected == 1)
                return Ok(eventt);
            else
                return NotFound();
        }

        // PUT api/<EventsController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Eventt e)
        {
            int numEffected = e.Update();
            if (numEffected == 1)
                return Ok(e);
            else
                return NotFound("event was not found");
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
