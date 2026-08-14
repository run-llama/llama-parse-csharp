using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines;
using LlamaIndex.LlamaCloud.Models.Pipelines.Documents;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines;

public class PipelineRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PipelineRetrieveResponse
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrievalNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    ClassName = "class_name",
                    Score = 0,
                },
            ],
            ClassName = "class_name",
            ImageNodes =
            [
                new()
                {
                    Node = new()
                    {
                        FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ImageSize = 0,
                        PageIndex = 0,
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    },
                    Score = 0,
                    ClassName = "class_name",
                },
            ],
            InferredSearchFilters = new()
            {
                Filters =
                [
                    new MetadataFilter()
                    {
                        Key = "key",
                        Value = 0,
                        Operator = Operator.Undefined,
                    },
                ],
                Condition = Condition.And,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PageFigureNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    Score = 0,
                    ClassName = "class_name",
                },
            ],
            RetrievalLatency = new Dictionary<string, double>() { { "foo", 0 } },
        };

        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<RetrievalNode> expectedRetrievalNodes =
        [
            new()
            {
                Node = new()
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
                },
                ClassName = "class_name",
                Score = 0,
            },
        ];
        string expectedClassName = "class_name";
        List<PageScreenshotNodeWithScore> expectedImageNodes =
        [
            new()
            {
                Node = new()
                {
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ImageSize = 0,
                    PageIndex = 0,
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
                Score = 0,
                ClassName = "class_name",
            },
        ];
        MetadataFilters expectedInferredSearchFilters = new()
        {
            Filters =
            [
                new MetadataFilter()
                {
                    Key = "key",
                    Value = 0,
                    Operator = Operator.Undefined,
                },
            ],
            Condition = Condition.And,
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        List<PageFigureNodeWithScore> expectedPageFigureNodes =
        [
            new()
            {
                Node = new()
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
                },
                Score = 0,
                ClassName = "class_name",
            },
        ];
        Dictionary<string, double> expectedRetrievalLatency = new() { { "foo", 0 } };

        Assert.Equal(expectedPipelineID, model.PipelineID);
        Assert.Equal(expectedRetrievalNodes.Count, model.RetrievalNodes.Count);
        for (int i = 0; i < expectedRetrievalNodes.Count; i++)
        {
            Assert.Equal(expectedRetrievalNodes[i], model.RetrievalNodes[i]);
        }
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.NotNull(model.ImageNodes);
        Assert.Equal(expectedImageNodes.Count, model.ImageNodes.Count);
        for (int i = 0; i < expectedImageNodes.Count; i++)
        {
            Assert.Equal(expectedImageNodes[i], model.ImageNodes[i]);
        }
        Assert.Equal(expectedInferredSearchFilters, model.InferredSearchFilters);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.NotNull(model.PageFigureNodes);
        Assert.Equal(expectedPageFigureNodes.Count, model.PageFigureNodes.Count);
        for (int i = 0; i < expectedPageFigureNodes.Count; i++)
        {
            Assert.Equal(expectedPageFigureNodes[i], model.PageFigureNodes[i]);
        }
        Assert.NotNull(model.RetrievalLatency);
        Assert.Equal(expectedRetrievalLatency.Count, model.RetrievalLatency.Count);
        foreach (var item in expectedRetrievalLatency)
        {
            Assert.True(model.RetrievalLatency.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.RetrievalLatency[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PipelineRetrieveResponse
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrievalNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    ClassName = "class_name",
                    Score = 0,
                },
            ],
            ClassName = "class_name",
            ImageNodes =
            [
                new()
                {
                    Node = new()
                    {
                        FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ImageSize = 0,
                        PageIndex = 0,
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    },
                    Score = 0,
                    ClassName = "class_name",
                },
            ],
            InferredSearchFilters = new()
            {
                Filters =
                [
                    new MetadataFilter()
                    {
                        Key = "key",
                        Value = 0,
                        Operator = Operator.Undefined,
                    },
                ],
                Condition = Condition.And,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PageFigureNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    Score = 0,
                    ClassName = "class_name",
                },
            ],
            RetrievalLatency = new Dictionary<string, double>() { { "foo", 0 } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PipelineRetrieveResponse
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrievalNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    ClassName = "class_name",
                    Score = 0,
                },
            ],
            ClassName = "class_name",
            ImageNodes =
            [
                new()
                {
                    Node = new()
                    {
                        FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ImageSize = 0,
                        PageIndex = 0,
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    },
                    Score = 0,
                    ClassName = "class_name",
                },
            ],
            InferredSearchFilters = new()
            {
                Filters =
                [
                    new MetadataFilter()
                    {
                        Key = "key",
                        Value = 0,
                        Operator = Operator.Undefined,
                    },
                ],
                Condition = Condition.And,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PageFigureNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    Score = 0,
                    ClassName = "class_name",
                },
            ],
            RetrievalLatency = new Dictionary<string, double>() { { "foo", 0 } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<RetrievalNode> expectedRetrievalNodes =
        [
            new()
            {
                Node = new()
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
                },
                ClassName = "class_name",
                Score = 0,
            },
        ];
        string expectedClassName = "class_name";
        List<PageScreenshotNodeWithScore> expectedImageNodes =
        [
            new()
            {
                Node = new()
                {
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ImageSize = 0,
                    PageIndex = 0,
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
                Score = 0,
                ClassName = "class_name",
            },
        ];
        MetadataFilters expectedInferredSearchFilters = new()
        {
            Filters =
            [
                new MetadataFilter()
                {
                    Key = "key",
                    Value = 0,
                    Operator = Operator.Undefined,
                },
            ],
            Condition = Condition.And,
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        List<PageFigureNodeWithScore> expectedPageFigureNodes =
        [
            new()
            {
                Node = new()
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
                },
                Score = 0,
                ClassName = "class_name",
            },
        ];
        Dictionary<string, double> expectedRetrievalLatency = new() { { "foo", 0 } };

        Assert.Equal(expectedPipelineID, deserialized.PipelineID);
        Assert.Equal(expectedRetrievalNodes.Count, deserialized.RetrievalNodes.Count);
        for (int i = 0; i < expectedRetrievalNodes.Count; i++)
        {
            Assert.Equal(expectedRetrievalNodes[i], deserialized.RetrievalNodes[i]);
        }
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.NotNull(deserialized.ImageNodes);
        Assert.Equal(expectedImageNodes.Count, deserialized.ImageNodes.Count);
        for (int i = 0; i < expectedImageNodes.Count; i++)
        {
            Assert.Equal(expectedImageNodes[i], deserialized.ImageNodes[i]);
        }
        Assert.Equal(expectedInferredSearchFilters, deserialized.InferredSearchFilters);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.NotNull(deserialized.PageFigureNodes);
        Assert.Equal(expectedPageFigureNodes.Count, deserialized.PageFigureNodes.Count);
        for (int i = 0; i < expectedPageFigureNodes.Count; i++)
        {
            Assert.Equal(expectedPageFigureNodes[i], deserialized.PageFigureNodes[i]);
        }
        Assert.NotNull(deserialized.RetrievalLatency);
        Assert.Equal(expectedRetrievalLatency.Count, deserialized.RetrievalLatency.Count);
        foreach (var item in expectedRetrievalLatency)
        {
            Assert.True(deserialized.RetrievalLatency.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.RetrievalLatency[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PipelineRetrieveResponse
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrievalNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    ClassName = "class_name",
                    Score = 0,
                },
            ],
            ClassName = "class_name",
            ImageNodes =
            [
                new()
                {
                    Node = new()
                    {
                        FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ImageSize = 0,
                        PageIndex = 0,
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    },
                    Score = 0,
                    ClassName = "class_name",
                },
            ],
            InferredSearchFilters = new()
            {
                Filters =
                [
                    new MetadataFilter()
                    {
                        Key = "key",
                        Value = 0,
                        Operator = Operator.Undefined,
                    },
                ],
                Condition = Condition.And,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PageFigureNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    Score = 0,
                    ClassName = "class_name",
                },
            ],
            RetrievalLatency = new Dictionary<string, double>() { { "foo", 0 } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PipelineRetrieveResponse
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrievalNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    ClassName = "class_name",
                    Score = 0,
                },
            ],
            InferredSearchFilters = new()
            {
                Filters =
                [
                    new MetadataFilter()
                    {
                        Key = "key",
                        Value = 0,
                        Operator = Operator.Undefined,
                    },
                ],
                Condition = Condition.And,
            },
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.ImageNodes);
        Assert.False(model.RawData.ContainsKey("image_nodes"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PageFigureNodes);
        Assert.False(model.RawData.ContainsKey("page_figure_nodes"));
        Assert.Null(model.RetrievalLatency);
        Assert.False(model.RawData.ContainsKey("retrieval_latency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PipelineRetrieveResponse
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrievalNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    ClassName = "class_name",
                    Score = 0,
                },
            ],
            InferredSearchFilters = new()
            {
                Filters =
                [
                    new MetadataFilter()
                    {
                        Key = "key",
                        Value = 0,
                        Operator = Operator.Undefined,
                    },
                ],
                Condition = Condition.And,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PipelineRetrieveResponse
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrievalNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    ClassName = "class_name",
                    Score = 0,
                },
            ],
            InferredSearchFilters = new()
            {
                Filters =
                [
                    new MetadataFilter()
                    {
                        Key = "key",
                        Value = 0,
                        Operator = Operator.Undefined,
                    },
                ],
                Condition = Condition.And,
            },

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            ImageNodes = null,
            Metadata = null,
            PageFigureNodes = null,
            RetrievalLatency = null,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.ImageNodes);
        Assert.False(model.RawData.ContainsKey("image_nodes"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PageFigureNodes);
        Assert.False(model.RawData.ContainsKey("page_figure_nodes"));
        Assert.Null(model.RetrievalLatency);
        Assert.False(model.RawData.ContainsKey("retrieval_latency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PipelineRetrieveResponse
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrievalNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    ClassName = "class_name",
                    Score = 0,
                },
            ],
            InferredSearchFilters = new()
            {
                Filters =
                [
                    new MetadataFilter()
                    {
                        Key = "key",
                        Value = 0,
                        Operator = Operator.Undefined,
                    },
                ],
                Condition = Condition.And,
            },

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            ImageNodes = null,
            Metadata = null,
            PageFigureNodes = null,
            RetrievalLatency = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PipelineRetrieveResponse
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrievalNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    ClassName = "class_name",
                    Score = 0,
                },
            ],
            ClassName = "class_name",
            ImageNodes =
            [
                new()
                {
                    Node = new()
                    {
                        FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ImageSize = 0,
                        PageIndex = 0,
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    },
                    Score = 0,
                    ClassName = "class_name",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PageFigureNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    Score = 0,
                    ClassName = "class_name",
                },
            ],
            RetrievalLatency = new Dictionary<string, double>() { { "foo", 0 } },
        };

        Assert.Null(model.InferredSearchFilters);
        Assert.False(model.RawData.ContainsKey("inferred_search_filters"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PipelineRetrieveResponse
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrievalNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    ClassName = "class_name",
                    Score = 0,
                },
            ],
            ClassName = "class_name",
            ImageNodes =
            [
                new()
                {
                    Node = new()
                    {
                        FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ImageSize = 0,
                        PageIndex = 0,
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    },
                    Score = 0,
                    ClassName = "class_name",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PageFigureNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    Score = 0,
                    ClassName = "class_name",
                },
            ],
            RetrievalLatency = new Dictionary<string, double>() { { "foo", 0 } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PipelineRetrieveResponse
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrievalNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    ClassName = "class_name",
                    Score = 0,
                },
            ],
            ClassName = "class_name",
            ImageNodes =
            [
                new()
                {
                    Node = new()
                    {
                        FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ImageSize = 0,
                        PageIndex = 0,
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    },
                    Score = 0,
                    ClassName = "class_name",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PageFigureNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    Score = 0,
                    ClassName = "class_name",
                },
            ],
            RetrievalLatency = new Dictionary<string, double>() { { "foo", 0 } },

            InferredSearchFilters = null,
        };

        Assert.Null(model.InferredSearchFilters);
        Assert.True(model.RawData.ContainsKey("inferred_search_filters"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PipelineRetrieveResponse
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrievalNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    ClassName = "class_name",
                    Score = 0,
                },
            ],
            ClassName = "class_name",
            ImageNodes =
            [
                new()
                {
                    Node = new()
                    {
                        FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ImageSize = 0,
                        PageIndex = 0,
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    },
                    Score = 0,
                    ClassName = "class_name",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PageFigureNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    Score = 0,
                    ClassName = "class_name",
                },
            ],
            RetrievalLatency = new Dictionary<string, double>() { { "foo", 0 } },

            InferredSearchFilters = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PipelineRetrieveResponse
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrievalNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    ClassName = "class_name",
                    Score = 0,
                },
            ],
            ClassName = "class_name",
            ImageNodes =
            [
                new()
                {
                    Node = new()
                    {
                        FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ImageSize = 0,
                        PageIndex = 0,
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    },
                    Score = 0,
                    ClassName = "class_name",
                },
            ],
            InferredSearchFilters = new()
            {
                Filters =
                [
                    new MetadataFilter()
                    {
                        Key = "key",
                        Value = 0,
                        Operator = Operator.Undefined,
                    },
                ],
                Condition = Condition.And,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PageFigureNodes =
            [
                new()
                {
                    Node = new()
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
                    },
                    Score = 0,
                    ClassName = "class_name",
                },
            ],
            RetrievalLatency = new Dictionary<string, double>() { { "foo", 0 } },
        };

        PipelineRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RetrievalNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RetrievalNode
        {
            Node = new()
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
            },
            ClassName = "class_name",
            Score = 0,
        };

        TextNode expectedNode = new()
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
        double expectedScore = 0;

        Assert.Equal(expectedNode, model.Node);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedScore, model.Score);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RetrievalNode
        {
            Node = new()
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
            },
            ClassName = "class_name",
            Score = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetrievalNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RetrievalNode
        {
            Node = new()
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
            },
            ClassName = "class_name",
            Score = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetrievalNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        TextNode expectedNode = new()
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
        double expectedScore = 0;

        Assert.Equal(expectedNode, deserialized.Node);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedScore, deserialized.Score);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RetrievalNode
        {
            Node = new()
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
            },
            ClassName = "class_name",
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RetrievalNode
        {
            Node = new()
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
            },
            Score = 0,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RetrievalNode
        {
            Node = new()
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
            },
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RetrievalNode
        {
            Node = new()
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
            },
            Score = 0,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RetrievalNode
        {
            Node = new()
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
            },
            Score = 0,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RetrievalNode
        {
            Node = new()
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
            },
            ClassName = "class_name",
        };

        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RetrievalNode
        {
            Node = new()
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
            },
            ClassName = "class_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RetrievalNode
        {
            Node = new()
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
            },
            ClassName = "class_name",

            Score = null,
        };

        Assert.Null(model.Score);
        Assert.True(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RetrievalNode
        {
            Node = new()
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
            },
            ClassName = "class_name",

            Score = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RetrievalNode
        {
            Node = new()
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
            },
            ClassName = "class_name",
            Score = 0,
        };

        RetrievalNode copied = new(model);

        Assert.Equal(model, copied);
    }
}
