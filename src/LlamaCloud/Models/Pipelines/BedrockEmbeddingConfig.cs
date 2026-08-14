using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Pipelines;

[JsonConverter(typeof(JsonModelConverter<BedrockEmbeddingConfig, BedrockEmbeddingConfigFromRaw>))]
public sealed record class BedrockEmbeddingConfig : JsonModel
{
    /// <summary>
    /// Configuration for the Bedrock embedding model.
    /// </summary>
    public BedrockEmbedding? Component
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BedrockEmbedding>("component");
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
    public ApiEnum<string, BedrockEmbeddingConfigType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BedrockEmbeddingConfigType>>(
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

    public BedrockEmbeddingConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BedrockEmbeddingConfig(BedrockEmbeddingConfig bedrockEmbeddingConfig)
        : base(bedrockEmbeddingConfig) { }
#pragma warning restore CS8618

    public BedrockEmbeddingConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BedrockEmbeddingConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BedrockEmbeddingConfigFromRaw.FromRawUnchecked"/>
    public static BedrockEmbeddingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BedrockEmbeddingConfigFromRaw : IFromRawJson<BedrockEmbeddingConfig>
{
    /// <inheritdoc/>
    public BedrockEmbeddingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BedrockEmbeddingConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of the embedding model.
/// </summary>
[JsonConverter(typeof(BedrockEmbeddingConfigTypeConverter))]
public enum BedrockEmbeddingConfigType
{
    BedrockEmbedding,
}

sealed class BedrockEmbeddingConfigTypeConverter : JsonConverter<BedrockEmbeddingConfigType>
{
    public override BedrockEmbeddingConfigType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BEDROCK_EMBEDDING" => BedrockEmbeddingConfigType.BedrockEmbedding,
            _ => (BedrockEmbeddingConfigType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BedrockEmbeddingConfigType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BedrockEmbeddingConfigType.BedrockEmbedding => "BEDROCK_EMBEDDING",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
