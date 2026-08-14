using System.Net.Http;

namespace LlamaCloud.Exceptions;

public class LlamaCloudUnexpectedStatusCodeException : LlamaCloudApiException
{
    public LlamaCloudUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
