using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace WebApplication.Exceptions
{
    public class ExceptionHandlerFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<ExceptionHandlerFilter> _logger;

        public ExceptionHandlerFilter()
        {
            var loggerFactory = new LoggerFactory();
            _logger = loggerFactory.CreateLogger<ExceptionHandlerFilter>();
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError("Exception Filter denemesi");
            context.ExceptionHandled = true;
        }
    }
}
