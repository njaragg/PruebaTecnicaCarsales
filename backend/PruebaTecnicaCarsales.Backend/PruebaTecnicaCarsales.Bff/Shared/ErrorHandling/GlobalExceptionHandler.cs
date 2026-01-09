using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaCarsales.Bff.Shared.Exceptions;

namespace PruebaTecnicaCarsales.Bff.Shared.ErrorHandling
{
    public sealed class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext context,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var (status, title) = exception switch
            {
                UpstreamTimeoutException => (StatusCodes.Status504GatewayTimeout, "Upstream timeout"),
                UpstreamServiceException => (StatusCodes.Status502BadGateway, "Upstream service error"),
                _ => (StatusCodes.Status500InternalServerError, "Unexpected error")
            };

            var problem = new ProblemDetails
            {
                Status = status,
                Title = title,
                Detail = exception.Message,
                Instance = context.Request.Path
            };

            context.Response.StatusCode = status;
            await context.Response.WriteAsJsonAsync(problem, cancellationToken);

            return true;
        }
    }
}
