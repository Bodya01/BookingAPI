using BookingAPI.Domain.DDD;

namespace BookingAPI.Domain.Exceptions
{
    public sealed class InvalidTimeSlotException : DomainException
    {
        public InvalidTimeSlotException()
        {
        }

        public InvalidTimeSlotException(string? message) : base(message)
        {
        }
    }
}