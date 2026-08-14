using System;
using System.Collections.Generic;
using LlamaIndex.LlamaCloud.Models.Beta.Directories.Files;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.Directories.Files;

public class FileListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileListParams
        {
            DirectoryID = "directory_id",
            DisplayName = "display_name",
            DisplayNameContains = "display_name_contains",
            Expand = ["string", "string"],
            FileID = "file_id",
            IncludeDeleted = true,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 0,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UniqueID = "unique_id",
            UpdatedAtOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAtOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedDirectoryID = "directory_id";
        string expectedDisplayName = "display_name";
        string expectedDisplayNameContains = "display_name_contains";
        List<string> expectedExpand = ["string", "string"];
        string expectedFileID = "file_id";
        bool expectedIncludeDeleted = true;
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedPageSize = 0;
        string expectedPageToken = "page_token";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedUniqueID = "unique_id";
        DateTimeOffset expectedUpdatedAtOnOrAfter = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedUpdatedAtOnOrBefore = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );

        Assert.Equal(expectedDirectoryID, parameters.DirectoryID);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedDisplayNameContains, parameters.DisplayNameContains);
        Assert.NotNull(parameters.Expand);
        Assert.Equal(expectedExpand.Count, parameters.Expand.Count);
        for (int i = 0; i < expectedExpand.Count; i++)
        {
            Assert.Equal(expectedExpand[i], parameters.Expand[i]);
        }
        Assert.Equal(expectedFileID, parameters.FileID);
        Assert.Equal(expectedIncludeDeleted, parameters.IncludeDeleted);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedPageToken, parameters.PageToken);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedUniqueID, parameters.UniqueID);
        Assert.Equal(expectedUpdatedAtOnOrAfter, parameters.UpdatedAtOnOrAfter);
        Assert.Equal(expectedUpdatedAtOnOrBefore, parameters.UpdatedAtOnOrBefore);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileListParams
        {
            DirectoryID = "directory_id",
            DisplayName = "display_name",
            DisplayNameContains = "display_name_contains",
            Expand = ["string", "string"],
            FileID = "file_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 0,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UniqueID = "unique_id",
            UpdatedAtOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAtOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(parameters.IncludeDeleted);
        Assert.False(parameters.RawQueryData.ContainsKey("include_deleted"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FileListParams
        {
            DirectoryID = "directory_id",
            DisplayName = "display_name",
            DisplayNameContains = "display_name_contains",
            Expand = ["string", "string"],
            FileID = "file_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 0,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UniqueID = "unique_id",
            UpdatedAtOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAtOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            IncludeDeleted = null,
        };

        Assert.Null(parameters.IncludeDeleted);
        Assert.False(parameters.RawQueryData.ContainsKey("include_deleted"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileListParams { DirectoryID = "directory_id", IncludeDeleted = true };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawQueryData.ContainsKey("display_name"));
        Assert.Null(parameters.DisplayNameContains);
        Assert.False(parameters.RawQueryData.ContainsKey("display_name_contains"));
        Assert.Null(parameters.Expand);
        Assert.False(parameters.RawQueryData.ContainsKey("expand"));
        Assert.Null(parameters.FileID);
        Assert.False(parameters.RawQueryData.ContainsKey("file_id"));
        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.False(parameters.RawQueryData.ContainsKey("page_token"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.UniqueID);
        Assert.False(parameters.RawQueryData.ContainsKey("unique_id"));
        Assert.Null(parameters.UpdatedAtOnOrAfter);
        Assert.False(parameters.RawQueryData.ContainsKey("updated_at_on_or_after"));
        Assert.Null(parameters.UpdatedAtOnOrBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("updated_at_on_or_before"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new FileListParams
        {
            DirectoryID = "directory_id",
            IncludeDeleted = true,

            DisplayName = null,
            DisplayNameContains = null,
            Expand = null,
            FileID = null,
            OrganizationID = null,
            PageSize = null,
            PageToken = null,
            ProjectID = null,
            UniqueID = null,
            UpdatedAtOnOrAfter = null,
            UpdatedAtOnOrBefore = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.True(parameters.RawQueryData.ContainsKey("display_name"));
        Assert.Null(parameters.DisplayNameContains);
        Assert.True(parameters.RawQueryData.ContainsKey("display_name_contains"));
        Assert.Null(parameters.Expand);
        Assert.True(parameters.RawQueryData.ContainsKey("expand"));
        Assert.Null(parameters.FileID);
        Assert.True(parameters.RawQueryData.ContainsKey("file_id"));
        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.PageSize);
        Assert.True(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.True(parameters.RawQueryData.ContainsKey("page_token"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.UniqueID);
        Assert.True(parameters.RawQueryData.ContainsKey("unique_id"));
        Assert.Null(parameters.UpdatedAtOnOrAfter);
        Assert.True(parameters.RawQueryData.ContainsKey("updated_at_on_or_after"));
        Assert.Null(parameters.UpdatedAtOnOrBefore);
        Assert.True(parameters.RawQueryData.ContainsKey("updated_at_on_or_before"));
    }

    [Fact]
    public void Url_Works()
    {
        FileListParams parameters = new()
        {
            DirectoryID = "directory_id",
            DisplayName = "display_name",
            DisplayNameContains = "display_name_contains",
            Expand = ["string", "string"],
            FileID = "file_id",
            IncludeDeleted = true,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 0,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UniqueID = "unique_id",
            UpdatedAtOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            UpdatedAtOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/directories/directory_id/files?display_name=display_name&display_name_contains=display_name_contains&expand=string&expand=string&file_id=file_id&include_deleted=true&organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&page_size=0&page_token=page_token&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&unique_id=unique_id&updated_at_on_or_after=2019-12-27T18%3a11%3a19.117%2b00%3a00&updated_at_on_or_before=2019-12-27T18%3a11%3a19.117%2b00%3a00"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileListParams
        {
            DirectoryID = "directory_id",
            DisplayName = "display_name",
            DisplayNameContains = "display_name_contains",
            Expand = ["string", "string"],
            FileID = "file_id",
            IncludeDeleted = true,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 0,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UniqueID = "unique_id",
            UpdatedAtOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAtOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        FileListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
