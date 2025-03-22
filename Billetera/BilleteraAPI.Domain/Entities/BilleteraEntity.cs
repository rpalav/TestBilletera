using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BilleteraAPI.Domain.Entities
{
    public class BilleteraEntity
    {
        public int Id { get; set; }
        public string DocumentId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public DateTime CreatedAt  { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<HistorialMovimientoEntity> Movimientos { get; set; } = new List<HistorialMovimientoEntity>();


    }
}
