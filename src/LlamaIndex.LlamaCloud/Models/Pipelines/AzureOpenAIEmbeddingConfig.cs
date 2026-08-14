using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Pipelines;

[JsonConverter(
    typeof(JsonModelConverter<AzureOpenAIEmbeddingConfig, AzureOpenAIEmbeddingConfigFromRaw>)
)]
public sealed record class AzureOpenAIEmbeddingConfig : JsonModel
{
    /// <summary>
    /// Configuration for the Azure OpenAI embedding model.
    /// </summary>
    public AzureOpenAIEmbedding? Component
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AzureOpenAIEmbedding>("component");
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
    public ApiEnum<string, global::LlamaIndex.LlamaCloud.Models.Pipelines.Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::LlamaIndex.LlamaCloud.Models.Pipelines.Type>
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

    public AzureOpenAIEmbeddingConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AzureOpenAIEmbeddingConfig(AzureOpenAIEmbeddingConfig azureOpenAIEmbeddingConfig)
        : base(azureOpenAIEmbeddingConfig) { }
#pragma warning restore CS8618

    public AzureOpenAIEmbeddingConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AzureOpenAIEmbeddingConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AzureOpenAIEmbeddingConfigFromRaw.FromRawUnchecked"/>
    public static AzureOpenAIEmbeddingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AzureOpenAIEmbeddingConfigFromRaw : IFromRawJson<AzureOpenAIEmbeddingConfig>
{
    /// <inheritdoc/>
    public AzureOpenAIEmbeddingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AzureOpenAIEmbeddingConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of the embedding model.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    AzureEmbedding,
}

sealed class TypeConverter : JsonConverter<global::LlamaIndex.LlamaCloud.Models.Pipelines.Type>
{
    public override global::LlamaIndex.LlamaCloud.Models.Pipelines.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AZURE_EMBEDDING" => global::LlamaIndex.LlamaCloud.Models.Pipelines.Type.AzureEmbedding,
            _ => (global::LlamaIndex.LlamaCloud.Models.Pipelines.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::LlamaIndex.LlamaCloud.Models.Pipelines.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::LlamaIndex.LlamaCloud.Models.Pipelines.Type.AzureEmbedding =>
                    "AZURE_EMBEDDING",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
