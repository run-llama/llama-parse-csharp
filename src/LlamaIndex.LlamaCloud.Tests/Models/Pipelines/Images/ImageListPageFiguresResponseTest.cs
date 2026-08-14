using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines.Images;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines.Images;

public class ImageListPageFiguresResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageListPageFiguresResponse
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        double expectedConfidence = 0;
        string expectedFigureName = "figure_name";
        long expectedFigureSize = 0;
        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedPageIndex = 0;
        bool expectedIsLikelyNoise = true;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedFigureName, model.FigureName);
        Assert.Equal(expectedFigureSize, model.FigureSize);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedPageIndex, model.PageIndex);
        Assert.Equal(expectedIsLikelyNoise, model.IsLikelyNoise);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Metadata[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImageListPageFiguresResponse
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageListPageFiguresResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageListPageFiguresResponse
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageListPageFiguresResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedConfidence = 0;
        string expectedFigureName = "figure_name";
        long expectedFigureSize = 0;
        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedPageIndex = 0;
        bool expectedIsLikelyNoise = true;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedFigureName, deserialized.FigureName);
        Assert.Equal(expectedFigureSize, deserialized.FigureSize);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedPageIndex, deserialized.PageIndex);
        Assert.Equal(expectedIsLikelyNoise, deserialized.IsLikelyNoise);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Metadata[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImageListPageFiguresResponse
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ImageListPageFiguresResponse
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Null(model.IsLikelyNoise);
        Assert.False(model.RawData.ContainsKey("is_likely_noise"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ImageListPageFiguresResponse
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ImageListPageFiguresResponse
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            // Null should be interpreted as omitted for these properties
            IsLikelyNoise = null,
        };

        Assert.Null(model.IsLikelyNoise);
        Assert.False(model.RawData.ContainsKey("is_likely_noise"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ImageListPageFiguresResponse
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            // Null should be interpreted as omitted for these properties
            IsLikelyNoise = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ImageListPageFiguresResponse
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ImageListPageFiguresResponse
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ImageListPageFiguresResponse
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,

            Metadata = null,
        };

        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ImageListPageFiguresResponse
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,

            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ImageListPageFiguresResponse
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        ImageListPageFiguresResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
