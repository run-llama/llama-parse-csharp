using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Pipelines;

namespace LlamaCloud.Tests.Models.Pipelines;

public class AzureOpenAIEmbeddingConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AzureOpenAIEmbeddingConfig
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
                AzureDeployment = "azure_deployment",
                AzureEndpoint = "azure_endpoint",
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
            Type = Type.AzureEmbedding,
        };

        AzureOpenAIEmbedding expectedComponent = new()
        {
            AdditionalKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ApiBase = "api_base",
            ApiKey = "api_key",
            ApiVersion = "api_version",
            AzureDeployment = "azure_deployment",
            AzureEndpoint = "azure_endpoint",
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
        ApiEnum<string, Type> expectedType = Type.AzureEmbedding;

        Assert.Equal(expectedComponent, model.Component);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AzureOpenAIEmbeddingConfig
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
                AzureDeployment = "azure_deployment",
                AzureEndpoint = "azure_endpoint",
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
            Type = Type.AzureEmbedding,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AzureOpenAIEmbeddingConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AzureOpenAIEmbeddingConfig
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
                AzureDeployment = "azure_deployment",
                AzureEndpoint = "azure_endpoint",
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
            Type = Type.AzureEmbedding,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AzureOpenAIEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AzureOpenAIEmbedding expectedComponent = new()
        {
            AdditionalKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ApiBase = "api_base",
            ApiKey = "api_key",
            ApiVersion = "api_version",
            AzureDeployment = "azure_deployment",
            AzureEndpoint = "azure_endpoint",
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
        ApiEnum<string, Type> expectedType = Type.AzureEmbedding;

        Assert.Equal(expectedComponent, deserialized.Component);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AzureOpenAIEmbeddingConfig
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
                AzureDeployment = "azure_deployment",
                AzureEndpoint = "azure_endpoint",
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
            Type = Type.AzureEmbedding,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AzureOpenAIEmbeddingConfig { };

        Assert.Null(model.Component);
        Assert.False(model.RawData.ContainsKey("component"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AzureOpenAIEmbeddingConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AzureOpenAIEmbeddingConfig
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
        var model = new AzureOpenAIEmbeddingConfig
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
        var model = new AzureOpenAIEmbeddingConfig
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
                AzureDeployment = "azure_deployment",
                AzureEndpoint = "azure_endpoint",
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
            Type = Type.AzureEmbedding,
        };

        AzureOpenAIEmbeddingConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.AzureEmbedding)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.AzureEmbedding)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
