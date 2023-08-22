using Infrastructure.Models;
using Infrastructure.Services.Filtering;
using System.Text.Json;

namespace Infrastructure.Tests;

public class FilterByCountryPopulationTests
{
    private readonly FilterByCountryPopulation _filter = new();
    private readonly List<Country> _countries;

    public FilterByCountryPopulationTests()
    {
        var content = File.ReadAllText("../../../TestData/full-response-valid.json") ?? string.Empty;
        _countries = JsonSerializer.Deserialize<List<Country>>(content) ?? new List<Country>();
    }

    [Fact]
    public void ThrowsExceptionForInvalidQuery()
    {
        var countries = new List<Country>();

        Assert.Throws<ArgumentException>(() => _filter.Filter(countries, "invalid"));
    }

    [Fact]
    public void ReturnsCountriesWithLessThanSpecifiedPopulation()
    {
        // Arrange & Act
        var result = _filter.Filter(_countries, "2").ToList();

        Assert.Equal(101, result.Count);
        Assert.Contains(result, country => country.Name.Common == "Guinea-Bissau");
        Assert.Contains(result, country => country.Name.Common == "Cyprus");
    }
}
