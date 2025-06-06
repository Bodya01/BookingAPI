using BookingAPI.Infrastructure.EF.Models;

namespace BookingAPI.Domain.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken?> GetByIdAsync(string token, CancellationToken cancellationToken = default);
        Task<RefreshToken> CreateAsync(RefreshToken model, CancellationToken cancellationToken = default);
        Task<RefreshToken> UpdateAsync(RefreshToken model, CancellationToken cancellationToken = default);
    }
}