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

[JsonConverter(typeof(JsonModelConverter<HeadingItem, HeadingItemFromRaw>))]
public sealed record class HeadingItem : JsonModel
{
    /// <summary>
    /// Heading level (1-6)
    /// </summary>
    public required long Level
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("level");
        }
        init { this._rawData.Set("level", value); }
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
    /// Heading text content
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
    /// Heading item type
    /// </summary>
    public ApiEnum<string, HeadingItemType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, HeadingItemType>>("type");
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
        _ = this.Level;
        _ = this.Md;
        _ = this.Value;
        foreach (var item in this.Bbox ?? [])
        {
            item.Validate();
        }
        this.Type?.Validate();
    }

    public HeadingItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public HeadingItem(HeadingItem headingItem)
        : base(headingItem) { }
#pragma warning restore CS8618

    public HeadingItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HeadingItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HeadingItemFromRaw.FromRawUnchecked"/>
    public static HeadingItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HeadingItemFromRaw : IFromRawJson<HeadingItem>
{
    /// <inheritdoc/>
    public HeadingItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        HeadingItem.FromRawUnchecked(rawData);
}

/// <summary>
/// Heading item type
/// </summary>
[JsonConverter(typeof(HeadingItemTypeConverter))]
public enum HeadingItemType
{
    Heading,
}

sealed class HeadingItemTypeConverter : JsonConverter<HeadingItemType>
{
    public override HeadingItemType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "heading" => HeadingItemType.Heading,
            _ => (HeadingItemType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        HeadingItemType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                HeadingItemType.Heading => "heading",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
