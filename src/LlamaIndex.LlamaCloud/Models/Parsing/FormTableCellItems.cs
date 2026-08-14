using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Parsing;

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
                "Data did not match any variant of FormTableCellItemsItem"
            ),
        };
    }

    public static implicit operator FormTableCellItemsItem(FormField value) => new(value);

    public static implicit operator FormTableCellItemsItem(FormSection value) => new(value);

    public static implicit operator FormTableCellItemsItem(FormTable value) => new(value);

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
            (formTable) => formTable.Validate()
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
