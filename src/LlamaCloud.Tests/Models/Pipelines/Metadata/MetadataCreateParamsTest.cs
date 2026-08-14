using System;
using System.Text;
using LlamaCloud.Core;
using LlamaCloud.Models.Pipelines.Metadata;

namespace LlamaCloud.Tests.Models.Pipelines.Metadata;

public class MetadataCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent uploadFile = Encoding.UTF8.GetBytes("Example data");

        var parameters = new MetadataCreateParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UploadFile = uploadFile,
        };

        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        BinaryContent expectedUploadFile = uploadFile;

        Assert.Equal(expectedPipelineID, parameters.PipelineID);
        Assert.Equal(expectedUploadFile, parameters.UploadFile);
    }

    [Fact]
    public void Url_Works()
    {
        MetadataCreateParams parameters = new()
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UploadFile = Encoding.UTF8.GetBytes("Example data"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/pipelines/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/metadata"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MetadataCreateParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UploadFile = Encoding.UTF8.GetBytes("Example data"),
        };

        MetadataCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
