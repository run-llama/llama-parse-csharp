using System.Net.Http;

namespace LlamaCloud.Exceptions;

public class LlamaCloudUnprocessableEntityException : LlamaCloud4xxException
{
    public LlamaCloudUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
