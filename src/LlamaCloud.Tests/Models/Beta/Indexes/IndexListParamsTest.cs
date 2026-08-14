using System;
using LlamaCloud.Models.Beta.Indexes;

namespace LlamaCloud.Tests.Models.Beta.Indexes;

public class IndexListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IndexListParams
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 0,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceDirectoryID = "source_directory_id",
        };

        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedPageSize = 0;
        string expectedPageToken = "page_token";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedSourceDirectoryID = "source_directory_id";

        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedPageToken, parameters.PageToken);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedSourceDirectoryID, parameters.SourceDirectoryID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IndexListParams { };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.False(parameters.RawQueryData.ContainsKey("page_token"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.SourceDirectoryID);
        Assert.False(parameters.RawQueryData.ContainsKey("source_directory_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new IndexListParams
        {
            OrganizationID = null,
            PageSize = null,
            PageToken = null,
            ProjectID = null,
            SourceDirectoryID = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.PageSize);
        Assert.True(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.True(parameters.RawQueryData.ContainsKey("page_token"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.SourceDirectoryID);
        Assert.True(parameters.RawQueryData.ContainsKey("source_directory_id"));
    }

    [Fact]
    public void Url_Works()
    {
        IndexListParams parameters = new()
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 0,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceDirectoryID = "source_directory_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/indexes?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&page_size=0&page_token=page_token&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&source_directory_id=source_directory_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IndexListParams
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 0,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceDirectoryID = "source_directory_id",
        };

        IndexListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
