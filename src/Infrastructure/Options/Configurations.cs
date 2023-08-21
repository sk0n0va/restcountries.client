using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Options
{
    public static class Configurations
    {
        public static IServiceCollection AddCountriesService(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetRequiredSection(CountriesApiOptions.Key);
            services.Configure<CountriesApiOptions>(section);

            services.AddScoped<ICountriesService, CountriesService>();

            return services;
        }
    }
}
