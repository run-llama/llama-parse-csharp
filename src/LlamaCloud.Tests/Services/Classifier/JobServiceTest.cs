using System.Threading.Tasks;

namespace LlamaCloud.Tests.Services.Classifier;

public class JobServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var classifyJob = await this.client.Classifier.Jobs.Create(
            new()
            {
                FileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        classifyJob.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Classifier.Jobs.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var classifyJob = await this.client.Classifier.Jobs.Get(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        classifyJob.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetResults_Works()
    {
        var response = await this.client.Classifier.Jobs.GetResults(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
