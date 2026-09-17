using System;
using LlamaCloud.Models.Pipelines.Files;

namespace LlamaCloud.Tests.Models.Pipelines.Files;

public class FileGetStatusCountsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileGetStatusCountsParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyManuallyUploaded = true,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        bool expectedOnlyManuallyUploaded = true;
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedPipelineID, parameters.PipelineID);
        Assert.Equal(expectedDataSourceID, parameters.DataSourceID);
        Assert.Equal(expectedOnlyManuallyUploaded, parameters.OnlyManuallyUploaded);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileGetStatusCountsParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.OnlyManuallyUploaded);
        Assert.False(parameters.RawQueryData.ContainsKey("only_manually_uploaded"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FileGetStatusCountsParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            OnlyManuallyUploaded = null,
        };

        Assert.Null(parameters.OnlyManuallyUploaded);
        Assert.False(parameters.RawQueryData.ContainsKey("only_manually_uploaded"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileGetStatusCountsParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyManuallyUploaded = true,
        };

        Assert.Null(parameters.DataSourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("data_source_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new FileGetStatusCountsParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyManuallyUploaded = true,

            DataSourceID = null,
            ProjectID = null,
        };

        Assert.Null(parameters.DataSourceID);
        Assert.True(parameters.RawQueryData.ContainsKey("data_source_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void Url_Works()
    {
        FileGetStatusCountsParams parameters = new()
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyManuallyUploaded = true,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/pipelines/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/files/status-counts?data_source_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&only_manually_uploaded=true&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileGetStatusCountsParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyManuallyUploaded = true,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        FileGetStatusCountsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
