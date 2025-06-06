using System.Net;
using ApplicationException = BookingAPI.Application.Exceptions.Abstractions.ApplicationException;

namespace BookingAPI.Application.Exceptions.User
{
    public sealed class EmailAlreadyTakenException : ApplicationException
    {
        public EmailAlreadyTakenException(HttpStatusCode code) : base(code) { }

        public EmailAlreadyTakenException(HttpStatusCode code, string? message) : base(code, message) { }
    }
}