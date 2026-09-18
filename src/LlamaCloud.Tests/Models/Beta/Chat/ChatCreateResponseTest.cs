using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Beta.Chat;

namespace LlamaCloud.Tests.Models.Beta.Chat;

public class ChatCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCreateResponse
        {
            LastUpdatedAt = "2026-04-22T12:34:41.342245",
            SessionID = "ses-abc123",
            SharedAccess = ChatCreateResponseSharedAccess.ReadOnly,
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

        string expectedLastUpdatedAt = "2026-04-22T12:34:41.342245";
        string expectedSessionID = "ses-abc123";
        ApiEnum<string, ChatCreateResponseSharedAccess> expectedSharedAccess =
            ChatCreateResponseSharedAccess.ReadOnly;
        string expectedGeneratedTitle = "What were the main findings in Q3?...";
        List<string> expectedIndexIds = ["idx-abc123", "idx-def456"];
        JobMetadata expectedJobMetadata = new()
        {
            DurationMs = 0,
            Error = "error",
            ExportConfigIds = ["string"],
            IsError = true,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            Turns = 0,
        };

        Assert.Equal(expectedLastUpdatedAt, model.LastUpdatedAt);
        Assert.Equal(expectedSessionID, model.SessionID);
        Assert.Equal(expectedSharedAccess, model.SharedAccess);
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
        var model = new ChatCreateResponse
        {
            LastUpdatedAt = "2026-04-22T12:34:41.342245",
            SessionID = "ses-abc123",
            SharedAccess = ChatCreateResponseSharedAccess.ReadOnly,
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
        var deserialized = JsonSerializer.Deserialize<ChatCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCreateResponse
        {
            LastUpdatedAt = "2026-04-22T12:34:41.342245",
            SessionID = "ses-abc123",
            SharedAccess = ChatCreateResponseSharedAccess.ReadOnly,
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
        var deserialized = JsonSerializer.Deserialize<ChatCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedLastUpdatedAt = "2026-04-22T12:34:41.342245";
        string expectedSessionID = "ses-abc123";
        ApiEnum<string, ChatCreateResponseSharedAccess> expectedSharedAccess =
            ChatCreateResponseSharedAccess.ReadOnly;
        string expectedGeneratedTitle = "What were the main findings in Q3?...";
        List<string> expectedIndexIds = ["idx-abc123", "idx-def456"];
        JobMetadata expectedJobMetadata = new()
        {
            DurationMs = 0,
            Error = "error",
            ExportConfigIds = ["string"],
            IsError = true,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            Turns = 0,
        };

        Assert.Equal(expectedLastUpdatedAt, deserialized.LastUpdatedAt);
        Assert.Equal(expectedSessionID, deserialized.SessionID);
        Assert.Equal(expectedSharedAccess, deserialized.SharedAccess);
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
        var model = new ChatCreateResponse
        {
            LastUpdatedAt = "2026-04-22T12:34:41.342245",
            SessionID = "ses-abc123",
            SharedAccess = ChatCreateResponseSharedAccess.ReadOnly,
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
        var model = new ChatCreateResponse
        {
            LastUpdatedAt = "2026-04-22T12:34:41.342245",
            SessionID = "ses-abc123",
            SharedAccess = ChatCreateResponseSharedAccess.ReadOnly,
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
        var model = new ChatCreateResponse
        {
            LastUpdatedAt = "2026-04-22T12:34:41.342245",
            SessionID = "ses-abc123",
            SharedAccess = ChatCreateResponseSharedAccess.ReadOnly,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChatCreateResponse
        {
            LastUpdatedAt = "2026-04-22T12:34:41.342245",
            SessionID = "ses-abc123",
            SharedAccess = ChatCreateResponseSharedAccess.ReadOnly,

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
        var model = new ChatCreateResponse
        {
            LastUpdatedAt = "2026-04-22T12:34:41.342245",
            SessionID = "ses-abc123",
            SharedAccess = ChatCreateResponseSharedAccess.ReadOnly,

            GeneratedTitle = null,
            IndexIds = null,
            JobMetadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCreateResponse
        {
            LastUpdatedAt = "2026-04-22T12:34:41.342245",
            SessionID = "ses-abc123",
            SharedAccess = ChatCreateResponseSharedAccess.ReadOnly,
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

        ChatCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChatCreateResponseSharedAccessTest : TestBase
{
    [Theory]
    [InlineData(ChatCreateResponseSharedAccess.Query)]
    [InlineData(ChatCreateResponseSharedAccess.ReadOnly)]
    public void Validation_Works(ChatCreateResponseSharedAccess rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChatCreateResponseSharedAccess> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChatCreateResponseSharedAccess>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChatCreateResponseSharedAccess.Query)]
    [InlineData(ChatCreateResponseSharedAccess.ReadOnly)]
    public void SerializationRoundtrip_Works(ChatCreateResponseSharedAccess rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChatCreateResponseSharedAccess> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChatCreateResponseSharedAccess>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChatCreateResponseSharedAccess>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChatCreateResponseSharedAccess>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class JobMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JobMetadata
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
        var model = new JobMetadata
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
        var deserialized = JsonSerializer.Deserialize<JobMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JobMetadata
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
        var deserialized = JsonSerializer.Deserialize<JobMetadata>(
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
        var model = new JobMetadata
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
        var model = new JobMetadata
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
        var model = new JobMetadata
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
        var model = new JobMetadata
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
        var model = new JobMetadata
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
        var model = new JobMetadata
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
        var model = new JobMetadata
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
        var model = new JobMetadata
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
        var model = new JobMetadata
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
        var model = new JobMetadata
        {
            DurationMs = 0,
            Error = "error",
            ExportConfigIds = ["string"],
            IsError = true,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            Turns = 0,
        };

        JobMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
