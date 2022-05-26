using System.Text.Json.Serialization;

namespace Tringle.Core.DTOs
{
    public class PaymentDto
    {
        [JsonPropertyOrder(2)]
        public int SenderAccount { get; set; }

        [JsonPropertyOrder(3)]
        public int ReceiverAccount { get; set; }

        [JsonPropertyOrder(4)]
        public decimal Amount { get; set; }
    }
}
