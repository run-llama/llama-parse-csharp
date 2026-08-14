using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models;

[JsonConverter(
    typeof(JsonModelConverter<CloudPostgresVectorStore, CloudPostgresVectorStoreFromRaw>)
)]
public sealed record class CloudPostgresVectorStore : JsonModel
{
    public required string Database
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("database");
        }
        init { this._rawData.Set("database", value); }
    }

    public required long EmbedDim
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("embed_dim");
        }
        init { this._rawData.Set("embed_dim", value); }
    }

    public required string Host
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("host");
        }
        init { this._rawData.Set("host", value); }
    }

    public required string Password
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("password");
        }
        init { this._rawData.Set("password", value); }
    }

    public required long Port
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("port");
        }
        init { this._rawData.Set("port", value); }
    }

    public required string SchemaName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("schema_name");
        }
        init { this._rawData.Set("schema_name", value); }
    }

    public required string TableName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("table_name");
        }
        init { this._rawData.Set("table_name", value); }
    }

    public required string User
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("user");
        }
        init { this._rawData.Set("user", value); }
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
    /// HNSW settings for PGVector.
    /// </summary>
    public PgVectorHnswSettings? HnswSettings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PgVectorHnswSettings>("hnsw_settings");
        }
        init { this._rawData.Set("hnsw_settings", value); }
    }

    public bool? HybridSearch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hybrid_search");
        }
        init { this._rawData.Set("hybrid_search", value); }
    }

    public bool? PerformSetup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("perform_setup");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("perform_setup", value);
        }
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
        _ = this.Database;
        _ = this.EmbedDim;
        _ = this.Host;
        _ = this.Password;
        _ = this.Port;
        _ = this.SchemaName;
        _ = this.TableName;
        _ = this.User;
        _ = this.ClassName;
        this.HnswSettings?.Validate();
        _ = this.HybridSearch;
        _ = this.PerformSetup;
        _ = this.SupportsNestedMetadataFilters;
    }

    public CloudPostgresVectorStore() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudPostgresVectorStore(CloudPostgresVectorStore cloudPostgresVectorStore)
        : base(cloudPostgresVectorStore) { }
#pragma warning restore CS8618

    public CloudPostgresVectorStore(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudPostgresVectorStore(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudPostgresVectorStoreFromRaw.FromRawUnchecked"/>
    public static CloudPostgresVectorStore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CloudPostgresVectorStoreFromRaw : IFromRawJson<CloudPostgresVectorStore>
{
    /// <inheritdoc/>
    public CloudPostgresVectorStore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CloudPostgresVectorStore.FromRawUnchecked(rawData);
}
