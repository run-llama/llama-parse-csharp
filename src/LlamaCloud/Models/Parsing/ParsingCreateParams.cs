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
using System = System;

namespace LlamaCloud.Models.Parsing;

/// <summary>
/// Parse a file by file ID or URL.
///
/// <para>Provide either `file_id` (a previously uploaded file) or `source_url` (a
/// publicly accessible URL). Configure parsing with options like `tier`, `target_pages`,
/// and `lang`.</para>
///
/// <para>## Tiers</para>
///
/// <para>- `fast` — rule-based, cheapest, no AI - `cost_effective` — balanced speed
/// and quality - `agentic` — full AI-powered parsing - `agentic_plus` — premium
/// AI with specialized features</para>
///
/// <para>The job runs asynchronously. Poll `GET /parse/{job_id}` with `expand=text`
/// or `expand=markdown` to retrieve results.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ParsingCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Parsing tier: 'fast' (rule-based, cheapest), 'cost_effective' (balanced),
    /// 'agentic' (AI-powered with custom prompts), or 'agentic_plus' (premium AI
    /// with highest accuracy)
    /// </summary>
    public required ApiEnum<string, Tier> Tier
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Tier>>("tier");
        }
        init { this._rawBodyData.Set("tier", value); }
    }

    /// <summary>
    /// Version for the selected tier. Use `latest`, or pin one of that tier's dated versions.
    ///
    /// <para>Current `latest` by tier: - `fast`: `2026-06-15` - `cost_effective`:
    /// `2026-08-19` - `agentic`: `2026-08-19` - `agentic_plus`: `2026-08-19`</para>
    ///
    /// <para>Full list: `GET /api/v2/parse/versions`.</para>
    /// </summary>
    public required ApiEnum<string, Version> Version
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Version>>("version");
        }
        init { this._rawBodyData.Set("version", value); }
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

    /// <summary>
    /// Options for AI-powered parsing tiers (cost_effective, agentic, agentic_plus).
    ///
    /// <para>These options customize how the AI processes and interprets document
    /// content. Only applicable when using non-fast tiers.</para>
    /// </summary>
    public AgenticOptions? AgenticOptions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<AgenticOptions>("agentic_options");
        }
        init { this._rawBodyData.Set("agentic_options", value); }
    }

    /// <summary>
    /// Identifier for the client/application making the request. Used for analytics
    /// and debugging. Example: 'my-app-v2'
    /// </summary>
    public string? ClientName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("client_name");
        }
        init { this._rawBodyData.Set("client_name", value); }
    }

    /// <summary>
    /// ID of a saved parse configuration. When set, `tier` and `version` default
    /// to the saved configuration's values — omit them or pass `'configured'`.
    /// </summary>
    public string? ConfigurationID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("configuration_id");
        }
        init { this._rawBodyData.Set("configuration_id", value); }
    }

    /// <summary>
    /// Crop boundaries to process only a portion of each page. Values are ratios
    /// 0-1 from page edges
    /// </summary>
    public CropBox? CropBox
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CropBox>("crop_box");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("crop_box", value);
        }
    }

    /// <summary>
    /// Bypass result caching and force re-parsing. Use when document content may
    /// have changed or you need fresh results
    /// </summary>
    public bool? DisableCache
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("disable_cache");
        }
        init { this._rawBodyData.Set("disable_cache", value); }
    }

    /// <summary>
    /// Options for fast tier parsing (rule-based, no AI).
    ///
    /// <para>Fast tier uses deterministic algorithms for text extraction without
    /// AI enhancement. It's the fastest and most cost-effective option, best suited
    /// for simple documents with standard layouts. Currently has no configurable
    /// options but reserved for future expansion.</para>
    /// </summary>
    public JsonElement? FastOptions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<JsonElement>("fast_options");
        }
        init { this._rawBodyData.Set("fast_options", value); }
    }

    /// <summary>
    /// ID of an existing file in the project to parse. Mutually exclusive with source_url
    /// </summary>
    public string? FileID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("file_id");
        }
        init { this._rawBodyData.Set("file_id", value); }
    }

    /// <summary>
    /// HTTP/HTTPS proxy for fetching source_url. Ignored if using file_id
    /// </summary>
    public string? HttpProxy
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("http_proxy");
        }
        init { this._rawBodyData.Set("http_proxy", value); }
    }

    /// <summary>
    /// Format-specific options (HTML, PDF, spreadsheet, presentation). Applied based
    /// on detected input file type
    /// </summary>
    public InputOptions? InputOptions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<InputOptions>("input_options");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("input_options", value);
        }
    }

    /// <summary>
    /// Output formatting options for markdown, text, and extracted images
    /// </summary>
    public OutputOptions? OutputOptions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<OutputOptions>("output_options");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("output_options", value);
        }
    }

    /// <summary>
    /// Page selection: limit total pages or specify exact pages to process
    /// </summary>
    public PageRanges? PageRanges
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PageRanges>("page_ranges");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("page_ranges", value);
        }
    }

    /// <summary>
    /// Job execution controls including timeouts and failure thresholds
    /// </summary>
    public ProcessingControl? ProcessingControl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ProcessingControl>("processing_control");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("processing_control", value);
        }
    }

    /// <summary>
    /// Document processing options including OCR, table extraction, and chart parsing
    /// </summary>
    public ProcessingOptions? ProcessingOptions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ProcessingOptions>("processing_options");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("processing_options", value);
        }
    }

    /// <summary>
    /// Public URL of the document to parse. Mutually exclusive with file_id
    /// </summary>
    public string? SourceUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("source_url");
        }
        init { this._rawBodyData.Set("source_url", value); }
    }

    /// <summary>
    /// Arbitrary key/value tags to attach to this job. Returned when retrieving the
    /// job. Not searchable. Limits apply to the number of entries and the length
    /// of keys and values; oversized metadata is rejected.
    /// </summary>
    public IReadOnlyDictionary<string, string>? UserMetadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>(
                "user_metadata"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "user_metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// IDs of saved webhook configurations to notify for this job.
    /// </summary>
    public IReadOnlyList<string>? WebhookConfigurationIds
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "webhook_configuration_ids"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "webhook_configuration_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Webhook endpoints for job status notifications. Multiple webhooks can be
    /// configured for different events or services
    /// </summary>
    public IReadOnlyList<WebhookConfiguration>? WebhookConfigurations
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<WebhookConfiguration>>(
                "webhook_configurations"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<WebhookConfiguration>?>(
                "webhook_configurations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ParsingCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParsingCreateParams(ParsingCreateParams parsingCreateParams)
        : base(parsingCreateParams)
    {
        this._rawBodyData = new(parsingCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ParsingCreateParams(
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
    ParsingCreateParams(
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
    public static ParsingCreateParams FromRawUnchecked(
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

    public virtual bool Equals(ParsingCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v2/parse")
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
/// Parsing tier: 'fast' (rule-based, cheapest), 'cost_effective' (balanced), 'agentic'
/// (AI-powered with custom prompts), or 'agentic_plus' (premium AI with highest accuracy)
/// </summary>
[JsonConverter(typeof(TierConverter))]
public enum Tier
{
    Fast,
    CostEffective,
    Agentic,
    AgenticPlus,
}

sealed class TierConverter : JsonConverter<Tier>
{
    public override Tier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fast" => Tier.Fast,
            "cost_effective" => Tier.CostEffective,
            "agentic" => Tier.Agentic,
            "agentic_plus" => Tier.AgenticPlus,
            _ => (Tier)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Tier value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Tier.Fast => "fast",
                Tier.CostEffective => "cost_effective",
                Tier.Agentic => "agentic",
                Tier.AgenticPlus => "agentic_plus",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Version for the selected tier. Use `latest`, or pin one of that tier's dated versions.
///
/// <para>Current `latest` by tier: - `fast`: `2026-06-15` - `cost_effective`: `2026-08-19`
/// - `agentic`: `2026-08-19` - `agentic_plus`: `2026-08-19`</para>
///
/// <para>Full list: `GET /api/v2/parse/versions`.</para>
/// </summary>
[JsonConverter(typeof(VersionConverter))]
public enum Version
{
    Latest,
    V2026_08_19,
    V2026_06_15,
}

sealed class VersionConverter : JsonConverter<Version>
{
    public override Version Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "latest" => Version.Latest,
            "2026-08-19" => Version.V2026_08_19,
            "2026-06-15" => Version.V2026_06_15,
            _ => (Version)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Version value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Version.Latest => "latest",
                Version.V2026_08_19 => "2026-08-19",
                Version.V2026_06_15 => "2026-06-15",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Options for AI-powered parsing tiers (cost_effective, agentic, agentic_plus).
///
/// <para>These options customize how the AI processes and interprets document content.
/// Only applicable when using non-fast tiers.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AgenticOptions, AgenticOptionsFromRaw>))]
public sealed record class AgenticOptions : JsonModel
{
    /// <summary>
    /// Custom instructions for the AI parser. Use to guide extraction behavior, specify
    /// output formatting, or provide domain-specific context. Example: 'Extract
    /// financial tables with currency symbols. Format dates as YYYY-MM-DD.'
    /// </summary>
    public string? CustomPrompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("custom_prompt");
        }
        init { this._rawData.Set("custom_prompt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CustomPrompt;
    }

    public AgenticOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgenticOptions(AgenticOptions agenticOptions)
        : base(agenticOptions) { }
#pragma warning restore CS8618

    public AgenticOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgenticOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgenticOptionsFromRaw.FromRawUnchecked"/>
    public static AgenticOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgenticOptionsFromRaw : IFromRawJson<AgenticOptions>
{
    /// <inheritdoc/>
    public AgenticOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgenticOptions.FromRawUnchecked(rawData);
}

/// <summary>
/// Crop boundaries to process only a portion of each page. Values are ratios 0-1
/// from page edges
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CropBox, CropBoxFromRaw>))]
public sealed record class CropBox : JsonModel
{
    /// <summary>
    /// Bottom boundary as ratio (0-1). 0=top edge, 1=bottom edge. Content below this
    /// line is excluded
    /// </summary>
    public double? Bottom
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("bottom");
        }
        init { this._rawData.Set("bottom", value); }
    }

    /// <summary>
    /// Left boundary as ratio (0-1). 0=left edge, 1=right edge. Content left of
    /// this line is excluded
    /// </summary>
    public double? Left
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("left");
        }
        init { this._rawData.Set("left", value); }
    }

    /// <summary>
    /// Right boundary as ratio (0-1). 0=left edge, 1=right edge. Content right of
    /// this line is excluded
    /// </summary>
    public double? Right
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("right");
        }
        init { this._rawData.Set("right", value); }
    }

    /// <summary>
    /// Top boundary as ratio (0-1). 0=top edge, 1=bottom edge. Content above this
    /// line is excluded
    /// </summary>
    public double? Top
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("top");
        }
        init { this._rawData.Set("top", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Bottom;
        _ = this.Left;
        _ = this.Right;
        _ = this.Top;
    }

    public CropBox() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CropBox(CropBox cropBox)
        : base(cropBox) { }
#pragma warning restore CS8618

    public CropBox(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CropBox(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CropBoxFromRaw.FromRawUnchecked"/>
    public static CropBox FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CropBoxFromRaw : IFromRawJson<CropBox>
{
    /// <inheritdoc/>
    public CropBox FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CropBox.FromRawUnchecked(rawData);
}

/// <summary>
/// Format-specific options (HTML, PDF, spreadsheet, presentation). Applied based
/// on detected input file type
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InputOptions, InputOptionsFromRaw>))]
public sealed record class InputOptions : JsonModel
{
    /// <summary>
    /// HTML/web page parsing options (applies to .html, .htm files)
    /// </summary>
    public Html? Html
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Html>("html");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("html", value);
        }
    }

    /// <summary>
    /// Image parsing options (applies to .jpg, .jpeg, .png, .webp files)
    /// </summary>
    public Image? Image
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Image>("image");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("image", value);
        }
    }

    /// <summary>
    /// PDF-specific parsing options (applies to .pdf files)
    /// </summary>
    public JsonElement? Pdf
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("pdf");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pdf", value);
        }
    }

    /// <summary>
    /// Presentation parsing options (applies to .pptx, .ppt, .odp, .key files)
    /// </summary>
    public Presentation? Presentation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Presentation>("presentation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("presentation", value);
        }
    }

    /// <summary>
    /// Spreadsheet parsing options (applies to .xlsx, .xls, .csv, .ods files)
    /// </summary>
    public Spreadsheet? Spreadsheet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Spreadsheet>("spreadsheet");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("spreadsheet", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Html?.Validate();
        this.Image?.Validate();
        _ = this.Pdf;
        this.Presentation?.Validate();
        this.Spreadsheet?.Validate();
    }

    public InputOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InputOptions(InputOptions inputOptions)
        : base(inputOptions) { }
#pragma warning restore CS8618

    public InputOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InputOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InputOptionsFromRaw.FromRawUnchecked"/>
    public static InputOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InputOptionsFromRaw : IFromRawJson<InputOptions>
{
    /// <inheritdoc/>
    public InputOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InputOptions.FromRawUnchecked(rawData);
}

/// <summary>
/// HTML/web page parsing options (applies to .html, .htm files)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Html, HtmlFromRaw>))]
public sealed record class Html : JsonModel
{
    /// <summary>
    /// Force all HTML elements to be visible by overriding CSS display/visibility
    /// properties. Useful for parsing pages with hidden content or collapsed sections
    /// </summary>
    public bool? MakeAllElementsVisible
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("make_all_elements_visible");
        }
        init { this._rawData.Set("make_all_elements_visible", value); }
    }

    /// <summary>
    /// Remove fixed-position elements (headers, footers, floating buttons) that
    /// appear on every page render
    /// </summary>
    public bool? RemoveFixedElements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("remove_fixed_elements");
        }
        init { this._rawData.Set("remove_fixed_elements", value); }
    }

    /// <summary>
    /// Remove navigation elements (nav bars, sidebars, menus) to focus on main content
    /// </summary>
    public bool? RemoveNavigationElements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("remove_navigation_elements");
        }
        init { this._rawData.Set("remove_navigation_elements", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MakeAllElementsVisible;
        _ = this.RemoveFixedElements;
        _ = this.RemoveNavigationElements;
    }

    public Html() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Html(Html html)
        : base(html) { }
#pragma warning restore CS8618

    public Html(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Html(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HtmlFromRaw.FromRawUnchecked"/>
    public static Html FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HtmlFromRaw : IFromRawJson<Html>
{
    /// <inheritdoc/>
    public Html FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Html.FromRawUnchecked(rawData);
}

/// <summary>
/// Image parsing options (applies to .jpg, .jpeg, .png, .webp files)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Image, ImageFromRaw>))]
public sealed record class Image : JsonModel
{
    /// <summary>
    /// Detect documents photographed with a camera (e.g. phone scans of receipts
    /// or forms), then crop, perspective-correct, and flatten uneven lighting and
    /// shadows before parsing. Supports JPEG, PNG, WebP, and HEIC/HEIF inputs. Improves
    /// results when the document is tilted or surrounded by background. Images that
    /// already look like clean scans are left untouched
    /// </summary>
    public bool? CameraPhotoCorrection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("camera_photo_correction");
        }
        init { this._rawData.Set("camera_photo_correction", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CameraPhotoCorrection;
    }

    public Image() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Image(Image image)
        : base(image) { }
#pragma warning restore CS8618

    public Image(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Image(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageFromRaw.FromRawUnchecked"/>
    public static Image FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageFromRaw : IFromRawJson<Image>
{
    /// <inheritdoc/>
    public Image FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Image.FromRawUnchecked(rawData);
}

/// <summary>
/// Presentation parsing options (applies to .pptx, .ppt, .odp, .key files)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Presentation, PresentationFromRaw>))]
public sealed record class Presentation : JsonModel
{
    /// <summary>
    /// Extract content positioned outside the visible slide area. Some presentations
    /// have hidden notes or content that extends beyond slide boundaries
    /// </summary>
    public bool? OutOfBoundsContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("out_of_bounds_content");
        }
        init { this._rawData.Set("out_of_bounds_content", value); }
    }

    /// <summary>
    /// Skip extraction of embedded chart data tables. When true, only the visual
    /// representation of charts is captured, not the underlying data
    /// </summary>
    public bool? SkipEmbeddedData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("skip_embedded_data");
        }
        init { this._rawData.Set("skip_embedded_data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.OutOfBoundsContent;
        _ = this.SkipEmbeddedData;
    }

    public Presentation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Presentation(Presentation presentation)
        : base(presentation) { }
#pragma warning restore CS8618

    public Presentation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Presentation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PresentationFromRaw.FromRawUnchecked"/>
    public static Presentation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PresentationFromRaw : IFromRawJson<Presentation>
{
    /// <inheritdoc/>
    public Presentation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Presentation.FromRawUnchecked(rawData);
}

/// <summary>
/// Spreadsheet parsing options (applies to .xlsx, .xls, .csv, .ods files)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Spreadsheet, SpreadsheetFromRaw>))]
public sealed record class Spreadsheet : JsonModel
{
    /// <summary>
    /// Detect and extract multiple tables within a single sheet. Useful when spreadsheets
    /// contain several data regions separated by blank rows/columns
    /// </summary>
    public bool? DetectSubTablesInSheets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("detect_sub_tables_in_sheets");
        }
        init { this._rawData.Set("detect_sub_tables_in_sheets", value); }
    }

    /// <summary>
    /// Compute formula results instead of extracting formula text. Use when you need
    /// calculated values rather than formula definitions
    /// </summary>
    public bool? ForceFormulaComputationInSheets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("force_formula_computation_in_sheets");
        }
        init { this._rawData.Set("force_formula_computation_in_sheets", value); }
    }

    /// <summary>
    /// Parse hidden sheets in addition to visible ones. By default, hidden sheets
    /// are skipped
    /// </summary>
    public bool? IncludeHiddenSheets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("include_hidden_sheets");
        }
        init { this._rawData.Set("include_hidden_sheets", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DetectSubTablesInSheets;
        _ = this.ForceFormulaComputationInSheets;
        _ = this.IncludeHiddenSheets;
    }

    public Spreadsheet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Spreadsheet(Spreadsheet spreadsheet)
        : base(spreadsheet) { }
#pragma warning restore CS8618

    public Spreadsheet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Spreadsheet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpreadsheetFromRaw.FromRawUnchecked"/>
    public static Spreadsheet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpreadsheetFromRaw : IFromRawJson<Spreadsheet>
{
    /// <inheritdoc/>
    public Spreadsheet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Spreadsheet.FromRawUnchecked(rawData);
}

/// <summary>
/// Output formatting options for markdown, text, and extracted images
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OutputOptions, OutputOptionsFromRaw>))]
public sealed record class OutputOptions : JsonModel
{
    /// <summary>
    /// Optional additional output artifacts to save alongside the primary parse
    /// output. Each value opts in to generating and persisting one extra file; the
    /// empty list (default) saves none. The three accepted values are: 'stripped_md'
    /// — per-page markdown stripped of formatting (links, bold/italic, images, HTML),
    /// saved as JSON for full-text-search indexing; fetch via `expand=stripped_markdown_content_metadata`.
    /// 'concatenated_stripped_txt' — all stripped pages concatenated into a single
    /// plain-text file with `\n\n---\n\n` between pages, useful for feeding the
    /// document into search or embedding pipelines as one blob; fetch via `expand=concatenated_stripped_markdown_content_metadata`.
    /// 'word_bbox' — raw word-level bounding boxes (one JSON object per word, with
    /// page number and x/y/w/h coordinates) saved as JSONL, useful for highlighting
    /// or grounding extracted answers back to the source document; fetch via `expand=raw_words_content_metadata`.
    /// </summary>
    public IReadOnlyList<string>? AdditionalOutputs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("additional_outputs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "additional_outputs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Extract the printed page number as it appears in the document (e.g., 'Page
    /// 5 of 10', 'v', 'A-3'). Useful for referencing original page numbers
    /// </summary>
    public bool? ExtractPrintedPageNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("extract_printed_page_number");
        }
        init { this._rawData.Set("extract_printed_page_number", value); }
    }

    /// <summary>
    /// Bounding-box granularity levels to compute for the parse. 'word' computes
    /// one bounding box per detected word; 'line' computes one per text line; 'cell'
    /// computes one per table cell. Multiple levels can be requested. Empty list
    /// (default) disables granular bboxes — only item-level layout boxes are returned
    /// on the result. When set, the computed boxes are not inlined on the result
    /// items; they are written to a separate `grounded_items` sidecar (JSONL, one
    /// row per page) and exposed as `result_content_metadata.grounded_items` (a presigned
    /// download URL) on the parse result. Each row matches the `GroundedJsonItem` shape.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, GranularBbox>>? GranularBboxes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, GranularBbox>>>(
                "granular_bboxes"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, GranularBbox>>?>(
                "granular_bboxes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Image categories to save: 'screenshot' (full page renders), 'embedded' (images
    /// found within the document), 'layout' (cropped figures and diagrams). Defaults
    /// to saving 'layout' when the output links to cropped images; pass [] to save none
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ImagesToSave>>? ImagesToSave
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, ImagesToSave>>>(
                "images_to_save"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, ImagesToSave>>?>(
                "images_to_save",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Markdown formatting options including table styles and link annotations
    /// </summary>
    public Markdown? Markdown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Markdown>("markdown");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("markdown", value);
        }
    }

    /// <summary>
    /// Save a PDF copy of the parsed document, retrievable via `expand=output_pdf_content_metadata`.
    /// Not produced for spreadsheet, plain-text, or audio inputs
    /// </summary>
    public bool? SaveOutputPdf
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("save_output_pdf");
        }
        init { this._rawData.Set("save_output_pdf", value); }
    }

    /// <summary>
    /// Spatial text output options for preserving document layout structure
    /// </summary>
    public SpatialText? SpatialText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SpatialText>("spatial_text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("spatial_text", value);
        }
    }

    /// <summary>
    /// Options for exporting tables as XLSX spreadsheets
    /// </summary>
    public TablesAsSpreadsheet? TablesAsSpreadsheet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TablesAsSpreadsheet>("tables_as_spreadsheet");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tables_as_spreadsheet", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdditionalOutputs;
        _ = this.ExtractPrintedPageNumber;
        foreach (var item in this.GranularBboxes ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.ImagesToSave ?? [])
        {
            item.Validate();
        }
        this.Markdown?.Validate();
        _ = this.SaveOutputPdf;
        this.SpatialText?.Validate();
        this.TablesAsSpreadsheet?.Validate();
    }

    public OutputOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputOptions(OutputOptions outputOptions)
        : base(outputOptions) { }
#pragma warning restore CS8618

    public OutputOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputOptionsFromRaw.FromRawUnchecked"/>
    public static OutputOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputOptionsFromRaw : IFromRawJson<OutputOptions>
{
    /// <inheritdoc/>
    public OutputOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OutputOptions.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(GranularBboxConverter))]
public enum GranularBbox
{
    Cell,
    Line,
    Word,
}

sealed class GranularBboxConverter : JsonConverter<GranularBbox>
{
    public override GranularBbox Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cell" => GranularBbox.Cell,
            "line" => GranularBbox.Line,
            "word" => GranularBbox.Word,
            _ => (GranularBbox)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GranularBbox value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GranularBbox.Cell => "cell",
                GranularBbox.Line => "line",
                GranularBbox.Word => "word",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ImagesToSaveConverter))]
public enum ImagesToSave
{
    Embedded,
    Layout,
    Screenshot,
}

sealed class ImagesToSaveConverter : JsonConverter<ImagesToSave>
{
    public override ImagesToSave Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "embedded" => ImagesToSave.Embedded,
            "layout" => ImagesToSave.Layout,
            "screenshot" => ImagesToSave.Screenshot,
            _ => (ImagesToSave)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ImagesToSave value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ImagesToSave.Embedded => "embedded",
                ImagesToSave.Layout => "layout",
                ImagesToSave.Screenshot => "screenshot",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Markdown formatting options including table styles and link annotations
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Markdown, MarkdownFromRaw>))]
public sealed record class Markdown : JsonModel
{
    /// <summary>
    /// Detect printed gutter line numbers and return their Markdown offsets
    /// </summary>
    public bool? AnnotateLineNumbers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("annotate_line_numbers");
        }
        init { this._rawData.Set("annotate_line_numbers", value); }
    }

    /// <summary>
    /// Add link annotations to markdown output in the format [text](url). When false,
    /// only the link text is included
    /// </summary>
    public bool? AnnotateLinks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("annotate_links");
        }
        init { this._rawData.Set("annotate_links", value); }
    }

    /// <summary>
    /// Extract Word-style revisions and comments into structured page output
    /// </summary>
    public bool? AnnotateRevisions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("annotate_revisions");
        }
        init { this._rawData.Set("annotate_revisions", value); }
    }

    /// <summary>
    /// Embed images directly in markdown as base64 data URIs instead of extracting
    /// them as separate files. Useful for self-contained markdown output
    /// </summary>
    public bool? InlineImages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inline_images");
        }
        init { this._rawData.Set("inline_images", value); }
    }

    /// <summary>
    /// Table formatting options including markdown vs HTML format and merging behavior
    /// </summary>
    public Tables? Tables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Tables>("tables");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tables", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AnnotateLineNumbers;
        _ = this.AnnotateLinks;
        _ = this.AnnotateRevisions;
        _ = this.InlineImages;
        this.Tables?.Validate();
    }

    public Markdown() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Markdown(Markdown markdown)
        : base(markdown) { }
#pragma warning restore CS8618

    public Markdown(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Markdown(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MarkdownFromRaw.FromRawUnchecked"/>
    public static Markdown FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MarkdownFromRaw : IFromRawJson<Markdown>
{
    /// <inheritdoc/>
    public Markdown FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Markdown.FromRawUnchecked(rawData);
}

/// <summary>
/// Table formatting options including markdown vs HTML format and merging behavior
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Tables, TablesFromRaw>))]
public sealed record class Tables : JsonModel
{
    /// <summary>
    /// Remove extra whitespace padding in markdown table cells for more compact output
    /// </summary>
    public bool? CompactMarkdownTables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("compact_markdown_tables");
        }
        init { this._rawData.Set("compact_markdown_tables", value); }
    }

    /// <summary>
    /// Separator string for multiline cell content in markdown tables. Example:
    /// '&amp;lt;br&amp;gt;' to preserve line breaks, ' ' to join with spaces
    /// </summary>
    public string? MarkdownTableMultilineSeparator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("markdown_table_multiline_separator");
        }
        init { this._rawData.Set("markdown_table_multiline_separator", value); }
    }

    /// <summary>
    /// Automatically merge tables that span multiple pages into a single table. The
    /// merged table appears on the first page with merged_from_pages metadata
    /// </summary>
    public bool? MergeContinuedTables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("merge_continued_tables");
        }
        init { this._rawData.Set("merge_continued_tables", value); }
    }

    /// <summary>
    /// Output tables as markdown pipe tables instead of HTML &amp;lt;table&amp;gt;
    /// tags. Markdown tables are simpler but cannot represent complex structures
    /// like merged cells
    /// </summary>
    public bool? OutputTablesAsMarkdown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("output_tables_as_markdown");
        }
        init { this._rawData.Set("output_tables_as_markdown", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CompactMarkdownTables;
        _ = this.MarkdownTableMultilineSeparator;
        _ = this.MergeContinuedTables;
        _ = this.OutputTablesAsMarkdown;
    }

    public Tables() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Tables(Tables tables)
        : base(tables) { }
#pragma warning restore CS8618

    public Tables(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tables(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TablesFromRaw.FromRawUnchecked"/>
    public static Tables FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TablesFromRaw : IFromRawJson<Tables>
{
    /// <inheritdoc/>
    public Tables FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tables.FromRawUnchecked(rawData);
}

/// <summary>
/// Spatial text output options for preserving document layout structure
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SpatialText, SpatialTextFromRaw>))]
public sealed record class SpatialText : JsonModel
{
    /// <summary>
    /// Keep multi-column layouts intact instead of linearizing columns into sequential
    /// text. Automatically enabled for non-fast tiers
    /// </summary>
    public bool? DoNotUnrollColumns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("do_not_unroll_columns");
        }
        init { this._rawData.Set("do_not_unroll_columns", value); }
    }

    /// <summary>
    /// Maintain consistent text column alignment across page boundaries. Automatically
    /// enabled for document-level parsing modes
    /// </summary>
    public bool? PreserveLayoutAlignmentAcrossPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("preserve_layout_alignment_across_pages");
        }
        init { this._rawData.Set("preserve_layout_alignment_across_pages", value); }
    }

    /// <summary>
    /// Include text below the normal size threshold. Useful for footnotes, watermarks,
    /// or fine print that might otherwise be filtered out
    /// </summary>
    public bool? PreserveVerySmallText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("preserve_very_small_text");
        }
        init { this._rawData.Set("preserve_very_small_text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DoNotUnrollColumns;
        _ = this.PreserveLayoutAlignmentAcrossPages;
        _ = this.PreserveVerySmallText;
    }

    public SpatialText() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpatialText(SpatialText spatialText)
        : base(spatialText) { }
#pragma warning restore CS8618

    public SpatialText(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpatialText(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpatialTextFromRaw.FromRawUnchecked"/>
    public static SpatialText FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpatialTextFromRaw : IFromRawJson<SpatialText>
{
    /// <inheritdoc/>
    public SpatialText FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SpatialText.FromRawUnchecked(rawData);
}

/// <summary>
/// Options for exporting tables as XLSX spreadsheets
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TablesAsSpreadsheet, TablesAsSpreadsheetFromRaw>))]
public sealed record class TablesAsSpreadsheet : JsonModel
{
    /// <summary>
    /// Whether this option is enabled
    /// </summary>
    public bool? Enable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enable");
        }
        init { this._rawData.Set("enable", value); }
    }

    /// <summary>
    /// Automatically generate descriptive sheet names from table context (headers,
    /// surrounding text) instead of using generic names like 'Table_1'
    /// </summary>
    public bool? GuessSheetName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("guess_sheet_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("guess_sheet_name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enable;
        _ = this.GuessSheetName;
    }

    public TablesAsSpreadsheet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TablesAsSpreadsheet(TablesAsSpreadsheet tablesAsSpreadsheet)
        : base(tablesAsSpreadsheet) { }
#pragma warning restore CS8618

    public TablesAsSpreadsheet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TablesAsSpreadsheet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TablesAsSpreadsheetFromRaw.FromRawUnchecked"/>
    public static TablesAsSpreadsheet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TablesAsSpreadsheetFromRaw : IFromRawJson<TablesAsSpreadsheet>
{
    /// <inheritdoc/>
    public TablesAsSpreadsheet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TablesAsSpreadsheet.FromRawUnchecked(rawData);
}

/// <summary>
/// Page selection: limit total pages or specify exact pages to process
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PageRanges, PageRangesFromRaw>))]
public sealed record class PageRanges : JsonModel
{
    /// <summary>
    /// Maximum number of pages to process. Pages are processed in order starting
    /// from page 1. If both max_pages and target_pages are set, target_pages takes precedence
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
    /// Comma-separated list of specific pages to process using 1-based indexing.
    /// Supports individual pages and ranges. Examples: '1,3,5' (pages 1, 3, 5), '1-5'
    /// (pages 1 through 5 inclusive), '1,3,5-8,10' (pages 1, 3, 5-8, and 10). Pages
    /// are sorted and deduplicated automatically. Duplicate pages cause an error
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MaxPages;
        _ = this.TargetPages;
    }

    public PageRanges() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PageRanges(PageRanges pageRanges)
        : base(pageRanges) { }
#pragma warning restore CS8618

    public PageRanges(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PageRanges(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PageRangesFromRaw.FromRawUnchecked"/>
    public static PageRanges FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PageRangesFromRaw : IFromRawJson<PageRanges>
{
    /// <inheritdoc/>
    public PageRanges FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PageRanges.FromRawUnchecked(rawData);
}

/// <summary>
/// Job execution controls including timeouts and failure thresholds
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProcessingControl, ProcessingControlFromRaw>))]
public sealed record class ProcessingControl : JsonModel
{
    /// <summary>
    /// Quality thresholds that determine when a job should fail vs complete with
    /// partial results
    /// </summary>
    public JobFailureConditions? JobFailureConditions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JobFailureConditions>("job_failure_conditions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("job_failure_conditions", value);
        }
    }

    /// <summary>
    /// Timeout settings for job execution. Increase for large or complex documents
    /// </summary>
    public Timeouts? Timeouts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Timeouts>("timeouts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timeouts", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.JobFailureConditions?.Validate();
        this.Timeouts?.Validate();
    }

    public ProcessingControl() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProcessingControl(ProcessingControl processingControl)
        : base(processingControl) { }
#pragma warning restore CS8618

    public ProcessingControl(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProcessingControl(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProcessingControlFromRaw.FromRawUnchecked"/>
    public static ProcessingControl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProcessingControlFromRaw : IFromRawJson<ProcessingControl>
{
    /// <inheritdoc/>
    public ProcessingControl FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProcessingControl.FromRawUnchecked(rawData);
}

/// <summary>
/// Quality thresholds that determine when a job should fail vs complete with partial results
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JobFailureConditions, JobFailureConditionsFromRaw>))]
public sealed record class JobFailureConditions : JsonModel
{
    /// <summary>
    /// Maximum ratio of pages allowed to fail before the job fails (0-1). Example:
    /// 0.1 means job fails if more than 10% of pages fail. Default is 0.05 (5%)
    /// </summary>
    public double? AllowedPageFailureRatio
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("allowed_page_failure_ratio");
        }
        init { this._rawData.Set("allowed_page_failure_ratio", value); }
    }

    /// <summary>
    /// Fail the job if a problematic font is detected that may cause incorrect text
    /// extraction. Buggy fonts can produce garbled or missing characters
    /// </summary>
    public bool? FailOnBuggyFont
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("fail_on_buggy_font");
        }
        init { this._rawData.Set("fail_on_buggy_font", value); }
    }

    /// <summary>
    /// Fail the entire job if any embedded image cannot be extracted. By default,
    /// image extraction errors are logged but don't fail the job
    /// </summary>
    public bool? FailOnImageExtractionError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("fail_on_image_extraction_error");
        }
        init { this._rawData.Set("fail_on_image_extraction_error", value); }
    }

    /// <summary>
    /// Fail the entire job if OCR fails on any image. By default, OCR errors result
    /// in empty text for that image
    /// </summary>
    public bool? FailOnImageOcrError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("fail_on_image_ocr_error");
        }
        init { this._rawData.Set("fail_on_image_ocr_error", value); }
    }

    /// <summary>
    /// Fail the entire job if markdown cannot be reconstructed for any page. By default,
    /// failed pages use fallback text extraction
    /// </summary>
    public bool? FailOnMarkdownReconstructionError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("fail_on_markdown_reconstruction_error");
        }
        init { this._rawData.Set("fail_on_markdown_reconstruction_error", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowedPageFailureRatio;
        _ = this.FailOnBuggyFont;
        _ = this.FailOnImageExtractionError;
        _ = this.FailOnImageOcrError;
        _ = this.FailOnMarkdownReconstructionError;
    }

    public JobFailureConditions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobFailureConditions(JobFailureConditions jobFailureConditions)
        : base(jobFailureConditions) { }
#pragma warning restore CS8618

    public JobFailureConditions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JobFailureConditions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JobFailureConditionsFromRaw.FromRawUnchecked"/>
    public static JobFailureConditions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JobFailureConditionsFromRaw : IFromRawJson<JobFailureConditions>
{
    /// <inheritdoc/>
    public JobFailureConditions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JobFailureConditions.FromRawUnchecked(rawData);
}

/// <summary>
/// Timeout settings for job execution. Increase for large or complex documents
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Timeouts, TimeoutsFromRaw>))]
public sealed record class Timeouts : JsonModel
{
    /// <summary>
    /// Base timeout for the job in seconds (max 7200 = 2 hours). This is the minimum
    /// time allowed regardless of document size
    /// </summary>
    public long? BaseInSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("base_in_seconds");
        }
        init { this._rawData.Set("base_in_seconds", value); }
    }

    /// <summary>
    /// Additional timeout per page in seconds (max 300 = 5 minutes). Total timeout
    /// = base + (this value × page count)
    /// </summary>
    public long? ExtraTimePerPageInSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("extra_time_per_page_in_seconds");
        }
        init { this._rawData.Set("extra_time_per_page_in_seconds", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BaseInSeconds;
        _ = this.ExtraTimePerPageInSeconds;
    }

    public Timeouts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Timeouts(Timeouts timeouts)
        : base(timeouts) { }
#pragma warning restore CS8618

    public Timeouts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Timeouts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TimeoutsFromRaw.FromRawUnchecked"/>
    public static Timeouts FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TimeoutsFromRaw : IFromRawJson<Timeouts>
{
    /// <inheritdoc/>
    public Timeouts FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Timeouts.FromRawUnchecked(rawData);
}

/// <summary>
/// Document processing options including OCR, table extraction, and chart parsing
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProcessingOptions, ProcessingOptionsFromRaw>))]
public sealed record class ProcessingOptions : JsonModel
{
    /// <summary>
    /// Use aggressive heuristics to detect table boundaries, even without visible
    /// borders. Useful for documents with borderless or complex tables
    /// </summary>
    public bool? AggressiveTableExtraction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("aggressive_table_extraction");
        }
        init { this._rawData.Set("aggressive_table_extraction", value); }
    }

    /// <summary>
    /// Conditional processing rules that apply different parsing options based on
    /// page content, document structure, or filename patterns. Each entry defines
    /// trigger conditions and the parsing configuration to apply when triggered
    /// </summary>
    public IReadOnlyList<AutoModeConfiguration>? AutoModeConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AutoModeConfiguration>>(
                "auto_mode_configuration"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<AutoModeConfiguration>?>(
                "auto_mode_configuration",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Confidence scoring effort. Omit for standard scoring. 'high': more accurate
    /// assessment of the parsing quality of every page, plus a document-level score
    /// in the result metadata; costs an additional 5 credits per page
    /// </summary>
    public ApiEnum<string, ConfidenceScoreEffort>? ConfidenceScoreEffort
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConfidenceScoreEffort>>(
                "confidence_score_effort"
            );
        }
        init { this._rawData.Set("confidence_score_effort", value); }
    }

    /// <summary>
    /// Cost optimizer configuration for reducing parsing costs on simpler pages.
    ///
    /// <para>When enabled, the parser analyzes each page and routes simpler pages
    /// to faster, cheaper processing while preserving quality for complex pages.
    /// Only works with 'agentic' or 'agentic_plus' tiers.</para>
    /// </summary>
    public CostOptimizer? CostOptimizer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CostOptimizer>("cost_optimizer");
        }
        init { this._rawData.Set("cost_optimizer", value); }
    }

    /// <summary>
    /// Disable automatic heuristics including outlined table extraction and adaptive
    /// long table handling. Use when heuristics produce incorrect results
    /// </summary>
    public bool? DisableHeuristics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("disable_heuristics");
        }
        init { this._rawData.Set("disable_heuristics", value); }
    }

    /// <summary>
    /// Beta: set to 'enrich' to run an additional AI form-analysis pass on pages
    /// detected as forms, producing a structured tree of the form's sections, fields,
    /// and fillable grids. Retrieve the result with expand=forms. 'default' (the
    /// default) applies standard parsing with no extra pass. Not available on the
    /// fast tier
    /// </summary>
    public ApiEnum<string, Forms>? Forms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Forms>>("forms");
        }
        init { this._rawData.Set("forms", value); }
    }

    /// <summary>
    /// Options for ignoring specific text types (diagonal, hidden, text in images)
    /// </summary>
    public ProcessingOptionsIgnore? Ignore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProcessingOptionsIgnore>("ignore");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ignore", value);
        }
    }

    /// <summary>
    /// OCR configuration including language detection settings
    /// </summary>
    public OcrParameters? OcrParameters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OcrParameters>("ocr_parameters");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ocr_parameters", value);
        }
    }

    /// <summary>
    /// Enable AI-powered chart analysis. Modes: 'efficient' (fast, lower cost), 'agentic'
    /// (balanced), 'agentic_plus' (highest accuracy). Automatically enables extract_layout
    /// and precise_bounding_box when set
    /// </summary>
    public ApiEnum<string, ProcessingOptionsSpecializedChartParsing>? SpecializedChartParsing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProcessingOptionsSpecializedChartParsing>
            >("specialized_chart_parsing");
        }
        init { this._rawData.Set("specialized_chart_parsing", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AggressiveTableExtraction;
        foreach (var item in this.AutoModeConfiguration ?? [])
        {
            item.Validate();
        }
        this.ConfidenceScoreEffort?.Validate();
        this.CostOptimizer?.Validate();
        _ = this.DisableHeuristics;
        this.Forms?.Validate();
        this.Ignore?.Validate();
        this.OcrParameters?.Validate();
        this.SpecializedChartParsing?.Validate();
    }

    public ProcessingOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProcessingOptions(ProcessingOptions processingOptions)
        : base(processingOptions) { }
#pragma warning restore CS8618

    public ProcessingOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProcessingOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProcessingOptionsFromRaw.FromRawUnchecked"/>
    public static ProcessingOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProcessingOptionsFromRaw : IFromRawJson<ProcessingOptions>
{
    /// <inheritdoc/>
    public ProcessingOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProcessingOptions.FromRawUnchecked(rawData);
}

/// <summary>
/// A single auto mode rule with trigger conditions and parsing configuration.
///
/// <para>Auto mode allows conditional parsing where different configurations are
/// applied based on page content, structure, or filename. When triggers match, the
/// parsing_conf overrides default settings for that page.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AutoModeConfiguration, AutoModeConfigurationFromRaw>))]
public sealed record class AutoModeConfiguration : JsonModel
{
    /// <summary>
    /// Parsing configuration to apply when trigger conditions are met
    /// </summary>
    public required ParsingConf ParsingConf
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ParsingConf>("parsing_conf");
        }
        init { this._rawData.Set("parsing_conf", value); }
    }

    /// <summary>
    /// Single glob pattern to match against filename
    /// </summary>
    public string? FilenameMatchGlob
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("filename_match_glob");
        }
        init { this._rawData.Set("filename_match_glob", value); }
    }

    /// <summary>
    /// List of glob patterns to match against filename
    /// </summary>
    public IReadOnlyList<string>? FilenameMatchGlobList
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "filename_match_glob_list"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "filename_match_glob_list",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Regex pattern to match against filename
    /// </summary>
    public string? FilenameRegexp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("filename_regexp");
        }
        init { this._rawData.Set("filename_regexp", value); }
    }

    /// <summary>
    /// Regex mode flags (e.g., 'i' for case-insensitive)
    /// </summary>
    public string? FilenameRegexpMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("filename_regexp_mode");
        }
        init { this._rawData.Set("filename_regexp_mode", value); }
    }

    /// <summary>
    /// Trigger if page contains a full-page image (scanned page detection)
    /// </summary>
    public bool? FullPageImageInPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("full_page_image_in_page");
        }
        init { this._rawData.Set("full_page_image_in_page", value); }
    }

    /// <summary>
    /// Threshold for full page image detection (0.0-1.0, default 0.8)
    /// </summary>
    public FullPageImageInPageThreshold? FullPageImageInPageThreshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FullPageImageInPageThreshold>(
                "full_page_image_in_page_threshold"
            );
        }
        init { this._rawData.Set("full_page_image_in_page_threshold", value); }
    }

    /// <summary>
    /// Trigger if page contains non-screenshot images
    /// </summary>
    public bool? ImageInPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("image_in_page");
        }
        init { this._rawData.Set("image_in_page", value); }
    }

    /// <summary>
    /// Trigger if page contains this layout element type
    /// </summary>
    public string? LayoutElementInPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("layout_element_in_page");
        }
        init { this._rawData.Set("layout_element_in_page", value); }
    }

    /// <summary>
    /// Confidence threshold for layout element detection
    /// </summary>
    public LayoutElementInPageConfidenceThreshold? LayoutElementInPageConfidenceThreshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LayoutElementInPageConfidenceThreshold>(
                "layout_element_in_page_confidence_threshold"
            );
        }
        init { this._rawData.Set("layout_element_in_page_confidence_threshold", value); }
    }

    /// <summary>
    /// Trigger if page has more than N charts
    /// </summary>
    public PageContainsAtLeastNCharts? PageContainsAtLeastNCharts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageContainsAtLeastNCharts>(
                "page_contains_at_least_n_charts"
            );
        }
        init { this._rawData.Set("page_contains_at_least_n_charts", value); }
    }

    /// <summary>
    /// Trigger if page has more than N images
    /// </summary>
    public PageContainsAtLeastNImages? PageContainsAtLeastNImages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageContainsAtLeastNImages>(
                "page_contains_at_least_n_images"
            );
        }
        init { this._rawData.Set("page_contains_at_least_n_images", value); }
    }

    /// <summary>
    /// Trigger if page has more than N layout elements
    /// </summary>
    public PageContainsAtLeastNLayoutElements? PageContainsAtLeastNLayoutElements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageContainsAtLeastNLayoutElements>(
                "page_contains_at_least_n_layout_elements"
            );
        }
        init { this._rawData.Set("page_contains_at_least_n_layout_elements", value); }
    }

    /// <summary>
    /// Trigger if page has more than N lines
    /// </summary>
    public PageContainsAtLeastNLines? PageContainsAtLeastNLines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageContainsAtLeastNLines>(
                "page_contains_at_least_n_lines"
            );
        }
        init { this._rawData.Set("page_contains_at_least_n_lines", value); }
    }

    /// <summary>
    /// Trigger if page has more than N links
    /// </summary>
    public PageContainsAtLeastNLinks? PageContainsAtLeastNLinks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageContainsAtLeastNLinks>(
                "page_contains_at_least_n_links"
            );
        }
        init { this._rawData.Set("page_contains_at_least_n_links", value); }
    }

    /// <summary>
    /// Trigger if page has more than N numeric words
    /// </summary>
    public PageContainsAtLeastNNumbers? PageContainsAtLeastNNumbers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageContainsAtLeastNNumbers>(
                "page_contains_at_least_n_numbers"
            );
        }
        init { this._rawData.Set("page_contains_at_least_n_numbers", value); }
    }

    /// <summary>
    /// Trigger if page has more than N% numeric words
    /// </summary>
    public PageContainsAtLeastNPercentNumbers? PageContainsAtLeastNPercentNumbers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageContainsAtLeastNPercentNumbers>(
                "page_contains_at_least_n_percent_numbers"
            );
        }
        init { this._rawData.Set("page_contains_at_least_n_percent_numbers", value); }
    }

    /// <summary>
    /// Trigger if page has more than N tables
    /// </summary>
    public PageContainsAtLeastNTables? PageContainsAtLeastNTables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageContainsAtLeastNTables>(
                "page_contains_at_least_n_tables"
            );
        }
        init { this._rawData.Set("page_contains_at_least_n_tables", value); }
    }

    /// <summary>
    /// Trigger if page has more than N words
    /// </summary>
    public PageContainsAtLeastNWords? PageContainsAtLeastNWords
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageContainsAtLeastNWords>(
                "page_contains_at_least_n_words"
            );
        }
        init { this._rawData.Set("page_contains_at_least_n_words", value); }
    }

    /// <summary>
    /// Trigger if page has fewer than N charts
    /// </summary>
    public PageContainsAtMostNCharts? PageContainsAtMostNCharts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageContainsAtMostNCharts>(
                "page_contains_at_most_n_charts"
            );
        }
        init { this._rawData.Set("page_contains_at_most_n_charts", value); }
    }

    /// <summary>
    /// Trigger if page has fewer than N images
    /// </summary>
    public PageContainsAtMostNImages? PageContainsAtMostNImages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageContainsAtMostNImages>(
                "page_contains_at_most_n_images"
            );
        }
        init { this._rawData.Set("page_contains_at_most_n_images", value); }
    }

    /// <summary>
    /// Trigger if page has fewer than N layout elements
    /// </summary>
    public PageContainsAtMostNLayoutElements? PageContainsAtMostNLayoutElements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageContainsAtMostNLayoutElements>(
                "page_contains_at_most_n_layout_elements"
            );
        }
        init { this._rawData.Set("page_contains_at_most_n_layout_elements", value); }
    }

    /// <summary>
    /// Trigger if page has fewer than N lines
    /// </summary>
    public PageContainsAtMostNLines? PageContainsAtMostNLines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageContainsAtMostNLines>(
                "page_contains_at_most_n_lines"
            );
        }
        init { this._rawData.Set("page_contains_at_most_n_lines", value); }
    }

    /// <summary>
    /// Trigger if page has fewer than N links
    /// </summary>
    public PageContainsAtMostNLinks? PageContainsAtMostNLinks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageContainsAtMostNLinks>(
                "page_contains_at_most_n_links"
            );
        }
        init { this._rawData.Set("page_contains_at_most_n_links", value); }
    }

    /// <summary>
    /// Trigger if page has fewer than N numeric words
    /// </summary>
    public PageContainsAtMostNNumbers? PageContainsAtMostNNumbers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageContainsAtMostNNumbers>(
                "page_contains_at_most_n_numbers"
            );
        }
        init { this._rawData.Set("page_contains_at_most_n_numbers", value); }
    }

    /// <summary>
    /// Trigger if page has fewer than N% numeric words
    /// </summary>
    public PageContainsAtMostNPercentNumbers? PageContainsAtMostNPercentNumbers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageContainsAtMostNPercentNumbers>(
                "page_contains_at_most_n_percent_numbers"
            );
        }
        init { this._rawData.Set("page_contains_at_most_n_percent_numbers", value); }
    }

    /// <summary>
    /// Trigger if page has fewer than N tables
    /// </summary>
    public PageContainsAtMostNTables? PageContainsAtMostNTables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageContainsAtMostNTables>(
                "page_contains_at_most_n_tables"
            );
        }
        init { this._rawData.Set("page_contains_at_most_n_tables", value); }
    }

    /// <summary>
    /// Trigger if page has fewer than N words
    /// </summary>
    public PageContainsAtMostNWords? PageContainsAtMostNWords
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageContainsAtMostNWords>(
                "page_contains_at_most_n_words"
            );
        }
        init { this._rawData.Set("page_contains_at_most_n_words", value); }
    }

    /// <summary>
    /// Trigger if page has more than N characters
    /// </summary>
    public PageLongerThanNChars? PageLongerThanNChars
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageLongerThanNChars>("page_longer_than_n_chars");
        }
        init { this._rawData.Set("page_longer_than_n_chars", value); }
    }

    /// <summary>
    /// Trigger on pages with markdown extraction errors
    /// </summary>
    public bool? PageMdError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("page_md_error");
        }
        init { this._rawData.Set("page_md_error", value); }
    }

    /// <summary>
    /// Trigger if page has fewer than N characters
    /// </summary>
    public PageShorterThanNChars? PageShorterThanNChars
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PageShorterThanNChars>(
                "page_shorter_than_n_chars"
            );
        }
        init { this._rawData.Set("page_shorter_than_n_chars", value); }
    }

    /// <summary>
    /// Regex pattern to match in page content
    /// </summary>
    public string? RegexpInPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("regexp_in_page");
        }
        init { this._rawData.Set("regexp_in_page", value); }
    }

    /// <summary>
    /// Regex mode flags for regexp_in_page
    /// </summary>
    public string? RegexpInPageMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("regexp_in_page_mode");
        }
        init { this._rawData.Set("regexp_in_page_mode", value); }
    }

    /// <summary>
    /// Trigger if page contains a table
    /// </summary>
    public bool? TableInPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("table_in_page");
        }
        init { this._rawData.Set("table_in_page", value); }
    }

    /// <summary>
    /// Trigger if page text/markdown contains this string
    /// </summary>
    public string? TextInPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_in_page");
        }
        init { this._rawData.Set("text_in_page", value); }
    }

    /// <summary>
    /// How to combine multiple trigger conditions: 'and' (all conditions must match,
    /// this is the default) or 'or' (any single condition can trigger)
    /// </summary>
    public string? TriggerMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("trigger_mode");
        }
        init { this._rawData.Set("trigger_mode", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ParsingConf.Validate();
        _ = this.FilenameMatchGlob;
        _ = this.FilenameMatchGlobList;
        _ = this.FilenameRegexp;
        _ = this.FilenameRegexpMode;
        _ = this.FullPageImageInPage;
        this.FullPageImageInPageThreshold?.Validate();
        _ = this.ImageInPage;
        _ = this.LayoutElementInPage;
        this.LayoutElementInPageConfidenceThreshold?.Validate();
        this.PageContainsAtLeastNCharts?.Validate();
        this.PageContainsAtLeastNImages?.Validate();
        this.PageContainsAtLeastNLayoutElements?.Validate();
        this.PageContainsAtLeastNLines?.Validate();
        this.PageContainsAtLeastNLinks?.Validate();
        this.PageContainsAtLeastNNumbers?.Validate();
        this.PageContainsAtLeastNPercentNumbers?.Validate();
        this.PageContainsAtLeastNTables?.Validate();
        this.PageContainsAtLeastNWords?.Validate();
        this.PageContainsAtMostNCharts?.Validate();
        this.PageContainsAtMostNImages?.Validate();
        this.PageContainsAtMostNLayoutElements?.Validate();
        this.PageContainsAtMostNLines?.Validate();
        this.PageContainsAtMostNLinks?.Validate();
        this.PageContainsAtMostNNumbers?.Validate();
        this.PageContainsAtMostNPercentNumbers?.Validate();
        this.PageContainsAtMostNTables?.Validate();
        this.PageContainsAtMostNWords?.Validate();
        this.PageLongerThanNChars?.Validate();
        _ = this.PageMdError;
        this.PageShorterThanNChars?.Validate();
        _ = this.RegexpInPage;
        _ = this.RegexpInPageMode;
        _ = this.TableInPage;
        _ = this.TextInPage;
        _ = this.TriggerMode;
    }

    public AutoModeConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutoModeConfiguration(AutoModeConfiguration autoModeConfiguration)
        : base(autoModeConfiguration) { }
#pragma warning restore CS8618

    public AutoModeConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutoModeConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutoModeConfigurationFromRaw.FromRawUnchecked"/>
    public static AutoModeConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AutoModeConfiguration(ParsingConf parsingConf)
        : this()
    {
        this.ParsingConf = parsingConf;
    }
}

class AutoModeConfigurationFromRaw : IFromRawJson<AutoModeConfiguration>
{
    /// <inheritdoc/>
    public AutoModeConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutoModeConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Parsing configuration to apply when trigger conditions are met
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ParsingConf, ParsingConfFromRaw>))]
public sealed record class ParsingConf : JsonModel
{
    /// <summary>
    /// Whether to use adaptive long table handling
    /// </summary>
    public bool? AdaptiveLongTable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("adaptive_long_table");
        }
        init { this._rawData.Set("adaptive_long_table", value); }
    }

    /// <summary>
    /// Whether to use aggressive table extraction
    /// </summary>
    public bool? AggressiveTableExtraction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("aggressive_table_extraction");
        }
        init { this._rawData.Set("aggressive_table_extraction", value); }
    }

    /// <summary>
    /// Crop box options for auto mode parsing configuration.
    /// </summary>
    public ParsingConfCropBox? CropBox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ParsingConfCropBox>("crop_box");
        }
        init { this._rawData.Set("crop_box", value); }
    }

    /// <summary>
    /// Custom AI instructions for matched pages. Overrides the base custom_prompt
    /// </summary>
    public string? CustomPrompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("custom_prompt");
        }
        init { this._rawData.Set("custom_prompt", value); }
    }

    /// <summary>
    /// Whether to extract layout information
    /// </summary>
    public bool? ExtractLayout
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("extract_layout");
        }
        init { this._rawData.Set("extract_layout", value); }
    }

    /// <summary>
    /// Whether to use high resolution OCR
    /// </summary>
    public bool? HighResOcr
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("high_res_ocr");
        }
        init { this._rawData.Set("high_res_ocr", value); }
    }

    /// <summary>
    /// Ignore options for auto mode parsing configuration.
    /// </summary>
    public Ignore? Ignore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Ignore>("ignore");
        }
        init { this._rawData.Set("ignore", value); }
    }

    /// <summary>
    /// Primary language of the document
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
    /// Whether to use outlined table extraction
    /// </summary>
    public bool? OutlinedTableExtraction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("outlined_table_extraction");
        }
        init { this._rawData.Set("outlined_table_extraction", value); }
    }

    /// <summary>
    /// Presentation-specific options for auto mode parsing configuration.
    /// </summary>
    public ParsingConfPresentation? Presentation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ParsingConfPresentation>("presentation");
        }
        init { this._rawData.Set("presentation", value); }
    }

    /// <summary>
    /// Spatial text options for auto mode parsing configuration.
    /// </summary>
    public ParsingConfSpatialText? SpatialText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ParsingConfSpatialText>("spatial_text");
        }
        init { this._rawData.Set("spatial_text", value); }
    }

    /// <summary>
    /// Enable specialized chart parsing with the specified mode
    /// </summary>
    public ApiEnum<string, SpecializedChartParsing>? SpecializedChartParsing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SpecializedChartParsing>>(
                "specialized_chart_parsing"
            );
        }
        init { this._rawData.Set("specialized_chart_parsing", value); }
    }

    /// <summary>
    /// Override the parsing tier for matched pages. Must be paired with version
    /// </summary>
    public ApiEnum<string, ParsingConfTier>? Tier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ParsingConfTier>>("tier");
        }
        init { this._rawData.Set("tier", value); }
    }

    /// <summary>
    /// Version for the override tier. Required when `tier` is set. Use `latest`,
    /// or pin one of that tier's dated versions.
    ///
    /// <para>Current `latest` by tier: - `fast`: `2026-06-15` - `cost_effective`:
    /// `2026-08-19` - `agentic`: `2026-08-19` - `agentic_plus`: `2026-08-19`</para>
    ///
    /// <para>Full list: `GET /api/v2/parse/versions`.</para>
    /// </summary>
    public ApiEnum<string, ParsingConfVersion>? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ParsingConfVersion>>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdaptiveLongTable;
        _ = this.AggressiveTableExtraction;
        this.CropBox?.Validate();
        _ = this.CustomPrompt;
        _ = this.ExtractLayout;
        _ = this.HighResOcr;
        this.Ignore?.Validate();
        _ = this.Language;
        _ = this.OutlinedTableExtraction;
        this.Presentation?.Validate();
        this.SpatialText?.Validate();
        this.SpecializedChartParsing?.Validate();
        this.Tier?.Validate();
        this.Version?.Raw();
    }

    public ParsingConf() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParsingConf(ParsingConf parsingConf)
        : base(parsingConf) { }
#pragma warning restore CS8618

    public ParsingConf(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParsingConf(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParsingConfFromRaw.FromRawUnchecked"/>
    public static ParsingConf FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParsingConfFromRaw : IFromRawJson<ParsingConf>
{
    /// <inheritdoc/>
    public ParsingConf FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ParsingConf.FromRawUnchecked(rawData);
}

/// <summary>
/// Crop box options for auto mode parsing configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ParsingConfCropBox, ParsingConfCropBoxFromRaw>))]
public sealed record class ParsingConfCropBox : JsonModel
{
    /// <summary>
    /// Bottom boundary of crop box as ratio (0-1)
    /// </summary>
    public double? Bottom
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("bottom");
        }
        init { this._rawData.Set("bottom", value); }
    }

    /// <summary>
    /// Left boundary of crop box as ratio (0-1)
    /// </summary>
    public double? Left
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("left");
        }
        init { this._rawData.Set("left", value); }
    }

    /// <summary>
    /// Right boundary of crop box as ratio (0-1)
    /// </summary>
    public double? Right
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("right");
        }
        init { this._rawData.Set("right", value); }
    }

    /// <summary>
    /// Top boundary of crop box as ratio (0-1)
    /// </summary>
    public double? Top
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("top");
        }
        init { this._rawData.Set("top", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Bottom;
        _ = this.Left;
        _ = this.Right;
        _ = this.Top;
    }

    public ParsingConfCropBox() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParsingConfCropBox(ParsingConfCropBox parsingConfCropBox)
        : base(parsingConfCropBox) { }
#pragma warning restore CS8618

    public ParsingConfCropBox(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParsingConfCropBox(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParsingConfCropBoxFromRaw.FromRawUnchecked"/>
    public static ParsingConfCropBox FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParsingConfCropBoxFromRaw : IFromRawJson<ParsingConfCropBox>
{
    /// <inheritdoc/>
    public ParsingConfCropBox FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ParsingConfCropBox.FromRawUnchecked(rawData);
}

/// <summary>
/// Ignore options for auto mode parsing configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Ignore, IgnoreFromRaw>))]
public sealed record class Ignore : JsonModel
{
    /// <summary>
    /// Whether to ignore diagonal text in the document
    /// </summary>
    public bool? IgnoreDiagonalText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("ignore_diagonal_text");
        }
        init { this._rawData.Set("ignore_diagonal_text", value); }
    }

    /// <summary>
    /// Whether to ignore hidden text in the document
    /// </summary>
    public bool? IgnoreHiddenText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("ignore_hidden_text");
        }
        init { this._rawData.Set("ignore_hidden_text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IgnoreDiagonalText;
        _ = this.IgnoreHiddenText;
    }

    public Ignore() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Ignore(Ignore ignore)
        : base(ignore) { }
#pragma warning restore CS8618

    public Ignore(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Ignore(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IgnoreFromRaw.FromRawUnchecked"/>
    public static Ignore FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IgnoreFromRaw : IFromRawJson<Ignore>
{
    /// <inheritdoc/>
    public Ignore FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Ignore.FromRawUnchecked(rawData);
}

/// <summary>
/// Presentation-specific options for auto mode parsing configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ParsingConfPresentation, ParsingConfPresentationFromRaw>))]
public sealed record class ParsingConfPresentation : JsonModel
{
    /// <summary>
    /// Extract out of bounds content in presentation slides
    /// </summary>
    public bool? OutOfBoundsContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("out_of_bounds_content");
        }
        init { this._rawData.Set("out_of_bounds_content", value); }
    }

    /// <summary>
    /// Skip extraction of embedded data for charts in presentation slides
    /// </summary>
    public bool? SkipEmbeddedData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("skip_embedded_data");
        }
        init { this._rawData.Set("skip_embedded_data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.OutOfBoundsContent;
        _ = this.SkipEmbeddedData;
    }

    public ParsingConfPresentation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParsingConfPresentation(ParsingConfPresentation parsingConfPresentation)
        : base(parsingConfPresentation) { }
#pragma warning restore CS8618

    public ParsingConfPresentation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParsingConfPresentation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParsingConfPresentationFromRaw.FromRawUnchecked"/>
    public static ParsingConfPresentation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParsingConfPresentationFromRaw : IFromRawJson<ParsingConfPresentation>
{
    /// <inheritdoc/>
    public ParsingConfPresentation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ParsingConfPresentation.FromRawUnchecked(rawData);
}

/// <summary>
/// Spatial text options for auto mode parsing configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ParsingConfSpatialText, ParsingConfSpatialTextFromRaw>))]
public sealed record class ParsingConfSpatialText : JsonModel
{
    /// <summary>
    /// Keep column structure intact without unrolling
    /// </summary>
    public bool? DoNotUnrollColumns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("do_not_unroll_columns");
        }
        init { this._rawData.Set("do_not_unroll_columns", value); }
    }

    /// <summary>
    /// Preserve text alignment across page boundaries
    /// </summary>
    public bool? PreserveLayoutAlignmentAcrossPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("preserve_layout_alignment_across_pages");
        }
        init { this._rawData.Set("preserve_layout_alignment_across_pages", value); }
    }

    /// <summary>
    /// Include very small text in spatial output
    /// </summary>
    public bool? PreserveVerySmallText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("preserve_very_small_text");
        }
        init { this._rawData.Set("preserve_very_small_text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DoNotUnrollColumns;
        _ = this.PreserveLayoutAlignmentAcrossPages;
        _ = this.PreserveVerySmallText;
    }

    public ParsingConfSpatialText() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParsingConfSpatialText(ParsingConfSpatialText parsingConfSpatialText)
        : base(parsingConfSpatialText) { }
#pragma warning restore CS8618

    public ParsingConfSpatialText(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParsingConfSpatialText(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParsingConfSpatialTextFromRaw.FromRawUnchecked"/>
    public static ParsingConfSpatialText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParsingConfSpatialTextFromRaw : IFromRawJson<ParsingConfSpatialText>
{
    /// <inheritdoc/>
    public ParsingConfSpatialText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ParsingConfSpatialText.FromRawUnchecked(rawData);
}

/// <summary>
/// Enable specialized chart parsing with the specified mode
/// </summary>
[JsonConverter(typeof(SpecializedChartParsingConverter))]
public enum SpecializedChartParsing
{
    Agentic,
    AgenticPlus,
    Efficient,
}

sealed class SpecializedChartParsingConverter : JsonConverter<SpecializedChartParsing>
{
    public override SpecializedChartParsing Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agentic" => SpecializedChartParsing.Agentic,
            "agentic_plus" => SpecializedChartParsing.AgenticPlus,
            "efficient" => SpecializedChartParsing.Efficient,
            _ => (SpecializedChartParsing)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SpecializedChartParsing value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SpecializedChartParsing.Agentic => "agentic",
                SpecializedChartParsing.AgenticPlus => "agentic_plus",
                SpecializedChartParsing.Efficient => "efficient",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Override the parsing tier for matched pages. Must be paired with version
/// </summary>
[JsonConverter(typeof(ParsingConfTierConverter))]
public enum ParsingConfTier
{
    Agentic,
    AgenticPlus,
    CostEffective,
    Fast,
}

sealed class ParsingConfTierConverter : JsonConverter<ParsingConfTier>
{
    public override ParsingConfTier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agentic" => ParsingConfTier.Agentic,
            "agentic_plus" => ParsingConfTier.AgenticPlus,
            "cost_effective" => ParsingConfTier.CostEffective,
            "fast" => ParsingConfTier.Fast,
            _ => (ParsingConfTier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ParsingConfTier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ParsingConfTier.Agentic => "agentic",
                ParsingConfTier.AgenticPlus => "agentic_plus",
                ParsingConfTier.CostEffective => "cost_effective",
                ParsingConfTier.Fast => "fast",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Version for the override tier. Required when `tier` is set. Use `latest`, or pin
/// one of that tier's dated versions.
///
/// <para>Current `latest` by tier: - `fast`: `2026-06-15` - `cost_effective`: `2026-08-19`
/// - `agentic`: `2026-08-19` - `agentic_plus`: `2026-08-19`</para>
///
/// <para>Full list: `GET /api/v2/parse/versions`.</para>
/// </summary>
[JsonConverter(typeof(ParsingConfVersionConverter))]
public enum ParsingConfVersion
{
    Latest,
    V2026_08_19,
    V2026_06_15,
}

sealed class ParsingConfVersionConverter : JsonConverter<ParsingConfVersion>
{
    public override ParsingConfVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "latest" => ParsingConfVersion.Latest,
            "2026-08-19" => ParsingConfVersion.V2026_08_19,
            "2026-06-15" => ParsingConfVersion.V2026_06_15,
            _ => (ParsingConfVersion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ParsingConfVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ParsingConfVersion.Latest => "latest",
                ParsingConfVersion.V2026_08_19 => "2026-08-19",
                ParsingConfVersion.V2026_06_15 => "2026-06-15",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Threshold for full page image detection (0.0-1.0, default 0.8)
/// </summary>
[JsonConverter(typeof(FullPageImageInPageThresholdConverter))]
public record class FullPageImageInPageThreshold : ModelBase
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

    public FullPageImageInPageThreshold(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FullPageImageInPageThreshold(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FullPageImageInPageThreshold(JsonElement element)
    {
        this._element = element;
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<double> @double, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of FullPageImageInPageThreshold"
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<double, T> @double, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of FullPageImageInPageThreshold"
            ),
        };
    }

    public static implicit operator FullPageImageInPageThreshold(double value) => new(value);

    public static implicit operator FullPageImageInPageThreshold(string value) => new(value);

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
                "Data did not match any variant of FullPageImageInPageThreshold"
            );
        }
    }

    public virtual bool Equals(FullPageImageInPageThreshold? other) =>
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
            double _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class FullPageImageInPageThresholdConverter : JsonConverter<FullPageImageInPageThreshold?>
{
    public override FullPageImageInPageThreshold? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        FullPageImageInPageThreshold? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Confidence threshold for layout element detection
/// </summary>
[JsonConverter(typeof(LayoutElementInPageConfidenceThresholdConverter))]
public record class LayoutElementInPageConfidenceThreshold : ModelBase
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

    public LayoutElementInPageConfidenceThreshold(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public LayoutElementInPageConfidenceThreshold(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public LayoutElementInPageConfidenceThreshold(JsonElement element)
    {
        this._element = element;
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<double> @double, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of LayoutElementInPageConfidenceThreshold"
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<double, T> @double, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of LayoutElementInPageConfidenceThreshold"
            ),
        };
    }

    public static implicit operator LayoutElementInPageConfidenceThreshold(double value) =>
        new(value);

    public static implicit operator LayoutElementInPageConfidenceThreshold(string value) =>
        new(value);

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
                "Data did not match any variant of LayoutElementInPageConfidenceThreshold"
            );
        }
    }

    public virtual bool Equals(LayoutElementInPageConfidenceThreshold? other) =>
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
            double _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class LayoutElementInPageConfidenceThresholdConverter
    : JsonConverter<LayoutElementInPageConfidenceThreshold?>
{
    public override LayoutElementInPageConfidenceThreshold? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        LayoutElementInPageConfidenceThreshold? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has more than N charts
/// </summary>
[JsonConverter(typeof(PageContainsAtLeastNChartsConverter))]
public record class PageContainsAtLeastNCharts : ModelBase
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

    public PageContainsAtLeastNCharts(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtLeastNCharts(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtLeastNCharts(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageContainsAtLeastNCharts"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageContainsAtLeastNCharts"
            ),
        };
    }

    public static implicit operator PageContainsAtLeastNCharts(long value) => new(value);

    public static implicit operator PageContainsAtLeastNCharts(string value) => new(value);

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
                "Data did not match any variant of PageContainsAtLeastNCharts"
            );
        }
    }

    public virtual bool Equals(PageContainsAtLeastNCharts? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageContainsAtLeastNChartsConverter : JsonConverter<PageContainsAtLeastNCharts?>
{
    public override PageContainsAtLeastNCharts? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageContainsAtLeastNCharts? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has more than N images
/// </summary>
[JsonConverter(typeof(PageContainsAtLeastNImagesConverter))]
public record class PageContainsAtLeastNImages : ModelBase
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

    public PageContainsAtLeastNImages(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtLeastNImages(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtLeastNImages(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageContainsAtLeastNImages"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageContainsAtLeastNImages"
            ),
        };
    }

    public static implicit operator PageContainsAtLeastNImages(long value) => new(value);

    public static implicit operator PageContainsAtLeastNImages(string value) => new(value);

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
                "Data did not match any variant of PageContainsAtLeastNImages"
            );
        }
    }

    public virtual bool Equals(PageContainsAtLeastNImages? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageContainsAtLeastNImagesConverter : JsonConverter<PageContainsAtLeastNImages?>
{
    public override PageContainsAtLeastNImages? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageContainsAtLeastNImages? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has more than N layout elements
/// </summary>
[JsonConverter(typeof(PageContainsAtLeastNLayoutElementsConverter))]
public record class PageContainsAtLeastNLayoutElements : ModelBase
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

    public PageContainsAtLeastNLayoutElements(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtLeastNLayoutElements(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtLeastNLayoutElements(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageContainsAtLeastNLayoutElements"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageContainsAtLeastNLayoutElements"
            ),
        };
    }

    public static implicit operator PageContainsAtLeastNLayoutElements(long value) => new(value);

    public static implicit operator PageContainsAtLeastNLayoutElements(string value) => new(value);

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
                "Data did not match any variant of PageContainsAtLeastNLayoutElements"
            );
        }
    }

    public virtual bool Equals(PageContainsAtLeastNLayoutElements? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageContainsAtLeastNLayoutElementsConverter
    : JsonConverter<PageContainsAtLeastNLayoutElements?>
{
    public override PageContainsAtLeastNLayoutElements? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageContainsAtLeastNLayoutElements? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has more than N lines
/// </summary>
[JsonConverter(typeof(PageContainsAtLeastNLinesConverter))]
public record class PageContainsAtLeastNLines : ModelBase
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

    public PageContainsAtLeastNLines(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtLeastNLines(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtLeastNLines(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageContainsAtLeastNLines"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageContainsAtLeastNLines"
            ),
        };
    }

    public static implicit operator PageContainsAtLeastNLines(long value) => new(value);

    public static implicit operator PageContainsAtLeastNLines(string value) => new(value);

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
                "Data did not match any variant of PageContainsAtLeastNLines"
            );
        }
    }

    public virtual bool Equals(PageContainsAtLeastNLines? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageContainsAtLeastNLinesConverter : JsonConverter<PageContainsAtLeastNLines?>
{
    public override PageContainsAtLeastNLines? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageContainsAtLeastNLines? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has more than N links
/// </summary>
[JsonConverter(typeof(PageContainsAtLeastNLinksConverter))]
public record class PageContainsAtLeastNLinks : ModelBase
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

    public PageContainsAtLeastNLinks(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtLeastNLinks(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtLeastNLinks(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageContainsAtLeastNLinks"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageContainsAtLeastNLinks"
            ),
        };
    }

    public static implicit operator PageContainsAtLeastNLinks(long value) => new(value);

    public static implicit operator PageContainsAtLeastNLinks(string value) => new(value);

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
                "Data did not match any variant of PageContainsAtLeastNLinks"
            );
        }
    }

    public virtual bool Equals(PageContainsAtLeastNLinks? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageContainsAtLeastNLinksConverter : JsonConverter<PageContainsAtLeastNLinks?>
{
    public override PageContainsAtLeastNLinks? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageContainsAtLeastNLinks? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has more than N numeric words
/// </summary>
[JsonConverter(typeof(PageContainsAtLeastNNumbersConverter))]
public record class PageContainsAtLeastNNumbers : ModelBase
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

    public PageContainsAtLeastNNumbers(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtLeastNNumbers(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtLeastNNumbers(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageContainsAtLeastNNumbers"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageContainsAtLeastNNumbers"
            ),
        };
    }

    public static implicit operator PageContainsAtLeastNNumbers(long value) => new(value);

    public static implicit operator PageContainsAtLeastNNumbers(string value) => new(value);

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
                "Data did not match any variant of PageContainsAtLeastNNumbers"
            );
        }
    }

    public virtual bool Equals(PageContainsAtLeastNNumbers? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageContainsAtLeastNNumbersConverter : JsonConverter<PageContainsAtLeastNNumbers?>
{
    public override PageContainsAtLeastNNumbers? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageContainsAtLeastNNumbers? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has more than N% numeric words
/// </summary>
[JsonConverter(typeof(PageContainsAtLeastNPercentNumbersConverter))]
public record class PageContainsAtLeastNPercentNumbers : ModelBase
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

    public PageContainsAtLeastNPercentNumbers(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtLeastNPercentNumbers(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtLeastNPercentNumbers(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageContainsAtLeastNPercentNumbers"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageContainsAtLeastNPercentNumbers"
            ),
        };
    }

    public static implicit operator PageContainsAtLeastNPercentNumbers(long value) => new(value);

    public static implicit operator PageContainsAtLeastNPercentNumbers(string value) => new(value);

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
                "Data did not match any variant of PageContainsAtLeastNPercentNumbers"
            );
        }
    }

    public virtual bool Equals(PageContainsAtLeastNPercentNumbers? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageContainsAtLeastNPercentNumbersConverter
    : JsonConverter<PageContainsAtLeastNPercentNumbers?>
{
    public override PageContainsAtLeastNPercentNumbers? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageContainsAtLeastNPercentNumbers? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has more than N tables
/// </summary>
[JsonConverter(typeof(PageContainsAtLeastNTablesConverter))]
public record class PageContainsAtLeastNTables : ModelBase
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

    public PageContainsAtLeastNTables(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtLeastNTables(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtLeastNTables(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageContainsAtLeastNTables"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageContainsAtLeastNTables"
            ),
        };
    }

    public static implicit operator PageContainsAtLeastNTables(long value) => new(value);

    public static implicit operator PageContainsAtLeastNTables(string value) => new(value);

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
                "Data did not match any variant of PageContainsAtLeastNTables"
            );
        }
    }

    public virtual bool Equals(PageContainsAtLeastNTables? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageContainsAtLeastNTablesConverter : JsonConverter<PageContainsAtLeastNTables?>
{
    public override PageContainsAtLeastNTables? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageContainsAtLeastNTables? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has more than N words
/// </summary>
[JsonConverter(typeof(PageContainsAtLeastNWordsConverter))]
public record class PageContainsAtLeastNWords : ModelBase
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

    public PageContainsAtLeastNWords(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtLeastNWords(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtLeastNWords(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageContainsAtLeastNWords"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageContainsAtLeastNWords"
            ),
        };
    }

    public static implicit operator PageContainsAtLeastNWords(long value) => new(value);

    public static implicit operator PageContainsAtLeastNWords(string value) => new(value);

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
                "Data did not match any variant of PageContainsAtLeastNWords"
            );
        }
    }

    public virtual bool Equals(PageContainsAtLeastNWords? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageContainsAtLeastNWordsConverter : JsonConverter<PageContainsAtLeastNWords?>
{
    public override PageContainsAtLeastNWords? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageContainsAtLeastNWords? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has fewer than N charts
/// </summary>
[JsonConverter(typeof(PageContainsAtMostNChartsConverter))]
public record class PageContainsAtMostNCharts : ModelBase
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

    public PageContainsAtMostNCharts(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtMostNCharts(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtMostNCharts(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageContainsAtMostNCharts"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageContainsAtMostNCharts"
            ),
        };
    }

    public static implicit operator PageContainsAtMostNCharts(long value) => new(value);

    public static implicit operator PageContainsAtMostNCharts(string value) => new(value);

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
                "Data did not match any variant of PageContainsAtMostNCharts"
            );
        }
    }

    public virtual bool Equals(PageContainsAtMostNCharts? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageContainsAtMostNChartsConverter : JsonConverter<PageContainsAtMostNCharts?>
{
    public override PageContainsAtMostNCharts? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageContainsAtMostNCharts? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has fewer than N images
/// </summary>
[JsonConverter(typeof(PageContainsAtMostNImagesConverter))]
public record class PageContainsAtMostNImages : ModelBase
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

    public PageContainsAtMostNImages(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtMostNImages(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtMostNImages(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageContainsAtMostNImages"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageContainsAtMostNImages"
            ),
        };
    }

    public static implicit operator PageContainsAtMostNImages(long value) => new(value);

    public static implicit operator PageContainsAtMostNImages(string value) => new(value);

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
                "Data did not match any variant of PageContainsAtMostNImages"
            );
        }
    }

    public virtual bool Equals(PageContainsAtMostNImages? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageContainsAtMostNImagesConverter : JsonConverter<PageContainsAtMostNImages?>
{
    public override PageContainsAtMostNImages? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageContainsAtMostNImages? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has fewer than N layout elements
/// </summary>
[JsonConverter(typeof(PageContainsAtMostNLayoutElementsConverter))]
public record class PageContainsAtMostNLayoutElements : ModelBase
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

    public PageContainsAtMostNLayoutElements(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtMostNLayoutElements(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtMostNLayoutElements(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageContainsAtMostNLayoutElements"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageContainsAtMostNLayoutElements"
            ),
        };
    }

    public static implicit operator PageContainsAtMostNLayoutElements(long value) => new(value);

    public static implicit operator PageContainsAtMostNLayoutElements(string value) => new(value);

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
                "Data did not match any variant of PageContainsAtMostNLayoutElements"
            );
        }
    }

    public virtual bool Equals(PageContainsAtMostNLayoutElements? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageContainsAtMostNLayoutElementsConverter
    : JsonConverter<PageContainsAtMostNLayoutElements?>
{
    public override PageContainsAtMostNLayoutElements? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageContainsAtMostNLayoutElements? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has fewer than N lines
/// </summary>
[JsonConverter(typeof(PageContainsAtMostNLinesConverter))]
public record class PageContainsAtMostNLines : ModelBase
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

    public PageContainsAtMostNLines(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtMostNLines(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtMostNLines(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageContainsAtMostNLines"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageContainsAtMostNLines"
            ),
        };
    }

    public static implicit operator PageContainsAtMostNLines(long value) => new(value);

    public static implicit operator PageContainsAtMostNLines(string value) => new(value);

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
                "Data did not match any variant of PageContainsAtMostNLines"
            );
        }
    }

    public virtual bool Equals(PageContainsAtMostNLines? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageContainsAtMostNLinesConverter : JsonConverter<PageContainsAtMostNLines?>
{
    public override PageContainsAtMostNLines? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageContainsAtMostNLines? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has fewer than N links
/// </summary>
[JsonConverter(typeof(PageContainsAtMostNLinksConverter))]
public record class PageContainsAtMostNLinks : ModelBase
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

    public PageContainsAtMostNLinks(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtMostNLinks(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtMostNLinks(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageContainsAtMostNLinks"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageContainsAtMostNLinks"
            ),
        };
    }

    public static implicit operator PageContainsAtMostNLinks(long value) => new(value);

    public static implicit operator PageContainsAtMostNLinks(string value) => new(value);

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
                "Data did not match any variant of PageContainsAtMostNLinks"
            );
        }
    }

    public virtual bool Equals(PageContainsAtMostNLinks? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageContainsAtMostNLinksConverter : JsonConverter<PageContainsAtMostNLinks?>
{
    public override PageContainsAtMostNLinks? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageContainsAtMostNLinks? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has fewer than N numeric words
/// </summary>
[JsonConverter(typeof(PageContainsAtMostNNumbersConverter))]
public record class PageContainsAtMostNNumbers : ModelBase
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

    public PageContainsAtMostNNumbers(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtMostNNumbers(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtMostNNumbers(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageContainsAtMostNNumbers"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageContainsAtMostNNumbers"
            ),
        };
    }

    public static implicit operator PageContainsAtMostNNumbers(long value) => new(value);

    public static implicit operator PageContainsAtMostNNumbers(string value) => new(value);

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
                "Data did not match any variant of PageContainsAtMostNNumbers"
            );
        }
    }

    public virtual bool Equals(PageContainsAtMostNNumbers? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageContainsAtMostNNumbersConverter : JsonConverter<PageContainsAtMostNNumbers?>
{
    public override PageContainsAtMostNNumbers? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageContainsAtMostNNumbers? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has fewer than N% numeric words
/// </summary>
[JsonConverter(typeof(PageContainsAtMostNPercentNumbersConverter))]
public record class PageContainsAtMostNPercentNumbers : ModelBase
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

    public PageContainsAtMostNPercentNumbers(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtMostNPercentNumbers(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtMostNPercentNumbers(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageContainsAtMostNPercentNumbers"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageContainsAtMostNPercentNumbers"
            ),
        };
    }

    public static implicit operator PageContainsAtMostNPercentNumbers(long value) => new(value);

    public static implicit operator PageContainsAtMostNPercentNumbers(string value) => new(value);

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
                "Data did not match any variant of PageContainsAtMostNPercentNumbers"
            );
        }
    }

    public virtual bool Equals(PageContainsAtMostNPercentNumbers? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageContainsAtMostNPercentNumbersConverter
    : JsonConverter<PageContainsAtMostNPercentNumbers?>
{
    public override PageContainsAtMostNPercentNumbers? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageContainsAtMostNPercentNumbers? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has fewer than N tables
/// </summary>
[JsonConverter(typeof(PageContainsAtMostNTablesConverter))]
public record class PageContainsAtMostNTables : ModelBase
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

    public PageContainsAtMostNTables(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtMostNTables(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtMostNTables(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageContainsAtMostNTables"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageContainsAtMostNTables"
            ),
        };
    }

    public static implicit operator PageContainsAtMostNTables(long value) => new(value);

    public static implicit operator PageContainsAtMostNTables(string value) => new(value);

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
                "Data did not match any variant of PageContainsAtMostNTables"
            );
        }
    }

    public virtual bool Equals(PageContainsAtMostNTables? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageContainsAtMostNTablesConverter : JsonConverter<PageContainsAtMostNTables?>
{
    public override PageContainsAtMostNTables? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageContainsAtMostNTables? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has fewer than N words
/// </summary>
[JsonConverter(typeof(PageContainsAtMostNWordsConverter))]
public record class PageContainsAtMostNWords : ModelBase
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

    public PageContainsAtMostNWords(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtMostNWords(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageContainsAtMostNWords(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageContainsAtMostNWords"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageContainsAtMostNWords"
            ),
        };
    }

    public static implicit operator PageContainsAtMostNWords(long value) => new(value);

    public static implicit operator PageContainsAtMostNWords(string value) => new(value);

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
                "Data did not match any variant of PageContainsAtMostNWords"
            );
        }
    }

    public virtual bool Equals(PageContainsAtMostNWords? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageContainsAtMostNWordsConverter : JsonConverter<PageContainsAtMostNWords?>
{
    public override PageContainsAtMostNWords? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageContainsAtMostNWords? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has more than N characters
/// </summary>
[JsonConverter(typeof(PageLongerThanNCharsConverter))]
public record class PageLongerThanNChars : ModelBase
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

    public PageLongerThanNChars(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageLongerThanNChars(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageLongerThanNChars(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageLongerThanNChars"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageLongerThanNChars"
            ),
        };
    }

    public static implicit operator PageLongerThanNChars(long value) => new(value);

    public static implicit operator PageLongerThanNChars(string value) => new(value);

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
                "Data did not match any variant of PageLongerThanNChars"
            );
        }
    }

    public virtual bool Equals(PageLongerThanNChars? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageLongerThanNCharsConverter : JsonConverter<PageLongerThanNChars?>
{
    public override PageLongerThanNChars? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageLongerThanNChars? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Trigger if page has fewer than N characters
/// </summary>
[JsonConverter(typeof(PageShorterThanNCharsConverter))]
public record class PageShorterThanNChars : ModelBase
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

    public PageShorterThanNChars(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageShorterThanNChars(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PageShorterThanNChars(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<long> @long, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of PageShorterThanNChars"
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
    ///     (long value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<long, T> @long, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            long value => @long(value),
            string value => @string(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of PageShorterThanNChars"
            ),
        };
    }

    public static implicit operator PageShorterThanNChars(long value) => new(value);

    public static implicit operator PageShorterThanNChars(string value) => new(value);

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
                "Data did not match any variant of PageShorterThanNChars"
            );
        }
    }

    public virtual bool Equals(PageShorterThanNChars? other) =>
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
            long _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageShorterThanNCharsConverter : JsonConverter<PageShorterThanNChars?>
{
    public override PageShorterThanNChars? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageShorterThanNChars? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Confidence scoring effort. Omit for standard scoring. 'high': more accurate assessment
/// of the parsing quality of every page, plus a document-level score in the result
/// metadata; costs an additional 5 credits per page
/// </summary>
[JsonConverter(typeof(ConfidenceScoreEffortConverter))]
public enum ConfidenceScoreEffort
{
    High,
}

sealed class ConfidenceScoreEffortConverter : JsonConverter<ConfidenceScoreEffort>
{
    public override ConfidenceScoreEffort Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "high" => ConfidenceScoreEffort.High,
            _ => (ConfidenceScoreEffort)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConfidenceScoreEffort value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConfidenceScoreEffort.High => "high",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Cost optimizer configuration for reducing parsing costs on simpler pages.
///
/// <para>When enabled, the parser analyzes each page and routes simpler pages to
/// faster, cheaper processing while preserving quality for complex pages. Only works
/// with 'agentic' or 'agentic_plus' tiers.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CostOptimizer, CostOptimizerFromRaw>))]
public sealed record class CostOptimizer : JsonModel
{
    /// <summary>
    /// Enable cost-optimized parsing. Routes simpler pages to faster processing while
    /// complex pages use full AI analysis. May reduce speed on some documents. IMPORTANT:
    /// Only available with 'agentic' or 'agentic_plus' tiers
    /// </summary>
    public bool? Enable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enable");
        }
        init { this._rawData.Set("enable", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enable;
    }

    public CostOptimizer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CostOptimizer(CostOptimizer costOptimizer)
        : base(costOptimizer) { }
#pragma warning restore CS8618

    public CostOptimizer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CostOptimizer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CostOptimizerFromRaw.FromRawUnchecked"/>
    public static CostOptimizer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CostOptimizerFromRaw : IFromRawJson<CostOptimizer>
{
    /// <inheritdoc/>
    public CostOptimizer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CostOptimizer.FromRawUnchecked(rawData);
}

/// <summary>
/// Beta: set to 'enrich' to run an additional AI form-analysis pass on pages detected
/// as forms, producing a structured tree of the form's sections, fields, and fillable
/// grids. Retrieve the result with expand=forms. 'default' (the default) applies
/// standard parsing with no extra pass. Not available on the fast tier
/// </summary>
[JsonConverter(typeof(FormsConverter))]
public enum Forms
{
    Default,
    Enrich,
}

sealed class FormsConverter : JsonConverter<Forms>
{
    public override Forms Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "default" => Forms.Default,
            "enrich" => Forms.Enrich,
            _ => (Forms)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Forms value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Forms.Default => "default",
                Forms.Enrich => "enrich",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Options for ignoring specific text types (diagonal, hidden, text in images)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProcessingOptionsIgnore, ProcessingOptionsIgnoreFromRaw>))]
public sealed record class ProcessingOptionsIgnore : JsonModel
{
    /// <summary>
    /// Skip text rotated at an angle (not horizontal/vertical). Useful for ignoring
    /// watermarks or decorative angled text
    /// </summary>
    public bool? IgnoreDiagonalText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("ignore_diagonal_text");
        }
        init { this._rawData.Set("ignore_diagonal_text", value); }
    }

    /// <summary>
    /// Skip text marked as hidden in the document structure. Some PDFs contain invisible
    /// text layers used for accessibility or search indexing
    /// </summary>
    public bool? IgnoreHiddenText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("ignore_hidden_text");
        }
        init { this._rawData.Set("ignore_hidden_text", value); }
    }

    /// <summary>
    /// Skip OCR text extraction from embedded images. Use when images contain irrelevant
    /// text (watermarks, logos) that shouldn't be in the output
    /// </summary>
    public bool? IgnoreTextInImage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("ignore_text_in_image");
        }
        init { this._rawData.Set("ignore_text_in_image", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IgnoreDiagonalText;
        _ = this.IgnoreHiddenText;
        _ = this.IgnoreTextInImage;
    }

    public ProcessingOptionsIgnore() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProcessingOptionsIgnore(ProcessingOptionsIgnore processingOptionsIgnore)
        : base(processingOptionsIgnore) { }
#pragma warning restore CS8618

    public ProcessingOptionsIgnore(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProcessingOptionsIgnore(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProcessingOptionsIgnoreFromRaw.FromRawUnchecked"/>
    public static ProcessingOptionsIgnore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProcessingOptionsIgnoreFromRaw : IFromRawJson<ProcessingOptionsIgnore>
{
    /// <inheritdoc/>
    public ProcessingOptionsIgnore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProcessingOptionsIgnore.FromRawUnchecked(rawData);
}

/// <summary>
/// OCR configuration including language detection settings
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OcrParameters, OcrParametersFromRaw>))]
public sealed record class OcrParameters : JsonModel
{
    /// <summary>
    /// Languages to use for OCR text recognition. Specify multiple languages if document
    /// contains mixed-language content. Order matters - put primary language first.
    /// Example: ['en', 'es'] for English with Spanish
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ParsingLanguages>>? Languages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, ParsingLanguages>>
            >("languages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, ParsingLanguages>>?>(
                "languages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Languages ?? [])
        {
            item.Validate();
        }
    }

    public OcrParameters() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OcrParameters(OcrParameters ocrParameters)
        : base(ocrParameters) { }
#pragma warning restore CS8618

    public OcrParameters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OcrParameters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OcrParametersFromRaw.FromRawUnchecked"/>
    public static OcrParameters FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OcrParametersFromRaw : IFromRawJson<OcrParameters>
{
    /// <inheritdoc/>
    public OcrParameters FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OcrParameters.FromRawUnchecked(rawData);
}

/// <summary>
/// Enable AI-powered chart analysis. Modes: 'efficient' (fast, lower cost), 'agentic'
/// (balanced), 'agentic_plus' (highest accuracy). Automatically enables extract_layout
/// and precise_bounding_box when set
/// </summary>
[JsonConverter(typeof(ProcessingOptionsSpecializedChartParsingConverter))]
public enum ProcessingOptionsSpecializedChartParsing
{
    Agentic,
    AgenticPlus,
    Efficient,
}

sealed class ProcessingOptionsSpecializedChartParsingConverter
    : JsonConverter<ProcessingOptionsSpecializedChartParsing>
{
    public override ProcessingOptionsSpecializedChartParsing Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agentic" => ProcessingOptionsSpecializedChartParsing.Agentic,
            "agentic_plus" => ProcessingOptionsSpecializedChartParsing.AgenticPlus,
            "efficient" => ProcessingOptionsSpecializedChartParsing.Efficient,
            _ => (ProcessingOptionsSpecializedChartParsing)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProcessingOptionsSpecializedChartParsing value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProcessingOptionsSpecializedChartParsing.Agentic => "agentic",
                ProcessingOptionsSpecializedChartParsing.AgenticPlus => "agentic_plus",
                ProcessingOptionsSpecializedChartParsing.Efficient => "efficient",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Webhook configuration for receiving parsing job notifications.
///
/// <para>Webhooks are called when specified events occur during job processing.
/// Configure multiple webhook configurations to send to different endpoints.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookConfiguration, WebhookConfigurationFromRaw>))]
public sealed record class WebhookConfiguration : JsonModel
{
    /// <summary>
    /// Events that trigger this webhook. Options: 'parse.success' (job completed),
    /// 'parse.error' (job failed), 'parse.partial_success' (some pages failed),
    /// 'parse.pending', 'parse.running', 'parse.cancelled'. If not specified, webhook
    /// fires for all events
    /// </summary>
    public IReadOnlyList<string>? WebhookEvents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("webhook_events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "webhook_events",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Custom HTTP headers to include in webhook requests. Use for authentication
    /// tokens or custom routing. Example: {'Authorization': 'Bearer xyz'}
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? WebhookHeaders
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "webhook_headers"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "webhook_headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Format of the webhook payload body. 'string' (default) sends the payload as
    /// a JSON-encoded string; 'json' sends it as a JSON object.
    /// </summary>
    public ApiEnum<string, WebhookOutputFormat>? WebhookOutputFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WebhookOutputFormat>>(
                "webhook_output_format"
            );
        }
        init { this._rawData.Set("webhook_output_format", value); }
    }

    /// <summary>
    /// Shared signing secret used to sign webhook deliveries. When set, each request
    /// includes an HMAC-SHA256 signature of the request body in the 'LC-Signature'
    /// header (value 'sha256=&lt;hex&gt;'). Recompute the HMAC over the raw request
    /// body with this secret to verify the delivery is authentic.
    /// </summary>
    public string? WebhookSigningSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("webhook_signing_secret");
        }
        init { this._rawData.Set("webhook_signing_secret", value); }
    }

    /// <summary>
    /// HTTPS URL to receive webhook POST requests. Must be publicly accessible
    /// </summary>
    public string? WebhookUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("webhook_url");
        }
        init { this._rawData.Set("webhook_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.WebhookEvents;
        _ = this.WebhookHeaders;
        this.WebhookOutputFormat?.Validate();
        _ = this.WebhookSigningSecret;
        _ = this.WebhookUrl;
    }

    public WebhookConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookConfiguration(WebhookConfiguration webhookConfiguration)
        : base(webhookConfiguration) { }
#pragma warning restore CS8618

    public WebhookConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookConfigurationFromRaw.FromRawUnchecked"/>
    public static WebhookConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookConfigurationFromRaw : IFromRawJson<WebhookConfiguration>
{
    /// <inheritdoc/>
    public WebhookConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Format of the webhook payload body. 'string' (default) sends the payload as a
/// JSON-encoded string; 'json' sends it as a JSON object.
/// </summary>
[JsonConverter(typeof(WebhookOutputFormatConverter))]
public enum WebhookOutputFormat
{
    Json,
    String,
}

sealed class WebhookOutputFormatConverter : JsonConverter<WebhookOutputFormat>
{
    public override WebhookOutputFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "json" => WebhookOutputFormat.Json,
            "string" => WebhookOutputFormat.String,
            _ => (WebhookOutputFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookOutputFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookOutputFormat.Json => "json",
                WebhookOutputFormat.String => "string",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
