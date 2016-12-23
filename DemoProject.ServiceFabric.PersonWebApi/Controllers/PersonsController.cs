using System.Collections.Generic;
using System.Web.Http;
using DemoProject.ServiceFabric.PersonDataBase;
using DemoProject.ServiceFabric.PersonDataBase.Models;

namespace DemoProject.ServiceFabric.PersonWebApi.Controllers
{
    [ServiceRequestActionFilter]
    public class PersonsController : ApiController
    {
        public PersonsController(IPersonDbContext context)
        {
            Context = context;
        }

        private IPersonDbContext Context { get; set; }

        public IEnumerable<Person> Get()
        {
            return Context.GetPersons();
        }

        // GET api/persons/5 
        public Person Get(string id)
        {
            return Context.GetPersonById(id);
        }

        // POST api/persons 
        public void Post([FromBody] string value)
        {
        }

        // PUT api/persons/5 
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/persons/5 
        public void Delete(int id)
        {
        }
    }
}