using Infrastructure.Models;

namespace WebClient.Tests.TestData;

internal static class CountriesLists
{
    public static List<Country> GetValidListWithOneItem() => new()
    {
        new Country
        {
            Name = new Name
            {
                Common = "Ukraine",
                Official = "Ukraine",
                NativeName = new Dictionary<string, NativeNameLanguage>
                {
                    {
                        "ukr", new NativeNameLanguage
                        {
                            Official = "Україна",
                            Common = "Україна"
                        }
                    }
                }
            },
            Tld = new List<string> { ".ua", ".укр" },
            Cca2 = "UA",
            Ccn3 = "804",
            Cca3 = "UKR",
            Cioc = "UKR",
            Independent = true,
            Status = "officially-assigned",
            UnMember = true,
            Currencies = new Dictionary<string, Currency>
            {
                {
                    "UAH", new Currency
                    {
                        Name = "Ukrainian hryvnia",
                        Symbol = "₴"
                    }
                }
            },
            Idd = new Idd
            {
                Root = "+3",
                Suffixes = new List<string> { "80" }
            },
            Capital = new List<string> { "Kyiv" },
            AltSpellings = new List<string> { "UA", "Ukrayina" },
            Region = "Europe",
            Subregion = "Eastern Europe",
            Languages = new Dictionary<string, string>
            {
                { "ukr", "Ukrainian" }
            },
            Translations = new Dictionary<string, Translation>
            {
                { "ara", new Translation { Official = "أوكرانيا", Common = "أوكرانيا" } },
                // ... Add other translations similarly ...
            },
            Latlng = new List<double> { 49.0, 32.0 },
            Landlocked = false,
            Borders = new List<string> { "BLR", "HUN", "MDA", "POL", "ROU", "RUS", "SVK" },
            Area = 603500.0,
            Demonyms = new Dictionary<string, Demonym>
            {
                {
                    "eng", new Demonym
                    {
                        F = "Ukrainian",
                        M = "Ukrainian"
                    }
                },
                // ... Add other demonyms similarly ...
            },
            Flag = "\uD83C\uDDFA\uD83C\uDDE6",
            Maps = new Maps
            {
                GoogleMaps = "https://goo.gl/maps/DvgJMiPJ7aozKFZv7",
                OpenStreetMaps = "https://www.openstreetmap.org/relation/60199"
            },
            Population = 44134693,
            Gini = new Dictionary<string, double>
            {
                { "2019", 26.6 }
            },
            Fifa = "UKR",
            Car = new Car
            {
                Signs = new List<string> { "UA" },
                Side = "right"
            },
            Timezones = new List<string> { "UTC+02:00" },
            Continents = new List<string> { "Europe" },
            Flags = new Flags
            {
                Png = "https://flagcdn.com/w320/ua.png",
                Svg = "https://flagcdn.com/ua.svg",
                Alt = "The flag of Ukraine is composed of two equal horizontal bands of blue and yellow."
            },
            CoatOfArms = new CoatOfArms
            {
                Png = "https://mainfacts.com/media/images/coats_of_arms/ua.png",
                Svg = "https://mainfacts.com/media/images/coats_of_arms/ua.svg"
            },
            StartOfWeek = "monday",
            CapitalInfo = new CapitalInfo
            {
                Latlng = new List<double> { 50.43, 30.52 }
            },
            PostalCode = new PostalCode
            {
                Format = "#####",
                Regex = "^(\\d{5})$"
            }
        }
    };
}