using BookingAPI.Application.Commands;

namespace BookingAPI.Application.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> LoginAsync(LoginUserCommand model, CancellationToken cancellationToken = default);
        Task<AuthenticationResult> RegisterAsync(RegistrationModel model, CancellationToken cancellationToken = default);
        Task<AuthenticationResult> RefreshAsync(RefreshAccessToken model, CancellationToken cancellationToken = default);
    }
}
