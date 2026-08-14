using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines.Documents;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines.Documents;

public class CloudDocumentCreateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudDocumentCreate
        {
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ID = "id",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
            PagePositions = [0],
        };

        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedText = "text";
        string expectedID = "id";
        List<string> expectedExcludedEmbedMetadataKeys = ["string"];
        List<string> expectedExcludedLlmMetadataKeys = ["string"];
        List<long> expectedPagePositions = [0];

        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Metadata[item.Key]));
        }
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedID, model.ID);
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudDocumentCreate
        {
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ID = "id",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
            PagePositions = [0],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudDocumentCreate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudDocumentCreate
        {
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ID = "id",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
            PagePositions = [0],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudDocumentCreate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedText = "text";
        string expectedID = "id";
        List<string> expectedExcludedEmbedMetadataKeys = ["string"];
        List<string> expectedExcludedLlmMetadataKeys = ["string"];
        List<long> expectedPagePositions = [0];

        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Metadata[item.Key]));
        }
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedID, deserialized.ID);
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudDocumentCreate
        {
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ID = "id",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
            PagePositions = [0],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudDocumentCreate
        {
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ID = "id",
            PagePositions = [0],
        };

        Assert.Null(model.ExcludedEmbedMetadataKeys);
        Assert.False(model.RawData.ContainsKey("excluded_embed_metadata_keys"));
        Assert.Null(model.ExcludedLlmMetadataKeys);
        Assert.False(model.RawData.ContainsKey("excluded_llm_metadata_keys"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudDocumentCreate
        {
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ID = "id",
            PagePositions = [0],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudDocumentCreate
        {
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ID = "id",
            PagePositions = [0],

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
        var model = new CloudDocumentCreate
        {
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ID = "id",
            PagePositions = [0],

            // Null should be interpreted as omitted for these properties
            ExcludedEmbedMetadataKeys = null,
            ExcludedLlmMetadataKeys = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudDocumentCreate
        {
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.PagePositions);
        Assert.False(model.RawData.ContainsKey("page_positions"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudDocumentCreate
        {
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
        var model = new CloudDocumentCreate
        {
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],

            ID = null,
            PagePositions = null,
        };

        Assert.Null(model.ID);
        Assert.True(model.RawData.ContainsKey("id"));
        Assert.Null(model.PagePositions);
        Assert.True(model.RawData.ContainsKey("page_positions"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudDocumentCreate
        {
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],

            ID = null,
            PagePositions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudDocumentCreate
        {
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Text = "text",
            ID = "id",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
            PagePositions = [0],
        };

        CloudDocumentCreate copied = new(model);

        Assert.Equal(model, copied);
    }
}
