using MediatR;

namespace BookingAPI.Application.Commands
{
    public sealed record RefreshAccessToken(string Token, string RefreshToken) : IRequest<AuthenticationResult>;
}
