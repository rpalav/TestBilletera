using BilleteraAPI.Domain.Interfaces;
using BilleteraAPI.Infrastructure.Data;
using BilleteraAPI.Infrastructure.Repositories;

namespace BilleteraAPI.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private bool _disposed = false;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Billeteras = new BilleteraRepository(context);
            HistorialMovimientos = new HistorialMovimientoRepository(context);
        }

        public IBilleteraRepository Billeteras { get; }
        public IHistorialMovimientoRepository HistorialMovimientos { get; }

        public async Task CompleteAsync()
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _context.Dispose();
                _disposed = true;
            }
        }
    }
}
