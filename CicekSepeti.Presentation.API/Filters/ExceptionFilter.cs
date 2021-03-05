using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace CicekSepeti.Presentation.API.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            string errorMessage = string.Empty;
            var exceptionType = context.Exception.GetType();
            switch (context.Exception)
            {
                case NullReferenceException:
                    errorMessage = "Data is null";
                    httpStatusCode = HttpStatusCode.NotFound;
                    _logger.LogError(context.Exception, context.Exception.Message);
                    break;
                case UnauthorizedAccessException:
                    errorMessage = "Unauthorized Access";
                    httpStatusCode = HttpStatusCode.Unauthorized;
                    _logger.LogError(context.Exception, context.Exception.Message);
                    break;
                default:
                    errorMessage = "Unexpected Error";
                    httpStatusCode = HttpStatusCode.InternalServerError;
                    _logger.LogError(context.Exception, context.Exception.Message);
                    break;
            }
            base.OnException(context);
        }
    }
}
