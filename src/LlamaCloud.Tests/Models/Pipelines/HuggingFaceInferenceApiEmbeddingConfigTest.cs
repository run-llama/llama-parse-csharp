using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Pipelines;

namespace LlamaCloud.Tests.Models.Pipelines;

public class HuggingFaceInferenceApiEmbeddingConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new HuggingFaceInferenceApiEmbeddingConfig
        {
            Component = new()
            {
                Token = "string",
                ClassName = "class_name",
                Cookies = new Dictionary<string, string>() { { "foo", "string" } },
                EmbedBatchSize = 1,
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ModelName = "model_name",
                NumWorkers = 0,
                Pooling = Pooling.Cls,
                QueryInstruction = "query_instruction",
                Task = "task",
                TextInstruction = "text_instruction",
                Timeout = 0,
            },
            Type = HuggingFaceInferenceApiEmbeddingConfigType.HuggingfaceApiEmbedding,
        };

        HuggingFaceInferenceApiEmbedding expectedComponent = new()
        {
            Token = "string",
            ClassName = "class_name",
            Cookies = new Dictionary<string, string>() { { "foo", "string" } },
            EmbedBatchSize = 1,
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ModelName = "model_name",
            NumWorkers = 0,
            Pooling = Pooling.Cls,
            QueryInstruction = "query_instruction",
            Task = "task",
            TextInstruction = "text_instruction",
            Timeout = 0,
        };
        ApiEnum<string, HuggingFaceInferenceApiEmbeddingConfigType> expectedType =
            HuggingFaceInferenceApiEmbeddingConfigType.HuggingfaceApiEmbedding;

        Assert.Equal(expectedComponent, model.Component);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new HuggingFaceInferenceApiEmbeddingConfig
        {
            Component = new()
            {
                Token = "string",
                ClassName = "class_name",
                Cookies = new Dictionary<string, string>() { { "foo", "string" } },
                EmbedBatchSize = 1,
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ModelName = "model_name",
                NumWorkers = 0,
                Pooling = Pooling.Cls,
                QueryInstruction = "query_instruction",
                Task = "task",
                TextInstruction = "text_instruction",
                Timeout = 0,
            },
            Type = HuggingFaceInferenceApiEmbeddingConfigType.HuggingfaceApiEmbedding,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<HuggingFaceInferenceApiEmbeddingConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new HuggingFaceInferenceApiEmbeddingConfig
        {
            Component = new()
            {
                Token = "string",
                ClassName = "class_name",
                Cookies = new Dictionary<string, string>() { { "foo", "string" } },
                EmbedBatchSize = 1,
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ModelName = "model_name",
                NumWorkers = 0,
                Pooling = Pooling.Cls,
                QueryInstruction = "query_instruction",
                Task = "task",
                TextInstruction = "text_instruction",
                Timeout = 0,
            },
            Type = HuggingFaceInferenceApiEmbeddingConfigType.HuggingfaceApiEmbedding,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<HuggingFaceInferenceApiEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        HuggingFaceInferenceApiEmbedding expectedComponent = new()
        {
            Token = "string",
            ClassName = "class_name",
            Cookies = new Dictionary<string, string>() { { "foo", "string" } },
            EmbedBatchSize = 1,
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ModelName = "model_name",
            NumWorkers = 0,
            Pooling = Pooling.Cls,
            QueryInstruction = "query_instruction",
            Task = "task",
            TextInstruction = "text_instruction",
            Timeout = 0,
        };
        ApiEnum<string, HuggingFaceInferenceApiEmbeddingConfigType> expectedType =
            HuggingFaceInferenceApiEmbeddingConfigType.HuggingfaceApiEmbedding;

        Assert.Equal(expectedComponent, deserialized.Component);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new HuggingFaceInferenceApiEmbeddingConfig
        {
            Component = new()
            {
                Token = "string",
                ClassName = "class_name",
                Cookies = new Dictionary<string, string>() { { "foo", "string" } },
                EmbedBatchSize = 1,
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ModelName = "model_name",
                NumWorkers = 0,
                Pooling = Pooling.Cls,
                QueryInstruction = "query_instruction",
                Task = "task",
                TextInstruction = "text_instruction",
                Timeout = 0,
            },
            Type = HuggingFaceInferenceApiEmbeddingConfigType.HuggingfaceApiEmbedding,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new HuggingFaceInferenceApiEmbeddingConfig { };

        Assert.Null(model.Component);
        Assert.False(model.RawData.ContainsKey("component"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new HuggingFaceInferenceApiEmbeddingConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new HuggingFaceInferenceApiEmbeddingConfig
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
        var model = new HuggingFaceInferenceApiEmbeddingConfig
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
        var model = new HuggingFaceInferenceApiEmbeddingConfig
        {
            Component = new()
            {
                Token = "string",
                ClassName = "class_name",
                Cookies = new Dictionary<string, string>() { { "foo", "string" } },
                EmbedBatchSize = 1,
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ModelName = "model_name",
                NumWorkers = 0,
                Pooling = Pooling.Cls,
                QueryInstruction = "query_instruction",
                Task = "task",
                TextInstruction = "text_instruction",
                Timeout = 0,
            },
            Type = HuggingFaceInferenceApiEmbeddingConfigType.HuggingfaceApiEmbedding,
        };

        HuggingFaceInferenceApiEmbeddingConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class HuggingFaceInferenceApiEmbeddingConfigTypeTest : TestBase
{
    [Theory]
    [InlineData(HuggingFaceInferenceApiEmbeddingConfigType.HuggingfaceApiEmbedding)]
    public void Validation_Works(HuggingFaceInferenceApiEmbeddingConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, HuggingFaceInferenceApiEmbeddingConfigType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, HuggingFaceInferenceApiEmbeddingConfigType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(HuggingFaceInferenceApiEmbeddingConfigType.HuggingfaceApiEmbedding)]
    public void SerializationRoundtrip_Works(HuggingFaceInferenceApiEmbeddingConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, HuggingFaceInferenceApiEmbeddingConfigType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, HuggingFaceInferenceApiEmbeddingConfigType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, HuggingFaceInferenceApiEmbeddingConfigType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, HuggingFaceInferenceApiEmbeddingConfigType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
