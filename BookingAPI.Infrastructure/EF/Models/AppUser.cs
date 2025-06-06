using Microsoft.AspNetCore.Identity;

namespace BookingAPI.Infrastructure.EF.Models
{
    public sealed class AppUser : IdentityUser<Guid> { }
}