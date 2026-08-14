using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Pipelines;

namespace LlamaCloud.Tests.Models.Pipelines;

public class PresetRetrievalParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PresetRetrievalParams
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

        double expectedAlpha = 0;
        string expectedClassName = "class_name";
        double expectedDenseSimilarityCutoff = 0;
        long expectedDenseSimilarityTopK = 1;
        bool expectedEnableReranking = true;
        long expectedFilesTopK = 1;
        long expectedRerankTopN = 1;
        ApiEnum<string, RetrievalMode> expectedRetrievalMode = RetrievalMode.AutoRouted;
        bool expectedRetrieveImageNodes = true;
        bool expectedRetrievePageFigureNodes = true;
        bool expectedRetrievePageScreenshotNodes = true;
        MetadataFilters expectedSearchFilters = new()
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
        Dictionary<
            string,
            PresetRetrievalParamsSearchFiltersInferenceSchema?
        > expectedSearchFiltersInferenceSchema = new()
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
        };
        long expectedSparseSimilarityTopK = 1;

        Assert.Equal(expectedAlpha, model.Alpha);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedDenseSimilarityCutoff, model.DenseSimilarityCutoff);
        Assert.Equal(expectedDenseSimilarityTopK, model.DenseSimilarityTopK);
        Assert.Equal(expectedEnableReranking, model.EnableReranking);
        Assert.Equal(expectedFilesTopK, model.FilesTopK);
        Assert.Equal(expectedRerankTopN, model.RerankTopN);
        Assert.Equal(expectedRetrievalMode, model.RetrievalMode);
        Assert.Equal(expectedRetrieveImageNodes, model.RetrieveImageNodes);
        Assert.Equal(expectedRetrievePageFigureNodes, model.RetrievePageFigureNodes);
        Assert.Equal(expectedRetrievePageScreenshotNodes, model.RetrievePageScreenshotNodes);
        Assert.Equal(expectedSearchFilters, model.SearchFilters);
        Assert.NotNull(model.SearchFiltersInferenceSchema);
        Assert.Equal(
            expectedSearchFiltersInferenceSchema.Count,
            model.SearchFiltersInferenceSchema.Count
        );
        foreach (var item in expectedSearchFiltersInferenceSchema)
        {
            Assert.True(model.SearchFiltersInferenceSchema.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.SearchFiltersInferenceSchema[item.Key]);
        }
        Assert.Equal(expectedSparseSimilarityTopK, model.SparseSimilarityTopK);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PresetRetrievalParams
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PresetRetrievalParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PresetRetrievalParams
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PresetRetrievalParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAlpha = 0;
        string expectedClassName = "class_name";
        double expectedDenseSimilarityCutoff = 0;
        long expectedDenseSimilarityTopK = 1;
        bool expectedEnableReranking = true;
        long expectedFilesTopK = 1;
        long expectedRerankTopN = 1;
        ApiEnum<string, RetrievalMode> expectedRetrievalMode = RetrievalMode.AutoRouted;
        bool expectedRetrieveImageNodes = true;
        bool expectedRetrievePageFigureNodes = true;
        bool expectedRetrievePageScreenshotNodes = true;
        MetadataFilters expectedSearchFilters = new()
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
        Dictionary<
            string,
            PresetRetrievalParamsSearchFiltersInferenceSchema?
        > expectedSearchFiltersInferenceSchema = new()
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
        };
        long expectedSparseSimilarityTopK = 1;

        Assert.Equal(expectedAlpha, deserialized.Alpha);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedDenseSimilarityCutoff, deserialized.DenseSimilarityCutoff);
        Assert.Equal(expectedDenseSimilarityTopK, deserialized.DenseSimilarityTopK);
        Assert.Equal(expectedEnableReranking, deserialized.EnableReranking);
        Assert.Equal(expectedFilesTopK, deserialized.FilesTopK);
        Assert.Equal(expectedRerankTopN, deserialized.RerankTopN);
        Assert.Equal(expectedRetrievalMode, deserialized.RetrievalMode);
        Assert.Equal(expectedRetrieveImageNodes, deserialized.RetrieveImageNodes);
        Assert.Equal(expectedRetrievePageFigureNodes, deserialized.RetrievePageFigureNodes);
        Assert.Equal(expectedRetrievePageScreenshotNodes, deserialized.RetrievePageScreenshotNodes);
        Assert.Equal(expectedSearchFilters, deserialized.SearchFilters);
        Assert.NotNull(deserialized.SearchFiltersInferenceSchema);
        Assert.Equal(
            expectedSearchFiltersInferenceSchema.Count,
            deserialized.SearchFiltersInferenceSchema.Count
        );
        foreach (var item in expectedSearchFiltersInferenceSchema)
        {
            Assert.True(
                deserialized.SearchFiltersInferenceSchema.TryGetValue(item.Key, out var value)
            );

            Assert.Equal(value, deserialized.SearchFiltersInferenceSchema[item.Key]);
        }
        Assert.Equal(expectedSparseSimilarityTopK, deserialized.SparseSimilarityTopK);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PresetRetrievalParams
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PresetRetrievalParams
        {
            Alpha = 0,
            DenseSimilarityCutoff = 0,
            DenseSimilarityTopK = 1,
            EnableReranking = true,
            FilesTopK = 1,
            RerankTopN = 1,
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

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.RetrievalMode);
        Assert.False(model.RawData.ContainsKey("retrieval_mode"));
        Assert.Null(model.RetrieveImageNodes);
        Assert.False(model.RawData.ContainsKey("retrieve_image_nodes"));
        Assert.Null(model.RetrievePageFigureNodes);
        Assert.False(model.RawData.ContainsKey("retrieve_page_figure_nodes"));
        Assert.Null(model.RetrievePageScreenshotNodes);
        Assert.False(model.RawData.ContainsKey("retrieve_page_screenshot_nodes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PresetRetrievalParams
        {
            Alpha = 0,
            DenseSimilarityCutoff = 0,
            DenseSimilarityTopK = 1,
            EnableReranking = true,
            FilesTopK = 1,
            RerankTopN = 1,
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PresetRetrievalParams
        {
            Alpha = 0,
            DenseSimilarityCutoff = 0,
            DenseSimilarityTopK = 1,
            EnableReranking = true,
            FilesTopK = 1,
            RerankTopN = 1,
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

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            RetrievalMode = null,
            RetrieveImageNodes = null,
            RetrievePageFigureNodes = null,
            RetrievePageScreenshotNodes = null,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.RetrievalMode);
        Assert.False(model.RawData.ContainsKey("retrieval_mode"));
        Assert.Null(model.RetrieveImageNodes);
        Assert.False(model.RawData.ContainsKey("retrieve_image_nodes"));
        Assert.Null(model.RetrievePageFigureNodes);
        Assert.False(model.RawData.ContainsKey("retrieve_page_figure_nodes"));
        Assert.Null(model.RetrievePageScreenshotNodes);
        Assert.False(model.RawData.ContainsKey("retrieve_page_screenshot_nodes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PresetRetrievalParams
        {
            Alpha = 0,
            DenseSimilarityCutoff = 0,
            DenseSimilarityTopK = 1,
            EnableReranking = true,
            FilesTopK = 1,
            RerankTopN = 1,
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

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            RetrievalMode = null,
            RetrieveImageNodes = null,
            RetrievePageFigureNodes = null,
            RetrievePageScreenshotNodes = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PresetRetrievalParams
        {
            ClassName = "class_name",
            RetrievalMode = RetrievalMode.AutoRouted,
            RetrieveImageNodes = true,
            RetrievePageFigureNodes = true,
            RetrievePageScreenshotNodes = true,
        };

        Assert.Null(model.Alpha);
        Assert.False(model.RawData.ContainsKey("alpha"));
        Assert.Null(model.DenseSimilarityCutoff);
        Assert.False(model.RawData.ContainsKey("dense_similarity_cutoff"));
        Assert.Null(model.DenseSimilarityTopK);
        Assert.False(model.RawData.ContainsKey("dense_similarity_top_k"));
        Assert.Null(model.EnableReranking);
        Assert.False(model.RawData.ContainsKey("enable_reranking"));
        Assert.Null(model.FilesTopK);
        Assert.False(model.RawData.ContainsKey("files_top_k"));
        Assert.Null(model.RerankTopN);
        Assert.False(model.RawData.ContainsKey("rerank_top_n"));
        Assert.Null(model.SearchFilters);
        Assert.False(model.RawData.ContainsKey("search_filters"));
        Assert.Null(model.SearchFiltersInferenceSchema);
        Assert.False(model.RawData.ContainsKey("search_filters_inference_schema"));
        Assert.Null(model.SparseSimilarityTopK);
        Assert.False(model.RawData.ContainsKey("sparse_similarity_top_k"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PresetRetrievalParams
        {
            ClassName = "class_name",
            RetrievalMode = RetrievalMode.AutoRouted,
            RetrieveImageNodes = true,
            RetrievePageFigureNodes = true,
            RetrievePageScreenshotNodes = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PresetRetrievalParams
        {
            ClassName = "class_name",
            RetrievalMode = RetrievalMode.AutoRouted,
            RetrieveImageNodes = true,
            RetrievePageFigureNodes = true,
            RetrievePageScreenshotNodes = true,

            Alpha = null,
            DenseSimilarityCutoff = null,
            DenseSimilarityTopK = null,
            EnableReranking = null,
            FilesTopK = null,
            RerankTopN = null,
            SearchFilters = null,
            SearchFiltersInferenceSchema = null,
            SparseSimilarityTopK = null,
        };

        Assert.Null(model.Alpha);
        Assert.True(model.RawData.ContainsKey("alpha"));
        Assert.Null(model.DenseSimilarityCutoff);
        Assert.True(model.RawData.ContainsKey("dense_similarity_cutoff"));
        Assert.Null(model.DenseSimilarityTopK);
        Assert.True(model.RawData.ContainsKey("dense_similarity_top_k"));
        Assert.Null(model.EnableReranking);
        Assert.True(model.RawData.ContainsKey("enable_reranking"));
        Assert.Null(model.FilesTopK);
        Assert.True(model.RawData.ContainsKey("files_top_k"));
        Assert.Null(model.RerankTopN);
        Assert.True(model.RawData.ContainsKey("rerank_top_n"));
        Assert.Null(model.SearchFilters);
        Assert.True(model.RawData.ContainsKey("search_filters"));
        Assert.Null(model.SearchFiltersInferenceSchema);
        Assert.True(model.RawData.ContainsKey("search_filters_inference_schema"));
        Assert.Null(model.SparseSimilarityTopK);
        Assert.True(model.RawData.ContainsKey("sparse_similarity_top_k"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PresetRetrievalParams
        {
            ClassName = "class_name",
            RetrievalMode = RetrievalMode.AutoRouted,
            RetrieveImageNodes = true,
            RetrievePageFigureNodes = true,
            RetrievePageScreenshotNodes = true,

            Alpha = null,
            DenseSimilarityCutoff = null,
            DenseSimilarityTopK = null,
            EnableReranking = null,
            FilesTopK = null,
            RerankTopN = null,
            SearchFilters = null,
            SearchFiltersInferenceSchema = null,
            SparseSimilarityTopK = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PresetRetrievalParams
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

        PresetRetrievalParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PresetRetrievalParamsSearchFiltersInferenceSchemaTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        PresetRetrievalParamsSearchFiltersInferenceSchema value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        value.Validate();
    }

    [Fact]
    public void JsonElementsValidationWorks1()
    {
        PresetRetrievalParamsSearchFiltersInferenceSchema value = new(
            [JsonSerializer.Deserialize<JsonElement>("{}")]
        );
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        PresetRetrievalParamsSearchFiltersInferenceSchema value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        PresetRetrievalParamsSearchFiltersInferenceSchema value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        PresetRetrievalParamsSearchFiltersInferenceSchema value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        PresetRetrievalParamsSearchFiltersInferenceSchema value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PresetRetrievalParamsSearchFiltersInferenceSchema>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        PresetRetrievalParamsSearchFiltersInferenceSchema value = new(
            [JsonSerializer.Deserialize<JsonElement>("{}")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PresetRetrievalParamsSearchFiltersInferenceSchema>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        PresetRetrievalParamsSearchFiltersInferenceSchema value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PresetRetrievalParamsSearchFiltersInferenceSchema>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        PresetRetrievalParamsSearchFiltersInferenceSchema value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PresetRetrievalParamsSearchFiltersInferenceSchema>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        PresetRetrievalParamsSearchFiltersInferenceSchema value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PresetRetrievalParamsSearchFiltersInferenceSchema>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
