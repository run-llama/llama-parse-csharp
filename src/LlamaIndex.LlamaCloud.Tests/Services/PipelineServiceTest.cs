using System.Threading.Tasks;

namespace LlamaIndex.LlamaCloud.Tests.Services;

public class PipelineServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var pipeline = await this.client.Pipelines.Create(
            new() { Name = "x" },
            TestContext.Current.CancellationToken
        );
        pipeline.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var pipeline = await this.client.Pipelines.Retrieve(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { Query = "x" },
            TestContext.Current.CancellationToken
        );
        pipeline.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var pipeline = await this.client.Pipelines.Update(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        pipeline.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var pipelines = await this.client.Pipelines.List(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in pipelines)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Pipelines.Delete(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var pipeline = await this.client.Pipelines.Get(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        pipeline.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetStatus_Works()
    {
        var managedIngestionStatusResponse = await this.client.Pipelines.GetStatus(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        managedIngestionStatusResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Upsert_Works()
    {
        var pipeline = await this.client.Pipelines.Upsert(
            new() { Name = "x" },
            TestContext.Current.CancellationToken
        );
        pipeline.Validate();
    }
}
