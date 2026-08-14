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

[JsonConverter(typeof(JsonModelConverter<ImageItem, ImageItemFromRaw>))]
public sealed record class ImageItem : JsonModel
{
    /// <summary>
    /// Image caption
    /// </summary>
    public required string Caption
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("caption");
        }
        init { this._rawData.Set("caption", value); }
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
    /// URL to the image
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
    /// Image item type
    /// </summary>
    public ApiEnum<string, ImageItemType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ImageItemType>>("type");
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
        _ = this.Caption;
        _ = this.Md;
        _ = this.Url;
        foreach (var item in this.Bbox ?? [])
        {
            item.Validate();
        }
        this.Type?.Validate();
    }

    public ImageItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageItem(ImageItem imageItem)
        : base(imageItem) { }
#pragma warning restore CS8618

    public ImageItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageItemFromRaw.FromRawUnchecked"/>
    public static ImageItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageItemFromRaw : IFromRawJson<ImageItem>
{
    /// <inheritdoc/>
    public ImageItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ImageItem.FromRawUnchecked(rawData);
}

/// <summary>
/// Image item type
/// </summary>
[JsonConverter(typeof(ImageItemTypeConverter))]
public enum ImageItemType
{
    Image,
}

sealed class ImageItemTypeConverter : JsonConverter<ImageItemType>
{
    public override ImageItemType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "image" => ImageItemType.Image,
            _ => (ImageItemType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ImageItemType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ImageItemType.Image => "image",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
