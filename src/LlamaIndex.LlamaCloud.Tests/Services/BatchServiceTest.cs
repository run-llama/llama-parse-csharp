using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Models.Batches;

namespace LlamaIndex.LlamaCloud.Tests.Services;

public class BatchServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var batch = await this.client.Batches.Create(
            new()
            {
                Config = new(
                    new Job() { ConfigurationID = "cfg-PARSE_AGENTIC", Type = Type.ParseV2 }
                ),
                SourceDirectoryID = "dir-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            },
            TestContext.Current.CancellationToken
        );
        batch.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Batches.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Cancel_Works()
    {
        var response = await this.client.Batches.Cancel(
            "batch_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var batch = await this.client.Batches.Get(
            "batch_id",
            new(),
            TestContext.Current.CancellationToken
        );
        batch.Validate();
    }
}
