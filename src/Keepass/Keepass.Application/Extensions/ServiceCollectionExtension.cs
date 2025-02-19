
namespace Keepass.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServiceCollectionExtension).Assembly;
            services.AddMediatR(configuraiton =>
            {
                configuraiton.RegisterServicesFromAssembly(applicationAssembly);
                configuraiton.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(applicationAssembly);

            return services;
        }
    }
}
