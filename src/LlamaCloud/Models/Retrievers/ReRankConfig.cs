using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Retrievers;

[JsonConverter(typeof(JsonModelConverter<ReRankConfig, ReRankConfigFromRaw>))]
public sealed record class ReRankConfig : JsonModel
{
    /// <summary>
    /// The number of nodes to retrieve after reranking over retrieved nodes from
    /// all retrieval tools.
    /// </summary>
    public long? TopN
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("top_n");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("top_n", value);
        }
    }

    /// <summary>
    /// The type of reranker to use.
    /// </summary>
    public ApiEnum<string, global::LlamaCloud.Models.Retrievers.Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::LlamaCloud.Models.Retrievers.Type>
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
        _ = this.TopN;
        this.Type?.Validate();
    }

    public ReRankConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReRankConfig(ReRankConfig reRankConfig)
        : base(reRankConfig) { }
#pragma warning restore CS8618

    public ReRankConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReRankConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReRankConfigFromRaw.FromRawUnchecked"/>
    public static ReRankConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReRankConfigFromRaw : IFromRawJson<ReRankConfig>
{
    /// <inheritdoc/>
    public ReRankConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReRankConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of reranker to use.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Bedrock,
    Cohere,
    Disabled,
    Llm,
    Score,
    SystemDefault,
}

sealed class TypeConverter : JsonConverter<global::LlamaCloud.Models.Retrievers.Type>
{
    public override global::LlamaCloud.Models.Retrievers.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "bedrock" => global::LlamaCloud.Models.Retrievers.Type.Bedrock,
            "cohere" => global::LlamaCloud.Models.Retrievers.Type.Cohere,
            "disabled" => global::LlamaCloud.Models.Retrievers.Type.Disabled,
            "llm" => global::LlamaCloud.Models.Retrievers.Type.Llm,
            "score" => global::LlamaCloud.Models.Retrievers.Type.Score,
            "system_default" => global::LlamaCloud.Models.Retrievers.Type.SystemDefault,
            _ => (global::LlamaCloud.Models.Retrievers.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::LlamaCloud.Models.Retrievers.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::LlamaCloud.Models.Retrievers.Type.Bedrock => "bedrock",
                global::LlamaCloud.Models.Retrievers.Type.Cohere => "cohere",
                global::LlamaCloud.Models.Retrievers.Type.Disabled => "disabled",
                global::LlamaCloud.Models.Retrievers.Type.Llm => "llm",
                global::LlamaCloud.Models.Retrievers.Type.Score => "score",
                global::LlamaCloud.Models.Retrievers.Type.SystemDefault => "system_default",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
