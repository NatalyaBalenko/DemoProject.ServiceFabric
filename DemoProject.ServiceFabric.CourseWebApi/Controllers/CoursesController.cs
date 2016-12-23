using System.Collections.Generic;
using System.Web.Http;
using DemoProject.ServiceFabric.CourseDatabase.Models;

namespace DemoProject.ServiceFabric.CourseWebApi.Controllers
{
    [ServiceRequestActionFilter]
    public class CoursesController : ApiController
    {
        public CoursesController(ICourseDbContext context)
        {
            Context = context;
        }

        private ICourseDbContext Context{ get; set; }
        // GET api/courses
        public IEnumerable<Course> Get()
        {
            return Context.GetCourses();
        }

        // GET api/courses/5 
        public Course Get(string id)
        {
            return Context.GetCourseById(id);
        }

        // POST api/coursess 
        public void Post([FromBody] string value)
        {
        }

        // PUT api/coursess/5 
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/courses/5 
        public void Delete(int id)
        {
        }
    }
}