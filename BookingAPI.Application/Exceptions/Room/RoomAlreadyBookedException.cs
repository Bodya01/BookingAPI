using System.Net;
using ApplicationException = BookingAPI.Application.Exceptions.Abstractions.ApplicationException;

namespace BookingAPI.Application.Exceptions.Room
{
    public sealed class RoomAlreadyBookedException : ApplicationException
    {
        public RoomAlreadyBookedException(HttpStatusCode code) : base(code) { }

        public RoomAlreadyBookedException(HttpStatusCode code, string? message) : base(code, message) { }
    }
}