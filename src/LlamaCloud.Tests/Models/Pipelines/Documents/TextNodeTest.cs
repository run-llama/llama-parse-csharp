using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Pipelines.Documents;

namespace LlamaCloud.Tests.Models.Pipelines.Documents;

public class TextNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TextNode
        {
            ClassName = "class_name",
            Embedding = [0],
            EndCharIdx = 0,
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
            ExtraInfo = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ID = "id_",
            MetadataSeperator = "metadata_seperator",
            MetadataTemplate = "metadata_template",
            Mimetype = "mimetype",
            Relationships = new Dictionary<string, Relationship>()
            {
                {
                    "foo",
                    new RelatedNodeInfo()
                    {
                        NodeID = "node_id",
                        ClassName = "class_name",
                        Hash = "hash",
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        NodeType = NodeType.V1,
                    }
                },
            },
            StartCharIdx = 0,
            Text = "text",
            TextTemplate = "text_template",
        };

        string expectedClassName = "class_name";
        List<double> expectedEmbedding = [0];
        long expectedEndCharIdx = 0;
        List<string> expectedExcludedEmbedMetadataKeys = ["string"];
        List<string> expectedExcludedLlmMetadataKeys = ["string"];
        Dictionary<string, JsonElement> expectedExtraInfo = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedID = "id_";
        string expectedMetadataSeperator = "metadata_seperator";
        string expectedMetadataTemplate = "metadata_template";
        string expectedMimetype = "mimetype";
        Dictionary<string, Relationship> expectedRelationships = new()
        {
            {
                "foo",
                new RelatedNodeInfo()
                {
                    NodeID = "node_id",
                    ClassName = "class_name",
                    Hash = "hash",
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    NodeType = NodeType.V1,
                }
            },
        };
        long expectedStartCharIdx = 0;
        string expectedText = "text";
        string expectedTextTemplate = "text_template";

        Assert.Equal(expectedClassName, model.ClassName);
        Assert.NotNull(model.Embedding);
        Assert.Equal(expectedEmbedding.Count, model.Embedding.Count);
        for (int i = 0; i < expectedEmbedding.Count; i++)
        {
            Assert.Equal(expectedEmbedding[i], model.Embedding[i]);
        }
        Assert.Equal(expectedEndCharIdx, model.EndCharIdx);
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
        Assert.NotNull(model.ExtraInfo);
        Assert.Equal(expectedExtraInfo.Count, model.ExtraInfo.Count);
        foreach (var item in expectedExtraInfo)
        {
            Assert.True(model.ExtraInfo.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.ExtraInfo[item.Key]));
        }
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedMetadataSeperator, model.MetadataSeperator);
        Assert.Equal(expectedMetadataTemplate, model.MetadataTemplate);
        Assert.Equal(expectedMimetype, model.Mimetype);
        Assert.NotNull(model.Relationships);
        Assert.Equal(expectedRelationships.Count, model.Relationships.Count);
        foreach (var item in expectedRelationships)
        {
            Assert.True(model.Relationships.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Relationships[item.Key]);
        }
        Assert.Equal(expectedStartCharIdx, model.StartCharIdx);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedTextTemplate, model.TextTemplate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TextNode
        {
            ClassName = "class_name",
            Embedding = [0],
            EndCharIdx = 0,
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
            ExtraInfo = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ID = "id_",
            MetadataSeperator = "metadata_seperator",
            MetadataTemplate = "metadata_template",
            Mimetype = "mimetype",
            Relationships = new Dictionary<string, Relationship>()
            {
                {
                    "foo",
                    new RelatedNodeInfo()
                    {
                        NodeID = "node_id",
                        ClassName = "class_name",
                        Hash = "hash",
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        NodeType = NodeType.V1,
                    }
                },
            },
            StartCharIdx = 0,
            Text = "text",
            TextTemplate = "text_template",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextNode>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TextNode
        {
            ClassName = "class_name",
            Embedding = [0],
            EndCharIdx = 0,
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
            ExtraInfo = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ID = "id_",
            MetadataSeperator = "metadata_seperator",
            MetadataTemplate = "metadata_template",
            Mimetype = "mimetype",
            Relationships = new Dictionary<string, Relationship>()
            {
                {
                    "foo",
                    new RelatedNodeInfo()
                    {
                        NodeID = "node_id",
                        ClassName = "class_name",
                        Hash = "hash",
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        NodeType = NodeType.V1,
                    }
                },
            },
            StartCharIdx = 0,
            Text = "text",
            TextTemplate = "text_template",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClassName = "class_name";
        List<double> expectedEmbedding = [0];
        long expectedEndCharIdx = 0;
        List<string> expectedExcludedEmbedMetadataKeys = ["string"];
        List<string> expectedExcludedLlmMetadataKeys = ["string"];
        Dictionary<string, JsonElement> expectedExtraInfo = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedID = "id_";
        string expectedMetadataSeperator = "metadata_seperator";
        string expectedMetadataTemplate = "metadata_template";
        string expectedMimetype = "mimetype";
        Dictionary<string, Relationship> expectedRelationships = new()
        {
            {
                "foo",
                new RelatedNodeInfo()
                {
                    NodeID = "node_id",
                    ClassName = "class_name",
                    Hash = "hash",
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    NodeType = NodeType.V1,
                }
            },
        };
        long expectedStartCharIdx = 0;
        string expectedText = "text";
        string expectedTextTemplate = "text_template";

        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.NotNull(deserialized.Embedding);
        Assert.Equal(expectedEmbedding.Count, deserialized.Embedding.Count);
        for (int i = 0; i < expectedEmbedding.Count; i++)
        {
            Assert.Equal(expectedEmbedding[i], deserialized.Embedding[i]);
        }
        Assert.Equal(expectedEndCharIdx, deserialized.EndCharIdx);
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
        Assert.NotNull(deserialized.ExtraInfo);
        Assert.Equal(expectedExtraInfo.Count, deserialized.ExtraInfo.Count);
        foreach (var item in expectedExtraInfo)
        {
            Assert.True(deserialized.ExtraInfo.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.ExtraInfo[item.Key]));
        }
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedMetadataSeperator, deserialized.MetadataSeperator);
        Assert.Equal(expectedMetadataTemplate, deserialized.MetadataTemplate);
        Assert.Equal(expectedMimetype, deserialized.Mimetype);
        Assert.NotNull(deserialized.Relationships);
        Assert.Equal(expectedRelationships.Count, deserialized.Relationships.Count);
        foreach (var item in expectedRelationships)
        {
            Assert.True(deserialized.Relationships.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Relationships[item.Key]);
        }
        Assert.Equal(expectedStartCharIdx, deserialized.StartCharIdx);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedTextTemplate, deserialized.TextTemplate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TextNode
        {
            ClassName = "class_name",
            Embedding = [0],
            EndCharIdx = 0,
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
            ExtraInfo = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ID = "id_",
            MetadataSeperator = "metadata_seperator",
            MetadataTemplate = "metadata_template",
            Mimetype = "mimetype",
            Relationships = new Dictionary<string, Relationship>()
            {
                {
                    "foo",
                    new RelatedNodeInfo()
                    {
                        NodeID = "node_id",
                        ClassName = "class_name",
                        Hash = "hash",
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        NodeType = NodeType.V1,
                    }
                },
            },
            StartCharIdx = 0,
            Text = "text",
            TextTemplate = "text_template",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TextNode
        {
            Embedding = [0],
            EndCharIdx = 0,
            StartCharIdx = 0,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.ExcludedEmbedMetadataKeys);
        Assert.False(model.RawData.ContainsKey("excluded_embed_metadata_keys"));
        Assert.Null(model.ExcludedLlmMetadataKeys);
        Assert.False(model.RawData.ContainsKey("excluded_llm_metadata_keys"));
        Assert.Null(model.ExtraInfo);
        Assert.False(model.RawData.ContainsKey("extra_info"));
        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id_"));
        Assert.Null(model.MetadataSeperator);
        Assert.False(model.RawData.ContainsKey("metadata_seperator"));
        Assert.Null(model.MetadataTemplate);
        Assert.False(model.RawData.ContainsKey("metadata_template"));
        Assert.Null(model.Mimetype);
        Assert.False(model.RawData.ContainsKey("mimetype"));
        Assert.Null(model.Relationships);
        Assert.False(model.RawData.ContainsKey("relationships"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.TextTemplate);
        Assert.False(model.RawData.ContainsKey("text_template"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TextNode
        {
            Embedding = [0],
            EndCharIdx = 0,
            StartCharIdx = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TextNode
        {
            Embedding = [0],
            EndCharIdx = 0,
            StartCharIdx = 0,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            ExcludedEmbedMetadataKeys = null,
            ExcludedLlmMetadataKeys = null,
            ExtraInfo = null,
            ID = null,
            MetadataSeperator = null,
            MetadataTemplate = null,
            Mimetype = null,
            Relationships = null,
            Text = null,
            TextTemplate = null,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.ExcludedEmbedMetadataKeys);
        Assert.False(model.RawData.ContainsKey("excluded_embed_metadata_keys"));
        Assert.Null(model.ExcludedLlmMetadataKeys);
        Assert.False(model.RawData.ContainsKey("excluded_llm_metadata_keys"));
        Assert.Null(model.ExtraInfo);
        Assert.False(model.RawData.ContainsKey("extra_info"));
        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id_"));
        Assert.Null(model.MetadataSeperator);
        Assert.False(model.RawData.ContainsKey("metadata_seperator"));
        Assert.Null(model.MetadataTemplate);
        Assert.False(model.RawData.ContainsKey("metadata_template"));
        Assert.Null(model.Mimetype);
        Assert.False(model.RawData.ContainsKey("mimetype"));
        Assert.Null(model.Relationships);
        Assert.False(model.RawData.ContainsKey("relationships"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.TextTemplate);
        Assert.False(model.RawData.ContainsKey("text_template"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TextNode
        {
            Embedding = [0],
            EndCharIdx = 0,
            StartCharIdx = 0,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            ExcludedEmbedMetadataKeys = null,
            ExcludedLlmMetadataKeys = null,
            ExtraInfo = null,
            ID = null,
            MetadataSeperator = null,
            MetadataTemplate = null,
            Mimetype = null,
            Relationships = null,
            Text = null,
            TextTemplate = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TextNode
        {
            ClassName = "class_name",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
            ExtraInfo = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ID = "id_",
            MetadataSeperator = "metadata_seperator",
            MetadataTemplate = "metadata_template",
            Mimetype = "mimetype",
            Relationships = new Dictionary<string, Relationship>()
            {
                {
                    "foo",
                    new RelatedNodeInfo()
                    {
                        NodeID = "node_id",
                        ClassName = "class_name",
                        Hash = "hash",
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        NodeType = NodeType.V1,
                    }
                },
            },
            Text = "text",
            TextTemplate = "text_template",
        };

        Assert.Null(model.Embedding);
        Assert.False(model.RawData.ContainsKey("embedding"));
        Assert.Null(model.EndCharIdx);
        Assert.False(model.RawData.ContainsKey("end_char_idx"));
        Assert.Null(model.StartCharIdx);
        Assert.False(model.RawData.ContainsKey("start_char_idx"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TextNode
        {
            ClassName = "class_name",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
            ExtraInfo = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ID = "id_",
            MetadataSeperator = "metadata_seperator",
            MetadataTemplate = "metadata_template",
            Mimetype = "mimetype",
            Relationships = new Dictionary<string, Relationship>()
            {
                {
                    "foo",
                    new RelatedNodeInfo()
                    {
                        NodeID = "node_id",
                        ClassName = "class_name",
                        Hash = "hash",
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        NodeType = NodeType.V1,
                    }
                },
            },
            Text = "text",
            TextTemplate = "text_template",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TextNode
        {
            ClassName = "class_name",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
            ExtraInfo = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ID = "id_",
            MetadataSeperator = "metadata_seperator",
            MetadataTemplate = "metadata_template",
            Mimetype = "mimetype",
            Relationships = new Dictionary<string, Relationship>()
            {
                {
                    "foo",
                    new RelatedNodeInfo()
                    {
                        NodeID = "node_id",
                        ClassName = "class_name",
                        Hash = "hash",
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        NodeType = NodeType.V1,
                    }
                },
            },
            Text = "text",
            TextTemplate = "text_template",

            Embedding = null,
            EndCharIdx = null,
            StartCharIdx = null,
        };

        Assert.Null(model.Embedding);
        Assert.True(model.RawData.ContainsKey("embedding"));
        Assert.Null(model.EndCharIdx);
        Assert.True(model.RawData.ContainsKey("end_char_idx"));
        Assert.Null(model.StartCharIdx);
        Assert.True(model.RawData.ContainsKey("start_char_idx"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TextNode
        {
            ClassName = "class_name",
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
            ExtraInfo = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ID = "id_",
            MetadataSeperator = "metadata_seperator",
            MetadataTemplate = "metadata_template",
            Mimetype = "mimetype",
            Relationships = new Dictionary<string, Relationship>()
            {
                {
                    "foo",
                    new RelatedNodeInfo()
                    {
                        NodeID = "node_id",
                        ClassName = "class_name",
                        Hash = "hash",
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        NodeType = NodeType.V1,
                    }
                },
            },
            Text = "text",
            TextTemplate = "text_template",

            Embedding = null,
            EndCharIdx = null,
            StartCharIdx = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TextNode
        {
            ClassName = "class_name",
            Embedding = [0],
            EndCharIdx = 0,
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
            ExtraInfo = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ID = "id_",
            MetadataSeperator = "metadata_seperator",
            MetadataTemplate = "metadata_template",
            Mimetype = "mimetype",
            Relationships = new Dictionary<string, Relationship>()
            {
                {
                    "foo",
                    new RelatedNodeInfo()
                    {
                        NodeID = "node_id",
                        ClassName = "class_name",
                        Hash = "hash",
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        NodeType = NodeType.V1,
                    }
                },
            },
            StartCharIdx = 0,
            Text = "text",
            TextTemplate = "text_template",
        };

        TextNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RelationshipTest : TestBase
{
    [Fact]
    public void RelatedNodeInfoValidationWorks()
    {
        Relationship value = new RelatedNodeInfo()
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Hash = "hash",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            NodeType = NodeType.V1,
        };
        value.Validate();
    }

    [Fact]
    public void RelationshipRelatedNodeInfosValidationWorks()
    {
        Relationship value = new(
            [
                new RelationshipRelatedNodeInfo()
                {
                    NodeID = "node_id",
                    ClassName = "class_name",
                    Hash = "hash",
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    NodeType = RelationshipRelatedNodeInfoNodeType.V1,
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void RelatedNodeInfoSerializationRoundtripWorks()
    {
        Relationship value = new RelatedNodeInfo()
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Hash = "hash",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            NodeType = NodeType.V1,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Relationship>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RelationshipRelatedNodeInfosSerializationRoundtripWorks()
    {
        Relationship value = new(
            [
                new RelationshipRelatedNodeInfo()
                {
                    NodeID = "node_id",
                    ClassName = "class_name",
                    Hash = "hash",
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    NodeType = RelationshipRelatedNodeInfoNodeType.V1,
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Relationship>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RelatedNodeInfoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RelatedNodeInfo
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Hash = "hash",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            NodeType = NodeType.V1,
        };

        string expectedNodeID = "node_id";
        string expectedClassName = "class_name";
        string expectedHash = "hash";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, NodeType> expectedNodeType = NodeType.V1;

        Assert.Equal(expectedNodeID, model.NodeID);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedHash, model.Hash);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Metadata[item.Key]));
        }
        Assert.Equal(expectedNodeType, model.NodeType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RelatedNodeInfo
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Hash = "hash",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            NodeType = NodeType.V1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RelatedNodeInfo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RelatedNodeInfo
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Hash = "hash",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            NodeType = NodeType.V1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RelatedNodeInfo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNodeID = "node_id";
        string expectedClassName = "class_name";
        string expectedHash = "hash";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, NodeType> expectedNodeType = NodeType.V1;

        Assert.Equal(expectedNodeID, deserialized.NodeID);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedHash, deserialized.Hash);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Metadata[item.Key]));
        }
        Assert.Equal(expectedNodeType, deserialized.NodeType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RelatedNodeInfo
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Hash = "hash",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            NodeType = NodeType.V1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RelatedNodeInfo
        {
            NodeID = "node_id",
            Hash = "hash",
            NodeType = NodeType.V1,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RelatedNodeInfo
        {
            NodeID = "node_id",
            Hash = "hash",
            NodeType = NodeType.V1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RelatedNodeInfo
        {
            NodeID = "node_id",
            Hash = "hash",
            NodeType = NodeType.V1,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            Metadata = null,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RelatedNodeInfo
        {
            NodeID = "node_id",
            Hash = "hash",
            NodeType = NodeType.V1,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RelatedNodeInfo
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Null(model.Hash);
        Assert.False(model.RawData.ContainsKey("hash"));
        Assert.Null(model.NodeType);
        Assert.False(model.RawData.ContainsKey("node_type"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RelatedNodeInfo
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RelatedNodeInfo
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            Hash = null,
            NodeType = null,
        };

        Assert.Null(model.Hash);
        Assert.True(model.RawData.ContainsKey("hash"));
        Assert.Null(model.NodeType);
        Assert.True(model.RawData.ContainsKey("node_type"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RelatedNodeInfo
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            Hash = null,
            NodeType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RelatedNodeInfo
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Hash = "hash",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            NodeType = NodeType.V1,
        };

        RelatedNodeInfo copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NodeTypeTest : TestBase
{
    [Theory]
    [InlineData(NodeType.V1)]
    [InlineData(NodeType.V2)]
    [InlineData(NodeType.V3)]
    [InlineData(NodeType.V4)]
    [InlineData(NodeType.V5)]
    public void Validation_Works(NodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NodeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NodeType.V1)]
    [InlineData(NodeType.V2)]
    [InlineData(NodeType.V3)]
    [InlineData(NodeType.V4)]
    [InlineData(NodeType.V5)]
    public void SerializationRoundtrip_Works(NodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NodeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NodeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NodeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RelationshipRelatedNodeInfoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RelationshipRelatedNodeInfo
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Hash = "hash",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            NodeType = RelationshipRelatedNodeInfoNodeType.V1,
        };

        string expectedNodeID = "node_id";
        string expectedClassName = "class_name";
        string expectedHash = "hash";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, RelationshipRelatedNodeInfoNodeType> expectedNodeType =
            RelationshipRelatedNodeInfoNodeType.V1;

        Assert.Equal(expectedNodeID, model.NodeID);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedHash, model.Hash);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Metadata[item.Key]));
        }
        Assert.Equal(expectedNodeType, model.NodeType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RelationshipRelatedNodeInfo
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Hash = "hash",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            NodeType = RelationshipRelatedNodeInfoNodeType.V1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RelationshipRelatedNodeInfo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RelationshipRelatedNodeInfo
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Hash = "hash",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            NodeType = RelationshipRelatedNodeInfoNodeType.V1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RelationshipRelatedNodeInfo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNodeID = "node_id";
        string expectedClassName = "class_name";
        string expectedHash = "hash";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, RelationshipRelatedNodeInfoNodeType> expectedNodeType =
            RelationshipRelatedNodeInfoNodeType.V1;

        Assert.Equal(expectedNodeID, deserialized.NodeID);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedHash, deserialized.Hash);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Metadata[item.Key]));
        }
        Assert.Equal(expectedNodeType, deserialized.NodeType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RelationshipRelatedNodeInfo
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Hash = "hash",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            NodeType = RelationshipRelatedNodeInfoNodeType.V1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RelationshipRelatedNodeInfo
        {
            NodeID = "node_id",
            Hash = "hash",
            NodeType = RelationshipRelatedNodeInfoNodeType.V1,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RelationshipRelatedNodeInfo
        {
            NodeID = "node_id",
            Hash = "hash",
            NodeType = RelationshipRelatedNodeInfoNodeType.V1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RelationshipRelatedNodeInfo
        {
            NodeID = "node_id",
            Hash = "hash",
            NodeType = RelationshipRelatedNodeInfoNodeType.V1,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            Metadata = null,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RelationshipRelatedNodeInfo
        {
            NodeID = "node_id",
            Hash = "hash",
            NodeType = RelationshipRelatedNodeInfoNodeType.V1,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RelationshipRelatedNodeInfo
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Null(model.Hash);
        Assert.False(model.RawData.ContainsKey("hash"));
        Assert.Null(model.NodeType);
        Assert.False(model.RawData.ContainsKey("node_type"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RelationshipRelatedNodeInfo
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RelationshipRelatedNodeInfo
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            Hash = null,
            NodeType = null,
        };

        Assert.Null(model.Hash);
        Assert.True(model.RawData.ContainsKey("hash"));
        Assert.Null(model.NodeType);
        Assert.True(model.RawData.ContainsKey("node_type"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RelationshipRelatedNodeInfo
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            Hash = null,
            NodeType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RelationshipRelatedNodeInfo
        {
            NodeID = "node_id",
            ClassName = "class_name",
            Hash = "hash",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            NodeType = RelationshipRelatedNodeInfoNodeType.V1,
        };

        RelationshipRelatedNodeInfo copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RelationshipRelatedNodeInfoNodeTypeTest : TestBase
{
    [Theory]
    [InlineData(RelationshipRelatedNodeInfoNodeType.V1)]
    [InlineData(RelationshipRelatedNodeInfoNodeType.V2)]
    [InlineData(RelationshipRelatedNodeInfoNodeType.V3)]
    [InlineData(RelationshipRelatedNodeInfoNodeType.V4)]
    [InlineData(RelationshipRelatedNodeInfoNodeType.V5)]
    public void Validation_Works(RelationshipRelatedNodeInfoNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RelationshipRelatedNodeInfoNodeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RelationshipRelatedNodeInfoNodeType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RelationshipRelatedNodeInfoNodeType.V1)]
    [InlineData(RelationshipRelatedNodeInfoNodeType.V2)]
    [InlineData(RelationshipRelatedNodeInfoNodeType.V3)]
    [InlineData(RelationshipRelatedNodeInfoNodeType.V4)]
    [InlineData(RelationshipRelatedNodeInfoNodeType.V5)]
    public void SerializationRoundtrip_Works(RelationshipRelatedNodeInfoNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RelationshipRelatedNodeInfoNodeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RelationshipRelatedNodeInfoNodeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RelationshipRelatedNodeInfoNodeType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RelationshipRelatedNodeInfoNodeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
