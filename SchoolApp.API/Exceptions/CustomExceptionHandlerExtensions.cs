using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace JwtAuth.API.Exceptions
{
    public static class CustomExceptionHandlerExtensions
    {
        public static void ConfigureCustomExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseMiddleware<CustomExceptionHandler>(loggerFactory);
        }
    }
}
