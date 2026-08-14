using System;
using System.Collections.Generic;
using LlamaIndex.LlamaCloud.Models.Beta.Chat;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.Chat;

public class ChatStreamParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChatStreamParams
        {
            SessionID = "session_id",
            IndexIds = ["idx-abc123", "idx-def456"],
            Prompt = "What were the main findings in Q3?",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedSessionID = "session_id";
        List<string> expectedIndexIds = ["idx-abc123", "idx-def456"];
        string expectedPrompt = "What were the main findings in Q3?";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedSessionID, parameters.SessionID);
        Assert.Equal(expectedIndexIds.Count, parameters.IndexIds.Count);
        for (int i = 0; i < expectedIndexIds.Count; i++)
        {
            Assert.Equal(expectedIndexIds[i], parameters.IndexIds[i]);
        }
        Assert.Equal(expectedPrompt, parameters.Prompt);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChatStreamParams
        {
            SessionID = "session_id",
            IndexIds = ["idx-abc123", "idx-def456"],
            Prompt = "What were the main findings in Q3?",
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ChatStreamParams
        {
            SessionID = "session_id",
            IndexIds = ["idx-abc123", "idx-def456"],
            Prompt = "What were the main findings in Q3?",

            OrganizationID = null,
            ProjectID = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void Url_Works()
    {
        ChatStreamParams parameters = new()
        {
            SessionID = "session_id",
            IndexIds = ["idx-abc123", "idx-def456"],
            Prompt = "What were the main findings in Q3?",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/chat/session_id/messages/stream?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChatStreamParams
        {
            SessionID = "session_id",
            IndexIds = ["idx-abc123", "idx-def456"],
            Prompt = "What were the main findings in Q3?",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ChatStreamParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
