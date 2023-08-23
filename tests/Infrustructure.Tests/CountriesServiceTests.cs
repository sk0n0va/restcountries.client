using Infrastructure.Models;
using Infrastructure.Options;
using Infrastructure.Services;
using Infrastructure.Services.Filtering;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using System.Net;
using System.Text.Json;

namespace Infrastructure.Tests;

public class CountriesServiceTests
{
    private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly Mock<IOptions<CountriesApiOptions>> _optionsMock;
    private const string ApiUrl = "http://testapi.com";

    public CountriesServiceTests()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        _optionsMock = new Mock<IOptions<CountriesApiOptions>>();
        _optionsMock.Setup(o => o.Value).Returns(new CountriesApiOptions { ApiUrl = ApiUrl });

        var httpClient = new HttpClient(_httpMessageHandlerMock.Object);
        _httpClientFactoryMock = new Mock<IHttpClientFactory>();
        _httpClientFactoryMock.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(httpClient);
    }

    [Fact]
    public async Task FetchCountriesAsync_ReturnsCountries()
    {
        // Arrange
        var content = File.ReadAllText("../../../TestData/full-response-valid.json");
        SetupHttpResponse(content);
        var service = new CountriesService(_httpClientFactoryMock.Object, _optionsMock.Object);

        // Act
        var result = await service.FetchCountriesAsync();

        // Assert
        Assert.Equal(250, result.Count);
    }

    [Fact]
    public async Task FetchCountriesAsync_InvalidJson_ThrowsException()
    {
        // Arrange
        SetupHttpResponse("invalid JSON");
        var service = new CountriesService(_httpClientFactoryMock.Object, _optionsMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<JsonException>(() => service.FetchCountriesAsync());
    }

    [Fact]
    public async Task FetchCountriesAsync_FiltersApplied_ReturnsFilteredCountries()
    {
        // Arrange
        var content = File.ReadAllText("../../../TestData/full-response-valid.json");
        SetupHttpResponse(content);
        var query = "uKr";
        var filteredCountries = JsonSerializer.Deserialize<List<Country>>(content)
            .Where(c => c.Name.Common.Contains(query, StringComparison.OrdinalIgnoreCase))
            .ToList();
        var service = new CountriesService(_httpClientFactoryMock.Object, _optionsMock.Object);
        var filter = new Filter(new FilterByCountryName(), query);

        // Act
        var result = await service.FetchCountriesAsync(filter);

        // Assert
        Assert.Equal(filteredCountries.Count, result.Count);
        Assert.DoesNotContain(query, result.First().Name.Common);
    }

    [Fact]
    public async Task FetchCountriesAsync_SortApplied_ReturnsSortedCountries()
    {
        // Arrange
        var content = File.ReadAllText("../../../TestData/full-response-valid.json");
        SetupHttpResponse(content);
        var query = "iNd";
        var sortedCountries = JsonSerializer.Deserialize<List<Country>>(content)
            .Where(c => c.Name.Common.Contains(query, StringComparison.OrdinalIgnoreCase))
            .OrderByDescending(c => c.Name.Common)
            .ToList();
        var service = new CountriesService(_httpClientFactoryMock.Object, _optionsMock.Object);
        var filter = new Filter(new FilterByCountryName(), query);

        // Act
        var result = await service.FetchCountriesAsync(filter, sort: "descend");

        // Assert
        Assert.Equal(sortedCountries.Select(c => c.Name.Common), result.Select(c => c.Name.Common));
    }

    [Fact]
    public async Task FetchCountriesAsync_LimitApplied_ReturnsLimitedCountries()
    {
        // Arrange
        var content = File.ReadAllText("../../../TestData/full-response-valid.json");
        SetupHttpResponse(content);
        var query = "iNd";
        var limit = 2;
        var expectedCountries = JsonSerializer.Deserialize<List<Country>>(content)
            .Where(c => c.Name.Common.Contains(query, StringComparison.OrdinalIgnoreCase))
            .Take(limit)
            .ToList();
        var service = new CountriesService(_httpClientFactoryMock.Object, _optionsMock.Object);
        var filter = new Filter(new FilterByCountryName(), query);

        // Act
        var result = await service.FetchCountriesAsync(filter, limit: limit);

        // Assert
        Assert.Equal(limit, result.Count);
        Assert.Equal(expectedCountries.Select(c => c.Name.Common), result.Select(c => c.Name.Common));
    }

    private void SetupHttpResponse(string content)
    {
        var httpResponse = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(content),
        };
        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(httpResponse);
    }
}