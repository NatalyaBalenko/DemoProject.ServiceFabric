﻿using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DemoProject.ServiceFabric.PersonWebApi
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    internal sealed class ServiceRequestActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            ServiceEventSource.Current.ServiceRequestStart(actionContext.ActionDescriptor.ActionName);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            ServiceEventSource.Current.ServiceRequestStop(
                actionExecutedContext.ActionContext.ActionDescriptor.ActionName,
                actionExecutedContext.Exception?.ToString() ?? string.Empty);
        }
    }
}