using System;
using LlamaIndex.LlamaCloud.Models.Files;

namespace LlamaIndex.LlamaCloud.Tests.Models.Files;

public class FileContentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileContentParams
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExpiresAtSeconds = 0,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedExpiresAtSeconds = 0;
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedFileID, parameters.FileID);
        Assert.Equal(expectedExpiresAtSeconds, parameters.ExpiresAtSeconds);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileContentParams { FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        Assert.Null(parameters.ExpiresAtSeconds);
        Assert.False(parameters.RawQueryData.ContainsKey("expires_at_seconds"));
        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new FileContentParams
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            ExpiresAtSeconds = null,
            OrganizationID = null,
            ProjectID = null,
        };

        Assert.Null(parameters.ExpiresAtSeconds);
        Assert.True(parameters.RawQueryData.ContainsKey("expires_at_seconds"));
        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void Url_Works()
    {
        FileContentParams parameters = new()
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExpiresAtSeconds = 0,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/files/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/content?expires_at_seconds=0&organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileContentParams
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExpiresAtSeconds = 0,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        FileContentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
