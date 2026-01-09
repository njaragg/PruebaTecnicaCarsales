using System.Text.Json.Serialization;

namespace PruebaTecnicaCarsales.Bff.Infrastructure.RickAndMorty.Dtos
{
    public sealed class PagedApiResponse<T>
    {
        [JsonPropertyName("info")]
        public PageInfo Info { get; init; } = new();

        [JsonPropertyName("results")]
        public List<T> Results { get; init; } = new();
    }
}
