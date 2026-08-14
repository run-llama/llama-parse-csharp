using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Parsing;

namespace LlamaIndex.LlamaCloud.Tests.Models.Parsing;

public class FailPageModeTest : TestBase
{
    [Theory]
    [InlineData(FailPageMode.BlankPage)]
    [InlineData(FailPageMode.ErrorMessage)]
    [InlineData(FailPageMode.RawText)]
    public void Validation_Works(FailPageMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FailPageMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FailPageMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FailPageMode.BlankPage)]
    [InlineData(FailPageMode.ErrorMessage)]
    [InlineData(FailPageMode.RawText)]
    public void SerializationRoundtrip_Works(FailPageMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FailPageMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FailPageMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FailPageMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FailPageMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
