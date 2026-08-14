using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;

namespace LlamaCloud.Models;

/// <summary>
/// Cloud Qdrant Vector Store.
///
/// <para>This class is used to store the configuration for a Qdrant vector store,
/// so that it can be created and used in LlamaCloud.</para>
///
/// <para>Args:     collection_name (str): name of the Qdrant collection     url (str):
/// url of the Qdrant instance     api_key (str): API key for authenticating with
/// Qdrant     max_retries (int): maximum number of retries in case of a failure.
/// Defaults to 3     client_kwargs (dict): additional kwargs to pass to the Qdrant client</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CloudQdrantVectorStore, CloudQdrantVectorStoreFromRaw>))]
public sealed record class CloudQdrantVectorStore : JsonModel
{
    public required string ApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("api_key");
        }
        init { this._rawData.Set("api_key", value); }
    }

    public required string CollectionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("collection_name");
        }
        init { this._rawData.Set("collection_name", value); }
    }

    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
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

    public IReadOnlyDictionary<string, JsonElement>? ClientKwargs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "client_kwargs"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "client_kwargs",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

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

    public ApiEnum<
        bool,
        CloudQdrantVectorStoreSupportsNestedMetadataFilters
    >? SupportsNestedMetadataFilters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<bool, CloudQdrantVectorStoreSupportsNestedMetadataFilters>
            >("supports_nested_metadata_filters");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("supports_nested_metadata_filters", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApiKey;
        _ = this.CollectionName;
        _ = this.Url;
        _ = this.ClassName;
        _ = this.ClientKwargs;
        _ = this.MaxRetries;
        this.SupportsNestedMetadataFilters?.Validate();
    }

    public CloudQdrantVectorStore() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudQdrantVectorStore(CloudQdrantVectorStore cloudQdrantVectorStore)
        : base(cloudQdrantVectorStore) { }
#pragma warning restore CS8618

    public CloudQdrantVectorStore(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudQdrantVectorStore(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudQdrantVectorStoreFromRaw.FromRawUnchecked"/>
    public static CloudQdrantVectorStore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CloudQdrantVectorStoreFromRaw : IFromRawJson<CloudQdrantVectorStore>
{
    /// <inheritdoc/>
    public CloudQdrantVectorStore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CloudQdrantVectorStore.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CloudQdrantVectorStoreSupportsNestedMetadataFiltersConverter))]
public enum CloudQdrantVectorStoreSupportsNestedMetadataFilters
{
    True,
}

sealed class CloudQdrantVectorStoreSupportsNestedMetadataFiltersConverter
    : JsonConverter<CloudQdrantVectorStoreSupportsNestedMetadataFilters>
{
    public override CloudQdrantVectorStoreSupportsNestedMetadataFilters Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => CloudQdrantVectorStoreSupportsNestedMetadataFilters.True,
            _ => (CloudQdrantVectorStoreSupportsNestedMetadataFilters)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CloudQdrantVectorStoreSupportsNestedMetadataFilters value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CloudQdrantVectorStoreSupportsNestedMetadataFilters.True => true,
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
