using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using Sheets = LlamaIndex.LlamaCloud.Models.Beta.Sheets;

namespace LlamaIndex.LlamaCloud.Models.Sheets;

/// <summary>
/// Create a spreadsheet parsing job.
///
/// <para>Provide at most one of `configuration` (an inline parsing configuration)
/// or `configuration_id` (a saved configuration preset). If neither is provided,
/// a default configuration is used. Optionally include `webhook_configurations`
/// to receive `sheets.*` status notifications.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SheetCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The ID of the file to parse
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("file_id");
        }
        init { this._rawBodyData.Set("file_id", value); }
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
    /// Configuration for spreadsheet parsing and region extraction
    /// </summary>
    [Obsolete("deprecated")]
    public Sheets::SheetsParsingConfig? Config
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Sheets::SheetsParsingConfig>("config");
        }
        init { this._rawBodyData.Set("config", value); }
    }

    /// <summary>
    /// Configuration for spreadsheet parsing and region extraction
    /// </summary>
    public Sheets::SheetsParsingConfig? Configuration
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Sheets::SheetsParsingConfig>("configuration");
        }
        init { this._rawBodyData.Set("configuration", value); }
    }

    /// <summary>
    /// Saved configuration ID
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
    /// Outbound webhook endpoints to notify on job status changes
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
            this._rawBodyData.Set<ImmutableArray<WebhookConfiguration>?>(
                "webhook_configurations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public SheetCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SheetCreateParams(SheetCreateParams sheetCreateParams)
        : base(sheetCreateParams)
    {
        this._rawBodyData = new(sheetCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SheetCreateParams(
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
    SheetCreateParams(
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
    public static SheetCreateParams FromRawUnchecked(
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

    public virtual bool Equals(SheetCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/sheets/jobs")
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
/// Configuration for a single outbound webhook endpoint.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookConfiguration, WebhookConfigurationFromRaw>))]
public sealed record class WebhookConfiguration : JsonModel
{
    /// <summary>
    /// Events to subscribe to (e.g. 'parse.success', 'extract.error'). If null, all
    /// events are delivered.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, WebhookEvent>>? WebhookEvents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, WebhookEvent>>>(
                "webhook_events"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, WebhookEvent>>?>(
                "webhook_events",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Custom HTTP headers sent with each webhook request (e.g. auth tokens)
    /// </summary>
    public IReadOnlyDictionary<string, string>? WebhookHeaders
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "webhook_headers"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "webhook_headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Response format sent to the webhook: 'string' (default) or 'json'
    /// </summary>
    public string? WebhookOutputFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("webhook_output_format");
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
    /// URL to receive webhook POST notifications
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
        foreach (var item in this.WebhookEvents ?? [])
        {
            item.Validate();
        }
        _ = this.WebhookHeaders;
        _ = this.WebhookOutputFormat;
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

[JsonConverter(typeof(WebhookEventConverter))]
public enum WebhookEvent
{
    BatchCancelled,
    BatchError,
    BatchPending,
    BatchRunning,
    BatchSuccess,
    ClassifyCancelled,
    ClassifyError,
    ClassifyPartialSuccess,
    ClassifyPending,
    ClassifyRunning,
    ClassifySuccess,
    ExtractCancelled,
    ExtractError,
    ExtractPartialSuccess,
    ExtractPending,
    ExtractSuccess,
    ParseCancelled,
    ParseError,
    ParsePartialSuccess,
    ParsePending,
    ParseRunning,
    ParseSuccess,
    SheetsCancelled,
    SheetsError,
    SheetsPartialSuccess,
    SheetsPending,
    SheetsSuccess,
    SplitCancelled,
    SplitError,
    SplitPending,
    SplitProcessing,
    SplitSuccess,
    UnmappedEvent,
}

sealed class WebhookEventConverter : JsonConverter<WebhookEvent>
{
    public override WebhookEvent Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "batch.cancelled" => WebhookEvent.BatchCancelled,
            "batch.error" => WebhookEvent.BatchError,
            "batch.pending" => WebhookEvent.BatchPending,
            "batch.running" => WebhookEvent.BatchRunning,
            "batch.success" => WebhookEvent.BatchSuccess,
            "classify.cancelled" => WebhookEvent.ClassifyCancelled,
            "classify.error" => WebhookEvent.ClassifyError,
            "classify.partial_success" => WebhookEvent.ClassifyPartialSuccess,
            "classify.pending" => WebhookEvent.ClassifyPending,
            "classify.running" => WebhookEvent.ClassifyRunning,
            "classify.success" => WebhookEvent.ClassifySuccess,
            "extract.cancelled" => WebhookEvent.ExtractCancelled,
            "extract.error" => WebhookEvent.ExtractError,
            "extract.partial_success" => WebhookEvent.ExtractPartialSuccess,
            "extract.pending" => WebhookEvent.ExtractPending,
            "extract.success" => WebhookEvent.ExtractSuccess,
            "parse.cancelled" => WebhookEvent.ParseCancelled,
            "parse.error" => WebhookEvent.ParseError,
            "parse.partial_success" => WebhookEvent.ParsePartialSuccess,
            "parse.pending" => WebhookEvent.ParsePending,
            "parse.running" => WebhookEvent.ParseRunning,
            "parse.success" => WebhookEvent.ParseSuccess,
            "sheets.cancelled" => WebhookEvent.SheetsCancelled,
            "sheets.error" => WebhookEvent.SheetsError,
            "sheets.partial_success" => WebhookEvent.SheetsPartialSuccess,
            "sheets.pending" => WebhookEvent.SheetsPending,
            "sheets.success" => WebhookEvent.SheetsSuccess,
            "split.cancelled" => WebhookEvent.SplitCancelled,
            "split.error" => WebhookEvent.SplitError,
            "split.pending" => WebhookEvent.SplitPending,
            "split.processing" => WebhookEvent.SplitProcessing,
            "split.success" => WebhookEvent.SplitSuccess,
            "unmapped_event" => WebhookEvent.UnmappedEvent,
            _ => (WebhookEvent)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookEvent.BatchCancelled => "batch.cancelled",
                WebhookEvent.BatchError => "batch.error",
                WebhookEvent.BatchPending => "batch.pending",
                WebhookEvent.BatchRunning => "batch.running",
                WebhookEvent.BatchSuccess => "batch.success",
                WebhookEvent.ClassifyCancelled => "classify.cancelled",
                WebhookEvent.ClassifyError => "classify.error",
                WebhookEvent.ClassifyPartialSuccess => "classify.partial_success",
                WebhookEvent.ClassifyPending => "classify.pending",
                WebhookEvent.ClassifyRunning => "classify.running",
                WebhookEvent.ClassifySuccess => "classify.success",
                WebhookEvent.ExtractCancelled => "extract.cancelled",
                WebhookEvent.ExtractError => "extract.error",
                WebhookEvent.ExtractPartialSuccess => "extract.partial_success",
                WebhookEvent.ExtractPending => "extract.pending",
                WebhookEvent.ExtractSuccess => "extract.success",
                WebhookEvent.ParseCancelled => "parse.cancelled",
                WebhookEvent.ParseError => "parse.error",
                WebhookEvent.ParsePartialSuccess => "parse.partial_success",
                WebhookEvent.ParsePending => "parse.pending",
                WebhookEvent.ParseRunning => "parse.running",
                WebhookEvent.ParseSuccess => "parse.success",
                WebhookEvent.SheetsCancelled => "sheets.cancelled",
                WebhookEvent.SheetsError => "sheets.error",
                WebhookEvent.SheetsPartialSuccess => "sheets.partial_success",
                WebhookEvent.SheetsPending => "sheets.pending",
                WebhookEvent.SheetsSuccess => "sheets.success",
                WebhookEvent.SplitCancelled => "split.cancelled",
                WebhookEvent.SplitError => "split.error",
                WebhookEvent.SplitPending => "split.pending",
                WebhookEvent.SplitProcessing => "split.processing",
                WebhookEvent.SplitSuccess => "split.success",
                WebhookEvent.UnmappedEvent => "unmapped_event",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
