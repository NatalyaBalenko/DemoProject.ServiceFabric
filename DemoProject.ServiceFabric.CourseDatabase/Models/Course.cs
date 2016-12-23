using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DemoProject.ServiceFabric.CourseDatabase.Models
{
    public class Course
    {
        public Course(string name, string skill = null)
        {
            Id = ObjectId.GenerateNewId();
            Name = name;
            Skill = skill ?? name;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }
        public string Skill { get; set; }
    }
}
