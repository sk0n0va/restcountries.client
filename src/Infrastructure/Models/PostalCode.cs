using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class PostalCode
    {
        [JsonPropertyName("format")]
        public required string Format { get; set; }

        [JsonPropertyName("regex")]
        public string? Regex { get; set; }
    }
}
