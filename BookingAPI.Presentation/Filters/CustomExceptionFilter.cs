using BookingAPI.Application.Exceptions.RefreshToken;
using BookingAPI.Application.Exceptions.Room;
using BookingAPI.Application.Exceptions.User;
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

            if (exception is ApplicationException)
            {
                var statusCode = exception switch
                {
                    RefreshTokenIsExpiredException => HttpStatusCode.BadRequest,
                    RefreshTokenIsInvalidException => HttpStatusCode.Forbidden,

                    EmailAlreadyTakenException => HttpStatusCode.BadRequest,
                    InvalidPasswordException => HttpStatusCode.Forbidden,
                    UserNotFoundException => HttpStatusCode.NotFound,
                    UserWasNotCreatedException => HttpStatusCode.BadRequest,

                    RoomAlreadyBookedException => HttpStatusCode.BadRequest,
                    RoomNotFoundException => HttpStatusCode.NotFound,
                    _ => HttpStatusCode.InternalServerError
                };

                context.Result = new ObjectResult(messageWithType)
                {
                    StatusCode = (int)statusCode,
                };

                context.ExceptionHandled = true;

                return;
            }

            if (exception is DomainException)
            {
                context.Result = new BadRequestObjectResult(messageWithType);
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