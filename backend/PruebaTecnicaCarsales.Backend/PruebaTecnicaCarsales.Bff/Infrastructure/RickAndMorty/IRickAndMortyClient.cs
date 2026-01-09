using PruebaTecnicaCarsales.Bff.Infrastructure.RickAndMorty.Dtos;

namespace PruebaTecnicaCarsales.Bff.Infrastructure.RickAndMorty
{
    public interface IRickAndMortyClient
    {
        Task<PagedApiResponse<EpisodeApiDto>> GetEpisodesAsync(
            int page,
            string? name,
            CancellationToken ct);
        Task<PagedApiResponse<CharacterApiDto>> GetCharactersAsync(
            int page,
            string? name,
            CancellationToken ct);
    }
}
