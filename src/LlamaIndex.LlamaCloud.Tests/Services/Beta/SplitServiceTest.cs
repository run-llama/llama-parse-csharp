using System.Threading.Tasks;

namespace LlamaIndex.LlamaCloud.Tests.Services.Beta;

public class SplitServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var split = await this.client.Beta.Split.Create(
            new()
            {
                DocumentInput = new() { Type = "type", Value = "value" },
            },
            TestContext.Current.CancellationToken
        );
        split.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Split.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var split = await this.client.Beta.Split.Get(
            "split_job_id",
            new(),
            TestContext.Current.CancellationToken
        );
        split.Validate();
    }
}
