using System.Text.Json.Serialization;

namespace Tringle.Core.DTOs
{
    public abstract class BaseDto
    {
        [JsonPropertyOrder(1)]
        public int AccountNumber { get; set; }
    }
}
