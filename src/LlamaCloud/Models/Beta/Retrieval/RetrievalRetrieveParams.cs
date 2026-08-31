using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;

namespace LlamaCloud.Models.Beta.Retrieval;

/// <summary>
/// Retrieve relevant chunks via hybrid search (vector + full-text), with filtering
/// on built-in or user-defined metadata.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RetrievalRetrieveParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// ID of the index to retrieve against.
    /// </summary>
    public required string IndexID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("index_id");
        }
        init { this._rawBodyData.Set("index_id", value); }
    }

    /// <summary>
    /// Natural-language query to retrieve relevant chunks.
    /// </summary>
    public required string Query
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("query");
        }
        init { this._rawBodyData.Set("query", value); }
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
    /// Filters on user-defined metadata fields.
    /// </summary>
    public IReadOnlyDictionary<string, CustomFilter?>? CustomFilters
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, CustomFilter?>>(
                "custom_filters"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, CustomFilter?>?>(
                "custom_filters",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Weight of the full-text search pipeline (0-1).
    /// </summary>
    public double? FullTextPipelineWeight
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("full_text_pipeline_weight");
        }
        init { this._rawBodyData.Set("full_text_pipeline_weight", value); }
    }

    /// <summary>
    /// Number of candidates for approximate nearest neighbor search.
    /// </summary>
    public long? NumCandidates
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("num_candidates");
        }
        init { this._rawBodyData.Set("num_candidates", value); }
    }

    /// <summary>
    /// Reranking configuration applied after hybrid search. Enabled by default.
    /// </summary>
    public Rerank? Rerank
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Rerank>("rerank");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("rerank", value);
        }
    }

    /// <summary>
    /// Minimum score threshold for returned results.
    /// </summary>
    public double? ScoreThreshold
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("score_threshold");
        }
        init { this._rawBodyData.Set("score_threshold", value); }
    }

    /// <summary>
    /// Filters on built-in document fields (page range, chunk index, etc.).
    /// </summary>
    public StaticFilters? StaticFilters
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<StaticFilters>("static_filters");
        }
        init { this._rawBodyData.Set("static_filters", value); }
    }

    /// <summary>
    /// Maximum number of results to return. Values above 500 are capped at 500.
    /// </summary>
    public long? TopK
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("top_k");
        }
        init { this._rawBodyData.Set("top_k", value); }
    }

    /// <summary>
    /// Weight of the vector search pipeline (0-1).
    /// </summary>
    public double? VectorPipelineWeight
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("vector_pipeline_weight");
        }
        init { this._rawBodyData.Set("vector_pipeline_weight", value); }
    }

    public RetrievalRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetrievalRetrieveParams(RetrievalRetrieveParams retrievalRetrieveParams)
        : base(retrievalRetrieveParams)
    {
        this._rawBodyData = new(retrievalRetrieveParams._rawBodyData);
    }
#pragma warning restore CS8618

    public RetrievalRetrieveParams(
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
    RetrievalRetrieveParams(
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
    public static RetrievalRetrieveParams FromRawUnchecked(
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

    public virtual bool Equals(RetrievalRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/retrieval/retrieve"
        )
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

/// <summary>
/// Filter on a single metadata field value.
/// </summary>
[JsonConverter(typeof(CustomFilterConverter))]
public record class CustomFilter : ModelBase
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

    public CustomFilter(ValueFilter value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CustomFilter(IReadOnlyList<NumericRangeFilter> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public CustomFilter(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ValueFilter"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickValue(out var value)) {
    ///     // `value` is of type `ValueFilter`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickValue([NotNullWhen(true)] out ValueFilter? value)
    {
        value = this.Value as ValueFilter;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>NumericRangeFilter</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNumericRangeFilters(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;NumericRangeFilter&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNumericRangeFilters(
        [NotNullWhen(true)] out IReadOnlyList<NumericRangeFilter>? value
    )
    {
        value = this.Value as IReadOnlyList<NumericRangeFilter>;
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
    ///     (ValueFilter value) =&gt; {...},
    ///     (IReadOnlyList&lt;NumericRangeFilter&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<ValueFilter> value,
        Action<IReadOnlyList<NumericRangeFilter>> numericRangeFilters
    )
    {
        switch (this.Value)
        {
            case ValueFilter value1:
                value(value1);
                break;
            case IReadOnlyList<NumericRangeFilter> value1:
                numericRangeFilters(value1);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of CustomFilter"
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
    ///     (ValueFilter value) =&gt; {...},
    ///     (IReadOnlyList&lt;NumericRangeFilter&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<ValueFilter, T> value,
        Func<IReadOnlyList<NumericRangeFilter>, T> numericRangeFilters
    )
    {
        return this.Value switch
        {
            ValueFilter value1 => value(value1),
            IReadOnlyList<NumericRangeFilter> value1 => numericRangeFilters(value1),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of CustomFilter"
            ),
        };
    }

    public static implicit operator CustomFilter(ValueFilter value) => new(value);

    public static implicit operator CustomFilter(List<NumericRangeFilter> value) =>
        new((IReadOnlyList<NumericRangeFilter>)value);

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
                "Data did not match any variant of CustomFilter"
            );
        }
        this.Switch(
            (value) => value.Validate(),
            (numericRangeFilters) =>
            {
                foreach (var item in numericRangeFilters)
                {
                    item.Validate();
                }
            }
        );
    }

    public virtual bool Equals(CustomFilter? other) =>
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
            ValueFilter _ => 0,
            IReadOnlyList<NumericRangeFilter> _ => 1,
            _ => -1,
        };
    }
}

sealed class CustomFilterConverter : JsonConverter<CustomFilter?>
{
    public override CustomFilter? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ValueFilter>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<NumericRangeFilter>>(
                element,
                options
            );
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomFilter? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Filter on a single metadata field value.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ValueFilter, ValueFilterFromRaw>))]
public sealed record class ValueFilter : JsonModel
{
    public required ApiEnum<string, Operator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Operator>>("operator");
        }
        init { this._rawData.Set("operator", value); }
    }

    public required ValueFilterValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ValueFilterValue>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Operator.Validate();
        this.Value.Validate();
    }

    public ValueFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ValueFilter(ValueFilter valueFilter)
        : base(valueFilter) { }
#pragma warning restore CS8618

    public ValueFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValueFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValueFilterFromRaw.FromRawUnchecked"/>
    public static ValueFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ValueFilterFromRaw : IFromRawJson<ValueFilter>
{
    /// <inheritdoc/>
    public ValueFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ValueFilter.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(OperatorConverter))]
public enum Operator
{
    Eq,
    Gt,
    Gte,
    In,
    Lt,
    Lte,
    Ne,
    Nin,
}

sealed class OperatorConverter : JsonConverter<Operator>
{
    public override Operator Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "eq" => Operator.Eq,
            "gt" => Operator.Gt,
            "gte" => Operator.Gte,
            "in" => Operator.In,
            "lt" => Operator.Lt,
            "lte" => Operator.Lte,
            "ne" => Operator.Ne,
            "nin" => Operator.Nin,
            _ => (Operator)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Operator value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operator.Eq => "eq",
                Operator.Gt => "gt",
                Operator.Gte => "gte",
                Operator.In => "in",
                Operator.Lt => "lt",
                Operator.Lte => "lte",
                Operator.Ne => "ne",
                Operator.Nin => "nin",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ValueFilterValueConverter))]
public record class ValueFilterValue : ModelBase
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

    public ValueFilterValue(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ValueFilterValue(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ValueFilterValue(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ValueFilterValue(
        IReadOnlyList<UnnamedSchemaWithArrayParent0> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ValueFilterValue(JsonElement element)
    {
        this._element = element;
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
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>UnnamedSchemaWithArrayParent0</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnnamedSchemaWithArrayParent0s(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;UnnamedSchemaWithArrayParent0&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnnamedSchemaWithArrayParent0s(
        [NotNullWhen(true)] out IReadOnlyList<UnnamedSchemaWithArrayParent0>? value
    )
    {
        value = this.Value as IReadOnlyList<UnnamedSchemaWithArrayParent0>;
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
    ///     (string value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (IReadOnlyList&lt;UnnamedSchemaWithArrayParent0&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<string> @string,
        Action<bool> @bool,
        Action<double> @double,
        Action<IReadOnlyList<UnnamedSchemaWithArrayParent0>> unnamedSchemaWithArrayParent0s
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case bool value:
                @bool(value);
                break;
            case double value:
                @double(value);
                break;
            case IReadOnlyList<UnnamedSchemaWithArrayParent0> value:
                unnamedSchemaWithArrayParent0s(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of ValueFilterValue"
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
    ///     (string value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (IReadOnlyList&lt;UnnamedSchemaWithArrayParent0&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<string, T> @string,
        Func<bool, T> @bool,
        Func<double, T> @double,
        Func<IReadOnlyList<UnnamedSchemaWithArrayParent0>, T> unnamedSchemaWithArrayParent0s
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            bool value => @bool(value),
            double value => @double(value),
            IReadOnlyList<UnnamedSchemaWithArrayParent0> value => unnamedSchemaWithArrayParent0s(
                value
            ),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of ValueFilterValue"
            ),
        };
    }

    public static implicit operator ValueFilterValue(string value) => new(value);

    public static implicit operator ValueFilterValue(bool value) => new(value);

    public static implicit operator ValueFilterValue(double value) => new(value);

    public static implicit operator ValueFilterValue(List<UnnamedSchemaWithArrayParent0> value) =>
        new((IReadOnlyList<UnnamedSchemaWithArrayParent0>)value);

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
                "Data did not match any variant of ValueFilterValue"
            );
        }
        this.Switch(
            (_) => { },
            (_) => { },
            (_) => { },
            (unnamedSchemaWithArrayParent0s) =>
            {
                foreach (var item in unnamedSchemaWithArrayParent0s)
                {
                    item.Validate();
                }
            }
        );
    }

    public virtual bool Equals(ValueFilterValue? other) =>
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
            string _ => 0,
            bool _ => 1,
            double _ => 2,
            IReadOnlyList<UnnamedSchemaWithArrayParent0> _ => 3,
            _ => -1,
        };
    }
}

sealed class ValueFilterValueConverter : JsonConverter<ValueFilterValue>
{
    public override ValueFilterValue? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<UnnamedSchemaWithArrayParent0>>(
                element,
                options
            );
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ValueFilterValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(UnnamedSchemaWithArrayParent0Converter))]
public record class UnnamedSchemaWithArrayParent0 : ModelBase
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

    public UnnamedSchemaWithArrayParent0(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0(JsonElement element)
    {
        this._element = element;
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
    ///     (string value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (double value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<string> @string, Action<bool> @bool, Action<double> @double)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case bool value:
                @bool(value);
                break;
            case double value:
                @double(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of UnnamedSchemaWithArrayParent0"
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
    ///     (string value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (double value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<string, T> @string, Func<bool, T> @bool, Func<double, T> @double)
    {
        return this.Value switch
        {
            string value => @string(value),
            bool value => @bool(value),
            double value => @double(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent0"
            ),
        };
    }

    public static implicit operator UnnamedSchemaWithArrayParent0(string value) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0(bool value) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0(double value) => new(value);

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
                "Data did not match any variant of UnnamedSchemaWithArrayParent0"
            );
        }
    }

    public virtual bool Equals(UnnamedSchemaWithArrayParent0? other) =>
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
            string _ => 0,
            bool _ => 1,
            double _ => 2,
            _ => -1,
        };
    }
}

sealed class UnnamedSchemaWithArrayParent0Converter : JsonConverter<UnnamedSchemaWithArrayParent0>
{
    public override UnnamedSchemaWithArrayParent0? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent0 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// One bound of a numeric range filter on a metadata field.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NumericRangeFilter, NumericRangeFilterFromRaw>))]
public sealed record class NumericRangeFilter : JsonModel
{
    public required ApiEnum<string, NumericRangeFilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, NumericRangeFilterOperator>>(
                "operator"
            );
        }
        init { this._rawData.Set("operator", value); }
    }

    public required NumericRangeFilterValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NumericRangeFilterValue>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Operator.Validate();
        this.Value.Validate();
    }

    public NumericRangeFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumericRangeFilter(NumericRangeFilter numericRangeFilter)
        : base(numericRangeFilter) { }
#pragma warning restore CS8618

    public NumericRangeFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NumericRangeFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NumericRangeFilterFromRaw.FromRawUnchecked"/>
    public static NumericRangeFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NumericRangeFilterFromRaw : IFromRawJson<NumericRangeFilter>
{
    /// <inheritdoc/>
    public NumericRangeFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NumericRangeFilter.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(NumericRangeFilterOperatorConverter))]
public enum NumericRangeFilterOperator
{
    Eq,
    Gt,
    Gte,
    In,
    Lt,
    Lte,
    Ne,
    Nin,
}

sealed class NumericRangeFilterOperatorConverter : JsonConverter<NumericRangeFilterOperator>
{
    public override NumericRangeFilterOperator Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "eq" => NumericRangeFilterOperator.Eq,
            "gt" => NumericRangeFilterOperator.Gt,
            "gte" => NumericRangeFilterOperator.Gte,
            "in" => NumericRangeFilterOperator.In,
            "lt" => NumericRangeFilterOperator.Lt,
            "lte" => NumericRangeFilterOperator.Lte,
            "ne" => NumericRangeFilterOperator.Ne,
            "nin" => NumericRangeFilterOperator.Nin,
            _ => (NumericRangeFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NumericRangeFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NumericRangeFilterOperator.Eq => "eq",
                NumericRangeFilterOperator.Gt => "gt",
                NumericRangeFilterOperator.Gte => "gte",
                NumericRangeFilterOperator.In => "in",
                NumericRangeFilterOperator.Lt => "lt",
                NumericRangeFilterOperator.Lte => "lte",
                NumericRangeFilterOperator.Ne => "ne",
                NumericRangeFilterOperator.Nin => "nin",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(NumericRangeFilterValueConverter))]
public record class NumericRangeFilterValue : ModelBase
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

    public NumericRangeFilterValue(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public NumericRangeFilterValue(IReadOnlyList<double> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public NumericRangeFilterValue(JsonElement element)
    {
        this._element = element;
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
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>double</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDoubles(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;double&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDoubles([NotNullWhen(true)] out IReadOnlyList<double>? value)
    {
        value = this.Value as IReadOnlyList<double>;
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
    ///     (double value) =&gt; {...},
    ///     (IReadOnlyList&lt;double&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<double> @double, Action<IReadOnlyList<double>> doubles)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case IReadOnlyList<double> value:
                doubles(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of NumericRangeFilterValue"
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
    ///     (double value) =&gt; {...},
    ///     (IReadOnlyList&lt;double&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<double, T> @double, Func<IReadOnlyList<double>, T> doubles)
    {
        return this.Value switch
        {
            double value => @double(value),
            IReadOnlyList<double> value => doubles(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of NumericRangeFilterValue"
            ),
        };
    }

    public static implicit operator NumericRangeFilterValue(double value) => new(value);

    public static implicit operator NumericRangeFilterValue(List<double> value) =>
        new((IReadOnlyList<double>)value);

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
                "Data did not match any variant of NumericRangeFilterValue"
            );
        }
    }

    public virtual bool Equals(NumericRangeFilterValue? other) =>
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
            double _ => 0,
            IReadOnlyList<double> _ => 1,
            _ => -1,
        };
    }
}

sealed class NumericRangeFilterValueConverter : JsonConverter<NumericRangeFilterValue>
{
    public override NumericRangeFilterValue? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<double>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        NumericRangeFilterValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Reranking configuration applied after hybrid search. Enabled by default.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Rerank, RerankFromRaw>))]
public sealed record class Rerank : JsonModel
{
    /// <summary>
    /// Set to false to disable reranking.
    /// </summary>
    public bool? Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("enabled", value);
        }
    }

    /// <summary>
    /// Number of results to return after reranking.
    /// </summary>
    public long? TopN
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("top_n");
        }
        init { this._rawData.Set("top_n", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enabled;
        _ = this.TopN;
    }

    public Rerank() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Rerank(Rerank rerank)
        : base(rerank) { }
#pragma warning restore CS8618

    public Rerank(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Rerank(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RerankFromRaw.FromRawUnchecked"/>
    public static Rerank FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RerankFromRaw : IFromRawJson<Rerank>
{
    /// <inheritdoc/>
    public Rerank FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Rerank.FromRawUnchecked(rawData);
}

/// <summary>
/// Filters on built-in document fields (page range, chunk index, etc.).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StaticFilters, StaticFiltersFromRaw>))]
public sealed record class StaticFilters : JsonModel
{
    /// <summary>
    /// Filter on a string field.
    /// </summary>
    public ParsedDirectoryFileID? ParsedDirectoryFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ParsedDirectoryFileID>(
                "parsed_directory_file_id"
            );
        }
        init { this._rawData.Set("parsed_directory_file_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ParsedDirectoryFileID?.Validate();
    }

    public StaticFilters() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StaticFilters(StaticFilters staticFilters)
        : base(staticFilters) { }
#pragma warning restore CS8618

    public StaticFilters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StaticFilters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StaticFiltersFromRaw.FromRawUnchecked"/>
    public static StaticFilters FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StaticFiltersFromRaw : IFromRawJson<StaticFilters>
{
    /// <inheritdoc/>
    public StaticFilters FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        StaticFilters.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter on a string field.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ParsedDirectoryFileID, ParsedDirectoryFileIDFromRaw>))]
public sealed record class ParsedDirectoryFileID : JsonModel
{
    public required ApiEnum<string, ParsedDirectoryFileIDOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ParsedDirectoryFileIDOperator>>(
                "operator"
            );
        }
        init { this._rawData.Set("operator", value); }
    }

    public required ParsedDirectoryFileIDValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ParsedDirectoryFileIDValue>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Operator.Validate();
        this.Value.Validate();
    }

    public ParsedDirectoryFileID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParsedDirectoryFileID(ParsedDirectoryFileID parsedDirectoryFileID)
        : base(parsedDirectoryFileID) { }
#pragma warning restore CS8618

    public ParsedDirectoryFileID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParsedDirectoryFileID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParsedDirectoryFileIDFromRaw.FromRawUnchecked"/>
    public static ParsedDirectoryFileID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParsedDirectoryFileIDFromRaw : IFromRawJson<ParsedDirectoryFileID>
{
    /// <inheritdoc/>
    public ParsedDirectoryFileID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ParsedDirectoryFileID.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ParsedDirectoryFileIDOperatorConverter))]
public enum ParsedDirectoryFileIDOperator
{
    Eq,
    Gt,
    Gte,
    In,
    Lt,
    Lte,
    Ne,
    Nin,
}

sealed class ParsedDirectoryFileIDOperatorConverter : JsonConverter<ParsedDirectoryFileIDOperator>
{
    public override ParsedDirectoryFileIDOperator Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "eq" => ParsedDirectoryFileIDOperator.Eq,
            "gt" => ParsedDirectoryFileIDOperator.Gt,
            "gte" => ParsedDirectoryFileIDOperator.Gte,
            "in" => ParsedDirectoryFileIDOperator.In,
            "lt" => ParsedDirectoryFileIDOperator.Lt,
            "lte" => ParsedDirectoryFileIDOperator.Lte,
            "ne" => ParsedDirectoryFileIDOperator.Ne,
            "nin" => ParsedDirectoryFileIDOperator.Nin,
            _ => (ParsedDirectoryFileIDOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ParsedDirectoryFileIDOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ParsedDirectoryFileIDOperator.Eq => "eq",
                ParsedDirectoryFileIDOperator.Gt => "gt",
                ParsedDirectoryFileIDOperator.Gte => "gte",
                ParsedDirectoryFileIDOperator.In => "in",
                ParsedDirectoryFileIDOperator.Lt => "lt",
                ParsedDirectoryFileIDOperator.Lte => "lte",
                ParsedDirectoryFileIDOperator.Ne => "ne",
                ParsedDirectoryFileIDOperator.Nin => "nin",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ParsedDirectoryFileIDValueConverter))]
public record class ParsedDirectoryFileIDValue : ModelBase
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

    public ParsedDirectoryFileIDValue(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ParsedDirectoryFileIDValue(IReadOnlyList<string> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ParsedDirectoryFileIDValue(JsonElement element)
    {
        this._element = element;
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
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>string</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStrings(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;string&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStrings([NotNullWhen(true)] out IReadOnlyList<string>? value)
    {
        value = this.Value as IReadOnlyList<string>;
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
    ///     (string value) =&gt; {...},
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<string> @string, Action<IReadOnlyList<string>> strings)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case IReadOnlyList<string> value:
                strings(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of ParsedDirectoryFileIDValue"
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
    ///     (string value) =&gt; {...},
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<string, T> @string, Func<IReadOnlyList<string>, T> strings)
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<string> value => strings(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of ParsedDirectoryFileIDValue"
            ),
        };
    }

    public static implicit operator ParsedDirectoryFileIDValue(string value) => new(value);

    public static implicit operator ParsedDirectoryFileIDValue(List<string> value) =>
        new((IReadOnlyList<string>)value);

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
                "Data did not match any variant of ParsedDirectoryFileIDValue"
            );
        }
    }

    public virtual bool Equals(ParsedDirectoryFileIDValue? other) =>
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
            string _ => 0,
            IReadOnlyList<string> _ => 1,
            _ => -1,
        };
    }
}

sealed class ParsedDirectoryFileIDValueConverter : JsonConverter<ParsedDirectoryFileIDValue>
{
    public override ParsedDirectoryFileIDValue? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ParsedDirectoryFileIDValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
