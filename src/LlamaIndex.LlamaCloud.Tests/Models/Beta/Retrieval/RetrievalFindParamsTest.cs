using System;
using LlamaIndex.LlamaCloud.Models.Beta.Retrieval;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.Retrieval;

public class RetrievalFindParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RetrievalFindParams
        {
            IndexID = "idx-abc123",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",
            FileNameContains = "file_name_contains",
            PageSize = 0,
            PageToken = "page_token",
        };

        string expectedIndexID = "idx-abc123";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedFileName = "file_name";
        string expectedFileNameContains = "file_name_contains";
        long expectedPageSize = 0;
        string expectedPageToken = "page_token";

        Assert.Equal(expectedIndexID, parameters.IndexID);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedFileName, parameters.FileName);
        Assert.Equal(expectedFileNameContains, parameters.FileNameContains);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedPageToken, parameters.PageToken);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RetrievalFindParams { IndexID = "idx-abc123" };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.FileName);
        Assert.False(parameters.RawBodyData.ContainsKey("file_name"));
        Assert.Null(parameters.FileNameContains);
        Assert.False(parameters.RawBodyData.ContainsKey("file_name_contains"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawBodyData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.False(parameters.RawBodyData.ContainsKey("page_token"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RetrievalFindParams
        {
            IndexID = "idx-abc123",

            OrganizationID = null,
            ProjectID = null,
            FileName = null,
            FileNameContains = null,
            PageSize = null,
            PageToken = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.FileName);
        Assert.True(parameters.RawBodyData.ContainsKey("file_name"));
        Assert.Null(parameters.FileNameContains);
        Assert.True(parameters.RawBodyData.ContainsKey("file_name_contains"));
        Assert.Null(parameters.PageSize);
        Assert.True(parameters.RawBodyData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.True(parameters.RawBodyData.ContainsKey("page_token"));
    }

    [Fact]
    public void Url_Works()
    {
        RetrievalFindParams parameters = new()
        {
            IndexID = "idx-abc123",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/retrieval/files/find?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RetrievalFindParams
        {
            IndexID = "idx-abc123",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",
            FileNameContains = "file_name_contains",
            PageSize = 0,
            PageToken = "page_token",
        };

        RetrievalFindParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
