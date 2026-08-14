using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines;
using LlamaIndex.LlamaCloud.Models.Retrievers;

namespace LlamaIndex.LlamaCloud.Tests.Models.Retrievers;

public class RetrieverPipelineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RetrieverPipeline
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
        };

        string expectedDescription = "description";
        string expectedName = "x";
        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        PresetRetrievalParams expectedPresetRetrievalParameters = new()
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
        };

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPipelineID, model.PipelineID);
        Assert.Equal(expectedPresetRetrievalParameters, model.PresetRetrievalParameters);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RetrieverPipeline
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetrieverPipeline>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RetrieverPipeline
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetrieverPipeline>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        string expectedName = "x";
        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        PresetRetrievalParams expectedPresetRetrievalParameters = new()
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
        };

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPipelineID, deserialized.PipelineID);
        Assert.Equal(expectedPresetRetrievalParameters, deserialized.PresetRetrievalParameters);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RetrieverPipeline
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RetrieverPipeline
        {
            Description = "description",
            Name = "x",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(model.PresetRetrievalParameters);
        Assert.False(model.RawData.ContainsKey("preset_retrieval_parameters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RetrieverPipeline
        {
            Description = "description",
            Name = "x",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RetrieverPipeline
        {
            Description = "description",
            Name = "x",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            PresetRetrievalParameters = null,
        };

        Assert.Null(model.PresetRetrievalParameters);
        Assert.False(model.RawData.ContainsKey("preset_retrieval_parameters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RetrieverPipeline
        {
            Description = "description",
            Name = "x",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            PresetRetrievalParameters = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RetrieverPipeline
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
        };

        RetrieverPipeline copied = new(model);

        Assert.Equal(model, copied);
    }
}
