using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines.Documents;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines.Documents;

public class CloudDocumentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudDocument
        {
            ID = "id",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
            PagePositions = [0],
            StatusMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedText = "text";
        List<string> expectedExcludedEmbedMetadataKeys = ["string"];
        List<string> expectedExcludedLlmMetadataKeys = ["string"];
        List<long> expectedPagePositions = [0];
        Dictionary<string, JsonElement> expectedStatusMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Metadata[item.Key]));
        }
        Assert.Equal(expectedText, model.Text);
        Assert.NotNull(model.ExcludedEmbedMetadataKeys);
        Assert.Equal(
            expectedExcludedEmbedMetadataKeys.Count,
            model.ExcludedEmbedMetadataKeys.Count
        );
        for (int i = 0; i < expectedExcludedEmbedMetadataKeys.Count; i++)
        {
            Assert.Equal(expectedExcludedEmbedMetadataKeys[i], model.ExcludedEmbedMetadataKeys[i]);
        }
        Assert.NotNull(model.ExcludedLlmMetadataKeys);
        Assert.Equal(expectedExcludedLlmMetadataKeys.Count, model.ExcludedLlmMetadataKeys.Count);
        for (int i = 0; i < expectedExcludedLlmMetadataKeys.Count; i++)
        {
            Assert.Equal(expectedExcludedLlmMetadataKeys[i], model.ExcludedLlmMetadataKeys[i]);
        }
        Assert.NotNull(model.PagePositions);
        Assert.Equal(expectedPagePositions.Count, model.PagePositions.Count);
        for (int i = 0; i < expectedPagePositions.Count; i++)
        {
            Assert.Equal(expectedPagePositions[i], model.PagePositions[i]);
        }
        Assert.NotNull(model.StatusMetadata);
        Assert.Equal(expectedStatusMetadata.Count, model.StatusMetadata.Count);
        foreach (var item in expectedStatusMetadata)
        {
            Assert.True(model.StatusMetadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.StatusMetadata[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudDocument
        {
            ID = "id",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
            PagePositions = [0],
            StatusMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudDocument>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudDocument
        {
            ID = "id",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
            PagePositions = [0],
            StatusMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudDocument>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedText = "text";
        List<string> expectedExcludedEmbedMetadataKeys = ["string"];
        List<string> expectedExcludedLlmMetadataKeys = ["string"];
        List<long> expectedPagePositions = [0];
        Dictionary<string, JsonElement> expectedStatusMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Metadata[item.Key]));
        }
        Assert.Equal(expectedText, deserialized.Text);
        Assert.NotNull(deserialized.ExcludedEmbedMetadataKeys);
        Assert.Equal(
            expectedExcludedEmbedMetadataKeys.Count,
            deserialized.ExcludedEmbedMetadataKeys.Count
        );
        for (int i = 0; i < expectedExcludedEmbedMetadataKeys.Count; i++)
        {
            Assert.Equal(
                expectedExcludedEmbedMetadataKeys[i],
                deserialized.ExcludedEmbedMetadataKeys[i]
            );
        }
        Assert.NotNull(deserialized.ExcludedLlmMetadataKeys);
        Assert.Equal(
            expectedExcludedLlmMetadataKeys.Count,
            deserialized.ExcludedLlmMetadataKeys.Count
        );
        for (int i = 0; i < expectedExcludedLlmMetadataKeys.Count; i++)
        {
            Assert.Equal(
                expectedExcludedLlmMetadataKeys[i],
                deserialized.ExcludedLlmMetadataKeys[i]
            );
        }
        Assert.NotNull(deserialized.PagePositions);
        Assert.Equal(expectedPagePositions.Count, deserialized.PagePositions.Count);
        for (int i = 0; i < expectedPagePositions.Count; i++)
        {
            Assert.Equal(expectedPagePositions[i], deserialized.PagePositions[i]);
        }
        Assert.NotNull(deserialized.StatusMetadata);
        Assert.Equal(expectedStatusMetadata.Count, deserialized.StatusMetadata.Count);
        foreach (var item in expectedStatusMetadata)
        {
            Assert.True(deserialized.StatusMetadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.StatusMetadata[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudDocument
        {
            ID = "id",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
            PagePositions = [0],
            StatusMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudDocument
        {
            ID = "id",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            PagePositions = [0],
            StatusMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Null(model.ExcludedEmbedMetadataKeys);
        Assert.False(model.RawData.ContainsKey("excluded_embed_metadata_keys"));
        Assert.Null(model.ExcludedLlmMetadataKeys);
        Assert.False(model.RawData.ContainsKey("excluded_llm_metadata_keys"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudDocument
        {
            ID = "id",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            PagePositions = [0],
            StatusMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudDocument
        {
            ID = "id",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            PagePositions = [0],
            StatusMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            // Null should be interpreted as omitted for these properties
            ExcludedEmbedMetadataKeys = null,
            ExcludedLlmMetadataKeys = null,
        };

        Assert.Null(model.ExcludedEmbedMetadataKeys);
        Assert.False(model.RawData.ContainsKey("excluded_embed_metadata_keys"));
        Assert.Null(model.ExcludedLlmMetadataKeys);
        Assert.False(model.RawData.ContainsKey("excluded_llm_metadata_keys"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudDocument
        {
            ID = "id",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            PagePositions = [0],
            StatusMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            // Null should be interpreted as omitted for these properties
            ExcludedEmbedMetadataKeys = null,
            ExcludedLlmMetadataKeys = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudDocument
        {
            ID = "id",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
        };

        Assert.Null(model.PagePositions);
        Assert.False(model.RawData.ContainsKey("page_positions"));
        Assert.Null(model.StatusMetadata);
        Assert.False(model.RawData.ContainsKey("status_metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudDocument
        {
            ID = "id",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CloudDocument
        {
            ID = "id",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],

            PagePositions = null,
            StatusMetadata = null,
        };

        Assert.Null(model.PagePositions);
        Assert.True(model.RawData.ContainsKey("page_positions"));
        Assert.Null(model.StatusMetadata);
        Assert.True(model.RawData.ContainsKey("status_metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudDocument
        {
            ID = "id",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],

            PagePositions = null,
            StatusMetadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudDocument
        {
            ID = "id",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
            PagePositions = [0],
            StatusMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        CloudDocument copied = new(model);

        Assert.Equal(model, copied);
    }
}
