using System.Net.Http;

namespace LlamaCloud.Exceptions;

public class LlamaCloudBadRequestException : LlamaCloud4xxException
{
    public LlamaCloudBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
