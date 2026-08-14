using System;
using LlamaCloud.Models.Pipelines;

namespace LlamaCloud.Tests.Models.Pipelines;

public class PipelineGetStatusParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PipelineGetStatusParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FullDetails = true,
        };

        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        bool expectedFullDetails = true;

        Assert.Equal(expectedPipelineID, parameters.PipelineID);
        Assert.Equal(expectedFullDetails, parameters.FullDetails);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PipelineGetStatusParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.FullDetails);
        Assert.False(parameters.RawQueryData.ContainsKey("full_details"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PipelineGetStatusParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            FullDetails = null,
        };

        Assert.Null(parameters.FullDetails);
        Assert.True(parameters.RawQueryData.ContainsKey("full_details"));
    }

    [Fact]
    public void Url_Works()
    {
        PipelineGetStatusParams parameters = new()
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FullDetails = true,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/pipelines/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/status?full_details=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PipelineGetStatusParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FullDetails = true,
        };

        PipelineGetStatusParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
