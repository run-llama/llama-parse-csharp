using System.Text;
using System.Threading.Tasks;

namespace LlamaIndex.LlamaCloud.Tests.Services;

public class FileServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var file = await this.client.Files.Create(
            new() { File = Encoding.UTF8.GetBytes("Example data"), Purpose = "purpose" },
            TestContext.Current.CancellationToken
        );
        file.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var file = await this.client.Files.Retrieve(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        file.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Files.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Files.Delete(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Content_Works()
    {
        var presignedUrl = await this.client.Files.Content(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        presignedUrl.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Query_Works()
    {
        var response = await this.client.Files.Query(new(), TestContext.Current.CancellationToken);
        response.Validate();
    }
}
