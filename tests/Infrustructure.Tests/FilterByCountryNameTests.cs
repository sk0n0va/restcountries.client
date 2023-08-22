using Infrastructure.Models;
using Infrastructure.Services.Filtering;
using System.Text.Json;

namespace Infrastructure.Tests;

public class FilterByCountryNameTests
{
    private static List<Country> _countries;

    static FilterByCountryNameTests()
    {
        var content = File.ReadAllText("../../../TestData/full-response-valid.json") ?? string.Empty;
        _countries = JsonSerializer.Deserialize<List<Country>>(content) ?? new List<Country>();
    }

    [Theory]
    [MemberData(nameof(GetCountriesAndQueries))]
    public void Filter_ReturnsExpectedCountries(IEnumerable<Country> countries, string query, IEnumerable<string> expectedCountryNames)
    {
        // Act
        var result = new FilterByCountryName().Filter(countries, query);

        // Assert
        Assert.Equal(expectedCountryNames.Count(), result.Count());
        foreach (var name in expectedCountryNames)
        {
            Assert.Contains(result, c => c.Name.Common == name);
        }
    }

    public static IEnumerable<object[]> GetCountriesAndQueries()
    {
        yield return new object[]
        {
            _countries.Where(c => c.Name.Common == "India" || c.Name.Common == "Indonesia" | c.Name.Common == "Canada").ToList(),
            "iNd",
            new List<string> { "India", "Indonesia" }
        };

        yield return new object[]
        {
            _countries.Where(c => c.Name.Common == "Brazil" || c.Name.Common == "Argentina").ToList(),
            "Canada",
            new List<string> { }
        };

        yield return new object[]
        {
            _countries.Where(c => c.Name.Common == "Germany").ToList(),
            "germany",
            new List<string> { "Germany" }
        };

        yield return new object[]
        {
            new List<Country>(),
            "Australia",
            new List<string> { }
        };

        yield return new object[]
        {
            _countries.Where(c => c.Name.Common == "Japan" || c.Name.Common == "China").ToList(),
            string.Empty,
            new List<string> { "Japan", "China" }
        };
    }
}