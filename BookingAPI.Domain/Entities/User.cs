using BookingAPI.Domain.DDD;

namespace BookingAPI.Domain.Entities
{
    public sealed class User : Entity, IAggregateRoot
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public User(Guid id, string userName, string email) : base(id)
            => (UserName, Email) = (userName, email);
    }
}