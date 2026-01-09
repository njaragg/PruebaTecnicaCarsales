namespace PruebaTecnicaCarsales.Bff.Application.Characters.GetCharacters
{
    public sealed record CharacterDto(
         int Id,
         string Name,
         string Status,
         string Species,
         string Gender,
         string Image
     );
}
