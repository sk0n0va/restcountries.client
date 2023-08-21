namespace Infrastructure.Options
{
    public class CountriesApiOptions
    {
        public const string Key = "CountriesApi";

        public required string ApiUrl { get; set; }
    }
}