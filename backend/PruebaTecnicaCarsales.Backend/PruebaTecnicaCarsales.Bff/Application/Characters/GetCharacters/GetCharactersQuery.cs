namespace PruebaTecnicaCarsales.Bff.Application.Characters.GetCharacters
{
    public sealed record GetCharactersQuery(
        int Page,
        string? Name
    );
}
