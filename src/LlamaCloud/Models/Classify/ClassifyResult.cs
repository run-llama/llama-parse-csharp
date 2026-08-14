using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Classify;

/// <summary>
/// Result of classifying a document.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ClassifyResult, ClassifyResultFromRaw>))]
public sealed record class ClassifyResult : JsonModel
{
    /// <summary>
    /// Confidence score between 0.0 and 1.0
    /// </summary>
    public required double Confidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("confidence");
        }
        init { this._rawData.Set("confidence", value); }
    }

    /// <summary>
    /// Why the document matched (or didn't match) the returned rule
    /// </summary>
    public required string Reasoning
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reasoning");
        }
        init { this._rawData.Set("reasoning", value); }
    }

    /// <summary>
    /// Matched rule type, or null if no rule matched
    /// </summary>
    public required string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Confidence;
        _ = this.Reasoning;
        _ = this.Type;
    }

    public ClassifyResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClassifyResult(ClassifyResult classifyResult)
        : base(classifyResult) { }
#pragma warning restore CS8618

    public ClassifyResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClassifyResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClassifyResultFromRaw.FromRawUnchecked"/>
    public static ClassifyResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClassifyResultFromRaw : IFromRawJson<ClassifyResult>
{
    /// <inheritdoc/>
    public ClassifyResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ClassifyResult.FromRawUnchecked(rawData);
}
