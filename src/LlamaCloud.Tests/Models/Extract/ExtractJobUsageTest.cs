using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Extract;

namespace LlamaCloud.Tests.Models.Extract;

public class ExtractJobUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractJobUsage { NumPagesBilled = 0, NumPagesExtracted = 0 };

        long expectedNumPagesBilled = 0;
        long expectedNumPagesExtracted = 0;

        Assert.Equal(expectedNumPagesBilled, model.NumPagesBilled);
        Assert.Equal(expectedNumPagesExtracted, model.NumPagesExtracted);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractJobUsage { NumPagesBilled = 0, NumPagesExtracted = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractJobUsage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractJobUsage { NumPagesBilled = 0, NumPagesExtracted = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractJobUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedNumPagesBilled = 0;
        long expectedNumPagesExtracted = 0;

        Assert.Equal(expectedNumPagesBilled, deserialized.NumPagesBilled);
        Assert.Equal(expectedNumPagesExtracted, deserialized.NumPagesExtracted);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractJobUsage { NumPagesBilled = 0, NumPagesExtracted = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtractJobUsage { };

        Assert.Null(model.NumPagesBilled);
        Assert.False(model.RawData.ContainsKey("num_pages_billed"));
        Assert.Null(model.NumPagesExtracted);
        Assert.False(model.RawData.ContainsKey("num_pages_extracted"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtractJobUsage { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ExtractJobUsage { NumPagesBilled = null, NumPagesExtracted = null };

        Assert.Null(model.NumPagesBilled);
        Assert.True(model.RawData.ContainsKey("num_pages_billed"));
        Assert.Null(model.NumPagesExtracted);
        Assert.True(model.RawData.ContainsKey("num_pages_extracted"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtractJobUsage { NumPagesBilled = null, NumPagesExtracted = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractJobUsage { NumPagesBilled = 0, NumPagesExtracted = 0 };

        ExtractJobUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}
