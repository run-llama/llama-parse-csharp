using System;
using System.Collections.Generic;
using LlamaCloud.Models.Files;

namespace LlamaCloud.Tests.Models.Files;

public class FileListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileListParams
        {
            Expand = ["string", "string"],
            ExternalFileID = "external_file_id",
            FileIds =
            [
                "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ],
            FileName = "file_name",
            OrderBy = "order_by",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 1,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        List<string> expectedExpand = ["string", "string"];
        string expectedExternalFileID = "external_file_id";
        List<string> expectedFileIds =
        [
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        ];
        string expectedFileName = "file_name";
        string expectedOrderBy = "order_by";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedPageSize = 1;
        string expectedPageToken = "page_token";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.NotNull(parameters.Expand);
        Assert.Equal(expectedExpand.Count, parameters.Expand.Count);
        for (int i = 0; i < expectedExpand.Count; i++)
        {
            Assert.Equal(expectedExpand[i], parameters.Expand[i]);
        }
        Assert.Equal(expectedExternalFileID, parameters.ExternalFileID);
        Assert.NotNull(parameters.FileIds);
        Assert.Equal(expectedFileIds.Count, parameters.FileIds.Count);
        for (int i = 0; i < expectedFileIds.Count; i++)
        {
            Assert.Equal(expectedFileIds[i], parameters.FileIds[i]);
        }
        Assert.Equal(expectedFileName, parameters.FileName);
        Assert.Equal(expectedOrderBy, parameters.OrderBy);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedPageToken, parameters.PageToken);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileListParams { };

        Assert.Null(parameters.Expand);
        Assert.False(parameters.RawQueryData.ContainsKey("expand"));
        Assert.Null(parameters.ExternalFileID);
        Assert.False(parameters.RawQueryData.ContainsKey("external_file_id"));
        Assert.Null(parameters.FileIds);
        Assert.False(parameters.RawQueryData.ContainsKey("file_ids"));
        Assert.Null(parameters.FileName);
        Assert.False(parameters.RawQueryData.ContainsKey("file_name"));
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawQueryData.ContainsKey("order_by"));
        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.False(parameters.RawQueryData.ContainsKey("page_token"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new FileListParams
        {
            Expand = null,
            ExternalFileID = null,
            FileIds = null,
            FileName = null,
            OrderBy = null,
            OrganizationID = null,
            PageSize = null,
            PageToken = null,
            ProjectID = null,
        };

        Assert.Null(parameters.Expand);
        Assert.True(parameters.RawQueryData.ContainsKey("expand"));
        Assert.Null(parameters.ExternalFileID);
        Assert.True(parameters.RawQueryData.ContainsKey("external_file_id"));
        Assert.Null(parameters.FileIds);
        Assert.True(parameters.RawQueryData.ContainsKey("file_ids"));
        Assert.Null(parameters.FileName);
        Assert.True(parameters.RawQueryData.ContainsKey("file_name"));
        Assert.Null(parameters.OrderBy);
        Assert.True(parameters.RawQueryData.ContainsKey("order_by"));
        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.PageSize);
        Assert.True(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.True(parameters.RawQueryData.ContainsKey("page_token"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void Url_Works()
    {
        FileListParams parameters = new()
        {
            Expand = ["string", "string"],
            ExternalFileID = "external_file_id",
            FileIds =
            [
                "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ],
            FileName = "file_name",
            OrderBy = "order_by",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 1,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/files?expand=string&expand=string&external_file_id=external_file_id&file_ids=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&file_ids=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&file_name=file_name&order_by=order_by&organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&page_size=1&page_token=page_token&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
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
            Expand = ["string", "string"],
            ExternalFileID = "external_file_id",
            FileIds =
            [
                "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ],
            FileName = "file_name",
            OrderBy = "order_by",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 1,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        FileListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
