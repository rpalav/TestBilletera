using BilleteraAPI.Domain.Entities;

namespace BilleteraAPI.Domain.Interfaces
{
    public interface IHistorialMovimientoRepository
    {
        Task<HistorialMovimientoEntity> AddAsync(HistorialMovimientoEntity entity);

        Task<IEnumerable<HistorialMovimientoEntity>> GetHistorialMovimientoByWalletAsync(int idWallet);

    }
}
