using System.Threading.Tasks;
using LlamaCloud.Models.Configurations;

namespace LlamaCloud.Tests.Services;

public class ConfigurationServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var configurationResponse = await this.client.Configurations.Create(
            new()
            {
                Name = "x",
                Parameters = new ClassifyV2Parameters()
                {
                    Rules =
                    [
                        new()
                        {
                            Description = "contains invoice number, line items, and total amount",
                            Type = "invoice",
                        },
                    ],
                    Mode = Mode.Fast,
                    ParsingConfiguration = new()
                    {
                        Lang = "en",
                        MaxPages = 10,
                        TargetPages = "1,3,5-7",
                    },
                },
            },
            TestContext.Current.CancellationToken
        );
        configurationResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var configurationResponse = await this.client.Configurations.Retrieve(
            "config_id",
            new(),
            TestContext.Current.CancellationToken
        );
        configurationResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var configurationResponse = await this.client.Configurations.Update(
            "config_id",
            new(),
            TestContext.Current.CancellationToken
        );
        configurationResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Configurations.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Configurations.Delete(
            "config_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
