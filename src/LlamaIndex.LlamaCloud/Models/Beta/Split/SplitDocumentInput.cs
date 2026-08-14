using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Beta.Split;

/// <summary>
/// Document input specification for beta API.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SplitDocumentInput, SplitDocumentInputFromRaw>))]
public sealed record class SplitDocumentInput : JsonModel
{
    /// <summary>
    /// Type of document input. Valid values are: file_id
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Document identifier.
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Type;
        _ = this.Value;
    }

    public SplitDocumentInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitDocumentInput(SplitDocumentInput splitDocumentInput)
        : base(splitDocumentInput) { }
#pragma warning restore CS8618

    public SplitDocumentInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitDocumentInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitDocumentInputFromRaw.FromRawUnchecked"/>
    public static SplitDocumentInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SplitDocumentInputFromRaw : IFromRawJson<SplitDocumentInput>
{
    /// <inheritdoc/>
    public SplitDocumentInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SplitDocumentInput.FromRawUnchecked(rawData);
}
