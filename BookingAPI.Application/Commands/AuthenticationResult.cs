using BookingAPI.Domain.Entities;

namespace BookingAPI.Application.Commands
{
    public sealed record AuthenticationResult(string JwtId, string JwtToken, DateTime? JwtExpireTime, string RefreshToken, User User);
}