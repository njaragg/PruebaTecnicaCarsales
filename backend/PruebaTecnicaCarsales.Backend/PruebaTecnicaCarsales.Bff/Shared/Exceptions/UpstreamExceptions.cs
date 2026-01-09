namespace PruebaTecnicaCarsales.Bff.Shared.Exceptions
{
    public class UpstreamServiceException : Exception
    {
        public UpstreamServiceException(string message, Exception? inner = null)
            : base(message, inner) { }
    }

    public sealed class UpstreamTimeoutException : UpstreamServiceException
    {
        public UpstreamTimeoutException(string message, Exception? inner = null)
            : base(message, inner) { }
    }
}
