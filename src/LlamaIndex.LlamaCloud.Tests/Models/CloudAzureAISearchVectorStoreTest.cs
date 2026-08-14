using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models;

namespace LlamaIndex.LlamaCloud.Tests.Models;

public class CloudAzureAISearchVectorStoreTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudAzureAISearchVectorStore
        {
            SearchServiceApiKey = "search_service_api_key",
            SearchServiceEndpoint = "search_service_endpoint",
            ClassName = "class_name",
            ClientID = "client_id",
            ClientSecret = "client_secret",
            EmbeddingDimension = 0,
            FilterableMetadataFieldKeys = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IndexName = "index_name",
            SearchServiceApiVersion = "search_service_api_version",
            SupportsNestedMetadataFilters =
                CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters.True,
            TenantID = "tenant_id",
        };

        string expectedSearchServiceApiKey = "search_service_api_key";
        string expectedSearchServiceEndpoint = "search_service_endpoint";
        string expectedClassName = "class_name";
        string expectedClientID = "client_id";
        string expectedClientSecret = "client_secret";
        long expectedEmbeddingDimension = 0;
        Dictionary<string, JsonElement> expectedFilterableMetadataFieldKeys = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedIndexName = "index_name";
        string expectedSearchServiceApiVersion = "search_service_api_version";
        ApiEnum<
            bool,
            CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters
        > expectedSupportsNestedMetadataFilters =
            CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters.True;
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedSearchServiceApiKey, model.SearchServiceApiKey);
        Assert.Equal(expectedSearchServiceEndpoint, model.SearchServiceEndpoint);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedClientID, model.ClientID);
        Assert.Equal(expectedClientSecret, model.ClientSecret);
        Assert.Equal(expectedEmbeddingDimension, model.EmbeddingDimension);
        Assert.NotNull(model.FilterableMetadataFieldKeys);
        Assert.Equal(
            expectedFilterableMetadataFieldKeys.Count,
            model.FilterableMetadataFieldKeys.Count
        );
        foreach (var item in expectedFilterableMetadataFieldKeys)
        {
            Assert.True(model.FilterableMetadataFieldKeys.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.FilterableMetadataFieldKeys[item.Key]));
        }
        Assert.Equal(expectedIndexName, model.IndexName);
        Assert.Equal(expectedSearchServiceApiVersion, model.SearchServiceApiVersion);
        Assert.Equal(expectedSupportsNestedMetadataFilters, model.SupportsNestedMetadataFilters);
        Assert.Equal(expectedTenantID, model.TenantID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudAzureAISearchVectorStore
        {
            SearchServiceApiKey = "search_service_api_key",
            SearchServiceEndpoint = "search_service_endpoint",
            ClassName = "class_name",
            ClientID = "client_id",
            ClientSecret = "client_secret",
            EmbeddingDimension = 0,
            FilterableMetadataFieldKeys = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IndexName = "index_name",
            SearchServiceApiVersion = "search_service_api_version",
            SupportsNestedMetadataFilters =
                CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters.True,
            TenantID = "tenant_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudAzureAISearchVectorStore>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudAzureAISearchVectorStore
        {
            SearchServiceApiKey = "search_service_api_key",
            SearchServiceEndpoint = "search_service_endpoint",
            ClassName = "class_name",
            ClientID = "client_id",
            ClientSecret = "client_secret",
            EmbeddingDimension = 0,
            FilterableMetadataFieldKeys = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IndexName = "index_name",
            SearchServiceApiVersion = "search_service_api_version",
            SupportsNestedMetadataFilters =
                CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters.True,
            TenantID = "tenant_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudAzureAISearchVectorStore>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSearchServiceApiKey = "search_service_api_key";
        string expectedSearchServiceEndpoint = "search_service_endpoint";
        string expectedClassName = "class_name";
        string expectedClientID = "client_id";
        string expectedClientSecret = "client_secret";
        long expectedEmbeddingDimension = 0;
        Dictionary<string, JsonElement> expectedFilterableMetadataFieldKeys = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedIndexName = "index_name";
        string expectedSearchServiceApiVersion = "search_service_api_version";
        ApiEnum<
            bool,
            CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters
        > expectedSupportsNestedMetadataFilters =
            CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters.True;
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedSearchServiceApiKey, deserialized.SearchServiceApiKey);
        Assert.Equal(expectedSearchServiceEndpoint, deserialized.SearchServiceEndpoint);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedClientID, deserialized.ClientID);
        Assert.Equal(expectedClientSecret, deserialized.ClientSecret);
        Assert.Equal(expectedEmbeddingDimension, deserialized.EmbeddingDimension);
        Assert.NotNull(deserialized.FilterableMetadataFieldKeys);
        Assert.Equal(
            expectedFilterableMetadataFieldKeys.Count,
            deserialized.FilterableMetadataFieldKeys.Count
        );
        foreach (var item in expectedFilterableMetadataFieldKeys)
        {
            Assert.True(
                deserialized.FilterableMetadataFieldKeys.TryGetValue(item.Key, out var value)
            );

            Assert.True(
                JsonElement.DeepEquals(value, deserialized.FilterableMetadataFieldKeys[item.Key])
            );
        }
        Assert.Equal(expectedIndexName, deserialized.IndexName);
        Assert.Equal(expectedSearchServiceApiVersion, deserialized.SearchServiceApiVersion);
        Assert.Equal(
            expectedSupportsNestedMetadataFilters,
            deserialized.SupportsNestedMetadataFilters
        );
        Assert.Equal(expectedTenantID, deserialized.TenantID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudAzureAISearchVectorStore
        {
            SearchServiceApiKey = "search_service_api_key",
            SearchServiceEndpoint = "search_service_endpoint",
            ClassName = "class_name",
            ClientID = "client_id",
            ClientSecret = "client_secret",
            EmbeddingDimension = 0,
            FilterableMetadataFieldKeys = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IndexName = "index_name",
            SearchServiceApiVersion = "search_service_api_version",
            SupportsNestedMetadataFilters =
                CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters.True,
            TenantID = "tenant_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudAzureAISearchVectorStore
        {
            SearchServiceApiKey = "search_service_api_key",
            SearchServiceEndpoint = "search_service_endpoint",
            ClientID = "client_id",
            ClientSecret = "client_secret",
            EmbeddingDimension = 0,
            FilterableMetadataFieldKeys = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IndexName = "index_name",
            SearchServiceApiVersion = "search_service_api_version",
            TenantID = "tenant_id",
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.SupportsNestedMetadataFilters);
        Assert.False(model.RawData.ContainsKey("supports_nested_metadata_filters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudAzureAISearchVectorStore
        {
            SearchServiceApiKey = "search_service_api_key",
            SearchServiceEndpoint = "search_service_endpoint",
            ClientID = "client_id",
            ClientSecret = "client_secret",
            EmbeddingDimension = 0,
            FilterableMetadataFieldKeys = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IndexName = "index_name",
            SearchServiceApiVersion = "search_service_api_version",
            TenantID = "tenant_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudAzureAISearchVectorStore
        {
            SearchServiceApiKey = "search_service_api_key",
            SearchServiceEndpoint = "search_service_endpoint",
            ClientID = "client_id",
            ClientSecret = "client_secret",
            EmbeddingDimension = 0,
            FilterableMetadataFieldKeys = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IndexName = "index_name",
            SearchServiceApiVersion = "search_service_api_version",
            TenantID = "tenant_id",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            SupportsNestedMetadataFilters = null,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.SupportsNestedMetadataFilters);
        Assert.False(model.RawData.ContainsKey("supports_nested_metadata_filters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudAzureAISearchVectorStore
        {
            SearchServiceApiKey = "search_service_api_key",
            SearchServiceEndpoint = "search_service_endpoint",
            ClientID = "client_id",
            ClientSecret = "client_secret",
            EmbeddingDimension = 0,
            FilterableMetadataFieldKeys = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IndexName = "index_name",
            SearchServiceApiVersion = "search_service_api_version",
            TenantID = "tenant_id",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            SupportsNestedMetadataFilters = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudAzureAISearchVectorStore
        {
            SearchServiceApiKey = "search_service_api_key",
            SearchServiceEndpoint = "search_service_endpoint",
            ClassName = "class_name",
            SupportsNestedMetadataFilters =
                CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters.True,
        };

        Assert.Null(model.ClientID);
        Assert.False(model.RawData.ContainsKey("client_id"));
        Assert.Null(model.ClientSecret);
        Assert.False(model.RawData.ContainsKey("client_secret"));
        Assert.Null(model.EmbeddingDimension);
        Assert.False(model.RawData.ContainsKey("embedding_dimension"));
        Assert.Null(model.FilterableMetadataFieldKeys);
        Assert.False(model.RawData.ContainsKey("filterable_metadata_field_keys"));
        Assert.Null(model.IndexName);
        Assert.False(model.RawData.ContainsKey("index_name"));
        Assert.Null(model.SearchServiceApiVersion);
        Assert.False(model.RawData.ContainsKey("search_service_api_version"));
        Assert.Null(model.TenantID);
        Assert.False(model.RawData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudAzureAISearchVectorStore
        {
            SearchServiceApiKey = "search_service_api_key",
            SearchServiceEndpoint = "search_service_endpoint",
            ClassName = "class_name",
            SupportsNestedMetadataFilters =
                CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters.True,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CloudAzureAISearchVectorStore
        {
            SearchServiceApiKey = "search_service_api_key",
            SearchServiceEndpoint = "search_service_endpoint",
            ClassName = "class_name",
            SupportsNestedMetadataFilters =
                CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters.True,

            ClientID = null,
            ClientSecret = null,
            EmbeddingDimension = null,
            FilterableMetadataFieldKeys = null,
            IndexName = null,
            SearchServiceApiVersion = null,
            TenantID = null,
        };

        Assert.Null(model.ClientID);
        Assert.True(model.RawData.ContainsKey("client_id"));
        Assert.Null(model.ClientSecret);
        Assert.True(model.RawData.ContainsKey("client_secret"));
        Assert.Null(model.EmbeddingDimension);
        Assert.True(model.RawData.ContainsKey("embedding_dimension"));
        Assert.Null(model.FilterableMetadataFieldKeys);
        Assert.True(model.RawData.ContainsKey("filterable_metadata_field_keys"));
        Assert.Null(model.IndexName);
        Assert.True(model.RawData.ContainsKey("index_name"));
        Assert.Null(model.SearchServiceApiVersion);
        Assert.True(model.RawData.ContainsKey("search_service_api_version"));
        Assert.Null(model.TenantID);
        Assert.True(model.RawData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudAzureAISearchVectorStore
        {
            SearchServiceApiKey = "search_service_api_key",
            SearchServiceEndpoint = "search_service_endpoint",
            ClassName = "class_name",
            SupportsNestedMetadataFilters =
                CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters.True,

            ClientID = null,
            ClientSecret = null,
            EmbeddingDimension = null,
            FilterableMetadataFieldKeys = null,
            IndexName = null,
            SearchServiceApiVersion = null,
            TenantID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudAzureAISearchVectorStore
        {
            SearchServiceApiKey = "search_service_api_key",
            SearchServiceEndpoint = "search_service_endpoint",
            ClassName = "class_name",
            ClientID = "client_id",
            ClientSecret = "client_secret",
            EmbeddingDimension = 0,
            FilterableMetadataFieldKeys = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IndexName = "index_name",
            SearchServiceApiVersion = "search_service_api_version",
            SupportsNestedMetadataFilters =
                CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters.True,
            TenantID = "tenant_id",
        };

        CloudAzureAISearchVectorStore copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CloudAzureAISearchVectorStoreSupportsNestedMetadataFiltersTest : TestBase
{
    [Theory]
    [InlineData(CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters.True)]
    public void Validation_Works(
        CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<bool, CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters.True)]
    public void SerializationRoundtrip_Works(
        CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<bool, CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<bool, CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<bool, CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
