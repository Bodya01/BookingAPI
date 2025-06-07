using ApplicationException = BookingAPI.Application.Exceptions.Abstractions.ApplicationException;

namespace BookingAPI.Application.Exceptions.User
{
    public sealed class EmailAlreadyTakenException : ApplicationException
    {
        public EmailAlreadyTakenException(string? message) : base(message) { }
    }
}