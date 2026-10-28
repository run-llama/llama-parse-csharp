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
[JsonConverter(typeof(JsonModelConverter<PipelineListResponse, PipelineListResponseFromRaw>))]
public sealed record class PipelineListResponse : JsonModel
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
    public required PipelineListResponseEmbeddingConfig? EmbeddingConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PipelineListResponseEmbeddingConfig>(
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
    public PipelineListResponseConfigHash? ConfigHash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PipelineListResponseConfigHash>("config_hash");
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
    public PipelineListResponseEmbeddingModelConfig? EmbeddingModelConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PipelineListResponseEmbeddingModelConfig>(
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
    public ApiEnum<string, PipelineListResponseStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PipelineListResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Configuration for the transformation.
    /// </summary>
    public PipelineListResponseTransformConfig? TransformConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PipelineListResponseTransformConfig>(
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

    public PipelineListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PipelineListResponse(PipelineListResponse pipelineListResponse)
        : base(pipelineListResponse) { }
#pragma warning restore CS8618

    public PipelineListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PipelineListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PipelineListResponseFromRaw.FromRawUnchecked"/>
    public static PipelineListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PipelineListResponseFromRaw : IFromRawJson<PipelineListResponse>
{
    /// <inheritdoc/>
    public PipelineListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PipelineListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Embedding configuration, or null when unavailable for a legacy pipeline.
/// </summary>
[JsonConverter(typeof(PipelineListResponseEmbeddingConfigConverter))]
public record class PipelineListResponseEmbeddingConfig : ModelBase
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

    public PipelineListResponseEmbeddingConfig(
        AzureOpenAIEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListResponseEmbeddingConfig(
        BedrockEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListResponseEmbeddingConfig(
        CohereEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListResponseEmbeddingConfig(
        GeminiEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListResponseEmbeddingConfig(
        HuggingFaceInferenceApiEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListResponseEmbeddingConfig(
        PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListResponseEmbeddingConfig(
        OpenAIEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListResponseEmbeddingConfig(
        VertexAIEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListResponseEmbeddingConfig(JsonElement element)
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
    /// type <see cref="PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickManagedOpenAIEmbedding(out var value)) {
    ///     // `value` is of type `PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickManagedOpenAIEmbedding(
        [NotNullWhen(true)] out PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding? value
    )
    {
        value = this.Value as PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding;
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
    ///     (PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding value) =&gt; {...},
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
        System::Action<PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding> managedOpenAIEmbedding,
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
            case PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding value:
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
                    "Data did not match any variant of PipelineListResponseEmbeddingConfig"
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
    ///     (PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding value) =&gt; {...},
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
            PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding,
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
            PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding value =>
                managedOpenAIEmbedding(value),
            OpenAIEmbeddingConfig value => openai(value),
            VertexAIEmbeddingConfig value => vertexAI(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PipelineListResponseEmbeddingConfig"
            ),
        };
    }

    public static implicit operator PipelineListResponseEmbeddingConfig(
        AzureOpenAIEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListResponseEmbeddingConfig(
        BedrockEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListResponseEmbeddingConfig(
        CohereEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListResponseEmbeddingConfig(
        GeminiEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListResponseEmbeddingConfig(
        HuggingFaceInferenceApiEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListResponseEmbeddingConfig(
        PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding value
    ) => new(value);

    public static implicit operator PipelineListResponseEmbeddingConfig(
        OpenAIEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListResponseEmbeddingConfig(
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
                "Data did not match any variant of PipelineListResponseEmbeddingConfig"
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

    public virtual bool Equals(PipelineListResponseEmbeddingConfig? other) =>
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
            PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding _ => 5,
            OpenAIEmbeddingConfig _ => 6,
            VertexAIEmbeddingConfig _ => 7,
            _ => -1,
        };
    }
}

sealed class PipelineListResponseEmbeddingConfigConverter
    : JsonConverter<PipelineListResponseEmbeddingConfig?>
{
    public override PipelineListResponseEmbeddingConfig? Read(
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
                        JsonSerializer.Deserialize<PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding>(
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
                return new PipelineListResponseEmbeddingConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PipelineListResponseEmbeddingConfig? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding,
        PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingFromRaw
    >)
)]
public sealed record class PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding : JsonModel
{
    /// <summary>
    /// Configuration for the Managed OpenAI embedding model.
    /// </summary>
    public PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponent? Component
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponent>(
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
    public ApiEnum<string, PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingType>
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

    public PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding(
        PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding pipelineListResponseEmbeddingConfigManagedOpenAIEmbedding
    )
        : base(pipelineListResponseEmbeddingConfigManagedOpenAIEmbedding) { }
#pragma warning restore CS8618

    public PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingFromRaw.FromRawUnchecked"/>
    public static PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingFromRaw
    : IFromRawJson<PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding>
{
    /// <inheritdoc/>
    public PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PipelineListResponseEmbeddingConfigManagedOpenAIEmbedding.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for the Managed OpenAI embedding model.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponent,
        PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponentFromRaw
    >)
)]
public sealed record class PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponent
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
        PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponentModelName
    >? ModelName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponentModelName
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

    public PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponent(
        PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponent pipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponent
    )
        : base(pipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponent) { }
#pragma warning restore CS8618

    public PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponent(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponentFromRaw.FromRawUnchecked"/>
    public static PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponentFromRaw
    : IFromRawJson<PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponent>
{
    /// <inheritdoc/>
    public PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponent.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The name of the OpenAI embedding model.
/// </summary>
[JsonConverter(
    typeof(PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponentModelNameConverter)
)]
public enum PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponentModelName
{
    OpenAITextEmbedding3Small,
}

sealed class PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponentModelNameConverter
    : JsonConverter<PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponentModelName>
{
    public override PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponentModelName Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "openai-text-embedding-3-small" =>
                PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,
            _ => (PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponentModelName)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponentModelName value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small =>
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
[JsonConverter(typeof(PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingTypeConverter))]
public enum PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingType
{
    ManagedOpenAIEmbedding,
}

sealed class PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingTypeConverter
    : JsonConverter<PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingType>
{
    public override PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MANAGED_OPENAI_EMBEDDING" =>
                PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingType.ManagedOpenAIEmbedding,
            _ => (PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PipelineListResponseEmbeddingConfigManagedOpenAIEmbeddingType.ManagedOpenAIEmbedding =>
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
    typeof(JsonModelConverter<
        PipelineListResponseConfigHash,
        PipelineListResponseConfigHashFromRaw
    >)
)]
public sealed record class PipelineListResponseConfigHash : JsonModel
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

    public PipelineListResponseConfigHash() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PipelineListResponseConfigHash(
        PipelineListResponseConfigHash pipelineListResponseConfigHash
    )
        : base(pipelineListResponseConfigHash) { }
#pragma warning restore CS8618

    public PipelineListResponseConfigHash(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PipelineListResponseConfigHash(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PipelineListResponseConfigHashFromRaw.FromRawUnchecked"/>
    public static PipelineListResponseConfigHash FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PipelineListResponseConfigHashFromRaw : IFromRawJson<PipelineListResponseConfigHash>
{
    /// <inheritdoc/>
    public PipelineListResponseConfigHash FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PipelineListResponseConfigHash.FromRawUnchecked(rawData);
}

/// <summary>
/// Schema for an embedding model config.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PipelineListResponseEmbeddingModelConfig,
        PipelineListResponseEmbeddingModelConfigFromRaw
    >)
)]
public sealed record class PipelineListResponseEmbeddingModelConfig : JsonModel
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
    public required PipelineListResponseEmbeddingModelConfigEmbeddingConfig EmbeddingConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PipelineListResponseEmbeddingModelConfigEmbeddingConfig>(
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

    public PipelineListResponseEmbeddingModelConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PipelineListResponseEmbeddingModelConfig(
        PipelineListResponseEmbeddingModelConfig pipelineListResponseEmbeddingModelConfig
    )
        : base(pipelineListResponseEmbeddingModelConfig) { }
#pragma warning restore CS8618

    public PipelineListResponseEmbeddingModelConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PipelineListResponseEmbeddingModelConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PipelineListResponseEmbeddingModelConfigFromRaw.FromRawUnchecked"/>
    public static PipelineListResponseEmbeddingModelConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PipelineListResponseEmbeddingModelConfigFromRaw
    : IFromRawJson<PipelineListResponseEmbeddingModelConfig>
{
    /// <inheritdoc/>
    public PipelineListResponseEmbeddingModelConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PipelineListResponseEmbeddingModelConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The embedding configuration for the embedding model config.
/// </summary>
[JsonConverter(typeof(PipelineListResponseEmbeddingModelConfigEmbeddingConfigConverter))]
public record class PipelineListResponseEmbeddingModelConfigEmbeddingConfig : ModelBase
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

    public PipelineListResponseEmbeddingModelConfigEmbeddingConfig(
        AzureOpenAIEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListResponseEmbeddingModelConfigEmbeddingConfig(
        BedrockEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListResponseEmbeddingModelConfigEmbeddingConfig(
        CohereEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListResponseEmbeddingModelConfigEmbeddingConfig(
        GeminiEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListResponseEmbeddingModelConfigEmbeddingConfig(
        HuggingFaceInferenceApiEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListResponseEmbeddingModelConfigEmbeddingConfig(
        OpenAIEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListResponseEmbeddingModelConfigEmbeddingConfig(
        VertexAIEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListResponseEmbeddingModelConfigEmbeddingConfig(JsonElement element)
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
                    "Data did not match any variant of PipelineListResponseEmbeddingModelConfigEmbeddingConfig"
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
                "Data did not match any variant of PipelineListResponseEmbeddingModelConfigEmbeddingConfig"
            ),
        };
    }

    public static implicit operator PipelineListResponseEmbeddingModelConfigEmbeddingConfig(
        AzureOpenAIEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListResponseEmbeddingModelConfigEmbeddingConfig(
        BedrockEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListResponseEmbeddingModelConfigEmbeddingConfig(
        CohereEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListResponseEmbeddingModelConfigEmbeddingConfig(
        GeminiEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListResponseEmbeddingModelConfigEmbeddingConfig(
        HuggingFaceInferenceApiEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListResponseEmbeddingModelConfigEmbeddingConfig(
        OpenAIEmbeddingConfig value
    ) => new(value);

    public static implicit operator PipelineListResponseEmbeddingModelConfigEmbeddingConfig(
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
                "Data did not match any variant of PipelineListResponseEmbeddingModelConfigEmbeddingConfig"
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

    public virtual bool Equals(PipelineListResponseEmbeddingModelConfigEmbeddingConfig? other) =>
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

sealed class PipelineListResponseEmbeddingModelConfigEmbeddingConfigConverter
    : JsonConverter<PipelineListResponseEmbeddingModelConfigEmbeddingConfig>
{
    public override PipelineListResponseEmbeddingModelConfigEmbeddingConfig? Read(
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
                return new PipelineListResponseEmbeddingModelConfigEmbeddingConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PipelineListResponseEmbeddingModelConfigEmbeddingConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Status of the pipeline.
/// </summary>
[JsonConverter(typeof(PipelineListResponseStatusConverter))]
public enum PipelineListResponseStatus
{
    Created,
    Deleting,
}

sealed class PipelineListResponseStatusConverter : JsonConverter<PipelineListResponseStatus>
{
    public override PipelineListResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CREATED" => PipelineListResponseStatus.Created,
            "DELETING" => PipelineListResponseStatus.Deleting,
            _ => (PipelineListResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PipelineListResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PipelineListResponseStatus.Created => "CREATED",
                PipelineListResponseStatus.Deleting => "DELETING",
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
[JsonConverter(typeof(PipelineListResponseTransformConfigConverter))]
public record class PipelineListResponseTransformConfig : ModelBase
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

    public PipelineListResponseTransformConfig(
        AutoTransformConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListResponseTransformConfig(
        AdvancedModeTransformConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PipelineListResponseTransformConfig(JsonElement element)
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
                    "Data did not match any variant of PipelineListResponseTransformConfig"
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
                "Data did not match any variant of PipelineListResponseTransformConfig"
            ),
        };
    }

    public static implicit operator PipelineListResponseTransformConfig(
        AutoTransformConfig value
    ) => new(value);

    public static implicit operator PipelineListResponseTransformConfig(
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
                "Data did not match any variant of PipelineListResponseTransformConfig"
            );
        }
        this.Switch((auto) => auto.Validate(), (advancedMode) => advancedMode.Validate());
    }

    public virtual bool Equals(PipelineListResponseTransformConfig? other) =>
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

sealed class PipelineListResponseTransformConfigConverter
    : JsonConverter<PipelineListResponseTransformConfig>
{
    public override PipelineListResponseTransformConfig? Read(
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
        PipelineListResponseTransformConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
