using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models;
using LlamaIndex.LlamaCloud.Models.Pipelines;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines;

public class DataSinkCreateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataSinkCreate
        {
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            SinkType = SinkType.AstraDB,
        };

        Component expectedComponent = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string expectedName = "name";
        ApiEnum<string, SinkType> expectedSinkType = SinkType.AstraDB;

        Assert.Equal(expectedComponent, model.Component);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSinkType, model.SinkType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataSinkCreate
        {
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            SinkType = SinkType.AstraDB,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSinkCreate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataSinkCreate
        {
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            SinkType = SinkType.AstraDB,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSinkCreate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Component expectedComponent = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string expectedName = "name";
        ApiEnum<string, SinkType> expectedSinkType = SinkType.AstraDB;

        Assert.Equal(expectedComponent, deserialized.Component);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSinkType, deserialized.SinkType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataSinkCreate
        {
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            SinkType = SinkType.AstraDB,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataSinkCreate
        {
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            SinkType = SinkType.AstraDB,
        };

        DataSinkCreate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ComponentTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        Component value = new(
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
        Component value = new CloudPineconeVectorStore()
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
        Component value = new CloudPostgresVectorStore()
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
        Component value = new CloudQdrantVectorStore()
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
        Component value = new CloudAzureAISearchVectorStore()
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
        Component value = new CloudMongoDBAtlasVectorSearch()
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
        Component value = new CloudMilvusVectorStore()
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
        Component value = new CloudAstraDBVectorStore()
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
        Component value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudPineconeVectorStoreSerializationRoundtripWorks()
    {
        Component value = new CloudPineconeVectorStore()
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
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudPostgresVectorStoreSerializationRoundtripWorks()
    {
        Component value = new CloudPostgresVectorStore()
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
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudQdrantVectorStoreSerializationRoundtripWorks()
    {
        Component value = new CloudQdrantVectorStore()
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
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudAzureAISearchVectorStoreSerializationRoundtripWorks()
    {
        Component value = new CloudAzureAISearchVectorStore()
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
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudMongoDBAtlasVectorSearchSerializationRoundtripWorks()
    {
        Component value = new CloudMongoDBAtlasVectorSearch()
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
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudMilvusVectorStoreSerializationRoundtripWorks()
    {
        Component value = new CloudMilvusVectorStore()
        {
            Uri = "uri",
            Token = "token",
            ClassName = "class_name",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            SupportsNestedMetadataFilters = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudAstraDBVectorStoreSerializationRoundtripWorks()
    {
        Component value = new CloudAstraDBVectorStore()
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
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SinkTypeTest : TestBase
{
    [Theory]
    [InlineData(SinkType.AstraDB)]
    [InlineData(SinkType.AzureaiSearch)]
    [InlineData(SinkType.Milvus)]
    [InlineData(SinkType.MongoDBAtlas)]
    [InlineData(SinkType.Pinecone)]
    [InlineData(SinkType.Postgres)]
    [InlineData(SinkType.Qdrant)]
    public void Validation_Works(SinkType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SinkType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SinkType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SinkType.AstraDB)]
    [InlineData(SinkType.AzureaiSearch)]
    [InlineData(SinkType.Milvus)]
    [InlineData(SinkType.MongoDBAtlas)]
    [InlineData(SinkType.Pinecone)]
    [InlineData(SinkType.Postgres)]
    [InlineData(SinkType.Qdrant)]
    public void SerializationRoundtrip_Works(SinkType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SinkType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SinkType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SinkType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SinkType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
