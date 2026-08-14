using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Parsing;

public class StatusEnumTest : TestBase
{
    [Theory]
    [InlineData(StatusEnum.Cancelled)]
    [InlineData(StatusEnum.Error)]
    [InlineData(StatusEnum.PartialSuccess)]
    [InlineData(StatusEnum.Pending)]
    [InlineData(StatusEnum.Success)]
    public void Validation_Works(StatusEnum rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StatusEnum> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StatusEnum>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StatusEnum.Cancelled)]
    [InlineData(StatusEnum.Error)]
    [InlineData(StatusEnum.PartialSuccess)]
    [InlineData(StatusEnum.Pending)]
    [InlineData(StatusEnum.Success)]
    public void SerializationRoundtrip_Works(StatusEnum rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StatusEnum> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StatusEnum>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StatusEnum>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StatusEnum>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
