using System.Net;

namespace BookingAPI.Application.Exceptions.Abstractions
{
    public abstract class ApplicationException : Exception
    {
        public HttpStatusCode Code { get; init; }

        protected ApplicationException(HttpStatusCode code)
            => Code = code;

        protected ApplicationException(HttpStatusCode code, string? message) : base(message)
            => Code = code;
    }
}