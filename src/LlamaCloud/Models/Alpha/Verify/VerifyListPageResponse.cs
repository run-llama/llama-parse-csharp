using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Alpha.Verify;

/// <summary>
/// Response schema for paginated Verify job queries.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VerifyListPageResponse, VerifyListPageResponseFromRaw>))]
public sealed record class VerifyListPageResponse : JsonModel
{
    /// <summary>
    /// The list of items.
    /// </summary>
    public required IReadOnlyList<VerifyListResponse> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<VerifyListResponse>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<VerifyListResponse>>(
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

    public VerifyListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyListPageResponse(VerifyListPageResponse verifyListPageResponse)
        : base(verifyListPageResponse) { }
#pragma warning restore CS8618

    public VerifyListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyListPageResponseFromRaw.FromRawUnchecked"/>
    public static VerifyListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VerifyListPageResponse(IReadOnlyList<VerifyListResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class VerifyListPageResponseFromRaw : IFromRawJson<VerifyListPageResponse>
{
    /// <inheritdoc/>
    public VerifyListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyListPageResponse.FromRawUnchecked(rawData);
}
