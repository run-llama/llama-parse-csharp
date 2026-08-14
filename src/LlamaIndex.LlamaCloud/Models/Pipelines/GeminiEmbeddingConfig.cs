using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Pipelines;

[JsonConverter(typeof(JsonModelConverter<GeminiEmbeddingConfig, GeminiEmbeddingConfigFromRaw>))]
public sealed record class GeminiEmbeddingConfig : JsonModel
{
    /// <summary>
    /// Configuration for the Gemini embedding model.
    /// </summary>
    public GeminiEmbedding? Component
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GeminiEmbedding>("component");
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
    public ApiEnum<string, GeminiEmbeddingConfigType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, GeminiEmbeddingConfigType>>(
                "type"
            );
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

    public GeminiEmbeddingConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GeminiEmbeddingConfig(GeminiEmbeddingConfig geminiEmbeddingConfig)
        : base(geminiEmbeddingConfig) { }
#pragma warning restore CS8618

    public GeminiEmbeddingConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GeminiEmbeddingConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GeminiEmbeddingConfigFromRaw.FromRawUnchecked"/>
    public static GeminiEmbeddingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GeminiEmbeddingConfigFromRaw : IFromRawJson<GeminiEmbeddingConfig>
{
    /// <inheritdoc/>
    public GeminiEmbeddingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GeminiEmbeddingConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of the embedding model.
/// </summary>
[JsonConverter(typeof(GeminiEmbeddingConfigTypeConverter))]
public enum GeminiEmbeddingConfigType
{
    GeminiEmbedding,
}

sealed class GeminiEmbeddingConfigTypeConverter : JsonConverter<GeminiEmbeddingConfigType>
{
    public override GeminiEmbeddingConfigType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GEMINI_EMBEDDING" => GeminiEmbeddingConfigType.GeminiEmbedding,
            _ => (GeminiEmbeddingConfigType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GeminiEmbeddingConfigType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GeminiEmbeddingConfigType.GeminiEmbedding => "GEMINI_EMBEDDING",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
