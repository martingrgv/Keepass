
namespace Keepass.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(ServiceCollectionExtension).Assembly;
            services.AddMediatR(configuraiton =>
            {
                configuraiton.RegisterServicesFromAssembly(assembly);
                configuraiton.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
