using BilleteraAPI.Domain.Entities;
using BilleteraAPI.Domain.Interfaces;
using BilleteraAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraAPI.Infrastructure.Repositories
{
    public class BilleteraRepository(AppDbContext dbContext) : IBilleteraRepository
    {
        public async Task<IEnumerable<BilleteraEntity>> GetBilleterasAsync()
        {
            return await dbContext.Billeteras.ToListAsync();
        }

        public async Task<BilleteraEntity> GetBilleteraByIdAsync(int id)
        {
            return await dbContext.Billeteras.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<BilleteraEntity> AddBilleteraAsync(BilleteraEntity entity)
        {
            dbContext.Billeteras.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<BilleteraEntity> UpdateBilleteraAsync(int idBilletera, BilleteraEntity entity)
        {
            var billetera = await dbContext.Billeteras.FirstOrDefaultAsync(x => x.Id.Equals(idBilletera));
            if (billetera is not null)
            {
                billetera.Name = entity.Name;
                billetera.Balance = entity.Balance;
                await dbContext.SaveChangesAsync();
                return billetera;
            }

            return entity;
        }

        public async Task<bool> DeleteBilleteraAsync(int idBilletera)
        {
            var billetera = await dbContext.Billeteras.FirstOrDefaultAsync(x => x.Id.Equals(idBilletera));
            if (billetera is not null)
            {
                dbContext.Billeteras.Remove(billetera);                
                return await dbContext.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}
