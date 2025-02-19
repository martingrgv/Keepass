using Keepass.Infrastructure.Data.Persistence;
using Keepass.Wpf.Common;
using Keepass.Wpf.Events;
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
            var presentationAssembly = typeof(CreateSecretEventHandler).Assembly;
            services.AddMediatR(configuraiton =>
            {
                configuraiton.RegisterServicesFromAssembly(presentationAssembly);
            });

            services.AddSingleton<MainWindow>();
            services.AddSingleton<SecretCollectionViewModel>();

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
