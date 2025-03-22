

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

            modelBuilder.Entity<HistorialMovimientoEntity>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Id).ValueGeneratedOnAdd();
                entity.Property(m => m.WalletId).IsRequired();
                entity.Property(m => m.Amount).HasColumnType("decimal(18, 2)");
                entity.Property(m => m.Type)
                    .HasConversion<string>()
                    .IsRequired();
                entity.Property(m => m.CreatedAt).IsRequired();
            });

            modelBuilder.Entity<HistorialMovimientoEntity>()
                .HasOne(h => h.Wallet)
                .WithMany(b => b.Movimientos)
                .HasForeignKey(h => h.WalletId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
