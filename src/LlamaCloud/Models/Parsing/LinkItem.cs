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

[JsonConverter(typeof(JsonModelConverter<LinkItem, LinkItemFromRaw>))]
public sealed record class LinkItem : JsonModel
{
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
    /// Display text of the link
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// URL of the link
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
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
    /// Link item type
    /// </summary>
    public ApiEnum<string, LinkItemType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LinkItemType>>("type");
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
        _ = this.Md;
        _ = this.Text;
        _ = this.Url;
        foreach (var item in this.Bbox ?? [])
        {
            item.Validate();
        }
        this.Type?.Validate();
    }

    public LinkItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LinkItem(LinkItem linkItem)
        : base(linkItem) { }
#pragma warning restore CS8618

    public LinkItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LinkItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LinkItemFromRaw.FromRawUnchecked"/>
    public static LinkItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LinkItemFromRaw : IFromRawJson<LinkItem>
{
    /// <inheritdoc/>
    public LinkItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LinkItem.FromRawUnchecked(rawData);
}

/// <summary>
/// Link item type
/// </summary>
[JsonConverter(typeof(LinkItemTypeConverter))]
public enum LinkItemType
{
    Link,
}

sealed class LinkItemTypeConverter : JsonConverter<LinkItemType>
{
    public override LinkItemType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "link" => LinkItemType.Link,
            _ => (LinkItemType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LinkItemType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LinkItemType.Link => "link",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
