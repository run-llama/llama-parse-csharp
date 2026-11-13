using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.DataSinks;
using System = System;

namespace LlamaCloud.Models.Pipelines;

/// <summary>
/// A pipeline returned by the legacy list endpoint.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PipelineListItem, PipelineListItemFromRaw>))]
public sealed record class PipelineListItem : JsonModel
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Embedding configuration, or null when unavailable for a legacy pipeline.
    /// </summary>
    public required PipelineListItemEmbeddingConfig? EmbeddingConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PipelineListItemEmbeddingConfig>(
                "embedding_config"
            );
        }
        init { this._rawData.Set("embedding_config", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required string ProjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("project_id");
        }
        init { this._rawData.Set("project_id", value); }
    }

    /// <summary>
    /// Hashes for the configuration of a pipeline.
    /// </summary>
    public PipelineListItemConfigHash? ConfigHash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PipelineListItemConfigHash>("config_hash");
        }
        init { this._rawData.Set("config_hash", value); }
    }

    /// <summary>
    /// Creation datetime
    /// </summary>
    public System::DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Schema for a data sink.
    /// </summary>
    public DataSink? DataSink
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataSink>("data_sink");
        }
        init { this._rawData.Set("data_sink", value); }
    }

    /// <summary>
    /// Schema for an embedding model config.
    /// </summary>
    public PipelineListItemEmbeddingModelConfig? EmbeddingModelConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PipelineListItemEmbeddingModelConfig>(
                "embedding_model_config"
            );
        }
        init { this._rawData.Set("embedding_model_config", value); }
    }

    /// <summary>
    /// The ID of the EmbeddingModelConfig this pipeline is using.
    /// </summary>
    public string? EmbeddingModelConfigID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("embedding_model_config_id");
        }
        init { this._rawData.Set("embedding_model_config_id", value); }
    }

    /// <summary>
    /// Settings that can be configured for how to use LlamaParse to parse files within
    /// a LlamaCloud pipeline.
    /// </summary>
    public LlamaParseParameters? LlamaParseParameters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LlamaParseParameters>("llama_parse_parameters");
        }
        init { this._rawData.Set("llama_parse_parameters", value); }
    }

    /// <summary>
    /// The ID of the ManagedPipeline this playground pipeline is linked to.
    /// </summary>
    public string? ManagedPipelineID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("managed_pipeline_id");
        }
        init { this._rawData.Set("managed_pipeline_id", value); }
    }

    /// <summary>
    /// Metadata configuration for the pipeline.
    /// </summary>
    public PipelineMetadataConfig? MetadataConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PipelineMetadataConfig>("metadata_config");
        }
        init { this._rawData.Set("metadata_config", value); }
    }

    /// <summary>
    /// Type of pipeline. Either PLAYGROUND or MANAGED.
    /// </summary>
    public ApiEnum<string, PipelinePipelineType>? PipelineType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PipelinePipelineType>>(
                "pipeline_type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pipeline_type", value);
        }
    }

    /// <summary>
    /// Preset retrieval parameters for the pipeline.
    /// </summary>
    public PresetRetrievalParams? PresetRetrievalParameters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PresetRetrievalParams>(
                "preset_retrieval_parameters"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("preset_retrieval_parameters", value);
        }
    }

    /// <summary>
    /// Configuration for sparse embedding models used in hybrid search.
    ///
    /// <para>This allows users to choose between Splade and BM25 models for sparse
    /// retrieval in managed data sinks.</para>
    /// </summary>
    public SparseModelConfig? SparseModelConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SparseModelConfig>("sparse_model_config");
        }
        init { this._rawData.Set("sparse_model_config", value); }
    }

    /// <summary>
    /// Status of the pipeline.
    /// </summary>
    public ApiEnum<string, PipelineListItemStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PipelineListItemStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Configuration for the transformation.
    /// </summary>
    public PipelineListItemTransformConfig? TransformConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PipelineListItemTransformConfig>(
                "transform_config"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transform_config", value);
        }
    }

    /// <summary>
    /// Update datetime
    /// </summary>
    public System::DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.EmbeddingConfig?.Validate();
        _ = this.Name;
        _ = this.ProjectID;
        this.ConfigHash?.Validate();
        _ = this.CreatedAt;
        this.DataSink?.Validate();
        this.EmbeddingModelConfig?.Validate();
        _ = this.EmbeddingModelConfigID;
        this.LlamaParseParameters?.Validate();
        _ = this.ManagedPipelineID;
        this.MetadataConfig?.Validate();
        this.PipelineType?.Validate();
        this.PresetRetrievalParameters?.Validate();
        this.SparseModelConfig?.Validate();
        this.Status?.Validate();
        this.TransformConfig?.Validate();
        _ = this.UpdatedAt;
    }

    public PipelineListItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PipelineListItem(PipelineListItem pipelineListItem)
        : base(pipelineListItem) { }
#pragma warning restore CS8618

    public PipelineListItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PipelineListItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PipelineListItemFromRaw.FromRawUnchecked"/>
    public static PipelineListItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PipelineListItemFromRaw : IFromRawJson<PipelineListItem>
{
    /// <inheritdoc/>
    public PipelineListItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PipelineListItem.FromRawUnchecked(rawData);
}

/// <summary>
/// Embedding configuration, or null when unavailable for a legacy pipeline.
/// </summary>
[JsonConverter(typeof(PipelineListItemEmbeddingConfigConverter))]
public record class PipelineListItemEmbeddingConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public PipelineListItemEmbeddingConfig(
        AzureOpenAIEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListItemEmbeddingConfig(
        BedrockEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListItemEmbeddingConfig(CohereEmbeddingConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListItemEmbeddingConfig(GeminiEmbeddingConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListItemEmbeddingConfig(
        HuggingFaceInferenceApiEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListItemEmbeddingConfig(
        PipelineListItemEmbeddingConfigManagedOpenAIEmbedding value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListItemEmbeddingConfig(OpenAIEmbeddingConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListItemEmbeddingConfig(
        VertexAIEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListItemEmbeddingConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AzureOpenAIEmbeddingConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAzureOpenAI(out var value)) {
    ///     // `value` is of type `AzureOpenAIEmbeddingConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAzureOpenAI([NotNullWhen(true)] out AzureOpenAIEmbeddingConfig? value)
    {
        value = this.Value as AzureOpenAIEmbeddingConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BedrockEmbeddingConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBedrock(out var value)) {
    ///     // `value` is of type `BedrockEmbeddingConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBedrock([NotNullWhen(true)] out BedrockEmbeddingConfig? value)
    {
        value = this.Value as BedrockEmbeddingConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CohereEmbeddingConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCohere(out var value)) {
    ///     // `value` is of type `CohereEmbeddingConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCohere([NotNullWhen(true)] out CohereEmbeddingConfig? value)
    {
        value = this.Value as CohereEmbeddingConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GeminiEmbeddingConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGemini(out var value)) {
    ///     // `value` is of type `GeminiEmbeddingConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGemini([NotNullWhen(true)] out GeminiEmbeddingConfig? value)
    {
        value = this.Value as GeminiEmbeddingConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="HuggingFaceInferenceApiEmbeddingConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickHuggingFaceInferenceApi(out var value)) {
    ///     // `value` is of type `HuggingFaceInferenceApiEmbeddingConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickHuggingFaceInferenceApi(
        [NotNullWhen(true)] out HuggingFaceInferenceApiEmbeddingConfig? value
    )
    {
        value = this.Value as HuggingFaceInferenceApiEmbeddingConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PipelineListItemEmbeddingConfigManagedOpenAIEmbedding"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickManagedOpenAIEmbedding(out var value)) {
    ///     // `value` is of type `PipelineListItemEmbeddingConfigManagedOpenAIEmbedding`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickManagedOpenAIEmbedding(
        [NotNullWhen(true)] out PipelineListItemEmbeddingConfigManagedOpenAIEmbedding? value
    )
    {
        value = this.Value as PipelineListItemEmbeddingConfigManagedOpenAIEmbedding;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OpenAIEmbeddingConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOpenAI(out var value)) {
    ///     // `value` is of type `OpenAIEmbeddingConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOpenAI([NotNullWhen(true)] out OpenAIEmbeddingConfig? value)
    {
        value = this.Value as OpenAIEmbeddingConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VertexAIEmbeddingConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVertexAI(out var value)) {
    ///     // `value` is of type `VertexAIEmbeddingConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVertexAI([NotNullWhen(true)] out VertexAIEmbeddingConfig? value)
    {
        value = this.Value as VertexAIEmbeddingConfig;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (AzureOpenAIEmbeddingConfig value) =&gt; {...},
    ///     (BedrockEmbeddingConfig value) =&gt; {...},
    ///     (CohereEmbeddingConfig value) =&gt; {...},
    ///     (GeminiEmbeddingConfig value) =&gt; {...},
    ///     (HuggingFaceInferenceApiEmbeddingConfig value) =&gt; {...},
    ///     (PipelineListItemEmbeddingConfigManagedOpenAIEmbedding value) =&gt; {...},
    ///     (OpenAIEmbeddingConfig value) =&gt; {...},
    ///     (VertexAIEmbeddingConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<AzureOpenAIEmbeddingConfig> azureOpenAI,
        System::Action<BedrockEmbeddingConfig> bedrock,
        System::Action<CohereEmbeddingConfig> cohere,
        System::Action<GeminiEmbeddingConfig> gemini,
        System::Action<HuggingFaceInferenceApiEmbeddingConfig> huggingFaceInferenceApi,
        System::Action<PipelineListItemEmbeddingConfigManagedOpenAIEmbedding> managedOpenAIEmbedding,
        System::Action<OpenAIEmbeddingConfig> openai,
        System::Action<VertexAIEmbeddingConfig> vertexAI
    )
    {
        switch (this.Value)
        {
            case AzureOpenAIEmbeddingConfig value:
                azureOpenAI(value);
                break;
            case BedrockEmbeddingConfig value:
                bedrock(value);
                break;
            case CohereEmbeddingConfig value:
                cohere(value);
                break;
            case GeminiEmbeddingConfig value:
                gemini(value);
                break;
            case HuggingFaceInferenceApiEmbeddingConfig value:
                huggingFaceInferenceApi(value);
                break;
            case PipelineListItemEmbeddingConfigManagedOpenAIEmbedding value:
                managedOpenAIEmbedding(value);
                break;
            case OpenAIEmbeddingConfig value:
                openai(value);
                break;
            case VertexAIEmbeddingConfig value:
                vertexAI(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PipelineListItemEmbeddingConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (AzureOpenAIEmbeddingConfig value) =&gt; {...},
    ///     (BedrockEmbeddingConfig value) =&gt; {...},
    ///     (CohereEmbeddingConfig value) =&gt; {...},
    ///     (GeminiEmbeddingConfig value) =&gt; {...},
    ///     (HuggingFaceInferenceApiEmbeddingConfig value) =&gt; {...},
    ///     (PipelineListItemEmbeddingConfigManagedOpenAIEmbedding value) =&gt; {...},
    ///     (OpenAIEmbeddingConfig value) =&gt; {...},
    ///     (VertexAIEmbeddingConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<AzureOpenAIEmbeddingConfig, T> azureOpenAI,
        System::Func<BedrockEmbeddingConfig, T> bedrock,
        System::Func<CohereEmbeddingConfig, T> cohere,
        System::Func<GeminiEmbeddingConfig, T> gemini,
        System::Func<HuggingFaceInferenceApiEmbeddingConfig, T> huggingFaceInferenceApi,
        System::Func<
            PipelineListItemEmbeddingConfigManagedOpenAIEmbedding,
            T
        > managedOpenAIEmbedding,
        System::Func<OpenAIEmbeddingConfig, T> openai,
        System::Func<VertexAIEmbeddingConfig, T> vertexAI
    )
    {
        return this.Value switch
        {
            AzureOpenAIEmbeddingConfig value => azureOpenAI(value),
            BedrockEmbeddingConfig value => bedrock(value),
            CohereEmbeddingConfig value => cohere(value),
            GeminiEmbeddingConfig value => gemini(value),
            HuggingFaceInferenceApiEmbeddingConfig value => huggingFaceInferenceApi(value),
            PipelineListItemEmbeddingConfigManagedOpenAIEmbedding value => managedOpenAIEmbedding(
                value
            ),
            OpenAIEmbeddingConfig value => openai(value),
            VertexAIEmbeddingConfig value => vertexAI(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PipelineListItemEmbeddingConfig"
            ),
        };
    }

    public static implicit operator PipelineListItemEmbeddingConfig(
        AzureOpenAIEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListItemEmbeddingConfig(BedrockEmbeddingConfig value) =>
        new(value);

    public static implicit operator PipelineListItemEmbeddingConfig(CohereEmbeddingConfig value) =>
        new(value);

    public static implicit operator PipelineListItemEmbeddingConfig(GeminiEmbeddingConfig value) =>
        new(value);

    public static implicit operator PipelineListItemEmbeddingConfig(
        HuggingFaceInferenceApiEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListItemEmbeddingConfig(
        PipelineListItemEmbeddingConfigManagedOpenAIEmbedding value
    ) => new(value);

    public static implicit operator PipelineListItemEmbeddingConfig(OpenAIEmbeddingConfig value) =>
        new(value);

    public static implicit operator PipelineListItemEmbeddingConfig(
        VertexAIEmbeddingConfig value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PipelineListItemEmbeddingConfig"
            );
        }
        this.Switch(
            (azureOpenAI) => azureOpenAI.Validate(),
            (bedrock) => bedrock.Validate(),
            (cohere) => cohere.Validate(),
            (gemini) => gemini.Validate(),
            (huggingFaceInferenceApi) => huggingFaceInferenceApi.Validate(),
            (managedOpenAIEmbedding) => managedOpenAIEmbedding.Validate(),
            (openai) => openai.Validate(),
            (vertexAI) => vertexAI.Validate()
        );
    }

    public virtual bool Equals(PipelineListItemEmbeddingConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            AzureOpenAIEmbeddingConfig _ => 0,
            BedrockEmbeddingConfig _ => 1,
            CohereEmbeddingConfig _ => 2,
            GeminiEmbeddingConfig _ => 3,
            HuggingFaceInferenceApiEmbeddingConfig _ => 4,
            PipelineListItemEmbeddingConfigManagedOpenAIEmbedding _ => 5,
            OpenAIEmbeddingConfig _ => 6,
            VertexAIEmbeddingConfig _ => 7,
            _ => -1,
        };
    }
}

sealed class PipelineListItemEmbeddingConfigConverter
    : JsonConverter<PipelineListItemEmbeddingConfig?>
{
    public override PipelineListItemEmbeddingConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "AZURE_EMBEDDING":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AzureOpenAIEmbeddingConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "BEDROCK_EMBEDDING":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BedrockEmbeddingConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "COHERE_EMBEDDING":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CohereEmbeddingConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "GEMINI_EMBEDDING":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<GeminiEmbeddingConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "HUGGINGFACE_API_EMBEDDING":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<HuggingFaceInferenceApiEmbeddingConfig>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "MANAGED_OPENAI_EMBEDDING":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PipelineListItemEmbeddingConfigManagedOpenAIEmbedding>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "OPENAI_EMBEDDING":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<OpenAIEmbeddingConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "VERTEXAI_EMBEDDING":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<VertexAIEmbeddingConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new PipelineListItemEmbeddingConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PipelineListItemEmbeddingConfig? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        PipelineListItemEmbeddingConfigManagedOpenAIEmbedding,
        PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingFromRaw
    >)
)]
public sealed record class PipelineListItemEmbeddingConfigManagedOpenAIEmbedding : JsonModel
{
    /// <summary>
    /// Configuration for the Managed OpenAI embedding model.
    /// </summary>
    public PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponent? Component
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponent>(
                "component"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("component", value);
        }
    }

    /// <summary>
    /// Type of the embedding model.
    /// </summary>
    public ApiEnum<string, PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingType>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Component?.Validate();
        this.Type?.Validate();
    }

    public PipelineListItemEmbeddingConfigManagedOpenAIEmbedding() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PipelineListItemEmbeddingConfigManagedOpenAIEmbedding(
        PipelineListItemEmbeddingConfigManagedOpenAIEmbedding pipelineListItemEmbeddingConfigManagedOpenAIEmbedding
    )
        : base(pipelineListItemEmbeddingConfigManagedOpenAIEmbedding) { }
#pragma warning restore CS8618

    public PipelineListItemEmbeddingConfigManagedOpenAIEmbedding(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PipelineListItemEmbeddingConfigManagedOpenAIEmbedding(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingFromRaw.FromRawUnchecked"/>
    public static PipelineListItemEmbeddingConfigManagedOpenAIEmbedding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingFromRaw
    : IFromRawJson<PipelineListItemEmbeddingConfigManagedOpenAIEmbedding>
{
    /// <inheritdoc/>
    public PipelineListItemEmbeddingConfigManagedOpenAIEmbedding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PipelineListItemEmbeddingConfigManagedOpenAIEmbedding.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for the Managed OpenAI embedding model.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponent,
        PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponentFromRaw
    >)
)]
public sealed record class PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponent
    : JsonModel
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
    /// The batch size for embedding calls.
    /// </summary>
    public long? EmbedBatchSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("embed_batch_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("embed_batch_size", value);
        }
    }

    /// <summary>
    /// The name of the OpenAI embedding model.
    /// </summary>
    public ApiEnum<
        string,
        PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponentModelName
    >? ModelName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponentModelName
                >
            >("model_name");
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
    /// The number of workers to use for async embedding calls.
    /// </summary>
    public long? NumWorkers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("num_workers");
        }
        init { this._rawData.Set("num_workers", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClassName;
        _ = this.EmbedBatchSize;
        this.ModelName?.Validate();
        _ = this.NumWorkers;
    }

    public PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponent(
        PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponent pipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponent
    )
        : base(pipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponent) { }
#pragma warning restore CS8618

    public PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponent(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponentFromRaw.FromRawUnchecked"/>
    public static PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponentFromRaw
    : IFromRawJson<PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponent>
{
    /// <inheritdoc/>
    public PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponent.FromRawUnchecked(rawData);
}

/// <summary>
/// The name of the OpenAI embedding model.
/// </summary>
[JsonConverter(
    typeof(PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponentModelNameConverter)
)]
public enum PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponentModelName
{
    OpenAITextEmbedding3Small,
}

sealed class PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponentModelNameConverter
    : JsonConverter<PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponentModelName>
{
    public override PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponentModelName Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "openai-text-embedding-3-small" =>
                PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,
            _ => (PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponentModelName)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponentModelName value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small =>
                    "openai-text-embedding-3-small",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Type of the embedding model.
/// </summary>
[JsonConverter(typeof(PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingTypeConverter))]
public enum PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingType
{
    ManagedOpenAIEmbedding,
}

sealed class PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingTypeConverter
    : JsonConverter<PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingType>
{
    public override PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MANAGED_OPENAI_EMBEDDING" =>
                PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingType.ManagedOpenAIEmbedding,
            _ => (PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PipelineListItemEmbeddingConfigManagedOpenAIEmbeddingType.ManagedOpenAIEmbedding =>
                    "MANAGED_OPENAI_EMBEDDING",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Hashes for the configuration of a pipeline.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PipelineListItemConfigHash, PipelineListItemConfigHashFromRaw>)
)]
public sealed record class PipelineListItemConfigHash : JsonModel
{
    /// <summary>
    /// Hash of the embedding config. Null in API responses.
    /// </summary>
    [System::Obsolete("deprecated")]
    public string? EmbeddingConfigHash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("embedding_config_hash");
        }
        init { this._rawData.Set("embedding_config_hash", value); }
    }

    /// <summary>
    /// Hash of the llama parse parameters. Null in API responses.
    /// </summary>
    [System::Obsolete("deprecated")]
    public string? ParsingConfigHash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parsing_config_hash");
        }
        init { this._rawData.Set("parsing_config_hash", value); }
    }

    /// <summary>
    /// Hash of the transform config.
    /// </summary>
    public string? TransformConfigHash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transform_config_hash");
        }
        init { this._rawData.Set("transform_config_hash", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EmbeddingConfigHash;
        _ = this.ParsingConfigHash;
        _ = this.TransformConfigHash;
    }

    public PipelineListItemConfigHash() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PipelineListItemConfigHash(PipelineListItemConfigHash pipelineListItemConfigHash)
        : base(pipelineListItemConfigHash) { }
#pragma warning restore CS8618

    public PipelineListItemConfigHash(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PipelineListItemConfigHash(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PipelineListItemConfigHashFromRaw.FromRawUnchecked"/>
    public static PipelineListItemConfigHash FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PipelineListItemConfigHashFromRaw : IFromRawJson<PipelineListItemConfigHash>
{
    /// <inheritdoc/>
    public PipelineListItemConfigHash FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PipelineListItemConfigHash.FromRawUnchecked(rawData);
}

/// <summary>
/// Schema for an embedding model config.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PipelineListItemEmbeddingModelConfig,
        PipelineListItemEmbeddingModelConfigFromRaw
    >)
)]
public sealed record class PipelineListItemEmbeddingModelConfig : JsonModel
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The embedding configuration for the embedding model config.
    /// </summary>
    public required PipelineListItemEmbeddingModelConfigEmbeddingConfig EmbeddingConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PipelineListItemEmbeddingModelConfigEmbeddingConfig>(
                "embedding_config"
            );
        }
        init { this._rawData.Set("embedding_config", value); }
    }

    /// <summary>
    /// The name of the embedding model config.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required string ProjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("project_id");
        }
        init { this._rawData.Set("project_id", value); }
    }

    /// <summary>
    /// Creation datetime
    /// </summary>
    public System::DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Update datetime
    /// </summary>
    public System::DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.EmbeddingConfig.Validate();
        _ = this.Name;
        _ = this.ProjectID;
        _ = this.CreatedAt;
        _ = this.UpdatedAt;
    }

    public PipelineListItemEmbeddingModelConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PipelineListItemEmbeddingModelConfig(
        PipelineListItemEmbeddingModelConfig pipelineListItemEmbeddingModelConfig
    )
        : base(pipelineListItemEmbeddingModelConfig) { }
#pragma warning restore CS8618

    public PipelineListItemEmbeddingModelConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PipelineListItemEmbeddingModelConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PipelineListItemEmbeddingModelConfigFromRaw.FromRawUnchecked"/>
    public static PipelineListItemEmbeddingModelConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PipelineListItemEmbeddingModelConfigFromRaw
    : IFromRawJson<PipelineListItemEmbeddingModelConfig>
{
    /// <inheritdoc/>
    public PipelineListItemEmbeddingModelConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PipelineListItemEmbeddingModelConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The embedding configuration for the embedding model config.
/// </summary>
[JsonConverter(typeof(PipelineListItemEmbeddingModelConfigEmbeddingConfigConverter))]
public record class PipelineListItemEmbeddingModelConfigEmbeddingConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public PipelineListItemEmbeddingModelConfigEmbeddingConfig(
        AzureOpenAIEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListItemEmbeddingModelConfigEmbeddingConfig(
        BedrockEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListItemEmbeddingModelConfigEmbeddingConfig(
        CohereEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListItemEmbeddingModelConfigEmbeddingConfig(
        GeminiEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListItemEmbeddingModelConfigEmbeddingConfig(
        HuggingFaceInferenceApiEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListItemEmbeddingModelConfigEmbeddingConfig(
        OpenAIEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListItemEmbeddingModelConfigEmbeddingConfig(
        VertexAIEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListItemEmbeddingModelConfigEmbeddingConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AzureOpenAIEmbeddingConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAzureOpenAI(out var value)) {
    ///     // `value` is of type `AzureOpenAIEmbeddingConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAzureOpenAI([NotNullWhen(true)] out AzureOpenAIEmbeddingConfig? value)
    {
        value = this.Value as AzureOpenAIEmbeddingConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BedrockEmbeddingConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBedrock(out var value)) {
    ///     // `value` is of type `BedrockEmbeddingConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBedrock([NotNullWhen(true)] out BedrockEmbeddingConfig? value)
    {
        value = this.Value as BedrockEmbeddingConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CohereEmbeddingConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCohere(out var value)) {
    ///     // `value` is of type `CohereEmbeddingConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCohere([NotNullWhen(true)] out CohereEmbeddingConfig? value)
    {
        value = this.Value as CohereEmbeddingConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GeminiEmbeddingConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGemini(out var value)) {
    ///     // `value` is of type `GeminiEmbeddingConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGemini([NotNullWhen(true)] out GeminiEmbeddingConfig? value)
    {
        value = this.Value as GeminiEmbeddingConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="HuggingFaceInferenceApiEmbeddingConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickHuggingFaceInferenceApi(out var value)) {
    ///     // `value` is of type `HuggingFaceInferenceApiEmbeddingConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickHuggingFaceInferenceApi(
        [NotNullWhen(true)] out HuggingFaceInferenceApiEmbeddingConfig? value
    )
    {
        value = this.Value as HuggingFaceInferenceApiEmbeddingConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OpenAIEmbeddingConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOpenAI(out var value)) {
    ///     // `value` is of type `OpenAIEmbeddingConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOpenAI([NotNullWhen(true)] out OpenAIEmbeddingConfig? value)
    {
        value = this.Value as OpenAIEmbeddingConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VertexAIEmbeddingConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVertexAI(out var value)) {
    ///     // `value` is of type `VertexAIEmbeddingConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVertexAI([NotNullWhen(true)] out VertexAIEmbeddingConfig? value)
    {
        value = this.Value as VertexAIEmbeddingConfig;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (AzureOpenAIEmbeddingConfig value) =&gt; {...},
    ///     (BedrockEmbeddingConfig value) =&gt; {...},
    ///     (CohereEmbeddingConfig value) =&gt; {...},
    ///     (GeminiEmbeddingConfig value) =&gt; {...},
    ///     (HuggingFaceInferenceApiEmbeddingConfig value) =&gt; {...},
    ///     (OpenAIEmbeddingConfig value) =&gt; {...},
    ///     (VertexAIEmbeddingConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<AzureOpenAIEmbeddingConfig> azureOpenAI,
        System::Action<BedrockEmbeddingConfig> bedrock,
        System::Action<CohereEmbeddingConfig> cohere,
        System::Action<GeminiEmbeddingConfig> gemini,
        System::Action<HuggingFaceInferenceApiEmbeddingConfig> huggingFaceInferenceApi,
        System::Action<OpenAIEmbeddingConfig> openai,
        System::Action<VertexAIEmbeddingConfig> vertexAI
    )
    {
        switch (this.Value)
        {
            case AzureOpenAIEmbeddingConfig value:
                azureOpenAI(value);
                break;
            case BedrockEmbeddingConfig value:
                bedrock(value);
                break;
            case CohereEmbeddingConfig value:
                cohere(value);
                break;
            case GeminiEmbeddingConfig value:
                gemini(value);
                break;
            case HuggingFaceInferenceApiEmbeddingConfig value:
                huggingFaceInferenceApi(value);
                break;
            case OpenAIEmbeddingConfig value:
                openai(value);
                break;
            case VertexAIEmbeddingConfig value:
                vertexAI(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PipelineListItemEmbeddingModelConfigEmbeddingConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (AzureOpenAIEmbeddingConfig value) =&gt; {...},
    ///     (BedrockEmbeddingConfig value) =&gt; {...},
    ///     (CohereEmbeddingConfig value) =&gt; {...},
    ///     (GeminiEmbeddingConfig value) =&gt; {...},
    ///     (HuggingFaceInferenceApiEmbeddingConfig value) =&gt; {...},
    ///     (OpenAIEmbeddingConfig value) =&gt; {...},
    ///     (VertexAIEmbeddingConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<AzureOpenAIEmbeddingConfig, T> azureOpenAI,
        System::Func<BedrockEmbeddingConfig, T> bedrock,
        System::Func<CohereEmbeddingConfig, T> cohere,
        System::Func<GeminiEmbeddingConfig, T> gemini,
        System::Func<HuggingFaceInferenceApiEmbeddingConfig, T> huggingFaceInferenceApi,
        System::Func<OpenAIEmbeddingConfig, T> openai,
        System::Func<VertexAIEmbeddingConfig, T> vertexAI
    )
    {
        return this.Value switch
        {
            AzureOpenAIEmbeddingConfig value => azureOpenAI(value),
            BedrockEmbeddingConfig value => bedrock(value),
            CohereEmbeddingConfig value => cohere(value),
            GeminiEmbeddingConfig value => gemini(value),
            HuggingFaceInferenceApiEmbeddingConfig value => huggingFaceInferenceApi(value),
            OpenAIEmbeddingConfig value => openai(value),
            VertexAIEmbeddingConfig value => vertexAI(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PipelineListItemEmbeddingModelConfigEmbeddingConfig"
            ),
        };
    }

    public static implicit operator PipelineListItemEmbeddingModelConfigEmbeddingConfig(
        AzureOpenAIEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListItemEmbeddingModelConfigEmbeddingConfig(
        BedrockEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListItemEmbeddingModelConfigEmbeddingConfig(
        CohereEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListItemEmbeddingModelConfigEmbeddingConfig(
        GeminiEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListItemEmbeddingModelConfigEmbeddingConfig(
        HuggingFaceInferenceApiEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListItemEmbeddingModelConfigEmbeddingConfig(
        OpenAIEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListItemEmbeddingModelConfigEmbeddingConfig(
        VertexAIEmbeddingConfig value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PipelineListItemEmbeddingModelConfigEmbeddingConfig"
            );
        }
        this.Switch(
            (azureOpenAI) => azureOpenAI.Validate(),
            (bedrock) => bedrock.Validate(),
            (cohere) => cohere.Validate(),
            (gemini) => gemini.Validate(),
            (huggingFaceInferenceApi) => huggingFaceInferenceApi.Validate(),
            (openai) => openai.Validate(),
            (vertexAI) => vertexAI.Validate()
        );
    }

    public virtual bool Equals(PipelineListItemEmbeddingModelConfigEmbeddingConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            AzureOpenAIEmbeddingConfig _ => 0,
            BedrockEmbeddingConfig _ => 1,
            CohereEmbeddingConfig _ => 2,
            GeminiEmbeddingConfig _ => 3,
            HuggingFaceInferenceApiEmbeddingConfig _ => 4,
            OpenAIEmbeddingConfig _ => 5,
            VertexAIEmbeddingConfig _ => 6,
            _ => -1,
        };
    }
}

sealed class PipelineListItemEmbeddingModelConfigEmbeddingConfigConverter
    : JsonConverter<PipelineListItemEmbeddingModelConfigEmbeddingConfig>
{
    public override PipelineListItemEmbeddingModelConfigEmbeddingConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "AZURE_EMBEDDING":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AzureOpenAIEmbeddingConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "BEDROCK_EMBEDDING":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BedrockEmbeddingConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "COHERE_EMBEDDING":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CohereEmbeddingConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "GEMINI_EMBEDDING":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<GeminiEmbeddingConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "HUGGINGFACE_API_EMBEDDING":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<HuggingFaceInferenceApiEmbeddingConfig>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "OPENAI_EMBEDDING":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<OpenAIEmbeddingConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "VERTEXAI_EMBEDDING":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<VertexAIEmbeddingConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new PipelineListItemEmbeddingModelConfigEmbeddingConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PipelineListItemEmbeddingModelConfigEmbeddingConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Status of the pipeline.
/// </summary>
[JsonConverter(typeof(PipelineListItemStatusConverter))]
public enum PipelineListItemStatus
{
    Created,
    Deleting,
}

sealed class PipelineListItemStatusConverter : JsonConverter<PipelineListItemStatus>
{
    public override PipelineListItemStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CREATED" => PipelineListItemStatus.Created,
            "DELETING" => PipelineListItemStatus.Deleting,
            _ => (PipelineListItemStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PipelineListItemStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PipelineListItemStatus.Created => "CREATED",
                PipelineListItemStatus.Deleting => "DELETING",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for the transformation.
/// </summary>
[JsonConverter(typeof(PipelineListItemTransformConfigConverter))]
public record class PipelineListItemTransformConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public PipelineListItemTransformConfig(AutoTransformConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListItemTransformConfig(
        AdvancedModeTransformConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListItemTransformConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AutoTransformConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAuto(out var value)) {
    ///     // `value` is of type `AutoTransformConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAuto([NotNullWhen(true)] out AutoTransformConfig? value)
    {
        value = this.Value as AutoTransformConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AdvancedModeTransformConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAdvancedMode(out var value)) {
    ///     // `value` is of type `AdvancedModeTransformConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAdvancedMode([NotNullWhen(true)] out AdvancedModeTransformConfig? value)
    {
        value = this.Value as AdvancedModeTransformConfig;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (AutoTransformConfig value) =&gt; {...},
    ///     (AdvancedModeTransformConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<AutoTransformConfig> auto,
        System::Action<AdvancedModeTransformConfig> advancedMode
    )
    {
        switch (this.Value)
        {
            case AutoTransformConfig value:
                auto(value);
                break;
            case AdvancedModeTransformConfig value:
                advancedMode(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PipelineListItemTransformConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (AutoTransformConfig value) =&gt; {...},
    ///     (AdvancedModeTransformConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<AutoTransformConfig, T> auto,
        System::Func<AdvancedModeTransformConfig, T> advancedMode
    )
    {
        return this.Value switch
        {
            AutoTransformConfig value => auto(value),
            AdvancedModeTransformConfig value => advancedMode(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PipelineListItemTransformConfig"
            ),
        };
    }

    public static implicit operator PipelineListItemTransformConfig(AutoTransformConfig value) =>
        new(value);

    public static implicit operator PipelineListItemTransformConfig(
        AdvancedModeTransformConfig value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PipelineListItemTransformConfig"
            );
        }
        this.Switch((auto) => auto.Validate(), (advancedMode) => advancedMode.Validate());
    }

    public virtual bool Equals(PipelineListItemTransformConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            AutoTransformConfig _ => 0,
            AdvancedModeTransformConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class PipelineListItemTransformConfigConverter
    : JsonConverter<PipelineListItemTransformConfig>
{
    public override PipelineListItemTransformConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<AutoTransformConfig>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AdvancedModeTransformConfig>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PipelineListItemTransformConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
