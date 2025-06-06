using BookingAPI.Domain.Repositories;
using BookingAPI.Domain.Services;
using BookingAPI.Infrastructure.EF.Contexts;
using BookingAPI.Infrastructure.EF.Hosted;
using BookingAPI.Infrastructure.EF.Models;
using BookingAPI.Infrastructure.EF.Repositories;
using BookingAPI.Infrastructure.EF.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookingAPI.Infrastructure.Extensions
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookingDbContext>(x =>
            {
                x.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        public static IServiceCollection MigrateDatabase(this IServiceCollection services)
        {
            services.AddHostedService<MigrationHostedService>();

            return services;
        }

        public static IServiceCollection RegisterDomainRepositoriesAndServices(this IServiceCollection services)
        {
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IRoomService, RoomService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            return services;
        }

        public static IServiceCollection RegisterIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<BookingDbContext>()
                .AddUserManager<UserManager<AppUser>>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
