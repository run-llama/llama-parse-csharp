using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Pipelines;

[JsonConverter(typeof(JsonModelConverter<VertexAIEmbeddingConfig, VertexAIEmbeddingConfigFromRaw>))]
public sealed record class VertexAIEmbeddingConfig : JsonModel
{
    /// <summary>
    /// Configuration for the VertexAI embedding model.
    /// </summary>
    public VertexTextEmbedding? Component
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VertexTextEmbedding>("component");
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
    public ApiEnum<string, VertexAIEmbeddingConfigType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VertexAIEmbeddingConfigType>>(
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

    public VertexAIEmbeddingConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VertexAIEmbeddingConfig(VertexAIEmbeddingConfig vertexAIEmbeddingConfig)
        : base(vertexAIEmbeddingConfig) { }
#pragma warning restore CS8618

    public VertexAIEmbeddingConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VertexAIEmbeddingConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VertexAIEmbeddingConfigFromRaw.FromRawUnchecked"/>
    public static VertexAIEmbeddingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VertexAIEmbeddingConfigFromRaw : IFromRawJson<VertexAIEmbeddingConfig>
{
    /// <inheritdoc/>
    public VertexAIEmbeddingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VertexAIEmbeddingConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of the embedding model.
/// </summary>
[JsonConverter(typeof(VertexAIEmbeddingConfigTypeConverter))]
public enum VertexAIEmbeddingConfigType
{
    VertexaiEmbedding,
}

sealed class VertexAIEmbeddingConfigTypeConverter : JsonConverter<VertexAIEmbeddingConfigType>
{
    public override VertexAIEmbeddingConfigType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "VERTEXAI_EMBEDDING" => VertexAIEmbeddingConfigType.VertexaiEmbedding,
            _ => (VertexAIEmbeddingConfigType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VertexAIEmbeddingConfigType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VertexAIEmbeddingConfigType.VertexaiEmbedding => "VERTEXAI_EMBEDDING",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
