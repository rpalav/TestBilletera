

using BilleteraAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilleteraAPI.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
        public DbSet<BilleteraEntity> Billeteras { get; set; }

        public DbSet<HistorialMovimientoEntity> HistorialMovimientos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    

            modelBuilder.Entity<BilleteraEntity>(entity =>
            {
                entity.Property(b => b.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(b => b.DocumentId)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(b => b.Name)
                    .HasMaxLength(65)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HistorialMovimientoEntity>()
                .Property(h => h.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<HistorialMovimientoEntity>()
                .HasOne(h => h.Wallet)
                .WithMany(b => b.Movimientos)
                .HasForeignKey(h => h.WalletId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
