using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.V2Projects;

/// <summary>
/// API response schema for a project.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<V2ProjectGetResponse, V2ProjectGetResponseFromRaw>))]
public sealed record class V2ProjectGetResponse : JsonModel
{
    /// <summary>
    /// The project's unique identifier.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The project's display name.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The organization the project belongs to.
    /// </summary>
    public required string OrganizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("organization_id");
        }
        init { this._rawData.Set("organization_id", value); }
    }

    /// <summary>
    /// Creation datetime
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Whether this project is the default project for its organization.
    /// </summary>
    public bool? IsDefault
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_default");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_default", value);
        }
    }

    /// <summary>
    /// Update datetime
    /// </summary>
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
        _ = this.ID;
        _ = this.Name;
        _ = this.OrganizationID;
        _ = this.CreatedAt;
        _ = this.IsDefault;
        _ = this.UpdatedAt;
    }

    public V2ProjectGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V2ProjectGetResponse(V2ProjectGetResponse v2ProjectGetResponse)
        : base(v2ProjectGetResponse) { }
#pragma warning restore CS8618

    public V2ProjectGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V2ProjectGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V2ProjectGetResponseFromRaw.FromRawUnchecked"/>
    public static V2ProjectGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V2ProjectGetResponseFromRaw : IFromRawJson<V2ProjectGetResponse>
{
    /// <inheritdoc/>
    public V2ProjectGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V2ProjectGetResponse.FromRawUnchecked(rawData);
}
