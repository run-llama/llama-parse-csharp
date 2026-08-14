using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Beta.Retrieval;

/// <summary>
/// Paginated file find results.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<RetrievalFindPageResponse, RetrievalFindPageResponseFromRaw>)
)]
public sealed record class RetrievalFindPageResponse : JsonModel
{
    /// <summary>
    /// The list of items.
    /// </summary>
    public required IReadOnlyList<RetrievalFindResponse> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RetrievalFindResponse>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<RetrievalFindResponse>>(
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

    public RetrievalFindPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetrievalFindPageResponse(RetrievalFindPageResponse retrievalFindPageResponse)
        : base(retrievalFindPageResponse) { }
#pragma warning restore CS8618

    public RetrievalFindPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RetrievalFindPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RetrievalFindPageResponseFromRaw.FromRawUnchecked"/>
    public static RetrievalFindPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RetrievalFindPageResponse(IReadOnlyList<RetrievalFindResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class RetrievalFindPageResponseFromRaw : IFromRawJson<RetrievalFindPageResponse>
{
    /// <inheritdoc/>
    public RetrievalFindPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RetrievalFindPageResponse.FromRawUnchecked(rawData);
}
