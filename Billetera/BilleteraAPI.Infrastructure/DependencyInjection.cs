using BilleteraAPI.Domain.Interfaces;
using BilleteraAPI.Domain.Options;
using BilleteraAPI.Infrastructure.Data;
using BilleteraAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace BilleteraAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>((provider, options) =>
            {
                options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
            });

            services.AddScoped<IBilleteraRepository, BilleteraRepository>();
            services.AddScoped<IHistorialMovimientoRepository, HistorialMovimientoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
