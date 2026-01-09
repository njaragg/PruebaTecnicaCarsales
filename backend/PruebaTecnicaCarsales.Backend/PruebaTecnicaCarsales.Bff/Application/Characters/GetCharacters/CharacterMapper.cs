using PruebaTecnicaCarsales.Bff.Infrastructure.RickAndMorty.Dtos;

namespace PruebaTecnicaCarsales.Bff.Application.Characters.GetCharacters
{
    internal static class CharacterMapper
    {
        public static CharacterDto ToDto(CharacterApiDto x)
            => new(x.Id, x.Name, x.Status, x.Species, x.Gender, x.Image);
    }
}
