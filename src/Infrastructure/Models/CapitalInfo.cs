using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class CapitalInfo
    {
        [JsonPropertyName("latlng")]
        public List<double> Latlng { get; set; }
    }
}
