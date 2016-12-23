using System.Collections.Generic;

namespace DemoProject.ServiceFabric.CourseDatabase.Models
{
    public interface ICourseDbContext
    {
        Course GetCourseById(string id);
        Course GetCourseByName(string name);
        List<Course> GetCourses();
    }
}