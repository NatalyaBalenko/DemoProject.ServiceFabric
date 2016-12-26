using System.Collections.Generic;
using DemoProject.ServiceFabric.Common;
using DemoProject.ServiceFabric.CourseDatabase.Models;
using MongoDB.Driver;

namespace DemoProject.ServiceFabric.CourseDatabase
{
    public class CourseRepository : BaseDbContext, ICourseRepository
    {
        private IMongoCollection<Course> Courses => Database.GetCollection<Course>("courses");

        public Course GetCourseById(string id)
        {
            return Courses.Find(x => x.Id == id).FirstOrDefault();
        }

        public Course GetCourseByName(string name)
        {
            return Courses.Find(x => x.Name == name).FirstOrDefault();
        }

        public List<Course> GetCourses()
        {
            return Courses.Find(Builders<Course>.Filter.Empty).ToList();
        }

        public void CreateNewCourse(Course course)
        {
            Courses.InsertOne(course);
        }

        public void UpdateCourse(Course course)
        {
            var update = Builders<Course>.Update
                .Set(x => x.Name, course.Name)
                .Set(x => x.Skill, course.Skill);
            Courses.UpdateOne(x => x.Id == course.Id, update);
        }

        public void DeleteCourse(string objectId)
        {
            Courses.FindOneAndDelete(x => x.Id == objectId);
        }
    }
}