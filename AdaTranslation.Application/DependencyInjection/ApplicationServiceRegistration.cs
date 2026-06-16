using AdaTranslation.Application.Common.Validators;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace AdaTranslation.Application.DependencyInjection
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
