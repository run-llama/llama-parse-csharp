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

[JsonConverter(typeof(JsonModelConverter<FooterItem, FooterItemFromRaw>))]
public sealed record class FooterItem : JsonModel
{
    /// <summary>
    /// List of items within the footer
    /// </summary>
    public required IReadOnlyList<Item> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Item>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Item>>(
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
    /// Page footer container
    /// </summary>
    public ApiEnum<string, FooterItemType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FooterItemType>>("type");
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
        foreach (var item in this.Bbox ?? [])
        {
            item.Validate();
        }
        this.Type?.Validate();
    }

    public FooterItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FooterItem(FooterItem footerItem)
        : base(footerItem) { }
#pragma warning restore CS8618

    public FooterItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FooterItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FooterItemFromRaw.FromRawUnchecked"/>
    public static FooterItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FooterItemFromRaw : IFromRawJson<FooterItem>
{
    /// <inheritdoc/>
    public FooterItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FooterItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ItemConverter))]
public record class Item : ModelBase
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
        get
        {
            return Match(
                code: (x) => x.Md,
                heading: (x) => x.Md,
                image: (x) => x.Md,
                link: (x) => x.Md,
                list: (x) => x.Md,
                table: (x) => x.Md,
                text: (x) => x.Md
            );
        }
    }

    public string? ValueValue
    {
        get
        {
            return Match<string?>(
                code: (x) => x.ValueValue,
                heading: (x) => x.Value,
                image: (_) => null,
                link: (_) => null,
                list: (_) => null,
                table: (_) => null,
                text: (x) => x.Value
            );
        }
    }

    public string? Url
    {
        get
        {
            return Match<string?>(
                code: (_) => null,
                heading: (_) => null,
                image: (x) => x.Url,
                link: (x) => x.Url,
                list: (_) => null,
                table: (_) => null,
                text: (_) => null
            );
        }
    }

    public Item(CodeItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Item(HeadingItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Item(ImageItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Item(LinkItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Item(ListItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Item(TableItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Item(TextItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Item(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CodeItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCode(out var value)) {
    ///     // `value` is of type `CodeItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCode([NotNullWhen(true)] out CodeItem? value)
    {
        value = this.Value as CodeItem;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="HeadingItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickHeading(out var value)) {
    ///     // `value` is of type `HeadingItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickHeading([NotNullWhen(true)] out HeadingItem? value)
    {
        value = this.Value as HeadingItem;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ImageItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickImage(out var value)) {
    ///     // `value` is of type `ImageItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickImage([NotNullWhen(true)] out ImageItem? value)
    {
        value = this.Value as ImageItem;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="LinkItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLink(out var value)) {
    ///     // `value` is of type `LinkItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLink([NotNullWhen(true)] out LinkItem? value)
    {
        value = this.Value as LinkItem;
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
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TableItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTable(out var value)) {
    ///     // `value` is of type `TableItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTable([NotNullWhen(true)] out TableItem? value)
    {
        value = this.Value as TableItem;
        return value != null;
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
    ///     (CodeItem value) =&gt; {...},
    ///     (HeadingItem value) =&gt; {...},
    ///     (ImageItem value) =&gt; {...},
    ///     (LinkItem value) =&gt; {...},
    ///     (ListItem value) =&gt; {...},
    ///     (TableItem value) =&gt; {...},
    ///     (TextItem value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<CodeItem> code,
        System::Action<HeadingItem> heading,
        System::Action<ImageItem> image,
        System::Action<LinkItem> link,
        System::Action<ListItem> list,
        System::Action<TableItem> table,
        System::Action<TextItem> text
    )
    {
        switch (this.Value)
        {
            case CodeItem value:
                code(value);
                break;
            case HeadingItem value:
                heading(value);
                break;
            case ImageItem value:
                image(value);
                break;
            case LinkItem value:
                link(value);
                break;
            case ListItem value:
                list(value);
                break;
            case TableItem value:
                table(value);
                break;
            case TextItem value:
                text(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException("Data did not match any variant of Item");
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
    ///     (CodeItem value) =&gt; {...},
    ///     (HeadingItem value) =&gt; {...},
    ///     (ImageItem value) =&gt; {...},
    ///     (LinkItem value) =&gt; {...},
    ///     (ListItem value) =&gt; {...},
    ///     (TableItem value) =&gt; {...},
    ///     (TextItem value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<CodeItem, T> code,
        System::Func<HeadingItem, T> heading,
        System::Func<ImageItem, T> image,
        System::Func<LinkItem, T> link,
        System::Func<ListItem, T> list,
        System::Func<TableItem, T> table,
        System::Func<TextItem, T> text
    )
    {
        return this.Value switch
        {
            CodeItem value => code(value),
            HeadingItem value => heading(value),
            ImageItem value => image(value),
            LinkItem value => link(value),
            ListItem value => list(value),
            TableItem value => table(value),
            TextItem value => text(value),
            _ => throw new LlamaCloudInvalidDataException("Data did not match any variant of Item"),
        };
    }

    public static implicit operator Item(CodeItem value) => new(value);

    public static implicit operator Item(HeadingItem value) => new(value);

    public static implicit operator Item(ImageItem value) => new(value);

    public static implicit operator Item(LinkItem value) => new(value);

    public static implicit operator Item(ListItem value) => new(value);

    public static implicit operator Item(TableItem value) => new(value);

    public static implicit operator Item(TextItem value) => new(value);

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
            throw new LlamaCloudInvalidDataException("Data did not match any variant of Item");
        }
        this.Switch(
            (code) => code.Validate(),
            (heading) => heading.Validate(),
            (image) => image.Validate(),
            (link) => link.Validate(),
            (list) => list.Validate(),
            (table) => table.Validate(),
            (text) => text.Validate()
        );
    }

    public virtual bool Equals(Item? other) =>
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
            CodeItem _ => 0,
            HeadingItem _ => 1,
            ImageItem _ => 2,
            LinkItem _ => 3,
            ListItem _ => 4,
            TableItem _ => 5,
            TextItem _ => 6,
            _ => -1,
        };
    }
}

sealed class ItemConverter : JsonConverter<Item>
{
    public override Item? Read(
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
            case "code":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CodeItem>(element, options);
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
            case "heading":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<HeadingItem>(element, options);
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
            case "image":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ImageItem>(element, options);
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
            case "link":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<LinkItem>(element, options);
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
            case "list":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ListItem>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<TableItem>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<TextItem>(element, options);
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
                return new Item(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Item value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Page footer container
/// </summary>
[JsonConverter(typeof(FooterItemTypeConverter))]
public enum FooterItemType
{
    Footer,
}

sealed class FooterItemTypeConverter : JsonConverter<FooterItemType>
{
    public override FooterItemType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "footer" => FooterItemType.Footer,
            _ => (FooterItemType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FooterItemType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FooterItemType.Footer => "footer",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
