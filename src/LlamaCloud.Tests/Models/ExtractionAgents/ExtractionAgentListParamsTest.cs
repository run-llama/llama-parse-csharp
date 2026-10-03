using System;
using LlamaCloud.Models.ExtractionAgents;

namespace LlamaCloud.Tests.Models.ExtractionAgents;

public class ExtractionAgentListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExtractionAgentListParams
        {
            IncludeDefault = true,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 1,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        bool expectedIncludeDefault = true;
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedPageSize = 1;
        string expectedPageToken = "page_token";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedIncludeDefault, parameters.IncludeDefault);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedPageToken, parameters.PageToken);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExtractionAgentListParams
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.IncludeDefault);
        Assert.False(parameters.RawQueryData.ContainsKey("include_default"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExtractionAgentListParams
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            IncludeDefault = null,
            PageSize = null,
        };

        Assert.Null(parameters.IncludeDefault);
        Assert.False(parameters.RawQueryData.ContainsKey("include_default"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExtractionAgentListParams { IncludeDefault = true, PageSize = 1 };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.PageToken);
        Assert.False(parameters.RawQueryData.ContainsKey("page_token"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ExtractionAgentListParams
        {
            IncludeDefault = true,
            PageSize = 1,

            OrganizationID = null,
            PageToken = null,
            ProjectID = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.PageToken);
        Assert.True(parameters.RawQueryData.ContainsKey("page_token"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void Url_Works()
    {
        ExtractionAgentListParams parameters = new()
        {
            IncludeDefault = true,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 1,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/extraction-agents?include_default=true&organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&page_size=1&page_token=page_token&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExtractionAgentListParams
        {
            IncludeDefault = true,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 1,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ExtractionAgentListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
