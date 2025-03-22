using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraAPI.Application.Dtos
{
    public class TransferenciaDto
    {
        public int OrigenBilleteraId { get; set; }
        public int DestinoBilleteraId { get; set; }
        public decimal Amount { get; set; }
    }
}
