using ElderCareServerSide.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderCareServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssociationsController : ControllerBase
    {
        // GET: api/<AssociationsController>
        [HttpGet]
        public IEnumerable<Association> Get()
        {
            return Association.ReadAll();
        }

        // GET: api/<AssociationsController>
        [HttpGet("cities")]
        public IEnumerable<string> GetCities()
        {
            return Association.ReadCities();
        }

        // GET api/<AssociationsController>/5
        [HttpGet("{id}")]
        public List<Association> GetByID(int id)
        {
            return Association.Read(id);
        }

        // GET api/<AssociationsController>/5
        [HttpGet("new/{id}")]
        public Object Get(string id)
        {
            Association a = new Association();
            return a.GetNewApps(id);
        }

        // GET api/<AssociationsController>/5
        [HttpGet("all/{id}")]
        public Object GetAll(string id)
        {
            Association a = new Association();
            return a.GetAllApps(id);
        }

        // GET api/<AssociationsController>/5
        [HttpGet("closed/{id}")]
        public Object GetClosed(string id)
        {
            Association a = new Association();
            return a.GetClosedApps(id);
        }

        //GET api/<AssociationsController>/5
        [HttpGet("email/{email}/password/{password}")]
        public IActionResult Get(string email, string password)
        {
            Association association = new Association();
            association = Association.Login(email, password);
            if (association != null)
                return Ok(association);
            else
                return NotFound();
        }

        // GET api/<AssociationsController>/5
        [HttpGet("helpType/{helpType}/city/{city}")]
        public List<Association> GetByParameters(string helpType, string city)
        {
            return Association.ReadByParameters(helpType, city);
        }

        // POST api/<AssociationsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AssociationsController>
        [HttpPut]
        public IActionResult Put([FromBody] Association association)
        {
            int numEffected = association.updateScore();
            if (numEffected == 1)
                return Ok(association);
            else
                return NotFound("association was not found");
        }

        // DELETE api/<AssociationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
