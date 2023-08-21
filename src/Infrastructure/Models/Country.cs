using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class Country
    {
        [JsonPropertyName("name")]
        public required Name Name { get; set; }

        [JsonPropertyName("tld")]
        public List<string>? Tld { get; set; }

        [JsonPropertyName("cca2")]
        public required string Cca2 { get; set; }

        [JsonPropertyName("ccn3")]
        public string? Ccn3 { get; set; }

        [JsonPropertyName("cca3")]
        public required string Cca3 { get; set; }

        [JsonPropertyName("cioc")]
        public string? Cioc { get; set; }

        [JsonPropertyName("independent")]
        public bool Independent { get; set; }

        [JsonPropertyName("status")]
        public required string Status { get; set; }

        [JsonPropertyName("unMember")]
        public bool UnMember { get; set; }

        [JsonPropertyName("currencies")]
        public Dictionary<string, Currency>? Currencies { get; set; }

        [JsonPropertyName("idd")]
        public required Idd Idd { get; set; }

        [JsonPropertyName("capital")]
        public List<string>? Capital { get; set; }

        [JsonPropertyName("altSpellings")]
        public required List<string> AltSpellings { get; set; }

        [JsonPropertyName("region")]
        public required string Region { get; set; }

        [JsonPropertyName("subregion")]
        public string? Subregion { get; set; }

        [JsonPropertyName("languages")]
        public Dictionary<string, string>? Languages { get; set; }

        [JsonPropertyName("translations")]
        public required Dictionary<string, Translation> Translations { get; set; }

        [JsonPropertyName("latlng")]
        public required List<double> Latlng { get; set; }

        [JsonPropertyName("landlocked")]
        public bool Landlocked { get; set; }

        [JsonPropertyName("borders")]
        public List<string>? Borders { get; set; }

        [JsonPropertyName("area")]
        public double Area { get; set; }

        [JsonPropertyName("demonyms")]
        public Dictionary<string, Demonym>? Demonyms { get; set; }

        [JsonPropertyName("flag")]
        public required string Flag { get; set; }

        [JsonPropertyName("maps")]
        public required Maps Maps { get; set; }

        [JsonPropertyName("population")]
        public long Population { get; set; }

        [JsonPropertyName("gini")]
        public object? Gini { get; set; }

        [JsonPropertyName("fifa")]
        public string? Fifa { get; set; }

        [JsonPropertyName("car")]
        public required Car Car { get; set; }

        [JsonPropertyName("timezones")]
        public required List<string> Timezones { get; set; }

        [JsonPropertyName("continents")]
        public required List<string> Continents { get; set; }

        [JsonPropertyName("flags")]
        public required Flags Flags { get; set; }

        [JsonPropertyName("coatOfArms")]
        public required CoatOfArms CoatOfArms { get; set; }

        [JsonPropertyName("startOfWeek")]
        public string? StartOfWeek { get; set; }

        [JsonPropertyName("capitalInfo")]
        public required CapitalInfo CapitalInfo { get; set; }

        [JsonPropertyName("postalCode")]
        public PostalCode? PostalCode { get; set; }
    }
}