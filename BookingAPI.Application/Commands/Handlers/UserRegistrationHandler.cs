using BookingAPI.Application.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BookingAPI.Application.Commands.Handlers
{
    internal sealed class UserRegistrationHandler : IRequestHandler<RegistrationModel, AuthenticationResult>
    {
        private readonly IIdentityService _identityService;
        private readonly ILogger<UserRegistrationHandler> _logger;

        public UserRegistrationHandler(IIdentityService identityService, ILogger<UserRegistrationHandler> logger)
        {
            _identityService = identityService;
            _logger = logger;
        }

        public async Task<AuthenticationResult> Handle(RegistrationModel request, CancellationToken cancellationToken)
        {
            var result = await _identityService.RegisterAsync(request, cancellationToken);

            _logger.LogInformation("New user: {email} was registered.", result.User.Email);

            return result;
        }
    }
}
