using BookingAPI.Domain.Entities;
using BookingAPI.Domain.Repositories;
using BookingAPI.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Infrastructure.EF.Repositories
{
    internal sealed class RoomRepository : IRoomRepository
    {
        private readonly BookingDbContext _context;

        public RoomRepository(BookingDbContext context)
            => _context = context;

        public Task<List<Room>> GetAllAsync(CancellationToken cancelToken = default)
            => _context.Rooms.ToListAsync(cancelToken);

        public async Task<Guid> CreateAsync(Room room, CancellationToken cancelToken = default)
        {
            await _context.AddAsync(room, cancelToken);
            await _context.SaveChangesAsync(cancelToken);

            return room.Id;
        }

        public Task<bool> ExistsAsync(Guid roomId, CancellationToken cancelToken = default)
            => _context.Rooms.AnyAsync(x => x.Id == roomId, cancelToken);
    }
}