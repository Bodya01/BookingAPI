using MediatR;

namespace BookingAPI.Application.Commands
{
    public sealed record CreateBookingCommand(DateTime Start, DateTime End, Guid RoomId) : IRequest<Guid>;
}