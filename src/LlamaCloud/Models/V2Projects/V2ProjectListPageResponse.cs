using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.V2Projects;

/// <summary>
/// API query response schema for projects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<V2ProjectListPageResponse, V2ProjectListPageResponseFromRaw>)
)]
public sealed record class V2ProjectListPageResponse : JsonModel
{
    /// <summary>
    /// The list of items.
    /// </summary>
    public required IReadOnlyList<V2ProjectListResponse> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<V2ProjectListResponse>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<V2ProjectListResponse>>(
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

    public V2ProjectListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V2ProjectListPageResponse(V2ProjectListPageResponse v2ProjectListPageResponse)
        : base(v2ProjectListPageResponse) { }
#pragma warning restore CS8618

    public V2ProjectListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V2ProjectListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V2ProjectListPageResponseFromRaw.FromRawUnchecked"/>
    public static V2ProjectListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public V2ProjectListPageResponse(IReadOnlyList<V2ProjectListResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class V2ProjectListPageResponseFromRaw : IFromRawJson<V2ProjectListPageResponse>
{
    /// <inheritdoc/>
    public V2ProjectListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V2ProjectListPageResponse.FromRawUnchecked(rawData);
}
