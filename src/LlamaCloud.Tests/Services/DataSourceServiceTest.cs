using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using LlamaCloud.Models.DataSources;

namespace LlamaCloud.Tests.Services;

public class DataSourceServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var dataSource = await this.client.DataSources.Create(
            new()
            {
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                SourceType = SourceType.AzureStorageBlob,
            },
            TestContext.Current.CancellationToken
        );
        dataSource.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var dataSource = await this.client.DataSources.Update(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { SourceType = DataSourceUpdateParamsSourceType.AzureStorageBlob },
            TestContext.Current.CancellationToken
        );
        dataSource.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var dataSources = await this.client.DataSources.List(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in dataSources)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.DataSources.Delete(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var dataSource = await this.client.DataSources.Get(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        dataSource.Validate();
    }
}
