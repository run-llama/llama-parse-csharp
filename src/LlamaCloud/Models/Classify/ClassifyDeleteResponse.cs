using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Classify;

/// <summary>
/// Identifiers for a deleted classify job.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ClassifyDeleteResponse, ClassifyDeleteResponseFromRaw>))]
public sealed record class ClassifyDeleteResponse : JsonModel
{
    /// <summary>
    /// Identifier of the deleted classify job
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
    /// Project the deleted job belonged to
    /// </summary>
    public string? ProjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("project_id");
        }
        init { this._rawData.Set("project_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ProjectID;
    }

    public ClassifyDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClassifyDeleteResponse(ClassifyDeleteResponse classifyDeleteResponse)
        : base(classifyDeleteResponse) { }
#pragma warning restore CS8618

    public ClassifyDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClassifyDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClassifyDeleteResponseFromRaw.FromRawUnchecked"/>
    public static ClassifyDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ClassifyDeleteResponse(string id)
        : this()
    {
        this.ID = id;
    }
}

class ClassifyDeleteResponseFromRaw : IFromRawJson<ClassifyDeleteResponse>
{
    /// <inheritdoc/>
    public ClassifyDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClassifyDeleteResponse.FromRawUnchecked(rawData);
}
