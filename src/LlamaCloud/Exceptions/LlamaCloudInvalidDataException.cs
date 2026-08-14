using System;

namespace LlamaCloud.Exceptions;

public class LlamaCloudInvalidDataException : LlamaCloudException
{
    public LlamaCloudInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
