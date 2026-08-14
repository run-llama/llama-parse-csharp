using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Beta.Split;

namespace LlamaCloud.Tests.Models.Beta.Split;

public class SplitResultResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitResultResponse
        {
            Segments =
            [
                new()
                {
                    Category = "category",
                    ConfidenceCategory = "confidence_category",
                    Pages = [0],
                },
            ],
        };

        List<SplitSegmentResponse> expectedSegments =
        [
            new()
            {
                Category = "category",
                ConfidenceCategory = "confidence_category",
                Pages = [0],
            },
        ];

        Assert.Equal(expectedSegments.Count, model.Segments.Count);
        for (int i = 0; i < expectedSegments.Count; i++)
        {
            Assert.Equal(expectedSegments[i], model.Segments[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SplitResultResponse
        {
            Segments =
            [
                new()
                {
                    Category = "category",
                    ConfidenceCategory = "confidence_category",
                    Pages = [0],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitResultResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitResultResponse
        {
            Segments =
            [
                new()
                {
                    Category = "category",
                    ConfidenceCategory = "confidence_category",
                    Pages = [0],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitResultResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<SplitSegmentResponse> expectedSegments =
        [
            new()
            {
                Category = "category",
                ConfidenceCategory = "confidence_category",
                Pages = [0],
            },
        ];

        Assert.Equal(expectedSegments.Count, deserialized.Segments.Count);
        for (int i = 0; i < expectedSegments.Count; i++)
        {
            Assert.Equal(expectedSegments[i], deserialized.Segments[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SplitResultResponse
        {
            Segments =
            [
                new()
                {
                    Category = "category",
                    ConfidenceCategory = "confidence_category",
                    Pages = [0],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SplitResultResponse
        {
            Segments =
            [
                new()
                {
                    Category = "category",
                    ConfidenceCategory = "confidence_category",
                    Pages = [0],
                },
            ],
        };

        SplitResultResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
