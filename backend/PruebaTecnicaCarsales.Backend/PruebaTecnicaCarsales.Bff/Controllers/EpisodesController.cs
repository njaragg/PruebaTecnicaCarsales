using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaCarsales.Bff.Application.Common;
using PruebaTecnicaCarsales.Bff.Application.Episodes.GetEpisodes;

namespace PruebaTecnicaCarsales.Bff.Controllers;

[ApiController]
[Route("episodes")]
public sealed class EpisodesController : ControllerBase
{
    private readonly IGetEpisodesUseCase _useCase;

    public EpisodesController(IGetEpisodesUseCase useCase)
        => _useCase = useCase;

    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<EpisodeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status502BadGateway)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status504GatewayTimeout)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedResponse<EpisodeDto>>> Get(
        [FromQuery] int page = 1,
        [FromQuery] string? name = null,
        CancellationToken ct = default)
    {
        //validacion pagina negativa
        if (page < 1)
        {
            return Problem(
                title: "Invalid query parameter",
                detail: "Query parameter 'page' must be >= 1.",
                statusCode: StatusCodes.Status400BadRequest);
        }

        var result = await _useCase.Execute(new GetEpisodesQuery(page, name), ct);
        return Ok(result);
    }
}
