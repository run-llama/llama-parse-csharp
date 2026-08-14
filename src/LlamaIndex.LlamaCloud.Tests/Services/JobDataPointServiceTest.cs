using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Models.JobDataPoints;

namespace LlamaIndex.LlamaCloud.Tests.Services;

public class JobDataPointServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.JobDataPoints.List(
            new() { JobType = JobType.Parse },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
