using System.Threading.Tasks;
using LlamaCloud.Models.Beta.Sheets;

namespace LlamaCloud.Tests.Services.Beta;

public class SheetServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var sheetsJob = await this.client.Beta.Sheets.Create(
            new() { FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" },
            TestContext.Current.CancellationToken
        );
        sheetsJob.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Sheets.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task DeleteJob_Works()
    {
        await this.client.Beta.Sheets.DeleteJob(
            "spreadsheet_job_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var sheetsJob = await this.client.Beta.Sheets.Get(
            "spreadsheet_job_id",
            new(),
            TestContext.Current.CancellationToken
        );
        sheetsJob.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetResultTable_Works()
    {
        var presignedUrl = await this.client.Beta.Sheets.GetResultTable(
            RegionType.CellMetadata,
            new() { SpreadsheetJobID = "spreadsheet_job_id", RegionID = "region_id" },
            TestContext.Current.CancellationToken
        );
        presignedUrl.Validate();
    }
}
