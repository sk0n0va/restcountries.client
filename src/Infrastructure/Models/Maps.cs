using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class Maps
    {
        [JsonPropertyName("googleMaps")]
        public required string GoogleMaps { get; set; }

        [JsonPropertyName("openStreetMaps")]
        public required string OpenStreetMaps { get; set; }
    }
}
