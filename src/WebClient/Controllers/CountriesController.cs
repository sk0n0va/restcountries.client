using Infrastructure.Models;
using Infrastructure.Services;
using Infrastructure.Services.Filtering;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Country>>> Get([FromQuery] FilterType filterType = 0, [FromQuery] string? query = null)
        {
            var filter = FilterFactory.Create(filterType, query);
            var countries = await _countriesService.FetchCountriesAsync(filter);

            return Ok(countries);
        }
    }
}