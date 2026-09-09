using System;
using System.Collections.Generic;
using LlamaCloud.Models.Pipelines.DataSources;

namespace LlamaCloud.Tests.Models.Pipelines.DataSources;

public class DataSourceSyncParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DataSourceSyncParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PipelineFileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
        };

        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<string> expectedPipelineFileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"];

        Assert.Equal(expectedPipelineID, parameters.PipelineID);
        Assert.Equal(expectedDataSourceID, parameters.DataSourceID);
        Assert.NotNull(parameters.PipelineFileIds);
        Assert.Equal(expectedPipelineFileIds.Count, parameters.PipelineFileIds.Count);
        for (int i = 0; i < expectedPipelineFileIds.Count; i++)
        {
            Assert.Equal(expectedPipelineFileIds[i], parameters.PipelineFileIds[i]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DataSourceSyncParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.PipelineFileIds);
        Assert.False(parameters.RawBodyData.ContainsKey("pipeline_file_ids"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new DataSourceSyncParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            PipelineFileIds = null,
        };

        Assert.Null(parameters.PipelineFileIds);
        Assert.True(parameters.RawBodyData.ContainsKey("pipeline_file_ids"));
    }

    [Fact]
    public void Url_Works()
    {
        DataSourceSyncParams parameters = new()
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/pipelines/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/data-sources/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/sync"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DataSourceSyncParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PipelineFileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
        };

        DataSourceSyncParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
