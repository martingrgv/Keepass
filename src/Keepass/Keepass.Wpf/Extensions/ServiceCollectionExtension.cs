using Keepass.Wpf.Common;
using Keepass.Wpf.Common.Contracts;
using Keepass.Wpf.Views;

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
    }
}
