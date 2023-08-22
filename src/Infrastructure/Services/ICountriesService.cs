using Infrastructure.Models;
using Infrastructure.Services.Filtering;

namespace Infrastructure.Services
{
    public interface ICountriesService
    {
        Task<IReadOnlyCollection<Country>> FetchCountriesAsync(Filter? filter = null, string sort = "acsend");
    }
}