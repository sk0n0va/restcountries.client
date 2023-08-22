using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebClient.Controllers;
using WebClient.Tests.TestData;

namespace WebClient.Tests;

public class CountriesControllerTests
{
    private readonly Mock<ICountriesService> _countriesServiceMock;
    private readonly CountriesController _controller;

    public CountriesControllerTests()
    {
        _countriesServiceMock = new Mock<ICountriesService>();
        _controller = new CountriesController(_countriesServiceMock.Object);
    }

    [Fact]
    public async Task Get_ReturnsCountries_WhenServiceSucceeds()
    {
        // Arrange
        var mockCountries = CountriesLists.GetValidListWithOneItem();
        _countriesServiceMock.Setup(s => s.FetchCountriesAsync()).ReturnsAsync(mockCountries);

        // Act
        var result = await _controller.Get(null, null, null, null);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var countries = Assert.IsType<List<Country>>(okResult.Value);
        Assert.Equal(mockCountries.Count, countries.Count);
    }

    [Fact]
    public async Task Get_ThrowsException_WhenServiceFails()
    {
        // Arrange
        _countriesServiceMock.Setup(s => s.FetchCountriesAsync()).ThrowsAsync(new Exception());

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _controller.Get(null, null, null, null));
    }
}
