using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Extract;

/// <summary>
/// Extraction usage metrics.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExtractJobUsage, ExtractJobUsageFromRaw>))]
public sealed record class ExtractJobUsage : JsonModel
{
    /// <summary>
    /// Number of effective pages billed
    /// </summary>
    public long? NumPagesBilled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("num_pages_billed");
        }
        init { this._rawData.Set("num_pages_billed", value); }
    }

    /// <summary>
    /// Number of pages extracted
    /// </summary>
    public long? NumPagesExtracted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("num_pages_extracted");
        }
        init { this._rawData.Set("num_pages_extracted", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NumPagesBilled;
        _ = this.NumPagesExtracted;
    }

    public ExtractJobUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractJobUsage(ExtractJobUsage extractJobUsage)
        : base(extractJobUsage) { }
#pragma warning restore CS8618

    public ExtractJobUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractJobUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractJobUsageFromRaw.FromRawUnchecked"/>
    public static ExtractJobUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractJobUsageFromRaw : IFromRawJson<ExtractJobUsage>
{
    /// <inheritdoc/>
    public ExtractJobUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExtractJobUsage.FromRawUnchecked(rawData);
}
