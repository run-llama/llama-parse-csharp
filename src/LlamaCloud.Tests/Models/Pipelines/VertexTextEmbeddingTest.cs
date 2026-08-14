using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Pipelines;

namespace LlamaCloud.Tests.Models.Pipelines;

public class VertexTextEmbeddingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VertexTextEmbedding
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

        string expectedClientEmail = "client_email";
        string expectedLocation = "location";
        string expectedPrivateKey = "private_key";
        string expectedPrivateKeyID = "private_key_id";
        string expectedProject = "project";
        string expectedTokenUri = "token_uri";
        Dictionary<string, JsonElement> expectedAdditionalKwargs = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedClassName = "class_name";
        long expectedEmbedBatchSize = 1;
        ApiEnum<string, EmbedMode> expectedEmbedMode = EmbedMode.Classification;
        string expectedModelName = "model_name";
        long expectedNumWorkers = 0;

        Assert.Equal(expectedClientEmail, model.ClientEmail);
        Assert.Equal(expectedLocation, model.Location);
        Assert.Equal(expectedPrivateKey, model.PrivateKey);
        Assert.Equal(expectedPrivateKeyID, model.PrivateKeyID);
        Assert.Equal(expectedProject, model.Project);
        Assert.Equal(expectedTokenUri, model.TokenUri);
        Assert.NotNull(model.AdditionalKwargs);
        Assert.Equal(expectedAdditionalKwargs.Count, model.AdditionalKwargs.Count);
        foreach (var item in expectedAdditionalKwargs)
        {
            Assert.True(model.AdditionalKwargs.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.AdditionalKwargs[item.Key]));
        }
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedEmbedBatchSize, model.EmbedBatchSize);
        Assert.Equal(expectedEmbedMode, model.EmbedMode);
        Assert.Equal(expectedModelName, model.ModelName);
        Assert.Equal(expectedNumWorkers, model.NumWorkers);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VertexTextEmbedding
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VertexTextEmbedding>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VertexTextEmbedding
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VertexTextEmbedding>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClientEmail = "client_email";
        string expectedLocation = "location";
        string expectedPrivateKey = "private_key";
        string expectedPrivateKeyID = "private_key_id";
        string expectedProject = "project";
        string expectedTokenUri = "token_uri";
        Dictionary<string, JsonElement> expectedAdditionalKwargs = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedClassName = "class_name";
        long expectedEmbedBatchSize = 1;
        ApiEnum<string, EmbedMode> expectedEmbedMode = EmbedMode.Classification;
        string expectedModelName = "model_name";
        long expectedNumWorkers = 0;

        Assert.Equal(expectedClientEmail, deserialized.ClientEmail);
        Assert.Equal(expectedLocation, deserialized.Location);
        Assert.Equal(expectedPrivateKey, deserialized.PrivateKey);
        Assert.Equal(expectedPrivateKeyID, deserialized.PrivateKeyID);
        Assert.Equal(expectedProject, deserialized.Project);
        Assert.Equal(expectedTokenUri, deserialized.TokenUri);
        Assert.NotNull(deserialized.AdditionalKwargs);
        Assert.Equal(expectedAdditionalKwargs.Count, deserialized.AdditionalKwargs.Count);
        foreach (var item in expectedAdditionalKwargs)
        {
            Assert.True(deserialized.AdditionalKwargs.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.AdditionalKwargs[item.Key]));
        }
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedEmbedBatchSize, deserialized.EmbedBatchSize);
        Assert.Equal(expectedEmbedMode, deserialized.EmbedMode);
        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.Equal(expectedNumWorkers, deserialized.NumWorkers);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VertexTextEmbedding
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VertexTextEmbedding
        {
            ClientEmail = "client_email",
            Location = "location",
            PrivateKey = "private_key",
            PrivateKeyID = "private_key_id",
            Project = "project",
            TokenUri = "token_uri",
            NumWorkers = 0,
        };

        Assert.Null(model.AdditionalKwargs);
        Assert.False(model.RawData.ContainsKey("additional_kwargs"));
        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.EmbedBatchSize);
        Assert.False(model.RawData.ContainsKey("embed_batch_size"));
        Assert.Null(model.EmbedMode);
        Assert.False(model.RawData.ContainsKey("embed_mode"));
        Assert.Null(model.ModelName);
        Assert.False(model.RawData.ContainsKey("model_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VertexTextEmbedding
        {
            ClientEmail = "client_email",
            Location = "location",
            PrivateKey = "private_key",
            PrivateKeyID = "private_key_id",
            Project = "project",
            TokenUri = "token_uri",
            NumWorkers = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VertexTextEmbedding
        {
            ClientEmail = "client_email",
            Location = "location",
            PrivateKey = "private_key",
            PrivateKeyID = "private_key_id",
            Project = "project",
            TokenUri = "token_uri",
            NumWorkers = 0,

            // Null should be interpreted as omitted for these properties
            AdditionalKwargs = null,
            ClassName = null,
            EmbedBatchSize = null,
            EmbedMode = null,
            ModelName = null,
        };

        Assert.Null(model.AdditionalKwargs);
        Assert.False(model.RawData.ContainsKey("additional_kwargs"));
        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.EmbedBatchSize);
        Assert.False(model.RawData.ContainsKey("embed_batch_size"));
        Assert.Null(model.EmbedMode);
        Assert.False(model.RawData.ContainsKey("embed_mode"));
        Assert.Null(model.ModelName);
        Assert.False(model.RawData.ContainsKey("model_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VertexTextEmbedding
        {
            ClientEmail = "client_email",
            Location = "location",
            PrivateKey = "private_key",
            PrivateKeyID = "private_key_id",
            Project = "project",
            TokenUri = "token_uri",
            NumWorkers = 0,

            // Null should be interpreted as omitted for these properties
            AdditionalKwargs = null,
            ClassName = null,
            EmbedBatchSize = null,
            EmbedMode = null,
            ModelName = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VertexTextEmbedding
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
        };

        Assert.Null(model.NumWorkers);
        Assert.False(model.RawData.ContainsKey("num_workers"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VertexTextEmbedding
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VertexTextEmbedding
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

            NumWorkers = null,
        };

        Assert.Null(model.NumWorkers);
        Assert.True(model.RawData.ContainsKey("num_workers"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VertexTextEmbedding
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

            NumWorkers = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VertexTextEmbedding
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

        VertexTextEmbedding copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EmbedModeTest : TestBase
{
    [Theory]
    [InlineData(EmbedMode.Classification)]
    [InlineData(EmbedMode.Clustering)]
    [InlineData(EmbedMode.Default)]
    [InlineData(EmbedMode.Retrieval)]
    [InlineData(EmbedMode.Similarity)]
    public void Validation_Works(EmbedMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EmbedMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EmbedMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EmbedMode.Classification)]
    [InlineData(EmbedMode.Clustering)]
    [InlineData(EmbedMode.Default)]
    [InlineData(EmbedMode.Retrieval)]
    [InlineData(EmbedMode.Similarity)]
    public void SerializationRoundtrip_Works(EmbedMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EmbedMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EmbedMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EmbedMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EmbedMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
