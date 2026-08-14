using System;
using LlamaCloud.Models.Pipelines.DataSources;

namespace LlamaCloud.Tests.Models.Pipelines.DataSources;

public class DataSourceGetDataSourcesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DataSourceGetDataSourcesParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedPipelineID, parameters.PipelineID);
    }

    [Fact]
    public void Url_Works()
    {
        DataSourceGetDataSourcesParams parameters = new()
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/pipelines/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/data-sources"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DataSourceGetDataSourcesParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        DataSourceGetDataSourcesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
