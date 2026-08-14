using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Beta.Chat;

/// <summary>
/// Summary of a chat session, including its title and last run metadata.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChatListResponse, ChatListResponseFromRaw>))]
public sealed record class ChatListResponse : JsonModel
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
    public ChatListResponseJobMetadata? JobMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChatListResponseJobMetadata>("job_metadata");
        }
        init { this._rawData.Set("job_metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LastUpdatedAt;
        _ = this.SessionID;
        _ = this.GeneratedTitle;
        _ = this.IndexIds;
        this.JobMetadata?.Validate();
    }

    public ChatListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatListResponse(ChatListResponse chatListResponse)
        : base(chatListResponse) { }
#pragma warning restore CS8618

    public ChatListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatListResponseFromRaw.FromRawUnchecked"/>
    public static ChatListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatListResponseFromRaw : IFromRawJson<ChatListResponse>
{
    /// <inheritdoc/>
    public ChatListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChatListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Token usage and status from the most recent run. Null if the session has not been
/// run yet.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ChatListResponseJobMetadata, ChatListResponseJobMetadataFromRaw>)
)]
public sealed record class ChatListResponseJobMetadata : JsonModel
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

    public ChatListResponseJobMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatListResponseJobMetadata(ChatListResponseJobMetadata chatListResponseJobMetadata)
        : base(chatListResponseJobMetadata) { }
#pragma warning restore CS8618

    public ChatListResponseJobMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatListResponseJobMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatListResponseJobMetadataFromRaw.FromRawUnchecked"/>
    public static ChatListResponseJobMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatListResponseJobMetadataFromRaw : IFromRawJson<ChatListResponseJobMetadata>
{
    /// <inheritdoc/>
    public ChatListResponseJobMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatListResponseJobMetadata.FromRawUnchecked(rawData);
}
