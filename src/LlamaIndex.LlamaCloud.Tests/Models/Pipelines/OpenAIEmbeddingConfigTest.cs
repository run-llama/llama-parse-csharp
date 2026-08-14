using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Pipelines;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines;

public class OpenAIEmbeddingConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OpenAIEmbeddingConfig
        {
            Component = new()
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
            },
            Type = OpenAIEmbeddingConfigType.OpenAIEmbedding,
        };

        OpenAIEmbedding expectedComponent = new()
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
        ApiEnum<string, OpenAIEmbeddingConfigType> expectedType =
            OpenAIEmbeddingConfigType.OpenAIEmbedding;

        Assert.Equal(expectedComponent, model.Component);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OpenAIEmbeddingConfig
        {
            Component = new()
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
            },
            Type = OpenAIEmbeddingConfigType.OpenAIEmbedding,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OpenAIEmbeddingConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OpenAIEmbeddingConfig
        {
            Component = new()
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
            },
            Type = OpenAIEmbeddingConfigType.OpenAIEmbedding,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OpenAIEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        OpenAIEmbedding expectedComponent = new()
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
        ApiEnum<string, OpenAIEmbeddingConfigType> expectedType =
            OpenAIEmbeddingConfigType.OpenAIEmbedding;

        Assert.Equal(expectedComponent, deserialized.Component);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OpenAIEmbeddingConfig
        {
            Component = new()
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
            },
            Type = OpenAIEmbeddingConfigType.OpenAIEmbedding,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OpenAIEmbeddingConfig { };

        Assert.Null(model.Component);
        Assert.False(model.RawData.ContainsKey("component"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OpenAIEmbeddingConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OpenAIEmbeddingConfig
        {
            // Null should be interpreted as omitted for these properties
            Component = null,
            Type = null,
        };

        Assert.Null(model.Component);
        Assert.False(model.RawData.ContainsKey("component"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OpenAIEmbeddingConfig
        {
            // Null should be interpreted as omitted for these properties
            Component = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OpenAIEmbeddingConfig
        {
            Component = new()
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
            },
            Type = OpenAIEmbeddingConfigType.OpenAIEmbedding,
        };

        OpenAIEmbeddingConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OpenAIEmbeddingConfigTypeTest : TestBase
{
    [Theory]
    [InlineData(OpenAIEmbeddingConfigType.OpenAIEmbedding)]
    public void Validation_Works(OpenAIEmbeddingConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OpenAIEmbeddingConfigType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OpenAIEmbeddingConfigType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OpenAIEmbeddingConfigType.OpenAIEmbedding)]
    public void SerializationRoundtrip_Works(OpenAIEmbeddingConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OpenAIEmbeddingConfigType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OpenAIEmbeddingConfigType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OpenAIEmbeddingConfigType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OpenAIEmbeddingConfigType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
