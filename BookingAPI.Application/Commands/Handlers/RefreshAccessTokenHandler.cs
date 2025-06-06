using BookingAPI.Application.Services;
using MediatR;

namespace BookingAPI.Application.Commands.Handlers
{
    internal sealed class RefreshAccessTokenHandler : IRequestHandler<RefreshAccessToken, AuthenticationResult>
    {
        private readonly IIdentityService _identityService;

        public RefreshAccessTokenHandler(IIdentityService identityService)
            => _identityService = identityService;

        public async Task<AuthenticationResult> Handle(RefreshAccessToken request, CancellationToken cancellationToken)
            => await _identityService.RefreshAsync(request, cancellationToken);
    }
}