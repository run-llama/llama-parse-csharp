using System.Net.Http;

namespace LlamaCloud.Exceptions;

public class LlamaCloudRateLimitException : LlamaCloud4xxException
{
    public LlamaCloudRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
