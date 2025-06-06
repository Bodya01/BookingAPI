using System.Net;
using ApplicationException = BookingAPI.Application.Exceptions.Abstractions.ApplicationException;

namespace BookingAPI.Application.Exceptions.User
{
    public sealed class UserNotFoundException : ApplicationException
    {
        public UserNotFoundException(HttpStatusCode code) : base(code) { }

        public UserNotFoundException(HttpStatusCode code, string? message) : base(code, message) { }
    }
}