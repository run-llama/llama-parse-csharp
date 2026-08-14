using System;
using System.Text;
using LlamaCloud.Core;
using LlamaCloud.Models.Beta.Directories.Files;

namespace LlamaCloud.Tests.Models.Beta.Directories.Files;

public class FileUploadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent uploadFile = Encoding.UTF8.GetBytes("Example data");

        var parameters = new FileUploadParams
        {
            DirectoryID = "directory_id",
            UploadFile = uploadFile,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DisplayName = "display_name",
            ExternalFileID = "external_file_id",
            Metadata = "{\"source\": \"web\", \"priority\": 1}",
            UniqueID = "unique_id",
        };

        string expectedDirectoryID = "directory_id";
        BinaryContent expectedUploadFile = uploadFile;
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDisplayName = "display_name";
        string expectedExternalFileID = "external_file_id";
        string expectedMetadata = "{\"source\": \"web\", \"priority\": 1}";
        string expectedUniqueID = "unique_id";

        Assert.Equal(expectedDirectoryID, parameters.DirectoryID);
        Assert.Equal(expectedUploadFile, parameters.UploadFile);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedExternalFileID, parameters.ExternalFileID);
        Assert.Equal(expectedMetadata, parameters.Metadata);
        Assert.Equal(expectedUniqueID, parameters.UniqueID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        BinaryContent uploadFile = Encoding.UTF8.GetBytes("Example data");

        var parameters = new FileUploadParams
        {
            DirectoryID = "directory_id",
            UploadFile = uploadFile,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.ExternalFileID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_file_id"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.UniqueID);
        Assert.False(parameters.RawBodyData.ContainsKey("unique_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        BinaryContent uploadFile = Encoding.UTF8.GetBytes("Example data");

        var parameters = new FileUploadParams
        {
            DirectoryID = "directory_id",
            UploadFile = uploadFile,

            OrganizationID = null,
            ProjectID = null,
            DisplayName = null,
            ExternalFileID = null,
            Metadata = null,
            UniqueID = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.DisplayName);
        Assert.True(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.ExternalFileID);
        Assert.True(parameters.RawBodyData.ContainsKey("external_file_id"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.UniqueID);
        Assert.True(parameters.RawBodyData.ContainsKey("unique_id"));
    }

    [Fact]
    public void Url_Works()
    {
        FileUploadParams parameters = new()
        {
            DirectoryID = "directory_id",
            UploadFile = Encoding.UTF8.GetBytes("Example data"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/directories/directory_id/files/upload?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileUploadParams
        {
            DirectoryID = "directory_id",
            UploadFile = Encoding.UTF8.GetBytes("Example data"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DisplayName = "display_name",
            ExternalFileID = "external_file_id",
            Metadata = "{\"source\": \"web\", \"priority\": 1}",
            UniqueID = "unique_id",
        };

        FileUploadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
