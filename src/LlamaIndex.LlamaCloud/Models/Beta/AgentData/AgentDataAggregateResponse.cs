using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Beta.AgentData;

/// <summary>
/// API Result for a single group in the aggregate response
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AgentDataAggregateResponse, AgentDataAggregateResponseFromRaw>)
)]
public sealed record class AgentDataAggregateResponse : JsonModel
{
    public required IReadOnlyDictionary<string, JsonElement> GroupKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "group_key"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "group_key",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public long? Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? FirstItem
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "first_item"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "first_item",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GroupKey;
        _ = this.Count;
        _ = this.FirstItem;
    }

    public AgentDataAggregateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentDataAggregateResponse(AgentDataAggregateResponse agentDataAggregateResponse)
        : base(agentDataAggregateResponse) { }
#pragma warning restore CS8618

    public AgentDataAggregateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentDataAggregateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentDataAggregateResponseFromRaw.FromRawUnchecked"/>
    public static AgentDataAggregateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentDataAggregateResponseFromRaw : IFromRawJson<AgentDataAggregateResponse>
{
    /// <inheritdoc/>
    public AgentDataAggregateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AgentDataAggregateResponse.FromRawUnchecked(rawData);
}
