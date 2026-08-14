using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;

namespace LlamaCloud.Models.Configurations;

/// <summary>
/// Upsert a product configuration; updates if one with the same name + product type
/// + project exists, otherwise creates.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ConfigurationCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Human-readable name for this configuration.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Product-specific configuration parameters.
    /// </summary>
    public required Parameters Parameters
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Parameters>("parameters");
        }
        init { this._rawBodyData.Set("parameters", value); }
    }

    public string? OrganizationID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("organization_id");
        }
        init { this._rawQueryData.Set("organization_id", value); }
    }

    public string? ProjectID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("project_id");
        }
        init { this._rawQueryData.Set("project_id", value); }
    }

    public ConfigurationCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConfigurationCreateParams(ConfigurationCreateParams configurationCreateParams)
        : base(configurationCreateParams)
    {
        this._rawBodyData = new(configurationCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ConfigurationCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConfigurationCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ConfigurationCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ConfigurationCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/beta/configurations"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Product-specific configuration parameters.
/// </summary>
[JsonConverter(typeof(ParametersConverter))]
public record class Parameters : ModelBase
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

    public JsonElement ProductType
    {
        get
        {
            return Match(
                classifyV2: (x) => x.ProductType,
                extractV2: (x) => x.ProductType,
                parseV2: (x) => x.ProductType,
                splitV1: (x) => x.ProductType,
                spreadsheetV1: (x) => x.ProductType,
                untyped: (x) => x.ProductType
            );
        }
    }

    public bool? DisableCache
    {
        get
        {
            return Match<bool?>(
                classifyV2: (_) => null,
                extractV2: (x) => x.DisableCache,
                parseV2: (x) => x.DisableCache,
                splitV1: (_) => null,
                spreadsheetV1: (_) => null,
                untyped: (_) => null
            );
        }
    }

    public Parameters(ClassifyV2Parameters value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Parameters(ExtractV2Parameters value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Parameters(ParseV2Parameters value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Parameters(SplitV1Parameters value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Parameters(SpreadsheetV1 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Parameters(UntypedParameters value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Parameters(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ClassifyV2Parameters"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickClassifyV2(out var value)) {
    ///     // `value` is of type `ClassifyV2Parameters`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickClassifyV2([NotNullWhen(true)] out ClassifyV2Parameters? value)
    {
        value = this.Value as ClassifyV2Parameters;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExtractV2Parameters"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExtractV2(out var value)) {
    ///     // `value` is of type `ExtractV2Parameters`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExtractV2([NotNullWhen(true)] out ExtractV2Parameters? value)
    {
        value = this.Value as ExtractV2Parameters;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ParseV2Parameters"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickParseV2(out var value)) {
    ///     // `value` is of type `ParseV2Parameters`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickParseV2([NotNullWhen(true)] out ParseV2Parameters? value)
    {
        value = this.Value as ParseV2Parameters;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SplitV1Parameters"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSplitV1(out var value)) {
    ///     // `value` is of type `SplitV1Parameters`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSplitV1([NotNullWhen(true)] out SplitV1Parameters? value)
    {
        value = this.Value as SplitV1Parameters;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SpreadsheetV1"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpreadsheetV1(out var value)) {
    ///     // `value` is of type `SpreadsheetV1`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpreadsheetV1([NotNullWhen(true)] out SpreadsheetV1? value)
    {
        value = this.Value as SpreadsheetV1;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UntypedParameters"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUntyped(out var value)) {
    ///     // `value` is of type `UntypedParameters`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUntyped([NotNullWhen(true)] out UntypedParameters? value)
    {
        value = this.Value as UntypedParameters;
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
    ///     (ClassifyV2Parameters value) =&gt; {...},
    ///     (ExtractV2Parameters value) =&gt; {...},
    ///     (ParseV2Parameters value) =&gt; {...},
    ///     (SplitV1Parameters value) =&gt; {...},
    ///     (SpreadsheetV1 value) =&gt; {...},
    ///     (UntypedParameters value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<ClassifyV2Parameters> classifyV2,
        Action<ExtractV2Parameters> extractV2,
        Action<ParseV2Parameters> parseV2,
        Action<SplitV1Parameters> splitV1,
        Action<SpreadsheetV1> spreadsheetV1,
        Action<UntypedParameters> untyped
    )
    {
        switch (this.Value)
        {
            case ClassifyV2Parameters value:
                classifyV2(value);
                break;
            case ExtractV2Parameters value:
                extractV2(value);
                break;
            case ParseV2Parameters value:
                parseV2(value);
                break;
            case SplitV1Parameters value:
                splitV1(value);
                break;
            case SpreadsheetV1 value:
                spreadsheetV1(value);
                break;
            case UntypedParameters value:
                untyped(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of Parameters"
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
    ///     (ClassifyV2Parameters value) =&gt; {...},
    ///     (ExtractV2Parameters value) =&gt; {...},
    ///     (ParseV2Parameters value) =&gt; {...},
    ///     (SplitV1Parameters value) =&gt; {...},
    ///     (SpreadsheetV1 value) =&gt; {...},
    ///     (UntypedParameters value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<ClassifyV2Parameters, T> classifyV2,
        Func<ExtractV2Parameters, T> extractV2,
        Func<ParseV2Parameters, T> parseV2,
        Func<SplitV1Parameters, T> splitV1,
        Func<SpreadsheetV1, T> spreadsheetV1,
        Func<UntypedParameters, T> untyped
    )
    {
        return this.Value switch
        {
            ClassifyV2Parameters value => classifyV2(value),
            ExtractV2Parameters value => extractV2(value),
            ParseV2Parameters value => parseV2(value),
            SplitV1Parameters value => splitV1(value),
            SpreadsheetV1 value => spreadsheetV1(value),
            UntypedParameters value => untyped(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of Parameters"
            ),
        };
    }

    public static implicit operator Parameters(ClassifyV2Parameters value) => new(value);

    public static implicit operator Parameters(ExtractV2Parameters value) => new(value);

    public static implicit operator Parameters(ParseV2Parameters value) => new(value);

    public static implicit operator Parameters(SplitV1Parameters value) => new(value);

    public static implicit operator Parameters(SpreadsheetV1 value) => new(value);

    public static implicit operator Parameters(UntypedParameters value) => new(value);

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
                "Data did not match any variant of Parameters"
            );
        }
        this.Switch(
            (classifyV2) => classifyV2.Validate(),
            (extractV2) => extractV2.Validate(),
            (parseV2) => parseV2.Validate(),
            (splitV1) => splitV1.Validate(),
            (spreadsheetV1) => spreadsheetV1.Validate(),
            (untyped) => untyped.Validate()
        );
    }

    public virtual bool Equals(Parameters? other) =>
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
            ClassifyV2Parameters _ => 0,
            ExtractV2Parameters _ => 1,
            ParseV2Parameters _ => 2,
            SplitV1Parameters _ => 3,
            SpreadsheetV1 _ => 4,
            UntypedParameters _ => 5,
            _ => -1,
        };
    }
}

sealed class ParametersConverter : JsonConverter<Parameters>
{
    public override Parameters? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? productType;
        try
        {
            productType = element.GetProperty("product_type").GetString();
        }
        catch
        {
            productType = null;
        }

        switch (productType)
        {
            case "classify_v2":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ClassifyV2Parameters>(
                        element,
                        options
                    );
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
            case "extract_v2":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ExtractV2Parameters>(
                        element,
                        options
                    );
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
            case "parse_v2":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ParseV2Parameters>(
                        element,
                        options
                    );
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
            case "split_v1":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SplitV1Parameters>(
                        element,
                        options
                    );
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
            case "spreadsheet_v1":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SpreadsheetV1>(element, options);
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
            case "unknown":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<UntypedParameters>(
                        element,
                        options
                    );
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
                return new Parameters(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        Parameters value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Typed parameters for a *spreadsheet v1* product configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SpreadsheetV1, SpreadsheetV1FromRaw>))]
public sealed record class SpreadsheetV1 : JsonModel
{
    /// <summary>
    /// Product type.
    /// </summary>
    public JsonElement ProductType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("product_type");
        }
        init { this._rawData.Set("product_type", value); }
    }

    /// <summary>
    /// A1 notation of the range to extract a single region from. If None, the entire
    /// sheet is used.
    /// </summary>
    public string? ExtractionRange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("extraction_range");
        }
        init { this._rawData.Set("extraction_range", value); }
    }

    /// <summary>
    /// Return a flattened dataframe when a detected table is recognized as hierarchical.
    /// </summary>
    public bool? FlattenHierarchicalTables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("flatten_hierarchical_tables");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("flatten_hierarchical_tables", value);
        }
    }

    /// <summary>
    /// Deprecated: controlled by `tier`. Whether to generate additional metadata
    /// (title, description) for each extracted region. Honored only on `agentic`.
    /// </summary>
    public bool? GenerateAdditionalMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("generate_additional_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("generate_additional_metadata", value);
        }
    }

    /// <summary>
    /// Whether to include hidden cells when extracting regions from the spreadsheet.
    /// </summary>
    public bool? IncludeHiddenCells
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("include_hidden_cells");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("include_hidden_cells", value);
        }
    }

    /// <summary>
    /// The names of the sheets to extract regions from. If empty, all sheets will
    /// be processed.
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
    /// Deprecated: controlled by `tier`. Optional specialization mode for domain-specific
    /// extraction. Supported values: 'financial-standard', 'financial-enhanced',
    /// 'financial-precise'. Default None uses the general-purpose pipeline. Honored
    /// only on `agentic`.
    /// </summary>
    public string? Specialization
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("specialization");
        }
        init { this._rawData.Set("specialization", value); }
    }

    /// <summary>
    /// Deprecated: controlled by `tier`. Influences how likely similar-looking regions
    /// are merged into a single table. Honored only on `agentic`.
    /// </summary>
    public ApiEnum<string, TableMergeSensitivity>? TableMergeSensitivity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TableMergeSensitivity>>(
                "table_merge_sensitivity"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("table_merge_sensitivity", value);
        }
    }

    /// <summary>
    /// Spreadsheet extraction tier. `cost_effective` uses the rule-based/ML-only
    /// pipeline; `agentic` uses the full pipeline.
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
    /// Deprecated: controlled by `tier`. Enables experimental processing. Honored
    /// only on `agentic`.
    /// </summary>
    public bool? UseExperimentalProcessing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("use_experimental_processing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("use_experimental_processing", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ProductType,
                JsonSerializer.SerializeToElement("spreadsheet_v1")
            )
        )
        {
            throw new LlamaCloudInvalidDataException("Invalid value given for constant");
        }
        _ = this.ExtractionRange;
        _ = this.FlattenHierarchicalTables;
        _ = this.GenerateAdditionalMetadata;
        _ = this.IncludeHiddenCells;
        _ = this.SheetNames;
        _ = this.Specialization;
        this.TableMergeSensitivity?.Validate();
        this.Tier?.Validate();
        _ = this.UseExperimentalProcessing;
    }

    public SpreadsheetV1()
    {
        this.ProductType = JsonSerializer.SerializeToElement("spreadsheet_v1");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpreadsheetV1(SpreadsheetV1 spreadsheetV1)
        : base(spreadsheetV1) { }
#pragma warning restore CS8618

    public SpreadsheetV1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ProductType = JsonSerializer.SerializeToElement("spreadsheet_v1");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpreadsheetV1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpreadsheetV1FromRaw.FromRawUnchecked"/>
    public static SpreadsheetV1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpreadsheetV1FromRaw : IFromRawJson<SpreadsheetV1>
{
    /// <inheritdoc/>
    public SpreadsheetV1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SpreadsheetV1.FromRawUnchecked(rawData);
}

/// <summary>
/// Deprecated: controlled by `tier`. Influences how likely similar-looking regions
/// are merged into a single table. Honored only on `agentic`.
/// </summary>
[JsonConverter(typeof(TableMergeSensitivityConverter))]
public enum TableMergeSensitivity
{
    Strong,
    Weak,
}

sealed class TableMergeSensitivityConverter : JsonConverter<TableMergeSensitivity>
{
    public override TableMergeSensitivity Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "strong" => TableMergeSensitivity.Strong,
            "weak" => TableMergeSensitivity.Weak,
            _ => (TableMergeSensitivity)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TableMergeSensitivity value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TableMergeSensitivity.Strong => "strong",
                TableMergeSensitivity.Weak => "weak",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Spreadsheet extraction tier. `cost_effective` uses the rule-based/ML-only pipeline;
/// `agentic` uses the full pipeline.
/// </summary>
[JsonConverter(typeof(TierConverter))]
public enum Tier
{
    Agentic,
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
                Tier.CostEffective => "cost_effective",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
