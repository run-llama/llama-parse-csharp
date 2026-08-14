using System.Threading.Tasks;

namespace LlamaIndex.LlamaCloud.Tests.Services;

public class WebhookConfigServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var webhookConfigResponse = await this.client.WebhookConfigs.Create(
            new() { WebhookUrl = "https://example.com/webhooks/llamacloud" },
            TestContext.Current.CancellationToken
        );
        webhookConfigResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var webhookConfigResponse = await this.client.WebhookConfigs.Retrieve(
            "config_id",
            new(),
            TestContext.Current.CancellationToken
        );
        webhookConfigResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var webhookConfigResponse = await this.client.WebhookConfigs.Update(
            "config_id",
            new(),
            TestContext.Current.CancellationToken
        );
        webhookConfigResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var webhookConfigResponses = await this.client.WebhookConfigs.List(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in webhookConfigResponses)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.WebhookConfigs.Delete(
            "config_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
