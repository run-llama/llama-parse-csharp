using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Extract.Review;

/// <summary>
/// A page of a review's history, newest first.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ReviewListEventsPageResponse, ReviewListEventsPageResponseFromRaw>)
)]
public sealed record class ReviewListEventsPageResponse : JsonModel
{
    /// <summary>
    /// The list of items.
    /// </summary>
    public required IReadOnlyList<ExtractReviewEvent> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ExtractReviewEvent>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ExtractReviewEvent>>(
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

    public ReviewListEventsPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReviewListEventsPageResponse(ReviewListEventsPageResponse reviewListEventsPageResponse)
        : base(reviewListEventsPageResponse) { }
#pragma warning restore CS8618

    public ReviewListEventsPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReviewListEventsPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReviewListEventsPageResponseFromRaw.FromRawUnchecked"/>
    public static ReviewListEventsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReviewListEventsPageResponse(IReadOnlyList<ExtractReviewEvent> items)
        : this()
    {
        this.Items = items;
    }
}

class ReviewListEventsPageResponseFromRaw : IFromRawJson<ReviewListEventsPageResponse>
{
    /// <inheritdoc/>
    public ReviewListEventsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReviewListEventsPageResponse.FromRawUnchecked(rawData);
}
