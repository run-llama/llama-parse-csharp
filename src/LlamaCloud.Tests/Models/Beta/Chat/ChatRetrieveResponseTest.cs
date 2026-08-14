using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Beta.Chat;

namespace LlamaCloud.Tests.Models.Beta.Chat;

public class ChatRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatRetrieveResponse
        {
            Events =
            [
                new Stop()
                {
                    Error = "error",
                    IsError = true,
                    Usage = new()
                    {
                        DurationMs = 0,
                        TotalInputTokens = 0,
                        TotalOutputTokens = 0,
                        Turns = 0,
                    },
                    Type = Type.Stop,
                },
            ],
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
        };

        List<Event> expectedEvents =
        [
            new Stop()
            {
                Error = "error",
                IsError = true,
                Usage = new()
                {
                    DurationMs = 0,
                    TotalInputTokens = 0,
                    TotalOutputTokens = 0,
                    Turns = 0,
                },
                Type = Type.Stop,
            },
        ];
        string expectedLastUpdatedAt = "2026-04-22T12:34:41.342245";
        string expectedSessionID = "ses-abc123";
        string expectedGeneratedTitle = "What were the main findings in Q3?...";
        List<string> expectedIndexIds = ["idx-abc123", "idx-def456"];
        ChatRetrieveResponseJobMetadata expectedJobMetadata = new()
        {
            DurationMs = 0,
            Error = "error",
            ExportConfigIds = ["string"],
            IsError = true,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            Turns = 0,
        };

        Assert.Equal(expectedEvents.Count, model.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], model.Events[i]);
        }
        Assert.Equal(expectedLastUpdatedAt, model.LastUpdatedAt);
        Assert.Equal(expectedSessionID, model.SessionID);
        Assert.Equal(expectedGeneratedTitle, model.GeneratedTitle);
        Assert.NotNull(model.IndexIds);
        Assert.Equal(expectedIndexIds.Count, model.IndexIds.Count);
        for (int i = 0; i < expectedIndexIds.Count; i++)
        {
            Assert.Equal(expectedIndexIds[i], model.IndexIds[i]);
        }
        Assert.Equal(expectedJobMetadata, model.JobMetadata);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatRetrieveResponse
        {
            Events =
            [
                new Stop()
                {
                    Error = "error",
                    IsError = true,
                    Usage = new()
                    {
                        DurationMs = 0,
                        TotalInputTokens = 0,
                        TotalOutputTokens = 0,
                        Turns = 0,
                    },
                    Type = Type.Stop,
                },
            ],
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatRetrieveResponse
        {
            Events =
            [
                new Stop()
                {
                    Error = "error",
                    IsError = true,
                    Usage = new()
                    {
                        DurationMs = 0,
                        TotalInputTokens = 0,
                        TotalOutputTokens = 0,
                        Turns = 0,
                    },
                    Type = Type.Stop,
                },
            ],
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Event> expectedEvents =
        [
            new Stop()
            {
                Error = "error",
                IsError = true,
                Usage = new()
                {
                    DurationMs = 0,
                    TotalInputTokens = 0,
                    TotalOutputTokens = 0,
                    Turns = 0,
                },
                Type = Type.Stop,
            },
        ];
        string expectedLastUpdatedAt = "2026-04-22T12:34:41.342245";
        string expectedSessionID = "ses-abc123";
        string expectedGeneratedTitle = "What were the main findings in Q3?...";
        List<string> expectedIndexIds = ["idx-abc123", "idx-def456"];
        ChatRetrieveResponseJobMetadata expectedJobMetadata = new()
        {
            DurationMs = 0,
            Error = "error",
            ExportConfigIds = ["string"],
            IsError = true,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            Turns = 0,
        };

        Assert.Equal(expectedEvents.Count, deserialized.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], deserialized.Events[i]);
        }
        Assert.Equal(expectedLastUpdatedAt, deserialized.LastUpdatedAt);
        Assert.Equal(expectedSessionID, deserialized.SessionID);
        Assert.Equal(expectedGeneratedTitle, deserialized.GeneratedTitle);
        Assert.NotNull(deserialized.IndexIds);
        Assert.Equal(expectedIndexIds.Count, deserialized.IndexIds.Count);
        for (int i = 0; i < expectedIndexIds.Count; i++)
        {
            Assert.Equal(expectedIndexIds[i], deserialized.IndexIds[i]);
        }
        Assert.Equal(expectedJobMetadata, deserialized.JobMetadata);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatRetrieveResponse
        {
            Events =
            [
                new Stop()
                {
                    Error = "error",
                    IsError = true,
                    Usage = new()
                    {
                        DurationMs = 0,
                        TotalInputTokens = 0,
                        TotalOutputTokens = 0,
                        Turns = 0,
                    },
                    Type = Type.Stop,
                },
            ],
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatRetrieveResponse
        {
            Events =
            [
                new Stop()
                {
                    Error = "error",
                    IsError = true,
                    Usage = new()
                    {
                        DurationMs = 0,
                        TotalInputTokens = 0,
                        TotalOutputTokens = 0,
                        Turns = 0,
                    },
                    Type = Type.Stop,
                },
            ],
            LastUpdatedAt = "2026-04-22T12:34:41.342245",
            SessionID = "ses-abc123",
        };

        Assert.Null(model.GeneratedTitle);
        Assert.False(model.RawData.ContainsKey("generated_title"));
        Assert.Null(model.IndexIds);
        Assert.False(model.RawData.ContainsKey("index_ids"));
        Assert.Null(model.JobMetadata);
        Assert.False(model.RawData.ContainsKey("job_metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatRetrieveResponse
        {
            Events =
            [
                new Stop()
                {
                    Error = "error",
                    IsError = true,
                    Usage = new()
                    {
                        DurationMs = 0,
                        TotalInputTokens = 0,
                        TotalOutputTokens = 0,
                        Turns = 0,
                    },
                    Type = Type.Stop,
                },
            ],
            LastUpdatedAt = "2026-04-22T12:34:41.342245",
            SessionID = "ses-abc123",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChatRetrieveResponse
        {
            Events =
            [
                new Stop()
                {
                    Error = "error",
                    IsError = true,
                    Usage = new()
                    {
                        DurationMs = 0,
                        TotalInputTokens = 0,
                        TotalOutputTokens = 0,
                        Turns = 0,
                    },
                    Type = Type.Stop,
                },
            ],
            LastUpdatedAt = "2026-04-22T12:34:41.342245",
            SessionID = "ses-abc123",

            GeneratedTitle = null,
            IndexIds = null,
            JobMetadata = null,
        };

        Assert.Null(model.GeneratedTitle);
        Assert.True(model.RawData.ContainsKey("generated_title"));
        Assert.Null(model.IndexIds);
        Assert.True(model.RawData.ContainsKey("index_ids"));
        Assert.Null(model.JobMetadata);
        Assert.True(model.RawData.ContainsKey("job_metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatRetrieveResponse
        {
            Events =
            [
                new Stop()
                {
                    Error = "error",
                    IsError = true,
                    Usage = new()
                    {
                        DurationMs = 0,
                        TotalInputTokens = 0,
                        TotalOutputTokens = 0,
                        Turns = 0,
                    },
                    Type = Type.Stop,
                },
            ],
            LastUpdatedAt = "2026-04-22T12:34:41.342245",
            SessionID = "ses-abc123",

            GeneratedTitle = null,
            IndexIds = null,
            JobMetadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatRetrieveResponse
        {
            Events =
            [
                new Stop()
                {
                    Error = "error",
                    IsError = true,
                    Usage = new()
                    {
                        DurationMs = 0,
                        TotalInputTokens = 0,
                        TotalOutputTokens = 0,
                        Turns = 0,
                    },
                    Type = Type.Stop,
                },
            ],
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
        };

        ChatRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventTest : TestBase
{
    [Fact]
    public void StopValidationWorks()
    {
        Event value = new Stop()
        {
            Error = "error",
            IsError = true,
            Usage = new()
            {
                DurationMs = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                Turns = 0,
            },
            Type = Type.Stop,
        };
        value.Validate();
    }

    [Fact]
    public void TextDeltaValidationWorks()
    {
        Event value = new TextDelta() { Content = "content", Type = TextDeltaType.TextDelta };
        value.Validate();
    }

    [Fact]
    public void TextValidationWorks()
    {
        Event value = new Text() { Content = "content", Type = TextType.Text };
        value.Validate();
    }

    [Fact]
    public void ThinkingDeltaValidationWorks()
    {
        Event value = new ThinkingDelta()
        {
            Content = "content",
            Type = ThinkingDeltaType.ThinkingDelta,
        };
        value.Validate();
    }

    [Fact]
    public void ThinkingValidationWorks()
    {
        Event value = new Thinking() { Content = "content", Type = ThinkingType.Thinking };
        value.Validate();
    }

    [Fact]
    public void ToolCallValidationWorks()
    {
        Event value = new ToolCall()
        {
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            CallID = "call_id",
            Name = "name",
            Type = ToolCallType.ToolCall,
        };
        value.Validate();
    }

    [Fact]
    public void ToolResultValidationWorks()
    {
        Event value = new ToolResult()
        {
            CallID = "call_id",
            Name = "name",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ImageAttachment = new() { AttachmentName = "attachment_name", SourceID = "source_id" },
            Type = ToolResultType.ToolResult,
        };
        value.Validate();
    }

    [Fact]
    public void UserInputValidationWorks()
    {
        Event value = new UserInput() { Content = "content", Type = UserInputType.UserInput };
        value.Validate();
    }

    [Fact]
    public void StopSerializationRoundtripWorks()
    {
        Event value = new Stop()
        {
            Error = "error",
            IsError = true,
            Usage = new()
            {
                DurationMs = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                Turns = 0,
            },
            Type = Type.Stop,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextDeltaSerializationRoundtripWorks()
    {
        Event value = new TextDelta() { Content = "content", Type = TextDeltaType.TextDelta };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        Event value = new Text() { Content = "content", Type = TextType.Text };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThinkingDeltaSerializationRoundtripWorks()
    {
        Event value = new ThinkingDelta()
        {
            Content = "content",
            Type = ThinkingDeltaType.ThinkingDelta,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThinkingSerializationRoundtripWorks()
    {
        Event value = new Thinking() { Content = "content", Type = ThinkingType.Thinking };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolCallSerializationRoundtripWorks()
    {
        Event value = new ToolCall()
        {
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            CallID = "call_id",
            Name = "name",
            Type = ToolCallType.ToolCall,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolResultSerializationRoundtripWorks()
    {
        Event value = new ToolResult()
        {
            CallID = "call_id",
            Name = "name",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ImageAttachment = new() { AttachmentName = "attachment_name", SourceID = "source_id" },
            Type = ToolResultType.ToolResult,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserInputSerializationRoundtripWorks()
    {
        Event value = new UserInput() { Content = "content", Type = UserInputType.UserInput };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StopTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Stop
        {
            Error = "error",
            IsError = true,
            Usage = new()
            {
                DurationMs = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                Turns = 0,
            },
            Type = Type.Stop,
        };

        string expectedError = "error";
        bool expectedIsError = true;
        Usage expectedUsage = new()
        {
            DurationMs = 0,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            Turns = 0,
        };
        ApiEnum<string, Type> expectedType = Type.Stop;

        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedIsError, model.IsError);
        Assert.Equal(expectedUsage, model.Usage);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Stop
        {
            Error = "error",
            IsError = true,
            Usage = new()
            {
                DurationMs = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                Turns = 0,
            },
            Type = Type.Stop,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Stop>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Stop
        {
            Error = "error",
            IsError = true,
            Usage = new()
            {
                DurationMs = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                Turns = 0,
            },
            Type = Type.Stop,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Stop>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedError = "error";
        bool expectedIsError = true;
        Usage expectedUsage = new()
        {
            DurationMs = 0,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            Turns = 0,
        };
        ApiEnum<string, Type> expectedType = Type.Stop;

        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedIsError, deserialized.IsError);
        Assert.Equal(expectedUsage, deserialized.Usage);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Stop
        {
            Error = "error",
            IsError = true,
            Usage = new()
            {
                DurationMs = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                Turns = 0,
            },
            Type = Type.Stop,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Stop
        {
            Error = "error",
            IsError = true,
            Usage = new()
            {
                DurationMs = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                Turns = 0,
            },
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Stop
        {
            Error = "error",
            IsError = true,
            Usage = new()
            {
                DurationMs = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                Turns = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Stop
        {
            Error = "error",
            IsError = true,
            Usage = new()
            {
                DurationMs = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                Turns = 0,
            },

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Stop
        {
            Error = "error",
            IsError = true,
            Usage = new()
            {
                DurationMs = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                Turns = 0,
            },

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Stop
        {
            Error = "error",
            IsError = true,
            Usage = new()
            {
                DurationMs = 0,
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                Turns = 0,
            },
            Type = Type.Stop,
        };

        Stop copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage
        {
            DurationMs = 0,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            Turns = 0,
        };

        double expectedDurationMs = 0;
        long expectedTotalInputTokens = 0;
        long expectedTotalOutputTokens = 0;
        long expectedTurns = 0;

        Assert.Equal(expectedDurationMs, model.DurationMs);
        Assert.Equal(expectedTotalInputTokens, model.TotalInputTokens);
        Assert.Equal(expectedTotalOutputTokens, model.TotalOutputTokens);
        Assert.Equal(expectedTurns, model.Turns);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Usage
        {
            DurationMs = 0,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            Turns = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Usage
        {
            DurationMs = 0,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            Turns = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedDurationMs = 0;
        long expectedTotalInputTokens = 0;
        long expectedTotalOutputTokens = 0;
        long expectedTurns = 0;

        Assert.Equal(expectedDurationMs, deserialized.DurationMs);
        Assert.Equal(expectedTotalInputTokens, deserialized.TotalInputTokens);
        Assert.Equal(expectedTotalOutputTokens, deserialized.TotalOutputTokens);
        Assert.Equal(expectedTurns, deserialized.Turns);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Usage
        {
            DurationMs = 0,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            Turns = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Usage { TotalInputTokens = 0, TotalOutputTokens = 0 };

        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("duration_ms"));
        Assert.Null(model.Turns);
        Assert.False(model.RawData.ContainsKey("turns"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Usage { TotalInputTokens = 0, TotalOutputTokens = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Usage
        {
            TotalInputTokens = 0,
            TotalOutputTokens = 0,

            // Null should be interpreted as omitted for these properties
            DurationMs = null,
            Turns = null,
        };

        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("duration_ms"));
        Assert.Null(model.Turns);
        Assert.False(model.RawData.ContainsKey("turns"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Usage
        {
            TotalInputTokens = 0,
            TotalOutputTokens = 0,

            // Null should be interpreted as omitted for these properties
            DurationMs = null,
            Turns = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Usage { DurationMs = 0, Turns = 0 };

        Assert.Null(model.TotalInputTokens);
        Assert.False(model.RawData.ContainsKey("total_input_tokens"));
        Assert.Null(model.TotalOutputTokens);
        Assert.False(model.RawData.ContainsKey("total_output_tokens"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Usage { DurationMs = 0, Turns = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Usage
        {
            DurationMs = 0,
            Turns = 0,

            TotalInputTokens = null,
            TotalOutputTokens = null,
        };

        Assert.Null(model.TotalInputTokens);
        Assert.True(model.RawData.ContainsKey("total_input_tokens"));
        Assert.Null(model.TotalOutputTokens);
        Assert.True(model.RawData.ContainsKey("total_output_tokens"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Usage
        {
            DurationMs = 0,
            Turns = 0,

            TotalInputTokens = null,
            TotalOutputTokens = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Usage
        {
            DurationMs = 0,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            Turns = 0,
        };

        Usage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.Stop)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.Stop)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TextDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TextDelta { Content = "content", Type = TextDeltaType.TextDelta };

        string expectedContent = "content";
        ApiEnum<string, TextDeltaType> expectedType = TextDeltaType.TextDelta;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TextDelta { Content = "content", Type = TextDeltaType.TextDelta };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextDelta>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TextDelta { Content = "content", Type = TextDeltaType.TextDelta };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextDelta>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        ApiEnum<string, TextDeltaType> expectedType = TextDeltaType.TextDelta;

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TextDelta { Content = "content", Type = TextDeltaType.TextDelta };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TextDelta { Content = "content" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TextDelta { Content = "content" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TextDelta
        {
            Content = "content",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TextDelta
        {
            Content = "content",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TextDelta { Content = "content", Type = TextDeltaType.TextDelta };

        TextDelta copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TextDeltaTypeTest : TestBase
{
    [Theory]
    [InlineData(TextDeltaType.TextDelta)]
    public void Validation_Works(TextDeltaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextDeltaType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TextDeltaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TextDeltaType.TextDelta)]
    public void SerializationRoundtrip_Works(TextDeltaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextDeltaType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TextDeltaType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TextDeltaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TextDeltaType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TextTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Text { Content = "content", Type = TextType.Text };

        string expectedContent = "content";
        ApiEnum<string, TextType> expectedType = TextType.Text;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Text { Content = "content", Type = TextType.Text };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Text>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Text { Content = "content", Type = TextType.Text };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Text>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        ApiEnum<string, TextType> expectedType = TextType.Text;

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Text { Content = "content", Type = TextType.Text };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Text { Content = "content" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Text { Content = "content" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Text
        {
            Content = "content",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Text
        {
            Content = "content",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Text { Content = "content", Type = TextType.Text };

        Text copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TextTypeTest : TestBase
{
    [Theory]
    [InlineData(TextType.Text)]
    public void Validation_Works(TextType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TextType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TextType.Text)]
    public void SerializationRoundtrip_Works(TextType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TextType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TextType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TextType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ThinkingDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThinkingDelta
        {
            Content = "content",
            Type = ThinkingDeltaType.ThinkingDelta,
        };

        string expectedContent = "content";
        ApiEnum<string, ThinkingDeltaType> expectedType = ThinkingDeltaType.ThinkingDelta;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ThinkingDelta
        {
            Content = "content",
            Type = ThinkingDeltaType.ThinkingDelta,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThinkingDelta>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ThinkingDelta
        {
            Content = "content",
            Type = ThinkingDeltaType.ThinkingDelta,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThinkingDelta>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        ApiEnum<string, ThinkingDeltaType> expectedType = ThinkingDeltaType.ThinkingDelta;

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ThinkingDelta
        {
            Content = "content",
            Type = ThinkingDeltaType.ThinkingDelta,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ThinkingDelta { Content = "content" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ThinkingDelta { Content = "content" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ThinkingDelta
        {
            Content = "content",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ThinkingDelta
        {
            Content = "content",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ThinkingDelta
        {
            Content = "content",
            Type = ThinkingDeltaType.ThinkingDelta,
        };

        ThinkingDelta copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ThinkingDeltaTypeTest : TestBase
{
    [Theory]
    [InlineData(ThinkingDeltaType.ThinkingDelta)]
    public void Validation_Works(ThinkingDeltaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ThinkingDeltaType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ThinkingDeltaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ThinkingDeltaType.ThinkingDelta)]
    public void SerializationRoundtrip_Works(ThinkingDeltaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ThinkingDeltaType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ThinkingDeltaType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ThinkingDeltaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ThinkingDeltaType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ThinkingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Thinking { Content = "content", Type = ThinkingType.Thinking };

        string expectedContent = "content";
        ApiEnum<string, ThinkingType> expectedType = ThinkingType.Thinking;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Thinking { Content = "content", Type = ThinkingType.Thinking };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Thinking>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Thinking { Content = "content", Type = ThinkingType.Thinking };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Thinking>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        ApiEnum<string, ThinkingType> expectedType = ThinkingType.Thinking;

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Thinking { Content = "content", Type = ThinkingType.Thinking };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Thinking { Content = "content" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Thinking { Content = "content" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Thinking
        {
            Content = "content",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Thinking
        {
            Content = "content",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Thinking { Content = "content", Type = ThinkingType.Thinking };

        Thinking copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ThinkingTypeTest : TestBase
{
    [Theory]
    [InlineData(ThinkingType.Thinking)]
    public void Validation_Works(ThinkingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ThinkingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ThinkingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ThinkingType.Thinking)]
    public void SerializationRoundtrip_Works(ThinkingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ThinkingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ThinkingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ThinkingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ThinkingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ToolCallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolCall
        {
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            CallID = "call_id",
            Name = "name",
            Type = ToolCallType.ToolCall,
        };

        Dictionary<string, JsonElement> expectedArguments = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedCallID = "call_id";
        string expectedName = "name";
        ApiEnum<string, ToolCallType> expectedType = ToolCallType.ToolCall;

        Assert.Equal(expectedArguments.Count, model.Arguments.Count);
        foreach (var item in expectedArguments)
        {
            Assert.True(model.Arguments.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Arguments[item.Key]));
        }
        Assert.Equal(expectedCallID, model.CallID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolCall
        {
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            CallID = "call_id",
            Name = "name",
            Type = ToolCallType.ToolCall,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolCall>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolCall
        {
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            CallID = "call_id",
            Name = "name",
            Type = ToolCallType.ToolCall,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolCall>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, JsonElement> expectedArguments = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedCallID = "call_id";
        string expectedName = "name";
        ApiEnum<string, ToolCallType> expectedType = ToolCallType.ToolCall;

        Assert.Equal(expectedArguments.Count, deserialized.Arguments.Count);
        foreach (var item in expectedArguments)
        {
            Assert.True(deserialized.Arguments.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Arguments[item.Key]));
        }
        Assert.Equal(expectedCallID, deserialized.CallID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolCall
        {
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            CallID = "call_id",
            Name = "name",
            Type = ToolCallType.ToolCall,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolCall
        {
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            CallID = "call_id",
            Name = "name",
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolCall
        {
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            CallID = "call_id",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ToolCall
        {
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            CallID = "call_id",
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolCall
        {
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            CallID = "call_id",
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ToolCall
        {
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            CallID = "call_id",
            Name = "name",
            Type = ToolCallType.ToolCall,
        };

        ToolCall copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ToolCallTypeTest : TestBase
{
    [Theory]
    [InlineData(ToolCallType.ToolCall)]
    public void Validation_Works(ToolCallType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolCallType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolCallType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ToolCallType.ToolCall)]
    public void SerializationRoundtrip_Works(ToolCallType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolCallType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ToolCallType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolCallType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ToolCallType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ToolResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolResult
        {
            CallID = "call_id",
            Name = "name",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ImageAttachment = new() { AttachmentName = "attachment_name", SourceID = "source_id" },
            Type = ToolResultType.ToolResult,
        };

        string expectedCallID = "call_id";
        string expectedName = "name";
        JsonElement expectedResult = JsonSerializer.Deserialize<JsonElement>("{}");
        ImageAttachment expectedImageAttachment = new()
        {
            AttachmentName = "attachment_name",
            SourceID = "source_id",
        };
        ApiEnum<string, ToolResultType> expectedType = ToolResultType.ToolResult;

        Assert.Equal(expectedCallID, model.CallID);
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedResult, model.Result));
        Assert.Equal(expectedImageAttachment, model.ImageAttachment);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolResult
        {
            CallID = "call_id",
            Name = "name",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ImageAttachment = new() { AttachmentName = "attachment_name", SourceID = "source_id" },
            Type = ToolResultType.ToolResult,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolResult
        {
            CallID = "call_id",
            Name = "name",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ImageAttachment = new() { AttachmentName = "attachment_name", SourceID = "source_id" },
            Type = ToolResultType.ToolResult,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCallID = "call_id";
        string expectedName = "name";
        JsonElement expectedResult = JsonSerializer.Deserialize<JsonElement>("{}");
        ImageAttachment expectedImageAttachment = new()
        {
            AttachmentName = "attachment_name",
            SourceID = "source_id",
        };
        ApiEnum<string, ToolResultType> expectedType = ToolResultType.ToolResult;

        Assert.Equal(expectedCallID, deserialized.CallID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedResult, deserialized.Result));
        Assert.Equal(expectedImageAttachment, deserialized.ImageAttachment);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolResult
        {
            CallID = "call_id",
            Name = "name",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ImageAttachment = new() { AttachmentName = "attachment_name", SourceID = "source_id" },
            Type = ToolResultType.ToolResult,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolResult
        {
            CallID = "call_id",
            Name = "name",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ImageAttachment = new() { AttachmentName = "attachment_name", SourceID = "source_id" },
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolResult
        {
            CallID = "call_id",
            Name = "name",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ImageAttachment = new() { AttachmentName = "attachment_name", SourceID = "source_id" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ToolResult
        {
            CallID = "call_id",
            Name = "name",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ImageAttachment = new() { AttachmentName = "attachment_name", SourceID = "source_id" },

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolResult
        {
            CallID = "call_id",
            Name = "name",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ImageAttachment = new() { AttachmentName = "attachment_name", SourceID = "source_id" },

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolResult
        {
            CallID = "call_id",
            Name = "name",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Type = ToolResultType.ToolResult,
        };

        Assert.Null(model.ImageAttachment);
        Assert.False(model.RawData.ContainsKey("image_attachment"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolResult
        {
            CallID = "call_id",
            Name = "name",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Type = ToolResultType.ToolResult,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ToolResult
        {
            CallID = "call_id",
            Name = "name",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Type = ToolResultType.ToolResult,

            ImageAttachment = null,
        };

        Assert.Null(model.ImageAttachment);
        Assert.True(model.RawData.ContainsKey("image_attachment"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolResult
        {
            CallID = "call_id",
            Name = "name",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Type = ToolResultType.ToolResult,

            ImageAttachment = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ToolResult
        {
            CallID = "call_id",
            Name = "name",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ImageAttachment = new() { AttachmentName = "attachment_name", SourceID = "source_id" },
            Type = ToolResultType.ToolResult,
        };

        ToolResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageAttachmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageAttachment
        {
            AttachmentName = "attachment_name",
            SourceID = "source_id",
        };

        string expectedAttachmentName = "attachment_name";
        string expectedSourceID = "source_id";

        Assert.Equal(expectedAttachmentName, model.AttachmentName);
        Assert.Equal(expectedSourceID, model.SourceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImageAttachment
        {
            AttachmentName = "attachment_name",
            SourceID = "source_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageAttachment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageAttachment
        {
            AttachmentName = "attachment_name",
            SourceID = "source_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageAttachment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAttachmentName = "attachment_name";
        string expectedSourceID = "source_id";

        Assert.Equal(expectedAttachmentName, deserialized.AttachmentName);
        Assert.Equal(expectedSourceID, deserialized.SourceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImageAttachment
        {
            AttachmentName = "attachment_name",
            SourceID = "source_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ImageAttachment
        {
            AttachmentName = "attachment_name",
            SourceID = "source_id",
        };

        ImageAttachment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ToolResultTypeTest : TestBase
{
    [Theory]
    [InlineData(ToolResultType.ToolResult)]
    public void Validation_Works(ToolResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolResultType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ToolResultType.ToolResult)]
    public void SerializationRoundtrip_Works(ToolResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolResultType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ToolResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ToolResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UserInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserInput { Content = "content", Type = UserInputType.UserInput };

        string expectedContent = "content";
        ApiEnum<string, UserInputType> expectedType = UserInputType.UserInput;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserInput { Content = "content", Type = UserInputType.UserInput };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserInput>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserInput { Content = "content", Type = UserInputType.UserInput };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        ApiEnum<string, UserInputType> expectedType = UserInputType.UserInput;

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserInput { Content = "content", Type = UserInputType.UserInput };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserInput { Content = "content" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UserInput { Content = "content" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UserInput
        {
            Content = "content",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UserInput
        {
            Content = "content",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserInput { Content = "content", Type = UserInputType.UserInput };

        UserInput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UserInputTypeTest : TestBase
{
    [Theory]
    [InlineData(UserInputType.UserInput)]
    public void Validation_Works(UserInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserInputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserInputType.UserInput)]
    public void SerializationRoundtrip_Works(UserInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserInputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserInputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserInputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ChatRetrieveResponseJobMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatRetrieveResponseJobMetadata
        {
            DurationMs = 0,
            Error = "error",
            ExportConfigIds = ["string"],
            IsError = true,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            Turns = 0,
        };

        double expectedDurationMs = 0;
        string expectedError = "error";
        List<string> expectedExportConfigIds = ["string"];
        bool expectedIsError = true;
        long expectedTotalInputTokens = 0;
        long expectedTotalOutputTokens = 0;
        long expectedTurns = 0;

        Assert.Equal(expectedDurationMs, model.DurationMs);
        Assert.Equal(expectedError, model.Error);
        Assert.NotNull(model.ExportConfigIds);
        Assert.Equal(expectedExportConfigIds.Count, model.ExportConfigIds.Count);
        for (int i = 0; i < expectedExportConfigIds.Count; i++)
        {
            Assert.Equal(expectedExportConfigIds[i], model.ExportConfigIds[i]);
        }
        Assert.Equal(expectedIsError, model.IsError);
        Assert.Equal(expectedTotalInputTokens, model.TotalInputTokens);
        Assert.Equal(expectedTotalOutputTokens, model.TotalOutputTokens);
        Assert.Equal(expectedTurns, model.Turns);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatRetrieveResponseJobMetadata
        {
            DurationMs = 0,
            Error = "error",
            ExportConfigIds = ["string"],
            IsError = true,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            Turns = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatRetrieveResponseJobMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatRetrieveResponseJobMetadata
        {
            DurationMs = 0,
            Error = "error",
            ExportConfigIds = ["string"],
            IsError = true,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            Turns = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatRetrieveResponseJobMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedDurationMs = 0;
        string expectedError = "error";
        List<string> expectedExportConfigIds = ["string"];
        bool expectedIsError = true;
        long expectedTotalInputTokens = 0;
        long expectedTotalOutputTokens = 0;
        long expectedTurns = 0;

        Assert.Equal(expectedDurationMs, deserialized.DurationMs);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.NotNull(deserialized.ExportConfigIds);
        Assert.Equal(expectedExportConfigIds.Count, deserialized.ExportConfigIds.Count);
        for (int i = 0; i < expectedExportConfigIds.Count; i++)
        {
            Assert.Equal(expectedExportConfigIds[i], deserialized.ExportConfigIds[i]);
        }
        Assert.Equal(expectedIsError, deserialized.IsError);
        Assert.Equal(expectedTotalInputTokens, deserialized.TotalInputTokens);
        Assert.Equal(expectedTotalOutputTokens, deserialized.TotalOutputTokens);
        Assert.Equal(expectedTurns, deserialized.Turns);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatRetrieveResponseJobMetadata
        {
            DurationMs = 0,
            Error = "error",
            ExportConfigIds = ["string"],
            IsError = true,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            Turns = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatRetrieveResponseJobMetadata
        {
            Error = "error",
            ExportConfigIds = ["string"],
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
        };

        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("duration_ms"));
        Assert.Null(model.IsError);
        Assert.False(model.RawData.ContainsKey("is_error"));
        Assert.Null(model.Turns);
        Assert.False(model.RawData.ContainsKey("turns"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatRetrieveResponseJobMetadata
        {
            Error = "error",
            ExportConfigIds = ["string"],
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChatRetrieveResponseJobMetadata
        {
            Error = "error",
            ExportConfigIds = ["string"],
            TotalInputTokens = 0,
            TotalOutputTokens = 0,

            // Null should be interpreted as omitted for these properties
            DurationMs = null,
            IsError = null,
            Turns = null,
        };

        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("duration_ms"));
        Assert.Null(model.IsError);
        Assert.False(model.RawData.ContainsKey("is_error"));
        Assert.Null(model.Turns);
        Assert.False(model.RawData.ContainsKey("turns"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatRetrieveResponseJobMetadata
        {
            Error = "error",
            ExportConfigIds = ["string"],
            TotalInputTokens = 0,
            TotalOutputTokens = 0,

            // Null should be interpreted as omitted for these properties
            DurationMs = null,
            IsError = null,
            Turns = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatRetrieveResponseJobMetadata
        {
            DurationMs = 0,
            IsError = true,
            Turns = 0,
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.ExportConfigIds);
        Assert.False(model.RawData.ContainsKey("export_config_ids"));
        Assert.Null(model.TotalInputTokens);
        Assert.False(model.RawData.ContainsKey("total_input_tokens"));
        Assert.Null(model.TotalOutputTokens);
        Assert.False(model.RawData.ContainsKey("total_output_tokens"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatRetrieveResponseJobMetadata
        {
            DurationMs = 0,
            IsError = true,
            Turns = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChatRetrieveResponseJobMetadata
        {
            DurationMs = 0,
            IsError = true,
            Turns = 0,

            Error = null,
            ExportConfigIds = null,
            TotalInputTokens = null,
            TotalOutputTokens = null,
        };

        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
        Assert.Null(model.ExportConfigIds);
        Assert.True(model.RawData.ContainsKey("export_config_ids"));
        Assert.Null(model.TotalInputTokens);
        Assert.True(model.RawData.ContainsKey("total_input_tokens"));
        Assert.Null(model.TotalOutputTokens);
        Assert.True(model.RawData.ContainsKey("total_output_tokens"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatRetrieveResponseJobMetadata
        {
            DurationMs = 0,
            IsError = true,
            Turns = 0,

            Error = null,
            ExportConfigIds = null,
            TotalInputTokens = null,
            TotalOutputTokens = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatRetrieveResponseJobMetadata
        {
            DurationMs = 0,
            Error = "error",
            ExportConfigIds = ["string"],
            IsError = true,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            Turns = 0,
        };

        ChatRetrieveResponseJobMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
