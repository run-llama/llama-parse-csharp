using System;
using System.Text;
using LlamaCloud.Core;
using LlamaCloud.Models.Files;

namespace LlamaCloud.Tests.Models.Files;

public class FileCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new FileCreateParams
        {
            File = file,
            Purpose = "purpose",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExternalFileID = "external_file_id",
        };

        BinaryContent expectedFile = file;
        string expectedPurpose = "purpose";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedExternalFileID = "external_file_id";

        Assert.Equal(expectedFile, parameters.File);
        Assert.Equal(expectedPurpose, parameters.Purpose);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedExternalFileID, parameters.ExternalFileID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new FileCreateParams { File = file, Purpose = "purpose" };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.ExternalFileID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_file_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new FileCreateParams
        {
            File = file,
            Purpose = "purpose",

            OrganizationID = null,
            ProjectID = null,
            ExternalFileID = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.ExternalFileID);
        Assert.True(parameters.RawBodyData.ContainsKey("external_file_id"));
    }

    [Fact]
    public void Url_Works()
    {
        FileCreateParams parameters = new()
        {
            File = Encoding.UTF8.GetBytes("Example data"),
            Purpose = "purpose",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/files?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileCreateParams
        {
            File = Encoding.UTF8.GetBytes("Example data"),
            Purpose = "purpose",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExternalFileID = "external_file_id",
        };

        FileCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
