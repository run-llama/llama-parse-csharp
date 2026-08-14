using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;

namespace LlamaIndex.LlamaCloud.Models;

/// <summary>
/// Cloud AstraDB Vector Store.
///
/// <para>This class is used to store the configuration for an AstraDB vector store,
/// so that it can be created and used in LlamaCloud.</para>
///
/// <para>Args:     token (str): The Astra DB Application Token to use.     api_endpoint
/// (str): The Astra DB JSON API endpoint for your database.     collection_name
/// (str): Collection name to use. If not existing, it will be created.     embedding_dimension
/// (int): Length of the embedding vectors in use.     keyspace (optional[str]): The
/// keyspace to use. If not provided, 'default_keyspace'</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CloudAstraDBVectorStore, CloudAstraDBVectorStoreFromRaw>))]
public sealed record class CloudAstraDBVectorStore : JsonModel
{
    /// <summary>
    /// The Astra DB Application Token to use
    /// </summary>
    public required string Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("token");
        }
        init { this._rawData.Set("token", value); }
    }

    /// <summary>
    /// The Astra DB JSON API endpoint for your database
    /// </summary>
    public required string ApiEndpoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("api_endpoint");
        }
        init { this._rawData.Set("api_endpoint", value); }
    }

    /// <summary>
    /// Collection name to use. If not existing, it will be created
    /// </summary>
    public required string CollectionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("collection_name");
        }
        init { this._rawData.Set("collection_name", value); }
    }

    /// <summary>
    /// Length of the embedding vectors in use
    /// </summary>
    public required long EmbeddingDimension
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("embedding_dimension");
        }
        init { this._rawData.Set("embedding_dimension", value); }
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
    /// The keyspace to use. If not provided, 'default_keyspace'
    /// </summary>
    public string? Keyspace
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("keyspace");
        }
        init { this._rawData.Set("keyspace", value); }
    }

    public ApiEnum<bool, SupportsNestedMetadataFilters>? SupportsNestedMetadataFilters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<bool, SupportsNestedMetadataFilters>>(
                "supports_nested_metadata_filters"
            );
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
        _ = this.Token;
        _ = this.ApiEndpoint;
        _ = this.CollectionName;
        _ = this.EmbeddingDimension;
        _ = this.ClassName;
        _ = this.Keyspace;
        this.SupportsNestedMetadataFilters?.Validate();
    }

    public CloudAstraDBVectorStore() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudAstraDBVectorStore(CloudAstraDBVectorStore cloudAstraDBVectorStore)
        : base(cloudAstraDBVectorStore) { }
#pragma warning restore CS8618

    public CloudAstraDBVectorStore(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudAstraDBVectorStore(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudAstraDBVectorStoreFromRaw.FromRawUnchecked"/>
    public static CloudAstraDBVectorStore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CloudAstraDBVectorStoreFromRaw : IFromRawJson<CloudAstraDBVectorStore>
{
    /// <inheritdoc/>
    public CloudAstraDBVectorStore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CloudAstraDBVectorStore.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SupportsNestedMetadataFiltersConverter))]
public enum SupportsNestedMetadataFilters
{
    True,
}

sealed class SupportsNestedMetadataFiltersConverter : JsonConverter<SupportsNestedMetadataFilters>
{
    public override SupportsNestedMetadataFilters Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => SupportsNestedMetadataFilters.True,
            _ => (SupportsNestedMetadataFilters)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SupportsNestedMetadataFilters value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SupportsNestedMetadataFilters.True => true,
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
