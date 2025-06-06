using BookingAPI.Domain.DDD;

namespace BookingAPI.Domain.Entities
{
    public sealed class Room : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public int Capacity { get; private set; }

        // EF ctor
        private Room() : base(null) { }

        public Room (string name, int capacity, Guid? id = null) : base(id)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
            if (capacity <= 0) throw new ArgumentException("Capacity must be > 0");

            Name = name;
            Capacity = capacity;
        }
    }
}