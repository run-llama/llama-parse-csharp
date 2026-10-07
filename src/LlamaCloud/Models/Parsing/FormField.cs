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
/// One labeled form entry: a text input, checkbox, select group, or signature line.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FormField, FormFieldFromRaw>))]
public sealed record class FormField : JsonModel
{
    /// <summary>
    /// Kind of entry: text (any free-text input), checkbox, single_select, multi_select,
    /// or signature
    /// </summary>
    public required ApiEnum<string, Field> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Field>>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Field number/letter printed on the form (e.g. '1a'), if any
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
    /// Bounding boxes of the field's fillable area on the page.
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
    public FormFieldGrounding? Grounding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FormFieldGrounding>("grounding");
        }
        init { this._rawData.Set("grounding", value); }
    }

    /// <summary>
    /// True for a printed-but-blank text field (mutually exclusive with value)
    /// </summary>
    public bool? IsEmpty
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isEmpty");
        }
        init { this._rawData.Set("isEmpty", value); }
    }

    /// <summary>
    /// Printed field caption, if any
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
    /// Form field node
    /// </summary>
    public ApiEnum<string, FormFieldType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FormFieldType>>("type");
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

    /// <summary>
    /// Entered content: verbatim text for text fields, or a boolean for checkbox
    /// (checked) and signature (signed). Absent on blank text fields and on select groups
    /// </summary>
    public FormFieldValue? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FormFieldValue>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <summary>
    /// Options of a single_select/multi_select group (only on select fields)
    /// </summary>
    public IReadOnlyList<ValueItem>? ValueItems
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ValueItem>>("valueItems");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ValueItem>?>(
                "valueItems",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Field.Validate();
        _ = this.ID;
        foreach (var item in this.Bbox ?? [])
        {
            item.Validate();
        }
        this.Grounding?.Validate();
        _ = this.IsEmpty;
        _ = this.Label;
        this.Type?.Validate();
        this.Value?.Validate();
        foreach (var item in this.ValueItems ?? [])
        {
            item.Validate();
        }
    }

    public FormField() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormField(FormField formField)
        : base(formField) { }
#pragma warning restore CS8618

    public FormField(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormField(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormFieldFromRaw.FromRawUnchecked"/>
    public static FormField FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FormField(ApiEnum<string, Field> field)
        : this()
    {
        this.Field = field;
    }
}

class FormFieldFromRaw : IFromRawJson<FormField>
{
    /// <inheritdoc/>
    public FormField FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FormField.FromRawUnchecked(rawData);
}

/// <summary>
/// Kind of entry: text (any free-text input), checkbox, single_select, multi_select,
/// or signature
/// </summary>
[JsonConverter(typeof(FieldConverter))]
public enum Field
{
    Checkbox,
    MultiSelect,
    Signature,
    SingleSelect,
    Text,
}

sealed class FieldConverter : JsonConverter<Field>
{
    public override Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "checkbox" => Field.Checkbox,
            "multi_select" => Field.MultiSelect,
            "signature" => Field.Signature,
            "single_select" => Field.SingleSelect,
            "text" => Field.Text,
            _ => (Field)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Field value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Field.Checkbox => "checkbox",
                Field.MultiSelect => "multi_select",
                Field.Signature => "signature",
                Field.SingleSelect => "single_select",
                Field.Text => "text",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Optional grounding for a field's printed text; boolean states have no text spans.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FormFieldGrounding, FormFieldGroundingFromRaw>))]
public sealed record class FormFieldGrounding : JsonModel
{
    /// <summary>
    /// Supported text with half-open UTF-8 byte spans into the complete property string.
    /// </summary>
    public FormFieldGroundingID? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FormFieldGroundingID>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Supported text with half-open UTF-8 byte spans into the complete property string.
    /// </summary>
    public FormFieldGroundingLabel? Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FormFieldGroundingLabel>("label");
        }
        init { this._rawData.Set("label", value); }
    }

    /// <summary>
    /// Supported text with half-open UTF-8 byte spans into the complete property string.
    /// </summary>
    public FormFieldGroundingValue? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FormFieldGroundingValue>("value");
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

    public FormFieldGrounding() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormFieldGrounding(FormFieldGrounding formFieldGrounding)
        : base(formFieldGrounding) { }
#pragma warning restore CS8618

    public FormFieldGrounding(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormFieldGrounding(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormFieldGroundingFromRaw.FromRawUnchecked"/>
    public static FormFieldGrounding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormFieldGroundingFromRaw : IFromRawJson<FormFieldGrounding>
{
    /// <inheritdoc/>
    public FormFieldGrounding FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FormFieldGrounding.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FormFieldGroundingID, FormFieldGroundingIDFromRaw>))]
public sealed record class FormFieldGroundingID : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<FormFieldGroundingIDLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FormFieldGroundingIDLine>>(
                "lines"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormFieldGroundingIDLine>>(
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

    public FormFieldGroundingID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormFieldGroundingID(FormFieldGroundingID formFieldGroundingID)
        : base(formFieldGroundingID) { }
#pragma warning restore CS8618

    public FormFieldGroundingID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormFieldGroundingID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormFieldGroundingIDFromRaw.FromRawUnchecked"/>
    public static FormFieldGroundingID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FormFieldGroundingID(IReadOnlyList<FormFieldGroundingIDLine> lines)
        : this()
    {
        this.Lines = lines;
    }
}

class FormFieldGroundingIDFromRaw : IFromRawJson<FormFieldGroundingID>
{
    /// <inheritdoc/>
    public FormFieldGroundingID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormFieldGroundingID.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FormFieldGroundingIDLine, FormFieldGroundingIDLineFromRaw>)
)]
public sealed record class FormFieldGroundingIDLine : JsonModel
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
    public IReadOnlyList<FormFieldGroundingIDLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FormFieldGroundingIDLineWord>>(
                "words"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormFieldGroundingIDLineWord>?>(
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

    public FormFieldGroundingIDLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormFieldGroundingIDLine(FormFieldGroundingIDLine formFieldGroundingIDLine)
        : base(formFieldGroundingIDLine) { }
#pragma warning restore CS8618

    public FormFieldGroundingIDLine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormFieldGroundingIDLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormFieldGroundingIDLineFromRaw.FromRawUnchecked"/>
    public static FormFieldGroundingIDLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormFieldGroundingIDLineFromRaw : IFromRawJson<FormFieldGroundingIDLine>
{
    /// <inheritdoc/>
    public FormFieldGroundingIDLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormFieldGroundingIDLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FormFieldGroundingIDLineWord, FormFieldGroundingIDLineWordFromRaw>)
)]
public sealed record class FormFieldGroundingIDLineWord : JsonModel
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

    public FormFieldGroundingIDLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormFieldGroundingIDLineWord(FormFieldGroundingIDLineWord formFieldGroundingIDLineWord)
        : base(formFieldGroundingIDLineWord) { }
#pragma warning restore CS8618

    public FormFieldGroundingIDLineWord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormFieldGroundingIDLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormFieldGroundingIDLineWordFromRaw.FromRawUnchecked"/>
    public static FormFieldGroundingIDLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormFieldGroundingIDLineWordFromRaw : IFromRawJson<FormFieldGroundingIDLineWord>
{
    /// <inheritdoc/>
    public FormFieldGroundingIDLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormFieldGroundingIDLineWord.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FormFieldGroundingLabel, FormFieldGroundingLabelFromRaw>))]
public sealed record class FormFieldGroundingLabel : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<FormFieldGroundingLabelLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FormFieldGroundingLabelLine>>(
                "lines"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormFieldGroundingLabelLine>>(
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

    public FormFieldGroundingLabel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormFieldGroundingLabel(FormFieldGroundingLabel formFieldGroundingLabel)
        : base(formFieldGroundingLabel) { }
#pragma warning restore CS8618

    public FormFieldGroundingLabel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormFieldGroundingLabel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormFieldGroundingLabelFromRaw.FromRawUnchecked"/>
    public static FormFieldGroundingLabel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FormFieldGroundingLabel(IReadOnlyList<FormFieldGroundingLabelLine> lines)
        : this()
    {
        this.Lines = lines;
    }
}

class FormFieldGroundingLabelFromRaw : IFromRawJson<FormFieldGroundingLabel>
{
    /// <inheritdoc/>
    public FormFieldGroundingLabel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormFieldGroundingLabel.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FormFieldGroundingLabelLine, FormFieldGroundingLabelLineFromRaw>)
)]
public sealed record class FormFieldGroundingLabelLine : JsonModel
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
    public IReadOnlyList<FormFieldGroundingLabelLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FormFieldGroundingLabelLineWord>>(
                "words"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormFieldGroundingLabelLineWord>?>(
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

    public FormFieldGroundingLabelLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormFieldGroundingLabelLine(FormFieldGroundingLabelLine formFieldGroundingLabelLine)
        : base(formFieldGroundingLabelLine) { }
#pragma warning restore CS8618

    public FormFieldGroundingLabelLine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormFieldGroundingLabelLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormFieldGroundingLabelLineFromRaw.FromRawUnchecked"/>
    public static FormFieldGroundingLabelLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormFieldGroundingLabelLineFromRaw : IFromRawJson<FormFieldGroundingLabelLine>
{
    /// <inheritdoc/>
    public FormFieldGroundingLabelLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormFieldGroundingLabelLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FormFieldGroundingLabelLineWord,
        FormFieldGroundingLabelLineWordFromRaw
    >)
)]
public sealed record class FormFieldGroundingLabelLineWord : JsonModel
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

    public FormFieldGroundingLabelLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormFieldGroundingLabelLineWord(
        FormFieldGroundingLabelLineWord formFieldGroundingLabelLineWord
    )
        : base(formFieldGroundingLabelLineWord) { }
#pragma warning restore CS8618

    public FormFieldGroundingLabelLineWord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormFieldGroundingLabelLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormFieldGroundingLabelLineWordFromRaw.FromRawUnchecked"/>
    public static FormFieldGroundingLabelLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormFieldGroundingLabelLineWordFromRaw : IFromRawJson<FormFieldGroundingLabelLineWord>
{
    /// <inheritdoc/>
    public FormFieldGroundingLabelLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormFieldGroundingLabelLineWord.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FormFieldGroundingValue, FormFieldGroundingValueFromRaw>))]
public sealed record class FormFieldGroundingValue : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<FormFieldGroundingValueLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FormFieldGroundingValueLine>>(
                "lines"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormFieldGroundingValueLine>>(
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

    public FormFieldGroundingValue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormFieldGroundingValue(FormFieldGroundingValue formFieldGroundingValue)
        : base(formFieldGroundingValue) { }
#pragma warning restore CS8618

    public FormFieldGroundingValue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormFieldGroundingValue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormFieldGroundingValueFromRaw.FromRawUnchecked"/>
    public static FormFieldGroundingValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FormFieldGroundingValue(IReadOnlyList<FormFieldGroundingValueLine> lines)
        : this()
    {
        this.Lines = lines;
    }
}

class FormFieldGroundingValueFromRaw : IFromRawJson<FormFieldGroundingValue>
{
    /// <inheritdoc/>
    public FormFieldGroundingValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormFieldGroundingValue.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FormFieldGroundingValueLine, FormFieldGroundingValueLineFromRaw>)
)]
public sealed record class FormFieldGroundingValueLine : JsonModel
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
    public IReadOnlyList<FormFieldGroundingValueLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FormFieldGroundingValueLineWord>>(
                "words"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormFieldGroundingValueLineWord>?>(
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

    public FormFieldGroundingValueLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormFieldGroundingValueLine(FormFieldGroundingValueLine formFieldGroundingValueLine)
        : base(formFieldGroundingValueLine) { }
#pragma warning restore CS8618

    public FormFieldGroundingValueLine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormFieldGroundingValueLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormFieldGroundingValueLineFromRaw.FromRawUnchecked"/>
    public static FormFieldGroundingValueLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormFieldGroundingValueLineFromRaw : IFromRawJson<FormFieldGroundingValueLine>
{
    /// <inheritdoc/>
    public FormFieldGroundingValueLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormFieldGroundingValueLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FormFieldGroundingValueLineWord,
        FormFieldGroundingValueLineWordFromRaw
    >)
)]
public sealed record class FormFieldGroundingValueLineWord : JsonModel
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

    public FormFieldGroundingValueLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormFieldGroundingValueLineWord(
        FormFieldGroundingValueLineWord formFieldGroundingValueLineWord
    )
        : base(formFieldGroundingValueLineWord) { }
#pragma warning restore CS8618

    public FormFieldGroundingValueLineWord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormFieldGroundingValueLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormFieldGroundingValueLineWordFromRaw.FromRawUnchecked"/>
    public static FormFieldGroundingValueLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormFieldGroundingValueLineWordFromRaw : IFromRawJson<FormFieldGroundingValueLineWord>
{
    /// <inheritdoc/>
    public FormFieldGroundingValueLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormFieldGroundingValueLineWord.FromRawUnchecked(rawData);
}

/// <summary>
/// Form field node
/// </summary>
[JsonConverter(typeof(FormFieldTypeConverter))]
public enum FormFieldType
{
    Field,
}

sealed class FormFieldTypeConverter : JsonConverter<FormFieldType>
{
    public override FormFieldType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "field" => FormFieldType.Field,
            _ => (FormFieldType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FormFieldType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FormFieldType.Field => "field",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Entered content: verbatim text for text fields, or a boolean for checkbox (checked)
/// and signature (signed). Absent on blank text fields and on select groups
/// </summary>
[JsonConverter(typeof(FormFieldValueConverter))]
public record class FormFieldValue : ModelBase
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

    public FormFieldValue(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FormFieldValue(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FormFieldValue(JsonElement element)
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
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<string> @string, System::Action<bool> @bool)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of FormFieldValue"
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
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<string, T> @string, System::Func<bool, T> @bool)
    {
        return this.Value switch
        {
            string value => @string(value),
            bool value => @bool(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of FormFieldValue"
            ),
        };
    }

    public static implicit operator FormFieldValue(string value) => new(value);

    public static implicit operator FormFieldValue(bool value) => new(value);

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
                "Data did not match any variant of FormFieldValue"
            );
        }
    }

    public virtual bool Equals(FormFieldValue? other) =>
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
            _ => -1,
        };
    }
}

sealed class FormFieldValueConverter : JsonConverter<FormFieldValue?>
{
    public override FormFieldValue? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
        FormFieldValue? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// One labeled form entry: a text input, checkbox, select group, or signature line.
/// </summary>
[JsonConverter(typeof(ValueItemConverter))]
public record class ValueItem : ModelBase
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

    public ValueItem(FormField value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ValueItem(FormSection value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ValueItem(FormTable value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ValueItem(ValueItemText value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ValueItem(JsonElement element)
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
    /// type <see cref="ValueItemText"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickText(out var value)) {
    ///     // `value` is of type `ValueItemText`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickText([NotNullWhen(true)] out ValueItemText? value)
    {
        value = this.Value as ValueItemText;
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
    ///     (ValueItemText value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<FormField> formField,
        System::Action<FormSection> formSection,
        System::Action<FormTable> formTable,
        System::Action<ValueItemText> text
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
            case ValueItemText value:
                text(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of ValueItem"
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
    ///     (ValueItemText value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<FormField, T> formField,
        System::Func<FormSection, T> formSection,
        System::Func<FormTable, T> formTable,
        System::Func<ValueItemText, T> text
    )
    {
        return this.Value switch
        {
            FormField value => formField(value),
            FormSection value => formSection(value),
            FormTable value => formTable(value),
            ValueItemText value => text(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of ValueItem"
            ),
        };
    }

    public static implicit operator ValueItem(FormField value) => new(value);

    public static implicit operator ValueItem(FormSection value) => new(value);

    public static implicit operator ValueItem(FormTable value) => new(value);

    public static implicit operator ValueItem(ValueItemText value) => new(value);

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
            throw new LlamaCloudInvalidDataException("Data did not match any variant of ValueItem");
        }
        this.Switch(
            (formField) => formField.Validate(),
            (formSection) => formSection.Validate(),
            (formTable) => formTable.Validate(),
            (text) => text.Validate()
        );
    }

    public virtual bool Equals(ValueItem? other) =>
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
            ValueItemText _ => 3,
            _ => -1,
        };
    }
}

sealed class ValueItemConverter : JsonConverter<ValueItem>
{
    public override ValueItem? Read(
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
                    var deserialized = JsonSerializer.Deserialize<ValueItemText>(element, options);
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
                return new ValueItem(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ValueItem value,
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
[JsonConverter(typeof(JsonModelConverter<ValueItemText, ValueItemTextFromRaw>))]
public sealed record class ValueItemText : JsonModel
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
    public ValueItemTextGrounding? Grounding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ValueItemTextGrounding>("grounding");
        }
        init { this._rawData.Set("grounding", value); }
    }

    /// <summary>
    /// Form text node
    /// </summary>
    public ApiEnum<string, ValueItemTextType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ValueItemTextType>>("type");
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

    public ValueItemText() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ValueItemText(ValueItemText valueItemText)
        : base(valueItemText) { }
#pragma warning restore CS8618

    public ValueItemText(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValueItemText(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValueItemTextFromRaw.FromRawUnchecked"/>
    public static ValueItemText FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ValueItemText(string value)
        : this()
    {
        this.Value = value;
    }
}

class ValueItemTextFromRaw : IFromRawJson<ValueItemText>
{
    /// <inheritdoc/>
    public ValueItemText FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ValueItemText.FromRawUnchecked(rawData);
}

/// <summary>
/// Optional grounding for a field's printed text; boolean states have no text spans.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ValueItemTextGrounding, ValueItemTextGroundingFromRaw>))]
public sealed record class ValueItemTextGrounding : JsonModel
{
    /// <summary>
    /// Supported text with half-open UTF-8 byte spans into the complete property string.
    /// </summary>
    public ValueItemTextGroundingID? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ValueItemTextGroundingID>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Supported text with half-open UTF-8 byte spans into the complete property string.
    /// </summary>
    public ValueItemTextGroundingLabel? Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ValueItemTextGroundingLabel>("label");
        }
        init { this._rawData.Set("label", value); }
    }

    /// <summary>
    /// Supported text with half-open UTF-8 byte spans into the complete property string.
    /// </summary>
    public ValueItemTextGroundingValue? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ValueItemTextGroundingValue>("value");
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

    public ValueItemTextGrounding() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ValueItemTextGrounding(ValueItemTextGrounding valueItemTextGrounding)
        : base(valueItemTextGrounding) { }
#pragma warning restore CS8618

    public ValueItemTextGrounding(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValueItemTextGrounding(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValueItemTextGroundingFromRaw.FromRawUnchecked"/>
    public static ValueItemTextGrounding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ValueItemTextGroundingFromRaw : IFromRawJson<ValueItemTextGrounding>
{
    /// <inheritdoc/>
    public ValueItemTextGrounding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ValueItemTextGrounding.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ValueItemTextGroundingID, ValueItemTextGroundingIDFromRaw>)
)]
public sealed record class ValueItemTextGroundingID : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<ValueItemTextGroundingIDLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ValueItemTextGroundingIDLine>>(
                "lines"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ValueItemTextGroundingIDLine>>(
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

    public ValueItemTextGroundingID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ValueItemTextGroundingID(ValueItemTextGroundingID valueItemTextGroundingID)
        : base(valueItemTextGroundingID) { }
#pragma warning restore CS8618

    public ValueItemTextGroundingID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValueItemTextGroundingID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValueItemTextGroundingIDFromRaw.FromRawUnchecked"/>
    public static ValueItemTextGroundingID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ValueItemTextGroundingID(IReadOnlyList<ValueItemTextGroundingIDLine> lines)
        : this()
    {
        this.Lines = lines;
    }
}

class ValueItemTextGroundingIDFromRaw : IFromRawJson<ValueItemTextGroundingID>
{
    /// <inheritdoc/>
    public ValueItemTextGroundingID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ValueItemTextGroundingID.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ValueItemTextGroundingIDLine, ValueItemTextGroundingIDLineFromRaw>)
)]
public sealed record class ValueItemTextGroundingIDLine : JsonModel
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
    public IReadOnlyList<ValueItemTextGroundingIDLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ValueItemTextGroundingIDLineWord>
            >("words");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ValueItemTextGroundingIDLineWord>?>(
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

    public ValueItemTextGroundingIDLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ValueItemTextGroundingIDLine(ValueItemTextGroundingIDLine valueItemTextGroundingIDLine)
        : base(valueItemTextGroundingIDLine) { }
#pragma warning restore CS8618

    public ValueItemTextGroundingIDLine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValueItemTextGroundingIDLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValueItemTextGroundingIDLineFromRaw.FromRawUnchecked"/>
    public static ValueItemTextGroundingIDLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ValueItemTextGroundingIDLineFromRaw : IFromRawJson<ValueItemTextGroundingIDLine>
{
    /// <inheritdoc/>
    public ValueItemTextGroundingIDLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ValueItemTextGroundingIDLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ValueItemTextGroundingIDLineWord,
        ValueItemTextGroundingIDLineWordFromRaw
    >)
)]
public sealed record class ValueItemTextGroundingIDLineWord : JsonModel
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

    public ValueItemTextGroundingIDLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ValueItemTextGroundingIDLineWord(
        ValueItemTextGroundingIDLineWord valueItemTextGroundingIDLineWord
    )
        : base(valueItemTextGroundingIDLineWord) { }
#pragma warning restore CS8618

    public ValueItemTextGroundingIDLineWord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValueItemTextGroundingIDLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValueItemTextGroundingIDLineWordFromRaw.FromRawUnchecked"/>
    public static ValueItemTextGroundingIDLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ValueItemTextGroundingIDLineWordFromRaw : IFromRawJson<ValueItemTextGroundingIDLineWord>
{
    /// <inheritdoc/>
    public ValueItemTextGroundingIDLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ValueItemTextGroundingIDLineWord.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ValueItemTextGroundingLabel, ValueItemTextGroundingLabelFromRaw>)
)]
public sealed record class ValueItemTextGroundingLabel : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<ValueItemTextGroundingLabelLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ValueItemTextGroundingLabelLine>>(
                "lines"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ValueItemTextGroundingLabelLine>>(
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

    public ValueItemTextGroundingLabel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ValueItemTextGroundingLabel(ValueItemTextGroundingLabel valueItemTextGroundingLabel)
        : base(valueItemTextGroundingLabel) { }
#pragma warning restore CS8618

    public ValueItemTextGroundingLabel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValueItemTextGroundingLabel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValueItemTextGroundingLabelFromRaw.FromRawUnchecked"/>
    public static ValueItemTextGroundingLabel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ValueItemTextGroundingLabel(IReadOnlyList<ValueItemTextGroundingLabelLine> lines)
        : this()
    {
        this.Lines = lines;
    }
}

class ValueItemTextGroundingLabelFromRaw : IFromRawJson<ValueItemTextGroundingLabel>
{
    /// <inheritdoc/>
    public ValueItemTextGroundingLabel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ValueItemTextGroundingLabel.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ValueItemTextGroundingLabelLine,
        ValueItemTextGroundingLabelLineFromRaw
    >)
)]
public sealed record class ValueItemTextGroundingLabelLine : JsonModel
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
    public IReadOnlyList<ValueItemTextGroundingLabelLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ValueItemTextGroundingLabelLineWord>
            >("words");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ValueItemTextGroundingLabelLineWord>?>(
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

    public ValueItemTextGroundingLabelLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ValueItemTextGroundingLabelLine(
        ValueItemTextGroundingLabelLine valueItemTextGroundingLabelLine
    )
        : base(valueItemTextGroundingLabelLine) { }
#pragma warning restore CS8618

    public ValueItemTextGroundingLabelLine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValueItemTextGroundingLabelLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValueItemTextGroundingLabelLineFromRaw.FromRawUnchecked"/>
    public static ValueItemTextGroundingLabelLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ValueItemTextGroundingLabelLineFromRaw : IFromRawJson<ValueItemTextGroundingLabelLine>
{
    /// <inheritdoc/>
    public ValueItemTextGroundingLabelLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ValueItemTextGroundingLabelLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ValueItemTextGroundingLabelLineWord,
        ValueItemTextGroundingLabelLineWordFromRaw
    >)
)]
public sealed record class ValueItemTextGroundingLabelLineWord : JsonModel
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

    public ValueItemTextGroundingLabelLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ValueItemTextGroundingLabelLineWord(
        ValueItemTextGroundingLabelLineWord valueItemTextGroundingLabelLineWord
    )
        : base(valueItemTextGroundingLabelLineWord) { }
#pragma warning restore CS8618

    public ValueItemTextGroundingLabelLineWord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValueItemTextGroundingLabelLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValueItemTextGroundingLabelLineWordFromRaw.FromRawUnchecked"/>
    public static ValueItemTextGroundingLabelLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ValueItemTextGroundingLabelLineWordFromRaw : IFromRawJson<ValueItemTextGroundingLabelLineWord>
{
    /// <inheritdoc/>
    public ValueItemTextGroundingLabelLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ValueItemTextGroundingLabelLineWord.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ValueItemTextGroundingValue, ValueItemTextGroundingValueFromRaw>)
)]
public sealed record class ValueItemTextGroundingValue : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<ValueItemTextGroundingValueLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ValueItemTextGroundingValueLine>>(
                "lines"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ValueItemTextGroundingValueLine>>(
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

    public ValueItemTextGroundingValue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ValueItemTextGroundingValue(ValueItemTextGroundingValue valueItemTextGroundingValue)
        : base(valueItemTextGroundingValue) { }
#pragma warning restore CS8618

    public ValueItemTextGroundingValue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValueItemTextGroundingValue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValueItemTextGroundingValueFromRaw.FromRawUnchecked"/>
    public static ValueItemTextGroundingValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ValueItemTextGroundingValue(IReadOnlyList<ValueItemTextGroundingValueLine> lines)
        : this()
    {
        this.Lines = lines;
    }
}

class ValueItemTextGroundingValueFromRaw : IFromRawJson<ValueItemTextGroundingValue>
{
    /// <inheritdoc/>
    public ValueItemTextGroundingValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ValueItemTextGroundingValue.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ValueItemTextGroundingValueLine,
        ValueItemTextGroundingValueLineFromRaw
    >)
)]
public sealed record class ValueItemTextGroundingValueLine : JsonModel
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
    public IReadOnlyList<ValueItemTextGroundingValueLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ValueItemTextGroundingValueLineWord>
            >("words");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ValueItemTextGroundingValueLineWord>?>(
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

    public ValueItemTextGroundingValueLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ValueItemTextGroundingValueLine(
        ValueItemTextGroundingValueLine valueItemTextGroundingValueLine
    )
        : base(valueItemTextGroundingValueLine) { }
#pragma warning restore CS8618

    public ValueItemTextGroundingValueLine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValueItemTextGroundingValueLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValueItemTextGroundingValueLineFromRaw.FromRawUnchecked"/>
    public static ValueItemTextGroundingValueLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ValueItemTextGroundingValueLineFromRaw : IFromRawJson<ValueItemTextGroundingValueLine>
{
    /// <inheritdoc/>
    public ValueItemTextGroundingValueLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ValueItemTextGroundingValueLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ValueItemTextGroundingValueLineWord,
        ValueItemTextGroundingValueLineWordFromRaw
    >)
)]
public sealed record class ValueItemTextGroundingValueLineWord : JsonModel
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

    public ValueItemTextGroundingValueLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ValueItemTextGroundingValueLineWord(
        ValueItemTextGroundingValueLineWord valueItemTextGroundingValueLineWord
    )
        : base(valueItemTextGroundingValueLineWord) { }
#pragma warning restore CS8618

    public ValueItemTextGroundingValueLineWord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValueItemTextGroundingValueLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValueItemTextGroundingValueLineWordFromRaw.FromRawUnchecked"/>
    public static ValueItemTextGroundingValueLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ValueItemTextGroundingValueLineWordFromRaw : IFromRawJson<ValueItemTextGroundingValueLineWord>
{
    /// <inheritdoc/>
    public ValueItemTextGroundingValueLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ValueItemTextGroundingValueLineWord.FromRawUnchecked(rawData);
}

/// <summary>
/// Form text node
/// </summary>
[JsonConverter(typeof(ValueItemTextTypeConverter))]
public enum ValueItemTextType
{
    Text,
}

sealed class ValueItemTextTypeConverter : JsonConverter<ValueItemTextType>
{
    public override ValueItemTextType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => ValueItemTextType.Text,
            _ => (ValueItemTextType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ValueItemTextType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ValueItemTextType.Text => "text",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
