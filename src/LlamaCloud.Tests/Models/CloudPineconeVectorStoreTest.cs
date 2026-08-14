using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models;

namespace LlamaCloud.Tests.Models;

public class CloudPineconeVectorStoreTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudPineconeVectorStore
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

        string expectedApiKey = "api_key";
        string expectedIndexName = "index_name";
        string expectedClassName = "class_name";
        Dictionary<string, JsonElement> expectedInsertKwargs = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedNamespace = "namespace";
        ApiEnum<
            bool,
            CloudPineconeVectorStoreSupportsNestedMetadataFilters
        > expectedSupportsNestedMetadataFilters =
            CloudPineconeVectorStoreSupportsNestedMetadataFilters.True;

        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedIndexName, model.IndexName);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.NotNull(model.InsertKwargs);
        Assert.Equal(expectedInsertKwargs.Count, model.InsertKwargs.Count);
        foreach (var item in expectedInsertKwargs)
        {
            Assert.True(model.InsertKwargs.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.InsertKwargs[item.Key]));
        }
        Assert.Equal(expectedNamespace, model.Namespace);
        Assert.Equal(expectedSupportsNestedMetadataFilters, model.SupportsNestedMetadataFilters);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudPineconeVectorStore
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudPineconeVectorStore>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudPineconeVectorStore
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudPineconeVectorStore>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedApiKey = "api_key";
        string expectedIndexName = "index_name";
        string expectedClassName = "class_name";
        Dictionary<string, JsonElement> expectedInsertKwargs = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedNamespace = "namespace";
        ApiEnum<
            bool,
            CloudPineconeVectorStoreSupportsNestedMetadataFilters
        > expectedSupportsNestedMetadataFilters =
            CloudPineconeVectorStoreSupportsNestedMetadataFilters.True;

        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedIndexName, deserialized.IndexName);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.NotNull(deserialized.InsertKwargs);
        Assert.Equal(expectedInsertKwargs.Count, deserialized.InsertKwargs.Count);
        foreach (var item in expectedInsertKwargs)
        {
            Assert.True(deserialized.InsertKwargs.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.InsertKwargs[item.Key]));
        }
        Assert.Equal(expectedNamespace, deserialized.Namespace);
        Assert.Equal(
            expectedSupportsNestedMetadataFilters,
            deserialized.SupportsNestedMetadataFilters
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudPineconeVectorStore
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudPineconeVectorStore
        {
            ApiKey = "api_key",
            IndexName = "index_name",
            InsertKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Namespace = "namespace",
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.SupportsNestedMetadataFilters);
        Assert.False(model.RawData.ContainsKey("supports_nested_metadata_filters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudPineconeVectorStore
        {
            ApiKey = "api_key",
            IndexName = "index_name",
            InsertKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Namespace = "namespace",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudPineconeVectorStore
        {
            ApiKey = "api_key",
            IndexName = "index_name",
            InsertKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Namespace = "namespace",

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
        var model = new CloudPineconeVectorStore
        {
            ApiKey = "api_key",
            IndexName = "index_name",
            InsertKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Namespace = "namespace",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            SupportsNestedMetadataFilters = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudPineconeVectorStore
        {
            ApiKey = "api_key",
            IndexName = "index_name",
            ClassName = "class_name",
            SupportsNestedMetadataFilters =
                CloudPineconeVectorStoreSupportsNestedMetadataFilters.True,
        };

        Assert.Null(model.InsertKwargs);
        Assert.False(model.RawData.ContainsKey("insert_kwargs"));
        Assert.Null(model.Namespace);
        Assert.False(model.RawData.ContainsKey("namespace"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudPineconeVectorStore
        {
            ApiKey = "api_key",
            IndexName = "index_name",
            ClassName = "class_name",
            SupportsNestedMetadataFilters =
                CloudPineconeVectorStoreSupportsNestedMetadataFilters.True,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CloudPineconeVectorStore
        {
            ApiKey = "api_key",
            IndexName = "index_name",
            ClassName = "class_name",
            SupportsNestedMetadataFilters =
                CloudPineconeVectorStoreSupportsNestedMetadataFilters.True,

            InsertKwargs = null,
            Namespace = null,
        };

        Assert.Null(model.InsertKwargs);
        Assert.True(model.RawData.ContainsKey("insert_kwargs"));
        Assert.Null(model.Namespace);
        Assert.True(model.RawData.ContainsKey("namespace"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudPineconeVectorStore
        {
            ApiKey = "api_key",
            IndexName = "index_name",
            ClassName = "class_name",
            SupportsNestedMetadataFilters =
                CloudPineconeVectorStoreSupportsNestedMetadataFilters.True,

            InsertKwargs = null,
            Namespace = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudPineconeVectorStore
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

        CloudPineconeVectorStore copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CloudPineconeVectorStoreSupportsNestedMetadataFiltersTest : TestBase
{
    [Theory]
    [InlineData(CloudPineconeVectorStoreSupportsNestedMetadataFilters.True)]
    public void Validation_Works(CloudPineconeVectorStoreSupportsNestedMetadataFilters rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, CloudPineconeVectorStoreSupportsNestedMetadataFilters> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<bool, CloudPineconeVectorStoreSupportsNestedMetadataFilters>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CloudPineconeVectorStoreSupportsNestedMetadataFilters.True)]
    public void SerializationRoundtrip_Works(
        CloudPineconeVectorStoreSupportsNestedMetadataFilters rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, CloudPineconeVectorStoreSupportsNestedMetadataFilters> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<bool, CloudPineconeVectorStoreSupportsNestedMetadataFilters>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<bool, CloudPineconeVectorStoreSupportsNestedMetadataFilters>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<bool, CloudPineconeVectorStoreSupportsNestedMetadataFilters>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
