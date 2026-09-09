using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using Sheets = LlamaCloud.Models.Beta.Sheets;

namespace LlamaCloud.Models.Sheets;

/// <summary>
/// Response schema for paginated spreadsheet job queries.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SheetListPageResponse, SheetListPageResponseFromRaw>))]
public sealed record class SheetListPageResponse : JsonModel
{
    /// <summary>
    /// The list of items.
    /// </summary>
    public required IReadOnlyList<Sheets::SheetsJob> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Sheets::SheetsJob>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Sheets::SheetsJob>>(
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

    public SheetListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SheetListPageResponse(SheetListPageResponse sheetListPageResponse)
        : base(sheetListPageResponse) { }
#pragma warning restore CS8618

    public SheetListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SheetListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SheetListPageResponseFromRaw.FromRawUnchecked"/>
    public static SheetListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SheetListPageResponse(IReadOnlyList<Sheets::SheetsJob> items)
        : this()
    {
        this.Items = items;
    }
}

class SheetListPageResponseFromRaw : IFromRawJson<SheetListPageResponse>
{
    /// <inheritdoc/>
    public SheetListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SheetListPageResponse.FromRawUnchecked(rawData);
}
