using BookingAPI.Domain.ValueObjects;

namespace BookingAPI.Domain.Services
{
    public interface IRoomService
    {
        Task<bool> IsRoomAvailableAsync(Guid roomId, TimeSlot slot, CancellationToken cancelToken = default);
    }
}