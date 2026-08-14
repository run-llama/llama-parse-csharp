using System.Net.Http;

namespace LlamaIndex.LlamaCloud.Exceptions;

public class LlamaCloudBadRequestException : LlamaCloud4xxException
{
    public LlamaCloudBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
