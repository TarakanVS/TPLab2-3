using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly));
            services
                .AddAutoMapper(typeof(StoryAppMappingProfile))
                .AddAutoMapper(typeof(BaseAppMappingProfile));

            return services;
        }
    }
}