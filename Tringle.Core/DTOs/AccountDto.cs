using System.Text.Json.Serialization;
using Tringle.Core.Enums;

namespace Tringle.Core.DTOs
{
    public class AccountDto : BaseDto
    {
        [JsonPropertyOrder(2)]
        public CurrencyCodes? CurrencyCode { get; set; }

        [JsonPropertyOrder(4)]
        public string? OwnerName { get; set; }

        [JsonPropertyOrder(5)]
        public AccountTypes? AccountType { get; set; }

        [JsonPropertyOrder(6)]
        public decimal Balance { get; set; }
    }
}
