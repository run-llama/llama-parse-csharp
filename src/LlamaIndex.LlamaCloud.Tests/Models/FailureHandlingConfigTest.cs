using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models;

namespace LlamaIndex.LlamaCloud.Tests.Models;

public class FailureHandlingConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FailureHandlingConfig { SkipListFailures = true };

        bool expectedSkipListFailures = true;

        Assert.Equal(expectedSkipListFailures, model.SkipListFailures);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FailureHandlingConfig { SkipListFailures = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FailureHandlingConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FailureHandlingConfig { SkipListFailures = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FailureHandlingConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedSkipListFailures = true;

        Assert.Equal(expectedSkipListFailures, deserialized.SkipListFailures);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FailureHandlingConfig { SkipListFailures = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FailureHandlingConfig { };

        Assert.Null(model.SkipListFailures);
        Assert.False(model.RawData.ContainsKey("skip_list_failures"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FailureHandlingConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FailureHandlingConfig
        {
            // Null should be interpreted as omitted for these properties
            SkipListFailures = null,
        };

        Assert.Null(model.SkipListFailures);
        Assert.False(model.RawData.ContainsKey("skip_list_failures"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FailureHandlingConfig
        {
            // Null should be interpreted as omitted for these properties
            SkipListFailures = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FailureHandlingConfig { SkipListFailures = true };

        FailureHandlingConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}
