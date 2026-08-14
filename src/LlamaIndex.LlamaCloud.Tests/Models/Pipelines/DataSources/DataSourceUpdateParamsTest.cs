using System;
using LlamaIndex.LlamaCloud.Models.Pipelines.DataSources;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines.DataSources;

public class DataSourceUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DataSourceUpdateParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SyncInterval = 0,
        };

        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        double expectedSyncInterval = 0;

        Assert.Equal(expectedPipelineID, parameters.PipelineID);
        Assert.Equal(expectedDataSourceID, parameters.DataSourceID);
        Assert.Equal(expectedSyncInterval, parameters.SyncInterval);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DataSourceUpdateParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.SyncInterval);
        Assert.False(parameters.RawBodyData.ContainsKey("sync_interval"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new DataSourceUpdateParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            SyncInterval = null,
        };

        Assert.Null(parameters.SyncInterval);
        Assert.True(parameters.RawBodyData.ContainsKey("sync_interval"));
    }

    [Fact]
    public void Url_Works()
    {
        DataSourceUpdateParams parameters = new()
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/pipelines/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/data-sources/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DataSourceUpdateParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SyncInterval = 0,
        };

        DataSourceUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
