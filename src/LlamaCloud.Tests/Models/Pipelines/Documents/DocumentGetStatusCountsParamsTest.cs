using System;
using LlamaCloud.Models.Pipelines.Documents;

namespace LlamaCloud.Tests.Models.Pipelines.Documents;

public class DocumentGetStatusCountsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DocumentGetStatusCountsParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyDirectUpload = true,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        bool expectedOnlyDirectUpload = true;
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedPipelineID, parameters.PipelineID);
        Assert.Equal(expectedDataSourceID, parameters.DataSourceID);
        Assert.Equal(expectedFileID, parameters.FileID);
        Assert.Equal(expectedOnlyDirectUpload, parameters.OnlyDirectUpload);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DocumentGetStatusCountsParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.OnlyDirectUpload);
        Assert.False(parameters.RawQueryData.ContainsKey("only_direct_upload"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DocumentGetStatusCountsParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            OnlyDirectUpload = null,
        };

        Assert.Null(parameters.OnlyDirectUpload);
        Assert.False(parameters.RawQueryData.ContainsKey("only_direct_upload"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DocumentGetStatusCountsParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyDirectUpload = true,
        };

        Assert.Null(parameters.DataSourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("data_source_id"));
        Assert.Null(parameters.FileID);
        Assert.False(parameters.RawQueryData.ContainsKey("file_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new DocumentGetStatusCountsParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyDirectUpload = true,

            DataSourceID = null,
            FileID = null,
            ProjectID = null,
        };

        Assert.Null(parameters.DataSourceID);
        Assert.True(parameters.RawQueryData.ContainsKey("data_source_id"));
        Assert.Null(parameters.FileID);
        Assert.True(parameters.RawQueryData.ContainsKey("file_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void Url_Works()
    {
        DocumentGetStatusCountsParams parameters = new()
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyDirectUpload = true,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/pipelines/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/documents/status-counts?data_source_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&file_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&only_direct_upload=true&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DocumentGetStatusCountsParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyDirectUpload = true,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        DocumentGetStatusCountsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
