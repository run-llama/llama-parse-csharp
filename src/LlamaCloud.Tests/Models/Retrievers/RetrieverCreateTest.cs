using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Pipelines;
using LlamaCloud.Models.Retrievers;

namespace LlamaCloud.Tests.Models.Retrievers;

public class RetrieverCreateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RetrieverCreate
        {
            Name = "x",
            Pipelines =
            [
                new()
                {
                    Description = "description",
                    Name = "x",
                    PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    PresetRetrievalParameters = new()
                    {
                        Alpha = 0,
                        ClassName = "class_name",
                        DenseSimilarityCutoff = 0,
                        DenseSimilarityTopK = 1,
                        EnableReranking = true,
                        FilesTopK = 1,
                        RerankTopN = 1,
                        RetrievalMode = RetrievalMode.AutoRouted,
                        RetrieveImageNodes = true,
                        RetrievePageFigureNodes = true,
                        RetrievePageScreenshotNodes = true,
                        SearchFilters = new()
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
                        SearchFiltersInferenceSchema = new Dictionary<
                            string,
                            PresetRetrievalParamsSearchFiltersInferenceSchema?
                        >()
                        {
                            {
                                "foo",
                                new(
                                    new Dictionary<string, JsonElement>()
                                    {
                                        { "foo", JsonSerializer.SerializeToElement("bar") },
                                    }
                                )
                            },
                        },
                        SparseSimilarityTopK = 1,
                    },
                },
            ],
        };

        string expectedName = "x";
        List<RetrieverPipeline> expectedPipelines =
        [
            new()
            {
                Description = "description",
                Name = "x",
                PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PresetRetrievalParameters = new()
                {
                    Alpha = 0,
                    ClassName = "class_name",
                    DenseSimilarityCutoff = 0,
                    DenseSimilarityTopK = 1,
                    EnableReranking = true,
                    FilesTopK = 1,
                    RerankTopN = 1,
                    RetrievalMode = RetrievalMode.AutoRouted,
                    RetrieveImageNodes = true,
                    RetrievePageFigureNodes = true,
                    RetrievePageScreenshotNodes = true,
                    SearchFilters = new()
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
                    SearchFiltersInferenceSchema = new Dictionary<
                        string,
                        PresetRetrievalParamsSearchFiltersInferenceSchema?
                    >()
                    {
                        {
                            "foo",
                            new(
                                new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                }
                            )
                        },
                    },
                    SparseSimilarityTopK = 1,
                },
            },
        ];

        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.Pipelines);
        Assert.Equal(expectedPipelines.Count, model.Pipelines.Count);
        for (int i = 0; i < expectedPipelines.Count; i++)
        {
            Assert.Equal(expectedPipelines[i], model.Pipelines[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RetrieverCreate
        {
            Name = "x",
            Pipelines =
            [
                new()
                {
                    Description = "description",
                    Name = "x",
                    PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    PresetRetrievalParameters = new()
                    {
                        Alpha = 0,
                        ClassName = "class_name",
                        DenseSimilarityCutoff = 0,
                        DenseSimilarityTopK = 1,
                        EnableReranking = true,
                        FilesTopK = 1,
                        RerankTopN = 1,
                        RetrievalMode = RetrievalMode.AutoRouted,
                        RetrieveImageNodes = true,
                        RetrievePageFigureNodes = true,
                        RetrievePageScreenshotNodes = true,
                        SearchFilters = new()
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
                        SearchFiltersInferenceSchema = new Dictionary<
                            string,
                            PresetRetrievalParamsSearchFiltersInferenceSchema?
                        >()
                        {
                            {
                                "foo",
                                new(
                                    new Dictionary<string, JsonElement>()
                                    {
                                        { "foo", JsonSerializer.SerializeToElement("bar") },
                                    }
                                )
                            },
                        },
                        SparseSimilarityTopK = 1,
                    },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetrieverCreate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RetrieverCreate
        {
            Name = "x",
            Pipelines =
            [
                new()
                {
                    Description = "description",
                    Name = "x",
                    PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    PresetRetrievalParameters = new()
                    {
                        Alpha = 0,
                        ClassName = "class_name",
                        DenseSimilarityCutoff = 0,
                        DenseSimilarityTopK = 1,
                        EnableReranking = true,
                        FilesTopK = 1,
                        RerankTopN = 1,
                        RetrievalMode = RetrievalMode.AutoRouted,
                        RetrieveImageNodes = true,
                        RetrievePageFigureNodes = true,
                        RetrievePageScreenshotNodes = true,
                        SearchFilters = new()
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
                        SearchFiltersInferenceSchema = new Dictionary<
                            string,
                            PresetRetrievalParamsSearchFiltersInferenceSchema?
                        >()
                        {
                            {
                                "foo",
                                new(
                                    new Dictionary<string, JsonElement>()
                                    {
                                        { "foo", JsonSerializer.SerializeToElement("bar") },
                                    }
                                )
                            },
                        },
                        SparseSimilarityTopK = 1,
                    },
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetrieverCreate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "x";
        List<RetrieverPipeline> expectedPipelines =
        [
            new()
            {
                Description = "description",
                Name = "x",
                PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PresetRetrievalParameters = new()
                {
                    Alpha = 0,
                    ClassName = "class_name",
                    DenseSimilarityCutoff = 0,
                    DenseSimilarityTopK = 1,
                    EnableReranking = true,
                    FilesTopK = 1,
                    RerankTopN = 1,
                    RetrievalMode = RetrievalMode.AutoRouted,
                    RetrieveImageNodes = true,
                    RetrievePageFigureNodes = true,
                    RetrievePageScreenshotNodes = true,
                    SearchFilters = new()
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
                    SearchFiltersInferenceSchema = new Dictionary<
                        string,
                        PresetRetrievalParamsSearchFiltersInferenceSchema?
                    >()
                    {
                        {
                            "foo",
                            new(
                                new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                }
                            )
                        },
                    },
                    SparseSimilarityTopK = 1,
                },
            },
        ];

        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.Pipelines);
        Assert.Equal(expectedPipelines.Count, deserialized.Pipelines.Count);
        for (int i = 0; i < expectedPipelines.Count; i++)
        {
            Assert.Equal(expectedPipelines[i], deserialized.Pipelines[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RetrieverCreate
        {
            Name = "x",
            Pipelines =
            [
                new()
                {
                    Description = "description",
                    Name = "x",
                    PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    PresetRetrievalParameters = new()
                    {
                        Alpha = 0,
                        ClassName = "class_name",
                        DenseSimilarityCutoff = 0,
                        DenseSimilarityTopK = 1,
                        EnableReranking = true,
                        FilesTopK = 1,
                        RerankTopN = 1,
                        RetrievalMode = RetrievalMode.AutoRouted,
                        RetrieveImageNodes = true,
                        RetrievePageFigureNodes = true,
                        RetrievePageScreenshotNodes = true,
                        SearchFilters = new()
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
                        SearchFiltersInferenceSchema = new Dictionary<
                            string,
                            PresetRetrievalParamsSearchFiltersInferenceSchema?
                        >()
                        {
                            {
                                "foo",
                                new(
                                    new Dictionary<string, JsonElement>()
                                    {
                                        { "foo", JsonSerializer.SerializeToElement("bar") },
                                    }
                                )
                            },
                        },
                        SparseSimilarityTopK = 1,
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RetrieverCreate { Name = "x" };

        Assert.Null(model.Pipelines);
        Assert.False(model.RawData.ContainsKey("pipelines"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RetrieverCreate { Name = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RetrieverCreate
        {
            Name = "x",

            // Null should be interpreted as omitted for these properties
            Pipelines = null,
        };

        Assert.Null(model.Pipelines);
        Assert.False(model.RawData.ContainsKey("pipelines"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RetrieverCreate
        {
            Name = "x",

            // Null should be interpreted as omitted for these properties
            Pipelines = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RetrieverCreate
        {
            Name = "x",
            Pipelines =
            [
                new()
                {
                    Description = "description",
                    Name = "x",
                    PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    PresetRetrievalParameters = new()
                    {
                        Alpha = 0,
                        ClassName = "class_name",
                        DenseSimilarityCutoff = 0,
                        DenseSimilarityTopK = 1,
                        EnableReranking = true,
                        FilesTopK = 1,
                        RerankTopN = 1,
                        RetrievalMode = RetrievalMode.AutoRouted,
                        RetrieveImageNodes = true,
                        RetrievePageFigureNodes = true,
                        RetrievePageScreenshotNodes = true,
                        SearchFilters = new()
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
                        SearchFiltersInferenceSchema = new Dictionary<
                            string,
                            PresetRetrievalParamsSearchFiltersInferenceSchema?
                        >()
                        {
                            {
                                "foo",
                                new(
                                    new Dictionary<string, JsonElement>()
                                    {
                                        { "foo", JsonSerializer.SerializeToElement("bar") },
                                    }
                                )
                            },
                        },
                        SparseSimilarityTopK = 1,
                    },
                },
            ],
        };

        RetrieverCreate copied = new(model);

        Assert.Equal(model, copied);
    }
}
