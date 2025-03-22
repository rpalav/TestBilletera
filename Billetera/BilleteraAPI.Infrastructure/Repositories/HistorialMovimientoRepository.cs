using BilleteraAPI.Domain.Entities;
using BilleteraAPI.Domain.Interfaces;
using BilleteraAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BilleteraAPI.Infrastructure.Repositories
{
    public class HistorialMovimientoRepository(AppDbContext dbContext) : IHistorialMovimientoRepository
    {
        public async Task<HistorialMovimientoEntity> AddAsync(HistorialMovimientoEntity entity)
        {
            dbContext.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<HistorialMovimientoEntity>> GetHistorialMovimientoByWalletAsync(int idWallet)
        {
            return await dbContext.HistorialMovimientos.Where(x => x.WalletId.Equals(idWallet)).ToListAsync();
        }
    }
}
