namespace PruebaTecnicaCarsales.Bff.Infrastructure.RickAndMorty.Dtos
{
    public sealed class PageInfo
    {
        public int Count { get; init; }
        public int Pages { get; init; }
        public string? Next { get; init; }
        public string? Prev { get; init; }
    }

}
