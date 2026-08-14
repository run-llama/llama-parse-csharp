using System;
using System.Net.Http;

namespace LlamaCloud.Exceptions;

public class LlamaCloudException : Exception
{
    public LlamaCloudException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected LlamaCloudException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
