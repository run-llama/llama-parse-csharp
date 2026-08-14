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

[JsonConverter(typeof(JsonModelConverter<ListItem, ListItemFromRaw>))]
public sealed record class ListItem : JsonModel
{
    /// <summary>
    /// List of nested text or list items
    /// </summary>
    public required IReadOnlyList<ListItemItem> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ListItemItem>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ListItemItem>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Markdown representation preserving formatting
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
    /// Whether the list is ordered or unordered
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
    /// List of bounding boxes
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
    /// List item type
    /// </summary>
    public ApiEnum<string, ListItemType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ListItemType>>("type");
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
        foreach (var item in this.Bbox ?? [])
        {
            item.Validate();
        }
        this.Type?.Validate();
    }

    public ListItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ListItem(ListItem listItem)
        : base(listItem) { }
#pragma warning restore CS8618

    public ListItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ListItemFromRaw.FromRawUnchecked"/>
    public static ListItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ListItemFromRaw : IFromRawJson<ListItem>
{
    /// <inheritdoc/>
    public ListItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ListItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ListItemItemConverter))]
public record class ListItemItem : ModelBase
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
        get { return Match(text: (x) => x.Md, list: (x) => x.Md); }
    }

    public ListItemItem(TextItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ListItemItem(ListItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ListItemItem(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TextItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickText(out var value)) {
    ///     // `value` is of type `TextItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickText([NotNullWhen(true)] out TextItem? value)
    {
        value = this.Value as TextItem;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ListItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickList(out var value)) {
    ///     // `value` is of type `ListItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickList([NotNullWhen(true)] out ListItem? value)
    {
        value = this.Value as ListItem;
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
    ///     (TextItem value) =&gt; {...},
    ///     (ListItem value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<TextItem> text, System::Action<ListItem> list)
    {
        switch (this.Value)
        {
            case TextItem value:
                text(value);
                break;
            case ListItem value:
                list(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of ListItemItem"
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
    ///     (TextItem value) =&gt; {...},
    ///     (ListItem value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<TextItem, T> text, System::Func<ListItem, T> list)
    {
        return this.Value switch
        {
            TextItem value => text(value),
            ListItem value => list(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of ListItemItem"
            ),
        };
    }

    public static implicit operator ListItemItem(TextItem value) => new(value);

    public static implicit operator ListItemItem(ListItem value) => new(value);

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
                "Data did not match any variant of ListItemItem"
            );
        }
        this.Switch((text) => text.Validate(), (list) => list.Validate());
    }

    public virtual bool Equals(ListItemItem? other) =>
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
            TextItem _ => 0,
            ListItem _ => 1,
            _ => -1,
        };
    }
}

sealed class ListItemItemConverter : JsonConverter<ListItemItem>
{
    public override ListItemItem? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<TextItem>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<ListItem>(element, options);
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
        ListItemItem value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// List item type
/// </summary>
[JsonConverter(typeof(ListItemTypeConverter))]
public enum ListItemType
{
    List,
}

sealed class ListItemTypeConverter : JsonConverter<ListItemType>
{
    public override ListItemType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "list" => ListItemType.List,
            _ => (ListItemType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ListItemType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ListItemType.List => "list",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
