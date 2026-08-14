using System.Threading.Tasks;

namespace LlamaCloud.Tests.Services.Retrievers;

public class RetrieverServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Search_Works()
    {
        var compositeRetrievalResult = await this.client.Retrievers.Retriever.Search(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { Query = "x" },
            TestContext.Current.CancellationToken
        );
        compositeRetrievalResult.Validate();
    }
}
