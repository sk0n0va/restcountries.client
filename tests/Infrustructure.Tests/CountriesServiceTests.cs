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
    private readonly Mock<IOptions<CountriesApiOptions>> _optionsMock;
    private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
    private const string ApiUrl = "http://testapi.com";

    public CountriesServiceTests()
    {
        _optionsMock = new Mock<IOptions<CountriesApiOptions>>();
        _optionsMock.Setup(o => o.Value).Returns(new CountriesApiOptions { ApiUrl = ApiUrl });

        _httpClientFactoryMock = new Mock<IHttpClientFactory>();
    }

    private CountriesService CreateServiceWithHandler(DelegatingHandler handler)
    {
        var httpClient = new HttpClient(handler);
        _httpClientFactoryMock.Setup(c => c.CreateClient(It.IsAny<string>())).Returns(httpClient);
        return new CountriesService(_httpClientFactoryMock.Object, _optionsMock.Object);
    }

    [Fact]
    public async Task FetchCountriesAsync_ShouldReturnCountries_WhenApiResponseIsValid()
    {
        // Arrange
        var clientHandlerStub = new DelegatingHandlerStub((request, cancellationToken) =>
        {
            var content = File.ReadAllText("../../../TestData/full-response-valid.json");
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(content)
            };
        });
        var service = CreateServiceWithHandler(clientHandlerStub);

        // Act
        var countries = await service.FetchCountriesAsync();

        // Assert
        Assert.NotNull(countries);
    }

    [Fact]
    public async Task FetchCountriesAsync_ThrowsJsonException_WhenApiProvidesInvalidJson()
    {
        // Arrange
        var clientHandlerStub = new DelegatingHandlerStub((request, cancellationToken) =>
        {
            var content = File.ReadAllText("../../../TestData/partial-response-invalid.json");
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(content)
            };
        });

        var httpClient = new HttpClient(clientHandlerStub);
        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
        httpClientFactoryMock.Setup(c => c.CreateClient(It.IsAny<string>())).Returns(httpClient);

        // Act & Assert
        await Assert.ThrowsAsync<JsonException>(() => CreateServiceWithHandler(clientHandlerStub).FetchCountriesAsync());
    }

    [Fact]
    public async Task FetchCountriesAsync_AppliesFilter_WhenFilterIsProvided()
    {
        // Arrange
        var clientHandlerStub = new DelegatingHandlerStub((request, cancellationToken) =>
        {
            var content = File.ReadAllText("../../../TestData/full-response-valid.json");
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(content)
            };
        });
        var service = CreateServiceWithHandler(clientHandlerStub);
        var filter = new Filter(new FilterByCountryName(), "ukR");

        // Act
        var result = await service.FetchCountriesAsync(filter);

        // Assert
        Assert.Single(result);
        Assert.Equal("Ukraine", result.First().Name.Common);
    }
}
