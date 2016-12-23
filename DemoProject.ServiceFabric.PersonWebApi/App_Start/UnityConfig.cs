using DemoProject.ServiceFabric.PersonDataBase;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace DemoProject.ServiceFabric.PersonWebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
			var container = new UnityContainer();
            config.DependencyResolver = new UnityDependencyResolver(container);
            container.RegisterType<IDbContext, PersonDbContext>();
        }
    }
}