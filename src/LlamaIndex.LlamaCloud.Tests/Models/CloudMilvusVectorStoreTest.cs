using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models;

namespace LlamaIndex.LlamaCloud.Tests.Models;

public class CloudMilvusVectorStoreTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudMilvusVectorStore
        {
            Uri = "uri",
            Token = "token",
            ClassName = "class_name",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            SupportsNestedMetadataFilters = true,
        };

        string expectedUri = "uri";
        string expectedToken = "token";
        string expectedClassName = "class_name";
        string expectedCollectionName = "collection_name";
        long expectedEmbeddingDimension = 0;
        bool expectedSupportsNestedMetadataFilters = true;

        Assert.Equal(expectedUri, model.Uri);
        Assert.Equal(expectedToken, model.Token);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedCollectionName, model.CollectionName);
        Assert.Equal(expectedEmbeddingDimension, model.EmbeddingDimension);
        Assert.Equal(expectedSupportsNestedMetadataFilters, model.SupportsNestedMetadataFilters);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudMilvusVectorStore
        {
            Uri = "uri",
            Token = "token",
            ClassName = "class_name",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            SupportsNestedMetadataFilters = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudMilvusVectorStore>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudMilvusVectorStore
        {
            Uri = "uri",
            Token = "token",
            ClassName = "class_name",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            SupportsNestedMetadataFilters = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudMilvusVectorStore>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUri = "uri";
        string expectedToken = "token";
        string expectedClassName = "class_name";
        string expectedCollectionName = "collection_name";
        long expectedEmbeddingDimension = 0;
        bool expectedSupportsNestedMetadataFilters = true;

        Assert.Equal(expectedUri, deserialized.Uri);
        Assert.Equal(expectedToken, deserialized.Token);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedCollectionName, deserialized.CollectionName);
        Assert.Equal(expectedEmbeddingDimension, deserialized.EmbeddingDimension);
        Assert.Equal(
            expectedSupportsNestedMetadataFilters,
            deserialized.SupportsNestedMetadataFilters
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudMilvusVectorStore
        {
            Uri = "uri",
            Token = "token",
            ClassName = "class_name",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            SupportsNestedMetadataFilters = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudMilvusVectorStore
        {
            Uri = "uri",
            Token = "token",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.SupportsNestedMetadataFilters);
        Assert.False(model.RawData.ContainsKey("supports_nested_metadata_filters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudMilvusVectorStore
        {
            Uri = "uri",
            Token = "token",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudMilvusVectorStore
        {
            Uri = "uri",
            Token = "token",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,

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
        var model = new CloudMilvusVectorStore
        {
            Uri = "uri",
            Token = "token",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            SupportsNestedMetadataFilters = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudMilvusVectorStore
        {
            Uri = "uri",
            ClassName = "class_name",
            SupportsNestedMetadataFilters = true,
        };

        Assert.Null(model.Token);
        Assert.False(model.RawData.ContainsKey("token"));
        Assert.Null(model.CollectionName);
        Assert.False(model.RawData.ContainsKey("collection_name"));
        Assert.Null(model.EmbeddingDimension);
        Assert.False(model.RawData.ContainsKey("embedding_dimension"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudMilvusVectorStore
        {
            Uri = "uri",
            ClassName = "class_name",
            SupportsNestedMetadataFilters = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CloudMilvusVectorStore
        {
            Uri = "uri",
            ClassName = "class_name",
            SupportsNestedMetadataFilters = true,

            Token = null,
            CollectionName = null,
            EmbeddingDimension = null,
        };

        Assert.Null(model.Token);
        Assert.True(model.RawData.ContainsKey("token"));
        Assert.Null(model.CollectionName);
        Assert.True(model.RawData.ContainsKey("collection_name"));
        Assert.Null(model.EmbeddingDimension);
        Assert.True(model.RawData.ContainsKey("embedding_dimension"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudMilvusVectorStore
        {
            Uri = "uri",
            ClassName = "class_name",
            SupportsNestedMetadataFilters = true,

            Token = null,
            CollectionName = null,
            EmbeddingDimension = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudMilvusVectorStore
        {
            Uri = "uri",
            Token = "token",
            ClassName = "class_name",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            SupportsNestedMetadataFilters = true,
        };

        CloudMilvusVectorStore copied = new(model);

        Assert.Equal(model, copied);
    }
}
