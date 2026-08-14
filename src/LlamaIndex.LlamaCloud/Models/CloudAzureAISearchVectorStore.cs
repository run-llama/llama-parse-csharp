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
/// Cloud Azure AI Search Vector Store.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CloudAzureAISearchVectorStore, CloudAzureAISearchVectorStoreFromRaw>)
)]
public sealed record class CloudAzureAISearchVectorStore : JsonModel
{
    public required string SearchServiceApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("search_service_api_key");
        }
        init { this._rawData.Set("search_service_api_key", value); }
    }

    public required string SearchServiceEndpoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("search_service_endpoint");
        }
        init { this._rawData.Set("search_service_endpoint", value); }
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

    public string? ClientID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("client_id");
        }
        init { this._rawData.Set("client_id", value); }
    }

    public string? ClientSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("client_secret");
        }
        init { this._rawData.Set("client_secret", value); }
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

    public IReadOnlyDictionary<string, JsonElement>? FilterableMetadataFieldKeys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "filterable_metadata_field_keys"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "filterable_metadata_field_keys",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? IndexName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("index_name");
        }
        init { this._rawData.Set("index_name", value); }
    }

    public string? SearchServiceApiVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("search_service_api_version");
        }
        init { this._rawData.Set("search_service_api_version", value); }
    }

    public ApiEnum<
        bool,
        CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters
    >? SupportsNestedMetadataFilters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<bool, CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters>
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

    public string? TenantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tenant_id");
        }
        init { this._rawData.Set("tenant_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SearchServiceApiKey;
        _ = this.SearchServiceEndpoint;
        _ = this.ClassName;
        _ = this.ClientID;
        _ = this.ClientSecret;
        _ = this.EmbeddingDimension;
        _ = this.FilterableMetadataFieldKeys;
        _ = this.IndexName;
        _ = this.SearchServiceApiVersion;
        this.SupportsNestedMetadataFilters?.Validate();
        _ = this.TenantID;
    }

    public CloudAzureAISearchVectorStore() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudAzureAISearchVectorStore(
        CloudAzureAISearchVectorStore cloudAzureAISearchVectorStore
    )
        : base(cloudAzureAISearchVectorStore) { }
#pragma warning restore CS8618

    public CloudAzureAISearchVectorStore(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudAzureAISearchVectorStore(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudAzureAISearchVectorStoreFromRaw.FromRawUnchecked"/>
    public static CloudAzureAISearchVectorStore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CloudAzureAISearchVectorStoreFromRaw : IFromRawJson<CloudAzureAISearchVectorStore>
{
    /// <inheritdoc/>
    public CloudAzureAISearchVectorStore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CloudAzureAISearchVectorStore.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CloudAzureAISearchVectorStoreSupportsNestedMetadataFiltersConverter))]
public enum CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters
{
    True,
}

sealed class CloudAzureAISearchVectorStoreSupportsNestedMetadataFiltersConverter
    : JsonConverter<CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters>
{
    public override CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters.True,
            _ => (CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters.True => true,
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
