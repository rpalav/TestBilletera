using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraAPI.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBilleteraRepository Billeteras { get; }
        IHistorialMovimientoRepository HistorialMovimientos { get; }
        Task CompleteAsync();
    }
}
