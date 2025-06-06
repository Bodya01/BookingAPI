using BookingAPI.Domain.Enums;
using BookingAPI.Domain.Services;
using BookingAPI.Domain.ValueObjects;
using BookingAPI.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Infrastructure.EF.Services
{
    internal sealed class RoomService : IRoomService
    {
        private readonly BookingDbContext _context;

        public RoomService(BookingDbContext context)
            => _context = context;

        public async Task<bool> IsRoomAvailableAsync(Guid roomId, TimeSlot slot, CancellationToken cancelToken = default)
        {
            var confirmedReservations = await _context.Bookings
                .AsNoTracking()
                .Where(b =>
                    b.RoomId == roomId &&
                    b.Status == BookingStatus.Confirmed)
                .ToListAsync(cancelToken);

            return !confirmedReservations.Any(r => slot.OverlapsWith(r.Slot));
        }
    }
}