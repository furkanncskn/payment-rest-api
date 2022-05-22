namespace Tringle.Core.DTOs
{
    public class PaymentDto
    {
        public int SenderAccount { get; set; }
        public int ReceiverAccount { get; set; }
        public decimal Amount { get; set; }
    }
}
