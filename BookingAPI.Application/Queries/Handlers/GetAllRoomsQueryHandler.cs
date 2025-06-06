using BookingAPI.Domain.Entities;
using BookingAPI.Domain.Repositories;
using MediatR;

namespace BookingAPI.Application.Queries.Handlers
{
    internal sealed class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, List<Room>>
    {
        private readonly IRoomRepository _roomRepository;

        public GetAllRoomsQueryHandler(IRoomRepository roomRepository)
            => _roomRepository = roomRepository;

        public Task<List<Room>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            return _roomRepository.GetAllAsync(cancellationToken);
        }
    }
}