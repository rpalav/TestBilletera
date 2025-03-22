

using BilleteraAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilleteraAPI.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
        public DbSet<BilleteraEntity> Billeteras { get; set; }
    }
}
