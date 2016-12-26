using DemoProject.ServiceFabric.Common;
using DemoProject.ServiceFabric.Common.Data;
using DemoProject.ServiceFabric.CourseDatabase.Models;

namespace DemoProject.ServiceFabric.CourseWebApi.Controllers
{
    [ServiceRequestActionFilter]
    public class CoursesController : BaseApiController<Course>
    {
        public CoursesController(IRepository<Course> context) : base(context)
        {
        }
    }
}