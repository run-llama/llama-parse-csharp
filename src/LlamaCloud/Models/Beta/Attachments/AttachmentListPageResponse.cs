using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Beta.Attachments;

/// <summary>
/// Paginated list of file attachments.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AttachmentListPageResponse, AttachmentListPageResponseFromRaw>)
)]
public sealed record class AttachmentListPageResponse : JsonModel
{
    /// <summary>
    /// The list of items.
    /// </summary>
    public required IReadOnlyList<AttachmentListResponse> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AttachmentListResponse>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AttachmentListResponse>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A token, which can be sent as page_token to retrieve the next page. If this
    /// field is omitted, there are no subsequent pages.
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

    /// <summary>
    /// The total number of items available. This is only populated when specifically
    /// requested. The value may be an estimate and can be used for display purposes only.
    /// </summary>
    public long? TotalSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_size");
        }
        init { this._rawData.Set("total_size", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.NextPageToken;
        _ = this.TotalSize;
    }

    public AttachmentListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AttachmentListPageResponse(AttachmentListPageResponse attachmentListPageResponse)
        : base(attachmentListPageResponse) { }
#pragma warning restore CS8618

    public AttachmentListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AttachmentListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttachmentListPageResponseFromRaw.FromRawUnchecked"/>
    public static AttachmentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AttachmentListPageResponse(IReadOnlyList<AttachmentListResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class AttachmentListPageResponseFromRaw : IFromRawJson<AttachmentListPageResponse>
{
    /// <inheritdoc/>
    public AttachmentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AttachmentListPageResponse.FromRawUnchecked(rawData);
}
