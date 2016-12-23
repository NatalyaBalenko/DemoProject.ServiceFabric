using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoProject.ServiceFabric.Common;
using DemoProject.ServiceFabric.CourseDatabase.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DemoProject.ServiceFabric.CourseDatabase
{
    public class CourseDbContext : BaseDbContext, ICourseDbContext
    {
        private IMongoCollection<Course> Courses => Database.GetCollection<Course>("courses");

        public Course GetCourseById(string id)
        {
            return Courses.Find(x => x.Id == new ObjectId(id)).FirstOrDefault();
        }

        public Course GetCourseByName(string name)
        {
            return Courses.Find(x => x.Name == name).FirstOrDefault();
        }

        public List<Course> GetCourses()
        {
            return Courses.Find(Builders<Course>.Filter.Empty).ToList();
        }
    }
}