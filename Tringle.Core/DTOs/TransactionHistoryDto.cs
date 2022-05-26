using System.Text.Json.Serialization;
using Tringle.Core.Enums;

namespace Tringle.Core.DTOs
{
    public class TransactionHistoryDto : BaseDto
    {
        [JsonPropertyOrder(2)]
        public decimal Amount { get; set; }

        [JsonPropertyOrder(3)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TransactionTypes? TransactionType { get; set; }

        [JsonPropertyOrder(4)]
        public DateTime CreatedAt { get; set; }
    }
}
