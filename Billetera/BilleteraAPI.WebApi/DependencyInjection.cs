using BilleteraAPI.Application;
using BilleteraAPI.Application.Validators;
using BilleteraAPI.Infrastructure;
using FluentValidation.AspNetCore;
using FluentValidation;

namespace BilleteraAPI.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApiDI(this IServiceCollection services)
        {

            services.AddApplicationDI()
                .AddInfrastructureDI();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(typeof(BilleteraValidator).Assembly);
            return services;
        }
    }
}
