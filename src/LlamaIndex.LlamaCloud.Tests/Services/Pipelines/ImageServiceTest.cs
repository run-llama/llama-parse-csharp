using System.Threading.Tasks;

namespace LlamaIndex.LlamaCloud.Tests.Services.Pipelines;

public class ImageServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetPageFigure_Works()
    {
        await this.client.Pipelines.Images.GetPageFigure(
            "figure_name",
            new() { ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e", PageIndex = 0 },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetPageScreenshot_Works()
    {
        await this.client.Pipelines.Images.GetPageScreenshot(
            0,
            new() { ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListPageFigures_Works()
    {
        var response = await this.client.Pipelines.Images.ListPageFigures(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListPageScreenshots_Works()
    {
        var response = await this.client.Pipelines.Images.ListPageScreenshots(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }
}
