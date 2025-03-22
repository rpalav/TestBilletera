namespace BilleteraAPI.Application.Dtos
{
    public class TransferenciaDto
    {
        public int OrigenBilleteraId { get; set; }
        public int DestinoBilleteraId { get; set; }
        public decimal Amount { get; set; }
    }
}
