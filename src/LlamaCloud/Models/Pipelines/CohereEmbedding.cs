using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Pipelines;

[JsonConverter(typeof(JsonModelConverter<CohereEmbedding, CohereEmbeddingFromRaw>))]
public sealed record class CohereEmbedding : JsonModel
{
    /// <summary>
    /// The Cohere API key.
    /// </summary>
    public required string? ApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("api_key");
        }
        init { this._rawData.Set("api_key", value); }
    }

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
    /// The batch size for embedding calls.
    /// </summary>
    public long? EmbedBatchSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("embed_batch_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("embed_batch_size", value);
        }
    }

    /// <summary>
    /// Embedding type. If not provided float embedding_type is used when needed.
    /// </summary>
    public string? EmbeddingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("embedding_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("embedding_type", value);
        }
    }

    /// <summary>
    /// Model Input type. If not provided, search_document and search_query are used
    /// when needed.
    /// </summary>
    public string? InputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("input_type");
        }
        init { this._rawData.Set("input_type", value); }
    }

    /// <summary>
    /// The modelId of the Cohere model to use.
    /// </summary>
    public string? ModelName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("model_name", value);
        }
    }

    /// <summary>
    /// The number of workers to use for async embedding calls.
    /// </summary>
    public long? NumWorkers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("num_workers");
        }
        init { this._rawData.Set("num_workers", value); }
    }

    /// <summary>
    /// Truncation type - START/ END/ NONE
    /// </summary>
    public string? Truncate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("truncate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("truncate", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApiKey;
        _ = this.ClassName;
        _ = this.EmbedBatchSize;
        _ = this.EmbeddingType;
        _ = this.InputType;
        _ = this.ModelName;
        _ = this.NumWorkers;
        _ = this.Truncate;
    }

    public CohereEmbedding() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CohereEmbedding(CohereEmbedding cohereEmbedding)
        : base(cohereEmbedding) { }
#pragma warning restore CS8618

    public CohereEmbedding(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CohereEmbedding(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CohereEmbeddingFromRaw.FromRawUnchecked"/>
    public static CohereEmbedding FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CohereEmbedding(string? apiKey)
        : this()
    {
        this.ApiKey = apiKey;
    }
}

class CohereEmbeddingFromRaw : IFromRawJson<CohereEmbedding>
{
    /// <inheritdoc/>
    public CohereEmbedding FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CohereEmbedding.FromRawUnchecked(rawData);
}
