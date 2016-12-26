using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoProject.ServiceFabric.Common.Data;
using DemoProject.ServiceFabric.Common.Filters;

namespace DemoProject.ServiceFabric.Common
{
    public abstract class BaseApiController<TEntity> : ApiController where TEntity : EntityBase
    {
        public BaseApiController(IRepository<TEntity> context)
        {
            Context = context;
        }

        private IRepository<TEntity> Context { get; }


        // GET api/controller
        public IEnumerable<TEntity> Get()
        {
            return Context.GetAll();
        }

        // GET api/controller/5860d9093d878a0b6c7cfe53
        public TEntity Get(string id)
        {
            return Context.GetById(id);
        }

        // POST api/controller
        [ValidateModel]
        public HttpResponseMessage Post([FromBody] TEntity course)
        {
            Context.Insert(course);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // PUT api/controller/5860d9093d878a0b6c7cfe53
        [ValidateModel]
        public HttpResponseMessage Put([FromBody] TEntity course)
        {
            Context.Update(course);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE api/controller/5860d9093d878a0b6c7cfe53
        public HttpResponseMessage Delete(string id)
        {
            Context.Delete(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}