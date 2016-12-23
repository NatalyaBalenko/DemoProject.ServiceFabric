using DemoProject.ServiceFabric.CourseDatabase.Models;
using Microsoft.Practices.Unity;
using System.Web.Http;
using DemoProject.ServiceFabric.CourseDatabase;
using Unity.WebApi;

namespace DemoProject.ServiceFabric.CourseWebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
            var container = new UnityContainer();
            config.DependencyResolver = new UnityDependencyResolver(container);
            container.RegisterType<ICourseDbContext, CourseDbContext>();
        }
    }
}