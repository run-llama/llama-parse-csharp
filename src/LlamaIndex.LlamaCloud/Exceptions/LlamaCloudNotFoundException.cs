using System.Net.Http;

namespace LlamaIndex.LlamaCloud.Exceptions;

public class LlamaCloudNotFoundException : LlamaCloud4xxException
{
    public LlamaCloudNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
