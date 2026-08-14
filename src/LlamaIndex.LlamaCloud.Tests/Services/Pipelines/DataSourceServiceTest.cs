using System.Threading.Tasks;

namespace LlamaIndex.LlamaCloud.Tests.Services.Pipelines;

public class DataSourceServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var pipelineDataSource = await this.client.Pipelines.DataSources.Update(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" },
            TestContext.Current.CancellationToken
        );
        pipelineDataSource.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetDataSources_Works()
    {
        var pipelineDataSources = await this.client.Pipelines.DataSources.GetDataSources(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in pipelineDataSources)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetStatus_Works()
    {
        var managedIngestionStatusResponse = await this.client.Pipelines.DataSources.GetStatus(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" },
            TestContext.Current.CancellationToken
        );
        managedIngestionStatusResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Sync_Works()
    {
        var pipeline = await this.client.Pipelines.DataSources.Sync(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" },
            TestContext.Current.CancellationToken
        );
        pipeline.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UpdateDataSources_Works()
    {
        var pipelineDataSources = await this.client.Pipelines.DataSources.UpdateDataSources(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new()
            {
                Body =
                [
                    new()
                    {
                        DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        SyncInterval = 0,
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        foreach (var item in pipelineDataSources)
        {
            item.Validate();
        }
    }
}
