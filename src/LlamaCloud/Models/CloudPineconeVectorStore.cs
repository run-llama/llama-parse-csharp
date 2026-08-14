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
/// Cloud Pinecone Vector Store.
///
/// <para>This class is used to store the configuration for a Pinecone vector store,
/// so that it can be created and used in LlamaCloud.</para>
///
/// <para>Args:     api_key (str): API key for authenticating with Pinecone     index_name
/// (str): name of the Pinecone index     namespace (optional[str]): namespace to
/// use in the Pinecone index     insert_kwargs (optional[dict]): additional kwargs
/// to pass during insertion</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CloudPineconeVectorStore, CloudPineconeVectorStoreFromRaw>)
)]
public sealed record class CloudPineconeVectorStore : JsonModel
{
    /// <summary>
    /// The API key for authenticating with Pinecone
    /// </summary>
    public required string ApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("api_key");
        }
        init { this._rawData.Set("api_key", value); }
    }

    public required string IndexName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("index_name");
        }
        init { this._rawData.Set("index_name", value); }
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

    public IReadOnlyDictionary<string, JsonElement>? InsertKwargs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "insert_kwargs"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "insert_kwargs",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? Namespace
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("namespace");
        }
        init { this._rawData.Set("namespace", value); }
    }

    public ApiEnum<
        bool,
        CloudPineconeVectorStoreSupportsNestedMetadataFilters
    >? SupportsNestedMetadataFilters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<bool, CloudPineconeVectorStoreSupportsNestedMetadataFilters>
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
        _ = this.IndexName;
        _ = this.ClassName;
        _ = this.InsertKwargs;
        _ = this.Namespace;
        this.SupportsNestedMetadataFilters?.Validate();
    }

    public CloudPineconeVectorStore() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudPineconeVectorStore(CloudPineconeVectorStore cloudPineconeVectorStore)
        : base(cloudPineconeVectorStore) { }
#pragma warning restore CS8618

    public CloudPineconeVectorStore(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudPineconeVectorStore(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudPineconeVectorStoreFromRaw.FromRawUnchecked"/>
    public static CloudPineconeVectorStore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CloudPineconeVectorStoreFromRaw : IFromRawJson<CloudPineconeVectorStore>
{
    /// <inheritdoc/>
    public CloudPineconeVectorStore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CloudPineconeVectorStore.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CloudPineconeVectorStoreSupportsNestedMetadataFiltersConverter))]
public enum CloudPineconeVectorStoreSupportsNestedMetadataFilters
{
    True,
}

sealed class CloudPineconeVectorStoreSupportsNestedMetadataFiltersConverter
    : JsonConverter<CloudPineconeVectorStoreSupportsNestedMetadataFilters>
{
    public override CloudPineconeVectorStoreSupportsNestedMetadataFilters Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => CloudPineconeVectorStoreSupportsNestedMetadataFilters.True,
            _ => (CloudPineconeVectorStoreSupportsNestedMetadataFilters)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CloudPineconeVectorStoreSupportsNestedMetadataFilters value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CloudPineconeVectorStoreSupportsNestedMetadataFilters.True => true,
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
