using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Pipelines;

[JsonConverter(
    typeof(JsonModelConverter<
        HuggingFaceInferenceApiEmbeddingConfig,
        HuggingFaceInferenceApiEmbeddingConfigFromRaw
    >)
)]
public sealed record class HuggingFaceInferenceApiEmbeddingConfig : JsonModel
{
    /// <summary>
    /// Configuration for the HuggingFace Inference API embedding model.
    /// </summary>
    public HuggingFaceInferenceApiEmbedding? Component
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<HuggingFaceInferenceApiEmbedding>("component");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("component", value);
        }
    }

    /// <summary>
    /// Type of the embedding model.
    /// </summary>
    public ApiEnum<string, HuggingFaceInferenceApiEmbeddingConfigType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, HuggingFaceInferenceApiEmbeddingConfigType>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Component?.Validate();
        this.Type?.Validate();
    }

    public HuggingFaceInferenceApiEmbeddingConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public HuggingFaceInferenceApiEmbeddingConfig(
        HuggingFaceInferenceApiEmbeddingConfig huggingFaceInferenceApiEmbeddingConfig
    )
        : base(huggingFaceInferenceApiEmbeddingConfig) { }
#pragma warning restore CS8618

    public HuggingFaceInferenceApiEmbeddingConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HuggingFaceInferenceApiEmbeddingConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HuggingFaceInferenceApiEmbeddingConfigFromRaw.FromRawUnchecked"/>
    public static HuggingFaceInferenceApiEmbeddingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HuggingFaceInferenceApiEmbeddingConfigFromRaw
    : IFromRawJson<HuggingFaceInferenceApiEmbeddingConfig>
{
    /// <inheritdoc/>
    public HuggingFaceInferenceApiEmbeddingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => HuggingFaceInferenceApiEmbeddingConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of the embedding model.
/// </summary>
[JsonConverter(typeof(HuggingFaceInferenceApiEmbeddingConfigTypeConverter))]
public enum HuggingFaceInferenceApiEmbeddingConfigType
{
    HuggingfaceApiEmbedding,
}

sealed class HuggingFaceInferenceApiEmbeddingConfigTypeConverter
    : JsonConverter<HuggingFaceInferenceApiEmbeddingConfigType>
{
    public override HuggingFaceInferenceApiEmbeddingConfigType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "HUGGINGFACE_API_EMBEDDING" =>
                HuggingFaceInferenceApiEmbeddingConfigType.HuggingfaceApiEmbedding,
            _ => (HuggingFaceInferenceApiEmbeddingConfigType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        HuggingFaceInferenceApiEmbeddingConfigType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                HuggingFaceInferenceApiEmbeddingConfigType.HuggingfaceApiEmbedding =>
                    "HUGGINGFACE_API_EMBEDDING",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
