using System.Threading.Tasks;

namespace LlamaCloud.Tests.Services;

public class ChatServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var chat = await this.client.Chat.Create(new(), TestContext.Current.CancellationToken);
        chat.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var chat = await this.client.Chat.Retrieve(
            "session_id",
            new(),
            TestContext.Current.CancellationToken
        );
        chat.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Chat.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Chat.Delete("session_id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetSummary_Works()
    {
        var response = await this.client.Chat.GetSummary(
            "session_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Stream_Works()
    {
        await this.client.Chat.Stream(
            "session_id",
            new()
            {
                IndexIds = ["idx-abc123", "idx-def456"],
                Prompt = "What were the main findings in Q3?",
            },
            TestContext.Current.CancellationToken
        );
    }
}
