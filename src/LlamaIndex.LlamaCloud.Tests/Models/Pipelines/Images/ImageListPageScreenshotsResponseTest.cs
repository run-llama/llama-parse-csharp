using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines.Images;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines.Images;

public class ImageListPageScreenshotsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageListPageScreenshotsResponse
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ImageSize = 0,
            PageIndex = 0,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedImageSize = 0;
        long expectedPageIndex = 0;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedImageSize, model.ImageSize);
        Assert.Equal(expectedPageIndex, model.PageIndex);
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
        var model = new ImageListPageScreenshotsResponse
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ImageSize = 0,
            PageIndex = 0,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageListPageScreenshotsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageListPageScreenshotsResponse
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ImageSize = 0,
            PageIndex = 0,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageListPageScreenshotsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedImageSize = 0;
        long expectedPageIndex = 0;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedImageSize, deserialized.ImageSize);
        Assert.Equal(expectedPageIndex, deserialized.PageIndex);
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
        var model = new ImageListPageScreenshotsResponse
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ImageSize = 0,
            PageIndex = 0,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ImageListPageScreenshotsResponse
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ImageSize = 0,
            PageIndex = 0,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ImageListPageScreenshotsResponse
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ImageSize = 0,
            PageIndex = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ImageListPageScreenshotsResponse
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ImageSize = 0,
            PageIndex = 0,

            Metadata = null,
        };

        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ImageListPageScreenshotsResponse
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ImageSize = 0,
            PageIndex = 0,

            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ImageListPageScreenshotsResponse
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ImageSize = 0,
            PageIndex = 0,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        ImageListPageScreenshotsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
