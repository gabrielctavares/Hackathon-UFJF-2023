using Hackathon.Services;
using System.Reflection;

namespace Hackathon.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            var baseServiceTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.BaseType != null && t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == typeof(BaseService<>));

            foreach (var baseServiceType in baseServiceTypes)
                services.AddScoped(baseServiceType);

            return services;
        }
    }
}
