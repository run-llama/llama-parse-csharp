using System;
using LlamaIndex.LlamaCloud.Models.Projects;

namespace LlamaIndex.LlamaCloud.Tests.Models.Projects;

public class ProjectListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProjectListParams
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectName = "project_name",
        };

        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectName = "project_name";

        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectName, parameters.ProjectName);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProjectListParams { };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectName);
        Assert.False(parameters.RawQueryData.ContainsKey("project_name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ProjectListParams { OrganizationID = null, ProjectName = null };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectName);
        Assert.True(parameters.RawQueryData.ContainsKey("project_name"));
    }

    [Fact]
    public void Url_Works()
    {
        ProjectListParams parameters = new()
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectName = "project_name",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/projects?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_name=project_name"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProjectListParams
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectName = "project_name",
        };

        ProjectListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
