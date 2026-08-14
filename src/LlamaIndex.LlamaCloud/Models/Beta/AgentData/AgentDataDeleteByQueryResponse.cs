using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Beta.AgentData;

/// <summary>
/// API response for bulk delete operation
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AgentDataDeleteByQueryResponse,
        AgentDataDeleteByQueryResponseFromRaw
    >)
)]
public sealed record class AgentDataDeleteByQueryResponse : JsonModel
{
    public required long DeletedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("deleted_count");
        }
        init { this._rawData.Set("deleted_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DeletedCount;
    }

    public AgentDataDeleteByQueryResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentDataDeleteByQueryResponse(
        AgentDataDeleteByQueryResponse agentDataDeleteByQueryResponse
    )
        : base(agentDataDeleteByQueryResponse) { }
#pragma warning restore CS8618

    public AgentDataDeleteByQueryResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentDataDeleteByQueryResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentDataDeleteByQueryResponseFromRaw.FromRawUnchecked"/>
    public static AgentDataDeleteByQueryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AgentDataDeleteByQueryResponse(long deletedCount)
        : this()
    {
        this.DeletedCount = deletedCount;
    }
}

class AgentDataDeleteByQueryResponseFromRaw : IFromRawJson<AgentDataDeleteByQueryResponse>
{
    /// <inheritdoc/>
    public AgentDataDeleteByQueryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AgentDataDeleteByQueryResponse.FromRawUnchecked(rawData);
}
