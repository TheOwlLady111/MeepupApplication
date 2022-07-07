using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBusinessLayerMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceExtensions));

            return services;
        }
    }
}
