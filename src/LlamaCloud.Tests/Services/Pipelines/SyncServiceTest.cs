using System.Threading.Tasks;

namespace LlamaCloud.Tests.Services.Pipelines;

public class SyncServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var pipeline = await this.client.Pipelines.Sync.Create(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        pipeline.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Cancel_Works()
    {
        var pipeline = await this.client.Pipelines.Sync.Cancel(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        pipeline.Validate();
    }
}
