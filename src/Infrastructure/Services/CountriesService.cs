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
                return JsonSerializer.Deserialize<List<Country>>(response) ??
                    throw new InvalidOperationException("Failed to deserialize countries. Result is null.");
            }
            catch (JsonException ex)
            {
                int errorPos = (int)(ex.BytePositionInLine ?? 0);
                int start = Math.Max(0, errorPos - 40);
                int length = Math.Min(response.Length - start, 60);

                string fragment = response.Substring(start, length);

                throw new JsonException($"Deserialization failed near: ...{fragment}...", ex);
            }
        }
    }
}