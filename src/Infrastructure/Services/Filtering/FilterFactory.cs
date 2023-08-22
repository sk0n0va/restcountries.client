namespace Infrastructure.Services.Filtering;

public class FilterFactory
{
    public static Filter? Create(FilterType filterType, string? query)
    {
        if (string.IsNullOrEmpty(query)) return null;

        return filterType switch
        {
            FilterType.CountryCommonName => new Filter(new FilterByCountryName(), query),
            FilterType.CountryPopulation => new Filter(new FilterByCountryPopulation(), query),
            _ => null
        };
    }
}

