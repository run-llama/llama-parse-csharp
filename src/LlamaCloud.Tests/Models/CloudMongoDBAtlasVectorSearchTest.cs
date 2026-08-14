using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models;

namespace LlamaCloud.Tests.Models;

public class CloudMongoDBAtlasVectorSearchTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudMongoDBAtlasVectorSearch
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

        string expectedCollectionName = "collection_name";
        string expectedDBName = "db_name";
        string expectedMongoDBUri = "mongodb_uri";
        string expectedClassName = "class_name";
        long expectedEmbeddingDimension = 0;
        string expectedFulltextIndexName = "fulltext_index_name";
        bool expectedSupportsNestedMetadataFilters = true;
        string expectedVectorIndexName = "vector_index_name";

        Assert.Equal(expectedCollectionName, model.CollectionName);
        Assert.Equal(expectedDBName, model.DBName);
        Assert.Equal(expectedMongoDBUri, model.MongoDBUri);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedEmbeddingDimension, model.EmbeddingDimension);
        Assert.Equal(expectedFulltextIndexName, model.FulltextIndexName);
        Assert.Equal(expectedSupportsNestedMetadataFilters, model.SupportsNestedMetadataFilters);
        Assert.Equal(expectedVectorIndexName, model.VectorIndexName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudMongoDBAtlasVectorSearch
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudMongoDBAtlasVectorSearch>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudMongoDBAtlasVectorSearch
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudMongoDBAtlasVectorSearch>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCollectionName = "collection_name";
        string expectedDBName = "db_name";
        string expectedMongoDBUri = "mongodb_uri";
        string expectedClassName = "class_name";
        long expectedEmbeddingDimension = 0;
        string expectedFulltextIndexName = "fulltext_index_name";
        bool expectedSupportsNestedMetadataFilters = true;
        string expectedVectorIndexName = "vector_index_name";

        Assert.Equal(expectedCollectionName, deserialized.CollectionName);
        Assert.Equal(expectedDBName, deserialized.DBName);
        Assert.Equal(expectedMongoDBUri, deserialized.MongoDBUri);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedEmbeddingDimension, deserialized.EmbeddingDimension);
        Assert.Equal(expectedFulltextIndexName, deserialized.FulltextIndexName);
        Assert.Equal(
            expectedSupportsNestedMetadataFilters,
            deserialized.SupportsNestedMetadataFilters
        );
        Assert.Equal(expectedVectorIndexName, deserialized.VectorIndexName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudMongoDBAtlasVectorSearch
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudMongoDBAtlasVectorSearch
        {
            CollectionName = "collection_name",
            DBName = "db_name",
            MongoDBUri = "mongodb_uri",
            EmbeddingDimension = 0,
            FulltextIndexName = "fulltext_index_name",
            VectorIndexName = "vector_index_name",
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.SupportsNestedMetadataFilters);
        Assert.False(model.RawData.ContainsKey("supports_nested_metadata_filters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudMongoDBAtlasVectorSearch
        {
            CollectionName = "collection_name",
            DBName = "db_name",
            MongoDBUri = "mongodb_uri",
            EmbeddingDimension = 0,
            FulltextIndexName = "fulltext_index_name",
            VectorIndexName = "vector_index_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudMongoDBAtlasVectorSearch
        {
            CollectionName = "collection_name",
            DBName = "db_name",
            MongoDBUri = "mongodb_uri",
            EmbeddingDimension = 0,
            FulltextIndexName = "fulltext_index_name",
            VectorIndexName = "vector_index_name",

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
        var model = new CloudMongoDBAtlasVectorSearch
        {
            CollectionName = "collection_name",
            DBName = "db_name",
            MongoDBUri = "mongodb_uri",
            EmbeddingDimension = 0,
            FulltextIndexName = "fulltext_index_name",
            VectorIndexName = "vector_index_name",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            SupportsNestedMetadataFilters = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudMongoDBAtlasVectorSearch
        {
            CollectionName = "collection_name",
            DBName = "db_name",
            MongoDBUri = "mongodb_uri",
            ClassName = "class_name",
            SupportsNestedMetadataFilters = true,
        };

        Assert.Null(model.EmbeddingDimension);
        Assert.False(model.RawData.ContainsKey("embedding_dimension"));
        Assert.Null(model.FulltextIndexName);
        Assert.False(model.RawData.ContainsKey("fulltext_index_name"));
        Assert.Null(model.VectorIndexName);
        Assert.False(model.RawData.ContainsKey("vector_index_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudMongoDBAtlasVectorSearch
        {
            CollectionName = "collection_name",
            DBName = "db_name",
            MongoDBUri = "mongodb_uri",
            ClassName = "class_name",
            SupportsNestedMetadataFilters = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CloudMongoDBAtlasVectorSearch
        {
            CollectionName = "collection_name",
            DBName = "db_name",
            MongoDBUri = "mongodb_uri",
            ClassName = "class_name",
            SupportsNestedMetadataFilters = true,

            EmbeddingDimension = null,
            FulltextIndexName = null,
            VectorIndexName = null,
        };

        Assert.Null(model.EmbeddingDimension);
        Assert.True(model.RawData.ContainsKey("embedding_dimension"));
        Assert.Null(model.FulltextIndexName);
        Assert.True(model.RawData.ContainsKey("fulltext_index_name"));
        Assert.Null(model.VectorIndexName);
        Assert.True(model.RawData.ContainsKey("vector_index_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudMongoDBAtlasVectorSearch
        {
            CollectionName = "collection_name",
            DBName = "db_name",
            MongoDBUri = "mongodb_uri",
            ClassName = "class_name",
            SupportsNestedMetadataFilters = true,

            EmbeddingDimension = null,
            FulltextIndexName = null,
            VectorIndexName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudMongoDBAtlasVectorSearch
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

        CloudMongoDBAtlasVectorSearch copied = new(model);

        Assert.Equal(model, copied);
    }
}
