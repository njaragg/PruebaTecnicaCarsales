using PruebaTecnicaCarsales.Bff.Infrastructure.RickAndMorty.Dtos;

namespace PruebaTecnicaCarsales.Bff.Application.Episodes.GetEpisodes
{
    internal static class EpisodeMapper
    {
        public static EpisodeDto ToDto(EpisodeApiDto x)
            => new(x.Id, x.Name, x.AirDate, x.EpisodeCode);
    }
}
