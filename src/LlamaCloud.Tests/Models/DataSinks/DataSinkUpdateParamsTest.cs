using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models;
using LlamaCloud.Models.DataSinks;

namespace LlamaCloud.Tests.Models.DataSinks;

public class DataSinkUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DataSinkUpdateParams
        {
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SinkType = DataSinkUpdateParamsSinkType.AstraDB,
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
        };

        string expectedDataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, DataSinkUpdateParamsSinkType> expectedSinkType =
            DataSinkUpdateParamsSinkType.AstraDB;
        DataSinkUpdateParamsComponent expectedComponent = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string expectedName = "name";

        Assert.Equal(expectedDataSinkID, parameters.DataSinkID);
        Assert.Equal(expectedSinkType, parameters.SinkType);
        Assert.Equal(expectedComponent, parameters.Component);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DataSinkUpdateParams
        {
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SinkType = DataSinkUpdateParamsSinkType.AstraDB,
        };

        Assert.Null(parameters.Component);
        Assert.False(parameters.RawBodyData.ContainsKey("component"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new DataSinkUpdateParams
        {
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SinkType = DataSinkUpdateParamsSinkType.AstraDB,

            Component = null,
            Name = null,
        };

        Assert.Null(parameters.Component);
        Assert.True(parameters.RawBodyData.ContainsKey("component"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        DataSinkUpdateParams parameters = new()
        {
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SinkType = DataSinkUpdateParamsSinkType.AstraDB,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/data-sinks/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DataSinkUpdateParams
        {
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SinkType = DataSinkUpdateParamsSinkType.AstraDB,
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
        };

        DataSinkUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DataSinkUpdateParamsSinkTypeTest : TestBase
{
    [Theory]
    [InlineData(DataSinkUpdateParamsSinkType.AstraDB)]
    [InlineData(DataSinkUpdateParamsSinkType.AzureaiSearch)]
    [InlineData(DataSinkUpdateParamsSinkType.Milvus)]
    [InlineData(DataSinkUpdateParamsSinkType.MongoDBAtlas)]
    [InlineData(DataSinkUpdateParamsSinkType.Pinecone)]
    [InlineData(DataSinkUpdateParamsSinkType.Postgres)]
    [InlineData(DataSinkUpdateParamsSinkType.Qdrant)]
    public void Validation_Works(DataSinkUpdateParamsSinkType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataSinkUpdateParamsSinkType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataSinkUpdateParamsSinkType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataSinkUpdateParamsSinkType.AstraDB)]
    [InlineData(DataSinkUpdateParamsSinkType.AzureaiSearch)]
    [InlineData(DataSinkUpdateParamsSinkType.Milvus)]
    [InlineData(DataSinkUpdateParamsSinkType.MongoDBAtlas)]
    [InlineData(DataSinkUpdateParamsSinkType.Pinecone)]
    [InlineData(DataSinkUpdateParamsSinkType.Postgres)]
    [InlineData(DataSinkUpdateParamsSinkType.Qdrant)]
    public void SerializationRoundtrip_Works(DataSinkUpdateParamsSinkType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataSinkUpdateParamsSinkType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataSinkUpdateParamsSinkType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataSinkUpdateParamsSinkType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataSinkUpdateParamsSinkType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DataSinkUpdateParamsComponentTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        DataSinkUpdateParamsComponent value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        value.Validate();
    }

    [Fact]
    public void CloudPineconeVectorStoreValidationWorks()
    {
        DataSinkUpdateParamsComponent value = new CloudPineconeVectorStore()
        {
            ApiKey = "api_key",
            IndexName = "index_name",
            ClassName = "class_name",
            InsertKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Namespace = "namespace",
            SupportsNestedMetadataFilters =
                CloudPineconeVectorStoreSupportsNestedMetadataFilters.True,
        };
        value.Validate();
    }

    [Fact]
    public void CloudPostgresVectorStoreValidationWorks()
    {
        DataSinkUpdateParamsComponent value = new CloudPostgresVectorStore()
        {
            Database = "database",
            EmbedDim = 0,
            Host = "host",
            Password = "password",
            Port = 0,
            SchemaName = "schema_name",
            TableName = "table_name",
            User = "user",
            ClassName = "class_name",
            HnswSettings = new()
            {
                DistanceMethod = DistanceMethod.Cosine,
                EfConstruction = 1,
                EfSearch = 1,
                M = 1,
                VectorType = VectorType.Bit,
            },
            HybridSearch = true,
            PerformSetup = true,
            SupportsNestedMetadataFilters = true,
        };
        value.Validate();
    }

    [Fact]
    public void CloudQdrantVectorStoreValidationWorks()
    {
        DataSinkUpdateParamsComponent value = new CloudQdrantVectorStore()
        {
            ApiKey = "api_key",
            CollectionName = "collection_name",
            Url = "url",
            ClassName = "class_name",
            ClientKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MaxRetries = 0,
            SupportsNestedMetadataFilters =
                CloudQdrantVectorStoreSupportsNestedMetadataFilters.True,
        };
        value.Validate();
    }

    [Fact]
    public void CloudAzureAISearchVectorStoreValidationWorks()
    {
        DataSinkUpdateParamsComponent value = new CloudAzureAISearchVectorStore()
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
        value.Validate();
    }

    [Fact]
    public void CloudMongoDBAtlasVectorSearchValidationWorks()
    {
        DataSinkUpdateParamsComponent value = new CloudMongoDBAtlasVectorSearch()
        {
            CollectionName = "collection_name",
            DBName = "db_name",
            MongoDBUri = "mongodb_uri",
            ClassName = "class_name",
            EmbeddingDimension = 0,
            FulltextIndexName = "fulltext_index_name",
            SupportsNestedMetadataFilters = true,
            VectorIndexName = "vector_index_name",
        };
        value.Validate();
    }

    [Fact]
    public void CloudMilvusVectorStoreValidationWorks()
    {
        DataSinkUpdateParamsComponent value = new CloudMilvusVectorStore()
        {
            Uri = "uri",
            Token = "token",
            ClassName = "class_name",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            SupportsNestedMetadataFilters = true,
        };
        value.Validate();
    }

    [Fact]
    public void CloudAstraDBVectorStoreValidationWorks()
    {
        DataSinkUpdateParamsComponent value = new CloudAstraDBVectorStore()
        {
            Token = "token",
            ApiEndpoint = "api_endpoint",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            ClassName = "class_name",
            Keyspace = "keyspace",
            SupportsNestedMetadataFilters = SupportsNestedMetadataFilters.True,
        };
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        DataSinkUpdateParamsComponent value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSinkUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudPineconeVectorStoreSerializationRoundtripWorks()
    {
        DataSinkUpdateParamsComponent value = new CloudPineconeVectorStore()
        {
            ApiKey = "api_key",
            IndexName = "index_name",
            ClassName = "class_name",
            InsertKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Namespace = "namespace",
            SupportsNestedMetadataFilters =
                CloudPineconeVectorStoreSupportsNestedMetadataFilters.True,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSinkUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudPostgresVectorStoreSerializationRoundtripWorks()
    {
        DataSinkUpdateParamsComponent value = new CloudPostgresVectorStore()
        {
            Database = "database",
            EmbedDim = 0,
            Host = "host",
            Password = "password",
            Port = 0,
            SchemaName = "schema_name",
            TableName = "table_name",
            User = "user",
            ClassName = "class_name",
            HnswSettings = new()
            {
                DistanceMethod = DistanceMethod.Cosine,
                EfConstruction = 1,
                EfSearch = 1,
                M = 1,
                VectorType = VectorType.Bit,
            },
            HybridSearch = true,
            PerformSetup = true,
            SupportsNestedMetadataFilters = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSinkUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudQdrantVectorStoreSerializationRoundtripWorks()
    {
        DataSinkUpdateParamsComponent value = new CloudQdrantVectorStore()
        {
            ApiKey = "api_key",
            CollectionName = "collection_name",
            Url = "url",
            ClassName = "class_name",
            ClientKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MaxRetries = 0,
            SupportsNestedMetadataFilters =
                CloudQdrantVectorStoreSupportsNestedMetadataFilters.True,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSinkUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudAzureAISearchVectorStoreSerializationRoundtripWorks()
    {
        DataSinkUpdateParamsComponent value = new CloudAzureAISearchVectorStore()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSinkUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudMongoDBAtlasVectorSearchSerializationRoundtripWorks()
    {
        DataSinkUpdateParamsComponent value = new CloudMongoDBAtlasVectorSearch()
        {
            CollectionName = "collection_name",
            DBName = "db_name",
            MongoDBUri = "mongodb_uri",
            ClassName = "class_name",
            EmbeddingDimension = 0,
            FulltextIndexName = "fulltext_index_name",
            SupportsNestedMetadataFilters = true,
            VectorIndexName = "vector_index_name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSinkUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudMilvusVectorStoreSerializationRoundtripWorks()
    {
        DataSinkUpdateParamsComponent value = new CloudMilvusVectorStore()
        {
            Uri = "uri",
            Token = "token",
            ClassName = "class_name",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            SupportsNestedMetadataFilters = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSinkUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudAstraDBVectorStoreSerializationRoundtripWorks()
    {
        DataSinkUpdateParamsComponent value = new CloudAstraDBVectorStore()
        {
            Token = "token",
            ApiEndpoint = "api_endpoint",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            ClassName = "class_name",
            Keyspace = "keyspace",
            SupportsNestedMetadataFilters = SupportsNestedMetadataFilters.True,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSinkUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
