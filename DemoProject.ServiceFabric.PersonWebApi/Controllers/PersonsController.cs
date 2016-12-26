using DemoProject.ServiceFabric.Common;
using DemoProject.ServiceFabric.Common.Data;
using DemoProject.ServiceFabric.PersonDataBase.Models;

namespace DemoProject.ServiceFabric.PersonWebApi.Controllers
{
    [ServiceRequestActionFilter]
    public class PersonsController : BaseApiController<Person>
    {
        public PersonsController(IRepository<Person> context) : base(context)
        {
        }
    }
}