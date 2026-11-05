using System.Text.Json;
using System.Threading.Tasks;
using LlamaCloud.Models.Extract.Review;

namespace LlamaCloud.Tests.Services.Extract;

public class ReviewServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var extractReview = await this.client.Extract.Review.Create(
            "job_id",
            new(),
            TestContext.Current.CancellationToken
        );
        extractReview.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Approve_Works()
    {
        var extractReview = await this.client.Extract.Review.Approve(
            "job_id",
            new() { Revision = 0 },
            TestContext.Current.CancellationToken
        );
        extractReview.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ChangeFields_Works()
    {
        var extractReview = await this.client.Extract.Review.ChangeFields(
            "job_id",
            new()
            {
                Changes =
                [
                    new()
                    {
                        ChangeValue = ChangeChange.Correct,
                        Path = "/total",
                        Value = JsonSerializer.SerializeToElement(1250.5),
                    },
                ],
                Revision = 0,
            },
            TestContext.Current.CancellationToken
        );
        extractReview.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var extractReview = await this.client.Extract.Review.Get(
            "job_id",
            new(),
            TestContext.Current.CancellationToken
        );
        extractReview.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListEvents_Works()
    {
        var page = await this.client.Extract.Review.ListEvents(
            "job_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Reject_Works()
    {
        var extractReview = await this.client.Extract.Review.Reject(
            "job_id",
            new() { Reason = "The invoice total does not match the line items.", Revision = 0 },
            TestContext.Current.CancellationToken
        );
        extractReview.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Reopen_Works()
    {
        var extractReview = await this.client.Extract.Review.Reopen(
            "job_id",
            new() { Revision = 0 },
            TestContext.Current.CancellationToken
        );
        extractReview.Validate();
    }
}
