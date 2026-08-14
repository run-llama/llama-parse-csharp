using System.Threading.Tasks;

namespace LlamaCloud.Tests.Services;

public class ClassifyServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var classify = await this.client.Classify.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        classify.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Classify.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Cancel_Works()
    {
        var response = await this.client.Classify.Cancel(
            "job_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var classify = await this.client.Classify.Get(
            "job_id",
            new(),
            TestContext.Current.CancellationToken
        );
        classify.Validate();
    }
}
