using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace DemoProject.ServiceFabric.Common.Data
{
    public class MongoDbRepository<TEntity> :
        IRepository<TEntity> where
        TEntity : EntityBase
    {
        private IMongoCollection<TEntity> _collection;
        private IMongoDatabase _database;

        public MongoDbRepository()
        {
            GetDatabase();
            GetCollection();
        }

        public void Insert(TEntity entity)
        {
            _collection.InsertOne(entity);
        }

        public void Update(TEntity entity)
        {
            _collection.ReplaceOne(x => x.Id == entity.Id, entity);
        }

        public void Delete(TEntity entity)
        {
            _collection.DeleteOne(x => x.Id == entity.Id);
        }

        public void Delete(string id)
        {
            _collection.DeleteOne(x => x.Id == id);
        }


        public IList<TEntity>
            SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection
                .AsQueryable()
                .Where(predicate.Compile())
                .ToList();
        }

        public IList<TEntity> GetAll()
        {
            return _collection.Find(Builders<TEntity>.Filter.Empty).ToList();
        }

        public TEntity GetById(string id)
        {
            return _collection.Find(x => x.Id == id).FirstOrDefault();
        }

        public void Update(TEntity course, UpdateDefinition<TEntity> update)
        {
            _collection.UpdateOne(x => x.Id == course.Id, update);
        }

        #region Private Helper Methods

        private void GetDatabase()
        {
            var client = new MongoClient(ConnectionString);
            _database = client.GetDatabase(DatabaseName);
        }

        private string ConnectionString =>
            ConfigurationManager
                .AppSettings
                .Get("MongoDbConnectionString")
                .Replace("{DB_NAME}", DatabaseName);


        private string DatabaseName => ConfigurationManager
            .AppSettings
            .Get("MongoDbName");


        private void GetCollection()
        {
            _collection = _database
                .GetCollection<TEntity>(typeof(TEntity).Name);
        }

        #endregion
    }
}