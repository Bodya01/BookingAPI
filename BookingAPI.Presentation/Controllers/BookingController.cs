using BookingAPI.Application.Commands;
using BookingAPI.Application.Queries;
using BookingAPI.Presentation.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Presentation.Controllers
{
    [Route("~/api/bookings")]
    public sealed class BookingController : BookingControllerBase
    {
        public BookingController(IMediator sender) : base(sender)
            => _sender = sender;

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancelToken = default)
            => Ok(await _sender.Send(new GetAllBookingsQuery(), cancelToken));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookingCommand request, CancellationToken cancelToken = default)
        {
            request.UserId = GetCurrentUserId();
            return Ok(await _sender.Send(request, cancelToken));
        }
    }
}