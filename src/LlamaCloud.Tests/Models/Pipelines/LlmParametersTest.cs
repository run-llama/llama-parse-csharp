using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Pipelines;

namespace LlamaCloud.Tests.Models.Pipelines;

public class LlmParametersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LlmParameters
        {
            ClassName = "class_name",
            ModelName = ModelName.AzureOpenAIGpt4O,
            SystemPrompt = "system_prompt",
            Temperature = 0,
            UseChainOfThoughtReasoning = true,
            UseCitation = true,
        };

        string expectedClassName = "class_name";
        ApiEnum<string, ModelName> expectedModelName = ModelName.AzureOpenAIGpt4O;
        string expectedSystemPrompt = "system_prompt";
        double expectedTemperature = 0;
        bool expectedUseChainOfThoughtReasoning = true;
        bool expectedUseCitation = true;

        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedModelName, model.ModelName);
        Assert.Equal(expectedSystemPrompt, model.SystemPrompt);
        Assert.Equal(expectedTemperature, model.Temperature);
        Assert.Equal(expectedUseChainOfThoughtReasoning, model.UseChainOfThoughtReasoning);
        Assert.Equal(expectedUseCitation, model.UseCitation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LlmParameters
        {
            ClassName = "class_name",
            ModelName = ModelName.AzureOpenAIGpt4O,
            SystemPrompt = "system_prompt",
            Temperature = 0,
            UseChainOfThoughtReasoning = true,
            UseCitation = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LlmParameters>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LlmParameters
        {
            ClassName = "class_name",
            ModelName = ModelName.AzureOpenAIGpt4O,
            SystemPrompt = "system_prompt",
            Temperature = 0,
            UseChainOfThoughtReasoning = true,
            UseCitation = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LlmParameters>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClassName = "class_name";
        ApiEnum<string, ModelName> expectedModelName = ModelName.AzureOpenAIGpt4O;
        string expectedSystemPrompt = "system_prompt";
        double expectedTemperature = 0;
        bool expectedUseChainOfThoughtReasoning = true;
        bool expectedUseCitation = true;

        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.Equal(expectedSystemPrompt, deserialized.SystemPrompt);
        Assert.Equal(expectedTemperature, deserialized.Temperature);
        Assert.Equal(expectedUseChainOfThoughtReasoning, deserialized.UseChainOfThoughtReasoning);
        Assert.Equal(expectedUseCitation, deserialized.UseCitation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LlmParameters
        {
            ClassName = "class_name",
            ModelName = ModelName.AzureOpenAIGpt4O,
            SystemPrompt = "system_prompt",
            Temperature = 0,
            UseChainOfThoughtReasoning = true,
            UseCitation = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LlmParameters
        {
            SystemPrompt = "system_prompt",
            Temperature = 0,
            UseChainOfThoughtReasoning = true,
            UseCitation = true,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.ModelName);
        Assert.False(model.RawData.ContainsKey("model_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new LlmParameters
        {
            SystemPrompt = "system_prompt",
            Temperature = 0,
            UseChainOfThoughtReasoning = true,
            UseCitation = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new LlmParameters
        {
            SystemPrompt = "system_prompt",
            Temperature = 0,
            UseChainOfThoughtReasoning = true,
            UseCitation = true,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            ModelName = null,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.ModelName);
        Assert.False(model.RawData.ContainsKey("model_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LlmParameters
        {
            SystemPrompt = "system_prompt",
            Temperature = 0,
            UseChainOfThoughtReasoning = true,
            UseCitation = true,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            ModelName = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LlmParameters
        {
            ClassName = "class_name",
            ModelName = ModelName.AzureOpenAIGpt4O,
        };

        Assert.Null(model.SystemPrompt);
        Assert.False(model.RawData.ContainsKey("system_prompt"));
        Assert.Null(model.Temperature);
        Assert.False(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.UseChainOfThoughtReasoning);
        Assert.False(model.RawData.ContainsKey("use_chain_of_thought_reasoning"));
        Assert.Null(model.UseCitation);
        Assert.False(model.RawData.ContainsKey("use_citation"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new LlmParameters
        {
            ClassName = "class_name",
            ModelName = ModelName.AzureOpenAIGpt4O,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new LlmParameters
        {
            ClassName = "class_name",
            ModelName = ModelName.AzureOpenAIGpt4O,

            SystemPrompt = null,
            Temperature = null,
            UseChainOfThoughtReasoning = null,
            UseCitation = null,
        };

        Assert.Null(model.SystemPrompt);
        Assert.True(model.RawData.ContainsKey("system_prompt"));
        Assert.Null(model.Temperature);
        Assert.True(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.UseChainOfThoughtReasoning);
        Assert.True(model.RawData.ContainsKey("use_chain_of_thought_reasoning"));
        Assert.Null(model.UseCitation);
        Assert.True(model.RawData.ContainsKey("use_citation"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LlmParameters
        {
            ClassName = "class_name",
            ModelName = ModelName.AzureOpenAIGpt4O,

            SystemPrompt = null,
            Temperature = null,
            UseChainOfThoughtReasoning = null,
            UseCitation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LlmParameters
        {
            ClassName = "class_name",
            ModelName = ModelName.AzureOpenAIGpt4O,
            SystemPrompt = "system_prompt",
            Temperature = 0,
            UseChainOfThoughtReasoning = true,
            UseCitation = true,
        };

        LlmParameters copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModelNameTest : TestBase
{
    [Theory]
    [InlineData(ModelName.AzureOpenAIGpt4O)]
    [InlineData(ModelName.AzureOpenAIGpt4OMini)]
    [InlineData(ModelName.AzureOpenAIGpt4_1)]
    [InlineData(ModelName.AzureOpenAIGpt4_1Mini)]
    [InlineData(ModelName.AzureOpenAIGpt4_1Nano)]
    [InlineData(ModelName.BedrockClaude3_5SonnetV1)]
    [InlineData(ModelName.BedrockClaude3_5SonnetV2)]
    [InlineData(ModelName.Claude4_5Sonnet)]
    [InlineData(ModelName.Gpt4O)]
    [InlineData(ModelName.Gpt4OMini)]
    [InlineData(ModelName.Gpt4_1)]
    [InlineData(ModelName.Gpt4_1Mini)]
    [InlineData(ModelName.Gpt4_1Nano)]
    public void Validation_Works(ModelName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelName> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModelName>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ModelName.AzureOpenAIGpt4O)]
    [InlineData(ModelName.AzureOpenAIGpt4OMini)]
    [InlineData(ModelName.AzureOpenAIGpt4_1)]
    [InlineData(ModelName.AzureOpenAIGpt4_1Mini)]
    [InlineData(ModelName.AzureOpenAIGpt4_1Nano)]
    [InlineData(ModelName.BedrockClaude3_5SonnetV1)]
    [InlineData(ModelName.BedrockClaude3_5SonnetV2)]
    [InlineData(ModelName.Claude4_5Sonnet)]
    [InlineData(ModelName.Gpt4O)]
    [InlineData(ModelName.Gpt4OMini)]
    [InlineData(ModelName.Gpt4_1)]
    [InlineData(ModelName.Gpt4_1Mini)]
    [InlineData(ModelName.Gpt4_1Nano)]
    public void SerializationRoundtrip_Works(ModelName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelName> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModelName>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModelName>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModelName>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
