using PruebaTecnicaCarsales.Bff.Application.Common;
using PruebaTecnicaCarsales.Bff.Infrastructure.RickAndMorty;
using PruebaTecnicaCarsales.Bff.Infrastructure.RickAndMorty.Dtos;

namespace PruebaTecnicaCarsales.Bff.Application.Characters.GetCharacters
{

    public sealed class GetCharactersUseCase : IGetCharactersUseCase
    {
        private readonly IRickAndMortyClient _client;

        public GetCharactersUseCase(IRickAndMortyClient client)
            => _client = client;

        public async Task<PagedResponse<CharacterDto>> Execute(GetCharactersQuery query, CancellationToken ct)
        {
            Validate(query);

            var api = await _client.GetCharactersAsync(query.Page, query.Name, ct);

            var results = (api.Results ?? new List<CharacterApiDto>())
                .Select(CharacterMapper.ToDto)
                .ToList();

            return new PagedResponse<CharacterDto>(
                api.Info?.Count ?? 0,
                api.Info?.Pages ?? 0,
                api.Info?.Next,
                api.Info?.Prev,
                results
            );
        }

        private static void Validate(GetCharactersQuery query)
        {
            if (query.Page < 1)
                throw new ArgumentOutOfRangeException(nameof(query.Page), "Page must be >= 1.");
        }
    }
}
