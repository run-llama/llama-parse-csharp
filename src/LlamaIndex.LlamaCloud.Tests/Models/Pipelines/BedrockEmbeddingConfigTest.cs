using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Pipelines;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines;

public class BedrockEmbeddingConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BedrockEmbeddingConfig
        {
            Component = new()
            {
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                AwsAccessKeyID = "aws_access_key_id",
                AwsSecretAccessKey = "aws_secret_access_key",
                AwsSessionToken = "aws_session_token",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                MaxRetries = 1,
                ModelName = "model_name",
                NumWorkers = 0,
                ProfileName = "profile_name",
                RegionName = "region_name",
                Timeout = 0,
            },
            Type = BedrockEmbeddingConfigType.BedrockEmbedding,
        };

        BedrockEmbedding expectedComponent = new()
        {
            AdditionalKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            AwsAccessKeyID = "aws_access_key_id",
            AwsSecretAccessKey = "aws_secret_access_key",
            AwsSessionToken = "aws_session_token",
            ClassName = "class_name",
            EmbedBatchSize = 1,
            MaxRetries = 1,
            ModelName = "model_name",
            NumWorkers = 0,
            ProfileName = "profile_name",
            RegionName = "region_name",
            Timeout = 0,
        };
        ApiEnum<string, BedrockEmbeddingConfigType> expectedType =
            BedrockEmbeddingConfigType.BedrockEmbedding;

        Assert.Equal(expectedComponent, model.Component);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BedrockEmbeddingConfig
        {
            Component = new()
            {
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                AwsAccessKeyID = "aws_access_key_id",
                AwsSecretAccessKey = "aws_secret_access_key",
                AwsSessionToken = "aws_session_token",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                MaxRetries = 1,
                ModelName = "model_name",
                NumWorkers = 0,
                ProfileName = "profile_name",
                RegionName = "region_name",
                Timeout = 0,
            },
            Type = BedrockEmbeddingConfigType.BedrockEmbedding,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BedrockEmbeddingConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BedrockEmbeddingConfig
        {
            Component = new()
            {
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                AwsAccessKeyID = "aws_access_key_id",
                AwsSecretAccessKey = "aws_secret_access_key",
                AwsSessionToken = "aws_session_token",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                MaxRetries = 1,
                ModelName = "model_name",
                NumWorkers = 0,
                ProfileName = "profile_name",
                RegionName = "region_name",
                Timeout = 0,
            },
            Type = BedrockEmbeddingConfigType.BedrockEmbedding,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BedrockEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BedrockEmbedding expectedComponent = new()
        {
            AdditionalKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            AwsAccessKeyID = "aws_access_key_id",
            AwsSecretAccessKey = "aws_secret_access_key",
            AwsSessionToken = "aws_session_token",
            ClassName = "class_name",
            EmbedBatchSize = 1,
            MaxRetries = 1,
            ModelName = "model_name",
            NumWorkers = 0,
            ProfileName = "profile_name",
            RegionName = "region_name",
            Timeout = 0,
        };
        ApiEnum<string, BedrockEmbeddingConfigType> expectedType =
            BedrockEmbeddingConfigType.BedrockEmbedding;

        Assert.Equal(expectedComponent, deserialized.Component);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BedrockEmbeddingConfig
        {
            Component = new()
            {
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                AwsAccessKeyID = "aws_access_key_id",
                AwsSecretAccessKey = "aws_secret_access_key",
                AwsSessionToken = "aws_session_token",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                MaxRetries = 1,
                ModelName = "model_name",
                NumWorkers = 0,
                ProfileName = "profile_name",
                RegionName = "region_name",
                Timeout = 0,
            },
            Type = BedrockEmbeddingConfigType.BedrockEmbedding,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BedrockEmbeddingConfig { };

        Assert.Null(model.Component);
        Assert.False(model.RawData.ContainsKey("component"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BedrockEmbeddingConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BedrockEmbeddingConfig
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
        var model = new BedrockEmbeddingConfig
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
        var model = new BedrockEmbeddingConfig
        {
            Component = new()
            {
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                AwsAccessKeyID = "aws_access_key_id",
                AwsSecretAccessKey = "aws_secret_access_key",
                AwsSessionToken = "aws_session_token",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                MaxRetries = 1,
                ModelName = "model_name",
                NumWorkers = 0,
                ProfileName = "profile_name",
                RegionName = "region_name",
                Timeout = 0,
            },
            Type = BedrockEmbeddingConfigType.BedrockEmbedding,
        };

        BedrockEmbeddingConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BedrockEmbeddingConfigTypeTest : TestBase
{
    [Theory]
    [InlineData(BedrockEmbeddingConfigType.BedrockEmbedding)]
    public void Validation_Works(BedrockEmbeddingConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BedrockEmbeddingConfigType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BedrockEmbeddingConfigType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BedrockEmbeddingConfigType.BedrockEmbedding)]
    public void SerializationRoundtrip_Works(BedrockEmbeddingConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BedrockEmbeddingConfigType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BedrockEmbeddingConfigType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BedrockEmbeddingConfigType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BedrockEmbeddingConfigType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
