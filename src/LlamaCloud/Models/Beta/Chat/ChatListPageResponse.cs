using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Beta.Chat;

/// <summary>
/// Paginated list of chat sessions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChatListPageResponse, ChatListPageResponseFromRaw>))]
public sealed record class ChatListPageResponse : JsonModel
{
    /// <summary>
    /// Chat sessions for the current page.
    /// </summary>
    public required IReadOnlyList<ChatListResponse> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ChatListResponse>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ChatListResponse>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Opaque token to retrieve the next page. Omitted when there are no further pages.
    /// </summary>
    public string? NextPageToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_page_token");
        }
        init { this._rawData.Set("next_page_token", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.NextPageToken;
    }

    public ChatListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatListPageResponse(ChatListPageResponse chatListPageResponse)
        : base(chatListPageResponse) { }
#pragma warning restore CS8618

    public ChatListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatListPageResponseFromRaw.FromRawUnchecked"/>
    public static ChatListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChatListPageResponse(IReadOnlyList<ChatListResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class ChatListPageResponseFromRaw : IFromRawJson<ChatListPageResponse>
{
    /// <inheritdoc/>
    public ChatListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatListPageResponse.FromRawUnchecked(rawData);
}
