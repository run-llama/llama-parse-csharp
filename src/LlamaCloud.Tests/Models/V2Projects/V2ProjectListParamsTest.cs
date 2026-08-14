using System;
using LlamaCloud.Models.V2Projects;

namespace LlamaCloud.Tests.Models.V2Projects;

public class V2ProjectListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V2ProjectListParams
        {
            Name = "name",
            OrganizationID = "organization_id",
            PageSize = 0,
            PageToken = "page_token",
        };

        string expectedName = "name";
        string expectedOrganizationID = "organization_id";
        long expectedPageSize = 0;
        string expectedPageToken = "page_token";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedPageToken, parameters.PageToken);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V2ProjectListParams { };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawQueryData.ContainsKey("name"));
        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.False(parameters.RawQueryData.ContainsKey("page_token"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new V2ProjectListParams
        {
            Name = null,
            OrganizationID = null,
            PageSize = null,
            PageToken = null,
        };

        Assert.Null(parameters.Name);
        Assert.True(parameters.RawQueryData.ContainsKey("name"));
        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.PageSize);
        Assert.True(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.True(parameters.RawQueryData.ContainsKey("page_token"));
    }

    [Fact]
    public void Url_Works()
    {
        V2ProjectListParams parameters = new()
        {
            Name = "name",
            OrganizationID = "organization_id",
            PageSize = 0,
            PageToken = "page_token",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v2/projects?name=name&organization_id=organization_id&page_size=0&page_token=page_token"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V2ProjectListParams
        {
            Name = "name",
            OrganizationID = "organization_id",
            PageSize = 0,
            PageToken = "page_token",
        };

        V2ProjectListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
