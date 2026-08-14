using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Pipelines;

/// <summary>
/// Metadata filters for vector stores.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MetadataFilters, MetadataFiltersFromRaw>))]
public sealed record class MetadataFilters : JsonModel
{
    public required IReadOnlyList<Filter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Filter>>("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Filter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Vector store filter conditions to combine different filters.
    /// </summary>
    public ApiEnum<string, Condition>? Condition
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Condition>>("condition");
        }
        init { this._rawData.Set("condition", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        this.Condition?.Validate();
    }

    public MetadataFilters() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MetadataFilters(MetadataFilters metadataFilters)
        : base(metadataFilters) { }
#pragma warning restore CS8618

    public MetadataFilters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MetadataFilters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetadataFiltersFromRaw.FromRawUnchecked"/>
    public static MetadataFilters FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MetadataFilters(IReadOnlyList<Filter> filters)
        : this()
    {
        this.Filters = filters;
    }
}

class MetadataFiltersFromRaw : IFromRawJson<MetadataFilters>
{
    /// <inheritdoc/>
    public MetadataFilters FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MetadataFilters.FromRawUnchecked(rawData);
}

/// <summary>
/// Comprehensive metadata filter for vector stores to support more operators.
///
/// <para>Value uses Strict types, as int, float and str are compatible types and
/// were all converted to string before.</para>
///
/// <para>See: https://docs.pydantic.dev/latest/usage/types/#strict-types</para>
/// </summary>
[JsonConverter(typeof(FilterConverter))]
public record class Filter : ModelBase
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

    public Filter(MetadataFilter value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Filter(MetadataFilters value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Filter(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="MetadataFilter"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMetadata(out var value)) {
    ///     // `value` is of type `MetadataFilter`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMetadata([NotNullWhen(true)] out MetadataFilter? value)
    {
        value = this.Value as MetadataFilter;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="MetadataFilters"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMetadataFilters(out var value)) {
    ///     // `value` is of type `MetadataFilters`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMetadataFilters([NotNullWhen(true)] out MetadataFilters? value)
    {
        value = this.Value as MetadataFilters;
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
    ///     (MetadataFilter value) =&gt; {...},
    ///     (MetadataFilters value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<MetadataFilter> metadata,
        System::Action<MetadataFilters> metadataFilters
    )
    {
        switch (this.Value)
        {
            case MetadataFilter value:
                metadata(value);
                break;
            case MetadataFilters value:
                metadataFilters(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of Filter"
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
    ///     (MetadataFilter value) =&gt; {...},
    ///     (MetadataFilters value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<MetadataFilter, T> metadata,
        System::Func<MetadataFilters, T> metadataFilters
    )
    {
        return this.Value switch
        {
            MetadataFilter value => metadata(value),
            MetadataFilters value => metadataFilters(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of Filter"
            ),
        };
    }

    public static implicit operator Filter(MetadataFilter value) => new(value);

    public static implicit operator Filter(MetadataFilters value) => new(value);

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
            throw new LlamaCloudInvalidDataException("Data did not match any variant of Filter");
        }
        this.Switch(
            (metadata) => metadata.Validate(),
            (metadataFilters) => metadataFilters.Validate()
        );
    }

    public virtual bool Equals(Filter? other) =>
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
            MetadataFilter _ => 0,
            MetadataFilters _ => 1,
            _ => -1,
        };
    }
}

sealed class FilterConverter : JsonConverter<Filter>
{
    public override Filter? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<MetadataFilter>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<MetadataFilters>(element, options);
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

    public override void Write(Utf8JsonWriter writer, Filter value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Comprehensive metadata filter for vector stores to support more operators.
///
/// <para>Value uses Strict types, as int, float and str are compatible types and
/// were all converted to string before.</para>
///
/// <para>See: https://docs.pydantic.dev/latest/usage/types/#strict-types</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MetadataFilter, MetadataFilterFromRaw>))]
public sealed record class MetadataFilter : JsonModel
{
    public required string Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    public required MetadataFilterValue? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MetadataFilterValue>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <summary>
    /// Vector store filter operator.
    /// </summary>
    public ApiEnum<string, Operator>? Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Operator>>("operator");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("operator", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Key;
        this.Value?.Validate();
        this.Operator?.Validate();
    }

    public MetadataFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MetadataFilter(MetadataFilter metadataFilter)
        : base(metadataFilter) { }
#pragma warning restore CS8618

    public MetadataFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MetadataFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetadataFilterFromRaw.FromRawUnchecked"/>
    public static MetadataFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetadataFilterFromRaw : IFromRawJson<MetadataFilter>
{
    /// <inheritdoc/>
    public MetadataFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MetadataFilter.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MetadataFilterValueConverter))]
public record class MetadataFilterValue : ModelBase
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

    public MetadataFilterValue(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public MetadataFilterValue(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public MetadataFilterValue(IReadOnlyList<string> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public MetadataFilterValue(IReadOnlyList<double> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public MetadataFilterValue(IReadOnlyList<long> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public MetadataFilterValue(JsonElement element)
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
    /// if (instance.TryPickStringArray(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;string&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStringArray([NotNullWhen(true)] out IReadOnlyList<string>? value)
    {
        value = this.Value as IReadOnlyList<string>;
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
    /// if (instance.TryPickNumberArray(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;double&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNumberArray([NotNullWhen(true)] out IReadOnlyList<double>? value)
    {
        value = this.Value as IReadOnlyList<double>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>long</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickIntegerArray(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;long&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickIntegerArray([NotNullWhen(true)] out IReadOnlyList<long>? value)
    {
        value = this.Value as IReadOnlyList<long>;
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
    ///     (string value) =&gt; {...},
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...},
    ///     (IReadOnlyList&lt;double&gt; value) =&gt; {...},
    ///     (IReadOnlyList&lt;long&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<double> @double,
        System::Action<string> @string,
        System::Action<IReadOnlyList<string>> stringArray,
        System::Action<IReadOnlyList<double>> numberArray,
        System::Action<IReadOnlyList<long>> integerArray
    )
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            case IReadOnlyList<string> value:
                stringArray(value);
                break;
            case IReadOnlyList<double> value:
                numberArray(value);
                break;
            case IReadOnlyList<long> value:
                integerArray(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of MetadataFilterValue"
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
    ///     (string value) =&gt; {...},
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...},
    ///     (IReadOnlyList&lt;double&gt; value) =&gt; {...},
    ///     (IReadOnlyList&lt;long&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<double, T> @double,
        System::Func<string, T> @string,
        System::Func<IReadOnlyList<string>, T> stringArray,
        System::Func<IReadOnlyList<double>, T> numberArray,
        System::Func<IReadOnlyList<long>, T> integerArray
    )
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            IReadOnlyList<string> value => stringArray(value),
            IReadOnlyList<double> value => numberArray(value),
            IReadOnlyList<long> value => integerArray(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of MetadataFilterValue"
            ),
        };
    }

    public static implicit operator MetadataFilterValue(double value) => new(value);

    public static implicit operator MetadataFilterValue(string value) => new(value);

    public static implicit operator MetadataFilterValue(List<string> value) =>
        new((IReadOnlyList<string>)value);

    public static implicit operator MetadataFilterValue(List<double> value) =>
        new((IReadOnlyList<double>)value);

    public static implicit operator MetadataFilterValue(List<long> value) =>
        new((IReadOnlyList<long>)value);

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
                "Data did not match any variant of MetadataFilterValue"
            );
        }
    }

    public virtual bool Equals(MetadataFilterValue? other) =>
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
            string _ => 1,
            IReadOnlyList<string> _ => 2,
            IReadOnlyList<double> _ => 3,
            IReadOnlyList<long> _ => 4,
            _ => -1,
        };
    }
}

sealed class MetadataFilterValueConverter : JsonConverter<MetadataFilterValue?>
{
    public override MetadataFilterValue? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
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
            var deserialized = JsonSerializer.Deserialize<List<string>>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<List<double>>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<List<long>>(element, options);
            if (deserialized != null)
            {
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
        MetadataFilterValue? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Vector store filter operator.
/// </summary>
[JsonConverter(typeof(OperatorConverter))]
public enum Operator
{
    Undefined,
    V1,
    V2,
    V3,
    V4,
    V5,
    All,
    Any,
    Contains,
    In,
    IsEmpty,
    Nin,
    TextMatch,
    TextMatchInsensitive,
}

sealed class OperatorConverter : JsonConverter<Operator>
{
    public override Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "!=" => Operator.Undefined,
            "<" => Operator.V1,
            "<=" => Operator.V2,
            "==" => Operator.V3,
            ">" => Operator.V4,
            ">=" => Operator.V5,
            "all" => Operator.All,
            "any" => Operator.Any,
            "contains" => Operator.Contains,
            "in" => Operator.In,
            "is_empty" => Operator.IsEmpty,
            "nin" => Operator.Nin,
            "text_match" => Operator.TextMatch,
            "text_match_insensitive" => Operator.TextMatchInsensitive,
            _ => (Operator)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Operator value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operator.Undefined => "!=",
                Operator.V1 => "<",
                Operator.V2 => "<=",
                Operator.V3 => "==",
                Operator.V4 => ">",
                Operator.V5 => ">=",
                Operator.All => "all",
                Operator.Any => "any",
                Operator.Contains => "contains",
                Operator.In => "in",
                Operator.IsEmpty => "is_empty",
                Operator.Nin => "nin",
                Operator.TextMatch => "text_match",
                Operator.TextMatchInsensitive => "text_match_insensitive",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Vector store filter conditions to combine different filters.
/// </summary>
[JsonConverter(typeof(ConditionConverter))]
public enum Condition
{
    And,
    Not,
    Or,
}

sealed class ConditionConverter : JsonConverter<Condition>
{
    public override Condition Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "and" => Condition.And,
            "not" => Condition.Not,
            "or" => Condition.Or,
            _ => (Condition)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Condition value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Condition.And => "and",
                Condition.Not => "not",
                Condition.Or => "or",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
