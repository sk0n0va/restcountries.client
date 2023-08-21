using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class Translation
    {
        [JsonPropertyName("official")]
        public required string Official { get; set; }

        [JsonPropertyName("common")]
        public required string Common { get; set; }
    }
}
