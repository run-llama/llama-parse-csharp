using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Beta.Chat;

/// <summary>
/// Summary of a chat session, including its title and last run metadata.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChatGetSummaryResponse, ChatGetSummaryResponseFromRaw>))]
public sealed record class ChatGetSummaryResponse : JsonModel
{
    /// <summary>
    /// ISO-format timestamp showing when the session was last updated.
    /// </summary>
    public required string LastUpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("last_updated_at");
        }
        init { this._rawData.Set("last_updated_at", value); }
    }

    /// <summary>
    /// Unique session identifier.
    /// </summary>
    public required string SessionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("session_id");
        }
        init { this._rawData.Set("session_id", value); }
    }

    /// <summary>
    /// What this chat's share link grants: read_only (transcript only) or query (viewers
    /// may ask new questions).
    /// </summary>
    public required ApiEnum<string, ChatGetSummaryResponseSharedAccess> SharedAccess
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChatGetSummaryResponseSharedAccess>
            >("shared_access");
        }
        init { this._rawData.Set("shared_access", value); }
    }

    /// <summary>
    /// Auto-generated title derived from the first user message.
    /// </summary>
    public string? GeneratedTitle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("generated_title");
        }
        init { this._rawData.Set("generated_title", value); }
    }

    /// <summary>
    /// Indexes this session is bound to. Null on unbound sessions.
    /// </summary>
    public IReadOnlyList<string>? IndexIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("index_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "index_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Token usage and status from the most recent run. Null if the session has
    /// not been run yet.
    /// </summary>
    public ChatGetSummaryResponseJobMetadata? JobMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChatGetSummaryResponseJobMetadata>(
                "job_metadata"
            );
        }
        init { this._rawData.Set("job_metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LastUpdatedAt;
        _ = this.SessionID;
        this.SharedAccess.Validate();
        _ = this.GeneratedTitle;
        _ = this.IndexIds;
        this.JobMetadata?.Validate();
    }

    public ChatGetSummaryResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatGetSummaryResponse(ChatGetSummaryResponse chatGetSummaryResponse)
        : base(chatGetSummaryResponse) { }
#pragma warning restore CS8618

    public ChatGetSummaryResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatGetSummaryResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatGetSummaryResponseFromRaw.FromRawUnchecked"/>
    public static ChatGetSummaryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatGetSummaryResponseFromRaw : IFromRawJson<ChatGetSummaryResponse>
{
    /// <inheritdoc/>
    public ChatGetSummaryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatGetSummaryResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// What this chat's share link grants: read_only (transcript only) or query (viewers
/// may ask new questions).
/// </summary>
[JsonConverter(typeof(ChatGetSummaryResponseSharedAccessConverter))]
public enum ChatGetSummaryResponseSharedAccess
{
    Query,
    ReadOnly,
}

sealed class ChatGetSummaryResponseSharedAccessConverter
    : JsonConverter<ChatGetSummaryResponseSharedAccess>
{
    public override ChatGetSummaryResponseSharedAccess Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "query" => ChatGetSummaryResponseSharedAccess.Query,
            "read_only" => ChatGetSummaryResponseSharedAccess.ReadOnly,
            _ => (ChatGetSummaryResponseSharedAccess)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChatGetSummaryResponseSharedAccess value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChatGetSummaryResponseSharedAccess.Query => "query",
                ChatGetSummaryResponseSharedAccess.ReadOnly => "read_only",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Token usage and status from the most recent run. Null if the session has not been
/// run yet.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChatGetSummaryResponseJobMetadata,
        ChatGetSummaryResponseJobMetadataFromRaw
    >)
)]
public sealed record class ChatGetSummaryResponseJobMetadata : JsonModel
{
    public double? DurationMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("duration_ms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("duration_ms", value);
        }
    }

    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    public IReadOnlyList<string>? ExportConfigIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("export_config_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "export_config_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? IsError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_error", value);
        }
    }

    public long? TotalInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_input_tokens");
        }
        init { this._rawData.Set("total_input_tokens", value); }
    }

    public long? TotalOutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_output_tokens");
        }
        init { this._rawData.Set("total_output_tokens", value); }
    }

    public long? Turns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("turns");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("turns", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DurationMs;
        _ = this.Error;
        _ = this.ExportConfigIds;
        _ = this.IsError;
        _ = this.TotalInputTokens;
        _ = this.TotalOutputTokens;
        _ = this.Turns;
    }

    public ChatGetSummaryResponseJobMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatGetSummaryResponseJobMetadata(
        ChatGetSummaryResponseJobMetadata chatGetSummaryResponseJobMetadata
    )
        : base(chatGetSummaryResponseJobMetadata) { }
#pragma warning restore CS8618

    public ChatGetSummaryResponseJobMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatGetSummaryResponseJobMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatGetSummaryResponseJobMetadataFromRaw.FromRawUnchecked"/>
    public static ChatGetSummaryResponseJobMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatGetSummaryResponseJobMetadataFromRaw : IFromRawJson<ChatGetSummaryResponseJobMetadata>
{
    /// <inheritdoc/>
    public ChatGetSummaryResponseJobMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatGetSummaryResponseJobMetadata.FromRawUnchecked(rawData);
}
