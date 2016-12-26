using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoProject.ServiceFabric.Common.Filters;
using DemoProject.ServiceFabric.CourseDatabase.Models;

namespace DemoProject.ServiceFabric.CourseWebApi.Controllers
{
    [ServiceRequestActionFilter]
    public class CoursesController : ApiController
    {
        public CoursesController(ICourseRepository context)
        {
            Context = context;
        }

        private ICourseRepository Context { get; }
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
        [ValidateModel]
        public HttpResponseMessage Post([FromBody] Course course)
        {
            Context.CreateNewCourse(course);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // PUT api/courses/5860d9093d878a0b6c7cfe53
        [ValidateModel]
        public HttpResponseMessage Put([FromBody] Course course)
        {
            Context.UpdateCourse(course);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE api/courses/5860d9093d878a0b6c7cfe53
        public HttpResponseMessage Delete(string id)
        {
            Context.DeleteCourse(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}