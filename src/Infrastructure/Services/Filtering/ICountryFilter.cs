using Infrastructure.Models;

namespace Infrastructure.Services.Filtering;

public interface ICountryFilterStrategy
{
    IEnumerable<Country> Filter(IEnumerable<Country> countries, string query);
}