using System;
using LlamaIndex.LlamaCloud.Models.Beta.Retrieval;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.Retrieval;

public class RetrievalGrepParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RetrievalGrepParams
        {
            FileID = "file_id",
            IndexID = "idx-abc123",
            Pattern = "revenue|profit",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ContextChars = 0,
            PageSize = 0,
            PageToken = "page_token",
        };

        string expectedFileID = "file_id";
        string expectedIndexID = "idx-abc123";
        string expectedPattern = "revenue|profit";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedContextChars = 0;
        long expectedPageSize = 0;
        string expectedPageToken = "page_token";

        Assert.Equal(expectedFileID, parameters.FileID);
        Assert.Equal(expectedIndexID, parameters.IndexID);
        Assert.Equal(expectedPattern, parameters.Pattern);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedContextChars, parameters.ContextChars);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedPageToken, parameters.PageToken);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RetrievalGrepParams
        {
            FileID = "file_id",
            IndexID = "idx-abc123",
            Pattern = "revenue|profit",
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.ContextChars);
        Assert.False(parameters.RawBodyData.ContainsKey("context_chars"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawBodyData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.False(parameters.RawBodyData.ContainsKey("page_token"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RetrievalGrepParams
        {
            FileID = "file_id",
            IndexID = "idx-abc123",
            Pattern = "revenue|profit",

            OrganizationID = null,
            ProjectID = null,
            ContextChars = null,
            PageSize = null,
            PageToken = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.ContextChars);
        Assert.True(parameters.RawBodyData.ContainsKey("context_chars"));
        Assert.Null(parameters.PageSize);
        Assert.True(parameters.RawBodyData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.True(parameters.RawBodyData.ContainsKey("page_token"));
    }

    [Fact]
    public void Url_Works()
    {
        RetrievalGrepParams parameters = new()
        {
            FileID = "file_id",
            IndexID = "idx-abc123",
            Pattern = "revenue|profit",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/retrieval/files/grep?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RetrievalGrepParams
        {
            FileID = "file_id",
            IndexID = "idx-abc123",
            Pattern = "revenue|profit",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ContextChars = 0,
            PageSize = 0,
            PageToken = "page_token",
        };

        RetrievalGrepParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
