using ApplicationException = BookingAPI.Application.Exceptions.Abstractions.ApplicationException;

namespace BookingAPI.Application.Exceptions.Room
{
    public sealed class RoomNotFoundException : ApplicationException
    {
        public RoomNotFoundException(string? message) : base(message) { }
    }
}