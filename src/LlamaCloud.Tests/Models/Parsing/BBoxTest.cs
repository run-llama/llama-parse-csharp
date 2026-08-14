using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Parsing;

public class BBoxTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BBox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
            Confidence = 0,
            EndIndex = 0,
            Label = "label",
            R = 0,
            StartIndex = 0,
        };

        double expectedH = 0;
        double expectedW = 0;
        double expectedX = 0;
        double expectedY = 0;
        double expectedConfidence = 0;
        long expectedEndIndex = 0;
        string expectedLabel = "label";
        double expectedR = 0;
        long expectedStartIndex = 0;

        Assert.Equal(expectedH, model.H);
        Assert.Equal(expectedW, model.W);
        Assert.Equal(expectedX, model.X);
        Assert.Equal(expectedY, model.Y);
        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedEndIndex, model.EndIndex);
        Assert.Equal(expectedLabel, model.Label);
        Assert.Equal(expectedR, model.R);
        Assert.Equal(expectedStartIndex, model.StartIndex);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BBox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
            Confidence = 0,
            EndIndex = 0,
            Label = "label",
            R = 0,
            StartIndex = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BBox>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BBox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
            Confidence = 0,
            EndIndex = 0,
            Label = "label",
            R = 0,
            StartIndex = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BBox>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedH = 0;
        double expectedW = 0;
        double expectedX = 0;
        double expectedY = 0;
        double expectedConfidence = 0;
        long expectedEndIndex = 0;
        string expectedLabel = "label";
        double expectedR = 0;
        long expectedStartIndex = 0;

        Assert.Equal(expectedH, deserialized.H);
        Assert.Equal(expectedW, deserialized.W);
        Assert.Equal(expectedX, deserialized.X);
        Assert.Equal(expectedY, deserialized.Y);
        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedEndIndex, deserialized.EndIndex);
        Assert.Equal(expectedLabel, deserialized.Label);
        Assert.Equal(expectedR, deserialized.R);
        Assert.Equal(expectedStartIndex, deserialized.StartIndex);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BBox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
            Confidence = 0,
            EndIndex = 0,
            Label = "label",
            R = 0,
            StartIndex = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BBox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.EndIndex);
        Assert.False(model.RawData.ContainsKey("end_index"));
        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
        Assert.Null(model.R);
        Assert.False(model.RawData.ContainsKey("r"));
        Assert.Null(model.StartIndex);
        Assert.False(model.RawData.ContainsKey("start_index"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BBox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BBox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,

            Confidence = null,
            EndIndex = null,
            Label = null,
            R = null,
            StartIndex = null,
        };

        Assert.Null(model.Confidence);
        Assert.True(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.EndIndex);
        Assert.True(model.RawData.ContainsKey("end_index"));
        Assert.Null(model.Label);
        Assert.True(model.RawData.ContainsKey("label"));
        Assert.Null(model.R);
        Assert.True(model.RawData.ContainsKey("r"));
        Assert.Null(model.StartIndex);
        Assert.True(model.RawData.ContainsKey("start_index"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BBox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,

            Confidence = null,
            EndIndex = null,
            Label = null,
            R = null,
            StartIndex = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BBox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
            Confidence = 0,
            EndIndex = 0,
            Label = "label",
            R = 0,
            StartIndex = 0,
        };

        BBox copied = new(model);

        Assert.Equal(model, copied);
    }
}
