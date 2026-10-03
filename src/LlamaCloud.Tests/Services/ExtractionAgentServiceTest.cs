using System.Threading.Tasks;

namespace LlamaCloud.Tests.Services;

public class ExtractionAgentServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.ExtractionAgents.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
