using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using azureDBhandin3_2.Models;
using azureDBhandin3_2.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace azureDBhandin3_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        IRepository<Person> _repo = new Repository<Person>();

        // GET: api/Person
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public Person Get(string id)
        {
            return _repo.getPerson(id);
        }

        // POST: api/Person
        [HttpPost]
        public void Post([FromBody] Person person)
        {
            _repo.CreatePersonAsync(person);
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Person person)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }
    }
}
