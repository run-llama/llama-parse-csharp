using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Pipelines;

[JsonConverter(typeof(JsonModelConverter<VertexTextEmbedding, VertexTextEmbeddingFromRaw>))]
public sealed record class VertexTextEmbedding : JsonModel
{
    /// <summary>
    /// The client email for the VertexAI credentials.
    /// </summary>
    public required string? ClientEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("client_email");
        }
        init { this._rawData.Set("client_email", value); }
    }

    /// <summary>
    /// The default location to use when making API calls.
    /// </summary>
    public required string Location
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("location");
        }
        init { this._rawData.Set("location", value); }
    }

    /// <summary>
    /// The private key for the VertexAI credentials.
    /// </summary>
    public required string? PrivateKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("private_key");
        }
        init { this._rawData.Set("private_key", value); }
    }

    /// <summary>
    /// The private key ID for the VertexAI credentials.
    /// </summary>
    public required string? PrivateKeyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("private_key_id");
        }
        init { this._rawData.Set("private_key_id", value); }
    }

    /// <summary>
    /// The default GCP project to use when making Vertex API calls.
    /// </summary>
    public required string Project
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("project");
        }
        init { this._rawData.Set("project", value); }
    }

    /// <summary>
    /// The token URI for the VertexAI credentials.
    /// </summary>
    public required string? TokenUri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("token_uri");
        }
        init { this._rawData.Set("token_uri", value); }
    }

    /// <summary>
    /// Additional kwargs for the Vertex.
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
    /// The embedding mode to use.
    /// </summary>
    public ApiEnum<string, EmbedMode>? EmbedMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EmbedMode>>("embed_mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("embed_mode", value);
        }
    }

    /// <summary>
    /// The modelId of the VertexAI model to use.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClientEmail;
        _ = this.Location;
        _ = this.PrivateKey;
        _ = this.PrivateKeyID;
        _ = this.Project;
        _ = this.TokenUri;
        _ = this.AdditionalKwargs;
        _ = this.ClassName;
        _ = this.EmbedBatchSize;
        this.EmbedMode?.Validate();
        _ = this.ModelName;
        _ = this.NumWorkers;
    }

    public VertexTextEmbedding() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VertexTextEmbedding(VertexTextEmbedding vertexTextEmbedding)
        : base(vertexTextEmbedding) { }
#pragma warning restore CS8618

    public VertexTextEmbedding(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VertexTextEmbedding(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VertexTextEmbeddingFromRaw.FromRawUnchecked"/>
    public static VertexTextEmbedding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VertexTextEmbeddingFromRaw : IFromRawJson<VertexTextEmbedding>
{
    /// <inheritdoc/>
    public VertexTextEmbedding FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VertexTextEmbedding.FromRawUnchecked(rawData);
}

/// <summary>
/// The embedding mode to use.
/// </summary>
[JsonConverter(typeof(EmbedModeConverter))]
public enum EmbedMode
{
    Classification,
    Clustering,
    Default,
    Retrieval,
    Similarity,
}

sealed class EmbedModeConverter : JsonConverter<EmbedMode>
{
    public override EmbedMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "classification" => EmbedMode.Classification,
            "clustering" => EmbedMode.Clustering,
            "default" => EmbedMode.Default,
            "retrieval" => EmbedMode.Retrieval,
            "similarity" => EmbedMode.Similarity,
            _ => (EmbedMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmbedMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EmbedMode.Classification => "classification",
                EmbedMode.Clustering => "clustering",
                EmbedMode.Default => "default",
                EmbedMode.Retrieval => "retrieval",
                EmbedMode.Similarity => "similarity",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
