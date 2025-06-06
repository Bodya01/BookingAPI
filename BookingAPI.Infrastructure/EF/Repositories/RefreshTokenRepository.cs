using BookingAPI.Domain.Repositories;
using BookingAPI.Infrastructure.EF.Contexts;
using BookingAPI.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Infrastructure.EF.Repositories
{
    internal sealed class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly BookingDbContext _context;

        public RefreshTokenRepository(BookingDbContext context)
            => _context = context;

        public Task<RefreshToken?> GetByIdAsync(string token, CancellationToken cancellationToken = default)
            => _context.RefreshTokens.FirstOrDefaultAsync(x => x.Id == token, cancellationToken);

        public async Task<RefreshToken> CreateAsync(RefreshToken model, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return model;
        }

        public async Task<RefreshToken> UpdateAsync(RefreshToken entity, CancellationToken cancellationToken = default)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}