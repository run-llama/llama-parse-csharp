using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Pipelines;

/// <summary>
/// Configuration for sparse embedding models used in hybrid search.
///
/// <para>This allows users to choose between Splade and BM25 models for sparse retrieval
/// in managed data sinks.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SparseModelConfig, SparseModelConfigFromRaw>))]
public sealed record class SparseModelConfig : JsonModel
{
    public string? ClassName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("class_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("class_name", value);
        }
    }

    /// <summary>
    /// The sparse model type to use. 'bm25' uses Qdrant's FastEmbed BM25 model (default
    /// for new pipelines), 'splade' uses HuggingFace Splade model, 'auto' selects
    /// based on deployment mode (BYOC uses term frequency, Cloud uses Splade).
    /// </summary>
    public ApiEnum<string, ModelType>? ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ModelType>>("model_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("model_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClassName;
        this.ModelType?.Validate();
    }

    public SparseModelConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SparseModelConfig(SparseModelConfig sparseModelConfig)
        : base(sparseModelConfig) { }
#pragma warning restore CS8618

    public SparseModelConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SparseModelConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SparseModelConfigFromRaw.FromRawUnchecked"/>
    public static SparseModelConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SparseModelConfigFromRaw : IFromRawJson<SparseModelConfig>
{
    /// <inheritdoc/>
    public SparseModelConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SparseModelConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The sparse model type to use. 'bm25' uses Qdrant's FastEmbed BM25 model (default
/// for new pipelines), 'splade' uses HuggingFace Splade model, 'auto' selects based
/// on deployment mode (BYOC uses term frequency, Cloud uses Splade).
/// </summary>
[JsonConverter(typeof(ModelTypeConverter))]
public enum ModelType
{
    Auto,
    Bm25,
    Splade,
}

sealed class ModelTypeConverter : JsonConverter<ModelType>
{
    public override ModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => ModelType.Auto,
            "bm25" => ModelType.Bm25,
            "splade" => ModelType.Splade,
            _ => (ModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ModelType.Auto => "auto",
                ModelType.Bm25 => "bm25",
                ModelType.Splade => "splade",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
