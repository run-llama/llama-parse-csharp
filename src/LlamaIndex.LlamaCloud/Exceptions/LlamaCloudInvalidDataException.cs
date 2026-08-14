using System;

namespace LlamaIndex.LlamaCloud.Exceptions;

public class LlamaCloudInvalidDataException : LlamaCloudException
{
    public LlamaCloudInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
