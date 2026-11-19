using DVLD.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DVLD.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(assembly);
            });

            var validatorInterfaceType = typeof(IValidate<>);
            var validatorTypes = assembly
                .GetTypes()
                .Where(t => t is { IsAbstract: false, IsInterface: false, IsGenericTypeDefinition: false });

            foreach (var implementationType in validatorTypes)
            {
                var serviceInterfaces = implementationType
                    .GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == validatorInterfaceType);

                foreach (var serviceInterface in serviceInterfaces)
                {
                    services.AddScoped(serviceInterface, implementationType);
                }
            }

            return services;
        }
    }
}
