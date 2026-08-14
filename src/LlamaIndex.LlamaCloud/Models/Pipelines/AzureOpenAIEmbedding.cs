using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Pipelines;

[JsonConverter(typeof(JsonModelConverter<AzureOpenAIEmbedding, AzureOpenAIEmbeddingFromRaw>))]
public sealed record class AzureOpenAIEmbedding : JsonModel
{
    /// <summary>
    /// Additional kwargs for the OpenAI API.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? AdditionalKwargs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "additional_kwargs"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "additional_kwargs",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The base URL for Azure deployment.
    /// </summary>
    public string? ApiBase
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("api_base");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("api_base", value);
        }
    }

    /// <summary>
    /// The OpenAI API key.
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

    /// <summary>
    /// The version for Azure OpenAI API.
    /// </summary>
    public string? ApiVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("api_version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("api_version", value);
        }
    }

    /// <summary>
    /// The Azure deployment to use.
    /// </summary>
    public string? AzureDeployment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("azure_deployment");
        }
        init { this._rawData.Set("azure_deployment", value); }
    }

    /// <summary>
    /// The Azure endpoint to use.
    /// </summary>
    public string? AzureEndpoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("azure_endpoint");
        }
        init { this._rawData.Set("azure_endpoint", value); }
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
    /// The default headers for API requests.
    /// </summary>
    public IReadOnlyDictionary<string, string>? DefaultHeaders
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "default_headers"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "default_headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The number of dimensions on the output embedding vectors. Works only with
    /// v3 embedding models.
    /// </summary>
    public long? Dimensions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("dimensions");
        }
        init { this._rawData.Set("dimensions", value); }
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
    /// Maximum number of retries.
    /// </summary>
    public long? MaxRetries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_retries");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("max_retries", value);
        }
    }

    /// <summary>
    /// The name of the OpenAI embedding model.
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
    /// Reuse the OpenAI client between requests. When doing anything with large volumes
    /// of async API calls, setting this to false can improve stability.
    /// </summary>
    public bool? ReuseClient
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("reuse_client");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reuse_client", value);
        }
    }

    /// <summary>
    /// Timeout for each request.
    /// </summary>
    public double? Timeout
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("timeout");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timeout", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdditionalKwargs;
        _ = this.ApiBase;
        _ = this.ApiKey;
        _ = this.ApiVersion;
        _ = this.AzureDeployment;
        _ = this.AzureEndpoint;
        _ = this.ClassName;
        _ = this.DefaultHeaders;
        _ = this.Dimensions;
        _ = this.EmbedBatchSize;
        _ = this.MaxRetries;
        _ = this.ModelName;
        _ = this.NumWorkers;
        _ = this.ReuseClient;
        _ = this.Timeout;
    }

    public AzureOpenAIEmbedding() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AzureOpenAIEmbedding(AzureOpenAIEmbedding azureOpenAIEmbedding)
        : base(azureOpenAIEmbedding) { }
#pragma warning restore CS8618

    public AzureOpenAIEmbedding(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AzureOpenAIEmbedding(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AzureOpenAIEmbeddingFromRaw.FromRawUnchecked"/>
    public static AzureOpenAIEmbedding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AzureOpenAIEmbeddingFromRaw : IFromRawJson<AzureOpenAIEmbedding>
{
    /// <inheritdoc/>
    public AzureOpenAIEmbedding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AzureOpenAIEmbedding.FromRawUnchecked(rawData);
}
