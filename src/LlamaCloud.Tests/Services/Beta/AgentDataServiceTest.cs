using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace LlamaCloud.Tests.Services.Beta;

public class AgentDataServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var agentData = await this.client.Beta.AgentData.Create(
            new()
            {
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                DeploymentName = "deployment_name",
            },
            TestContext.Current.CancellationToken
        );
        agentData.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var agentData = await this.client.Beta.AgentData.Update(
            "item_id",
            new()
            {
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            TestContext.Current.CancellationToken
        );
        agentData.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Beta.AgentData.Delete(
            "item_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Aggregate_Works()
    {
        var page = await this.client.Beta.AgentData.Aggregate(
            new() { DeploymentName = "deployment_name" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task DeleteByQuery_Works()
    {
        var response = await this.client.Beta.AgentData.DeleteByQuery(
            new() { DeploymentName = "deployment_name" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var agentData = await this.client.Beta.AgentData.Get(
            "item_id",
            new(),
            TestContext.Current.CancellationToken
        );
        agentData.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Search_Works()
    {
        var page = await this.client.Beta.AgentData.Search(
            new() { DeploymentName = "deployment_name" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
