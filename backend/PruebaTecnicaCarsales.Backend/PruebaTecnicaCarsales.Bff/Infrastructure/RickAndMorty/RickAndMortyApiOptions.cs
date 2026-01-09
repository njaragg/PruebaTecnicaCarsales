namespace PruebaTecnicaCarsales.Bff.Infrastructure.RickAndMorty
{
    public class RickAndMortyApiOptions
    {
        public const string SectionName = "RickAndMortyApi";
        public string BaseUrl { get; init; } = "";
        public int TimeoutSeconds { get; init; } = 10;

    }
}
