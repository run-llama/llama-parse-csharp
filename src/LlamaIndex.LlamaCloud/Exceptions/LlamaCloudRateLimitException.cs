using System.Net.Http;

namespace LlamaIndex.LlamaCloud.Exceptions;

public class LlamaCloudRateLimitException : LlamaCloud4xxException
{
    public LlamaCloudRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
