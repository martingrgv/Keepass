using Keepass.Infrastructure.Data.Persistence;
using Keepass.Infrastructure.Data.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Keepass.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ISecretRepository, SecretRepository>();

            return services;
        }

        public static IServiceCollection RegisterDatabase(this IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("No connection string provided!");
            }

            services.AddDbContext<KeepassDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
