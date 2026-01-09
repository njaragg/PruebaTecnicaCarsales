using PruebaTecnicaCarsales.Bff.Application.Common;

namespace PruebaTecnicaCarsales.Bff.Application.Episodes.GetEpisodes
{
    public interface IGetEpisodesUseCase
    {
        Task<PagedResponse<EpisodeDto>> Execute(GetEpisodesQuery query, CancellationToken ct);
    }
}
