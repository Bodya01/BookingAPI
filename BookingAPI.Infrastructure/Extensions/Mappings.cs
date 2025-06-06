using BookingAPI.Domain.Entities;
using BookingAPI.Infrastructure.EF.Models;

namespace BookingAPI.Infrastructure.Extensions
{
    internal static class Mappings
    {
        public static AppUser AsDbObject(this User user)
            => new AppUser
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName
            };

        public static User? AsEntity(this AppUser user)
            => user is not null ? new(user.Id, user.Email, user.UserName) : null;
    }
}