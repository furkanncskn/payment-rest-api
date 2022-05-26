using System.Text.Json.Serialization;

namespace Tringle.Core.DTOs
{
    public class DepositOrWithdrawDto : BaseDto
    {
        [JsonPropertyOrder(2)]
        public decimal Amount { get; set; }
    }
}
