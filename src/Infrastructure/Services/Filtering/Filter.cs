namespace Infrastructure.Services.Filtering
{
    public record Filter
    {
        public ICountryFilterStrategy Strategy { get; }
        public string Query { get; }

        public Filter(ICountryFilterStrategy strategy, string query)
        {
            Strategy = strategy;
            Query = query;
        }
    }
}
