using System.Net.Http;

namespace LlamaIndex.LlamaCloud.Exceptions;

public class LlamaCloudUnprocessableEntityException : LlamaCloud4xxException
{
    public LlamaCloudUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
