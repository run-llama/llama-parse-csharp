using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Models.DataSinks;

namespace LlamaIndex.LlamaCloud.Tests.Services;

public class DataSinkServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var dataSink = await this.client.DataSinks.Create(
            new()
            {
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                SinkType = SinkType.AstraDB,
            },
            TestContext.Current.CancellationToken
        );
        dataSink.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var dataSink = await this.client.DataSinks.Update(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { SinkType = DataSinkUpdateParamsSinkType.AstraDB },
            TestContext.Current.CancellationToken
        );
        dataSink.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var dataSinks = await this.client.DataSinks.List(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in dataSinks)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.DataSinks.Delete(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var dataSink = await this.client.DataSinks.Get(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        dataSink.Validate();
    }
}
