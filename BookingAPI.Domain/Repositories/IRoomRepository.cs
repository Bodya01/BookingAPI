using BookingAPI.Domain.Entities;

namespace BookingAPI.Domain.Repositories
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllAsync(CancellationToken cancelToken = default);
        Task<Guid> CreateAsync(Room room, CancellationToken cancelToken = default);
        Task<bool> ExistsAsync(Guid roomId, CancellationToken cancelToken = default);
    }
}