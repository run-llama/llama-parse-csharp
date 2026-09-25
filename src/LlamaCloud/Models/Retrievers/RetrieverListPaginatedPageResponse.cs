using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Retrievers;

/// <summary>
/// A page of retrievers.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RetrieverListPaginatedPageResponse,
        RetrieverListPaginatedPageResponseFromRaw
    >)
)]
public sealed record class RetrieverListPaginatedPageResponse : JsonModel
{
    /// <summary>
    /// The list of items.
    /// </summary>
    public required IReadOnlyList<RetrieverRetriever> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RetrieverRetriever>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<RetrieverRetriever>>(
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

    public RetrieverListPaginatedPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetrieverListPaginatedPageResponse(
        RetrieverListPaginatedPageResponse retrieverListPaginatedPageResponse
    )
        : base(retrieverListPaginatedPageResponse) { }
#pragma warning restore CS8618

    public RetrieverListPaginatedPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RetrieverListPaginatedPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RetrieverListPaginatedPageResponseFromRaw.FromRawUnchecked"/>
    public static RetrieverListPaginatedPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RetrieverListPaginatedPageResponse(IReadOnlyList<RetrieverRetriever> items)
        : this()
    {
        this.Items = items;
    }
}

class RetrieverListPaginatedPageResponseFromRaw : IFromRawJson<RetrieverListPaginatedPageResponse>
{
    /// <inheritdoc/>
    public RetrieverListPaginatedPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RetrieverListPaginatedPageResponse.FromRawUnchecked(rawData);
}
