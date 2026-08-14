using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Parsing;

public class ParsingJobTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ParsingJob
        {
            ID = "id",
            Status = StatusEnum.Cancelled,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
        };

        string expectedID = "id";
        ApiEnum<string, StatusEnum> expectedStatus = StatusEnum.Cancelled;
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ParsingJob
        {
            ID = "id",
            Status = StatusEnum.Cancelled,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParsingJob>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ParsingJob
        {
            ID = "id",
            Status = StatusEnum.Cancelled,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParsingJob>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, StatusEnum> expectedStatus = StatusEnum.Cancelled;
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ParsingJob
        {
            ID = "id",
            Status = StatusEnum.Cancelled,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ParsingJob { ID = "id", Status = StatusEnum.Cancelled };

        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ParsingJob { ID = "id", Status = StatusEnum.Cancelled };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ParsingJob
        {
            ID = "id",
            Status = StatusEnum.Cancelled,

            ErrorCode = null,
            ErrorMessage = null,
        };

        Assert.Null(model.ErrorCode);
        Assert.True(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("error_message"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ParsingJob
        {
            ID = "id",
            Status = StatusEnum.Cancelled,

            ErrorCode = null,
            ErrorMessage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ParsingJob
        {
            ID = "id",
            Status = StatusEnum.Cancelled,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
        };

        ParsingJob copied = new(model);

        Assert.Equal(model, copied);
    }
}
