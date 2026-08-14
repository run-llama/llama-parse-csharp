using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models;

/// <summary>
/// Configuration for handling different types of failures during data source processing.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FailureHandlingConfig, FailureHandlingConfigFromRaw>))]
public sealed record class FailureHandlingConfig : JsonModel
{
    /// <summary>
    /// Whether to skip failed batches/lists and continue processing
    /// </summary>
    public bool? SkipListFailures
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("skip_list_failures");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("skip_list_failures", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SkipListFailures;
    }

    public FailureHandlingConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FailureHandlingConfig(FailureHandlingConfig failureHandlingConfig)
        : base(failureHandlingConfig) { }
#pragma warning restore CS8618

    public FailureHandlingConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FailureHandlingConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FailureHandlingConfigFromRaw.FromRawUnchecked"/>
    public static FailureHandlingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FailureHandlingConfigFromRaw : IFromRawJson<FailureHandlingConfig>
{
    /// <inheritdoc/>
    public FailureHandlingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FailureHandlingConfig.FromRawUnchecked(rawData);
}
