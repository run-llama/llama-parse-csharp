using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Pipelines;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines;

public class MessageRoleTest : TestBase
{
    [Theory]
    [InlineData(MessageRole.Assistant)]
    [InlineData(MessageRole.Chatbot)]
    [InlineData(MessageRole.Developer)]
    [InlineData(MessageRole.Function)]
    [InlineData(MessageRole.Model)]
    [InlineData(MessageRole.System)]
    [InlineData(MessageRole.Tool)]
    [InlineData(MessageRole.User)]
    public void Validation_Works(MessageRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessageRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MessageRole.Assistant)]
    [InlineData(MessageRole.Chatbot)]
    [InlineData(MessageRole.Developer)]
    [InlineData(MessageRole.Function)]
    [InlineData(MessageRole.Model)]
    [InlineData(MessageRole.System)]
    [InlineData(MessageRole.Tool)]
    [InlineData(MessageRole.User)]
    public void SerializationRoundtrip_Works(MessageRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessageRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessageRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessageRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
