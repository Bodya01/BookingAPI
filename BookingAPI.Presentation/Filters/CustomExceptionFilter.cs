using BookingAPI.Domain.DDD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Text.RegularExpressions;
using ApplicationException = BookingAPI.Application.Exceptions.Abstractions.ApplicationException;


namespace BookingAPI.Presentation.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var runtimeTypeName = exception.GetType().Name;
            var parsedName = ParseExceptionName(runtimeTypeName);
            var messageWithType = $"{parsedName}: {exception.Message}";

            if (exception is DomainException domainEx)
            {
                context.Result = new BadRequestObjectResult(messageWithType);
                context.ExceptionHandled = true;
                return;
            }

            if (exception is ApplicationException appEx)
            {
                var statusCode = (int)appEx.Code;

                context.Result = new ObjectResult(messageWithType)
                {
                    StatusCode = statusCode
                };
                context.ExceptionHandled = true;
                return;
            }

            // default fallback
            context.Result = new ObjectResult("An unexpected error occurred.")
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
            context.ExceptionHandled = true;
        }

        private string ParseExceptionName(string typeName)
        {
            const string suffix = "Exception";
            if (typeName.EndsWith(suffix, StringComparison.Ordinal))
            {
                typeName = typeName.Substring(0, typeName.Length - suffix.Length);
            }

            var withSpaces = Regex.Replace(typeName, "(?<!^)([A-Z])", " $1");
            return withSpaces;
        }
    }
}