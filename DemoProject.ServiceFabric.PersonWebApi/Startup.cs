using System.Web.Http;
using DemoProject.ServiceFabric.Common.Filters;
using Owin;

namespace DemoProject.ServiceFabric.PersonWebApi
{
    public static class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public static void ConfigureApp(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            UnityConfig.RegisterComponents(config);
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );
            config.Filters.Add(new ValidateModelAttribute());
            appBuilder.UseWebApi(config);
        }
    }
}