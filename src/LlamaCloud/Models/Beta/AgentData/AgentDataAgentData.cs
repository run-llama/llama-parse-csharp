using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Beta.AgentData;

/// <summary>
/// API Result for a single agent data item
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AgentDataAgentData, AgentDataAgentDataFromRaw>))]
public sealed record class AgentDataAgentData : JsonModel
{
    public required IReadOnlyDictionary<string, JsonElement> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("data");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "data",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required string DeploymentName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("deployment_name");
        }
        init { this._rawData.Set("deployment_name", value); }
    }

    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public string? Collection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("collection");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("collection", value);
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public string? ProjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("project_id");
        }
        init { this._rawData.Set("project_id", value); }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        _ = this.DeploymentName;
        _ = this.ID;
        _ = this.Collection;
        _ = this.CreatedAt;
        _ = this.ProjectID;
        _ = this.UpdatedAt;
    }

    public AgentDataAgentData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentDataAgentData(AgentDataAgentData agentDataAgentData)
        : base(agentDataAgentData) { }
#pragma warning restore CS8618

    public AgentDataAgentData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentDataAgentData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentDataAgentDataFromRaw.FromRawUnchecked"/>
    public static AgentDataAgentData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentDataAgentDataFromRaw : IFromRawJson<AgentDataAgentData>
{
    /// <inheritdoc/>
    public AgentDataAgentData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentDataAgentData.FromRawUnchecked(rawData);
}
