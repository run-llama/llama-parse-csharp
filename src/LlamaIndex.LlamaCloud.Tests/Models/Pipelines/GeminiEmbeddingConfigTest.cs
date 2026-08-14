using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Pipelines;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines;

public class GeminiEmbeddingConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GeminiEmbeddingConfig
        {
            Component = new()
            {
                ApiBase = "api_base",
                ApiKey = "api_key",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                ModelName = "model_name",
                NumWorkers = 0,
                OutputDimensionality = 0,
                TaskType = "task_type",
                Title = "title",
                Transport = "transport",
            },
            Type = GeminiEmbeddingConfigType.GeminiEmbedding,
        };

        GeminiEmbedding expectedComponent = new()
        {
            ApiBase = "api_base",
            ApiKey = "api_key",
            ClassName = "class_name",
            EmbedBatchSize = 1,
            ModelName = "model_name",
            NumWorkers = 0,
            OutputDimensionality = 0,
            TaskType = "task_type",
            Title = "title",
            Transport = "transport",
        };
        ApiEnum<string, GeminiEmbeddingConfigType> expectedType =
            GeminiEmbeddingConfigType.GeminiEmbedding;

        Assert.Equal(expectedComponent, model.Component);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GeminiEmbeddingConfig
        {
            Component = new()
            {
                ApiBase = "api_base",
                ApiKey = "api_key",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                ModelName = "model_name",
                NumWorkers = 0,
                OutputDimensionality = 0,
                TaskType = "task_type",
                Title = "title",
                Transport = "transport",
            },
            Type = GeminiEmbeddingConfigType.GeminiEmbedding,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GeminiEmbeddingConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GeminiEmbeddingConfig
        {
            Component = new()
            {
                ApiBase = "api_base",
                ApiKey = "api_key",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                ModelName = "model_name",
                NumWorkers = 0,
                OutputDimensionality = 0,
                TaskType = "task_type",
                Title = "title",
                Transport = "transport",
            },
            Type = GeminiEmbeddingConfigType.GeminiEmbedding,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GeminiEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        GeminiEmbedding expectedComponent = new()
        {
            ApiBase = "api_base",
            ApiKey = "api_key",
            ClassName = "class_name",
            EmbedBatchSize = 1,
            ModelName = "model_name",
            NumWorkers = 0,
            OutputDimensionality = 0,
            TaskType = "task_type",
            Title = "title",
            Transport = "transport",
        };
        ApiEnum<string, GeminiEmbeddingConfigType> expectedType =
            GeminiEmbeddingConfigType.GeminiEmbedding;

        Assert.Equal(expectedComponent, deserialized.Component);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GeminiEmbeddingConfig
        {
            Component = new()
            {
                ApiBase = "api_base",
                ApiKey = "api_key",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                ModelName = "model_name",
                NumWorkers = 0,
                OutputDimensionality = 0,
                TaskType = "task_type",
                Title = "title",
                Transport = "transport",
            },
            Type = GeminiEmbeddingConfigType.GeminiEmbedding,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GeminiEmbeddingConfig { };

        Assert.Null(model.Component);
        Assert.False(model.RawData.ContainsKey("component"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GeminiEmbeddingConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GeminiEmbeddingConfig
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
        var model = new GeminiEmbeddingConfig
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
        var model = new GeminiEmbeddingConfig
        {
            Component = new()
            {
                ApiBase = "api_base",
                ApiKey = "api_key",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                ModelName = "model_name",
                NumWorkers = 0,
                OutputDimensionality = 0,
                TaskType = "task_type",
                Title = "title",
                Transport = "transport",
            },
            Type = GeminiEmbeddingConfigType.GeminiEmbedding,
        };

        GeminiEmbeddingConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GeminiEmbeddingConfigTypeTest : TestBase
{
    [Theory]
    [InlineData(GeminiEmbeddingConfigType.GeminiEmbedding)]
    public void Validation_Works(GeminiEmbeddingConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GeminiEmbeddingConfigType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GeminiEmbeddingConfigType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GeminiEmbeddingConfigType.GeminiEmbedding)]
    public void SerializationRoundtrip_Works(GeminiEmbeddingConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GeminiEmbeddingConfigType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GeminiEmbeddingConfigType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GeminiEmbeddingConfigType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GeminiEmbeddingConfigType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
