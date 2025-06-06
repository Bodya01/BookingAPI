using BookingAPI.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookingAPI.Infrastructure.EF.Hosted
{
    internal sealed class MigrationHostedService : BackgroundService
    {
        private readonly IServiceProvider _provider;

        public MigrationHostedService(IServiceProvider provider)
            => _provider = provider;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _provider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<BookingDbContext>();

            await context.Database.MigrateAsync(stoppingToken);
        }
    }
}