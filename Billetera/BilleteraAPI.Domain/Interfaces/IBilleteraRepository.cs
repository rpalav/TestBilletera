using BilleteraAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraAPI.Domain.Interfaces
{
    public interface IBilleteraRepository
    {
        Task<IEnumerable<BilleteraEntity>> GetBilleterasAsync();
        Task<BilleteraEntity> GetBilleteraByIdAsync(int id);
        Task<BilleteraEntity> AddBilleteraAsync(BilleteraEntity entity);
        Task<BilleteraEntity> UpdateBilleteraAsync(int idBilletera, BilleteraEntity entity);
        Task<bool> DeleteBilleteraAsync(int idBilletera);
    }
}
