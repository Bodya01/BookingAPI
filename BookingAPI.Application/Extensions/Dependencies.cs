using BookingAPI.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookingAPI.Application.Extensions
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterMediatR(this IServiceCollection services)
        {
            services.AddMediatR(x =>
            {
                x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });

            return services;
        }

        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}
