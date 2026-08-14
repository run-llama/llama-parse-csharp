using System.Threading.Tasks;

namespace LlamaIndex.LlamaCloud.Tests.Services.Beta;

public class DirectoryServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var directory = await this.client.Beta.Directories.Create(
            new() { Name = "x" },
            TestContext.Current.CancellationToken
        );
        directory.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var directory = await this.client.Beta.Directories.Update(
            "directory_id",
            new(),
            TestContext.Current.CancellationToken
        );
        directory.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Directories.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Beta.Directories.Delete(
            "directory_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var directory = await this.client.Beta.Directories.Get(
            "directory_id",
            new(),
            TestContext.Current.CancellationToken
        );
        directory.Validate();
    }
}
