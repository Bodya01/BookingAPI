using ApplicationException = BookingAPI.Application.Exceptions.Abstractions.ApplicationException;

namespace BookingAPI.Application.Exceptions.User
{
    public sealed class UserWasNotCreatedException : ApplicationException
    {
        public UserWasNotCreatedException(string? message) : base(message) { }
    }
}