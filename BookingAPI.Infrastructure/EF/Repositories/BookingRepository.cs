using BookingAPI.Domain.Entities;
using BookingAPI.Domain.Repositories;
using BookingAPI.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Infrastructure.EF.Repositories
{
    internal sealed class BookingRepository : IBookingRepository
    {
        private readonly BookingDbContext _context;

        public BookingRepository(BookingDbContext context)
            => _context = context;

        public async Task<Guid> CreateAsync(Booking entity, CancellationToken cancelToken = default)
        {
            await _context.AddAsync(entity, cancelToken);
            await _context.SaveChangesAsync(cancelToken);

            return entity.Id;
        }

        public Task<List<Booking>> GetAllAsync(CancellationToken cancelToken = default)
            => _context.Bookings.ToListAsync(cancelToken);
    }
}