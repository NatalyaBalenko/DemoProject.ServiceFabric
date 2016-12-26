using System.Collections.Generic;
using DemoProject.ServiceFabric.Common.Data;

namespace DemoProject.ServiceFabric.PersonDataBase.Models
{
    public class Person : EntityBase
    {
        public Person()
        {
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Skills = new List<string>();
            CourseLearnings = new List<CourseLearning>();
        }


        public string Name { get; set; }
        public int Age { get; set; }

        public bool IsAdult => Age > 21;

        public List<string> Skills { get; set; }

        public bool Sex { get; set; }
        public List<CourseLearning> CourseLearnings { get; set; }
    }
}