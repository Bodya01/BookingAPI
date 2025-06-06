namespace BookingAPI.Domain.DDD
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }

        public Entity(Guid? id)
        {
            Id = id ?? Guid.NewGuid();
        }
    }
}