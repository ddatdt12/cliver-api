using CliverApi.Core.IConfiguration;
using CliverApi.Core.Repositories;

namespace CliverApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
         services.AddCors(options =>
         {
             options.AddPolicy("CorsPolicy", builder =>
             builder.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());
         });

        public static void ConfigureRepository(this IServiceCollection services) =>
            services.AddScoped<IUnitOfWork, UnitOfWork>();

    }
}
