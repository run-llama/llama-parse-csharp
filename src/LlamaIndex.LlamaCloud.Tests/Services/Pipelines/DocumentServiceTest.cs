using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace LlamaIndex.LlamaCloud.Tests.Services.Pipelines;

public class DocumentServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var cloudDocuments = await this.client.Pipelines.Documents.Create(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new()
            {
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
            },
            TestContext.Current.CancellationToken
        );
        foreach (var item in cloudDocuments)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Pipelines.Documents.List(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Pipelines.Documents.Delete(
            "document_id",
            new() { PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var cloudDocument = await this.client.Pipelines.Documents.Get(
            "document_id",
            new() { PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" },
            TestContext.Current.CancellationToken
        );
        cloudDocument.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetChunks_Works()
    {
        var textNodes = await this.client.Pipelines.Documents.GetChunks(
            "document_id",
            new() { PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in textNodes)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetStatus_Works()
    {
        var managedIngestionStatusResponse = await this.client.Pipelines.Documents.GetStatus(
            "document_id",
            new() { PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" },
            TestContext.Current.CancellationToken
        );
        managedIngestionStatusResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetStatusCounts_Works()
    {
        var response = await this.client.Pipelines.Documents.GetStatusCounts(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Sync_Works()
    {
        await this.client.Pipelines.Documents.Sync(
            "document_id",
            new() { PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Upsert_Works()
    {
        var cloudDocuments = await this.client.Pipelines.Documents.Upsert(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new()
            {
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
            },
            TestContext.Current.CancellationToken
        );
        foreach (var item in cloudDocuments)
        {
            item.Validate();
        }
    }
}
