using Infrastructure.Models;

namespace Infrastructure.Services.Filtering;

public class FilterByCountryName : ICountryFilterStrategy
{
    public IEnumerable<Country> Filter(IEnumerable<Country> countries, string query)
    {
        return countries.Where(c => c.Name.Common.Contains(query, StringComparison.OrdinalIgnoreCase));
    }
}