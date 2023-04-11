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

        [HttpGet("all")]
        public Object getAll()
        {
            Application a = new Application();
            return a.getAllApps();
        }

        [HttpGet("new")]
        public Object getNew()
        {
            Application a = new Application();
            return a.getNewApps();
        }

        [HttpGet("closed")]
        public Object getClosed()
        {
            Application a = new Application();
            return a.getClosedApps();
        }

        [HttpGet("denied")]
        public Object getDenied()
        {
            Application a = new Application();
            return a.getDeniedApps();
        }

        // GET api/<ApplicationsController>/5
        [HttpGet("{id}")]
        public List<Application> Get(int id)
        {
            return Application.Read(id);
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

        // PUT api/<ApplicationsController>
        [HttpPut]
        public IActionResult Put([FromBody] Application application)
        {
            int numEffected = application.changeStatus();
            if (numEffected == 1)
                return Ok(application);
            else
                return NotFound("application was not found");
        }

        // DELETE api/<ApplicationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
