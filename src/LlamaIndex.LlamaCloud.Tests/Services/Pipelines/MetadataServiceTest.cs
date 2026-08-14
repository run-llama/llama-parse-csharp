using System.Text;
using System.Threading.Tasks;

namespace LlamaIndex.LlamaCloud.Tests.Services.Pipelines;

public class MetadataServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        await this.client.Pipelines.Metadata.Create(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { UploadFile = Encoding.UTF8.GetBytes("Example data") },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task DeleteAll_Works()
    {
        await this.client.Pipelines.Metadata.DeleteAll(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
