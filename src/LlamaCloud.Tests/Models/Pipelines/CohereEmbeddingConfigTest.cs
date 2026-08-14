using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Pipelines;

namespace LlamaCloud.Tests.Models.Pipelines;

public class CohereEmbeddingConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CohereEmbeddingConfig
        {
            Component = new()
            {
                ApiKey = "api_key",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                EmbeddingType = "embedding_type",
                InputType = "input_type",
                ModelName = "model_name",
                NumWorkers = 0,
                Truncate = "truncate",
            },
            Type = CohereEmbeddingConfigType.CohereEmbedding,
        };

        CohereEmbedding expectedComponent = new()
        {
            ApiKey = "api_key",
            ClassName = "class_name",
            EmbedBatchSize = 1,
            EmbeddingType = "embedding_type",
            InputType = "input_type",
            ModelName = "model_name",
            NumWorkers = 0,
            Truncate = "truncate",
        };
        ApiEnum<string, CohereEmbeddingConfigType> expectedType =
            CohereEmbeddingConfigType.CohereEmbedding;

        Assert.Equal(expectedComponent, model.Component);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CohereEmbeddingConfig
        {
            Component = new()
            {
                ApiKey = "api_key",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                EmbeddingType = "embedding_type",
                InputType = "input_type",
                ModelName = "model_name",
                NumWorkers = 0,
                Truncate = "truncate",
            },
            Type = CohereEmbeddingConfigType.CohereEmbedding,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CohereEmbeddingConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CohereEmbeddingConfig
        {
            Component = new()
            {
                ApiKey = "api_key",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                EmbeddingType = "embedding_type",
                InputType = "input_type",
                ModelName = "model_name",
                NumWorkers = 0,
                Truncate = "truncate",
            },
            Type = CohereEmbeddingConfigType.CohereEmbedding,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CohereEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CohereEmbedding expectedComponent = new()
        {
            ApiKey = "api_key",
            ClassName = "class_name",
            EmbedBatchSize = 1,
            EmbeddingType = "embedding_type",
            InputType = "input_type",
            ModelName = "model_name",
            NumWorkers = 0,
            Truncate = "truncate",
        };
        ApiEnum<string, CohereEmbeddingConfigType> expectedType =
            CohereEmbeddingConfigType.CohereEmbedding;

        Assert.Equal(expectedComponent, deserialized.Component);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CohereEmbeddingConfig
        {
            Component = new()
            {
                ApiKey = "api_key",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                EmbeddingType = "embedding_type",
                InputType = "input_type",
                ModelName = "model_name",
                NumWorkers = 0,
                Truncate = "truncate",
            },
            Type = CohereEmbeddingConfigType.CohereEmbedding,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CohereEmbeddingConfig { };

        Assert.Null(model.Component);
        Assert.False(model.RawData.ContainsKey("component"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CohereEmbeddingConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CohereEmbeddingConfig
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
        var model = new CohereEmbeddingConfig
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
        var model = new CohereEmbeddingConfig
        {
            Component = new()
            {
                ApiKey = "api_key",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                EmbeddingType = "embedding_type",
                InputType = "input_type",
                ModelName = "model_name",
                NumWorkers = 0,
                Truncate = "truncate",
            },
            Type = CohereEmbeddingConfigType.CohereEmbedding,
        };

        CohereEmbeddingConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CohereEmbeddingConfigTypeTest : TestBase
{
    [Theory]
    [InlineData(CohereEmbeddingConfigType.CohereEmbedding)]
    public void Validation_Works(CohereEmbeddingConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CohereEmbeddingConfigType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CohereEmbeddingConfigType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CohereEmbeddingConfigType.CohereEmbedding)]
    public void SerializationRoundtrip_Works(CohereEmbeddingConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CohereEmbeddingConfigType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CohereEmbeddingConfigType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CohereEmbeddingConfigType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CohereEmbeddingConfigType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
