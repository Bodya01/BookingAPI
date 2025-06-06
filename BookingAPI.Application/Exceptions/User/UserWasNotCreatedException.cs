using System.Net;
using ApplicationException = BookingAPI.Application.Exceptions.Abstractions.ApplicationException;

namespace BookingAPI.Application.Exceptions.User
{
    internal class UserWasNotCreatedException : ApplicationException
    {
        public UserWasNotCreatedException(HttpStatusCode code) : base(code) { }

        public UserWasNotCreatedException(HttpStatusCode code, string? message) : base(code, message) { }
    }
}