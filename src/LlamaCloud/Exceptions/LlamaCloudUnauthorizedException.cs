using System.Net.Http;

namespace LlamaCloud.Exceptions;

public class LlamaCloudUnauthorizedException : LlamaCloud4xxException
{
    public LlamaCloudUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
