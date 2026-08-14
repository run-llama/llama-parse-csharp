using System.Net.Http;

namespace LlamaIndex.LlamaCloud.Exceptions;

public class LlamaCloud5xxException : LlamaCloudApiException
{
    public LlamaCloud5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
