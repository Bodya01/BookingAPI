using MediatR;

namespace BookingAPI.Application.Commands
{
    public sealed record LoginUserCommand(string Email, string Password) : IRequest<AuthenticationResult>;
}
