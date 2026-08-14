using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Retrievers;

namespace LlamaCloud.Tests.Models.Retrievers;

public class CompositeRetrievalModeTest : TestBase
{
    [Theory]
    [InlineData(CompositeRetrievalMode.Full)]
    [InlineData(CompositeRetrievalMode.Routing)]
    public void Validation_Works(CompositeRetrievalMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CompositeRetrievalMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CompositeRetrievalMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CompositeRetrievalMode.Full)]
    [InlineData(CompositeRetrievalMode.Routing)]
    public void SerializationRoundtrip_Works(CompositeRetrievalMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CompositeRetrievalMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CompositeRetrievalMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CompositeRetrievalMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CompositeRetrievalMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
