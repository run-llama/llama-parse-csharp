using System.Threading.Tasks;

namespace LlamaCloud.Tests.Services.Beta;

public class AttachmentServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Attachments.List(
            new() { SourceID = "source_id" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var presignedUrl = await this.client.Beta.Attachments.Get(
            "attachment_name",
            new() { SourceID = "source_id" },
            TestContext.Current.CancellationToken
        );
        presignedUrl.Validate();
    }
}
