using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DemoProject.ServiceFabric.Common.Data
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(string id);

        IList<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);

        IList<TEntity> GetAll();

        TEntity GetById(string id);
    }
}