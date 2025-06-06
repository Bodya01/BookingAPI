using BookingAPI.Domain.Entities;
using MediatR;

namespace BookingAPI.Application.Queries
{
    public sealed record GetAllRoomsQuery : IRequest<List<Room>>;
}