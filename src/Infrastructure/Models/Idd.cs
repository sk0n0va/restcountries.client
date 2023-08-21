using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class Idd
    {
        [JsonPropertyName("root")]
        public string? Root { get; set; }

        [JsonPropertyName("suffixes")]
        public List<string> Suffixes { get; set; }
    }
}
