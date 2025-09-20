using AdaTranslation.Application.Interfaces;
using AdaTranslation.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AdaTranslation.Application.DependencyInjection
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICenterService, CenterService>();
            
            return services;
        }
    }
}
