using System.Text.Json.Serialization;
using Tringle.Core.Enums;

namespace Tringle.Core.DTOs
{
    public class AccountDto : BaseDto
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CurrencyCodes? CurrencyCode { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccountTypes? AccountType { get; set; }
        public string? OwnerName { get; set; }
        public decimal Balance { get; set; }
    }
}
