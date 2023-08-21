using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class CoatOfArms
    {
        [JsonPropertyName("png")]
        public string? Png { get; set; }

        [JsonPropertyName("svg")]
        public string? Svg { get; set; }
    }
}
