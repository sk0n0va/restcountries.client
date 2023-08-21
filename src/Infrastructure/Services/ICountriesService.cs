using Infrastructure.Models;

namespace Infrastructure.Services
{
    public interface ICountriesService
    {
        Task<IReadOnlyCollection<Country>> FetchCountriesAsync();
    }
}