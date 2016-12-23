using System.Collections.Generic;
using System.Configuration;
using DemoProject.ServiceFabric.Common;
using DemoProject.ServiceFabric.PersonDataBase.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DemoProject.ServiceFabric.PersonDataBase
{
    public class PersonPersonDbContext : BaseDbContext, IPersonDbContext
    {
        private IMongoCollection<Person> Persons => Database.GetCollection<Person>("persons");

        public Person GetPersonById(string personId)
        {
            return Persons.Find(x => x.Id == new ObjectId(personId)).FirstOrDefault();
        }

        public Person GetPersonByName(string personName)
        {
            return Persons.Find(x => x.Name == personName).FirstOrDefault();
        }

        public List<Person> GetPersons()
        {
            return Persons.Find(Builders<Person>.Filter.Empty).ToList();
        }
    }
}