using System.Net.Http;

namespace LlamaCloud.Exceptions;

public class LlamaCloud5xxException : LlamaCloudApiException
{
    public LlamaCloud5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
