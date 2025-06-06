using BookingAPI.Domain.DDD;
using BookingAPI.Domain.Exceptions;

namespace BookingAPI.Domain.ValueObjects
{
    public record TimeSlot : ValueObject
    {
        public DateTime StartTime { get; init; }
        public DateTime EndTime { get; init; }

        private TimeSlot() { }

        private TimeSlot(DateTime start, DateTime end)
            => (StartTime, EndTime) = (start, end);

        public static TimeSlot Create(DateTime start, DateTime end)
        {
            if (start > end) throw new InvalidTimeSlotException("Start time must not be later than end time");

            if (end < DateTime.UtcNow) throw new InvalidTimeSlotException("Cannot create a booking in the past");

            return new TimeSlot(start, end);
        }

        public bool OverlapsWith(TimeSlot other) => StartTime <= other.EndTime && other.StartTime <= EndTime;
    }
}