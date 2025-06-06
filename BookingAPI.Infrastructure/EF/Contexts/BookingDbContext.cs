using BookingAPI.Domain.Entities;
using BookingAPI.Infrastructure.EF.Maps;
using BookingAPI.Infrastructure.EF.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Infrastructure.EF.Contexts
{
    internal sealed class BookingDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new BookingMap());
            builder.ApplyConfiguration(new RoomMap());
        }
    }
}