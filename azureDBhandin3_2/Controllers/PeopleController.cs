using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using azureDBhandin3_2.Models;
using azureDBhandin3_2.Repository;
using Microsoft.AspNetCore.Mvc;

namespace azureDBhandin3_2.Controllers
{
    public class PeopleController : Controller
    {
        IRepository<Person> _repo => new Repository<Person>();
        
        [Route("api/[controller]")]

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async void CreatePersonAsync([Bind(Include = "PersonId, FirstName, LastName, Nationality, Gender, Address, Email")] Person person)
        {
            await _repo.CreatePersonAsync(person);
        }
    }
}
