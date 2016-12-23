using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DemoProject.ServiceFabric.PersonDataBase.Models
{
    public class Person
    {
        public Person()
        {
        }

        public Person(string name, int age)
        {
            Id = ObjectId.GenerateNewId();
            Name = name;
            Age = age;
            Skills = new List<string>();
            CourseLearnings = new List<CourseLearning>();
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public bool IsAdult => Age > 21;

        public List<string> Skills { get; set; }

        public bool Sex { get; set; }
        public List<CourseLearning> CourseLearnings { get; set; }
    }

    public class CourseLearning
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsFinished => EndDate.HasValue;
        public ObjectId CourseId { get; set; }
    }
}
