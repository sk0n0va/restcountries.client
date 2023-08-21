using Infrastructure.Models;
using Infrastructure.Options;
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

        public async Task<IReadOnlyCollection<Country>> FetchCountriesAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync(_apiUrl);

            try
            {
                return JsonSerializer.Deserialize<List<Country>>(response);
            }
            catch (JsonException ex)
            {
                throw new JsonException($"An error occurred while deserializing the response. Input: {response?[..Math.Min(response.Length, 200)]}", ex);
            }
        }
    }
}