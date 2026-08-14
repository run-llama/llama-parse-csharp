using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Models.Parsing;

namespace LlamaIndex.LlamaCloud.Tests.Services;

public class ParsingServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var parsing = await this.client.Parsing.Create(
            new() { Tier = Tier.Fast, Version = Version.Latest },
            TestContext.Current.CancellationToken
        );
        parsing.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Parsing.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Cancel_Works()
    {
        var response = await this.client.Parsing.Cancel(
            "job_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var parsing = await this.client.Parsing.Get(
            "job_id",
            new(),
            TestContext.Current.CancellationToken
        );
        parsing.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListVersions_Works()
    {
        var response = await this.client.Parsing.ListVersions(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
