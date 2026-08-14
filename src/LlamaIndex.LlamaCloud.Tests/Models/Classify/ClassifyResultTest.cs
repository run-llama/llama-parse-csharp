using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Classify;

namespace LlamaIndex.LlamaCloud.Tests.Models.Classify;

public class ClassifyResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClassifyResult
        {
            Confidence = 0,
            Reasoning = "reasoning",
            Type = "type",
        };

        double expectedConfidence = 0;
        string expectedReasoning = "reasoning";
        string expectedType = "type";

        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedReasoning, model.Reasoning);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClassifyResult
        {
            Confidence = 0,
            Reasoning = "reasoning",
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClassifyResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClassifyResult
        {
            Confidence = 0,
            Reasoning = "reasoning",
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClassifyResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedConfidence = 0;
        string expectedReasoning = "reasoning";
        string expectedType = "type";

        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedReasoning, deserialized.Reasoning);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClassifyResult
        {
            Confidence = 0,
            Reasoning = "reasoning",
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClassifyResult
        {
            Confidence = 0,
            Reasoning = "reasoning",
            Type = "type",
        };

        ClassifyResult copied = new(model);

        Assert.Equal(model, copied);
    }
}
