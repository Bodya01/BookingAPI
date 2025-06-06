using BookingAPI.Domain.Entities;
using BookingAPI.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BookingAPI.Application.Commands.Handlers
{
    internal sealed class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Guid>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly ILogger<CreateRoomCommandHandler> _logger;

        public CreateRoomCommandHandler(IRoomRepository roomRepository, ILogger<CreateRoomCommandHandler> logger)
        {
            _roomRepository = roomRepository;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = new Room(request.Name, request.Capacity);

            var id = await _roomRepository.CreateAsync(room, cancellationToken);

            return id;
        }
    }
}