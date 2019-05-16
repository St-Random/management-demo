using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iTechArt.ManagementDemo.Web.Models;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using iTechArt.ManagementDemo.Web.Infrastructure.Filters;

namespace iTechArt.ManagementDemo.Web.Controllers
{
    public class ErrorController : Controller
    {
        [ResponseCache(
            Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Index()
        {
            var model = GetErrorModel(
                @"An error had occured. Please retry your request
 later or contact the support.");

            if (Request.Headers["Accept"].Contains(
                MediaTypeNames.Application.Json))
            {
                return Json(model);
            }

            return View(model);
        }

        //[ResponseCache(
        //    Duration = 0,
        //    Location = ResponseCacheLocation.None,
        //    NoStore = true)]
        //public IActionResult Error404()
        //{
        //    var model = GetErrorModel(
        //        @"The requested item is not found.");

        //    if (Request.Headers["Accept"].Contains(
        //        MediaTypeNames.Application.Json))
        //    {
        //        return Json(model);
        //    }

        //    return View(model);
        //}

        private ErrorViewModel GetErrorModel(string message) =>
            new ErrorViewModel
            {
                RequestId = Activity.Current?.Id
                        ?? HttpContext.TraceIdentifier,
                Message = message
            };
    }
}
