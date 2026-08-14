using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models;
using LlamaIndex.LlamaCloud.Models.DataSinks;

namespace LlamaIndex.LlamaCloud.Tests.Models.DataSinks;

public class DataSinkTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataSink
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SinkType = DataSinkSinkType.AstraDB,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DataSinkComponent expectedComponent = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string expectedName = "name";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, DataSinkSinkType> expectedSinkType = DataSinkSinkType.AstraDB;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedComponent, model.Component);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedSinkType, model.SinkType);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataSink
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SinkType = DataSinkSinkType.AstraDB,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSink>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataSink
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SinkType = DataSinkSinkType.AstraDB,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSink>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DataSinkComponent expectedComponent = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string expectedName = "name";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, DataSinkSinkType> expectedSinkType = DataSinkSinkType.AstraDB;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedComponent, deserialized.Component);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedSinkType, deserialized.SinkType);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataSink
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SinkType = DataSinkSinkType.AstraDB,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DataSink
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SinkType = DataSinkSinkType.AstraDB,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DataSink
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SinkType = DataSinkSinkType.AstraDB,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DataSink
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SinkType = DataSinkSinkType.AstraDB,

            CreatedAt = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DataSink
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SinkType = DataSinkSinkType.AstraDB,

            CreatedAt = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataSink
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SinkType = DataSinkSinkType.AstraDB,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DataSink copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataSinkComponentTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        DataSinkComponent value = new(
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
        DataSinkComponent value = new CloudPineconeVectorStore()
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
        DataSinkComponent value = new CloudPostgresVectorStore()
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
        DataSinkComponent value = new CloudQdrantVectorStore()
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
        DataSinkComponent value = new CloudAzureAISearchVectorStore()
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
        DataSinkComponent value = new CloudMongoDBAtlasVectorSearch()
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
        DataSinkComponent value = new CloudMilvusVectorStore()
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
        DataSinkComponent value = new CloudAstraDBVectorStore()
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
        DataSinkComponent value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSinkComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudPineconeVectorStoreSerializationRoundtripWorks()
    {
        DataSinkComponent value = new CloudPineconeVectorStore()
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
        var deserialized = JsonSerializer.Deserialize<DataSinkComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudPostgresVectorStoreSerializationRoundtripWorks()
    {
        DataSinkComponent value = new CloudPostgresVectorStore()
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
        var deserialized = JsonSerializer.Deserialize<DataSinkComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudQdrantVectorStoreSerializationRoundtripWorks()
    {
        DataSinkComponent value = new CloudQdrantVectorStore()
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
        var deserialized = JsonSerializer.Deserialize<DataSinkComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudAzureAISearchVectorStoreSerializationRoundtripWorks()
    {
        DataSinkComponent value = new CloudAzureAISearchVectorStore()
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
        var deserialized = JsonSerializer.Deserialize<DataSinkComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudMongoDBAtlasVectorSearchSerializationRoundtripWorks()
    {
        DataSinkComponent value = new CloudMongoDBAtlasVectorSearch()
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
        var deserialized = JsonSerializer.Deserialize<DataSinkComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudMilvusVectorStoreSerializationRoundtripWorks()
    {
        DataSinkComponent value = new CloudMilvusVectorStore()
        {
            Uri = "uri",
            Token = "token",
            ClassName = "class_name",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            SupportsNestedMetadataFilters = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSinkComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudAstraDBVectorStoreSerializationRoundtripWorks()
    {
        DataSinkComponent value = new CloudAstraDBVectorStore()
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
        var deserialized = JsonSerializer.Deserialize<DataSinkComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataSinkSinkTypeTest : TestBase
{
    [Theory]
    [InlineData(DataSinkSinkType.AstraDB)]
    [InlineData(DataSinkSinkType.AzureaiSearch)]
    [InlineData(DataSinkSinkType.Milvus)]
    [InlineData(DataSinkSinkType.MongoDBAtlas)]
    [InlineData(DataSinkSinkType.Pinecone)]
    [InlineData(DataSinkSinkType.Postgres)]
    [InlineData(DataSinkSinkType.Qdrant)]
    public void Validation_Works(DataSinkSinkType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataSinkSinkType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataSinkSinkType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataSinkSinkType.AstraDB)]
    [InlineData(DataSinkSinkType.AzureaiSearch)]
    [InlineData(DataSinkSinkType.Milvus)]
    [InlineData(DataSinkSinkType.MongoDBAtlas)]
    [InlineData(DataSinkSinkType.Pinecone)]
    [InlineData(DataSinkSinkType.Postgres)]
    [InlineData(DataSinkSinkType.Qdrant)]
    public void SerializationRoundtrip_Works(DataSinkSinkType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataSinkSinkType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataSinkSinkType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataSinkSinkType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataSinkSinkType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
