using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models;

/// <summary>
/// Cloud Milvus Vector Store.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CloudMilvusVectorStore, CloudMilvusVectorStoreFromRaw>))]
public sealed record class CloudMilvusVectorStore : JsonModel
{
    public required string Uri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("uri");
        }
        init { this._rawData.Set("uri", value); }
    }

    public string? Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("token");
        }
        init { this._rawData.Set("token", value); }
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

    public string? CollectionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("collection_name");
        }
        init { this._rawData.Set("collection_name", value); }
    }

    public long? EmbeddingDimension
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("embedding_dimension");
        }
        init { this._rawData.Set("embedding_dimension", value); }
    }

    public bool? SupportsNestedMetadataFilters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("supports_nested_metadata_filters");
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
        _ = this.Uri;
        _ = this.Token;
        _ = this.ClassName;
        _ = this.CollectionName;
        _ = this.EmbeddingDimension;
        _ = this.SupportsNestedMetadataFilters;
    }

    public CloudMilvusVectorStore() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudMilvusVectorStore(CloudMilvusVectorStore cloudMilvusVectorStore)
        : base(cloudMilvusVectorStore) { }
#pragma warning restore CS8618

    public CloudMilvusVectorStore(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudMilvusVectorStore(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudMilvusVectorStoreFromRaw.FromRawUnchecked"/>
    public static CloudMilvusVectorStore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CloudMilvusVectorStore(string uri)
        : this()
    {
        this.Uri = uri;
    }
}

class CloudMilvusVectorStoreFromRaw : IFromRawJson<CloudMilvusVectorStore>
{
    /// <inheritdoc/>
    public CloudMilvusVectorStore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CloudMilvusVectorStore.FromRawUnchecked(rawData);
}
