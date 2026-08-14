using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Models.Pipelines;
using LlamaIndex.LlamaCloud.Models.Retrievers;

namespace LlamaIndex.LlamaCloud.Tests.Models.Retrievers;

public class RetrieverUpsertParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RetrieverUpsertParams
        {
            Name = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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

        string expectedName = "x";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
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

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.NotNull(parameters.Pipelines);
        Assert.Equal(expectedPipelines.Count, parameters.Pipelines.Count);
        for (int i = 0; i < expectedPipelines.Count; i++)
        {
            Assert.Equal(expectedPipelines[i], parameters.Pipelines[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RetrieverUpsertParams
        {
            Name = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.Pipelines);
        Assert.False(parameters.RawBodyData.ContainsKey("pipelines"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RetrieverUpsertParams
        {
            Name = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            Pipelines = null,
        };

        Assert.Null(parameters.Pipelines);
        Assert.False(parameters.RawBodyData.ContainsKey("pipelines"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RetrieverUpsertParams
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

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RetrieverUpsertParams
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

            OrganizationID = null,
            ProjectID = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void Url_Works()
    {
        RetrieverUpsertParams parameters = new()
        {
            Name = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/retrievers?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RetrieverUpsertParams
        {
            Name = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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

        RetrieverUpsertParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
