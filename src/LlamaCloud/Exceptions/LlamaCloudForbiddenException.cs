using System.Net.Http;

namespace LlamaCloud.Exceptions;

public class LlamaCloudForbiddenException : LlamaCloud4xxException
{
    public LlamaCloudForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
