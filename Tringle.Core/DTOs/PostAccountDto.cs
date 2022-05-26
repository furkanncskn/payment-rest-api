using System.Text.Json.Serialization;
using Tringle.Core.Enums;

namespace Tringle.Core.DTOs
{
    public class PostAccountDto : BaseDto
    {
        [JsonPropertyOrder(2)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CurrencyCodes? CurrencyCode { get; set; }

        [JsonPropertyOrder(3)]
        public string? OwnerName { get; set; }

        [JsonPropertyOrder(4)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccountTypes? AccountType { get; set; }
    }
}
