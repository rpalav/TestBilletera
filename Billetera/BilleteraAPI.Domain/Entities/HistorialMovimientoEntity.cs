

using BilleteraAPI.Domain.Enums;

namespace BilleteraAPI.Domain.Entities
{
    public class HistorialMovimientoEntity
    {
        public int Id { get; set; }
        public int WalletId { get; set; }
        public decimal Amount { get; set; }
        public TipoMovimiento Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public BilleteraEntity Wallet { get; set; } = null!;
    }
}
