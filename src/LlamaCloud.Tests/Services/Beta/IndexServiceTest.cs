using System.Threading.Tasks;

namespace LlamaCloud.Tests.Services.Beta;

public class IndexServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var index = await this.client.Beta.Indexes.Create(
            new() { SourceDirectoryID = "dir-abc123" },
            TestContext.Current.CancellationToken
        );
        index.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Indexes.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Beta.Indexes.Delete(
            "index_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var index = await this.client.Beta.Indexes.Get(
            "index_id",
            new(),
            TestContext.Current.CancellationToken
        );
        index.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Sync_Works()
    {
        await this.client.Beta.Indexes.Sync(
            "index_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
