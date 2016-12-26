using Microsoft.Build.Framework;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DemoProject.ServiceFabric.CourseDatabase.Models
{
    public class Course
    {
        public Course()
        {
        }

        public Course(string name, string skill = null)
        {
            Name = name;
            Skill = skill ?? name;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [BsonRequired]
        public string Name { get; set; }

        public string Skill { get; set; }
    }
}