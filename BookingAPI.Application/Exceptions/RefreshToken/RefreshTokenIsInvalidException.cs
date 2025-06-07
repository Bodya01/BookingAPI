using ApplicationException = BookingAPI.Application.Exceptions.Abstractions.ApplicationException;

namespace BookingAPI.Application.Exceptions.RefreshToken
{
    public sealed class RefreshTokenIsInvalidException : ApplicationException
    {
        public RefreshTokenIsInvalidException(string? message) : base(message) { }
    }
}