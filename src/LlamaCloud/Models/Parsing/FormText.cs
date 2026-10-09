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
/// Printed text that is not part of a field, section heading or table: a title, an
/// instruction, a note. With it the form JSON holds every printed word of its region.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FormText, FormTextFromRaw>))]
public sealed record class FormText : JsonModel
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
    public GroundingModel? Grounding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GroundingModel>("grounding");
        }
        init { this._rawData.Set("grounding", value); }
    }

    /// <summary>
    /// Form text node
    /// </summary>
    public ApiEnum<string, FormTextType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FormTextType>>("type");
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

    public FormText() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormText(FormText formText)
        : base(formText) { }
#pragma warning restore CS8618

    public FormText(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormText(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormTextFromRaw.FromRawUnchecked"/>
    public static FormText FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FormText(string value)
        : this()
    {
        this.Value = value;
    }
}

class FormTextFromRaw : IFromRawJson<FormText>
{
    /// <inheritdoc/>
    public FormText FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FormText.FromRawUnchecked(rawData);
}

/// <summary>
/// Optional grounding for a field's printed text; boolean states have no text spans.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GroundingModel, GroundingModelFromRaw>))]
public sealed record class GroundingModel : JsonModel
{
    /// <summary>
    /// Supported text with half-open UTF-8 byte spans into the complete property string.
    /// </summary>
    public GroundingModelID? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GroundingModelID>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Supported text with half-open UTF-8 byte spans into the complete property string.
    /// </summary>
    public GroundingModelLabel? Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GroundingModelLabel>("label");
        }
        init { this._rawData.Set("label", value); }
    }

    /// <summary>
    /// Supported text with half-open UTF-8 byte spans into the complete property string.
    /// </summary>
    public GroundingModelValue? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GroundingModelValue>("value");
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

    public GroundingModel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GroundingModel(GroundingModel groundingModel)
        : base(groundingModel) { }
#pragma warning restore CS8618

    public GroundingModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroundingModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroundingModelFromRaw.FromRawUnchecked"/>
    public static GroundingModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroundingModelFromRaw : IFromRawJson<GroundingModel>
{
    /// <inheritdoc/>
    public GroundingModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GroundingModel.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GroundingModelID, GroundingModelIDFromRaw>))]
public sealed record class GroundingModelID : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<GroundingModelIDLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<GroundingModelIDLine>>("lines");
        }
        init
        {
            this._rawData.Set<ImmutableArray<GroundingModelIDLine>>(
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

    public GroundingModelID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GroundingModelID(GroundingModelID groundingModelID)
        : base(groundingModelID) { }
#pragma warning restore CS8618

    public GroundingModelID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroundingModelID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroundingModelIDFromRaw.FromRawUnchecked"/>
    public static GroundingModelID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public GroundingModelID(IReadOnlyList<GroundingModelIDLine> lines)
        : this()
    {
        this.Lines = lines;
    }
}

class GroundingModelIDFromRaw : IFromRawJson<GroundingModelID>
{
    /// <inheritdoc/>
    public GroundingModelID FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GroundingModelID.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GroundingModelIDLine, GroundingModelIDLineFromRaw>))]
public sealed record class GroundingModelIDLine : JsonModel
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
    public IReadOnlyList<GroundingModelIDLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<GroundingModelIDLineWord>>(
                "words"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<GroundingModelIDLineWord>?>(
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

    public GroundingModelIDLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GroundingModelIDLine(GroundingModelIDLine groundingModelIDLine)
        : base(groundingModelIDLine) { }
#pragma warning restore CS8618

    public GroundingModelIDLine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroundingModelIDLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroundingModelIDLineFromRaw.FromRawUnchecked"/>
    public static GroundingModelIDLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroundingModelIDLineFromRaw : IFromRawJson<GroundingModelIDLine>
{
    /// <inheritdoc/>
    public GroundingModelIDLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GroundingModelIDLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<GroundingModelIDLineWord, GroundingModelIDLineWordFromRaw>)
)]
public sealed record class GroundingModelIDLineWord : JsonModel
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

    public GroundingModelIDLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GroundingModelIDLineWord(GroundingModelIDLineWord groundingModelIDLineWord)
        : base(groundingModelIDLineWord) { }
#pragma warning restore CS8618

    public GroundingModelIDLineWord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroundingModelIDLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroundingModelIDLineWordFromRaw.FromRawUnchecked"/>
    public static GroundingModelIDLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroundingModelIDLineWordFromRaw : IFromRawJson<GroundingModelIDLineWord>
{
    /// <inheritdoc/>
    public GroundingModelIDLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GroundingModelIDLineWord.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GroundingModelLabel, GroundingModelLabelFromRaw>))]
public sealed record class GroundingModelLabel : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<GroundingModelLabelLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<GroundingModelLabelLine>>("lines");
        }
        init
        {
            this._rawData.Set<ImmutableArray<GroundingModelLabelLine>>(
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

    public GroundingModelLabel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GroundingModelLabel(GroundingModelLabel groundingModelLabel)
        : base(groundingModelLabel) { }
#pragma warning restore CS8618

    public GroundingModelLabel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroundingModelLabel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroundingModelLabelFromRaw.FromRawUnchecked"/>
    public static GroundingModelLabel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public GroundingModelLabel(IReadOnlyList<GroundingModelLabelLine> lines)
        : this()
    {
        this.Lines = lines;
    }
}

class GroundingModelLabelFromRaw : IFromRawJson<GroundingModelLabel>
{
    /// <inheritdoc/>
    public GroundingModelLabel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GroundingModelLabel.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GroundingModelLabelLine, GroundingModelLabelLineFromRaw>))]
public sealed record class GroundingModelLabelLine : JsonModel
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
    public IReadOnlyList<GroundingModelLabelLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<GroundingModelLabelLineWord>>(
                "words"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<GroundingModelLabelLineWord>?>(
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

    public GroundingModelLabelLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GroundingModelLabelLine(GroundingModelLabelLine groundingModelLabelLine)
        : base(groundingModelLabelLine) { }
#pragma warning restore CS8618

    public GroundingModelLabelLine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroundingModelLabelLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroundingModelLabelLineFromRaw.FromRawUnchecked"/>
    public static GroundingModelLabelLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroundingModelLabelLineFromRaw : IFromRawJson<GroundingModelLabelLine>
{
    /// <inheritdoc/>
    public GroundingModelLabelLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GroundingModelLabelLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<GroundingModelLabelLineWord, GroundingModelLabelLineWordFromRaw>)
)]
public sealed record class GroundingModelLabelLineWord : JsonModel
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

    public GroundingModelLabelLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GroundingModelLabelLineWord(GroundingModelLabelLineWord groundingModelLabelLineWord)
        : base(groundingModelLabelLineWord) { }
#pragma warning restore CS8618

    public GroundingModelLabelLineWord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroundingModelLabelLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroundingModelLabelLineWordFromRaw.FromRawUnchecked"/>
    public static GroundingModelLabelLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroundingModelLabelLineWordFromRaw : IFromRawJson<GroundingModelLabelLineWord>
{
    /// <inheritdoc/>
    public GroundingModelLabelLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GroundingModelLabelLineWord.FromRawUnchecked(rawData);
}

/// <summary>
/// Supported text with half-open UTF-8 byte spans into the complete property string.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GroundingModelValue, GroundingModelValueFromRaw>))]
public sealed record class GroundingModelValue : JsonModel
{
    /// <summary>
    /// Supported lines. Word requests include supported words; gaps are valid. Boxes
    /// use final page coordinates and optional local rotation r.
    /// </summary>
    public required IReadOnlyList<GroundingModelValueLine> Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<GroundingModelValueLine>>("lines");
        }
        init
        {
            this._rawData.Set<ImmutableArray<GroundingModelValueLine>>(
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

    public GroundingModelValue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GroundingModelValue(GroundingModelValue groundingModelValue)
        : base(groundingModelValue) { }
#pragma warning restore CS8618

    public GroundingModelValue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroundingModelValue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroundingModelValueFromRaw.FromRawUnchecked"/>
    public static GroundingModelValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public GroundingModelValue(IReadOnlyList<GroundingModelValueLine> lines)
        : this()
    {
        this.Lines = lines;
    }
}

class GroundingModelValueFromRaw : IFromRawJson<GroundingModelValue>
{
    /// <inheritdoc/>
    public GroundingModelValue FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GroundingModelValue.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded line of text with an optional per-word breakdown.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GroundingModelValueLine, GroundingModelValueLineFromRaw>))]
public sealed record class GroundingModelValueLine : JsonModel
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
    public IReadOnlyList<GroundingModelValueLineWord>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<GroundingModelValueLineWord>>(
                "words"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<GroundingModelValueLineWord>?>(
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

    public GroundingModelValueLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GroundingModelValueLine(GroundingModelValueLine groundingModelValueLine)
        : base(groundingModelValueLine) { }
#pragma warning restore CS8618

    public GroundingModelValueLine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroundingModelValueLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroundingModelValueLineFromRaw.FromRawUnchecked"/>
    public static GroundingModelValueLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroundingModelValueLineFromRaw : IFromRawJson<GroundingModelValueLine>
{
    /// <inheritdoc/>
    public GroundingModelValueLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GroundingModelValueLine.FromRawUnchecked(rawData);
}

/// <summary>
/// One grounded word: a `[start, end)` span in the source text and its bbox.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<GroundingModelValueLineWord, GroundingModelValueLineWordFromRaw>)
)]
public sealed record class GroundingModelValueLineWord : JsonModel
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

    public GroundingModelValueLineWord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GroundingModelValueLineWord(GroundingModelValueLineWord groundingModelValueLineWord)
        : base(groundingModelValueLineWord) { }
#pragma warning restore CS8618

    public GroundingModelValueLineWord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroundingModelValueLineWord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroundingModelValueLineWordFromRaw.FromRawUnchecked"/>
    public static GroundingModelValueLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroundingModelValueLineWordFromRaw : IFromRawJson<GroundingModelValueLineWord>
{
    /// <inheritdoc/>
    public GroundingModelValueLineWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GroundingModelValueLineWord.FromRawUnchecked(rawData);
}

/// <summary>
/// Form text node
/// </summary>
[JsonConverter(typeof(FormTextTypeConverter))]
public enum FormTextType
{
    Text,
}

sealed class FormTextTypeConverter : JsonConverter<FormTextType>
{
    public override FormTextType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => FormTextType.Text,
            _ => (FormTextType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FormTextType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FormTextType.Text => "text",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
