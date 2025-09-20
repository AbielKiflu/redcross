using AdaTranslation.Application.Services;
using AdaTranslation.Domain.Interfaces;
using AdaTranslation.Infrastructure.Data;
using AdaTranslation.Infrastructure.Repositories;
using AdaTranslation.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdaTranslation.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Connection")));

            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<ICenterRepository, CenterRepository>(); 

            return services;
        }
    }
}
