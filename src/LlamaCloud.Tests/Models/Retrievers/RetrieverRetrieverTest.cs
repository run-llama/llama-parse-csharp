using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Pipelines;
using LlamaCloud.Models.Retrievers;

namespace LlamaCloud.Tests.Models.Retrievers;

public class RetrieverRetrieverTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RetrieverRetriever
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedName = "x";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
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
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.NotNull(model.Pipelines);
        Assert.Equal(expectedPipelines.Count, model.Pipelines.Count);
        for (int i = 0; i < expectedPipelines.Count; i++)
        {
            Assert.Equal(expectedPipelines[i], model.Pipelines[i]);
        }
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RetrieverRetriever
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetrieverRetriever>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RetrieverRetriever
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetrieverRetriever>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedName = "x";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
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
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.Pipelines);
        Assert.Equal(expectedPipelines.Count, deserialized.Pipelines.Count);
        for (int i = 0; i < expectedPipelines.Count; i++)
        {
            Assert.Equal(expectedPipelines[i], deserialized.Pipelines[i]);
        }
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RetrieverRetriever
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RetrieverRetriever
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Pipelines);
        Assert.False(model.RawData.ContainsKey("pipelines"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RetrieverRetriever
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RetrieverRetriever
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Pipelines = null,
        };

        Assert.Null(model.Pipelines);
        Assert.False(model.RawData.ContainsKey("pipelines"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RetrieverRetriever
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Pipelines = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RetrieverRetriever
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RetrieverRetriever
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RetrieverRetriever
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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

            CreatedAt = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RetrieverRetriever
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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

            CreatedAt = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RetrieverRetriever
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        RetrieverRetriever copied = new(model);

        Assert.Equal(model, copied);
    }
}
