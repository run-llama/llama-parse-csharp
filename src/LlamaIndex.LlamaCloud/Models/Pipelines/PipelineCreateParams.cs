using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Pipelines;

/// <summary>
/// Create a new managed ingestion pipeline.
///
/// <para>A pipeline connects data sources to a vector store for RAG. After creation,
/// call `POST /pipelines/{id}/sync` to start ingesting documents.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
[System::Obsolete("deprecated")]
public record class PipelineCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    public string? OrganizationID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("organization_id");
        }
        init { this._rawQueryData.Set("organization_id", value); }
    }

    public string? ProjectID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("project_id");
        }
        init { this._rawQueryData.Set("project_id", value); }
    }

    /// <summary>
    /// Schema for creating a data sink.
    /// </summary>
    public DataSinkCreate? DataSink
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<DataSinkCreate>("data_sink");
        }
        init { this._rawBodyData.Set("data_sink", value); }
    }

    /// <summary>
    /// Data sink ID. When provided instead of data_sink, the data sink will be looked
    /// up by ID.
    /// </summary>
    public string? DataSinkID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("data_sink_id");
        }
        init { this._rawBodyData.Set("data_sink_id", value); }
    }

    public EmbeddingConfig? EmbeddingConfig
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<EmbeddingConfig>("embedding_config");
        }
        init { this._rawBodyData.Set("embedding_config", value); }
    }

    /// <summary>
    /// Embedding model config ID. When provided instead of embedding_config, the
    /// embedding model config will be looked up by ID.
    /// </summary>
    public string? EmbeddingModelConfigID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("embedding_model_config_id");
        }
        init { this._rawBodyData.Set("embedding_model_config_id", value); }
    }

    /// <summary>
    /// Settings that can be configured for how to use LlamaParse to parse files within
    /// a LlamaCloud pipeline.
    /// </summary>
    public LlamaParseParameters? LlamaParseParameters
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<LlamaParseParameters>(
                "llama_parse_parameters"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("llama_parse_parameters", value);
        }
    }

    /// <summary>
    /// The ID of the ManagedPipeline this playground pipeline is linked to.
    /// </summary>
    public string? ManagedPipelineID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("managed_pipeline_id");
        }
        init { this._rawBodyData.Set("managed_pipeline_id", value); }
    }

    /// <summary>
    /// Metadata configuration for the pipeline.
    /// </summary>
    public PipelineMetadataConfig? MetadataConfig
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PipelineMetadataConfig>("metadata_config");
        }
        init { this._rawBodyData.Set("metadata_config", value); }
    }

    /// <summary>
    /// Type of pipeline. Either PLAYGROUND or MANAGED.
    /// </summary>
    public ApiEnum<string, PipelineType>? PipelineType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, PipelineType>>(
                "pipeline_type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("pipeline_type", value);
        }
    }

    /// <summary>
    /// Preset retrieval parameters for the pipeline.
    /// </summary>
    public PresetRetrievalParams? PresetRetrievalParameters
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PresetRetrievalParams>(
                "preset_retrieval_parameters"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("preset_retrieval_parameters", value);
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SparseModelConfig>("sparse_model_config");
        }
        init { this._rawBodyData.Set("sparse_model_config", value); }
    }

    /// <summary>
    /// Status of the pipeline deployment.
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("status");
        }
        init { this._rawBodyData.Set("status", value); }
    }

    /// <summary>
    /// Configuration for the transformation.
    /// </summary>
    public TransformConfig? TransformConfig
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<TransformConfig>("transform_config");
        }
        init { this._rawBodyData.Set("transform_config", value); }
    }

    public PipelineCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PipelineCreateParams(PipelineCreateParams pipelineCreateParams)
        : base(pipelineCreateParams)
    {
        this._rawBodyData = new(pipelineCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public PipelineCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PipelineCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PipelineCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(PipelineCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/pipelines")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(EmbeddingConfigConverter))]
public record class EmbeddingConfig : ModelBase
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

    public EmbeddingConfig(AzureOpenAIEmbeddingConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EmbeddingConfig(BedrockEmbeddingConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EmbeddingConfig(CohereEmbeddingConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EmbeddingConfig(GeminiEmbeddingConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EmbeddingConfig(
        HuggingFaceInferenceApiEmbeddingConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EmbeddingConfig(OpenAIEmbeddingConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EmbeddingConfig(VertexAIEmbeddingConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EmbeddingConfig(JsonElement element)
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
                    "Data did not match any variant of EmbeddingConfig"
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
                "Data did not match any variant of EmbeddingConfig"
            ),
        };
    }

    public static implicit operator EmbeddingConfig(AzureOpenAIEmbeddingConfig value) => new(value);

    public static implicit operator EmbeddingConfig(BedrockEmbeddingConfig value) => new(value);

    public static implicit operator EmbeddingConfig(CohereEmbeddingConfig value) => new(value);

    public static implicit operator EmbeddingConfig(GeminiEmbeddingConfig value) => new(value);

    public static implicit operator EmbeddingConfig(HuggingFaceInferenceApiEmbeddingConfig value) =>
        new(value);

    public static implicit operator EmbeddingConfig(OpenAIEmbeddingConfig value) => new(value);

    public static implicit operator EmbeddingConfig(VertexAIEmbeddingConfig value) => new(value);

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
                "Data did not match any variant of EmbeddingConfig"
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

    public virtual bool Equals(EmbeddingConfig? other) =>
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

sealed class EmbeddingConfigConverter : JsonConverter<EmbeddingConfig?>
{
    public override EmbeddingConfig? Read(
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
                return new EmbeddingConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmbeddingConfig? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Configuration for the transformation.
/// </summary>
[JsonConverter(typeof(TransformConfigConverter))]
public record class TransformConfig : ModelBase
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

    public TransformConfig(AutoTransformConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformConfig(AdvancedModeTransformConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformConfig(JsonElement element)
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
                    "Data did not match any variant of TransformConfig"
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
                "Data did not match any variant of TransformConfig"
            ),
        };
    }

    public static implicit operator TransformConfig(AutoTransformConfig value) => new(value);

    public static implicit operator TransformConfig(AdvancedModeTransformConfig value) =>
        new(value);

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
                "Data did not match any variant of TransformConfig"
            );
        }
        this.Switch((auto) => auto.Validate(), (advancedMode) => advancedMode.Validate());
    }

    public virtual bool Equals(TransformConfig? other) =>
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

sealed class TransformConfigConverter : JsonConverter<TransformConfig?>
{
    public override TransformConfig? Read(
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
        TransformConfig? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
