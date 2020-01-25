using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Iris.ViewModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Iris.WebApi.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpHandler(int statusCode)
        {
            var statusCodeRes = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            ErrorViewModel errorContext; 
            switch (statusCode)
            {
                case 404:
                    errorContext = new ErrorViewModel("Http Status Code 404", statusCodeRes.OriginalPath, statusCodeRes.OriginalQueryString);
                    return Json(errorContext);
                case 500:
                    errorContext = new ErrorViewModel("Internal Server Error", statusCodeRes.OriginalPath, statusCodeRes.OriginalQueryString);
                    return Json(errorContext);
                default:
                    errorContext = new ErrorViewModel("Weird Error Occured.", statusCodeRes.OriginalPath, statusCodeRes.OriginalQueryString);
                    return Json(errorContext);
            }
        }
    }
}