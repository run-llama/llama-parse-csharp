using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Pipelines;

/// <summary>
/// Schema for the search params for an retrieval execution that can be preset for
/// a pipeline.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PresetRetrievalParams, PresetRetrievalParamsFromRaw>))]
public sealed record class PresetRetrievalParams : JsonModel
{
    /// <summary>
    /// Alpha value for hybrid retrieval to determine the weights between dense and
    /// sparse retrieval. 0 is sparse retrieval and 1 is dense retrieval.
    /// </summary>
    public double? Alpha
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("alpha");
        }
        init { this._rawData.Set("alpha", value); }
    }

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
    /// Minimum similarity score wrt query for retrieval
    /// </summary>
    public double? DenseSimilarityCutoff
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("dense_similarity_cutoff");
        }
        init { this._rawData.Set("dense_similarity_cutoff", value); }
    }

    /// <summary>
    /// Number of nodes for dense retrieval.
    /// </summary>
    public long? DenseSimilarityTopK
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("dense_similarity_top_k");
        }
        init { this._rawData.Set("dense_similarity_top_k", value); }
    }

    /// <summary>
    /// Enable reranking for retrieval
    /// </summary>
    public bool? EnableReranking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enable_reranking");
        }
        init { this._rawData.Set("enable_reranking", value); }
    }

    /// <summary>
    /// Number of files to retrieve (only for retrieval mode files_via_metadata and files_via_content).
    /// </summary>
    public long? FilesTopK
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("files_top_k");
        }
        init { this._rawData.Set("files_top_k", value); }
    }

    /// <summary>
    /// Number of reranked nodes for returning.
    /// </summary>
    public long? RerankTopN
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("rerank_top_n");
        }
        init { this._rawData.Set("rerank_top_n", value); }
    }

    /// <summary>
    /// The retrieval mode for the query.
    /// </summary>
    public ApiEnum<string, RetrievalMode>? RetrievalMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RetrievalMode>>("retrieval_mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("retrieval_mode", value);
        }
    }

    /// <summary>
    /// Whether to retrieve image nodes.
    /// </summary>
    [System::Obsolete("deprecated")]
    public bool? RetrieveImageNodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("retrieve_image_nodes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("retrieve_image_nodes", value);
        }
    }

    /// <summary>
    /// Whether to retrieve page figure nodes.
    /// </summary>
    public bool? RetrievePageFigureNodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("retrieve_page_figure_nodes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("retrieve_page_figure_nodes", value);
        }
    }

    /// <summary>
    /// Whether to retrieve page screenshot nodes.
    /// </summary>
    public bool? RetrievePageScreenshotNodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("retrieve_page_screenshot_nodes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("retrieve_page_screenshot_nodes", value);
        }
    }

    /// <summary>
    /// Metadata filters for vector stores.
    /// </summary>
    public MetadataFilters? SearchFilters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MetadataFilters>("search_filters");
        }
        init { this._rawData.Set("search_filters", value); }
    }

    /// <summary>
    /// JSON Schema that will be used to infer search_filters. Omit or leave as null
    /// to skip inference.
    /// </summary>
    public IReadOnlyDictionary<
        string,
        PresetRetrievalParamsSearchFiltersInferenceSchema?
    >? SearchFiltersInferenceSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                FrozenDictionary<string, PresetRetrievalParamsSearchFiltersInferenceSchema?>
            >("search_filters_inference_schema");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<
                string,
                PresetRetrievalParamsSearchFiltersInferenceSchema?
            >?>(
                "search_filters_inference_schema",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Number of nodes for sparse retrieval.
    /// </summary>
    public long? SparseSimilarityTopK
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sparse_similarity_top_k");
        }
        init { this._rawData.Set("sparse_similarity_top_k", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Alpha;
        _ = this.ClassName;
        _ = this.DenseSimilarityCutoff;
        _ = this.DenseSimilarityTopK;
        _ = this.EnableReranking;
        _ = this.FilesTopK;
        _ = this.RerankTopN;
        this.RetrievalMode?.Validate();
        _ = this.RetrieveImageNodes;
        _ = this.RetrievePageFigureNodes;
        _ = this.RetrievePageScreenshotNodes;
        this.SearchFilters?.Validate();
        if (this.SearchFiltersInferenceSchema != null)
        {
            foreach (var item in this.SearchFiltersInferenceSchema.Values)
            {
                item?.Validate();
            }
        }
        _ = this.SparseSimilarityTopK;
    }

    public PresetRetrievalParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PresetRetrievalParams(PresetRetrievalParams presetRetrievalParams)
        : base(presetRetrievalParams) { }
#pragma warning restore CS8618

    public PresetRetrievalParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PresetRetrievalParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PresetRetrievalParamsFromRaw.FromRawUnchecked"/>
    public static PresetRetrievalParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PresetRetrievalParamsFromRaw : IFromRawJson<PresetRetrievalParams>
{
    /// <inheritdoc/>
    public PresetRetrievalParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PresetRetrievalParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PresetRetrievalParamsSearchFiltersInferenceSchemaConverter))]
public record class PresetRetrievalParamsSearchFiltersInferenceSchema : ModelBase
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

    public PresetRetrievalParamsSearchFiltersInferenceSchema(
        IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public PresetRetrievalParamsSearchFiltersInferenceSchema(
        IReadOnlyList<JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public PresetRetrievalParamsSearchFiltersInferenceSchema(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PresetRetrievalParamsSearchFiltersInferenceSchema(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PresetRetrievalParamsSearchFiltersInferenceSchema(
        bool value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PresetRetrievalParamsSearchFiltersInferenceSchema(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Dictionary{Key, Value}"/> with a <c>Key</c> of <c>string</c> and a <c>Value</c> of <c>JsonElement</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElements(out var value)) {
    ///     // `value` is of type `IReadOnlyDictionary&lt;string, JsonElement&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElements(
        [NotNullWhen(true)] out IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value = this.Value as IReadOnlyDictionary<string, JsonElement>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>JsonElement</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElements1(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;JsonElement&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElements1([NotNullWhen(true)] out IReadOnlyList<JsonElement>? value)
    {
        value = this.Value as IReadOnlyList<JsonElement>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
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
    ///     (IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
    ///     (IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<IReadOnlyDictionary<string, JsonElement>> jsonElements,
        System::Action<IReadOnlyList<JsonElement>> jsonElements1,
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case IReadOnlyDictionary<string, JsonElement> value:
                jsonElements(value);
                break;
            case IReadOnlyList<JsonElement> value:
                jsonElements1(value);
                break;
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PresetRetrievalParamsSearchFiltersInferenceSchema"
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
    ///     (IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
    ///     (IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<IReadOnlyDictionary<string, JsonElement>, T> jsonElements,
        System::Func<IReadOnlyList<JsonElement>, T> jsonElements1,
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            IReadOnlyDictionary<string, JsonElement> value => jsonElements(value),
            IReadOnlyList<JsonElement> value => jsonElements1(value),
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PresetRetrievalParamsSearchFiltersInferenceSchema"
            ),
        };
    }

    public static implicit operator PresetRetrievalParamsSearchFiltersInferenceSchema(
        Dictionary<string, JsonElement> value
    ) => new((IReadOnlyDictionary<string, JsonElement>)value);

    public static implicit operator PresetRetrievalParamsSearchFiltersInferenceSchema(
        List<JsonElement> value
    ) => new((IReadOnlyList<JsonElement>)value);

    public static implicit operator PresetRetrievalParamsSearchFiltersInferenceSchema(
        string value
    ) => new(value);

    public static implicit operator PresetRetrievalParamsSearchFiltersInferenceSchema(
        double value
    ) => new(value);

    public static implicit operator PresetRetrievalParamsSearchFiltersInferenceSchema(bool value) =>
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
                "Data did not match any variant of PresetRetrievalParamsSearchFiltersInferenceSchema"
            );
        }
    }

    public virtual bool Equals(PresetRetrievalParamsSearchFiltersInferenceSchema? other) =>
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
            IReadOnlyDictionary<string, JsonElement> _ => 0,
            IReadOnlyList<JsonElement> _ => 1,
            string _ => 2,
            double _ => 3,
            bool _ => 4,
            _ => -1,
        };
    }
}

sealed class PresetRetrievalParamsSearchFiltersInferenceSchemaConverter
    : JsonConverter<PresetRetrievalParamsSearchFiltersInferenceSchema?>
{
    public override PresetRetrievalParamsSearchFiltersInferenceSchema? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                element,
                options
            );
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<JsonElement>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PresetRetrievalParamsSearchFiltersInferenceSchema? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
