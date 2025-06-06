using BookingAPI.Domain.Entities;
using BookingAPI.Domain.Repositories;
using BookingAPI.Infrastructure.EF.Contexts;
using BookingAPI.Infrastructure.EF.Models;
using BookingAPI.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Infrastructure.EF.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly BookingDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(BookingDbContext context, UserManager<AppUser> userManager)
            => (_context,  _userManager) = (context, userManager);

        public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => (await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)).AsEntity();

        public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
            => (await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower(), cancellationToken)).AsEntity();

        public async Task<Guid> CreateAsync(User user, string password, CancellationToken cancellationToken = default)
        {
            var entity = user.AsDbObject();
            await _userManager.CreateAsync(entity, password);

            return entity.Id;
        }

        public async Task<bool> ValidatePassword(Guid id, string password, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}
