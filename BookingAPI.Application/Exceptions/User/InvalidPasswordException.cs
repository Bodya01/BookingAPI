using System.Net;
using ApplicationException = BookingAPI.Application.Exceptions.Abstractions.ApplicationException;

namespace BookingAPI.Application.Exceptions.User
{
    public sealed class InvalidPasswordException : ApplicationException
    {
        public InvalidPasswordException(HttpStatusCode code) : base(code) { }

        public InvalidPasswordException(HttpStatusCode code, string? message) : base(code, message) { }
    }
}