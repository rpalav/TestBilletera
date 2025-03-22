using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraAPI.Application
{
    public static class DependencyInjenction
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            return services;
        }
    }
}
