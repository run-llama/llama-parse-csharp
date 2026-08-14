using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Pipelines;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines;

public class VertexAIEmbeddingConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VertexAIEmbeddingConfig
        {
            Component = new()
            {
                ClientEmail = "client_email",
                Location = "location",
                PrivateKey = "private_key",
                PrivateKeyID = "private_key_id",
                Project = "project",
                TokenUri = "token_uri",
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ClassName = "class_name",
                EmbedBatchSize = 1,
                EmbedMode = EmbedMode.Classification,
                ModelName = "model_name",
                NumWorkers = 0,
            },
            Type = VertexAIEmbeddingConfigType.VertexaiEmbedding,
        };

        VertexTextEmbedding expectedComponent = new()
        {
            ClientEmail = "client_email",
            Location = "location",
            PrivateKey = "private_key",
            PrivateKeyID = "private_key_id",
            Project = "project",
            TokenUri = "token_uri",
            AdditionalKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ClassName = "class_name",
            EmbedBatchSize = 1,
            EmbedMode = EmbedMode.Classification,
            ModelName = "model_name",
            NumWorkers = 0,
        };
        ApiEnum<string, VertexAIEmbeddingConfigType> expectedType =
            VertexAIEmbeddingConfigType.VertexaiEmbedding;

        Assert.Equal(expectedComponent, model.Component);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VertexAIEmbeddingConfig
        {
            Component = new()
            {
                ClientEmail = "client_email",
                Location = "location",
                PrivateKey = "private_key",
                PrivateKeyID = "private_key_id",
                Project = "project",
                TokenUri = "token_uri",
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ClassName = "class_name",
                EmbedBatchSize = 1,
                EmbedMode = EmbedMode.Classification,
                ModelName = "model_name",
                NumWorkers = 0,
            },
            Type = VertexAIEmbeddingConfigType.VertexaiEmbedding,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VertexAIEmbeddingConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VertexAIEmbeddingConfig
        {
            Component = new()
            {
                ClientEmail = "client_email",
                Location = "location",
                PrivateKey = "private_key",
                PrivateKeyID = "private_key_id",
                Project = "project",
                TokenUri = "token_uri",
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ClassName = "class_name",
                EmbedBatchSize = 1,
                EmbedMode = EmbedMode.Classification,
                ModelName = "model_name",
                NumWorkers = 0,
            },
            Type = VertexAIEmbeddingConfigType.VertexaiEmbedding,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VertexAIEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        VertexTextEmbedding expectedComponent = new()
        {
            ClientEmail = "client_email",
            Location = "location",
            PrivateKey = "private_key",
            PrivateKeyID = "private_key_id",
            Project = "project",
            TokenUri = "token_uri",
            AdditionalKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ClassName = "class_name",
            EmbedBatchSize = 1,
            EmbedMode = EmbedMode.Classification,
            ModelName = "model_name",
            NumWorkers = 0,
        };
        ApiEnum<string, VertexAIEmbeddingConfigType> expectedType =
            VertexAIEmbeddingConfigType.VertexaiEmbedding;

        Assert.Equal(expectedComponent, deserialized.Component);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VertexAIEmbeddingConfig
        {
            Component = new()
            {
                ClientEmail = "client_email",
                Location = "location",
                PrivateKey = "private_key",
                PrivateKeyID = "private_key_id",
                Project = "project",
                TokenUri = "token_uri",
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ClassName = "class_name",
                EmbedBatchSize = 1,
                EmbedMode = EmbedMode.Classification,
                ModelName = "model_name",
                NumWorkers = 0,
            },
            Type = VertexAIEmbeddingConfigType.VertexaiEmbedding,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VertexAIEmbeddingConfig { };

        Assert.Null(model.Component);
        Assert.False(model.RawData.ContainsKey("component"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VertexAIEmbeddingConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VertexAIEmbeddingConfig
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
        var model = new VertexAIEmbeddingConfig
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
        var model = new VertexAIEmbeddingConfig
        {
            Component = new()
            {
                ClientEmail = "client_email",
                Location = "location",
                PrivateKey = "private_key",
                PrivateKeyID = "private_key_id",
                Project = "project",
                TokenUri = "token_uri",
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ClassName = "class_name",
                EmbedBatchSize = 1,
                EmbedMode = EmbedMode.Classification,
                ModelName = "model_name",
                NumWorkers = 0,
            },
            Type = VertexAIEmbeddingConfigType.VertexaiEmbedding,
        };

        VertexAIEmbeddingConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VertexAIEmbeddingConfigTypeTest : TestBase
{
    [Theory]
    [InlineData(VertexAIEmbeddingConfigType.VertexaiEmbedding)]
    public void Validation_Works(VertexAIEmbeddingConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VertexAIEmbeddingConfigType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VertexAIEmbeddingConfigType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VertexAIEmbeddingConfigType.VertexaiEmbedding)]
    public void SerializationRoundtrip_Works(VertexAIEmbeddingConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VertexAIEmbeddingConfigType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VertexAIEmbeddingConfigType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VertexAIEmbeddingConfigType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VertexAIEmbeddingConfigType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
