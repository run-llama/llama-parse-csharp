using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Pipelines.Documents;

namespace LlamaCloud.Tests.Models.Pipelines.Documents;

public class DocumentListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DocumentListPageResponse
        {
            Documents =
            [
                new()
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
                },
            ],
            Limit = 0,
            Offset = 0,
            TotalCount = 0,
        };

        List<CloudDocument> expectedDocuments =
        [
            new()
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
            },
        ];
        long expectedLimit = 0;
        long expectedOffset = 0;
        long expectedTotalCount = 0;

        Assert.Equal(expectedDocuments.Count, model.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], model.Documents[i]);
        }
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedOffset, model.Offset);
        Assert.Equal(expectedTotalCount, model.TotalCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DocumentListPageResponse
        {
            Documents =
            [
                new()
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
                },
            ],
            Limit = 0,
            Offset = 0,
            TotalCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DocumentListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DocumentListPageResponse
        {
            Documents =
            [
                new()
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
                },
            ],
            Limit = 0,
            Offset = 0,
            TotalCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DocumentListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CloudDocument> expectedDocuments =
        [
            new()
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
            },
        ];
        long expectedLimit = 0;
        long expectedOffset = 0;
        long expectedTotalCount = 0;

        Assert.Equal(expectedDocuments.Count, deserialized.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], deserialized.Documents[i]);
        }
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedOffset, deserialized.Offset);
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DocumentListPageResponse
        {
            Documents =
            [
                new()
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
                },
            ],
            Limit = 0,
            Offset = 0,
            TotalCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DocumentListPageResponse
        {
            Documents =
            [
                new()
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
                },
            ],
            Limit = 0,
            Offset = 0,
            TotalCount = 0,
        };

        DocumentListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
