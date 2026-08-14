using System.Threading.Tasks;

namespace LlamaIndex.LlamaCloud.Tests.Services.Beta;

public class RetrievalServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var retrieval = await this.client.Beta.Retrieval.Retrieve(
            new() { IndexID = "idx-abc123", Query = "What are the key findings?" },
            TestContext.Current.CancellationToken
        );
        retrieval.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Find_Works()
    {
        var page = await this.client.Beta.Retrieval.Find(
            new() { IndexID = "idx-abc123" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Grep_Works()
    {
        var page = await this.client.Beta.Retrieval.Grep(
            new()
            {
                FileID = "file_id",
                IndexID = "idx-abc123",
                Pattern = "revenue|profit",
            },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Read_Works()
    {
        var response = await this.client.Beta.Retrieval.Read(
            new() { FileID = "file_id", IndexID = "idx-abc123" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
