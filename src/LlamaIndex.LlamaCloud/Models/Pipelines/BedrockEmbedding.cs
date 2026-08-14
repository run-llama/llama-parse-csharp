using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Pipelines;

[JsonConverter(typeof(JsonModelConverter<BedrockEmbedding, BedrockEmbeddingFromRaw>))]
public sealed record class BedrockEmbedding : JsonModel
{
    /// <summary>
    /// Additional kwargs for the bedrock client.
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
    /// AWS Access Key ID to use
    /// </summary>
    public string? AwsAccessKeyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("aws_access_key_id");
        }
        init { this._rawData.Set("aws_access_key_id", value); }
    }

    /// <summary>
    /// AWS Secret Access Key to use
    /// </summary>
    public string? AwsSecretAccessKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("aws_secret_access_key");
        }
        init { this._rawData.Set("aws_secret_access_key", value); }
    }

    /// <summary>
    /// AWS Session Token to use
    /// </summary>
    public string? AwsSessionToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("aws_session_token");
        }
        init { this._rawData.Set("aws_session_token", value); }
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
    /// The maximum number of API retries.
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
    /// The modelId of the Bedrock model to use.
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
    /// The name of aws profile to use. If not given, then the default profile is used.
    /// </summary>
    public string? ProfileName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profile_name");
        }
        init { this._rawData.Set("profile_name", value); }
    }

    /// <summary>
    /// AWS region name to use. Uses region configured in AWS CLI if not passed
    /// </summary>
    public string? RegionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("region_name");
        }
        init { this._rawData.Set("region_name", value); }
    }

    /// <summary>
    /// The timeout for the Bedrock API request in seconds. It will be used for both
    /// connect and read timeouts.
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
        _ = this.AwsAccessKeyID;
        _ = this.AwsSecretAccessKey;
        _ = this.AwsSessionToken;
        _ = this.ClassName;
        _ = this.EmbedBatchSize;
        _ = this.MaxRetries;
        _ = this.ModelName;
        _ = this.NumWorkers;
        _ = this.ProfileName;
        _ = this.RegionName;
        _ = this.Timeout;
    }

    public BedrockEmbedding() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BedrockEmbedding(BedrockEmbedding bedrockEmbedding)
        : base(bedrockEmbedding) { }
#pragma warning restore CS8618

    public BedrockEmbedding(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BedrockEmbedding(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BedrockEmbeddingFromRaw.FromRawUnchecked"/>
    public static BedrockEmbedding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BedrockEmbeddingFromRaw : IFromRawJson<BedrockEmbedding>
{
    /// <inheritdoc/>
    public BedrockEmbedding FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BedrockEmbedding.FromRawUnchecked(rawData);
}
