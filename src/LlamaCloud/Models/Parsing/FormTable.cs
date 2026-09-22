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
    /// Scalar text grounding aligned with the table's columns and ragged rows.
    /// </summary>
    public FormTableGrounding? Grounding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FormTableGrounding>("grounding");
        }
        init { this._rawData.Set("grounding", value); }
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
        this.Grounding?.Validate();
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
/// Scalar text grounding aligned with the table's columns and ragged rows.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FormTableGrounding, FormTableGroundingFromRaw>))]
public sealed record class FormTableGrounding : JsonModel
{
    /// <summary>
    /// Supported text with half-open UTF-8 byte spans into the complete property string.
    /// </summary>
    public FormTableGroundingID? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FormTableGroundingID>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Column text grounding in source order; blank slots have empty lines
    /// </summary>
    public IReadOnlyList<Column>? Columns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Column>>("columns");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Column>?>(
                "columns",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Supported text with half-open UTF-8 byte spans into the complete property string.
    /// </summary>
    public FormTableGroundingLabel? Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FormTableGroundingLabel>("label");
        }
        init { this._rawData.Set("label", value); }
    }

    /// <summary>
    /// Scalar cell text grounding aligned with rows; blank and structured slots have
    /// empty lines. Structured children carry their own grounding.
    /// </summary>
    public IReadOnlyList<IReadOnlyList<FormTextGrounding>>? Rows
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableStruct<
                ImmutableArray<ImmutableArray<FormTextGrounding>>
            >("rows");
            if (value == null)
            {
                return null;
            }

            return ImmutableArray.ToImmutableArray(
                Enumerable.Select(value.Value, (item) => (IReadOnlyList<FormTextGrounding>)item)
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ImmutableArray<FormTextGrounding>>?>(
                "rows",
                value == null
                    ? null
                    : ImmutableArray.ToImmutableArray(
                        Enumerable.Select(value, (item) => ImmutableArray.ToImmutableArray(item))
                    )
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ID?.Validate();
        foreach (var item in this.Columns ?? [])
        {
            item.Validate();
        }
        this.Label?.Validate();
        foreach (var item in this.Rows ?? [])
        {
            foreach (var item1 in item)
            {
                item1.Validate();
            }
        }
    }

    public FormTableGrounding() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTableGrounding(FormTableGrounding formTableGrounding)
        : base(formTableGrounding) { }
#pragma warning restore CS8618

    public FormTableGrounding(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTableGrounding(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableGroundingFromRaw.FromRawUnchecked"/>
    public static FormTableGrounding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormTableGroundingFromRaw : IFromRawJson<FormTableGrounding>
{
    /// <inheritdoc/>
    public FormTableGrounding FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FormTableGrounding.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FormTableGroundingID, FormTableGroundingIDFromRaw>))]
public sealed record class FormTableGroundingID : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<FormTableGroundingIDLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FormTableGroundingIDLine>>(
                "lines"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormTableGroundingIDLine>>(
                "lines",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Lines)
        {
            item.Validate();
        }
    }

    public FormTableGroundingID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTableGroundingID(FormTableGroundingID formTableGroundingID)
        : base(formTableGroundingID) { }
#pragma warning restore CS8618

    public FormTableGroundingID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTableGroundingID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableGroundingIDFromRaw.FromRawUnchecked"/>
    public static FormTableGroundingID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FormTableGroundingID(IReadOnlyList<FormTableGroundingIDLine> lines)
        : this()
    {
        this.Lines = lines;
    }
}

class FormTableGroundingIDFromRaw : IFromRawJson<FormTableGroundingID>
{
    /// <inheritdoc/>
    public FormTableGroundingID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormTableGroundingID.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FormTableGroundingIDLine, FormTableGroundingIDLineFromRaw>)
)]
public sealed record class FormTableGroundingIDLine : JsonModel
{
    /// <summary>
    /// Line bounding box
    /// </summary>
    public required BBox Bbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BBox>("bbox");
        }
        init { this._rawData.Set("bbox", value); }
    }

    /// <summary>
    /// `[start, end)` UTF-8 byte span in the complete source property string
    /// </summary>
    public required IReadOnlyList<JsonElement> Span
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JsonElement>>("span");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JsonElement>>(
                "span",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Per-word grounding within the line, when available
    /// </summary>
    public IReadOnlyList<FormTableGroundingIDLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FormTableGroundingIDLineWord>>(
                "words"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormTableGroundingIDLineWord>?>(
                "words",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Bbox.Validate();
        _ = this.Span;
        foreach (var item in this.Words ?? [])
        {
            item.Validate();
        }
    }

    public FormTableGroundingIDLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTableGroundingIDLine(FormTableGroundingIDLine formTableGroundingIDLine)
        : base(formTableGroundingIDLine) { }
#pragma warning restore CS8618

    public FormTableGroundingIDLine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTableGroundingIDLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableGroundingIDLineFromRaw.FromRawUnchecked"/>
    public static FormTableGroundingIDLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormTableGroundingIDLineFromRaw : IFromRawJson<FormTableGroundingIDLine>
{
    /// <inheritdoc/>
    public FormTableGroundingIDLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormTableGroundingIDLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FormTableGroundingIDLineWord, FormTableGroundingIDLineWordFromRaw>)
)]
public sealed record class FormTableGroundingIDLineWord : JsonModel
{
    /// <summary>
    /// Word bounding box
    /// </summary>
    public required BBox Bbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BBox>("bbox");
        }
        init { this._rawData.Set("bbox", value); }
    }

    /// <summary>
    /// `[start, end)` UTF-8 byte span in the complete source property string
    /// </summary>
    public required IReadOnlyList<JsonElement> Span
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JsonElement>>("span");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JsonElement>>(
                "span",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Bbox.Validate();
        _ = this.Span;
    }

    public FormTableGroundingIDLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTableGroundingIDLineWord(FormTableGroundingIDLineWord formTableGroundingIDLineWord)
        : base(formTableGroundingIDLineWord) { }
#pragma warning restore CS8618

    public FormTableGroundingIDLineWord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTableGroundingIDLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableGroundingIDLineWordFromRaw.FromRawUnchecked"/>
    public static FormTableGroundingIDLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormTableGroundingIDLineWordFromRaw : IFromRawJson<FormTableGroundingIDLineWord>
{
    /// <inheritdoc/>
    public FormTableGroundingIDLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormTableGroundingIDLineWord.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Column, ColumnFromRaw>))]
public sealed record class Column : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<ColumnLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ColumnLine>>("lines");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ColumnLine>>(
                "lines",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Lines)
        {
            item.Validate();
        }
    }

    public Column() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Column(Column column)
        : base(column) { }
#pragma warning restore CS8618

    public Column(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Column(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ColumnFromRaw.FromRawUnchecked"/>
    public static Column FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Column(IReadOnlyList<ColumnLine> lines)
        : this()
    {
        this.Lines = lines;
    }
}

class ColumnFromRaw : IFromRawJson<Column>
{
    /// <inheritdoc/>
    public Column FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Column.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ColumnLine, ColumnLineFromRaw>))]
public sealed record class ColumnLine : JsonModel
{
    /// <summary>
    /// Line bounding box
    /// </summary>
    public required BBox Bbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BBox>("bbox");
        }
        init { this._rawData.Set("bbox", value); }
    }

    /// <summary>
    /// `[start, end)` UTF-8 byte span in the complete source property string
    /// </summary>
    public required IReadOnlyList<JsonElement> Span
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JsonElement>>("span");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JsonElement>>(
                "span",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Per-word grounding within the line, when available
    /// </summary>
    public IReadOnlyList<ColumnLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ColumnLineWord>>("words");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ColumnLineWord>?>(
                "words",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Bbox.Validate();
        _ = this.Span;
        foreach (var item in this.Words ?? [])
        {
            item.Validate();
        }
    }

    public ColumnLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ColumnLine(ColumnLine columnLine)
        : base(columnLine) { }
#pragma warning restore CS8618

    public ColumnLine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ColumnLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ColumnLineFromRaw.FromRawUnchecked"/>
    public static ColumnLine FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ColumnLineFromRaw : IFromRawJson<ColumnLine>
{
    /// <inheritdoc/>
    public ColumnLine FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ColumnLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ColumnLineWord, ColumnLineWordFromRaw>))]
public sealed record class ColumnLineWord : JsonModel
{
    /// <summary>
    /// Word bounding box
    /// </summary>
    public required BBox Bbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BBox>("bbox");
        }
        init { this._rawData.Set("bbox", value); }
    }

    /// <summary>
    /// `[start, end)` UTF-8 byte span in the complete source property string
    /// </summary>
    public required IReadOnlyList<JsonElement> Span
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JsonElement>>("span");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JsonElement>>(
                "span",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Bbox.Validate();
        _ = this.Span;
    }

    public ColumnLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ColumnLineWord(ColumnLineWord columnLineWord)
        : base(columnLineWord) { }
#pragma warning restore CS8618

    public ColumnLineWord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ColumnLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ColumnLineWordFromRaw.FromRawUnchecked"/>
    public static ColumnLineWord FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ColumnLineWordFromRaw : IFromRawJson<ColumnLineWord>
{
    /// <inheritdoc/>
    public ColumnLineWord FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ColumnLineWord.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FormTableGroundingLabel, FormTableGroundingLabelFromRaw>))]
public sealed record class FormTableGroundingLabel : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<FormTableGroundingLabelLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FormTableGroundingLabelLine>>(
                "lines"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormTableGroundingLabelLine>>(
                "lines",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Lines)
        {
            item.Validate();
        }
    }

    public FormTableGroundingLabel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTableGroundingLabel(FormTableGroundingLabel formTableGroundingLabel)
        : base(formTableGroundingLabel) { }
#pragma warning restore CS8618

    public FormTableGroundingLabel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTableGroundingLabel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableGroundingLabelFromRaw.FromRawUnchecked"/>
    public static FormTableGroundingLabel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FormTableGroundingLabel(IReadOnlyList<FormTableGroundingLabelLine> lines)
        : this()
    {
        this.Lines = lines;
    }
}

class FormTableGroundingLabelFromRaw : IFromRawJson<FormTableGroundingLabel>
{
    /// <inheritdoc/>
    public FormTableGroundingLabel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormTableGroundingLabel.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FormTableGroundingLabelLine, FormTableGroundingLabelLineFromRaw>)
)]
public sealed record class FormTableGroundingLabelLine : JsonModel
{
    /// <summary>
    /// Line bounding box
    /// </summary>
    public required BBox Bbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BBox>("bbox");
        }
        init { this._rawData.Set("bbox", value); }
    }

    /// <summary>
    /// `[start, end)` UTF-8 byte span in the complete source property string
    /// </summary>
    public required IReadOnlyList<JsonElement> Span
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JsonElement>>("span");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JsonElement>>(
                "span",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Per-word grounding within the line, when available
    /// </summary>
    public IReadOnlyList<FormTableGroundingLabelLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FormTableGroundingLabelLineWord>>(
                "words"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormTableGroundingLabelLineWord>?>(
                "words",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Bbox.Validate();
        _ = this.Span;
        foreach (var item in this.Words ?? [])
        {
            item.Validate();
        }
    }

    public FormTableGroundingLabelLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTableGroundingLabelLine(FormTableGroundingLabelLine formTableGroundingLabelLine)
        : base(formTableGroundingLabelLine) { }
#pragma warning restore CS8618

    public FormTableGroundingLabelLine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTableGroundingLabelLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableGroundingLabelLineFromRaw.FromRawUnchecked"/>
    public static FormTableGroundingLabelLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormTableGroundingLabelLineFromRaw : IFromRawJson<FormTableGroundingLabelLine>
{
    /// <inheritdoc/>
    public FormTableGroundingLabelLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormTableGroundingLabelLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FormTableGroundingLabelLineWord,
        FormTableGroundingLabelLineWordFromRaw
    >)
)]
public sealed record class FormTableGroundingLabelLineWord : JsonModel
{
    /// <summary>
    /// Word bounding box
    /// </summary>
    public required BBox Bbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BBox>("bbox");
        }
        init { this._rawData.Set("bbox", value); }
    }

    /// <summary>
    /// `[start, end)` UTF-8 byte span in the complete source property string
    /// </summary>
    public required IReadOnlyList<JsonElement> Span
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JsonElement>>("span");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JsonElement>>(
                "span",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Bbox.Validate();
        _ = this.Span;
    }

    public FormTableGroundingLabelLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTableGroundingLabelLineWord(
        FormTableGroundingLabelLineWord formTableGroundingLabelLineWord
    )
        : base(formTableGroundingLabelLineWord) { }
#pragma warning restore CS8618

    public FormTableGroundingLabelLineWord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTableGroundingLabelLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableGroundingLabelLineWordFromRaw.FromRawUnchecked"/>
    public static FormTableGroundingLabelLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormTableGroundingLabelLineWordFromRaw : IFromRawJson<FormTableGroundingLabelLineWord>
{
    /// <inheritdoc/>
    public FormTableGroundingLabelLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormTableGroundingLabelLineWord.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FormTextGrounding, FormTextGroundingFromRaw>))]
public sealed record class FormTextGrounding : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<FormTextGroundingLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FormTextGroundingLine>>("lines");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormTextGroundingLine>>(
                "lines",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Lines)
        {
            item.Validate();
        }
    }

    public FormTextGrounding() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTextGrounding(FormTextGrounding formTextGrounding)
        : base(formTextGrounding) { }
#pragma warning restore CS8618

    public FormTextGrounding(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTextGrounding(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTextGroundingFromRaw.FromRawUnchecked"/>
    public static FormTextGrounding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FormTextGrounding(IReadOnlyList<FormTextGroundingLine> lines)
        : this()
    {
        this.Lines = lines;
    }
}

class FormTextGroundingFromRaw : IFromRawJson<FormTextGrounding>
{
    /// <inheritdoc/>
    public FormTextGrounding FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FormTextGrounding.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FormTextGroundingLine, FormTextGroundingLineFromRaw>))]
public sealed record class FormTextGroundingLine : JsonModel
{
    /// <summary>
    /// Line bounding box
    /// </summary>
    public required BBox Bbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BBox>("bbox");
        }
        init { this._rawData.Set("bbox", value); }
    }

    /// <summary>
    /// `[start, end)` UTF-8 byte span in the complete source property string
    /// </summary>
    public required IReadOnlyList<JsonElement> Span
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JsonElement>>("span");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JsonElement>>(
                "span",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Per-word grounding within the line, when available
    /// </summary>
    public IReadOnlyList<FormTextGroundingLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FormTextGroundingLineWord>>(
                "words"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormTextGroundingLineWord>?>(
                "words",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Bbox.Validate();
        _ = this.Span;
        foreach (var item in this.Words ?? [])
        {
            item.Validate();
        }
    }

    public FormTextGroundingLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTextGroundingLine(FormTextGroundingLine formTextGroundingLine)
        : base(formTextGroundingLine) { }
#pragma warning restore CS8618

    public FormTextGroundingLine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTextGroundingLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTextGroundingLineFromRaw.FromRawUnchecked"/>
    public static FormTextGroundingLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormTextGroundingLineFromRaw : IFromRawJson<FormTextGroundingLine>
{
    /// <inheritdoc/>
    public FormTextGroundingLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormTextGroundingLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FormTextGroundingLineWord, FormTextGroundingLineWordFromRaw>)
)]
public sealed record class FormTextGroundingLineWord : JsonModel
{
    /// <summary>
    /// Word bounding box
    /// </summary>
    public required BBox Bbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BBox>("bbox");
        }
        init { this._rawData.Set("bbox", value); }
    }

    /// <summary>
    /// `[start, end)` UTF-8 byte span in the complete source property string
    /// </summary>
    public required IReadOnlyList<JsonElement> Span
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JsonElement>>("span");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JsonElement>>(
                "span",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Bbox.Validate();
        _ = this.Span;
    }

    public FormTextGroundingLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTextGroundingLineWord(FormTextGroundingLineWord formTextGroundingLineWord)
        : base(formTextGroundingLineWord) { }
#pragma warning restore CS8618

    public FormTextGroundingLineWord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTextGroundingLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTextGroundingLineWordFromRaw.FromRawUnchecked"/>
    public static FormTextGroundingLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormTextGroundingLineWordFromRaw : IFromRawJson<FormTextGroundingLineWord>
{
    /// <inheritdoc/>
    public FormTextGroundingLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormTextGroundingLineWord.FromRawUnchecked(rawData);
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
