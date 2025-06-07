using ApplicationException = BookingAPI.Application.Exceptions.Abstractions.ApplicationException;

namespace BookingAPI.Application.Exceptions.Room
{
    public sealed class RoomAlreadyBookedException : ApplicationException
    {
        public RoomAlreadyBookedException(string? message) : base(message) { }
    }
}