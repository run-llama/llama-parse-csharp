using System.Threading.Tasks;

namespace LlamaIndex.LlamaCloud.Tests.Services;

public class SplitServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var split = await this.client.Split.Create(
            new() { FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee" },
            TestContext.Current.CancellationToken
        );
        split.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Split.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Split.Delete(
            "split_job_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Cancel_Works()
    {
        var response = await this.client.Split.Cancel(
            "split_job_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var split = await this.client.Split.Get(
            "split_job_id",
            new(),
            TestContext.Current.CancellationToken
        );
        split.Validate();
    }
}
