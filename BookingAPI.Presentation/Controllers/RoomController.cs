using BookingAPI.Application.Commands;
using BookingAPI.Application.Queries;
using BookingAPI.Presentation.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Presentation.Controllers
{
    [Route("~/api/rooms")]
    public sealed class RoomController : BookingControllerBase
    {
        public RoomController(IMediator sender) : base(sender) { }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancelToken = default)
            => Ok(await _sender.Send(new GetAllRoomsQuery(), cancelToken));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRoomCommand request, CancellationToken cancelToken = default)
            => Ok(await _sender.Send(request, cancelToken));
    }
}