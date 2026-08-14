using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Pipelines;

[JsonConverter(typeof(JsonModelConverter<PipelineMetadataConfig, PipelineMetadataConfigFromRaw>))]
public sealed record class PipelineMetadataConfig : JsonModel
{
    /// <summary>
    /// List of metadata keys to exclude from embeddings
    /// </summary>
    public IReadOnlyList<string>? ExcludedEmbedMetadataKeys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "excluded_embed_metadata_keys"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "excluded_embed_metadata_keys",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of metadata keys to exclude from LLM during retrieval
    /// </summary>
    public IReadOnlyList<string>? ExcludedLlmMetadataKeys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "excluded_llm_metadata_keys"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "excluded_llm_metadata_keys",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExcludedEmbedMetadataKeys;
        _ = this.ExcludedLlmMetadataKeys;
    }

    public PipelineMetadataConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PipelineMetadataConfig(PipelineMetadataConfig pipelineMetadataConfig)
        : base(pipelineMetadataConfig) { }
#pragma warning restore CS8618

    public PipelineMetadataConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PipelineMetadataConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PipelineMetadataConfigFromRaw.FromRawUnchecked"/>
    public static PipelineMetadataConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PipelineMetadataConfigFromRaw : IFromRawJson<PipelineMetadataConfig>
{
    /// <inheritdoc/>
    public PipelineMetadataConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PipelineMetadataConfig.FromRawUnchecked(rawData);
}
