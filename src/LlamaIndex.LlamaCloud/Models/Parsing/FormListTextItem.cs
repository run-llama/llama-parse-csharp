using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Parsing;

/// <summary>
/// One line of a form's list representation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FormListTextItem, FormListTextItemFromRaw>))]
public sealed record class FormListTextItem : JsonModel
{
    /// <summary>
    /// Markdown representation of the line
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
    /// Line content (e.g. '[1a] Wages: 29,513')
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
    /// Text line
    /// </summary>
    public ApiEnum<string, FormListTextItemType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FormListTextItemType>>("type");
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
        _ = this.Value;
        this.Type?.Validate();
    }

    public FormListTextItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormListTextItem(FormListTextItem formListTextItem)
        : base(formListTextItem) { }
#pragma warning restore CS8618

    public FormListTextItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormListTextItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormListTextItemFromRaw.FromRawUnchecked"/>
    public static FormListTextItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormListTextItemFromRaw : IFromRawJson<FormListTextItem>
{
    /// <inheritdoc/>
    public FormListTextItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FormListTextItem.FromRawUnchecked(rawData);
}

/// <summary>
/// Text line
/// </summary>
[JsonConverter(typeof(FormListTextItemTypeConverter))]
public enum FormListTextItemType
{
    Text,
}

sealed class FormListTextItemTypeConverter : JsonConverter<FormListTextItemType>
{
    public override FormListTextItemType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => FormListTextItemType.Text,
            _ => (FormListTextItemType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FormListTextItemType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FormListTextItemType.Text => "text",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
