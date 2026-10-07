using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Parsing;

/// <summary>
/// A table cell holding its own form nodes (e.g. a checkbox column).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FormTableCellItems, FormTableCellItemsFromRaw>))]
public sealed record class FormTableCellItems : JsonModel
{
    /// <summary>
    /// Form nodes inside the cell
    /// </summary>
    public required IReadOnlyList<FormTableCellItemsItem> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FormTableCellItemsItem>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormTableCellItemsItem>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public FormTableCellItems() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTableCellItems(FormTableCellItems formTableCellItems)
        : base(formTableCellItems) { }
#pragma warning restore CS8618

    public FormTableCellItems(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTableCellItems(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableCellItemsFromRaw.FromRawUnchecked"/>
    public static FormTableCellItems FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FormTableCellItems(IReadOnlyList<FormTableCellItemsItem> items)
        : this()
    {
        this.Items = items;
    }
}

class FormTableCellItemsFromRaw : IFromRawJson<FormTableCellItems>
{
    /// <inheritdoc/>
    public FormTableCellItems FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FormTableCellItems.FromRawUnchecked(rawData);
}

/// <summary>
/// One labeled form entry: a text input, checkbox, select group, or signature line.
/// </summary>
[JsonConverter(typeof(FormTableCellItemsItemConverter))]
public record class FormTableCellItemsItem : ModelBase
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

    public string? ID
    {
        get
        {
            return Match<string?>(
                formField: (x) => x.ID,
                formSection: (x) => x.ID,
                formTable: (x) => x.ID,
                text: (_) => null
            );
        }
    }

    public string? Label
    {
        get
        {
            return Match<string?>(
                formField: (x) => x.Label,
                formSection: (x) => x.Label,
                formTable: (x) => x.Label,
                text: (_) => null
            );
        }
    }

    public FormTableCellItemsItem(FormField value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FormTableCellItemsItem(FormSection value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FormTableCellItemsItem(FormTable value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FormTableCellItemsItem(FormTableCellItemsItemText value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FormTableCellItemsItem(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FormField"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFormField(out var value)) {
    ///     // `value` is of type `FormField`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFormField([NotNullWhen(true)] out FormField? value)
    {
        value = this.Value as FormField;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FormSection"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFormSection(out var value)) {
    ///     // `value` is of type `FormSection`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFormSection([NotNullWhen(true)] out FormSection? value)
    {
        value = this.Value as FormSection;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FormTable"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFormTable(out var value)) {
    ///     // `value` is of type `FormTable`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFormTable([NotNullWhen(true)] out FormTable? value)
    {
        value = this.Value as FormTable;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FormTableCellItemsItemText"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickText(out var value)) {
    ///     // `value` is of type `FormTableCellItemsItemText`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickText([NotNullWhen(true)] out FormTableCellItemsItemText? value)
    {
        value = this.Value as FormTableCellItemsItemText;
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
    ///     (FormField value) =&gt; {...},
    ///     (FormSection value) =&gt; {...},
    ///     (FormTable value) =&gt; {...},
    ///     (FormTableCellItemsItemText value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<FormField> formField,
        System::Action<FormSection> formSection,
        System::Action<FormTable> formTable,
        System::Action<FormTableCellItemsItemText> text
    )
    {
        switch (this.Value)
        {
            case FormField value:
                formField(value);
                break;
            case FormSection value:
                formSection(value);
                break;
            case FormTable value:
                formTable(value);
                break;
            case FormTableCellItemsItemText value:
                text(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of FormTableCellItemsItem"
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
    ///     (FormField value) =&gt; {...},
    ///     (FormSection value) =&gt; {...},
    ///     (FormTable value) =&gt; {...},
    ///     (FormTableCellItemsItemText value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<FormField, T> formField,
        System::Func<FormSection, T> formSection,
        System::Func<FormTable, T> formTable,
        System::Func<FormTableCellItemsItemText, T> text
    )
    {
        return this.Value switch
        {
            FormField value => formField(value),
            FormSection value => formSection(value),
            FormTable value => formTable(value),
            FormTableCellItemsItemText value => text(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of FormTableCellItemsItem"
            ),
        };
    }

    public static implicit operator FormTableCellItemsItem(FormField value) => new(value);

    public static implicit operator FormTableCellItemsItem(FormSection value) => new(value);

    public static implicit operator FormTableCellItemsItem(FormTable value) => new(value);

    public static implicit operator FormTableCellItemsItem(FormTableCellItemsItemText value) =>
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
                "Data did not match any variant of FormTableCellItemsItem"
            );
        }
        this.Switch(
            (formField) => formField.Validate(),
            (formSection) => formSection.Validate(),
            (formTable) => formTable.Validate(),
            (text) => text.Validate()
        );
    }

    public virtual bool Equals(FormTableCellItemsItem? other) =>
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
            FormField _ => 0,
            FormSection _ => 1,
            FormTable _ => 2,
            FormTableCellItemsItemText _ => 3,
            _ => -1,
        };
    }
}

sealed class FormTableCellItemsItemConverter : JsonConverter<FormTableCellItemsItem>
{
    public override FormTableCellItemsItem? Read(
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
            case "field":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<FormField>(element, options);
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
            case "section":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<FormSection>(element, options);
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
            case "table":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<FormTable>(element, options);
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
            case "text":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItemText>(
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
                return new FormTableCellItemsItem(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        FormTableCellItemsItem value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Printed text that is not part of a field, section heading or table: a title, an
/// instruction, a note. With it the form JSON holds every printed word of its region.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FormTableCellItemsItemText, FormTableCellItemsItemTextFromRaw>)
)]
public sealed record class FormTableCellItemsItemText : JsonModel
{
    /// <summary>
    /// The printed text, verbatim
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <summary>
    /// Bounding boxes of the text on the page, if attributed.
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
    /// Optional grounding for a field's printed text; boolean states have no text spans.
    /// </summary>
    public FormTableCellItemsItemTextGrounding? Grounding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FormTableCellItemsItemTextGrounding>("grounding");
        }
        init { this._rawData.Set("grounding", value); }
    }

    /// <summary>
    /// Form text node
    /// </summary>
    public ApiEnum<string, FormTableCellItemsItemTextType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FormTableCellItemsItemTextType>>(
                "type"
            );
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
        _ = this.Value;
        foreach (var item in this.Bbox ?? [])
        {
            item.Validate();
        }
        this.Grounding?.Validate();
        this.Type?.Validate();
    }

    public FormTableCellItemsItemText() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTableCellItemsItemText(FormTableCellItemsItemText formTableCellItemsItemText)
        : base(formTableCellItemsItemText) { }
#pragma warning restore CS8618

    public FormTableCellItemsItemText(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTableCellItemsItemText(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableCellItemsItemTextFromRaw.FromRawUnchecked"/>
    public static FormTableCellItemsItemText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FormTableCellItemsItemText(string value)
        : this()
    {
        this.Value = value;
    }
}

class FormTableCellItemsItemTextFromRaw : IFromRawJson<FormTableCellItemsItemText>
{
    /// <inheritdoc/>
    public FormTableCellItemsItemText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormTableCellItemsItemText.FromRawUnchecked(rawData);
}

/// <summary>
/// Optional grounding for a field's printed text; boolean states have no text spans.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FormTableCellItemsItemTextGrounding,
        FormTableCellItemsItemTextGroundingFromRaw
    >)
)]
public sealed record class FormTableCellItemsItemTextGrounding : JsonModel
{
    /// <summary>
    /// Supported text with half-open UTF-8 byte spans into the complete property string.
    /// </summary>
    public FormTableCellItemsItemTextGroundingID? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FormTableCellItemsItemTextGroundingID>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Supported text with half-open UTF-8 byte spans into the complete property string.
    /// </summary>
    public FormTableCellItemsItemTextGroundingLabel? Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FormTableCellItemsItemTextGroundingLabel>(
                "label"
            );
        }
        init { this._rawData.Set("label", value); }
    }

    /// <summary>
    /// Supported text with half-open UTF-8 byte spans into the complete property string.
    /// </summary>
    public FormTableCellItemsItemTextGroundingValue? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FormTableCellItemsItemTextGroundingValue>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ID?.Validate();
        this.Label?.Validate();
        this.Value?.Validate();
    }

    public FormTableCellItemsItemTextGrounding() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTableCellItemsItemTextGrounding(
        FormTableCellItemsItemTextGrounding formTableCellItemsItemTextGrounding
    )
        : base(formTableCellItemsItemTextGrounding) { }
#pragma warning restore CS8618

    public FormTableCellItemsItemTextGrounding(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTableCellItemsItemTextGrounding(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableCellItemsItemTextGroundingFromRaw.FromRawUnchecked"/>
    public static FormTableCellItemsItemTextGrounding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormTableCellItemsItemTextGroundingFromRaw : IFromRawJson<FormTableCellItemsItemTextGrounding>
{
    /// <inheritdoc/>
    public FormTableCellItemsItemTextGrounding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormTableCellItemsItemTextGrounding.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FormTableCellItemsItemTextGroundingID,
        FormTableCellItemsItemTextGroundingIDFromRaw
    >)
)]
public sealed record class FormTableCellItemsItemTextGroundingID : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<FormTableCellItemsItemTextGroundingIDLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<FormTableCellItemsItemTextGroundingIDLine>
            >("lines");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormTableCellItemsItemTextGroundingIDLine>>(
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

    public FormTableCellItemsItemTextGroundingID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTableCellItemsItemTextGroundingID(
        FormTableCellItemsItemTextGroundingID formTableCellItemsItemTextGroundingID
    )
        : base(formTableCellItemsItemTextGroundingID) { }
#pragma warning restore CS8618

    public FormTableCellItemsItemTextGroundingID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTableCellItemsItemTextGroundingID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableCellItemsItemTextGroundingIDFromRaw.FromRawUnchecked"/>
    public static FormTableCellItemsItemTextGroundingID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FormTableCellItemsItemTextGroundingID(
        IReadOnlyList<FormTableCellItemsItemTextGroundingIDLine> lines
    )
        : this()
    {
        this.Lines = lines;
    }
}

class FormTableCellItemsItemTextGroundingIDFromRaw
    : IFromRawJson<FormTableCellItemsItemTextGroundingID>
{
    /// <inheritdoc/>
    public FormTableCellItemsItemTextGroundingID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormTableCellItemsItemTextGroundingID.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FormTableCellItemsItemTextGroundingIDLine,
        FormTableCellItemsItemTextGroundingIDLineFromRaw
    >)
)]
public sealed record class FormTableCellItemsItemTextGroundingIDLine : JsonModel
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
    public IReadOnlyList<FormTableCellItemsItemTextGroundingIDLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FormTableCellItemsItemTextGroundingIDLineWord>
            >("words");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormTableCellItemsItemTextGroundingIDLineWord>?>(
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

    public FormTableCellItemsItemTextGroundingIDLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTableCellItemsItemTextGroundingIDLine(
        FormTableCellItemsItemTextGroundingIDLine formTableCellItemsItemTextGroundingIDLine
    )
        : base(formTableCellItemsItemTextGroundingIDLine) { }
#pragma warning restore CS8618

    public FormTableCellItemsItemTextGroundingIDLine(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTableCellItemsItemTextGroundingIDLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableCellItemsItemTextGroundingIDLineFromRaw.FromRawUnchecked"/>
    public static FormTableCellItemsItemTextGroundingIDLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormTableCellItemsItemTextGroundingIDLineFromRaw
    : IFromRawJson<FormTableCellItemsItemTextGroundingIDLine>
{
    /// <inheritdoc/>
    public FormTableCellItemsItemTextGroundingIDLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormTableCellItemsItemTextGroundingIDLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FormTableCellItemsItemTextGroundingIDLineWord,
        FormTableCellItemsItemTextGroundingIDLineWordFromRaw
    >)
)]
public sealed record class FormTableCellItemsItemTextGroundingIDLineWord : JsonModel
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

    public FormTableCellItemsItemTextGroundingIDLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTableCellItemsItemTextGroundingIDLineWord(
        FormTableCellItemsItemTextGroundingIDLineWord formTableCellItemsItemTextGroundingIDLineWord
    )
        : base(formTableCellItemsItemTextGroundingIDLineWord) { }
#pragma warning restore CS8618

    public FormTableCellItemsItemTextGroundingIDLineWord(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTableCellItemsItemTextGroundingIDLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableCellItemsItemTextGroundingIDLineWordFromRaw.FromRawUnchecked"/>
    public static FormTableCellItemsItemTextGroundingIDLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormTableCellItemsItemTextGroundingIDLineWordFromRaw
    : IFromRawJson<FormTableCellItemsItemTextGroundingIDLineWord>
{
    /// <inheritdoc/>
    public FormTableCellItemsItemTextGroundingIDLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormTableCellItemsItemTextGroundingIDLineWord.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FormTableCellItemsItemTextGroundingLabel,
        FormTableCellItemsItemTextGroundingLabelFromRaw
    >)
)]
public sealed record class FormTableCellItemsItemTextGroundingLabel : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<FormTableCellItemsItemTextGroundingLabelLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<FormTableCellItemsItemTextGroundingLabelLine>
            >("lines");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormTableCellItemsItemTextGroundingLabelLine>>(
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

    public FormTableCellItemsItemTextGroundingLabel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTableCellItemsItemTextGroundingLabel(
        FormTableCellItemsItemTextGroundingLabel formTableCellItemsItemTextGroundingLabel
    )
        : base(formTableCellItemsItemTextGroundingLabel) { }
#pragma warning restore CS8618

    public FormTableCellItemsItemTextGroundingLabel(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTableCellItemsItemTextGroundingLabel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableCellItemsItemTextGroundingLabelFromRaw.FromRawUnchecked"/>
    public static FormTableCellItemsItemTextGroundingLabel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FormTableCellItemsItemTextGroundingLabel(
        IReadOnlyList<FormTableCellItemsItemTextGroundingLabelLine> lines
    )
        : this()
    {
        this.Lines = lines;
    }
}

class FormTableCellItemsItemTextGroundingLabelFromRaw
    : IFromRawJson<FormTableCellItemsItemTextGroundingLabel>
{
    /// <inheritdoc/>
    public FormTableCellItemsItemTextGroundingLabel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormTableCellItemsItemTextGroundingLabel.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FormTableCellItemsItemTextGroundingLabelLine,
        FormTableCellItemsItemTextGroundingLabelLineFromRaw
    >)
)]
public sealed record class FormTableCellItemsItemTextGroundingLabelLine : JsonModel
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
    public IReadOnlyList<FormTableCellItemsItemTextGroundingLabelLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FormTableCellItemsItemTextGroundingLabelLineWord>
            >("words");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormTableCellItemsItemTextGroundingLabelLineWord>?>(
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

    public FormTableCellItemsItemTextGroundingLabelLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTableCellItemsItemTextGroundingLabelLine(
        FormTableCellItemsItemTextGroundingLabelLine formTableCellItemsItemTextGroundingLabelLine
    )
        : base(formTableCellItemsItemTextGroundingLabelLine) { }
#pragma warning restore CS8618

    public FormTableCellItemsItemTextGroundingLabelLine(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTableCellItemsItemTextGroundingLabelLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableCellItemsItemTextGroundingLabelLineFromRaw.FromRawUnchecked"/>
    public static FormTableCellItemsItemTextGroundingLabelLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormTableCellItemsItemTextGroundingLabelLineFromRaw
    : IFromRawJson<FormTableCellItemsItemTextGroundingLabelLine>
{
    /// <inheritdoc/>
    public FormTableCellItemsItemTextGroundingLabelLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormTableCellItemsItemTextGroundingLabelLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FormTableCellItemsItemTextGroundingLabelLineWord,
        FormTableCellItemsItemTextGroundingLabelLineWordFromRaw
    >)
)]
public sealed record class FormTableCellItemsItemTextGroundingLabelLineWord : JsonModel
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

    public FormTableCellItemsItemTextGroundingLabelLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTableCellItemsItemTextGroundingLabelLineWord(
        FormTableCellItemsItemTextGroundingLabelLineWord formTableCellItemsItemTextGroundingLabelLineWord
    )
        : base(formTableCellItemsItemTextGroundingLabelLineWord) { }
#pragma warning restore CS8618

    public FormTableCellItemsItemTextGroundingLabelLineWord(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTableCellItemsItemTextGroundingLabelLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableCellItemsItemTextGroundingLabelLineWordFromRaw.FromRawUnchecked"/>
    public static FormTableCellItemsItemTextGroundingLabelLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormTableCellItemsItemTextGroundingLabelLineWordFromRaw
    : IFromRawJson<FormTableCellItemsItemTextGroundingLabelLineWord>
{
    /// <inheritdoc/>
    public FormTableCellItemsItemTextGroundingLabelLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormTableCellItemsItemTextGroundingLabelLineWord.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FormTableCellItemsItemTextGroundingValue,
        FormTableCellItemsItemTextGroundingValueFromRaw
    >)
)]
public sealed record class FormTableCellItemsItemTextGroundingValue : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<FormTableCellItemsItemTextGroundingValueLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<FormTableCellItemsItemTextGroundingValueLine>
            >("lines");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormTableCellItemsItemTextGroundingValueLine>>(
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

    public FormTableCellItemsItemTextGroundingValue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTableCellItemsItemTextGroundingValue(
        FormTableCellItemsItemTextGroundingValue formTableCellItemsItemTextGroundingValue
    )
        : base(formTableCellItemsItemTextGroundingValue) { }
#pragma warning restore CS8618

    public FormTableCellItemsItemTextGroundingValue(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTableCellItemsItemTextGroundingValue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableCellItemsItemTextGroundingValueFromRaw.FromRawUnchecked"/>
    public static FormTableCellItemsItemTextGroundingValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FormTableCellItemsItemTextGroundingValue(
        IReadOnlyList<FormTableCellItemsItemTextGroundingValueLine> lines
    )
        : this()
    {
        this.Lines = lines;
    }
}

class FormTableCellItemsItemTextGroundingValueFromRaw
    : IFromRawJson<FormTableCellItemsItemTextGroundingValue>
{
    /// <inheritdoc/>
    public FormTableCellItemsItemTextGroundingValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormTableCellItemsItemTextGroundingValue.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FormTableCellItemsItemTextGroundingValueLine,
        FormTableCellItemsItemTextGroundingValueLineFromRaw
    >)
)]
public sealed record class FormTableCellItemsItemTextGroundingValueLine : JsonModel
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
    public IReadOnlyList<FormTableCellItemsItemTextGroundingValueLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FormTableCellItemsItemTextGroundingValueLineWord>
            >("words");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormTableCellItemsItemTextGroundingValueLineWord>?>(
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

    public FormTableCellItemsItemTextGroundingValueLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTableCellItemsItemTextGroundingValueLine(
        FormTableCellItemsItemTextGroundingValueLine formTableCellItemsItemTextGroundingValueLine
    )
        : base(formTableCellItemsItemTextGroundingValueLine) { }
#pragma warning restore CS8618

    public FormTableCellItemsItemTextGroundingValueLine(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTableCellItemsItemTextGroundingValueLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableCellItemsItemTextGroundingValueLineFromRaw.FromRawUnchecked"/>
    public static FormTableCellItemsItemTextGroundingValueLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormTableCellItemsItemTextGroundingValueLineFromRaw
    : IFromRawJson<FormTableCellItemsItemTextGroundingValueLine>
{
    /// <inheritdoc/>
    public FormTableCellItemsItemTextGroundingValueLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormTableCellItemsItemTextGroundingValueLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FormTableCellItemsItemTextGroundingValueLineWord,
        FormTableCellItemsItemTextGroundingValueLineWordFromRaw
    >)
)]
public sealed record class FormTableCellItemsItemTextGroundingValueLineWord : JsonModel
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

    public FormTableCellItemsItemTextGroundingValueLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormTableCellItemsItemTextGroundingValueLineWord(
        FormTableCellItemsItemTextGroundingValueLineWord formTableCellItemsItemTextGroundingValueLineWord
    )
        : base(formTableCellItemsItemTextGroundingValueLineWord) { }
#pragma warning restore CS8618

    public FormTableCellItemsItemTextGroundingValueLineWord(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormTableCellItemsItemTextGroundingValueLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTableCellItemsItemTextGroundingValueLineWordFromRaw.FromRawUnchecked"/>
    public static FormTableCellItemsItemTextGroundingValueLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormTableCellItemsItemTextGroundingValueLineWordFromRaw
    : IFromRawJson<FormTableCellItemsItemTextGroundingValueLineWord>
{
    /// <inheritdoc/>
    public FormTableCellItemsItemTextGroundingValueLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormTableCellItemsItemTextGroundingValueLineWord.FromRawUnchecked(rawData);
}

/// <summary>
/// Form text node
/// </summary>
[JsonConverter(typeof(FormTableCellItemsItemTextTypeConverter))]
public enum FormTableCellItemsItemTextType
{
    Text,
}

sealed class FormTableCellItemsItemTextTypeConverter : JsonConverter<FormTableCellItemsItemTextType>
{
    public override FormTableCellItemsItemTextType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => FormTableCellItemsItemTextType.Text,
            _ => (FormTableCellItemsItemTextType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FormTableCellItemsItemTextType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FormTableCellItemsItemTextType.Text => "text",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
