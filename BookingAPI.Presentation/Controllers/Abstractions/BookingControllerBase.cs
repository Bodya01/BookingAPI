using BookingAPI.Presentation.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingAPI.Presentation.Controllers.Abstractions
{
    [Authorize]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionFilter))]
    public abstract class BookingControllerBase : ControllerBase
    {
        protected IMediator _sender;

        protected BookingControllerBase(IMediator sender)
            => _sender = sender;

        protected Guid GetCurrentUserId()
            => Guid.Parse(HttpContext.User.FindFirstValue("Id")!);
    }
}