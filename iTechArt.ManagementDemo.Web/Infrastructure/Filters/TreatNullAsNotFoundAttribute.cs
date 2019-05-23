using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace iTechArt.ManagementDemo.Web.Infrastructure.Filters
{
    [AttributeUsage(
        AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class TreatNullAsNotFoundAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var result = context.Result;

            if (result is ObjectResult objectResult
                && objectResult.Value is null)
            {
                context.Result = new NotFoundResult();

                return;
            }

            if (result is ViewResult viewResult
                && viewResult.Model is null)
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}
