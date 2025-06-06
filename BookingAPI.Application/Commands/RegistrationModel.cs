using MediatR;

namespace BookingAPI.Application.Commands
{
    public sealed record RegistrationModel(string Email, string UserName, string Password) : IRequest<AuthenticationResult>;
}