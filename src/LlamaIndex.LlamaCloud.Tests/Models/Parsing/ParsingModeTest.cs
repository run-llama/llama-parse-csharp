using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Parsing;

namespace LlamaIndex.LlamaCloud.Tests.Models.Parsing;

public class ParsingModeTest : TestBase
{
    [Theory]
    [InlineData(ParsingMode.ParseDocumentWithAgent)]
    [InlineData(ParsingMode.ParseDocumentWithLlm)]
    [InlineData(ParsingMode.ParseDocumentWithLvm)]
    [InlineData(ParsingMode.ParsePageWithAgent)]
    [InlineData(ParsingMode.ParsePageWithLayoutAgent)]
    [InlineData(ParsingMode.ParsePageWithLlm)]
    [InlineData(ParsingMode.ParsePageWithLvm)]
    [InlineData(ParsingMode.ParsePageWithoutLlm)]
    public void Validation_Works(ParsingMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ParsingMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ParsingMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ParsingMode.ParseDocumentWithAgent)]
    [InlineData(ParsingMode.ParseDocumentWithLlm)]
    [InlineData(ParsingMode.ParseDocumentWithLvm)]
    [InlineData(ParsingMode.ParsePageWithAgent)]
    [InlineData(ParsingMode.ParsePageWithLayoutAgent)]
    [InlineData(ParsingMode.ParsePageWithLlm)]
    [InlineData(ParsingMode.ParsePageWithLvm)]
    [InlineData(ParsingMode.ParsePageWithoutLlm)]
    public void SerializationRoundtrip_Works(ParsingMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ParsingMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ParsingMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ParsingMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ParsingMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
