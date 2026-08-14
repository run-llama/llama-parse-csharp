using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models;

namespace LlamaIndex.LlamaCloud.Tests.Models;

public class CloudQdrantVectorStoreTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudQdrantVectorStore
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

        string expectedApiKey = "api_key";
        string expectedCollectionName = "collection_name";
        string expectedUrl = "url";
        string expectedClassName = "class_name";
        Dictionary<string, JsonElement> expectedClientKwargs = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        long expectedMaxRetries = 0;
        ApiEnum<
            bool,
            CloudQdrantVectorStoreSupportsNestedMetadataFilters
        > expectedSupportsNestedMetadataFilters =
            CloudQdrantVectorStoreSupportsNestedMetadataFilters.True;

        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedCollectionName, model.CollectionName);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.NotNull(model.ClientKwargs);
        Assert.Equal(expectedClientKwargs.Count, model.ClientKwargs.Count);
        foreach (var item in expectedClientKwargs)
        {
            Assert.True(model.ClientKwargs.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.ClientKwargs[item.Key]));
        }
        Assert.Equal(expectedMaxRetries, model.MaxRetries);
        Assert.Equal(expectedSupportsNestedMetadataFilters, model.SupportsNestedMetadataFilters);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudQdrantVectorStore
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudQdrantVectorStore>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudQdrantVectorStore
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudQdrantVectorStore>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedApiKey = "api_key";
        string expectedCollectionName = "collection_name";
        string expectedUrl = "url";
        string expectedClassName = "class_name";
        Dictionary<string, JsonElement> expectedClientKwargs = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        long expectedMaxRetries = 0;
        ApiEnum<
            bool,
            CloudQdrantVectorStoreSupportsNestedMetadataFilters
        > expectedSupportsNestedMetadataFilters =
            CloudQdrantVectorStoreSupportsNestedMetadataFilters.True;

        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedCollectionName, deserialized.CollectionName);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.NotNull(deserialized.ClientKwargs);
        Assert.Equal(expectedClientKwargs.Count, deserialized.ClientKwargs.Count);
        foreach (var item in expectedClientKwargs)
        {
            Assert.True(deserialized.ClientKwargs.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.ClientKwargs[item.Key]));
        }
        Assert.Equal(expectedMaxRetries, deserialized.MaxRetries);
        Assert.Equal(
            expectedSupportsNestedMetadataFilters,
            deserialized.SupportsNestedMetadataFilters
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudQdrantVectorStore
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudQdrantVectorStore
        {
            ApiKey = "api_key",
            CollectionName = "collection_name",
            Url = "url",
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.ClientKwargs);
        Assert.False(model.RawData.ContainsKey("client_kwargs"));
        Assert.Null(model.MaxRetries);
        Assert.False(model.RawData.ContainsKey("max_retries"));
        Assert.Null(model.SupportsNestedMetadataFilters);
        Assert.False(model.RawData.ContainsKey("supports_nested_metadata_filters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudQdrantVectorStore
        {
            ApiKey = "api_key",
            CollectionName = "collection_name",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudQdrantVectorStore
        {
            ApiKey = "api_key",
            CollectionName = "collection_name",
            Url = "url",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            ClientKwargs = null,
            MaxRetries = null,
            SupportsNestedMetadataFilters = null,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.ClientKwargs);
        Assert.False(model.RawData.ContainsKey("client_kwargs"));
        Assert.Null(model.MaxRetries);
        Assert.False(model.RawData.ContainsKey("max_retries"));
        Assert.Null(model.SupportsNestedMetadataFilters);
        Assert.False(model.RawData.ContainsKey("supports_nested_metadata_filters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudQdrantVectorStore
        {
            ApiKey = "api_key",
            CollectionName = "collection_name",
            Url = "url",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            ClientKwargs = null,
            MaxRetries = null,
            SupportsNestedMetadataFilters = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudQdrantVectorStore
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

        CloudQdrantVectorStore copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CloudQdrantVectorStoreSupportsNestedMetadataFiltersTest : TestBase
{
    [Theory]
    [InlineData(CloudQdrantVectorStoreSupportsNestedMetadataFilters.True)]
    public void Validation_Works(CloudQdrantVectorStoreSupportsNestedMetadataFilters rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, CloudQdrantVectorStoreSupportsNestedMetadataFilters> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<bool, CloudQdrantVectorStoreSupportsNestedMetadataFilters>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CloudQdrantVectorStoreSupportsNestedMetadataFilters.True)]
    public void SerializationRoundtrip_Works(
        CloudQdrantVectorStoreSupportsNestedMetadataFilters rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, CloudQdrantVectorStoreSupportsNestedMetadataFilters> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<bool, CloudQdrantVectorStoreSupportsNestedMetadataFilters>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<bool, CloudQdrantVectorStoreSupportsNestedMetadataFilters>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<bool, CloudQdrantVectorStoreSupportsNestedMetadataFilters>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
