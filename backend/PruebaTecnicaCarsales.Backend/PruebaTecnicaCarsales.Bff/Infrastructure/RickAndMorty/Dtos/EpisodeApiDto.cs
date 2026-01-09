using System.Text.Json.Serialization;

namespace PruebaTecnicaCarsales.Bff.Infrastructure.RickAndMorty.Dtos
{

    public sealed class EpisodeApiDto
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = "";

        [JsonPropertyName("air_date")]
        public string AirDate { get; init; } = "";

        [JsonPropertyName("episode")]
        public string EpisodeCode { get; init; } = "";
    }
}
