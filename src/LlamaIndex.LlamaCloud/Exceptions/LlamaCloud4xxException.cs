using System.Net.Http;

namespace LlamaIndex.LlamaCloud.Exceptions;

public class LlamaCloud4xxException : LlamaCloudApiException
{
    public LlamaCloud4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
