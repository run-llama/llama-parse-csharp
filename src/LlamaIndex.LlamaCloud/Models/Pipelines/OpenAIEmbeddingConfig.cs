using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Pipelines;

[JsonConverter(typeof(JsonModelConverter<OpenAIEmbeddingConfig, OpenAIEmbeddingConfigFromRaw>))]
public sealed record class OpenAIEmbeddingConfig : JsonModel
{
    /// <summary>
    /// Configuration for the OpenAI embedding model.
    /// </summary>
    public OpenAIEmbedding? Component
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OpenAIEmbedding>("component");
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
    public ApiEnum<string, OpenAIEmbeddingConfigType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OpenAIEmbeddingConfigType>>(
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

    public OpenAIEmbeddingConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OpenAIEmbeddingConfig(OpenAIEmbeddingConfig openaiEmbeddingConfig)
        : base(openaiEmbeddingConfig) { }
#pragma warning restore CS8618

    public OpenAIEmbeddingConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OpenAIEmbeddingConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OpenAIEmbeddingConfigFromRaw.FromRawUnchecked"/>
    public static OpenAIEmbeddingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OpenAIEmbeddingConfigFromRaw : IFromRawJson<OpenAIEmbeddingConfig>
{
    /// <inheritdoc/>
    public OpenAIEmbeddingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OpenAIEmbeddingConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of the embedding model.
/// </summary>
[JsonConverter(typeof(OpenAIEmbeddingConfigTypeConverter))]
public enum OpenAIEmbeddingConfigType
{
    OpenAIEmbedding,
}

sealed class OpenAIEmbeddingConfigTypeConverter : JsonConverter<OpenAIEmbeddingConfigType>
{
    public override OpenAIEmbeddingConfigType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPENAI_EMBEDDING" => OpenAIEmbeddingConfigType.OpenAIEmbedding,
            _ => (OpenAIEmbeddingConfigType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OpenAIEmbeddingConfigType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OpenAIEmbeddingConfigType.OpenAIEmbedding => "OPENAI_EMBEDDING",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
