using PruebaTecnicaCarsales.Bff.Application.Common;
using PruebaTecnicaCarsales.Bff.Infrastructure.RickAndMorty;
using PruebaTecnicaCarsales.Bff.Infrastructure.RickAndMorty.Dtos;

namespace PruebaTecnicaCarsales.Bff.Application.Episodes.GetEpisodes
{
    // Use-case: "Listar episodios"
    public sealed class GetEpisodesUseCase : IGetEpisodesUseCase
    {
        private readonly IRickAndMortyClient _client;

        public GetEpisodesUseCase(IRickAndMortyClient client)
            => _client = client;

        public async Task<PagedResponse<EpisodeDto>> Execute(GetEpisodesQuery query, CancellationToken ct)
        {
            Validate(query);

            var api = await _client.GetEpisodesAsync(query.Page, query.Name, ct);

            var results = (api.Results ?? new List<EpisodeApiDto>())
                .Select(EpisodeMapper.ToDto)
                .ToList();

            return new PagedResponse<EpisodeDto>(
                api.Info?.Count ?? 0,
                api.Info?.Pages ?? 0,
                api.Info?.Next,
                api.Info?.Prev,
                results
            );
        }

        private static void Validate(GetEpisodesQuery query)
        {
            if (query.Page < 1)
                throw new ArgumentOutOfRangeException(nameof(query.Page), "Page must be >= 1.");
        }
    }
}
