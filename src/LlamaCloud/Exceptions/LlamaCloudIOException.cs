using System;
using System.Net.Http;

namespace LlamaCloud.Exceptions;

public class LlamaCloudIOException : LlamaCloudException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public LlamaCloudIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
