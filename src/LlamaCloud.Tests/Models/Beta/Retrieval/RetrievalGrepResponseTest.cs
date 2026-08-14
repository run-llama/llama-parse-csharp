using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Beta.Retrieval;

namespace LlamaCloud.Tests.Models.Beta.Retrieval;

public class RetrievalGrepResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RetrievalGrepResponse
        {
            Content = "content",
            EndChar = 0,
            StartChar = 0,
        };

        string expectedContent = "content";
        long expectedEndChar = 0;
        long expectedStartChar = 0;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedEndChar, model.EndChar);
        Assert.Equal(expectedStartChar, model.StartChar);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RetrievalGrepResponse
        {
            Content = "content",
            EndChar = 0,
            StartChar = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetrievalGrepResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RetrievalGrepResponse
        {
            Content = "content",
            EndChar = 0,
            StartChar = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetrievalGrepResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        long expectedEndChar = 0;
        long expectedStartChar = 0;

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedEndChar, deserialized.EndChar);
        Assert.Equal(expectedStartChar, deserialized.StartChar);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RetrievalGrepResponse
        {
            Content = "content",
            EndChar = 0,
            StartChar = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RetrievalGrepResponse
        {
            Content = "content",
            EndChar = 0,
            StartChar = 0,
        };

        RetrievalGrepResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
