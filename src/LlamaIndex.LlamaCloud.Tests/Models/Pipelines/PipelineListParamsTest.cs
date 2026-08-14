using System;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines;

public class PipelineListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PipelineListParams
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PipelineName = "pipeline_name",
            PipelineType = PipelineType.Managed,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectName = "project_name",
        };

        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedPipelineName = "pipeline_name";
        ApiEnum<string, PipelineType> expectedPipelineType = PipelineType.Managed;
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectName = "project_name";

        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedPipelineName, parameters.PipelineName);
        Assert.Equal(expectedPipelineType, parameters.PipelineType);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedProjectName, parameters.ProjectName);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PipelineListParams { };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.PipelineName);
        Assert.False(parameters.RawQueryData.ContainsKey("pipeline_name"));
        Assert.Null(parameters.PipelineType);
        Assert.False(parameters.RawQueryData.ContainsKey("pipeline_type"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.ProjectName);
        Assert.False(parameters.RawQueryData.ContainsKey("project_name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PipelineListParams
        {
            OrganizationID = null,
            PipelineName = null,
            PipelineType = null,
            ProjectID = null,
            ProjectName = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.PipelineName);
        Assert.True(parameters.RawQueryData.ContainsKey("pipeline_name"));
        Assert.Null(parameters.PipelineType);
        Assert.True(parameters.RawQueryData.ContainsKey("pipeline_type"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.ProjectName);
        Assert.True(parameters.RawQueryData.ContainsKey("project_name"));
    }

    [Fact]
    public void Url_Works()
    {
        PipelineListParams parameters = new()
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PipelineName = "pipeline_name",
            PipelineType = PipelineType.Managed,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectName = "project_name",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/pipelines?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&pipeline_name=pipeline_name&pipeline_type=MANAGED&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_name=project_name"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PipelineListParams
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PipelineName = "pipeline_name",
            PipelineType = PipelineType.Managed,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectName = "project_name",
        };

        PipelineListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
