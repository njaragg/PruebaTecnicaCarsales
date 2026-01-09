namespace PruebaTecnicaCarsales.Bff.Application.Episodes.GetEpisodes
{
    public sealed record EpisodeDto(
        int Id,
        string Name,
        string AirDate,
        string EpisodeCode
    );
}
