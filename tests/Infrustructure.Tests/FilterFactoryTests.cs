using Infrastructure.Services.Filtering;

namespace Infrastructure.Tests;

public class FilterFactoryTests
{
    [Fact]
    public void Create_GivenCountryCommonNameAndQuery_ReturnsFilterByCountryName()
    {
        // Arrange & Act
        var result = FilterFactory.Create(FilterType.CountryCommonName, "any");

        // Assert
        Assert.NotNull(result);
        Assert.IsType<FilterByCountryName>(result.Strategy);
    }

    [Theory]
    [InlineData(FilterType.CountryCommonName, "")]
    [InlineData(FilterType.CountryCommonName, null)]
    [InlineData(FilterType.None, "any")]
    public void Create_GivenNullOrEmptyQueryOrNoneFilterType_ReturnsNull(FilterType filterType, string? query)
    {
        // Act
        var result = FilterFactory.Create(filterType, query);

        // Assert
        Assert.Null(result);
    }
}

