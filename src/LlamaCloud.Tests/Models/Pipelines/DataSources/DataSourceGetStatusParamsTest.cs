using System;
using LlamaCloud.Models.Pipelines.DataSources;

namespace LlamaCloud.Tests.Models.Pipelines.DataSources;

public class DataSourceGetStatusParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DataSourceGetStatusParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedPipelineID, parameters.PipelineID);
        Assert.Equal(expectedDataSourceID, parameters.DataSourceID);
    }

    [Fact]
    public void Url_Works()
    {
        DataSourceGetStatusParams parameters = new()
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/pipelines/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/data-sources/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/status"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DataSourceGetStatusParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        DataSourceGetStatusParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
