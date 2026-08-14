using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Pipelines;

namespace LlamaCloud.Tests.Models.Pipelines;

public class GeminiEmbeddingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GeminiEmbedding
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

        string expectedApiBase = "api_base";
        string expectedApiKey = "api_key";
        string expectedClassName = "class_name";
        long expectedEmbedBatchSize = 1;
        string expectedModelName = "model_name";
        long expectedNumWorkers = 0;
        long expectedOutputDimensionality = 0;
        string expectedTaskType = "task_type";
        string expectedTitle = "title";
        string expectedTransport = "transport";

        Assert.Equal(expectedApiBase, model.ApiBase);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedEmbedBatchSize, model.EmbedBatchSize);
        Assert.Equal(expectedModelName, model.ModelName);
        Assert.Equal(expectedNumWorkers, model.NumWorkers);
        Assert.Equal(expectedOutputDimensionality, model.OutputDimensionality);
        Assert.Equal(expectedTaskType, model.TaskType);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedTransport, model.Transport);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GeminiEmbedding
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GeminiEmbedding>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GeminiEmbedding
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GeminiEmbedding>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedApiBase = "api_base";
        string expectedApiKey = "api_key";
        string expectedClassName = "class_name";
        long expectedEmbedBatchSize = 1;
        string expectedModelName = "model_name";
        long expectedNumWorkers = 0;
        long expectedOutputDimensionality = 0;
        string expectedTaskType = "task_type";
        string expectedTitle = "title";
        string expectedTransport = "transport";

        Assert.Equal(expectedApiBase, deserialized.ApiBase);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedEmbedBatchSize, deserialized.EmbedBatchSize);
        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.Equal(expectedNumWorkers, deserialized.NumWorkers);
        Assert.Equal(expectedOutputDimensionality, deserialized.OutputDimensionality);
        Assert.Equal(expectedTaskType, deserialized.TaskType);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedTransport, deserialized.Transport);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GeminiEmbedding
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GeminiEmbedding
        {
            ApiBase = "api_base",
            ApiKey = "api_key",
            NumWorkers = 0,
            OutputDimensionality = 0,
            TaskType = "task_type",
            Title = "title",
            Transport = "transport",
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.EmbedBatchSize);
        Assert.False(model.RawData.ContainsKey("embed_batch_size"));
        Assert.Null(model.ModelName);
        Assert.False(model.RawData.ContainsKey("model_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GeminiEmbedding
        {
            ApiBase = "api_base",
            ApiKey = "api_key",
            NumWorkers = 0,
            OutputDimensionality = 0,
            TaskType = "task_type",
            Title = "title",
            Transport = "transport",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GeminiEmbedding
        {
            ApiBase = "api_base",
            ApiKey = "api_key",
            NumWorkers = 0,
            OutputDimensionality = 0,
            TaskType = "task_type",
            Title = "title",
            Transport = "transport",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            EmbedBatchSize = null,
            ModelName = null,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.EmbedBatchSize);
        Assert.False(model.RawData.ContainsKey("embed_batch_size"));
        Assert.Null(model.ModelName);
        Assert.False(model.RawData.ContainsKey("model_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GeminiEmbedding
        {
            ApiBase = "api_base",
            ApiKey = "api_key",
            NumWorkers = 0,
            OutputDimensionality = 0,
            TaskType = "task_type",
            Title = "title",
            Transport = "transport",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            EmbedBatchSize = null,
            ModelName = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GeminiEmbedding
        {
            ClassName = "class_name",
            EmbedBatchSize = 1,
            ModelName = "model_name",
        };

        Assert.Null(model.ApiBase);
        Assert.False(model.RawData.ContainsKey("api_base"));
        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("api_key"));
        Assert.Null(model.NumWorkers);
        Assert.False(model.RawData.ContainsKey("num_workers"));
        Assert.Null(model.OutputDimensionality);
        Assert.False(model.RawData.ContainsKey("output_dimensionality"));
        Assert.Null(model.TaskType);
        Assert.False(model.RawData.ContainsKey("task_type"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.Transport);
        Assert.False(model.RawData.ContainsKey("transport"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new GeminiEmbedding
        {
            ClassName = "class_name",
            EmbedBatchSize = 1,
            ModelName = "model_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new GeminiEmbedding
        {
            ClassName = "class_name",
            EmbedBatchSize = 1,
            ModelName = "model_name",

            ApiBase = null,
            ApiKey = null,
            NumWorkers = null,
            OutputDimensionality = null,
            TaskType = null,
            Title = null,
            Transport = null,
        };

        Assert.Null(model.ApiBase);
        Assert.True(model.RawData.ContainsKey("api_base"));
        Assert.Null(model.ApiKey);
        Assert.True(model.RawData.ContainsKey("api_key"));
        Assert.Null(model.NumWorkers);
        Assert.True(model.RawData.ContainsKey("num_workers"));
        Assert.Null(model.OutputDimensionality);
        Assert.True(model.RawData.ContainsKey("output_dimensionality"));
        Assert.Null(model.TaskType);
        Assert.True(model.RawData.ContainsKey("task_type"));
        Assert.Null(model.Title);
        Assert.True(model.RawData.ContainsKey("title"));
        Assert.Null(model.Transport);
        Assert.True(model.RawData.ContainsKey("transport"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GeminiEmbedding
        {
            ClassName = "class_name",
            EmbedBatchSize = 1,
            ModelName = "model_name",

            ApiBase = null,
            ApiKey = null,
            NumWorkers = null,
            OutputDimensionality = null,
            TaskType = null,
            Title = null,
            Transport = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GeminiEmbedding
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

        GeminiEmbedding copied = new(model);

        Assert.Equal(model, copied);
    }
}
