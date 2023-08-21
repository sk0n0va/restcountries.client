using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class Demonym
    {
        [JsonPropertyName("f")]
        public required string F { get; set; }
        [JsonPropertyName("m")]
        public required string M { get; set; }
    }
}
