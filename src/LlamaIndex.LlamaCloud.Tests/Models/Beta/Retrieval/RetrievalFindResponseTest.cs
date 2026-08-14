using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.Retrieval;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.Retrieval;

public class RetrievalFindResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RetrievalFindResponse { FileID = "file_id", FileName = "file_name" };

        string expectedFileID = "file_id";
        string expectedFileName = "file_name";

        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedFileName, model.FileName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RetrievalFindResponse { FileID = "file_id", FileName = "file_name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetrievalFindResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RetrievalFindResponse { FileID = "file_id", FileName = "file_name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetrievalFindResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFileID = "file_id";
        string expectedFileName = "file_name";

        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedFileName, deserialized.FileName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RetrievalFindResponse { FileID = "file_id", FileName = "file_name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RetrievalFindResponse { FileID = "file_id", FileName = "file_name" };

        RetrievalFindResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
