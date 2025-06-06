using BookingAPI.Application.Exceptions;
using BookingAPI.Application.Exceptions.Room;
using BookingAPI.Domain.Entities;
using BookingAPI.Domain.Enums;
using BookingAPI.Domain.Repositories;
using BookingAPI.Domain.Services;
using MediatR;
using System.Net;

namespace BookingAPI.Application.Commands.Handlers
{
    internal sealed class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Guid>
    {
        private readonly IRoomService _roomService;
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;

        public CreateBookingCommandHandler(IRoomService roomService, IBookingRepository bookingRepository, IRoomRepository roomRepository)
            => (_roomService, _bookingRepository, _roomRepository) = (roomService, bookingRepository, roomRepository);

        public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            if (!await _roomRepository.ExistsAsync(request.RoomId, cancellationToken))
                throw new RoomNotFoundException(HttpStatusCode.NotFound, $"Room with the given ID does not exist: {request.RoomId}");

            var booking = new Booking(request.Start, request.End, BookingStatus.Confirmed, request.RoomId, Guid.NewGuid());

            if (!await _roomService.IsRoomAvailableAsync(request.RoomId, booking.Slot, cancellationToken))
                throw new RoomAlreadyBookedException(HttpStatusCode.BadRequest, $"Room {request.RoomId} is already booked for the given time slot");

            return await _bookingRepository.CreateAsync(booking, cancellationToken);
        }
    }
}