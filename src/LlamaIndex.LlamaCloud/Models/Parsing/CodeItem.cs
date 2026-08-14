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

[JsonConverter(typeof(JsonModelConverter<CodeItem, CodeItemFromRaw>))]
public sealed record class CodeItem : JsonModel
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
    /// Code content
    /// </summary>
    public required string ValueValue
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
    /// Programming language identifier
    /// </summary>
    public string? Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("language");
        }
        init { this._rawData.Set("language", value); }
    }

    /// <summary>
    /// Code block item type
    /// </summary>
    public ApiEnum<string, global::LlamaIndex.LlamaCloud.Models.Parsing.Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::LlamaIndex.LlamaCloud.Models.Parsing.Type>
            >("type");
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
        _ = this.ValueValue;
        foreach (var item in this.Bbox ?? [])
        {
            item.Validate();
        }
        _ = this.Language;
        this.Type?.Validate();
    }

    public CodeItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CodeItem(CodeItem codeItem)
        : base(codeItem) { }
#pragma warning restore CS8618

    public CodeItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CodeItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CodeItemFromRaw.FromRawUnchecked"/>
    public static CodeItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CodeItemFromRaw : IFromRawJson<CodeItem>
{
    /// <inheritdoc/>
    public CodeItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CodeItem.FromRawUnchecked(rawData);
}

/// <summary>
/// Code block item type
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Code,
}

sealed class TypeConverter : JsonConverter<global::LlamaIndex.LlamaCloud.Models.Parsing.Type>
{
    public override global::LlamaIndex.LlamaCloud.Models.Parsing.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "code" => global::LlamaIndex.LlamaCloud.Models.Parsing.Type.Code,
            _ => (global::LlamaIndex.LlamaCloud.Models.Parsing.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::LlamaIndex.LlamaCloud.Models.Parsing.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::LlamaIndex.LlamaCloud.Models.Parsing.Type.Code => "code",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
