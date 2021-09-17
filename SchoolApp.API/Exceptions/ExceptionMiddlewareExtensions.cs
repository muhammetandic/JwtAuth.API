using JwtAuth.API.Data.Responses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System.Net;

namespace JwtAuth.API.Exceptions
{
    public static class ExceptionMiddlewareExtensions
    {
        // Builtin Exception Handler
        public static void ConfigureBuiltInExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var contextRequest = context.Features.Get<IHttpRequestFeature>();

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    if (contextFeature!=null)
                    {
                        var errorString = new ErrorResponse()
                        {
                            StatusCode = (int)HttpStatusCode.InternalServerError,
                            Message = contextFeature.Error.Message,
                            Path = contextRequest.Path
                        }.ToString();
                        await context.Response.WriteAsync(errorString);
                    }
                });
            });
        }
    }
}
