using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;

namespace LlamaIndex.LlamaCloud.Models.Extract;

/// <summary>
/// Extract configuration combining parse and extract settings.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExtractConfiguration, ExtractConfigurationFromRaw>))]
public sealed record class ExtractConfiguration : JsonModel
{
    /// <summary>
    /// JSON Schema defining the fields to extract. Validate with the /schema/validate
    /// endpoint first.
    /// </summary>
    public required IReadOnlyDictionary<string, ExtractConfigurationDataSchema?> DataSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                FrozenDictionary<string, ExtractConfigurationDataSchema?>
            >("data_schema");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, ExtractConfigurationDataSchema?>>(
                "data_schema",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Include citations in results. Returned under `extract_metadata` (auto-included
    /// when set). Text-level on `turbo` (no bounding boxes).
    /// </summary>
    public bool? CiteSources
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("cite_sources");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cite_sources", value);
        }
    }

    /// <summary>
    /// Include confidence scores in results. Returned under `extract_metadata` (auto-included
    /// when set).
    /// </summary>
    public bool? ConfidenceScores
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("confidence_scores");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confidence_scores", value);
        }
    }

    /// <summary>
    /// Disable reuse and storage of Extract results
    /// </summary>
    public bool? DisableCache
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("disable_cache");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("disable_cache", value);
        }
    }

    /// <summary>
    /// Granularity of extraction: per_doc returns one object per document, per_page
    /// returns one object per page, per_table_row returns one object per table row
    /// </summary>
    public ApiEnum<string, ExtractionTarget>? ExtractionTarget
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ExtractionTarget>>(
                "extraction_target"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("extraction_target", value);
        }
    }

    /// <summary>
    /// Maximum number of pages to process. Omit for no limit.
    /// </summary>
    public long? MaxPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_pages");
        }
        init { this._rawData.Set("max_pages", value); }
    }

    /// <summary>
    /// Saved parse configuration ID to control how the document is parsed before
    /// extraction. Turbo extract does not support parse configuration or produce
    /// a parse output; use another tier if your workflow requires parsed text.
    /// </summary>
    public string? ParseConfigID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parse_config_id");
        }
        init { this._rawData.Set("parse_config_id", value); }
    }

    /// <summary>
    /// Parse tier to use before extraction. Defaults to the extract tier if not specified.
    /// Turbo extract does not support parse configuration or produce a parse output;
    /// use another tier if your workflow requires parsed text.
    /// </summary>
    public string? ParseTier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parse_tier");
        }
        init { this._rawData.Set("parse_tier", value); }
    }

    /// <summary>
    /// Optional worksheet names to extract when spreadsheet_mode is on. Overrides
    /// target_pages for spreadsheets; omit to extract every sheet. Names are matched
    /// exactly (case-sensitive) — pass them as a list, e.g. ["Sheet 1", "My Sheet"].
    /// </summary>
    public IReadOnlyList<string>? SheetNames
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("sheet_names");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "sheet_names",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Beta. When true, extract structured data directly from a spreadsheet workbook
    /// (.xlsx/.xls/.csv) — the agent reads cells straight from the workbook instead
    /// of the standard document path. Off by default (spreadsheets keep the standard
    /// path). Requires the agentic_plus tier. Billed on the standard per-page extract
    /// rate, against a page count derived from workbook size. Citations and confidence
    /// scores are not available in this mode.
    /// </summary>
    public bool? SpreadsheetMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("spreadsheet_mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("spreadsheet_mode", value);
        }
    }

    /// <summary>
    /// Custom system prompt to guide extraction behavior
    /// </summary>
    public string? SystemPrompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("system_prompt");
        }
        init { this._rawData.Set("system_prompt", value); }
    }

    /// <summary>
    /// Comma-separated page numbers or ranges to process (1-based). Omit to process
    /// all pages.
    /// </summary>
    public string? TargetPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("target_pages");
        }
        init { this._rawData.Set("target_pages", value); }
    }

    /// <summary>
    /// Extract tier: cost_effective (5 credits/page), agentic (15 credits/page),
    /// or agentic_plus (50 credits/page)
    /// </summary>
    public ApiEnum<string, Tier>? Tier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Tier>>("tier");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tier", value);
        }
    }

    /// <summary>
    /// Use 'latest' for the latest release for the selected tier or a date string
    /// (YYYY-MM-DD format) to pin to the nearest release at or before that date.
    /// Job responses always report the concrete resolved version the job runs, fixed
    /// at job creation; saved configurations keep the value as provided.
    /// </summary>
    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.DataSchema.Values)
        {
            item?.Validate();
        }
        _ = this.CiteSources;
        _ = this.ConfidenceScores;
        _ = this.DisableCache;
        this.ExtractionTarget?.Validate();
        _ = this.MaxPages;
        _ = this.ParseConfigID;
        _ = this.ParseTier;
        _ = this.SheetNames;
        _ = this.SpreadsheetMode;
        _ = this.SystemPrompt;
        _ = this.TargetPages;
        this.Tier?.Validate();
        _ = this.Version;
    }

    public ExtractConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractConfiguration(ExtractConfiguration extractConfiguration)
        : base(extractConfiguration) { }
#pragma warning restore CS8618

    public ExtractConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractConfigurationFromRaw.FromRawUnchecked"/>
    public static ExtractConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExtractConfiguration(
        IReadOnlyDictionary<string, ExtractConfigurationDataSchema?> dataSchema
    )
        : this()
    {
        this.DataSchema = dataSchema;
    }
}

class ExtractConfigurationFromRaw : IFromRawJson<ExtractConfiguration>
{
    /// <inheritdoc/>
    public ExtractConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtractConfiguration.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ExtractConfigurationDataSchemaConverter))]
public record class ExtractConfigurationDataSchema : ModelBase
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

    public ExtractConfigurationDataSchema(
        IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public ExtractConfigurationDataSchema(
        IReadOnlyList<JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ExtractConfigurationDataSchema(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtractConfigurationDataSchema(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtractConfigurationDataSchema(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtractConfigurationDataSchema(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Dictionary{Key, Value}"/> with a <c>Key</c> of <c>string</c> and a <c>Value</c> of <c>JsonElement</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElements(out var value)) {
    ///     // `value` is of type `IReadOnlyDictionary&lt;string, JsonElement&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElements(
        [NotNullWhen(true)] out IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value = this.Value as IReadOnlyDictionary<string, JsonElement>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>JsonElement</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElements1(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;JsonElement&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElements1([NotNullWhen(true)] out IReadOnlyList<JsonElement>? value)
    {
        value = this.Value as IReadOnlyList<JsonElement>;
        return value != null;
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
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
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
    ///     (IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
    ///     (IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<IReadOnlyDictionary<string, JsonElement>> jsonElements,
        Action<IReadOnlyList<JsonElement>> jsonElements1,
        Action<string> @string,
        Action<double> @double,
        Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case IReadOnlyDictionary<string, JsonElement> value:
                jsonElements(value);
                break;
            case IReadOnlyList<JsonElement> value:
                jsonElements1(value);
                break;
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of ExtractConfigurationDataSchema"
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
    ///     (IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
    ///     (IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<IReadOnlyDictionary<string, JsonElement>, T> jsonElements,
        Func<IReadOnlyList<JsonElement>, T> jsonElements1,
        Func<string, T> @string,
        Func<double, T> @double,
        Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            IReadOnlyDictionary<string, JsonElement> value => jsonElements(value),
            IReadOnlyList<JsonElement> value => jsonElements1(value),
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of ExtractConfigurationDataSchema"
            ),
        };
    }

    public static implicit operator ExtractConfigurationDataSchema(
        Dictionary<string, JsonElement> value
    ) => new((IReadOnlyDictionary<string, JsonElement>)value);

    public static implicit operator ExtractConfigurationDataSchema(List<JsonElement> value) =>
        new((IReadOnlyList<JsonElement>)value);

    public static implicit operator ExtractConfigurationDataSchema(string value) => new(value);

    public static implicit operator ExtractConfigurationDataSchema(double value) => new(value);

    public static implicit operator ExtractConfigurationDataSchema(bool value) => new(value);

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
                "Data did not match any variant of ExtractConfigurationDataSchema"
            );
        }
    }

    public virtual bool Equals(ExtractConfigurationDataSchema? other) =>
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
            IReadOnlyDictionary<string, JsonElement> _ => 0,
            IReadOnlyList<JsonElement> _ => 1,
            string _ => 2,
            double _ => 3,
            bool _ => 4,
            _ => -1,
        };
    }
}

sealed class ExtractConfigurationDataSchemaConverter
    : JsonConverter<ExtractConfigurationDataSchema?>
{
    public override ExtractConfigurationDataSchema? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                element,
                options
            );
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<JsonElement>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractConfigurationDataSchema? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Granularity of extraction: per_doc returns one object per document, per_page
/// returns one object per page, per_table_row returns one object per table row
/// </summary>
[JsonConverter(typeof(ExtractionTargetConverter))]
public enum ExtractionTarget
{
    PerDoc,
    PerPage,
    PerTableRow,
}

sealed class ExtractionTargetConverter : JsonConverter<ExtractionTarget>
{
    public override ExtractionTarget Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "per_doc" => ExtractionTarget.PerDoc,
            "per_page" => ExtractionTarget.PerPage,
            "per_table_row" => ExtractionTarget.PerTableRow,
            _ => (ExtractionTarget)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionTarget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionTarget.PerDoc => "per_doc",
                ExtractionTarget.PerPage => "per_page",
                ExtractionTarget.PerTableRow => "per_table_row",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Extract tier: cost_effective (5 credits/page), agentic (15 credits/page), or agentic_plus
/// (50 credits/page)
/// </summary>
[JsonConverter(typeof(TierConverter))]
public enum Tier
{
    Agentic,
    AgenticPlus,
    CostEffective,
}

sealed class TierConverter : JsonConverter<Tier>
{
    public override Tier Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agentic" => Tier.Agentic,
            "agentic_plus" => Tier.AgenticPlus,
            "cost_effective" => Tier.CostEffective,
            _ => (Tier)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Tier value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Tier.Agentic => "agentic",
                Tier.AgenticPlus => "agentic_plus",
                Tier.CostEffective => "cost_effective",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
