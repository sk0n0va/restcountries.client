using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class Name
    {
        [JsonPropertyName("common")]
        public required string Common { get; set; }

        [JsonPropertyName("official")]
        public required string Official { get; set; }

        [JsonPropertyName("nativeName")]
        public Dictionary<string, NativeNameLanguage> NativeName { get; set; }
    }
}
