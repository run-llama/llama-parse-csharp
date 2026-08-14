using System.Net.Http;

namespace LlamaIndex.LlamaCloud.Exceptions;

public class LlamaCloudForbiddenException : LlamaCloud4xxException
{
    public LlamaCloudForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
