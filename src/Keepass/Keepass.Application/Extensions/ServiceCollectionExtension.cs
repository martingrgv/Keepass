
namespace Keepass.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuraiton =>
            {
                configuraiton.RegisterServicesFromAssembly(typeof(ServiceCollectionExtension).Assembly);
            });

            return services;
        }
    }
}
