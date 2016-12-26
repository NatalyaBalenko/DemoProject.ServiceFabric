using System;
using DemoProject.ServiceFabric.Common.Data;
using MongoDB.Bson;

namespace DemoProject.ServiceFabric.PersonDataBase.Models
{
    public class CourseLearning : EntityBase
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsFinished => EndDate.HasValue;
        public ObjectId CourseId { get; set; }
    }
}