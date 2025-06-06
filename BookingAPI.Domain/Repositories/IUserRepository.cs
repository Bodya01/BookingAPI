using BookingAPI.Domain.Entities;

namespace BookingAPI.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<Guid> CreateAsync(User user, string password, CancellationToken cancellationToken = default);
        Task<bool> ValidatePassword(Guid id, string password, CancellationToken cancellationToken = default);
    }
}