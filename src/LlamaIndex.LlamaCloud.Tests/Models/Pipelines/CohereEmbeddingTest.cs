using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines;

public class CohereEmbeddingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CohereEmbedding
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

        string expectedApiKey = "api_key";
        string expectedClassName = "class_name";
        long expectedEmbedBatchSize = 1;
        string expectedEmbeddingType = "embedding_type";
        string expectedInputType = "input_type";
        string expectedModelName = "model_name";
        long expectedNumWorkers = 0;
        string expectedTruncate = "truncate";

        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedEmbedBatchSize, model.EmbedBatchSize);
        Assert.Equal(expectedEmbeddingType, model.EmbeddingType);
        Assert.Equal(expectedInputType, model.InputType);
        Assert.Equal(expectedModelName, model.ModelName);
        Assert.Equal(expectedNumWorkers, model.NumWorkers);
        Assert.Equal(expectedTruncate, model.Truncate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CohereEmbedding
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CohereEmbedding>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CohereEmbedding
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CohereEmbedding>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedApiKey = "api_key";
        string expectedClassName = "class_name";
        long expectedEmbedBatchSize = 1;
        string expectedEmbeddingType = "embedding_type";
        string expectedInputType = "input_type";
        string expectedModelName = "model_name";
        long expectedNumWorkers = 0;
        string expectedTruncate = "truncate";

        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedEmbedBatchSize, deserialized.EmbedBatchSize);
        Assert.Equal(expectedEmbeddingType, deserialized.EmbeddingType);
        Assert.Equal(expectedInputType, deserialized.InputType);
        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.Equal(expectedNumWorkers, deserialized.NumWorkers);
        Assert.Equal(expectedTruncate, deserialized.Truncate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CohereEmbedding
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CohereEmbedding
        {
            ApiKey = "api_key",
            InputType = "input_type",
            NumWorkers = 0,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.EmbedBatchSize);
        Assert.False(model.RawData.ContainsKey("embed_batch_size"));
        Assert.Null(model.EmbeddingType);
        Assert.False(model.RawData.ContainsKey("embedding_type"));
        Assert.Null(model.ModelName);
        Assert.False(model.RawData.ContainsKey("model_name"));
        Assert.Null(model.Truncate);
        Assert.False(model.RawData.ContainsKey("truncate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CohereEmbedding
        {
            ApiKey = "api_key",
            InputType = "input_type",
            NumWorkers = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CohereEmbedding
        {
            ApiKey = "api_key",
            InputType = "input_type",
            NumWorkers = 0,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            EmbedBatchSize = null,
            EmbeddingType = null,
            ModelName = null,
            Truncate = null,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.EmbedBatchSize);
        Assert.False(model.RawData.ContainsKey("embed_batch_size"));
        Assert.Null(model.EmbeddingType);
        Assert.False(model.RawData.ContainsKey("embedding_type"));
        Assert.Null(model.ModelName);
        Assert.False(model.RawData.ContainsKey("model_name"));
        Assert.Null(model.Truncate);
        Assert.False(model.RawData.ContainsKey("truncate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CohereEmbedding
        {
            ApiKey = "api_key",
            InputType = "input_type",
            NumWorkers = 0,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            EmbedBatchSize = null,
            EmbeddingType = null,
            ModelName = null,
            Truncate = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CohereEmbedding
        {
            ApiKey = "api_key",
            ClassName = "class_name",
            EmbedBatchSize = 1,
            EmbeddingType = "embedding_type",
            ModelName = "model_name",
            Truncate = "truncate",
        };

        Assert.Null(model.InputType);
        Assert.False(model.RawData.ContainsKey("input_type"));
        Assert.Null(model.NumWorkers);
        Assert.False(model.RawData.ContainsKey("num_workers"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CohereEmbedding
        {
            ApiKey = "api_key",
            ClassName = "class_name",
            EmbedBatchSize = 1,
            EmbeddingType = "embedding_type",
            ModelName = "model_name",
            Truncate = "truncate",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CohereEmbedding
        {
            ApiKey = "api_key",
            ClassName = "class_name",
            EmbedBatchSize = 1,
            EmbeddingType = "embedding_type",
            ModelName = "model_name",
            Truncate = "truncate",

            InputType = null,
            NumWorkers = null,
        };

        Assert.Null(model.InputType);
        Assert.True(model.RawData.ContainsKey("input_type"));
        Assert.Null(model.NumWorkers);
        Assert.True(model.RawData.ContainsKey("num_workers"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CohereEmbedding
        {
            ApiKey = "api_key",
            ClassName = "class_name",
            EmbedBatchSize = 1,
            EmbeddingType = "embedding_type",
            ModelName = "model_name",
            Truncate = "truncate",

            InputType = null,
            NumWorkers = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CohereEmbedding
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

        CohereEmbedding copied = new(model);

        Assert.Equal(model, copied);
    }
}
