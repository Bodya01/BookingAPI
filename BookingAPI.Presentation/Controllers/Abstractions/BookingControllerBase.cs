using BookingAPI.Presentation.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}