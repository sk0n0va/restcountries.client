using Infrastructure.Models;

namespace Infrastructure.Services.Filtering;

public class FilterByCountryPopulation : ICountryFilterStrategy
{
    public IEnumerable<Country> Filter(IEnumerable<Country> countries, string query)
    {
        if (!int.TryParse(query, out int populationThresholdInMillions))
            throw new ArgumentException("Query must be a valid integer.");

        int populationThreshold = populationThresholdInMillions * 1_000_000;

        return countries.Where(c => c.Population < populationThreshold);
    }
}
