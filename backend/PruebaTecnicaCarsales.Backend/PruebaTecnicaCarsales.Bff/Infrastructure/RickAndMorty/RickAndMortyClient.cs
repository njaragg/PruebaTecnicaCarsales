using PruebaTecnicaCarsales.Bff.Infrastructure.RickAndMorty.Dtos;
using PruebaTecnicaCarsales.Bff.Shared.Exceptions;
using System.Net;

namespace PruebaTecnicaCarsales.Bff.Infrastructure.RickAndMorty
{
    public class RickAndMortyClient(HttpClient http) : IRickAndMortyClient
    {
        public Task<PagedApiResponse<CharacterApiDto>> GetCharactersAsync(int page, string? name, CancellationToken ct)
            => GetPagedAsync<CharacterApiDto>("character", page, name, ct);

        public Task<PagedApiResponse<EpisodeApiDto>> GetEpisodesAsync(int page, string? name, CancellationToken ct)
            => GetPagedAsync<EpisodeApiDto>("episode", page, name, ct);

        private async Task<PagedApiResponse<T>> GetPagedAsync<T>(string resource, int page, string? name, CancellationToken ct)
        {
            var url = $"{resource}?page={page}";
            if (!string.IsNullOrWhiteSpace(name))
                url += $"&name={Uri.EscapeDataString(name)}";

            try
            {
                var res = await http.GetAsync(url, ct);

                // La API devuelve 404 cuando no encuentra por filtros (ej: name)
                if (res.StatusCode == HttpStatusCode.NotFound)
                    return new PagedApiResponse<T>();

                if (!res.IsSuccessStatusCode)
                    throw new UpstreamServiceException(
                        $"RickAndMorty API returned {(int)res.StatusCode} {res.ReasonPhrase} for '{resource}'.");

                return (await res.Content.ReadFromJsonAsync<PagedApiResponse<T>>(cancellationToken: ct))
                       ?? new PagedApiResponse<T>();
            }
            catch (TaskCanceledException ex) when (!ct.IsCancellationRequested)
            {
                // Timeout de HttpClient 
                throw new UpstreamTimeoutException("RickAndMorty API request timed out.", ex);
            }
            catch (HttpRequestException ex)
            {
                throw new UpstreamServiceException($"Error calling RickAndMorty API for '{resource}'.", ex);
            }
        }
    }
}
