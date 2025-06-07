using ApplicationException = BookingAPI.Application.Exceptions.Abstractions.ApplicationException;

namespace BookingAPI.Application.Exceptions.User
{
    public sealed class InvalidPasswordException : ApplicationException
    {
        public InvalidPasswordException(string? message) : base(message) { }
    }
}