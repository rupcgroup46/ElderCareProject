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

        // PUT api/<AssociationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AssociationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
