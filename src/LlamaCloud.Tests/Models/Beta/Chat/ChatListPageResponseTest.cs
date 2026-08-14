using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Beta.Chat;

namespace LlamaCloud.Tests.Models.Beta.Chat;

public class ChatListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatListPageResponse
        {
            Items =
            [
                new()
                {
                    LastUpdatedAt = "2026-04-22T12:34:41.342245",
                    SessionID = "ses-abc123",
                    GeneratedTitle = "What were the main findings in Q3?...",
                    IndexIds = ["idx-abc123", "idx-def456"],
                    JobMetadata = new()
                    {
                        DurationMs = 0,
                        Error = "error",
                        ExportConfigIds = ["string"],
                        IsError = true,
                        TotalInputTokens = 0,
                        TotalOutputTokens = 0,
                        Turns = 0,
                    },
                },
            ],
            NextPageToken = "next_page_token",
        };

        List<ChatListResponse> expectedItems =
        [
            new()
            {
                LastUpdatedAt = "2026-04-22T12:34:41.342245",
                SessionID = "ses-abc123",
                GeneratedTitle = "What were the main findings in Q3?...",
                IndexIds = ["idx-abc123", "idx-def456"],
                JobMetadata = new()
                {
                    DurationMs = 0,
                    Error = "error",
                    ExportConfigIds = ["string"],
                    IsError = true,
                    TotalInputTokens = 0,
                    TotalOutputTokens = 0,
                    Turns = 0,
                },
            },
        ];
        string expectedNextPageToken = "next_page_token";

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNextPageToken, model.NextPageToken);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatListPageResponse
        {
            Items =
            [
                new()
                {
                    LastUpdatedAt = "2026-04-22T12:34:41.342245",
                    SessionID = "ses-abc123",
                    GeneratedTitle = "What were the main findings in Q3?...",
                    IndexIds = ["idx-abc123", "idx-def456"],
                    JobMetadata = new()
                    {
                        DurationMs = 0,
                        Error = "error",
                        ExportConfigIds = ["string"],
                        IsError = true,
                        TotalInputTokens = 0,
                        TotalOutputTokens = 0,
                        Turns = 0,
                    },
                },
            ],
            NextPageToken = "next_page_token",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatListPageResponse
        {
            Items =
            [
                new()
                {
                    LastUpdatedAt = "2026-04-22T12:34:41.342245",
                    SessionID = "ses-abc123",
                    GeneratedTitle = "What were the main findings in Q3?...",
                    IndexIds = ["idx-abc123", "idx-def456"],
                    JobMetadata = new()
                    {
                        DurationMs = 0,
                        Error = "error",
                        ExportConfigIds = ["string"],
                        IsError = true,
                        TotalInputTokens = 0,
                        TotalOutputTokens = 0,
                        Turns = 0,
                    },
                },
            ],
            NextPageToken = "next_page_token",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ChatListResponse> expectedItems =
        [
            new()
            {
                LastUpdatedAt = "2026-04-22T12:34:41.342245",
                SessionID = "ses-abc123",
                GeneratedTitle = "What were the main findings in Q3?...",
                IndexIds = ["idx-abc123", "idx-def456"],
                JobMetadata = new()
                {
                    DurationMs = 0,
                    Error = "error",
                    ExportConfigIds = ["string"],
                    IsError = true,
                    TotalInputTokens = 0,
                    TotalOutputTokens = 0,
                    Turns = 0,
                },
            },
        ];
        string expectedNextPageToken = "next_page_token";

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedNextPageToken, deserialized.NextPageToken);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatListPageResponse
        {
            Items =
            [
                new()
                {
                    LastUpdatedAt = "2026-04-22T12:34:41.342245",
                    SessionID = "ses-abc123",
                    GeneratedTitle = "What were the main findings in Q3?...",
                    IndexIds = ["idx-abc123", "idx-def456"],
                    JobMetadata = new()
                    {
                        DurationMs = 0,
                        Error = "error",
                        ExportConfigIds = ["string"],
                        IsError = true,
                        TotalInputTokens = 0,
                        TotalOutputTokens = 0,
                        Turns = 0,
                    },
                },
            ],
            NextPageToken = "next_page_token",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatListPageResponse
        {
            Items =
            [
                new()
                {
                    LastUpdatedAt = "2026-04-22T12:34:41.342245",
                    SessionID = "ses-abc123",
                    GeneratedTitle = "What were the main findings in Q3?...",
                    IndexIds = ["idx-abc123", "idx-def456"],
                    JobMetadata = new()
                    {
                        DurationMs = 0,
                        Error = "error",
                        ExportConfigIds = ["string"],
                        IsError = true,
                        TotalInputTokens = 0,
                        TotalOutputTokens = 0,
                        Turns = 0,
                    },
                },
            ],
        };

        Assert.Null(model.NextPageToken);
        Assert.False(model.RawData.ContainsKey("next_page_token"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatListPageResponse
        {
            Items =
            [
                new()
                {
                    LastUpdatedAt = "2026-04-22T12:34:41.342245",
                    SessionID = "ses-abc123",
                    GeneratedTitle = "What were the main findings in Q3?...",
                    IndexIds = ["idx-abc123", "idx-def456"],
                    JobMetadata = new()
                    {
                        DurationMs = 0,
                        Error = "error",
                        ExportConfigIds = ["string"],
                        IsError = true,
                        TotalInputTokens = 0,
                        TotalOutputTokens = 0,
                        Turns = 0,
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChatListPageResponse
        {
            Items =
            [
                new()
                {
                    LastUpdatedAt = "2026-04-22T12:34:41.342245",
                    SessionID = "ses-abc123",
                    GeneratedTitle = "What were the main findings in Q3?...",
                    IndexIds = ["idx-abc123", "idx-def456"],
                    JobMetadata = new()
                    {
                        DurationMs = 0,
                        Error = "error",
                        ExportConfigIds = ["string"],
                        IsError = true,
                        TotalInputTokens = 0,
                        TotalOutputTokens = 0,
                        Turns = 0,
                    },
                },
            ],

            NextPageToken = null,
        };

        Assert.Null(model.NextPageToken);
        Assert.True(model.RawData.ContainsKey("next_page_token"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatListPageResponse
        {
            Items =
            [
                new()
                {
                    LastUpdatedAt = "2026-04-22T12:34:41.342245",
                    SessionID = "ses-abc123",
                    GeneratedTitle = "What were the main findings in Q3?...",
                    IndexIds = ["idx-abc123", "idx-def456"],
                    JobMetadata = new()
                    {
                        DurationMs = 0,
                        Error = "error",
                        ExportConfigIds = ["string"],
                        IsError = true,
                        TotalInputTokens = 0,
                        TotalOutputTokens = 0,
                        Turns = 0,
                    },
                },
            ],

            NextPageToken = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatListPageResponse
        {
            Items =
            [
                new()
                {
                    LastUpdatedAt = "2026-04-22T12:34:41.342245",
                    SessionID = "ses-abc123",
                    GeneratedTitle = "What were the main findings in Q3?...",
                    IndexIds = ["idx-abc123", "idx-def456"],
                    JobMetadata = new()
                    {
                        DurationMs = 0,
                        Error = "error",
                        ExportConfigIds = ["string"],
                        IsError = true,
                        TotalInputTokens = 0,
                        TotalOutputTokens = 0,
                        Turns = 0,
                    },
                },
            ],
            NextPageToken = "next_page_token",
        };

        ChatListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
