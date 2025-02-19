using Keepass.Infrastructure.Data.Persistence;
using Keepass.Wpf.Common;
using Keepass.Wpf.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Keepass.Wpf.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddFormFactory<TForm>(this IServiceCollection services)
            where TForm : class
        {
            services.AddTransient<TForm>();
            services.AddSingleton<Func<TForm>>(x => () => x.GetService<TForm>()!);
            services.AddSingleton<IFormAbstractFactory<TForm>, FormAbstractFactory<TForm>>();

            return services;
        }

        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();

            services.AddFormFactory<LoginWindow>();
            services.AddFormFactory<CreateSecretWindow>();

            return services;
        }

        public static IHost UseMigration(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<KeepassDbContext>();

            context.Database.MigrateAsync();
            return host;
        }
    }
}
