using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models;

namespace LlamaIndex.LlamaCloud.Tests.Models;

public class CloudAstraDBVectorStoreTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudAstraDBVectorStore
        {
            Token = "token",
            ApiEndpoint = "api_endpoint",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            ClassName = "class_name",
            Keyspace = "keyspace",
            SupportsNestedMetadataFilters = SupportsNestedMetadataFilters.True,
        };

        string expectedToken = "token";
        string expectedApiEndpoint = "api_endpoint";
        string expectedCollectionName = "collection_name";
        long expectedEmbeddingDimension = 0;
        string expectedClassName = "class_name";
        string expectedKeyspace = "keyspace";
        ApiEnum<bool, SupportsNestedMetadataFilters> expectedSupportsNestedMetadataFilters =
            SupportsNestedMetadataFilters.True;

        Assert.Equal(expectedToken, model.Token);
        Assert.Equal(expectedApiEndpoint, model.ApiEndpoint);
        Assert.Equal(expectedCollectionName, model.CollectionName);
        Assert.Equal(expectedEmbeddingDimension, model.EmbeddingDimension);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedKeyspace, model.Keyspace);
        Assert.Equal(expectedSupportsNestedMetadataFilters, model.SupportsNestedMetadataFilters);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudAstraDBVectorStore
        {
            Token = "token",
            ApiEndpoint = "api_endpoint",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            ClassName = "class_name",
            Keyspace = "keyspace",
            SupportsNestedMetadataFilters = SupportsNestedMetadataFilters.True,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudAstraDBVectorStore>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudAstraDBVectorStore
        {
            Token = "token",
            ApiEndpoint = "api_endpoint",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            ClassName = "class_name",
            Keyspace = "keyspace",
            SupportsNestedMetadataFilters = SupportsNestedMetadataFilters.True,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudAstraDBVectorStore>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToken = "token";
        string expectedApiEndpoint = "api_endpoint";
        string expectedCollectionName = "collection_name";
        long expectedEmbeddingDimension = 0;
        string expectedClassName = "class_name";
        string expectedKeyspace = "keyspace";
        ApiEnum<bool, SupportsNestedMetadataFilters> expectedSupportsNestedMetadataFilters =
            SupportsNestedMetadataFilters.True;

        Assert.Equal(expectedToken, deserialized.Token);
        Assert.Equal(expectedApiEndpoint, deserialized.ApiEndpoint);
        Assert.Equal(expectedCollectionName, deserialized.CollectionName);
        Assert.Equal(expectedEmbeddingDimension, deserialized.EmbeddingDimension);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedKeyspace, deserialized.Keyspace);
        Assert.Equal(
            expectedSupportsNestedMetadataFilters,
            deserialized.SupportsNestedMetadataFilters
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudAstraDBVectorStore
        {
            Token = "token",
            ApiEndpoint = "api_endpoint",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            ClassName = "class_name",
            Keyspace = "keyspace",
            SupportsNestedMetadataFilters = SupportsNestedMetadataFilters.True,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudAstraDBVectorStore
        {
            Token = "token",
            ApiEndpoint = "api_endpoint",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            Keyspace = "keyspace",
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.SupportsNestedMetadataFilters);
        Assert.False(model.RawData.ContainsKey("supports_nested_metadata_filters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudAstraDBVectorStore
        {
            Token = "token",
            ApiEndpoint = "api_endpoint",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            Keyspace = "keyspace",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudAstraDBVectorStore
        {
            Token = "token",
            ApiEndpoint = "api_endpoint",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            Keyspace = "keyspace",

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
        var model = new CloudAstraDBVectorStore
        {
            Token = "token",
            ApiEndpoint = "api_endpoint",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            Keyspace = "keyspace",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            SupportsNestedMetadataFilters = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudAstraDBVectorStore
        {
            Token = "token",
            ApiEndpoint = "api_endpoint",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            ClassName = "class_name",
            SupportsNestedMetadataFilters = SupportsNestedMetadataFilters.True,
        };

        Assert.Null(model.Keyspace);
        Assert.False(model.RawData.ContainsKey("keyspace"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudAstraDBVectorStore
        {
            Token = "token",
            ApiEndpoint = "api_endpoint",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            ClassName = "class_name",
            SupportsNestedMetadataFilters = SupportsNestedMetadataFilters.True,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CloudAstraDBVectorStore
        {
            Token = "token",
            ApiEndpoint = "api_endpoint",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            ClassName = "class_name",
            SupportsNestedMetadataFilters = SupportsNestedMetadataFilters.True,

            Keyspace = null,
        };

        Assert.Null(model.Keyspace);
        Assert.True(model.RawData.ContainsKey("keyspace"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudAstraDBVectorStore
        {
            Token = "token",
            ApiEndpoint = "api_endpoint",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            ClassName = "class_name",
            SupportsNestedMetadataFilters = SupportsNestedMetadataFilters.True,

            Keyspace = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudAstraDBVectorStore
        {
            Token = "token",
            ApiEndpoint = "api_endpoint",
            CollectionName = "collection_name",
            EmbeddingDimension = 0,
            ClassName = "class_name",
            Keyspace = "keyspace",
            SupportsNestedMetadataFilters = SupportsNestedMetadataFilters.True,
        };

        CloudAstraDBVectorStore copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SupportsNestedMetadataFiltersTest : TestBase
{
    [Theory]
    [InlineData(SupportsNestedMetadataFilters.True)]
    public void Validation_Works(SupportsNestedMetadataFilters rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, SupportsNestedMetadataFilters> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, SupportsNestedMetadataFilters>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SupportsNestedMetadataFilters.True)]
    public void SerializationRoundtrip_Works(SupportsNestedMetadataFilters rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, SupportsNestedMetadataFilters> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, SupportsNestedMetadataFilters>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, SupportsNestedMetadataFilters>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, SupportsNestedMetadataFilters>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
