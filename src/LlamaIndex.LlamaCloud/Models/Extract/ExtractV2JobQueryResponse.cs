using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Extract;

/// <summary>
/// Paginated list of extraction jobs.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ExtractV2JobQueryResponse, ExtractV2JobQueryResponseFromRaw>)
)]
public sealed record class ExtractV2JobQueryResponse : JsonModel
{
    /// <summary>
    /// The list of items.
    /// </summary>
    public required IReadOnlyList<ExtractV2Job> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ExtractV2Job>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ExtractV2Job>>(
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

    public ExtractV2JobQueryResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractV2JobQueryResponse(ExtractV2JobQueryResponse extractV2JobQueryResponse)
        : base(extractV2JobQueryResponse) { }
#pragma warning restore CS8618

    public ExtractV2JobQueryResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractV2JobQueryResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractV2JobQueryResponseFromRaw.FromRawUnchecked"/>
    public static ExtractV2JobQueryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExtractV2JobQueryResponse(IReadOnlyList<ExtractV2Job> items)
        : this()
    {
        this.Items = items;
    }
}

class ExtractV2JobQueryResponseFromRaw : IFromRawJson<ExtractV2JobQueryResponse>
{
    /// <inheritdoc/>
    public ExtractV2JobQueryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtractV2JobQueryResponse.FromRawUnchecked(rawData);
}
