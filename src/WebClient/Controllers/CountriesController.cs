using Infrastructure.Models;
using Infrastructure.Services;
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
        public async Task<ActionResult<IReadOnlyCollection<Country>>> Get([FromQuery] string? param1, [FromQuery] int? param2, [FromQuery] string? param3, [FromQuery] string? param4)
        {
            var countries = await _countriesService.FetchCountriesAsync();

            return Ok(countries);
        }
    }
}