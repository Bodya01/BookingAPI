using BookingAPI.Domain.Entities;

namespace BookingAPI.Domain.Repositories
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllAsync(CancellationToken cancelToken = default);

        Task<Guid> CreateAsync(Booking entity, CancellationToken cancelToken = default);
    }
}