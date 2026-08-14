using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Beta.AgentData;

/// <summary>
/// Paginated agent data aggregation groups.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AgentDataAggregatePageResponse,
        AgentDataAggregatePageResponseFromRaw
    >)
)]
public sealed record class AgentDataAggregatePageResponse : JsonModel
{
    /// <summary>
    /// The list of items.
    /// </summary>
    public required IReadOnlyList<AgentDataAggregateResponse> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AgentDataAggregateResponse>>(
                "items"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<AgentDataAggregateResponse>>(
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

    public AgentDataAggregatePageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentDataAggregatePageResponse(
        AgentDataAggregatePageResponse agentDataAggregatePageResponse
    )
        : base(agentDataAggregatePageResponse) { }
#pragma warning restore CS8618

    public AgentDataAggregatePageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentDataAggregatePageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentDataAggregatePageResponseFromRaw.FromRawUnchecked"/>
    public static AgentDataAggregatePageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AgentDataAggregatePageResponse(IReadOnlyList<AgentDataAggregateResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class AgentDataAggregatePageResponseFromRaw : IFromRawJson<AgentDataAggregatePageResponse>
{
    /// <inheritdoc/>
    public AgentDataAggregatePageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AgentDataAggregatePageResponse.FromRawUnchecked(rawData);
}
