using System;
using LlamaCloud.Models.Pipelines.Documents;

namespace LlamaCloud.Tests.Models.Pipelines.Documents;

public class DocumentGetStatusParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DocumentGetStatusParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DocumentID = "document_id",
        };

        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDocumentID = "document_id";

        Assert.Equal(expectedPipelineID, parameters.PipelineID);
        Assert.Equal(expectedDocumentID, parameters.DocumentID);
    }

    [Fact]
    public void Url_Works()
    {
        DocumentGetStatusParams parameters = new()
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DocumentID = "document_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/pipelines/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/documents/document_id/status"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DocumentGetStatusParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DocumentID = "document_id",
        };

        DocumentGetStatusParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
