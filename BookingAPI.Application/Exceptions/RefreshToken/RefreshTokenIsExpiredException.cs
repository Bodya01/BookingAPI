using System.Net;
using ApplicationException = BookingAPI.Application.Exceptions.Abstractions.ApplicationException;

namespace BookingAPI.Application.Exceptions.RefreshToken
{
    public sealed class RefreshTokenIsExpiredException : ApplicationException
    {
        public RefreshTokenIsExpiredException(HttpStatusCode code) : base(code) { }

        public RefreshTokenIsExpiredException(HttpStatusCode code, string? message) : base(code, message) { }
    }
}