using BilleteraAPI.Domain.Interfaces;
using BilleteraAPI.Infrastructure.Data;
using BilleteraAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace BilleteraAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=DESKTOP-SVJJE3M\\SQLEXPRESS;Database=Wallet;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            });

            services.AddScoped<IBilleteraRepository, BilleteraRepository>();
            return services;
        }
    }
}
