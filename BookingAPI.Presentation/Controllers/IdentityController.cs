using BookingAPI.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Presentation.Controllers
{
    public sealed class IdentityController : ControllerBase
    {
        private readonly IMediator _sender;

        public IdentityController(IMediator sender)
            => _sender = sender;

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand model, CancellationToken cancellationToken)
            => Ok(await _sender.Send(model, cancellationToken));

        [AllowAnonymous]
        [HttpPost("sign-up")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model, CancellationToken cancellationToken)
            => Ok(await _sender.Send(model, cancellationToken));

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshAccessToken model, CancellationToken cancellationToken)
            => Ok(await _sender.Send(model, cancellationToken));
    }
}