using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Pipelines;

namespace LlamaCloud.Tests.Models.Pipelines;

public class HuggingFaceInferenceApiEmbeddingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new HuggingFaceInferenceApiEmbedding
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

        Token expectedToken = "string";
        string expectedClassName = "class_name";
        Dictionary<string, string> expectedCookies = new() { { "foo", "string" } };
        long expectedEmbedBatchSize = 1;
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        string expectedModelName = "model_name";
        long expectedNumWorkers = 0;
        ApiEnum<string, Pooling> expectedPooling = Pooling.Cls;
        string expectedQueryInstruction = "query_instruction";
        string expectedTask = "task";
        string expectedTextInstruction = "text_instruction";
        double expectedTimeout = 0;

        Assert.Equal(expectedToken, model.Token);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.NotNull(model.Cookies);
        Assert.Equal(expectedCookies.Count, model.Cookies.Count);
        foreach (var item in expectedCookies)
        {
            Assert.True(model.Cookies.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Cookies[item.Key]);
        }
        Assert.Equal(expectedEmbedBatchSize, model.EmbedBatchSize);
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
        Assert.Equal(expectedModelName, model.ModelName);
        Assert.Equal(expectedNumWorkers, model.NumWorkers);
        Assert.Equal(expectedPooling, model.Pooling);
        Assert.Equal(expectedQueryInstruction, model.QueryInstruction);
        Assert.Equal(expectedTask, model.Task);
        Assert.Equal(expectedTextInstruction, model.TextInstruction);
        Assert.Equal(expectedTimeout, model.Timeout);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new HuggingFaceInferenceApiEmbedding
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<HuggingFaceInferenceApiEmbedding>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new HuggingFaceInferenceApiEmbedding
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<HuggingFaceInferenceApiEmbedding>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Token expectedToken = "string";
        string expectedClassName = "class_name";
        Dictionary<string, string> expectedCookies = new() { { "foo", "string" } };
        long expectedEmbedBatchSize = 1;
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        string expectedModelName = "model_name";
        long expectedNumWorkers = 0;
        ApiEnum<string, Pooling> expectedPooling = Pooling.Cls;
        string expectedQueryInstruction = "query_instruction";
        string expectedTask = "task";
        string expectedTextInstruction = "text_instruction";
        double expectedTimeout = 0;

        Assert.Equal(expectedToken, deserialized.Token);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.NotNull(deserialized.Cookies);
        Assert.Equal(expectedCookies.Count, deserialized.Cookies.Count);
        foreach (var item in expectedCookies)
        {
            Assert.True(deserialized.Cookies.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Cookies[item.Key]);
        }
        Assert.Equal(expectedEmbedBatchSize, deserialized.EmbedBatchSize);
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.Equal(expectedNumWorkers, deserialized.NumWorkers);
        Assert.Equal(expectedPooling, deserialized.Pooling);
        Assert.Equal(expectedQueryInstruction, deserialized.QueryInstruction);
        Assert.Equal(expectedTask, deserialized.Task);
        Assert.Equal(expectedTextInstruction, deserialized.TextInstruction);
        Assert.Equal(expectedTimeout, deserialized.Timeout);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new HuggingFaceInferenceApiEmbedding
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new HuggingFaceInferenceApiEmbedding
        {
            Token = "string",
            Cookies = new Dictionary<string, string>() { { "foo", "string" } },
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ModelName = "model_name",
            NumWorkers = 0,
            Pooling = Pooling.Cls,
            QueryInstruction = "query_instruction",
            Task = "task",
            TextInstruction = "text_instruction",
            Timeout = 0,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.EmbedBatchSize);
        Assert.False(model.RawData.ContainsKey("embed_batch_size"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new HuggingFaceInferenceApiEmbedding
        {
            Token = "string",
            Cookies = new Dictionary<string, string>() { { "foo", "string" } },
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ModelName = "model_name",
            NumWorkers = 0,
            Pooling = Pooling.Cls,
            QueryInstruction = "query_instruction",
            Task = "task",
            TextInstruction = "text_instruction",
            Timeout = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new HuggingFaceInferenceApiEmbedding
        {
            Token = "string",
            Cookies = new Dictionary<string, string>() { { "foo", "string" } },
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ModelName = "model_name",
            NumWorkers = 0,
            Pooling = Pooling.Cls,
            QueryInstruction = "query_instruction",
            Task = "task",
            TextInstruction = "text_instruction",
            Timeout = 0,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            EmbedBatchSize = null,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.EmbedBatchSize);
        Assert.False(model.RawData.ContainsKey("embed_batch_size"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new HuggingFaceInferenceApiEmbedding
        {
            Token = "string",
            Cookies = new Dictionary<string, string>() { { "foo", "string" } },
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ModelName = "model_name",
            NumWorkers = 0,
            Pooling = Pooling.Cls,
            QueryInstruction = "query_instruction",
            Task = "task",
            TextInstruction = "text_instruction",
            Timeout = 0,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            EmbedBatchSize = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new HuggingFaceInferenceApiEmbedding
        {
            ClassName = "class_name",
            EmbedBatchSize = 1,
        };

        Assert.Null(model.Token);
        Assert.False(model.RawData.ContainsKey("token"));
        Assert.Null(model.Cookies);
        Assert.False(model.RawData.ContainsKey("cookies"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.ModelName);
        Assert.False(model.RawData.ContainsKey("model_name"));
        Assert.Null(model.NumWorkers);
        Assert.False(model.RawData.ContainsKey("num_workers"));
        Assert.Null(model.Pooling);
        Assert.False(model.RawData.ContainsKey("pooling"));
        Assert.Null(model.QueryInstruction);
        Assert.False(model.RawData.ContainsKey("query_instruction"));
        Assert.Null(model.Task);
        Assert.False(model.RawData.ContainsKey("task"));
        Assert.Null(model.TextInstruction);
        Assert.False(model.RawData.ContainsKey("text_instruction"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new HuggingFaceInferenceApiEmbedding
        {
            ClassName = "class_name",
            EmbedBatchSize = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new HuggingFaceInferenceApiEmbedding
        {
            ClassName = "class_name",
            EmbedBatchSize = 1,

            Token = null,
            Cookies = null,
            Headers = null,
            ModelName = null,
            NumWorkers = null,
            Pooling = null,
            QueryInstruction = null,
            Task = null,
            TextInstruction = null,
            Timeout = null,
        };

        Assert.Null(model.Token);
        Assert.True(model.RawData.ContainsKey("token"));
        Assert.Null(model.Cookies);
        Assert.True(model.RawData.ContainsKey("cookies"));
        Assert.Null(model.Headers);
        Assert.True(model.RawData.ContainsKey("headers"));
        Assert.Null(model.ModelName);
        Assert.True(model.RawData.ContainsKey("model_name"));
        Assert.Null(model.NumWorkers);
        Assert.True(model.RawData.ContainsKey("num_workers"));
        Assert.Null(model.Pooling);
        Assert.True(model.RawData.ContainsKey("pooling"));
        Assert.Null(model.QueryInstruction);
        Assert.True(model.RawData.ContainsKey("query_instruction"));
        Assert.Null(model.Task);
        Assert.True(model.RawData.ContainsKey("task"));
        Assert.Null(model.TextInstruction);
        Assert.True(model.RawData.ContainsKey("text_instruction"));
        Assert.Null(model.Timeout);
        Assert.True(model.RawData.ContainsKey("timeout"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new HuggingFaceInferenceApiEmbedding
        {
            ClassName = "class_name",
            EmbedBatchSize = 1,

            Token = null,
            Cookies = null,
            Headers = null,
            ModelName = null,
            NumWorkers = null,
            Pooling = null,
            QueryInstruction = null,
            Task = null,
            TextInstruction = null,
            Timeout = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new HuggingFaceInferenceApiEmbedding
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

        HuggingFaceInferenceApiEmbedding copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TokenTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Token value = "string";
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        Token value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Token value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Token>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        Token value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Token>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PoolingTest : TestBase
{
    [Theory]
    [InlineData(Pooling.Cls)]
    [InlineData(Pooling.Last)]
    [InlineData(Pooling.Mean)]
    public void Validation_Works(Pooling rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Pooling> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Pooling>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Pooling.Cls)]
    [InlineData(Pooling.Last)]
    [InlineData(Pooling.Mean)]
    public void SerializationRoundtrip_Works(Pooling rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Pooling> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Pooling>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Pooling>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Pooling>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
