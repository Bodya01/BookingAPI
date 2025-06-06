using BookingAPI.Application.Extensions;
using BookingAPI.Infrastructure.Extensions;
using BookingAPI.Presentation.Extensions;
using BookingAPI.Presentation.Filters;
using Microsoft.OpenApi.Models;

namespace BookingAPI.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(opt =>
            {
                opt.Filters.Add<CustomExceptionFilter>();
            });

            services
                .RegisterJwtSettings(Configuration, out var settings)
                .AddSwagger()
                .RegisterContext(Configuration)
                .MigrateDatabase()
                .RegisterIdentity()
                .ConfigureAuthentication(settings)
                .RegisterDomainRepositoriesAndServices()
                .RegisterApplicationServices()
                .RegisterMediatR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookingAPI v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
