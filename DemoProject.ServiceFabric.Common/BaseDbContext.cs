using System.Configuration;
using MongoDB.Driver;

namespace DemoProject.ServiceFabric.Common
{
    public class BaseDbContext 
    {
        public BaseDbContext()
        {
            var client = new MongoClient(ConfigurationManager.AppSettings.Get("MongoDbConnectionString"));
            Database = client.GetDatabase(ConfigurationManager.AppSettings.Get("MongoDbName"));
        }

        protected IMongoDatabase Database { get; set; }
    }
}