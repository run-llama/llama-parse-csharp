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
/// One form detected on a page, in two representations of the same content.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Form, FormFromRaw>))]
public sealed record class Form : JsonModel
{
    /// <summary>
    /// Structured representation: an ordered tree of sections, fields, and tables
    /// </summary>
    public required IReadOnlyList<FormJson> Json
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FormJson>>("json");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormJson>>(
                "json",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Flattened list representation of the same content
    /// </summary>
    public required FormListItem List
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FormListItem>("list");
        }
        init { this._rawData.Set("list", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Json)
        {
            item.Validate();
        }
        this.List.Validate();
    }

    public Form() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Form(Form form)
        : base(form) { }
#pragma warning restore CS8618

    public Form(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Form(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormFromRaw.FromRawUnchecked"/>
    public static Form FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormFromRaw : IFromRawJson<Form>
{
    /// <inheritdoc/>
    public Form FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Form.FromRawUnchecked(rawData);
}

/// <summary>
/// One labeled form entry: a text input, checkbox, select group, or signature line.
/// </summary>
[JsonConverter(typeof(FormJsonConverter))]
public record class FormJson : ModelBase
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

    public FormJson(FormField value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FormJson(FormSection value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FormJson(FormTable value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FormJson(Text value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FormJson(JsonElement element)
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
    /// type <see cref="Text"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickText(out var value)) {
    ///     // `value` is of type `Text`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickText([NotNullWhen(true)] out Text? value)
    {
        value = this.Value as Text;
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
    ///     (Text value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<FormField> formField,
        System::Action<FormSection> formSection,
        System::Action<FormTable> formTable,
        System::Action<Text> text
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
            case Text value:
                text(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of FormJson"
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
    ///     (Text value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<FormField, T> formField,
        System::Func<FormSection, T> formSection,
        System::Func<FormTable, T> formTable,
        System::Func<Text, T> text
    )
    {
        return this.Value switch
        {
            FormField value => formField(value),
            FormSection value => formSection(value),
            FormTable value => formTable(value),
            Text value => text(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of FormJson"
            ),
        };
    }

    public static implicit operator FormJson(FormField value) => new(value);

    public static implicit operator FormJson(FormSection value) => new(value);

    public static implicit operator FormJson(FormTable value) => new(value);

    public static implicit operator FormJson(Text value) => new(value);

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
            throw new LlamaCloudInvalidDataException("Data did not match any variant of FormJson");
        }
        this.Switch(
            (formField) => formField.Validate(),
            (formSection) => formSection.Validate(),
            (formTable) => formTable.Validate(),
            (text) => text.Validate()
        );
    }

    public virtual bool Equals(FormJson? other) =>
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
            Text _ => 3,
            _ => -1,
        };
    }
}

sealed class FormJsonConverter : JsonConverter<FormJson>
{
    public override FormJson? Read(
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
                    var deserialized = JsonSerializer.Deserialize<Text>(element, options);
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
                return new FormJson(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, FormJson value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Printed text that is not part of a field, section heading or table: a title, an
/// instruction, a note. With it the form JSON holds every printed word of its region.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Text, TextFromRaw>))]
public sealed record class Text : JsonModel
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
    public Grounding? Grounding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Grounding>("grounding");
        }
        init { this._rawData.Set("grounding", value); }
    }

    /// <summary>
    /// Form text node
    /// </summary>
    public ApiEnum<string, TextType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TextType>>("type");
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

    public Text() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Text(Text text)
        : base(text) { }
#pragma warning restore CS8618

    public Text(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Text(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextFromRaw.FromRawUnchecked"/>
    public static Text FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Text(string value)
        : this()
    {
        this.Value = value;
    }
}

class TextFromRaw : IFromRawJson<Text>
{
    /// <inheritdoc/>
    public Text FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Text.FromRawUnchecked(rawData);
}

/// <summary>
/// Optional grounding for a field's printed text; boolean states have no text spans.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Grounding, GroundingFromRaw>))]
public sealed record class Grounding : JsonModel
{
    /// <summary>
    /// Supported text with half-open UTF-8 byte spans into the complete property string.
    /// </summary>
    public ID? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ID>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Supported text with half-open UTF-8 byte spans into the complete property string.
    /// </summary>
    public Label? Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Label>("label");
        }
        init { this._rawData.Set("label", value); }
    }

    /// <summary>
    /// Supported text with half-open UTF-8 byte spans into the complete property string.
    /// </summary>
    public Value? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Value>("value");
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

    public Grounding() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Grounding(Grounding grounding)
        : base(grounding) { }
#pragma warning restore CS8618

    public Grounding(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Grounding(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroundingFromRaw.FromRawUnchecked"/>
    public static Grounding FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroundingFromRaw : IFromRawJson<Grounding>
{
    /// <inheritdoc/>
    public Grounding FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Grounding.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ID, IDFromRaw>))]
public sealed record class ID : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<Line> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Line>>("lines");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Line>>(
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

    public ID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ID(ID id)
        : base(id) { }
#pragma warning restore CS8618

    public ID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IDFromRaw.FromRawUnchecked"/>
    public static ID FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ID(IReadOnlyList<Line> lines)
        : this()
    {
        this.Lines = lines;
    }
}

class IDFromRaw : IFromRawJson<ID>
{
    /// <inheritdoc/>
    public ID FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ID.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Line, LineFromRaw>))]
public sealed record class Line : JsonModel
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
    public IReadOnlyList<Word>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Word>>("words");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Word>?>(
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

    public Line() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Line(Line line)
        : base(line) { }
#pragma warning restore CS8618

    public Line(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Line(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LineFromRaw.FromRawUnchecked"/>
    public static Line FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LineFromRaw : IFromRawJson<Line>
{
    /// <inheritdoc/>
    public Line FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Line.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Word, WordFromRaw>))]
public sealed record class Word : JsonModel
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

    public Word() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Word(Word word)
        : base(word) { }
#pragma warning restore CS8618

    public Word(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Word(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WordFromRaw.FromRawUnchecked"/>
    public static Word FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WordFromRaw : IFromRawJson<Word>
{
    /// <inheritdoc/>
    public Word FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Word.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Label, LabelFromRaw>))]
public sealed record class Label : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<LabelLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<LabelLine>>("lines");
        }
        init
        {
            this._rawData.Set<ImmutableArray<LabelLine>>(
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

    public Label() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Label(Label label)
        : base(label) { }
#pragma warning restore CS8618

    public Label(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Label(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LabelFromRaw.FromRawUnchecked"/>
    public static Label FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Label(IReadOnlyList<LabelLine> lines)
        : this()
    {
        this.Lines = lines;
    }
}

class LabelFromRaw : IFromRawJson<Label>
{
    /// <inheritdoc/>
    public Label FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Label.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LabelLine, LabelLineFromRaw>))]
public sealed record class LabelLine : JsonModel
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
    public IReadOnlyList<LabelLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<LabelLineWord>>("words");
        }
        init
        {
            this._rawData.Set<ImmutableArray<LabelLineWord>?>(
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

    public LabelLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LabelLine(LabelLine labelLine)
        : base(labelLine) { }
#pragma warning restore CS8618

    public LabelLine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LabelLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LabelLineFromRaw.FromRawUnchecked"/>
    public static LabelLine FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LabelLineFromRaw : IFromRawJson<LabelLine>
{
    /// <inheritdoc/>
    public LabelLine FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LabelLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LabelLineWord, LabelLineWordFromRaw>))]
public sealed record class LabelLineWord : JsonModel
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

    public LabelLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LabelLineWord(LabelLineWord labelLineWord)
        : base(labelLineWord) { }
#pragma warning restore CS8618

    public LabelLineWord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LabelLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LabelLineWordFromRaw.FromRawUnchecked"/>
    public static LabelLineWord FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LabelLineWordFromRaw : IFromRawJson<LabelLineWord>
{
    /// <inheritdoc/>
    public LabelLineWord FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LabelLineWord.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Value, ValueFromRaw>))]
public sealed record class Value : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<ValueLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ValueLine>>("lines");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ValueLine>>(
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

    public Value() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Value(Value value)
        : base(value) { }
#pragma warning restore CS8618

    public Value(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Value(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValueFromRaw.FromRawUnchecked"/>
    public static Value FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Value(IReadOnlyList<ValueLine> lines)
        : this()
    {
        this.Lines = lines;
    }
}

class ValueFromRaw : IFromRawJson<Value>
{
    /// <inheritdoc/>
    public Value FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Value.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ValueLine, ValueLineFromRaw>))]
public sealed record class ValueLine : JsonModel
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
    public IReadOnlyList<ValueLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ValueLineWord>>("words");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ValueLineWord>?>(
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

    public ValueLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ValueLine(ValueLine valueLine)
        : base(valueLine) { }
#pragma warning restore CS8618

    public ValueLine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValueLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValueLineFromRaw.FromRawUnchecked"/>
    public static ValueLine FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ValueLineFromRaw : IFromRawJson<ValueLine>
{
    /// <inheritdoc/>
    public ValueLine FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ValueLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ValueLineWord, ValueLineWordFromRaw>))]
public sealed record class ValueLineWord : JsonModel
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

    public ValueLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ValueLineWord(ValueLineWord valueLineWord)
        : base(valueLineWord) { }
#pragma warning restore CS8618

    public ValueLineWord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValueLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValueLineWordFromRaw.FromRawUnchecked"/>
    public static ValueLineWord FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ValueLineWordFromRaw : IFromRawJson<ValueLineWord>
{
    /// <inheritdoc/>
    public ValueLineWord FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ValueLineWord.FromRawUnchecked(rawData);
}

/// <summary>
/// Form text node
/// </summary>
[JsonConverter(typeof(TextTypeConverter))]
public enum TextType
{
    Text,
}

sealed class TextTypeConverter : JsonConverter<TextType>
{
    public override TextType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => TextType.Text,
            _ => (TextType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, TextType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TextType.Text => "text",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
