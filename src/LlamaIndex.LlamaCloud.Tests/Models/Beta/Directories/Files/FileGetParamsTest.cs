using System;
using System.Collections.Generic;
using LlamaIndex.LlamaCloud.Models.Beta.Directories.Files;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.Directories.Files;

public class FileGetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileGetParams
        {
            DirectoryID = "directory_id",
            DirectoryFileID = "directory_file_id",
            Expand = ["string", "string"],
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedDirectoryID = "directory_id";
        string expectedDirectoryFileID = "directory_file_id";
        List<string> expectedExpand = ["string", "string"];
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedDirectoryID, parameters.DirectoryID);
        Assert.Equal(expectedDirectoryFileID, parameters.DirectoryFileID);
        Assert.NotNull(parameters.Expand);
        Assert.Equal(expectedExpand.Count, parameters.Expand.Count);
        for (int i = 0; i < expectedExpand.Count; i++)
        {
            Assert.Equal(expectedExpand[i], parameters.Expand[i]);
        }
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileGetParams
        {
            DirectoryID = "directory_id",
            DirectoryFileID = "directory_file_id",
        };

        Assert.Null(parameters.Expand);
        Assert.False(parameters.RawQueryData.ContainsKey("expand"));
        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new FileGetParams
        {
            DirectoryID = "directory_id",
            DirectoryFileID = "directory_file_id",

            Expand = null,
            OrganizationID = null,
            ProjectID = null,
        };

        Assert.Null(parameters.Expand);
        Assert.True(parameters.RawQueryData.ContainsKey("expand"));
        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void Url_Works()
    {
        FileGetParams parameters = new()
        {
            DirectoryID = "directory_id",
            DirectoryFileID = "directory_file_id",
            Expand = ["string", "string"],
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/directories/directory_id/files/directory_file_id?expand=string&expand=string&organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileGetParams
        {
            DirectoryID = "directory_id",
            DirectoryFileID = "directory_file_id",
            Expand = ["string", "string"],
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        FileGetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
