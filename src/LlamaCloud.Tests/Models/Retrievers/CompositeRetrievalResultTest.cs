using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Retrievers;
using Pipelines = LlamaCloud.Models.Pipelines;

namespace LlamaCloud.Tests.Models.Retrievers;

public class CompositeRetrievalResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositeRetrievalResult
        {
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
            Nodes =
            [
                new()
                {
                    NodeValue = new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        EndCharIdx = 0,
                        PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        RetrieverPipelineName = "retriever_pipeline_name",
                        StartCharIdx = 0,
                        Text = "text",
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    },
                    ClassName = "class_name",
                    Score = 0,
                },
            ],
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
        };

        List<Pipelines::PageScreenshotNodeWithScore> expectedImageNodes =
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
        List<Node> expectedNodes =
        [
            new()
            {
                NodeValue = new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    EndCharIdx = 0,
                    PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    RetrieverPipelineName = "retriever_pipeline_name",
                    StartCharIdx = 0,
                    Text = "text",
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
                ClassName = "class_name",
                Score = 0,
            },
        ];
        List<Pipelines::PageFigureNodeWithScore> expectedPageFigureNodes =
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

        Assert.NotNull(model.ImageNodes);
        Assert.Equal(expectedImageNodes.Count, model.ImageNodes.Count);
        for (int i = 0; i < expectedImageNodes.Count; i++)
        {
            Assert.Equal(expectedImageNodes[i], model.ImageNodes[i]);
        }
        Assert.NotNull(model.Nodes);
        Assert.Equal(expectedNodes.Count, model.Nodes.Count);
        for (int i = 0; i < expectedNodes.Count; i++)
        {
            Assert.Equal(expectedNodes[i], model.Nodes[i]);
        }
        Assert.NotNull(model.PageFigureNodes);
        Assert.Equal(expectedPageFigureNodes.Count, model.PageFigureNodes.Count);
        for (int i = 0; i < expectedPageFigureNodes.Count; i++)
        {
            Assert.Equal(expectedPageFigureNodes[i], model.PageFigureNodes[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CompositeRetrievalResult
        {
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
            Nodes =
            [
                new()
                {
                    NodeValue = new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        EndCharIdx = 0,
                        PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        RetrieverPipelineName = "retriever_pipeline_name",
                        StartCharIdx = 0,
                        Text = "text",
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    },
                    ClassName = "class_name",
                    Score = 0,
                },
            ],
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CompositeRetrievalResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CompositeRetrievalResult
        {
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
            Nodes =
            [
                new()
                {
                    NodeValue = new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        EndCharIdx = 0,
                        PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        RetrieverPipelineName = "retriever_pipeline_name",
                        StartCharIdx = 0,
                        Text = "text",
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    },
                    ClassName = "class_name",
                    Score = 0,
                },
            ],
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CompositeRetrievalResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Pipelines::PageScreenshotNodeWithScore> expectedImageNodes =
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
        List<Node> expectedNodes =
        [
            new()
            {
                NodeValue = new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    EndCharIdx = 0,
                    PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    RetrieverPipelineName = "retriever_pipeline_name",
                    StartCharIdx = 0,
                    Text = "text",
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
                ClassName = "class_name",
                Score = 0,
            },
        ];
        List<Pipelines::PageFigureNodeWithScore> expectedPageFigureNodes =
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

        Assert.NotNull(deserialized.ImageNodes);
        Assert.Equal(expectedImageNodes.Count, deserialized.ImageNodes.Count);
        for (int i = 0; i < expectedImageNodes.Count; i++)
        {
            Assert.Equal(expectedImageNodes[i], deserialized.ImageNodes[i]);
        }
        Assert.NotNull(deserialized.Nodes);
        Assert.Equal(expectedNodes.Count, deserialized.Nodes.Count);
        for (int i = 0; i < expectedNodes.Count; i++)
        {
            Assert.Equal(expectedNodes[i], deserialized.Nodes[i]);
        }
        Assert.NotNull(deserialized.PageFigureNodes);
        Assert.Equal(expectedPageFigureNodes.Count, deserialized.PageFigureNodes.Count);
        for (int i = 0; i < expectedPageFigureNodes.Count; i++)
        {
            Assert.Equal(expectedPageFigureNodes[i], deserialized.PageFigureNodes[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CompositeRetrievalResult
        {
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
            Nodes =
            [
                new()
                {
                    NodeValue = new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        EndCharIdx = 0,
                        PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        RetrieverPipelineName = "retriever_pipeline_name",
                        StartCharIdx = 0,
                        Text = "text",
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    },
                    ClassName = "class_name",
                    Score = 0,
                },
            ],
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CompositeRetrievalResult { };

        Assert.Null(model.ImageNodes);
        Assert.False(model.RawData.ContainsKey("image_nodes"));
        Assert.Null(model.Nodes);
        Assert.False(model.RawData.ContainsKey("nodes"));
        Assert.Null(model.PageFigureNodes);
        Assert.False(model.RawData.ContainsKey("page_figure_nodes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CompositeRetrievalResult { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CompositeRetrievalResult
        {
            // Null should be interpreted as omitted for these properties
            ImageNodes = null,
            Nodes = null,
            PageFigureNodes = null,
        };

        Assert.Null(model.ImageNodes);
        Assert.False(model.RawData.ContainsKey("image_nodes"));
        Assert.Null(model.Nodes);
        Assert.False(model.RawData.ContainsKey("nodes"));
        Assert.Null(model.PageFigureNodes);
        Assert.False(model.RawData.ContainsKey("page_figure_nodes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CompositeRetrievalResult
        {
            // Null should be interpreted as omitted for these properties
            ImageNodes = null,
            Nodes = null,
            PageFigureNodes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CompositeRetrievalResult
        {
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
            Nodes =
            [
                new()
                {
                    NodeValue = new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        EndCharIdx = 0,
                        PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        RetrieverPipelineName = "retriever_pipeline_name",
                        StartCharIdx = 0,
                        Text = "text",
                        Metadata = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    },
                    ClassName = "class_name",
                    Score = 0,
                },
            ],
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
        };

        CompositeRetrievalResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Node
        {
            NodeValue = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                EndCharIdx = 0,
                PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverPipelineName = "retriever_pipeline_name",
                StartCharIdx = 0,
                Text = "text",
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            ClassName = "class_name",
            Score = 0,
        };

        NodeNode expectedNodeValue = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EndCharIdx = 0,
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverPipelineName = "retriever_pipeline_name",
            StartCharIdx = 0,
            Text = "text",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };
        string expectedClassName = "class_name";
        double expectedScore = 0;

        Assert.Equal(expectedNodeValue, model.NodeValue);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedScore, model.Score);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Node
        {
            NodeValue = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                EndCharIdx = 0,
                PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverPipelineName = "retriever_pipeline_name",
                StartCharIdx = 0,
                Text = "text",
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            ClassName = "class_name",
            Score = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Node>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Node
        {
            NodeValue = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                EndCharIdx = 0,
                PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverPipelineName = "retriever_pipeline_name",
                StartCharIdx = 0,
                Text = "text",
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            ClassName = "class_name",
            Score = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Node>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        NodeNode expectedNodeValue = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EndCharIdx = 0,
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverPipelineName = "retriever_pipeline_name",
            StartCharIdx = 0,
            Text = "text",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };
        string expectedClassName = "class_name";
        double expectedScore = 0;

        Assert.Equal(expectedNodeValue, deserialized.NodeValue);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedScore, deserialized.Score);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Node
        {
            NodeValue = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                EndCharIdx = 0,
                PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverPipelineName = "retriever_pipeline_name",
                StartCharIdx = 0,
                Text = "text",
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            ClassName = "class_name",
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Node
        {
            NodeValue = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                EndCharIdx = 0,
                PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverPipelineName = "retriever_pipeline_name",
                StartCharIdx = 0,
                Text = "text",
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Score = 0,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Node
        {
            NodeValue = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                EndCharIdx = 0,
                PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverPipelineName = "retriever_pipeline_name",
                StartCharIdx = 0,
                Text = "text",
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Node
        {
            NodeValue = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                EndCharIdx = 0,
                PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverPipelineName = "retriever_pipeline_name",
                StartCharIdx = 0,
                Text = "text",
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
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
        var model = new Node
        {
            NodeValue = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                EndCharIdx = 0,
                PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverPipelineName = "retriever_pipeline_name",
                StartCharIdx = 0,
                Text = "text",
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
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
        var model = new Node
        {
            NodeValue = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                EndCharIdx = 0,
                PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverPipelineName = "retriever_pipeline_name",
                StartCharIdx = 0,
                Text = "text",
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            ClassName = "class_name",
        };

        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Node
        {
            NodeValue = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                EndCharIdx = 0,
                PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverPipelineName = "retriever_pipeline_name",
                StartCharIdx = 0,
                Text = "text",
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            ClassName = "class_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Node
        {
            NodeValue = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                EndCharIdx = 0,
                PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverPipelineName = "retriever_pipeline_name",
                StartCharIdx = 0,
                Text = "text",
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
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
        var model = new Node
        {
            NodeValue = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                EndCharIdx = 0,
                PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverPipelineName = "retriever_pipeline_name",
                StartCharIdx = 0,
                Text = "text",
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            ClassName = "class_name",

            Score = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Node
        {
            NodeValue = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                EndCharIdx = 0,
                PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                RetrieverPipelineName = "retriever_pipeline_name",
                StartCharIdx = 0,
                Text = "text",
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            ClassName = "class_name",
            Score = 0,
        };

        Node copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NodeNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NodeNode
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EndCharIdx = 0,
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverPipelineName = "retriever_pipeline_name",
            StartCharIdx = 0,
            Text = "text",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedEndCharIdx = 0;
        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedRetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedRetrieverPipelineName = "retriever_pipeline_name";
        long expectedStartCharIdx = 0;
        string expectedText = "text";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedEndCharIdx, model.EndCharIdx);
        Assert.Equal(expectedPipelineID, model.PipelineID);
        Assert.Equal(expectedRetrieverID, model.RetrieverID);
        Assert.Equal(expectedRetrieverPipelineName, model.RetrieverPipelineName);
        Assert.Equal(expectedStartCharIdx, model.StartCharIdx);
        Assert.Equal(expectedText, model.Text);
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
        var model = new NodeNode
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EndCharIdx = 0,
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverPipelineName = "retriever_pipeline_name",
            StartCharIdx = 0,
            Text = "text",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NodeNode>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NodeNode
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EndCharIdx = 0,
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverPipelineName = "retriever_pipeline_name",
            StartCharIdx = 0,
            Text = "text",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NodeNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedEndCharIdx = 0;
        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedRetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedRetrieverPipelineName = "retriever_pipeline_name";
        long expectedStartCharIdx = 0;
        string expectedText = "text";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedEndCharIdx, deserialized.EndCharIdx);
        Assert.Equal(expectedPipelineID, deserialized.PipelineID);
        Assert.Equal(expectedRetrieverID, deserialized.RetrieverID);
        Assert.Equal(expectedRetrieverPipelineName, deserialized.RetrieverPipelineName);
        Assert.Equal(expectedStartCharIdx, deserialized.StartCharIdx);
        Assert.Equal(expectedText, deserialized.Text);
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
        var model = new NodeNode
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EndCharIdx = 0,
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverPipelineName = "retriever_pipeline_name",
            StartCharIdx = 0,
            Text = "text",
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
        var model = new NodeNode
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EndCharIdx = 0,
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverPipelineName = "retriever_pipeline_name",
            StartCharIdx = 0,
            Text = "text",
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NodeNode
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EndCharIdx = 0,
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverPipelineName = "retriever_pipeline_name",
            StartCharIdx = 0,
            Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NodeNode
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EndCharIdx = 0,
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverPipelineName = "retriever_pipeline_name",
            StartCharIdx = 0,
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NodeNode
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EndCharIdx = 0,
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverPipelineName = "retriever_pipeline_name",
            StartCharIdx = 0,
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NodeNode
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EndCharIdx = 0,
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RetrieverPipelineName = "retriever_pipeline_name",
            StartCharIdx = 0,
            Text = "text",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        NodeNode copied = new(model);

        Assert.Equal(model, copied);
    }
}
