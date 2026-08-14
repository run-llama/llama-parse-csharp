using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models;

/// <summary>
/// Cloud MongoDB Atlas Vector Store.
///
/// <para>This class is used to store the configuration for a MongoDB Atlas vector
/// store, so that it can be created and used in LlamaCloud.</para>
///
/// <para>Args:     mongodb_uri (str): URI for connecting to MongoDB Atlas     db_name
/// (str): name of the MongoDB database     collection_name (str): name of the MongoDB
/// collection     vector_index_name (str): name of the MongoDB Atlas vector index
///     fulltext_index_name (str): name of the MongoDB Atlas full-text index</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CloudMongoDBAtlasVectorSearch, CloudMongoDBAtlasVectorSearchFromRaw>)
)]
public sealed record class CloudMongoDBAtlasVectorSearch : JsonModel
{
    public required string CollectionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("collection_name");
        }
        init { this._rawData.Set("collection_name", value); }
    }

    public required string DBName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("db_name");
        }
        init { this._rawData.Set("db_name", value); }
    }

    public required string MongoDBUri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mongodb_uri");
        }
        init { this._rawData.Set("mongodb_uri", value); }
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

    public long? EmbeddingDimension
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("embedding_dimension");
        }
        init { this._rawData.Set("embedding_dimension", value); }
    }

    public string? FulltextIndexName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fulltext_index_name");
        }
        init { this._rawData.Set("fulltext_index_name", value); }
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

    public string? VectorIndexName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("vector_index_name");
        }
        init { this._rawData.Set("vector_index_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CollectionName;
        _ = this.DBName;
        _ = this.MongoDBUri;
        _ = this.ClassName;
        _ = this.EmbeddingDimension;
        _ = this.FulltextIndexName;
        _ = this.SupportsNestedMetadataFilters;
        _ = this.VectorIndexName;
    }

    public CloudMongoDBAtlasVectorSearch() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudMongoDBAtlasVectorSearch(
        CloudMongoDBAtlasVectorSearch cloudMongoDBAtlasVectorSearch
    )
        : base(cloudMongoDBAtlasVectorSearch) { }
#pragma warning restore CS8618

    public CloudMongoDBAtlasVectorSearch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudMongoDBAtlasVectorSearch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudMongoDBAtlasVectorSearchFromRaw.FromRawUnchecked"/>
    public static CloudMongoDBAtlasVectorSearch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CloudMongoDBAtlasVectorSearchFromRaw : IFromRawJson<CloudMongoDBAtlasVectorSearch>
{
    /// <inheritdoc/>
    public CloudMongoDBAtlasVectorSearch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CloudMongoDBAtlasVectorSearch.FromRawUnchecked(rawData);
}
