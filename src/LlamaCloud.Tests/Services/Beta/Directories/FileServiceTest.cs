using System.Text;
using System.Threading.Tasks;

namespace LlamaCloud.Tests.Services.Beta.Directories;

public class FileServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var file = await this.client.Beta.Directories.Files.Update(
            "directory_file_id",
            new() { DirectoryID = "directory_id" },
            TestContext.Current.CancellationToken
        );
        file.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Directories.Files.List(
            "directory_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Beta.Directories.Files.Delete(
            "directory_file_id",
            new() { DirectoryID = "directory_id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Add_Works()
    {
        var response = await this.client.Beta.Directories.Files.Add(
            "directory_id",
            new() { FileID = "file_id" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var file = await this.client.Beta.Directories.Files.Get(
            "directory_file_id",
            new() { DirectoryID = "directory_id" },
            TestContext.Current.CancellationToken
        );
        file.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Upload_Works()
    {
        var response = await this.client.Beta.Directories.Files.Upload(
            "directory_id",
            new() { UploadFile = Encoding.UTF8.GetBytes("Example data") },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
