using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Pipelines;
using Retrievers = LlamaCloud.Models.Retrievers;

namespace LlamaCloud.Tests.Models.Retrievers;

public class RetrieverSearchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Retrievers::RetrieverSearchParams
        {
            Query = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Mode = Retrievers::CompositeRetrievalMode.Full,
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
            RerankConfig = new() { TopN = 1, Type = Retrievers::Type.Bedrock },
            RerankTopN = 0,
        };

        string expectedQuery = "x";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, Retrievers::CompositeRetrievalMode> expectedMode =
            Retrievers::CompositeRetrievalMode.Full;
        List<Retrievers::RetrieverPipeline> expectedPipelines =
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
        Retrievers::ReRankConfig expectedRerankConfig = new()
        {
            TopN = 1,
            Type = Retrievers::Type.Bedrock,
        };
        long expectedRerankTopN = 0;

        Assert.Equal(expectedQuery, parameters.Query);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedMode, parameters.Mode);
        Assert.NotNull(parameters.Pipelines);
        Assert.Equal(expectedPipelines.Count, parameters.Pipelines.Count);
        for (int i = 0; i < expectedPipelines.Count; i++)
        {
            Assert.Equal(expectedPipelines[i], parameters.Pipelines[i]);
        }
        Assert.Equal(expectedRerankConfig, parameters.RerankConfig);
        Assert.Equal(expectedRerankTopN, parameters.RerankTopN);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Retrievers::RetrieverSearchParams
        {
            Query = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RerankTopN = 0,
        };

        Assert.Null(parameters.Mode);
        Assert.False(parameters.RawBodyData.ContainsKey("mode"));
        Assert.Null(parameters.Pipelines);
        Assert.False(parameters.RawBodyData.ContainsKey("pipelines"));
        Assert.Null(parameters.RerankConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("rerank_config"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Retrievers::RetrieverSearchParams
        {
            Query = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RerankTopN = 0,

            // Null should be interpreted as omitted for these properties
            Mode = null,
            Pipelines = null,
            RerankConfig = null,
        };

        Assert.Null(parameters.Mode);
        Assert.False(parameters.RawBodyData.ContainsKey("mode"));
        Assert.Null(parameters.Pipelines);
        Assert.False(parameters.RawBodyData.ContainsKey("pipelines"));
        Assert.Null(parameters.RerankConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("rerank_config"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Retrievers::RetrieverSearchParams
        {
            Query = "x",
            Mode = Retrievers::CompositeRetrievalMode.Full,
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
            RerankConfig = new() { TopN = 1, Type = Retrievers::Type.Bedrock },
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.RerankTopN);
        Assert.False(parameters.RawBodyData.ContainsKey("rerank_top_n"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Retrievers::RetrieverSearchParams
        {
            Query = "x",
            Mode = Retrievers::CompositeRetrievalMode.Full,
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
            RerankConfig = new() { TopN = 1, Type = Retrievers::Type.Bedrock },

            OrganizationID = null,
            ProjectID = null,
            RerankTopN = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.RerankTopN);
        Assert.True(parameters.RawBodyData.ContainsKey("rerank_top_n"));
    }

    [Fact]
    public void Url_Works()
    {
        Retrievers::RetrieverSearchParams parameters = new()
        {
            Query = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/retrievers/retrieve?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Retrievers::RetrieverSearchParams
        {
            Query = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Mode = Retrievers::CompositeRetrievalMode.Full,
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
            RerankConfig = new() { TopN = 1, Type = Retrievers::Type.Bedrock },
            RerankTopN = 0,
        };

        Retrievers::RetrieverSearchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
