using System.Text.Json.Serialization;

namespace PruebaTecnicaCarsales.Bff.Infrastructure.RickAndMorty.Dtos
{
    public sealed class CharacterApiDto
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = "";

        [JsonPropertyName("status")]
        public string Status { get; init; } = "";

        [JsonPropertyName("species")]
        public string Species { get; init; } = "";

        [JsonPropertyName("type")]
        public string Type { get; init; } = "";

        [JsonPropertyName("gender")]
        public string Gender { get; init; } = "";

        [JsonPropertyName("image")]
        public string Image { get; init; } = "";

    }
}
