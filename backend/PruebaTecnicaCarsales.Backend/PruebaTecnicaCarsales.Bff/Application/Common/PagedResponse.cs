namespace PruebaTecnicaCarsales.Bff.Application.Common
{
    public sealed record PagedResponse<T>(
        int Count,
        int Pages,
        string? Next,
        string? Prev,
        IReadOnlyList<T> Results
    );
}
