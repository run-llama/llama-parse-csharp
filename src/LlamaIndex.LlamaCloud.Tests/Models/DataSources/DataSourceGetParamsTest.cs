using System;
using LlamaIndex.LlamaCloud.Models.DataSources;

namespace LlamaIndex.LlamaCloud.Tests.Models.DataSources;

public class DataSourceGetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DataSourceGetParams
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedDataSourceID, parameters.DataSourceID);
    }

    [Fact]
    public void Url_Works()
    {
        DataSourceGetParams parameters = new()
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/data-sources/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DataSourceGetParams
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        DataSourceGetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
