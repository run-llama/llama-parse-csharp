using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Models.Pipelines.Documents;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines.Documents;

public class DocumentUpsertParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DocumentUpsertParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Body =
            [
                new()
                {
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Text = "text",
                    ID = "id",
                    ExcludedEmbedMetadataKeys = ["string"],
                    ExcludedLlmMetadataKeys = ["string"],
                    PagePositions = [0],
                },
            ],
        };

        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<CloudDocumentCreate> expectedBody =
        [
            new()
            {
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Text = "text",
                ID = "id",
                ExcludedEmbedMetadataKeys = ["string"],
                ExcludedLlmMetadataKeys = ["string"],
                PagePositions = [0],
            },
        ];

        Assert.Equal(expectedPipelineID, parameters.PipelineID);
        Assert.Equal(expectedBody.Count, parameters.Body.Count);
        for (int i = 0; i < expectedBody.Count; i++)
        {
            Assert.Equal(expectedBody[i], parameters.Body[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        DocumentUpsertParams parameters = new()
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Body =
            [
                new()
                {
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Text = "text",
                    ID = "id",
                    ExcludedEmbedMetadataKeys = ["string"],
                    ExcludedLlmMetadataKeys = ["string"],
                    PagePositions = [0],
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/pipelines/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/documents"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DocumentUpsertParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Body =
            [
                new()
                {
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Text = "text",
                    ID = "id",
                    ExcludedEmbedMetadataKeys = ["string"],
                    ExcludedLlmMetadataKeys = ["string"],
                    PagePositions = [0],
                },
            ],
        };

        DocumentUpsertParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
