using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Pipelines;

[JsonConverter(typeof(JsonModelConverter<GeminiEmbedding, GeminiEmbeddingFromRaw>))]
public sealed record class GeminiEmbedding : JsonModel
{
    /// <summary>
    /// API base to access the model. Defaults to None.
    /// </summary>
    public string? ApiBase
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("api_base");
        }
        init { this._rawData.Set("api_base", value); }
    }

    /// <summary>
    /// API key to access the model. Defaults to None.
    /// </summary>
    public string? ApiKey
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
    /// The modelId of the Gemini model to use.
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
    /// Optional reduced dimension for output embeddings. Supported by models/text-embedding-004
    /// and newer (e.g. gemini-embedding-001). Not supported by models/embedding-001.
    /// </summary>
    public long? OutputDimensionality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("output_dimensionality");
        }
        init { this._rawData.Set("output_dimensionality", value); }
    }

    /// <summary>
    /// The task for embedding model.
    /// </summary>
    public string? TaskType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("task_type");
        }
        init { this._rawData.Set("task_type", value); }
    }

    /// <summary>
    /// Title is only applicable for retrieval_document tasks, and is used to represent
    /// a document title. For other tasks, title is invalid.
    /// </summary>
    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    /// <summary>
    /// Transport to access the model. Defaults to None.
    /// </summary>
    public string? Transport
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transport");
        }
        init { this._rawData.Set("transport", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApiBase;
        _ = this.ApiKey;
        _ = this.ClassName;
        _ = this.EmbedBatchSize;
        _ = this.ModelName;
        _ = this.NumWorkers;
        _ = this.OutputDimensionality;
        _ = this.TaskType;
        _ = this.Title;
        _ = this.Transport;
    }

    public GeminiEmbedding() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GeminiEmbedding(GeminiEmbedding geminiEmbedding)
        : base(geminiEmbedding) { }
#pragma warning restore CS8618

    public GeminiEmbedding(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GeminiEmbedding(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GeminiEmbeddingFromRaw.FromRawUnchecked"/>
    public static GeminiEmbedding FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GeminiEmbeddingFromRaw : IFromRawJson<GeminiEmbedding>
{
    /// <inheritdoc/>
    public GeminiEmbedding FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GeminiEmbedding.FromRawUnchecked(rawData);
}
