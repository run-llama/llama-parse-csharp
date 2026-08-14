using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using LlamaCloud.Models.Pipelines.Files;

namespace LlamaCloud.Tests.Services.Pipelines;

public class FileServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var pipelineFiles = await this.client.Pipelines.Files.Create(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new()
            {
                Body =
                [
                    new()
                    {
                        FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CustomMetadata = new Dictionary<string, CustomMetadata?>()
                        {
                            {
                                "foo",
                                new(
                                    new Dictionary<string, JsonElement>()
                                    {
                                        { "foo", JsonSerializer.SerializeToElement("bar") },
                                    }
                                )
                            },
                        },
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        foreach (var item in pipelineFiles)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var pipelineFile = await this.client.Pipelines.Files.Update(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" },
            TestContext.Current.CancellationToken
        );
        pipelineFile.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Pipelines.Files.List(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Pipelines.Files.Delete(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetStatus_Works()
    {
        var managedIngestionStatusResponse = await this.client.Pipelines.Files.GetStatus(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" },
            TestContext.Current.CancellationToken
        );
        managedIngestionStatusResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetStatusCounts_Works()
    {
        var response = await this.client.Pipelines.Files.GetStatusCounts(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
