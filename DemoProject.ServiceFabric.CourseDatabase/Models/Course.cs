using DemoProject.ServiceFabric.Common.Data;
using Microsoft.Build.Framework;
using MongoDB.Bson.Serialization.Attributes;

namespace DemoProject.ServiceFabric.CourseDatabase.Models
{
    public class Course : EntityBase
    {
        public Course()
        {
        }

        public Course(string name, string skill = null)
        {
            Name = name;
            Skill = skill ?? name;
        }

        [Required]
        [BsonRequired]
        public string Name { get; set; }

        public string Skill { get; set; }
    }
}