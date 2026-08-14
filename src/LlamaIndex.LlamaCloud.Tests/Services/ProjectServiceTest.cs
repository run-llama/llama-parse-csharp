using System.Threading.Tasks;

namespace LlamaIndex.LlamaCloud.Tests.Services;

public class ProjectServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var projects = await this.client.Projects.List(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in projects)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var project = await this.client.Projects.Get(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        project.Validate();
    }
}
