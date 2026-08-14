using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Pipelines;

namespace LlamaCloud.Tests.Models.Pipelines;

public class BedrockEmbeddingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BedrockEmbedding
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

        Dictionary<string, JsonElement> expectedAdditionalKwargs = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedAwsAccessKeyID = "aws_access_key_id";
        string expectedAwsSecretAccessKey = "aws_secret_access_key";
        string expectedAwsSessionToken = "aws_session_token";
        string expectedClassName = "class_name";
        long expectedEmbedBatchSize = 1;
        long expectedMaxRetries = 1;
        string expectedModelName = "model_name";
        long expectedNumWorkers = 0;
        string expectedProfileName = "profile_name";
        string expectedRegionName = "region_name";
        double expectedTimeout = 0;

        Assert.NotNull(model.AdditionalKwargs);
        Assert.Equal(expectedAdditionalKwargs.Count, model.AdditionalKwargs.Count);
        foreach (var item in expectedAdditionalKwargs)
        {
            Assert.True(model.AdditionalKwargs.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.AdditionalKwargs[item.Key]));
        }
        Assert.Equal(expectedAwsAccessKeyID, model.AwsAccessKeyID);
        Assert.Equal(expectedAwsSecretAccessKey, model.AwsSecretAccessKey);
        Assert.Equal(expectedAwsSessionToken, model.AwsSessionToken);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedEmbedBatchSize, model.EmbedBatchSize);
        Assert.Equal(expectedMaxRetries, model.MaxRetries);
        Assert.Equal(expectedModelName, model.ModelName);
        Assert.Equal(expectedNumWorkers, model.NumWorkers);
        Assert.Equal(expectedProfileName, model.ProfileName);
        Assert.Equal(expectedRegionName, model.RegionName);
        Assert.Equal(expectedTimeout, model.Timeout);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BedrockEmbedding
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BedrockEmbedding>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BedrockEmbedding
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BedrockEmbedding>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, JsonElement> expectedAdditionalKwargs = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedAwsAccessKeyID = "aws_access_key_id";
        string expectedAwsSecretAccessKey = "aws_secret_access_key";
        string expectedAwsSessionToken = "aws_session_token";
        string expectedClassName = "class_name";
        long expectedEmbedBatchSize = 1;
        long expectedMaxRetries = 1;
        string expectedModelName = "model_name";
        long expectedNumWorkers = 0;
        string expectedProfileName = "profile_name";
        string expectedRegionName = "region_name";
        double expectedTimeout = 0;

        Assert.NotNull(deserialized.AdditionalKwargs);
        Assert.Equal(expectedAdditionalKwargs.Count, deserialized.AdditionalKwargs.Count);
        foreach (var item in expectedAdditionalKwargs)
        {
            Assert.True(deserialized.AdditionalKwargs.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.AdditionalKwargs[item.Key]));
        }
        Assert.Equal(expectedAwsAccessKeyID, deserialized.AwsAccessKeyID);
        Assert.Equal(expectedAwsSecretAccessKey, deserialized.AwsSecretAccessKey);
        Assert.Equal(expectedAwsSessionToken, deserialized.AwsSessionToken);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedEmbedBatchSize, deserialized.EmbedBatchSize);
        Assert.Equal(expectedMaxRetries, deserialized.MaxRetries);
        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.Equal(expectedNumWorkers, deserialized.NumWorkers);
        Assert.Equal(expectedProfileName, deserialized.ProfileName);
        Assert.Equal(expectedRegionName, deserialized.RegionName);
        Assert.Equal(expectedTimeout, deserialized.Timeout);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BedrockEmbedding
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BedrockEmbedding
        {
            AwsAccessKeyID = "aws_access_key_id",
            AwsSecretAccessKey = "aws_secret_access_key",
            AwsSessionToken = "aws_session_token",
            NumWorkers = 0,
            ProfileName = "profile_name",
            RegionName = "region_name",
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
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BedrockEmbedding
        {
            AwsAccessKeyID = "aws_access_key_id",
            AwsSecretAccessKey = "aws_secret_access_key",
            AwsSessionToken = "aws_session_token",
            NumWorkers = 0,
            ProfileName = "profile_name",
            RegionName = "region_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BedrockEmbedding
        {
            AwsAccessKeyID = "aws_access_key_id",
            AwsSecretAccessKey = "aws_secret_access_key",
            AwsSessionToken = "aws_session_token",
            NumWorkers = 0,
            ProfileName = "profile_name",
            RegionName = "region_name",

            // Null should be interpreted as omitted for these properties
            AdditionalKwargs = null,
            ClassName = null,
            EmbedBatchSize = null,
            MaxRetries = null,
            ModelName = null,
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
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BedrockEmbedding
        {
            AwsAccessKeyID = "aws_access_key_id",
            AwsSecretAccessKey = "aws_secret_access_key",
            AwsSessionToken = "aws_session_token",
            NumWorkers = 0,
            ProfileName = "profile_name",
            RegionName = "region_name",

            // Null should be interpreted as omitted for these properties
            AdditionalKwargs = null,
            ClassName = null,
            EmbedBatchSize = null,
            MaxRetries = null,
            ModelName = null,
            Timeout = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BedrockEmbedding
        {
            AdditionalKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ClassName = "class_name",
            EmbedBatchSize = 1,
            MaxRetries = 1,
            ModelName = "model_name",
            Timeout = 0,
        };

        Assert.Null(model.AwsAccessKeyID);
        Assert.False(model.RawData.ContainsKey("aws_access_key_id"));
        Assert.Null(model.AwsSecretAccessKey);
        Assert.False(model.RawData.ContainsKey("aws_secret_access_key"));
        Assert.Null(model.AwsSessionToken);
        Assert.False(model.RawData.ContainsKey("aws_session_token"));
        Assert.Null(model.NumWorkers);
        Assert.False(model.RawData.ContainsKey("num_workers"));
        Assert.Null(model.ProfileName);
        Assert.False(model.RawData.ContainsKey("profile_name"));
        Assert.Null(model.RegionName);
        Assert.False(model.RawData.ContainsKey("region_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BedrockEmbedding
        {
            AdditionalKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ClassName = "class_name",
            EmbedBatchSize = 1,
            MaxRetries = 1,
            ModelName = "model_name",
            Timeout = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BedrockEmbedding
        {
            AdditionalKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ClassName = "class_name",
            EmbedBatchSize = 1,
            MaxRetries = 1,
            ModelName = "model_name",
            Timeout = 0,

            AwsAccessKeyID = null,
            AwsSecretAccessKey = null,
            AwsSessionToken = null,
            NumWorkers = null,
            ProfileName = null,
            RegionName = null,
        };

        Assert.Null(model.AwsAccessKeyID);
        Assert.True(model.RawData.ContainsKey("aws_access_key_id"));
        Assert.Null(model.AwsSecretAccessKey);
        Assert.True(model.RawData.ContainsKey("aws_secret_access_key"));
        Assert.Null(model.AwsSessionToken);
        Assert.True(model.RawData.ContainsKey("aws_session_token"));
        Assert.Null(model.NumWorkers);
        Assert.True(model.RawData.ContainsKey("num_workers"));
        Assert.Null(model.ProfileName);
        Assert.True(model.RawData.ContainsKey("profile_name"));
        Assert.Null(model.RegionName);
        Assert.True(model.RawData.ContainsKey("region_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BedrockEmbedding
        {
            AdditionalKwargs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ClassName = "class_name",
            EmbedBatchSize = 1,
            MaxRetries = 1,
            ModelName = "model_name",
            Timeout = 0,

            AwsAccessKeyID = null,
            AwsSecretAccessKey = null,
            AwsSessionToken = null,
            NumWorkers = null,
            ProfileName = null,
            RegionName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BedrockEmbedding
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

        BedrockEmbedding copied = new(model);

        Assert.Equal(model, copied);
    }
}
