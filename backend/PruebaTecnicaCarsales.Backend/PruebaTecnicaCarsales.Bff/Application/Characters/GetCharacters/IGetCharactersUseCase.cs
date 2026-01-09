using PruebaTecnicaCarsales.Bff.Application.Characters.GetCharacters;
using PruebaTecnicaCarsales.Bff.Application.Common;

namespace PruebaTecnicaCarsales.Bff.Application.Characters.GetCharacters
{
    public interface IGetCharactersUseCase
    {
        Task<PagedResponse<CharacterDto>> Execute(GetCharactersQuery query, CancellationToken ct);
    }
}
