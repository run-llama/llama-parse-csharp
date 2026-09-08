using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Pipelines;

namespace LlamaCloud.Tests.Models.Pipelines;

public class PipelinePipelineTypeTest : TestBase
{
    [Theory]
    [InlineData(PipelinePipelineType.Managed)]
    [InlineData(PipelinePipelineType.Playground)]
    public void Validation_Works(PipelinePipelineType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PipelinePipelineType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PipelinePipelineType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PipelinePipelineType.Managed)]
    [InlineData(PipelinePipelineType.Playground)]
    public void SerializationRoundtrip_Works(PipelinePipelineType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PipelinePipelineType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PipelinePipelineType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PipelinePipelineType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PipelinePipelineType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
