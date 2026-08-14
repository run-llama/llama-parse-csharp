using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Pipelines;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines;

public class RetrievalModeTest : TestBase
{
    [Theory]
    [InlineData(RetrievalMode.AutoRouted)]
    [InlineData(RetrievalMode.Chunks)]
    [InlineData(RetrievalMode.FilesViaContent)]
    [InlineData(RetrievalMode.FilesViaMetadata)]
    public void Validation_Works(RetrievalMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RetrievalMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RetrievalMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RetrievalMode.AutoRouted)]
    [InlineData(RetrievalMode.Chunks)]
    [InlineData(RetrievalMode.FilesViaContent)]
    [InlineData(RetrievalMode.FilesViaMetadata)]
    public void SerializationRoundtrip_Works(RetrievalMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RetrievalMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RetrievalMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RetrievalMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RetrievalMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
