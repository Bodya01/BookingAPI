using BookingAPI.Domain.Entities;
using BookingAPI.Domain.Repositories;
using MediatR;

namespace BookingAPI.Application.Queries.Handlers
{
    internal class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, List<Booking>>
    {
        private readonly IBookingRepository _bookingRepository;

        public GetAllBookingsQueryHandler(IBookingRepository bookingRepository)
            => _bookingRepository = bookingRepository;

        public Task<List<Booking>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
            => _bookingRepository.GetAllAsync(cancellationToken);
    }
}
