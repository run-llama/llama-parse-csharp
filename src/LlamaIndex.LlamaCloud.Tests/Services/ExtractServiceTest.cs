using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Models.Extract;

namespace LlamaIndex.LlamaCloud.Tests.Services;

public class ExtractServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var extractV2Job = await this.client.Extract.Create(
            new() { FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee" },
            TestContext.Current.CancellationToken
        );
        extractV2Job.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Extract.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Extract.Delete("job_id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Cancel_Works()
    {
        var extractV2Job = await this.client.Extract.Cancel(
            "job_id",
            new(),
            TestContext.Current.CancellationToken
        );
        extractV2Job.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GenerateSchema_Works()
    {
        var configurationCreate = await this.client.Extract.GenerateSchema(
            new(),
            TestContext.Current.CancellationToken
        );
        configurationCreate.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var extractV2Job = await this.client.Extract.Get(
            "job_id",
            new(),
            TestContext.Current.CancellationToken
        );
        extractV2Job.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ValidateSchema_Works()
    {
        var extractV2SchemaValidateResponse = await this.client.Extract.ValidateSchema(
            new()
            {
                DataSchema = new Dictionary<string, ExtractValidateSchemaParamsDataSchema?>()
                {
                    {
                        "properties",
                        new(
                            new Dictionary<string, JsonElement>()
                            {
                                { "invoice_number", JsonSerializer.SerializeToElement("bar") },
                                { "line_items", JsonSerializer.SerializeToElement("bar") },
                                { "total_amount", JsonSerializer.SerializeToElement("bar") },
                                { "vendor_name", JsonSerializer.SerializeToElement("bar") },
                            }
                        )
                    },
                    {
                        "required",
                        new(
                            [
                                JsonSerializer.SerializeToElement("invoice_number"),
                                JsonSerializer.SerializeToElement("total_amount"),
                                JsonSerializer.SerializeToElement("vendor_name"),
                            ]
                        )
                    },
                    { "type", "object" },
                },
            },
            TestContext.Current.CancellationToken
        );
        extractV2SchemaValidateResponse.Validate();
    }
}
