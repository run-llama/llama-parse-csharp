using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Pipelines;

[JsonConverter(typeof(JsonModelConverter<CohereEmbeddingConfig, CohereEmbeddingConfigFromRaw>))]
public sealed record class CohereEmbeddingConfig : JsonModel
{
    /// <summary>
    /// Configuration for the Cohere embedding model.
    /// </summary>
    public CohereEmbedding? Component
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CohereEmbedding>("component");
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
    public ApiEnum<string, CohereEmbeddingConfigType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CohereEmbeddingConfigType>>(
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

    public CohereEmbeddingConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CohereEmbeddingConfig(CohereEmbeddingConfig cohereEmbeddingConfig)
        : base(cohereEmbeddingConfig) { }
#pragma warning restore CS8618

    public CohereEmbeddingConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CohereEmbeddingConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CohereEmbeddingConfigFromRaw.FromRawUnchecked"/>
    public static CohereEmbeddingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CohereEmbeddingConfigFromRaw : IFromRawJson<CohereEmbeddingConfig>
{
    /// <inheritdoc/>
    public CohereEmbeddingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CohereEmbeddingConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of the embedding model.
/// </summary>
[JsonConverter(typeof(CohereEmbeddingConfigTypeConverter))]
public enum CohereEmbeddingConfigType
{
    CohereEmbedding,
}

sealed class CohereEmbeddingConfigTypeConverter : JsonConverter<CohereEmbeddingConfigType>
{
    public override CohereEmbeddingConfigType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "COHERE_EMBEDDING" => CohereEmbeddingConfigType.CohereEmbedding,
            _ => (CohereEmbeddingConfigType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CohereEmbeddingConfigType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CohereEmbeddingConfigType.CohereEmbedding => "COHERE_EMBEDDING",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
