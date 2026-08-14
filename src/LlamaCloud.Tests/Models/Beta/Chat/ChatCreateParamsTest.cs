using System;
using System.Collections.Generic;
using LlamaCloud.Models.Beta.Chat;

namespace LlamaCloud.Tests.Models.Beta.Chat;

public class ChatCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChatCreateParams
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            IndexIds = ["idx-abc123", "idx-def456"],
        };

        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<string> expectedIndexIds = ["idx-abc123", "idx-def456"];

        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.NotNull(parameters.IndexIds);
        Assert.Equal(expectedIndexIds.Count, parameters.IndexIds.Count);
        for (int i = 0; i < expectedIndexIds.Count; i++)
        {
            Assert.Equal(expectedIndexIds[i], parameters.IndexIds[i]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChatCreateParams { };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.IndexIds);
        Assert.False(parameters.RawBodyData.ContainsKey("index_ids"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ChatCreateParams
        {
            OrganizationID = null,
            ProjectID = null,
            IndexIds = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.IndexIds);
        Assert.True(parameters.RawBodyData.ContainsKey("index_ids"));
    }

    [Fact]
    public void Url_Works()
    {
        ChatCreateParams parameters = new()
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/chat?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChatCreateParams
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            IndexIds = ["idx-abc123", "idx-def456"],
        };

        ChatCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
