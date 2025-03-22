using BilleteraAPI.Application;
using BilleteraAPI.Application.Validators;
using BilleteraAPI.Infrastructure;
using FluentValidation.AspNetCore;
using FluentValidation;
using BilleteraAPI.Domain;

namespace BilleteraAPI.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApiDI(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddApplicationDI()
                .AddInfrastructureDI()
                .AddDomainDI(configuration);

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(typeof(BilleteraValidator).Assembly);
            return services;
        }
    }
}
