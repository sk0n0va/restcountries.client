using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class Car
    {
        [JsonPropertyName("signs")]
        public List<string> Signs { get; set; }

        [JsonPropertyName("side")]
        public required string Side { get; set; }
    }
}
