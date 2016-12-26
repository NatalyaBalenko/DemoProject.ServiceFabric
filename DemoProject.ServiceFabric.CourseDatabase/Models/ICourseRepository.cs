using System.Collections.Generic;

namespace DemoProject.ServiceFabric.CourseDatabase.Models
{
    public interface ICourseRepository
    {
        Course GetCourseById(string id);
        Course GetCourseByName(string name);
        List<Course> GetCourses();
        void CreateNewCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(string objectId);
    }
}