using System.Threading.Tasks;

namespace LlamaCloud.Tests.Services;

public class V2ProjectServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V2Projects.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var v2Project = await this.client.V2Projects.Get(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        v2Project.Validate();
    }
}
