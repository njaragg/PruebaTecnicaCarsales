namespace PruebaTecnicaCarsales.Bff.Application.Episodes.GetEpisodes
{
    public sealed record GetEpisodesQuery(
        int Page,
        string? Name
    );
}
