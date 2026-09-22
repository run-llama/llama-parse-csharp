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
/// A grouping of form content, in the form's reading order.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FormSection, FormSectionFromRaw>))]
public sealed record class FormSection : JsonModel
{
    /// <summary>
    /// Child form nodes in reading order
    /// </summary>
    public required IReadOnlyList<FormSectionItem> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FormSectionItem>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormSectionItem>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Identifier printed on the form (e.g. 'Part III'), if any
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
    /// Optional grounding for printed identifiers and headings.
    /// </summary>
    public FormSectionGrounding? Grounding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FormSectionGrounding>("grounding");
        }
        init { this._rawData.Set("grounding", value); }
    }

    /// <summary>
    /// Printed section heading, if any
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
    /// Form section node
    /// </summary>
    public ApiEnum<string, FormSectionType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FormSectionType>>("type");
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
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.ID;
        this.Grounding?.Validate();
        _ = this.Label;
        this.Type?.Validate();
    }

    public FormSection() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormSection(FormSection formSection)
        : base(formSection) { }
#pragma warning restore CS8618

    public FormSection(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormSection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormSectionFromRaw.FromRawUnchecked"/>
    public static FormSection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FormSection(IReadOnlyList<FormSectionItem> items)
        : this()
    {
        this.Items = items;
    }
}

class FormSectionFromRaw : IFromRawJson<FormSection>
{
    /// <inheritdoc/>
    public FormSection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FormSection.FromRawUnchecked(rawData);
}

/// <summary>
/// One labeled form entry: a text input, checkbox, select group, or signature line.
/// </summary>
[JsonConverter(typeof(FormSectionItemConverter))]
public record class FormSectionItem : ModelBase
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
                formTable: (x) => x.ID
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
                formTable: (x) => x.Label
            );
        }
    }

    public FormSectionItem(FormField value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FormSectionItem(FormSection value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FormSectionItem(FormTable value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FormSectionItem(JsonElement element)
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
    ///     (FormTable value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<FormField> formField,
        System::Action<FormSection> formSection,
        System::Action<FormTable> formTable
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
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of FormSectionItem"
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
    ///     (FormTable value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<FormField, T> formField,
        System::Func<FormSection, T> formSection,
        System::Func<FormTable, T> formTable
    )
    {
        return this.Value switch
        {
            FormField value => formField(value),
            FormSection value => formSection(value),
            FormTable value => formTable(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of FormSectionItem"
            ),
        };
    }

    public static implicit operator FormSectionItem(FormField value) => new(value);

    public static implicit operator FormSectionItem(FormSection value) => new(value);

    public static implicit operator FormSectionItem(FormTable value) => new(value);

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
                "Data did not match any variant of FormSectionItem"
            );
        }
        this.Switch(
            (formField) => formField.Validate(),
            (formSection) => formSection.Validate(),
            (formTable) => formTable.Validate()
        );
    }

    public virtual bool Equals(FormSectionItem? other) =>
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
            _ => -1,
        };
    }
}

sealed class FormSectionItemConverter : JsonConverter<FormSectionItem>
{
    public override FormSectionItem? Read(
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
            default:
            {
                return new FormSectionItem(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        FormSectionItem value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Optional grounding for printed identifiers and headings.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FormSectionGrounding, FormSectionGroundingFromRaw>))]
public sealed record class FormSectionGrounding : JsonModel
{
    /// <summary>
    /// Supported text with half-open UTF-8 byte spans into the complete property string.
    /// </summary>
    public FormSectionGroundingID? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FormSectionGroundingID>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Supported text with half-open UTF-8 byte spans into the complete property string.
    /// </summary>
    public FormSectionGroundingLabel? Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FormSectionGroundingLabel>("label");
        }
        init { this._rawData.Set("label", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ID?.Validate();
        this.Label?.Validate();
    }

    public FormSectionGrounding() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormSectionGrounding(FormSectionGrounding formSectionGrounding)
        : base(formSectionGrounding) { }
#pragma warning restore CS8618

    public FormSectionGrounding(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormSectionGrounding(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormSectionGroundingFromRaw.FromRawUnchecked"/>
    public static FormSectionGrounding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormSectionGroundingFromRaw : IFromRawJson<FormSectionGrounding>
{
    /// <inheritdoc/>
    public FormSectionGrounding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormSectionGrounding.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FormSectionGroundingID, FormSectionGroundingIDFromRaw>))]
public sealed record class FormSectionGroundingID : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<FormSectionGroundingIDLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FormSectionGroundingIDLine>>(
                "lines"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormSectionGroundingIDLine>>(
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

    public FormSectionGroundingID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormSectionGroundingID(FormSectionGroundingID formSectionGroundingID)
        : base(formSectionGroundingID) { }
#pragma warning restore CS8618

    public FormSectionGroundingID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormSectionGroundingID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormSectionGroundingIDFromRaw.FromRawUnchecked"/>
    public static FormSectionGroundingID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FormSectionGroundingID(IReadOnlyList<FormSectionGroundingIDLine> lines)
        : this()
    {
        this.Lines = lines;
    }
}

class FormSectionGroundingIDFromRaw : IFromRawJson<FormSectionGroundingID>
{
    /// <inheritdoc/>
    public FormSectionGroundingID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormSectionGroundingID.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FormSectionGroundingIDLine, FormSectionGroundingIDLineFromRaw>)
)]
public sealed record class FormSectionGroundingIDLine : JsonModel
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
    public IReadOnlyList<FormSectionGroundingIDLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FormSectionGroundingIDLineWord>>(
                "words"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormSectionGroundingIDLineWord>?>(
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

    public FormSectionGroundingIDLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormSectionGroundingIDLine(FormSectionGroundingIDLine formSectionGroundingIDLine)
        : base(formSectionGroundingIDLine) { }
#pragma warning restore CS8618

    public FormSectionGroundingIDLine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormSectionGroundingIDLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormSectionGroundingIDLineFromRaw.FromRawUnchecked"/>
    public static FormSectionGroundingIDLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormSectionGroundingIDLineFromRaw : IFromRawJson<FormSectionGroundingIDLine>
{
    /// <inheritdoc/>
    public FormSectionGroundingIDLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormSectionGroundingIDLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FormSectionGroundingIDLineWord,
        FormSectionGroundingIDLineWordFromRaw
    >)
)]
public sealed record class FormSectionGroundingIDLineWord : JsonModel
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

    public FormSectionGroundingIDLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormSectionGroundingIDLineWord(
        FormSectionGroundingIDLineWord formSectionGroundingIDLineWord
    )
        : base(formSectionGroundingIDLineWord) { }
#pragma warning restore CS8618

    public FormSectionGroundingIDLineWord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormSectionGroundingIDLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormSectionGroundingIDLineWordFromRaw.FromRawUnchecked"/>
    public static FormSectionGroundingIDLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormSectionGroundingIDLineWordFromRaw : IFromRawJson<FormSectionGroundingIDLineWord>
{
    /// <inheritdoc/>
    public FormSectionGroundingIDLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormSectionGroundingIDLineWord.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FormSectionGroundingLabel, FormSectionGroundingLabelFromRaw>)
)]
public sealed record class FormSectionGroundingLabel : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<FormSectionGroundingLabelLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FormSectionGroundingLabelLine>>(
                "lines"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormSectionGroundingLabelLine>>(
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

    public FormSectionGroundingLabel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormSectionGroundingLabel(FormSectionGroundingLabel formSectionGroundingLabel)
        : base(formSectionGroundingLabel) { }
#pragma warning restore CS8618

    public FormSectionGroundingLabel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormSectionGroundingLabel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormSectionGroundingLabelFromRaw.FromRawUnchecked"/>
    public static FormSectionGroundingLabel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FormSectionGroundingLabel(IReadOnlyList<FormSectionGroundingLabelLine> lines)
        : this()
    {
        this.Lines = lines;
    }
}

class FormSectionGroundingLabelFromRaw : IFromRawJson<FormSectionGroundingLabel>
{
    /// <inheritdoc/>
    public FormSectionGroundingLabel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormSectionGroundingLabel.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FormSectionGroundingLabelLine, FormSectionGroundingLabelLineFromRaw>)
)]
public sealed record class FormSectionGroundingLabelLine : JsonModel
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
    public IReadOnlyList<FormSectionGroundingLabelLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FormSectionGroundingLabelLineWord>
            >("words");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormSectionGroundingLabelLineWord>?>(
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

    public FormSectionGroundingLabelLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormSectionGroundingLabelLine(
        FormSectionGroundingLabelLine formSectionGroundingLabelLine
    )
        : base(formSectionGroundingLabelLine) { }
#pragma warning restore CS8618

    public FormSectionGroundingLabelLine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormSectionGroundingLabelLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormSectionGroundingLabelLineFromRaw.FromRawUnchecked"/>
    public static FormSectionGroundingLabelLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormSectionGroundingLabelLineFromRaw : IFromRawJson<FormSectionGroundingLabelLine>
{
    /// <inheritdoc/>
    public FormSectionGroundingLabelLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormSectionGroundingLabelLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FormSectionGroundingLabelLineWord,
        FormSectionGroundingLabelLineWordFromRaw
    >)
)]
public sealed record class FormSectionGroundingLabelLineWord : JsonModel
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

    public FormSectionGroundingLabelLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormSectionGroundingLabelLineWord(
        FormSectionGroundingLabelLineWord formSectionGroundingLabelLineWord
    )
        : base(formSectionGroundingLabelLineWord) { }
#pragma warning restore CS8618

    public FormSectionGroundingLabelLineWord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormSectionGroundingLabelLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormSectionGroundingLabelLineWordFromRaw.FromRawUnchecked"/>
    public static FormSectionGroundingLabelLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormSectionGroundingLabelLineWordFromRaw : IFromRawJson<FormSectionGroundingLabelLineWord>
{
    /// <inheritdoc/>
    public FormSectionGroundingLabelLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormSectionGroundingLabelLineWord.FromRawUnchecked(rawData);
}

/// <summary>
/// Form section node
/// </summary>
[JsonConverter(typeof(FormSectionTypeConverter))]
public enum FormSectionType
{
    Section,
}

sealed class FormSectionTypeConverter : JsonConverter<FormSectionType>
{
    public override FormSectionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "section" => FormSectionType.Section,
            _ => (FormSectionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FormSectionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FormSectionType.Section => "section",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
