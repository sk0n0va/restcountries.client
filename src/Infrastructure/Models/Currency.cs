using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class Currency
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }
    }
}
