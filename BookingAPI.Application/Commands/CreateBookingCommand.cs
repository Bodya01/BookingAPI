using MediatR;
using System.Text.Json.Serialization;

namespace BookingAPI.Application.Commands
{
    public sealed record CreateBookingCommand(DateTime Start, DateTime End, Guid RoomId) : IRequest<Guid>
    {
        [JsonIgnore] public Guid UserId { get; set; }
    }
}