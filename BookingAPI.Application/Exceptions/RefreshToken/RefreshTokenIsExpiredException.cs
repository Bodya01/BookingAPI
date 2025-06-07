using ApplicationException = BookingAPI.Application.Exceptions.Abstractions.ApplicationException;

namespace BookingAPI.Application.Exceptions.RefreshToken
{
    public sealed class RefreshTokenIsExpiredException : ApplicationException
    {
        public RefreshTokenIsExpiredException(string? message) : base(message) { }
    }
}