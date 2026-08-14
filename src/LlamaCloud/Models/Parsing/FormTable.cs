using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Parsing;

/// <summary>
/// A fillable grid printed on the form: repeating records or a row-by-column matrix.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FormTable, FormTableFromRaw>))]
public sealed record class FormTable : JsonModel
{
    /// <summary>
    /// Table cells: a verbatim string, null for a printed-but-blank cell, or an
    /// object holding the cell's own form nodes
    /// </summary>
    public required IReadOnlyList<IReadOnlyList<Row?>> Rows
    {
        get
        {
            this._rawData.Freeze();
            return ImmutableArray.ToImmutableArray(
                Enumerable.Select(
                    this._rawData.GetNotNullStruct<ImmutableArray<ImmutableArray<Row?>>>("rows"),
                    (item) => (IReadOnlyList<Row?>)item
                )
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ImmutableArray<Row?>>>(
                "rows",
                ImmutableArray.ToImmutableArray(
                    Enumerable.Select(value, (item) => ImmutableArray.ToImmutableArray(item))
                )
            );
        }
    }

    /// <summary>
    /// Identifier printed on the form, if any
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Bounding boxes of the table's fillable regions on the page.
    /// </summary>
    public IReadOnlyList<BBox>? Bbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BBox>>("bbox");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BBox>?>(
                "bbox",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Printed column headers in order, if any
    /// </summary>
    public IReadOnlyList<string>? Columns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("columns");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "columns",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Printed table caption, if any
    /// </summary>
    public string? Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("label");
        }
        init { this._rawData.Set("label", value); }
    }

    /// <summary>
    /// Form table node
    /// </summary>
    public ApiEnum<string, FormTableType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FormTableType>>("type");
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
        foreach (var item in this.Rows)
        {
            foreach (var item1 in item)
            {
                item1?.Validate();
            }
        }
        _ = this.ID;
        foreach (var item in this.Bbox ?? [])
        {
            item.Validate();
        }
        _ = this.Columns;
        _ = this.Label;
        this.Type?.Validate();
    }

    public FormTable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTable(FormTable formTable)
        : base(formTable) { }
#pragma warning restore CS8618

    public FormTable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableFromRaw.FromRawUnchecked"/>
    public static FormTable FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FormTable(IReadOnlyList<IReadOnlyList<Row?>> rows)
        : this()
    {
        this.Rows = rows;
    }
}

class FormTableFromRaw : IFromRawJson<FormTable>
{
    /// <inheritdoc/>
    public FormTable FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FormTable.FromRawUnchecked(rawData);
}

/// <summary>
/// A table cell holding its own form nodes (e.g. a checkbox column).
/// </summary>
[JsonConverter(typeof(RowConverter))]
public record class Row : ModelBase
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

    public Row(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Row(FormTableCellItems value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Row(JsonElement element)
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
    /// type <see cref="FormTableCellItems"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFormTableCellItems(out var value)) {
    ///     // `value` is of type `FormTableCellItems`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFormTableCellItems([NotNullWhen(true)] out FormTableCellItems? value)
    {
        value = this.Value as FormTableCellItems;
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
    ///     (FormTableCellItems value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<FormTableCellItems> formTableCellItems
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case FormTableCellItems value:
                formTableCellItems(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException("Data did not match any variant of Row");
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
    ///     (FormTableCellItems value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<FormTableCellItems, T> formTableCellItems
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            FormTableCellItems value => formTableCellItems(value),
            _ => throw new LlamaCloudInvalidDataException("Data did not match any variant of Row"),
        };
    }

    public static implicit operator Row(string value) => new(value);

    public static implicit operator Row(FormTableCellItems value) => new(value);

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
            throw new LlamaCloudInvalidDataException("Data did not match any variant of Row");
        }
        this.Switch((_) => { }, (formTableCellItems) => formTableCellItems.Validate());
    }

    public virtual bool Equals(Row? other) =>
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
            FormTableCellItems _ => 1,
            _ => -1,
        };
    }
}

sealed class RowConverter : JsonConverter<Row?>
{
    public override Row? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<FormTableCellItems>(element, options);
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

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Row? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Form table node
/// </summary>
[JsonConverter(typeof(FormTableTypeConverter))]
public enum FormTableType
{
    Table,
}

sealed class FormTableTypeConverter : JsonConverter<FormTableType>
{
    public override FormTableType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "table" => FormTableType.Table,
            _ => (FormTableType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FormTableType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FormTableType.Table => "table",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
