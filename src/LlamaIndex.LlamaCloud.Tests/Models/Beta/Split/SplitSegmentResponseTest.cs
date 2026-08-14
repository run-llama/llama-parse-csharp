using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.Split;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.Split;

public class SplitSegmentResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitSegmentResponse
        {
            Category = "category",
            ConfidenceCategory = "confidence_category",
            Pages = [0],
        };

        string expectedCategory = "category";
        string expectedConfidenceCategory = "confidence_category";
        List<long> expectedPages = [0];

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedConfidenceCategory, model.ConfidenceCategory);
        Assert.Equal(expectedPages.Count, model.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], model.Pages[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SplitSegmentResponse
        {
            Category = "category",
            ConfidenceCategory = "confidence_category",
            Pages = [0],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitSegmentResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitSegmentResponse
        {
            Category = "category",
            ConfidenceCategory = "confidence_category",
            Pages = [0],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitSegmentResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCategory = "category";
        string expectedConfidenceCategory = "confidence_category";
        List<long> expectedPages = [0];

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedConfidenceCategory, deserialized.ConfidenceCategory);
        Assert.Equal(expectedPages.Count, deserialized.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], deserialized.Pages[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SplitSegmentResponse
        {
            Category = "category",
            ConfidenceCategory = "confidence_category",
            Pages = [0],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SplitSegmentResponse
        {
            Category = "category",
            ConfidenceCategory = "confidence_category",
            Pages = [0],
        };

        SplitSegmentResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
