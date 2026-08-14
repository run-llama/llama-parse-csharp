using System;
using LlamaIndex.LlamaCloud.Models.DataSinks;

namespace LlamaIndex.LlamaCloud.Tests.Models.DataSinks;

public class DataSinkDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DataSinkDeleteParams
        {
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedDataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedDataSinkID, parameters.DataSinkID);
    }

    [Fact]
    public void Url_Works()
    {
        DataSinkDeleteParams parameters = new()
        {
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/data-sinks/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DataSinkDeleteParams
        {
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        DataSinkDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
