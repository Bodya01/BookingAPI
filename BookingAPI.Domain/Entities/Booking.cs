using BookingAPI.Domain.DDD;
using BookingAPI.Domain.Enums;
using BookingAPI.Domain.ValueObjects;

namespace BookingAPI.Domain.Entities
{
    public sealed class Booking : Entity, IAggregateRoot
    {
        public TimeSlot Slot { get; private set; }

        public BookingStatus Status { get; private set; }

        public Guid RoomId { get; private set; }
        public Guid BookedBy { get; private set; }

        // EF ctor
        private Booking() : base(null) { }

        public Booking(DateTime start, DateTime end, BookingStatus status, Guid roomId, Guid bookedBy, Guid? id = null) : base(id)
        {
            Slot = TimeSlot.Create(start, end);
            Status = status;
            RoomId = roomId;
            BookedBy = bookedBy;
        }
    }
}