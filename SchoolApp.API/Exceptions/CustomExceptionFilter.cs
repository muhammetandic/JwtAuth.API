using JwtAuth.API.Data.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace JwtAuth.API.Exceptions
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<CustomExceptionFilter> _logger;

        public CustomExceptionFilter()
        {
            var loggerFactory = new LoggerFactory();
            _logger = loggerFactory.CreateLogger<CustomExceptionFilter>();
        }

        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";

            var statusCode = HttpStatusCode.InternalServerError;
            if (context.Exception is StudentNameException)
            {
                statusCode = HttpStatusCode.NotFound;
            }

            context.HttpContext.Response.StatusCode = (int)statusCode;
            var exceptionString = new ErrorResponse()
            {
                Message = context.Exception.Message,
                StatusCode = (int)statusCode,
                Path = context.Exception.StackTrace
            };
            _logger.LogInformation("Errror Ereroorror");
            context.Result = new JsonResult(exceptionString);
        }
    }
}
