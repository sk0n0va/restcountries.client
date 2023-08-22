using Infrastructure.Models;
using Infrastructure.Options;
using Infrastructure.Services.Filtering;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Infrastructure.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiUrl;

        public CountriesService(IHttpClientFactory httpClientFactory, IOptions<CountriesApiOptions> options)
        {
            _httpClientFactory = httpClientFactory;
            _apiUrl = options.Value.ApiUrl;
        }

        public async Task<IReadOnlyCollection<Country>> FetchCountriesAsync(Filter? filter = null, string sort = "acsend")
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync(_apiUrl);

            IEnumerable<Country> countries;
            try
            {
                countries = JsonSerializer.Deserialize<List<Country>>(response).ToList();
            }
            catch (JsonException ex)
            {
                throw new JsonException($"An error occurred while deserializing the response. Input: {response?[..Math.Min(response.Length, 200)]}", ex);
            }

            if (filter is not null && countries is not null)
            {
                return filter.Strategy.Filter(countries, filter.Query).ToList();
            }

            if(countries is not null)
            {
                countries = filter?.Strategy.Filter(countries, filter.Query) ?? countries;
                countries = Sort(countries, sort);
            }

            return countries?.ToList() ?? new List<Country>();
        }

        private IEnumerable<Country> Sort(IEnumerable<Country> countries, string sort, Func<Country, object>? keySelector = null)
        {
            keySelector ??= c => c.Name.Common;

            if (sort == "acsend")
                return countries.OrderBy(o => o.Name).AsEnumerable();
            else if (sort == "descend")
                return countries.OrderByDescending(keySelector);

            return countries;
        }
    }
}