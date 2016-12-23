﻿using System.Collections.Generic;
using DemoProject.ServiceFabric.PersonDataBase.Models;

namespace DemoProject.ServiceFabric.PersonDataBase
{
    public interface IDbContext
    {
        Person GetPersonById(string personId);
        Person GetPersonByName(string personName);
        List<Person> GetPersons();
    }
}