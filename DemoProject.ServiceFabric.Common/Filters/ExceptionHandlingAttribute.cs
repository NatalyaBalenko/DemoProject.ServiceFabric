using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using MongoDB.Driver;

namespace DemoProject.ServiceFabric.Common.Filters
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is MongoException)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Mongo Db Exception"
                });

            //Log Critical errors
            Debug.WriteLine(context.Exception);

            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An error occurred, please try again or contact the administrator."),
                ReasonPhrase = "Critical Exception"
            });
        }
    }
}