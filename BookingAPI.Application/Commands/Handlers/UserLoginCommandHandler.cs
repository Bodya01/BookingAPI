using BookingAPI.Application.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BookingAPI.Application.Commands.Handlers
{
    internal sealed class UserLoginHandler : IRequestHandler<LoginUserCommand, AuthenticationResult>
    {
        private readonly IIdentityService _identityService;

        public UserLoginHandler(IIdentityService identityService, ILogger<UserLoginHandler> logger)
            => _identityService = identityService;

        public async Task<AuthenticationResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            => await _identityService.LoginAsync(request, cancellationToken);
    }
}
