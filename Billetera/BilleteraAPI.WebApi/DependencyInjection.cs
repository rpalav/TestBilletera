using BilleteraAPI.Application;
using BilleteraAPI.Infrastructure;

namespace BilleteraAPI.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApiDI(this IServiceCollection services)
        {

            services.AddApplicationDI()
                .AddInfrastructureDI();
            return services;
        }
    }
}
