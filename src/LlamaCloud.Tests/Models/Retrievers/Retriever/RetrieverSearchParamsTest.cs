using System;
using LlamaCloud.Core;
using LlamaCloud.Models.Retrievers.Retriever;
using Retrievers = LlamaCloud.Models.Retrievers;

namespace LlamaCloud.Tests.Models.Retrievers.Retriever;

public class RetrieverSearchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RetrieverSearchParams
        {
            RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Query = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Mode = Retrievers::CompositeRetrievalMode.Full,
            RerankConfig = new() { TopN = 1, Type = Retrievers::Type.Bedrock },
            RerankTopN = 0,
        };

        string expectedRetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedQuery = "x";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, Retrievers::CompositeRetrievalMode> expectedMode =
            Retrievers::CompositeRetrievalMode.Full;
        Retrievers::ReRankConfig expectedRerankConfig = new()
        {
            TopN = 1,
            Type = Retrievers::Type.Bedrock,
        };
        long expectedRerankTopN = 0;

        Assert.Equal(expectedRetrieverID, parameters.RetrieverID);
        Assert.Equal(expectedQuery, parameters.Query);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedMode, parameters.Mode);
        Assert.Equal(expectedRerankConfig, parameters.RerankConfig);
        Assert.Equal(expectedRerankTopN, parameters.RerankTopN);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RetrieverSearchParams
        {
            RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Query = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RerankTopN = 0,
        };

        Assert.Null(parameters.Mode);
        Assert.False(parameters.RawBodyData.ContainsKey("mode"));
        Assert.Null(parameters.RerankConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("rerank_config"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RetrieverSearchParams
        {
            RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Query = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RerankTopN = 0,

            // Null should be interpreted as omitted for these properties
            Mode = null,
            RerankConfig = null,
        };

        Assert.Null(parameters.Mode);
        Assert.False(parameters.RawBodyData.ContainsKey("mode"));
        Assert.Null(parameters.RerankConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("rerank_config"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RetrieverSearchParams
        {
            RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Query = "x",
            Mode = Retrievers::CompositeRetrievalMode.Full,
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
        var parameters = new RetrieverSearchParams
        {
            RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Query = "x",
            Mode = Retrievers::CompositeRetrievalMode.Full,
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
        RetrieverSearchParams parameters = new()
        {
            RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Query = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/retrievers/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/retrieve?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RetrieverSearchParams
        {
            RetrieverID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Query = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Mode = Retrievers::CompositeRetrievalMode.Full,
            RerankConfig = new() { TopN = 1, Type = Retrievers::Type.Bedrock },
            RerankTopN = 0,
        };

        RetrieverSearchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
