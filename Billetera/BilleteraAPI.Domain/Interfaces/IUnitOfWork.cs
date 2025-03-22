namespace BilleteraAPI.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBilleteraRepository Billeteras { get; }
        IHistorialMovimientoRepository HistorialMovimientos { get; }
        Task CompleteAsync();
    }
}
