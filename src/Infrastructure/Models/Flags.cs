using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class Flags
    {
        [JsonPropertyName("png")]
        public required string Png { get; set; }

        [JsonPropertyName("svg")]
        public required string Svg { get; set; }

        [JsonPropertyName("alt")]
        public string? Alt { get; set; }
    }
}
