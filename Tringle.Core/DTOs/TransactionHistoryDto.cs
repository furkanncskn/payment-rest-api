using System.Text.Json.Serialization;
using Tringle.Core.Enums;

namespace Tringle.Core.DTOs
{
    public class TransactionHistoryDto : BaseDto
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TransactionTypes? TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
