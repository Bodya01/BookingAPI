using System.Net;
using ApplicationException = BookingAPI.Application.Exceptions.Abstractions.ApplicationException;

namespace BookingAPI.Application.Exceptions.RefreshToken
{
    public sealed class RefreshTokenIsInvalidException : ApplicationException
    {
        public RefreshTokenIsInvalidException(HttpStatusCode code) : base(code) { }

        public RefreshTokenIsInvalidException(HttpStatusCode code, string? message) : base(code, message) { }
    }
}