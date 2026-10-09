using System.Threading.Tasks;

namespace LlamaCloud.Tests.Services.Alpha;

public class VerifyServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var verify = await this.client.Alpha.Verify.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        verify.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Alpha.Verify.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Cancel_Works()
    {
        var response = await this.client.Alpha.Verify.Cancel(
            "job_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var verify = await this.client.Alpha.Verify.Get(
            "job_id",
            new(),
            TestContext.Current.CancellationToken
        );
        verify.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetDetails_Works()
    {
        var response = await this.client.Alpha.Verify.GetDetails(
            "job_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
