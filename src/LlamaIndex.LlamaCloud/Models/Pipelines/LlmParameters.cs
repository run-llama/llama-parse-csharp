using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Pipelines;

[JsonConverter(typeof(JsonModelConverter<LlmParameters, LlmParametersFromRaw>))]
public sealed record class LlmParameters : JsonModel
{
    public string? ClassName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("class_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("class_name", value);
        }
    }

    /// <summary>
    /// The name of the model to use for LLM completions.
    /// </summary>
    public ApiEnum<string, ModelName>? ModelName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ModelName>>("model_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("model_name", value);
        }
    }

    /// <summary>
    /// The system prompt to use for the completion.
    /// </summary>
    public string? SystemPrompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("system_prompt");
        }
        init { this._rawData.Set("system_prompt", value); }
    }

    /// <summary>
    /// The temperature value for the model.
    /// </summary>
    public double? Temperature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("temperature");
        }
        init { this._rawData.Set("temperature", value); }
    }

    /// <summary>
    /// Whether to use chain of thought reasoning.
    /// </summary>
    public bool? UseChainOfThoughtReasoning
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("use_chain_of_thought_reasoning");
        }
        init { this._rawData.Set("use_chain_of_thought_reasoning", value); }
    }

    /// <summary>
    /// Whether to show citations in the response.
    /// </summary>
    public bool? UseCitation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("use_citation");
        }
        init { this._rawData.Set("use_citation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClassName;
        this.ModelName?.Validate();
        _ = this.SystemPrompt;
        _ = this.Temperature;
        _ = this.UseChainOfThoughtReasoning;
        _ = this.UseCitation;
    }

    public LlmParameters() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LlmParameters(LlmParameters llmParameters)
        : base(llmParameters) { }
#pragma warning restore CS8618

    public LlmParameters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LlmParameters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LlmParametersFromRaw.FromRawUnchecked"/>
    public static LlmParameters FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LlmParametersFromRaw : IFromRawJson<LlmParameters>
{
    /// <inheritdoc/>
    public LlmParameters FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LlmParameters.FromRawUnchecked(rawData);
}

/// <summary>
/// The name of the model to use for LLM completions.
/// </summary>
[JsonConverter(typeof(ModelNameConverter))]
public enum ModelName
{
    AzureOpenAIGpt4O,
    AzureOpenAIGpt4OMini,
    AzureOpenAIGpt4_1,
    AzureOpenAIGpt4_1Mini,
    AzureOpenAIGpt4_1Nano,
    BedrockClaude3_5SonnetV1,
    BedrockClaude3_5SonnetV2,
    Claude4_5Sonnet,
    Gpt4O,
    Gpt4OMini,
    Gpt4_1,
    Gpt4_1Mini,
    Gpt4_1Nano,
}

sealed class ModelNameConverter : JsonConverter<ModelName>
{
    public override ModelName Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AZURE_OPENAI_GPT_4O" => ModelName.AzureOpenAIGpt4O,
            "AZURE_OPENAI_GPT_4O_MINI" => ModelName.AzureOpenAIGpt4OMini,
            "AZURE_OPENAI_GPT_4_1" => ModelName.AzureOpenAIGpt4_1,
            "AZURE_OPENAI_GPT_4_1_MINI" => ModelName.AzureOpenAIGpt4_1Mini,
            "AZURE_OPENAI_GPT_4_1_NANO" => ModelName.AzureOpenAIGpt4_1Nano,
            "BEDROCK_CLAUDE_3_5_SONNET_V1" => ModelName.BedrockClaude3_5SonnetV1,
            "BEDROCK_CLAUDE_3_5_SONNET_V2" => ModelName.BedrockClaude3_5SonnetV2,
            "CLAUDE_4_5_SONNET" => ModelName.Claude4_5Sonnet,
            "GPT_4O" => ModelName.Gpt4O,
            "GPT_4O_MINI" => ModelName.Gpt4OMini,
            "GPT_4_1" => ModelName.Gpt4_1,
            "GPT_4_1_MINI" => ModelName.Gpt4_1Mini,
            "GPT_4_1_NANO" => ModelName.Gpt4_1Nano,
            _ => (ModelName)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ModelName value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ModelName.AzureOpenAIGpt4O => "AZURE_OPENAI_GPT_4O",
                ModelName.AzureOpenAIGpt4OMini => "AZURE_OPENAI_GPT_4O_MINI",
                ModelName.AzureOpenAIGpt4_1 => "AZURE_OPENAI_GPT_4_1",
                ModelName.AzureOpenAIGpt4_1Mini => "AZURE_OPENAI_GPT_4_1_MINI",
                ModelName.AzureOpenAIGpt4_1Nano => "AZURE_OPENAI_GPT_4_1_NANO",
                ModelName.BedrockClaude3_5SonnetV1 => "BEDROCK_CLAUDE_3_5_SONNET_V1",
                ModelName.BedrockClaude3_5SonnetV2 => "BEDROCK_CLAUDE_3_5_SONNET_V2",
                ModelName.Claude4_5Sonnet => "CLAUDE_4_5_SONNET",
                ModelName.Gpt4O => "GPT_4O",
                ModelName.Gpt4OMini => "GPT_4O_MINI",
                ModelName.Gpt4_1 => "GPT_4_1",
                ModelName.Gpt4_1Mini => "GPT_4_1_MINI",
                ModelName.Gpt4_1Nano => "GPT_4_1_NANO",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
