using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Pipelines;

namespace LlamaCloud.Tests.Models.Pipelines;

public class PipelineRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PipelineRetrieveParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Query = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            SearchFiltersInferenceSchema = new Dictionary<string, SearchFiltersInferenceSchema?>()
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

        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedQuery = "x";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
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
        Dictionary<string, SearchFiltersInferenceSchema?> expectedSearchFiltersInferenceSchema =
            new()
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

        Assert.Equal(expectedPipelineID, parameters.PipelineID);
        Assert.Equal(expectedQuery, parameters.Query);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedAlpha, parameters.Alpha);
        Assert.Equal(expectedClassName, parameters.ClassName);
        Assert.Equal(expectedDenseSimilarityCutoff, parameters.DenseSimilarityCutoff);
        Assert.Equal(expectedDenseSimilarityTopK, parameters.DenseSimilarityTopK);
        Assert.Equal(expectedEnableReranking, parameters.EnableReranking);
        Assert.Equal(expectedFilesTopK, parameters.FilesTopK);
        Assert.Equal(expectedRerankTopN, parameters.RerankTopN);
        Assert.Equal(expectedRetrievalMode, parameters.RetrievalMode);
        Assert.Equal(expectedRetrieveImageNodes, parameters.RetrieveImageNodes);
        Assert.Equal(expectedRetrievePageFigureNodes, parameters.RetrievePageFigureNodes);
        Assert.Equal(expectedRetrievePageScreenshotNodes, parameters.RetrievePageScreenshotNodes);
        Assert.Equal(expectedSearchFilters, parameters.SearchFilters);
        Assert.NotNull(parameters.SearchFiltersInferenceSchema);
        Assert.Equal(
            expectedSearchFiltersInferenceSchema.Count,
            parameters.SearchFiltersInferenceSchema.Count
        );
        foreach (var item in expectedSearchFiltersInferenceSchema)
        {
            Assert.True(
                parameters.SearchFiltersInferenceSchema.TryGetValue(item.Key, out var value)
            );

            Assert.Equal(value, parameters.SearchFiltersInferenceSchema[item.Key]);
        }
        Assert.Equal(expectedSparseSimilarityTopK, parameters.SparseSimilarityTopK);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PipelineRetrieveParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Query = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            SearchFiltersInferenceSchema = new Dictionary<string, SearchFiltersInferenceSchema?>()
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

        Assert.Null(parameters.ClassName);
        Assert.False(parameters.RawBodyData.ContainsKey("class_name"));
        Assert.Null(parameters.RetrievalMode);
        Assert.False(parameters.RawBodyData.ContainsKey("retrieval_mode"));
        Assert.Null(parameters.RetrieveImageNodes);
        Assert.False(parameters.RawBodyData.ContainsKey("retrieve_image_nodes"));
        Assert.Null(parameters.RetrievePageFigureNodes);
        Assert.False(parameters.RawBodyData.ContainsKey("retrieve_page_figure_nodes"));
        Assert.Null(parameters.RetrievePageScreenshotNodes);
        Assert.False(parameters.RawBodyData.ContainsKey("retrieve_page_screenshot_nodes"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PipelineRetrieveParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Query = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            SearchFiltersInferenceSchema = new Dictionary<string, SearchFiltersInferenceSchema?>()
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

        Assert.Null(parameters.ClassName);
        Assert.False(parameters.RawBodyData.ContainsKey("class_name"));
        Assert.Null(parameters.RetrievalMode);
        Assert.False(parameters.RawBodyData.ContainsKey("retrieval_mode"));
        Assert.Null(parameters.RetrieveImageNodes);
        Assert.False(parameters.RawBodyData.ContainsKey("retrieve_image_nodes"));
        Assert.Null(parameters.RetrievePageFigureNodes);
        Assert.False(parameters.RawBodyData.ContainsKey("retrieve_page_figure_nodes"));
        Assert.Null(parameters.RetrievePageScreenshotNodes);
        Assert.False(parameters.RawBodyData.ContainsKey("retrieve_page_screenshot_nodes"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PipelineRetrieveParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Query = "x",
            ClassName = "class_name",
            RetrievalMode = RetrievalMode.AutoRouted,
            RetrieveImageNodes = true,
            RetrievePageFigureNodes = true,
            RetrievePageScreenshotNodes = true,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Alpha);
        Assert.False(parameters.RawBodyData.ContainsKey("alpha"));
        Assert.Null(parameters.DenseSimilarityCutoff);
        Assert.False(parameters.RawBodyData.ContainsKey("dense_similarity_cutoff"));
        Assert.Null(parameters.DenseSimilarityTopK);
        Assert.False(parameters.RawBodyData.ContainsKey("dense_similarity_top_k"));
        Assert.Null(parameters.EnableReranking);
        Assert.False(parameters.RawBodyData.ContainsKey("enable_reranking"));
        Assert.Null(parameters.FilesTopK);
        Assert.False(parameters.RawBodyData.ContainsKey("files_top_k"));
        Assert.Null(parameters.RerankTopN);
        Assert.False(parameters.RawBodyData.ContainsKey("rerank_top_n"));
        Assert.Null(parameters.SearchFilters);
        Assert.False(parameters.RawBodyData.ContainsKey("search_filters"));
        Assert.Null(parameters.SearchFiltersInferenceSchema);
        Assert.False(parameters.RawBodyData.ContainsKey("search_filters_inference_schema"));
        Assert.Null(parameters.SparseSimilarityTopK);
        Assert.False(parameters.RawBodyData.ContainsKey("sparse_similarity_top_k"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PipelineRetrieveParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Query = "x",
            ClassName = "class_name",
            RetrievalMode = RetrievalMode.AutoRouted,
            RetrieveImageNodes = true,
            RetrievePageFigureNodes = true,
            RetrievePageScreenshotNodes = true,

            OrganizationID = null,
            ProjectID = null,
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

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Alpha);
        Assert.True(parameters.RawBodyData.ContainsKey("alpha"));
        Assert.Null(parameters.DenseSimilarityCutoff);
        Assert.True(parameters.RawBodyData.ContainsKey("dense_similarity_cutoff"));
        Assert.Null(parameters.DenseSimilarityTopK);
        Assert.True(parameters.RawBodyData.ContainsKey("dense_similarity_top_k"));
        Assert.Null(parameters.EnableReranking);
        Assert.True(parameters.RawBodyData.ContainsKey("enable_reranking"));
        Assert.Null(parameters.FilesTopK);
        Assert.True(parameters.RawBodyData.ContainsKey("files_top_k"));
        Assert.Null(parameters.RerankTopN);
        Assert.True(parameters.RawBodyData.ContainsKey("rerank_top_n"));
        Assert.Null(parameters.SearchFilters);
        Assert.True(parameters.RawBodyData.ContainsKey("search_filters"));
        Assert.Null(parameters.SearchFiltersInferenceSchema);
        Assert.True(parameters.RawBodyData.ContainsKey("search_filters_inference_schema"));
        Assert.Null(parameters.SparseSimilarityTopK);
        Assert.True(parameters.RawBodyData.ContainsKey("sparse_similarity_top_k"));
    }

    [Fact]
    public void Url_Works()
    {
        PipelineRetrieveParams parameters = new()
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Query = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/pipelines/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/retrieve?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PipelineRetrieveParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Query = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            SearchFiltersInferenceSchema = new Dictionary<string, SearchFiltersInferenceSchema?>()
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

        PipelineRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SearchFiltersInferenceSchemaTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        SearchFiltersInferenceSchema value = new(
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
        SearchFiltersInferenceSchema value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        SearchFiltersInferenceSchema value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        SearchFiltersInferenceSchema value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        SearchFiltersInferenceSchema value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        SearchFiltersInferenceSchema value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchFiltersInferenceSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        SearchFiltersInferenceSchema value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchFiltersInferenceSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        SearchFiltersInferenceSchema value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchFiltersInferenceSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        SearchFiltersInferenceSchema value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchFiltersInferenceSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        SearchFiltersInferenceSchema value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchFiltersInferenceSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
