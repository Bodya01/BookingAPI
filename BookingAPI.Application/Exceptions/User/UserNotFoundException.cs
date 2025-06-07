using ApplicationException = BookingAPI.Application.Exceptions.Abstractions.ApplicationException;

namespace BookingAPI.Application.Exceptions.User
{
    public sealed class UserNotFoundException : ApplicationException
    {
        public UserNotFoundException(string? message) : base(message) { }
    }
}