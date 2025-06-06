using ApplicationException = BookingAPI.Application.Exceptions.Abstractions.ApplicationException;
using System.Net;

namespace BookingAPI.Application.Exceptions.Room
{
    public sealed class RoomNotFoundException : ApplicationException
    {
        public RoomNotFoundException(HttpStatusCode code) : base(code) { }

        public RoomNotFoundException(HttpStatusCode code, string? message) : base(code, message) { }
    }
}