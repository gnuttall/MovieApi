using System.Reflection;
using MovieApi.Services.Common;
using MovieApi.Services.Enums;

namespace MovieApi.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static void RegisterServices(this IServiceCollection serviceCollection)
    {
        var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies()
            .Where(x => x.FullName.Contains("MovieApi"))
            .Select(Assembly.Load).ToList();

        var serviceInterfaces = assemblies.SelectMany(x => x.GetTypes())
            .Where(x => x.IsInterface);

        foreach (var serviceInterface in serviceInterfaces)
        {
            var services = assemblies.SelectMany(x => x.DefinedTypes)
                .Where(x => x.ImplementedInterfaces.Contains(serviceInterface) && !x.IsInterface && !x.IsAbstract);
            foreach (var service in services)
            {
                var lifetime = Lifetime.Scoped;
                var serviceTypeAttribute = service.GetCustomAttribute(typeof(RegistrationOptions));
                if (serviceTypeAttribute != null)
                {
                    var options = (RegistrationOptions)serviceTypeAttribute;
                    if (options.Ignore) continue;
                    lifetime = options.Lifetime;
                }

                switch (lifetime)
                {
                    case Lifetime.Transient:
                        serviceCollection.AddTransient(serviceInterface, service);
                        break;
                    case Lifetime.Singleton:
                        serviceCollection.AddSingleton(serviceInterface, service);
                        break;
                    case Lifetime.Scoped:
                    default:
                        serviceCollection.AddScoped(serviceInterface, service);
                        break;
                }
            }
        }
    }
}