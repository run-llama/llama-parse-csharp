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
/// The list representation of form content: nested lists of rendered field lines.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FormListItem, FormListItemFromRaw>))]
public sealed record class FormListItem : JsonModel
{
    /// <summary>
    /// Nested lines and sub-lists, in the form's reading order
    /// </summary>
    public required IReadOnlyList<FormListItemItem> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FormListItemItem>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormListItemItem>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Markdown representation of this list
    /// </summary>
    public required string Md
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("md");
        }
        init { this._rawData.Set("md", value); }
    }

    /// <summary>
    /// Whether the list is ordered
    /// </summary>
    public required bool Ordered
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("ordered");
        }
        init { this._rawData.Set("ordered", value); }
    }

    /// <summary>
    /// List node
    /// </summary>
    public ApiEnum<string, FormListItemType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FormListItemType>>("type");
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
        _ = this.Md;
        _ = this.Ordered;
        this.Type?.Validate();
    }

    public FormListItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormListItem(FormListItem formListItem)
        : base(formListItem) { }
#pragma warning restore CS8618

    public FormListItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormListItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormListItemFromRaw.FromRawUnchecked"/>
    public static FormListItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormListItemFromRaw : IFromRawJson<FormListItem>
{
    /// <inheritdoc/>
    public FormListItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FormListItem.FromRawUnchecked(rawData);
}

/// <summary>
/// One line of a form's list representation.
/// </summary>
[JsonConverter(typeof(FormListItemItemConverter))]
public record class FormListItemItem : ModelBase
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

    public string Md
    {
        get { return Match(formListText: (x) => x.Md, formList: (x) => x.Md); }
    }

    public FormListItemItem(FormListTextItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FormListItemItem(FormListItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FormListItemItem(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FormListTextItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFormListText(out var value)) {
    ///     // `value` is of type `FormListTextItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFormListText([NotNullWhen(true)] out FormListTextItem? value)
    {
        value = this.Value as FormListTextItem;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FormListItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFormList(out var value)) {
    ///     // `value` is of type `FormListItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFormList([NotNullWhen(true)] out FormListItem? value)
    {
        value = this.Value as FormListItem;
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
    ///     (FormListTextItem value) =&gt; {...},
    ///     (FormListItem value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<FormListTextItem> formListText,
        System::Action<FormListItem> formList
    )
    {
        switch (this.Value)
        {
            case FormListTextItem value:
                formListText(value);
                break;
            case FormListItem value:
                formList(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of FormListItemItem"
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
    ///     (FormListTextItem value) =&gt; {...},
    ///     (FormListItem value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<FormListTextItem, T> formListText,
        System::Func<FormListItem, T> formList
    )
    {
        return this.Value switch
        {
            FormListTextItem value => formListText(value),
            FormListItem value => formList(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of FormListItemItem"
            ),
        };
    }

    public static implicit operator FormListItemItem(FormListTextItem value) => new(value);

    public static implicit operator FormListItemItem(FormListItem value) => new(value);

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
                "Data did not match any variant of FormListItemItem"
            );
        }
        this.Switch((formListText) => formListText.Validate(), (formList) => formList.Validate());
    }

    public virtual bool Equals(FormListItemItem? other) =>
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
            FormListTextItem _ => 0,
            FormListItem _ => 1,
            _ => -1,
        };
    }
}

sealed class FormListItemItemConverter : JsonConverter<FormListItemItem>
{
    public override FormListItemItem? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<FormListTextItem>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<FormListItem>(element, options);
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

    public override void Write(
        Utf8JsonWriter writer,
        FormListItemItem value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// List node
/// </summary>
[JsonConverter(typeof(FormListItemTypeConverter))]
public enum FormListItemType
{
    List,
}

sealed class FormListItemTypeConverter : JsonConverter<FormListItemType>
{
    public override FormListItemType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "list" => FormListItemType.List,
            _ => (FormListItemType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FormListItemType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FormListItemType.List => "list",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
