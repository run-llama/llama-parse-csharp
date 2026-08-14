using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Parsing;

[JsonConverter(typeof(JsonModelConverter<TableItem, TableItemFromRaw>))]
public sealed record class TableItem : JsonModel
{
    /// <summary>
    /// CSV representation of the table
    /// </summary>
    public required string Csv
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("csv");
        }
        init { this._rawData.Set("csv", value); }
    }

    /// <summary>
    /// HTML representation of the table
    /// </summary>
    public required string Html
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("html");
        }
        init { this._rawData.Set("html", value); }
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
    /// Table data as array of arrays (string, number, or null)
    /// </summary>
    public required IReadOnlyList<IReadOnlyList<TableItemRow?>> Rows
    {
        get
        {
            this._rawData.Freeze();
            return ImmutableArray.ToImmutableArray(
                Enumerable.Select(
                    this._rawData.GetNotNullStruct<ImmutableArray<ImmutableArray<TableItemRow?>>>(
                        "rows"
                    ),
                    (item) => (IReadOnlyList<TableItemRow?>)item
                )
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ImmutableArray<TableItemRow?>>>(
                "rows",
                ImmutableArray.ToImmutableArray(
                    Enumerable.Select(value, (item) => ImmutableArray.ToImmutableArray(item))
                )
            );
        }
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
    /// List of page numbers with tables that were merged into this table (e.g., [1,
    /// 2, 3, 4])
    /// </summary>
    public IReadOnlyList<long>? MergedFromPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("merged_from_pages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<long>?>(
                "merged_from_pages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Populated when merged into another table. Page number where the full merged
    /// table begins (used on empty tables).
    /// </summary>
    public long? MergedIntoPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("merged_into_page");
        }
        init { this._rawData.Set("merged_into_page", value); }
    }

    /// <summary>
    /// Quality concerns detected during table extraction, indicating the table may
    /// have issues
    /// </summary>
    public IReadOnlyList<ParseConcern>? ParseConcerns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ParseConcern>>("parse_concerns");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ParseConcern>?>(
                "parse_concerns",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Table item type
    /// </summary>
    public ApiEnum<string, TableItemType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TableItemType>>("type");
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
        _ = this.Csv;
        _ = this.Html;
        _ = this.Md;
        foreach (var item in this.Rows)
        {
            foreach (var item1 in item)
            {
                item1?.Validate();
            }
        }
        foreach (var item in this.Bbox ?? [])
        {
            item.Validate();
        }
        _ = this.MergedFromPages;
        _ = this.MergedIntoPage;
        foreach (var item in this.ParseConcerns ?? [])
        {
            item.Validate();
        }
        this.Type?.Validate();
    }

    public TableItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TableItem(TableItem tableItem)
        : base(tableItem) { }
#pragma warning restore CS8618

    public TableItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TableItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TableItemFromRaw.FromRawUnchecked"/>
    public static TableItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TableItemFromRaw : IFromRawJson<TableItem>
{
    /// <inheritdoc/>
    public TableItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TableItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TableItemRowConverter))]
public record class TableItemRow : ModelBase
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

    public TableItemRow(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TableItemRow(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TableItemRow(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<string> @string, System::Action<double> @double)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of TableItemRow"
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<string, T> @string, System::Func<double, T> @double)
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of TableItemRow"
            ),
        };
    }

    public static implicit operator TableItemRow(string value) => new(value);

    public static implicit operator TableItemRow(double value) => new(value);

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
                "Data did not match any variant of TableItemRow"
            );
        }
    }

    public virtual bool Equals(TableItemRow? other) =>
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
            string _ => 0,
            double _ => 1,
            _ => -1,
        };
    }
}

sealed class TableItemRowConverter : JsonConverter<TableItemRow?>
{
    public override TableItemRow? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        TableItemRow? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<ParseConcern, ParseConcernFromRaw>))]
public sealed record class ParseConcern : JsonModel
{
    /// <summary>
    /// Human-readable details about the concern
    /// </summary>
    public required string Details
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("details");
        }
        init { this._rawData.Set("details", value); }
    }

    /// <summary>
    /// Type of parse concern (e.g. header_value_type_mismatch, inconsistent_row_cell_count)
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Details;
        _ = this.Type;
    }

    public ParseConcern() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParseConcern(ParseConcern parseConcern)
        : base(parseConcern) { }
#pragma warning restore CS8618

    public ParseConcern(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParseConcern(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParseConcernFromRaw.FromRawUnchecked"/>
    public static ParseConcern FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParseConcernFromRaw : IFromRawJson<ParseConcern>
{
    /// <inheritdoc/>
    public ParseConcern FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ParseConcern.FromRawUnchecked(rawData);
}

/// <summary>
/// Table item type
/// </summary>
[JsonConverter(typeof(TableItemTypeConverter))]
public enum TableItemType
{
    Table,
}

sealed class TableItemTypeConverter : JsonConverter<TableItemType>
{
    public override TableItemType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "table" => TableItemType.Table,
            _ => (TableItemType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TableItemType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TableItemType.Table => "table",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
