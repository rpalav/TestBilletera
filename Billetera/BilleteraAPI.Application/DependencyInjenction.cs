using BilleteraAPI.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace BilleteraAPI.Application
{
    public static class DependencyInjenction
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjenction).Assembly));
            return services;
        }
    }
}
