using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines;

public class OpenAIEmbeddingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OpenAIEmbedding
        {
            AdditionalKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ApiBase = "api_base",
            ApiKey = "api_key",
            ApiVersion = "api_version",
            ClassName = "class_name",
            DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
            Dimensions = 0,
            EmbedBatchSize = 1,
            MaxRetries = 0,
            ModelName = "model_name",
            NumWorkers = 0,
            ReuseClient = true,
            Timeout = 0,
        };

        Dictionary<string, JsonElement> expectedAdditionalKwargs = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedApiBase = "api_base";
        string expectedApiKey = "api_key";
        string expectedApiVersion = "api_version";
        string expectedClassName = "class_name";
        Dictionary<string, string> expectedDefaultHeaders = new() { { "foo", "string" } };
        long expectedDimensions = 0;
        long expectedEmbedBatchSize = 1;
        long expectedMaxRetries = 0;
        string expectedModelName = "model_name";
        long expectedNumWorkers = 0;
        bool expectedReuseClient = true;
        double expectedTimeout = 0;

        Assert.NotNull(model.AdditionalKwargs);
        Assert.Equal(expectedAdditionalKwargs.Count, model.AdditionalKwargs.Count);
        foreach (var item in expectedAdditionalKwargs)
        {
            Assert.True(model.AdditionalKwargs.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.AdditionalKwargs[item.Key]));
        }
        Assert.Equal(expectedApiBase, model.ApiBase);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedApiVersion, model.ApiVersion);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.NotNull(model.DefaultHeaders);
        Assert.Equal(expectedDefaultHeaders.Count, model.DefaultHeaders.Count);
        foreach (var item in expectedDefaultHeaders)
        {
            Assert.True(model.DefaultHeaders.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.DefaultHeaders[item.Key]);
        }
        Assert.Equal(expectedDimensions, model.Dimensions);
        Assert.Equal(expectedEmbedBatchSize, model.EmbedBatchSize);
        Assert.Equal(expectedMaxRetries, model.MaxRetries);
        Assert.Equal(expectedModelName, model.ModelName);
        Assert.Equal(expectedNumWorkers, model.NumWorkers);
        Assert.Equal(expectedReuseClient, model.ReuseClient);
        Assert.Equal(expectedTimeout, model.Timeout);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OpenAIEmbedding
        {
            AdditionalKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ApiBase = "api_base",
            ApiKey = "api_key",
            ApiVersion = "api_version",
            ClassName = "class_name",
            DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
            Dimensions = 0,
            EmbedBatchSize = 1,
            MaxRetries = 0,
            ModelName = "model_name",
            NumWorkers = 0,
            ReuseClient = true,
            Timeout = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OpenAIEmbedding>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OpenAIEmbedding
        {
            AdditionalKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ApiBase = "api_base",
            ApiKey = "api_key",
            ApiVersion = "api_version",
            ClassName = "class_name",
            DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
            Dimensions = 0,
            EmbedBatchSize = 1,
            MaxRetries = 0,
            ModelName = "model_name",
            NumWorkers = 0,
            ReuseClient = true,
            Timeout = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OpenAIEmbedding>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, JsonElement> expectedAdditionalKwargs = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedApiBase = "api_base";
        string expectedApiKey = "api_key";
        string expectedApiVersion = "api_version";
        string expectedClassName = "class_name";
        Dictionary<string, string> expectedDefaultHeaders = new() { { "foo", "string" } };
        long expectedDimensions = 0;
        long expectedEmbedBatchSize = 1;
        long expectedMaxRetries = 0;
        string expectedModelName = "model_name";
        long expectedNumWorkers = 0;
        bool expectedReuseClient = true;
        double expectedTimeout = 0;

        Assert.NotNull(deserialized.AdditionalKwargs);
        Assert.Equal(expectedAdditionalKwargs.Count, deserialized.AdditionalKwargs.Count);
        foreach (var item in expectedAdditionalKwargs)
        {
            Assert.True(deserialized.AdditionalKwargs.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.AdditionalKwargs[item.Key]));
        }
        Assert.Equal(expectedApiBase, deserialized.ApiBase);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedApiVersion, deserialized.ApiVersion);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.NotNull(deserialized.DefaultHeaders);
        Assert.Equal(expectedDefaultHeaders.Count, deserialized.DefaultHeaders.Count);
        foreach (var item in expectedDefaultHeaders)
        {
            Assert.True(deserialized.DefaultHeaders.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.DefaultHeaders[item.Key]);
        }
        Assert.Equal(expectedDimensions, deserialized.Dimensions);
        Assert.Equal(expectedEmbedBatchSize, deserialized.EmbedBatchSize);
        Assert.Equal(expectedMaxRetries, deserialized.MaxRetries);
        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.Equal(expectedNumWorkers, deserialized.NumWorkers);
        Assert.Equal(expectedReuseClient, deserialized.ReuseClient);
        Assert.Equal(expectedTimeout, deserialized.Timeout);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OpenAIEmbedding
        {
            AdditionalKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ApiBase = "api_base",
            ApiKey = "api_key",
            ApiVersion = "api_version",
            ClassName = "class_name",
            DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
            Dimensions = 0,
            EmbedBatchSize = 1,
            MaxRetries = 0,
            ModelName = "model_name",
            NumWorkers = 0,
            ReuseClient = true,
            Timeout = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OpenAIEmbedding
        {
            ApiBase = "api_base",
            ApiKey = "api_key",
            ApiVersion = "api_version",
            DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
            Dimensions = 0,
            NumWorkers = 0,
        };

        Assert.Null(model.AdditionalKwargs);
        Assert.False(model.RawData.ContainsKey("additional_kwargs"));
        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.EmbedBatchSize);
        Assert.False(model.RawData.ContainsKey("embed_batch_size"));
        Assert.Null(model.MaxRetries);
        Assert.False(model.RawData.ContainsKey("max_retries"));
        Assert.Null(model.ModelName);
        Assert.False(model.RawData.ContainsKey("model_name"));
        Assert.Null(model.ReuseClient);
        Assert.False(model.RawData.ContainsKey("reuse_client"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OpenAIEmbedding
        {
            ApiBase = "api_base",
            ApiKey = "api_key",
            ApiVersion = "api_version",
            DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
            Dimensions = 0,
            NumWorkers = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OpenAIEmbedding
        {
            ApiBase = "api_base",
            ApiKey = "api_key",
            ApiVersion = "api_version",
            DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
            Dimensions = 0,
            NumWorkers = 0,

            // Null should be interpreted as omitted for these properties
            AdditionalKwargs = null,
            ClassName = null,
            EmbedBatchSize = null,
            MaxRetries = null,
            ModelName = null,
            ReuseClient = null,
            Timeout = null,
        };

        Assert.Null(model.AdditionalKwargs);
        Assert.False(model.RawData.ContainsKey("additional_kwargs"));
        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.EmbedBatchSize);
        Assert.False(model.RawData.ContainsKey("embed_batch_size"));
        Assert.Null(model.MaxRetries);
        Assert.False(model.RawData.ContainsKey("max_retries"));
        Assert.Null(model.ModelName);
        Assert.False(model.RawData.ContainsKey("model_name"));
        Assert.Null(model.ReuseClient);
        Assert.False(model.RawData.ContainsKey("reuse_client"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OpenAIEmbedding
        {
            ApiBase = "api_base",
            ApiKey = "api_key",
            ApiVersion = "api_version",
            DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
            Dimensions = 0,
            NumWorkers = 0,

            // Null should be interpreted as omitted for these properties
            AdditionalKwargs = null,
            ClassName = null,
            EmbedBatchSize = null,
            MaxRetries = null,
            ModelName = null,
            ReuseClient = null,
            Timeout = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OpenAIEmbedding
        {
            AdditionalKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ClassName = "class_name",
            EmbedBatchSize = 1,
            MaxRetries = 0,
            ModelName = "model_name",
            ReuseClient = true,
            Timeout = 0,
        };

        Assert.Null(model.ApiBase);
        Assert.False(model.RawData.ContainsKey("api_base"));
        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("api_key"));
        Assert.Null(model.ApiVersion);
        Assert.False(model.RawData.ContainsKey("api_version"));
        Assert.Null(model.DefaultHeaders);
        Assert.False(model.RawData.ContainsKey("default_headers"));
        Assert.Null(model.Dimensions);
        Assert.False(model.RawData.ContainsKey("dimensions"));
        Assert.Null(model.NumWorkers);
        Assert.False(model.RawData.ContainsKey("num_workers"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new OpenAIEmbedding
        {
            AdditionalKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ClassName = "class_name",
            EmbedBatchSize = 1,
            MaxRetries = 0,
            ModelName = "model_name",
            ReuseClient = true,
            Timeout = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new OpenAIEmbedding
        {
            AdditionalKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ClassName = "class_name",
            EmbedBatchSize = 1,
            MaxRetries = 0,
            ModelName = "model_name",
            ReuseClient = true,
            Timeout = 0,

            ApiBase = null,
            ApiKey = null,
            ApiVersion = null,
            DefaultHeaders = null,
            Dimensions = null,
            NumWorkers = null,
        };

        Assert.Null(model.ApiBase);
        Assert.True(model.RawData.ContainsKey("api_base"));
        Assert.Null(model.ApiKey);
        Assert.True(model.RawData.ContainsKey("api_key"));
        Assert.Null(model.ApiVersion);
        Assert.True(model.RawData.ContainsKey("api_version"));
        Assert.Null(model.DefaultHeaders);
        Assert.True(model.RawData.ContainsKey("default_headers"));
        Assert.Null(model.Dimensions);
        Assert.True(model.RawData.ContainsKey("dimensions"));
        Assert.Null(model.NumWorkers);
        Assert.True(model.RawData.ContainsKey("num_workers"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OpenAIEmbedding
        {
            AdditionalKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ClassName = "class_name",
            EmbedBatchSize = 1,
            MaxRetries = 0,
            ModelName = "model_name",
            ReuseClient = true,
            Timeout = 0,

            ApiBase = null,
            ApiKey = null,
            ApiVersion = null,
            DefaultHeaders = null,
            Dimensions = null,
            NumWorkers = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OpenAIEmbedding
        {
            AdditionalKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ApiBase = "api_base",
            ApiKey = "api_key",
            ApiVersion = "api_version",
            ClassName = "class_name",
            DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
            Dimensions = 0,
            EmbedBatchSize = 1,
            MaxRetries = 0,
            ModelName = "model_name",
            NumWorkers = 0,
            ReuseClient = true,
            Timeout = 0,
        };

        OpenAIEmbedding copied = new(model);

        Assert.Equal(model, copied);
    }
}
