using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class NativeNameLanguage
    {
        [JsonPropertyName("common")]
        public required string Common { get; set; }

        [JsonPropertyName("official")]
        public required string Official { get; set; }
    }
}
