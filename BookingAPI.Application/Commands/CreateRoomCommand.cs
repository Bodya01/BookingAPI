using MediatR;

namespace BookingAPI.Application.Commands
{
    public sealed record CreateRoomCommand(string Name, int Capacity) : IRequest<Guid>;
}