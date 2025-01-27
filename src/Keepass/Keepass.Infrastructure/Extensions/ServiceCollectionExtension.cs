using Keepass.Application.Contracts;
using Keepass.Infrastructure.Data.Services;

namespace Keepass.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("KeepassDb") ?? throw new ArgumentNullException("No connection string provided!");
            services.AddDbContext<KeepassDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<ISecretRepository, SecretRepository>();
            services.AddSingleton<ICryptography, CyptographerService>();

            return services;
        }
    }
}
