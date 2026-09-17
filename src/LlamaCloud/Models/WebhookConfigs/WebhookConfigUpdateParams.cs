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

namespace LlamaCloud.Models.WebhookConfigs;

/// <summary>
/// Update a webhook configuration. Only fields present in the request change.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WebhookConfigUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ConfigID { get; init; }

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
    /// Updated event subscriptions.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, WebhookConfigUpdateParamsWebhookEvent>>? WebhookEvents
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, WebhookConfigUpdateParamsWebhookEvent>>
            >("webhook_events");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<
                ApiEnum<string, WebhookConfigUpdateParamsWebhookEvent>
            >?>("webhook_events", value == null ? null : ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Updated headers.
    /// </summary>
    public IReadOnlyDictionary<string, string>? WebhookHeaders
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>(
                "webhook_headers"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "webhook_headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Updated output format.
    /// </summary>
    public ApiEnum<string, WebhookConfigUpdateParamsWebhookOutputFormat>? WebhookOutputFormat
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, WebhookConfigUpdateParamsWebhookOutputFormat>
            >("webhook_output_format");
        }
        init { this._rawBodyData.Set("webhook_output_format", value); }
    }

    /// <summary>
    /// Updated signing secret (write-only). Send to rotate the secret.
    /// </summary>
    public string? WebhookSigningSecret
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("webhook_signing_secret");
        }
        init { this._rawBodyData.Set("webhook_signing_secret", value); }
    }

    /// <summary>
    /// Updated webhook URL.
    /// </summary>
    public string? WebhookUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("webhook_url");
        }
        init { this._rawBodyData.Set("webhook_url", value); }
    }

    public WebhookConfigUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookConfigUpdateParams(WebhookConfigUpdateParams webhookConfigUpdateParams)
        : base(webhookConfigUpdateParams)
    {
        this.ConfigID = webhookConfigUpdateParams.ConfigID;

        this._rawBodyData = new(webhookConfigUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WebhookConfigUpdateParams(
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
    WebhookConfigUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string configID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ConfigID = configID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WebhookConfigUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string configID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            configID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ConfigID"] = JsonSerializer.SerializeToElement(this.ConfigID),
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

    public virtual bool Equals(WebhookConfigUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ConfigID?.Equals(other.ConfigID) ?? other.ConfigID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/api/v1/beta/webhook-configs/{0}", this.ConfigID)
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

[JsonConverter(typeof(WebhookConfigUpdateParamsWebhookEventConverter))]
public enum WebhookConfigUpdateParamsWebhookEvent
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

sealed class WebhookConfigUpdateParamsWebhookEventConverter
    : JsonConverter<WebhookConfigUpdateParamsWebhookEvent>
{
    public override WebhookConfigUpdateParamsWebhookEvent Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "batch.cancelled" => WebhookConfigUpdateParamsWebhookEvent.BatchCancelled,
            "batch.error" => WebhookConfigUpdateParamsWebhookEvent.BatchError,
            "batch.pending" => WebhookConfigUpdateParamsWebhookEvent.BatchPending,
            "batch.running" => WebhookConfigUpdateParamsWebhookEvent.BatchRunning,
            "batch.success" => WebhookConfigUpdateParamsWebhookEvent.BatchSuccess,
            "classify.cancelled" => WebhookConfigUpdateParamsWebhookEvent.ClassifyCancelled,
            "classify.error" => WebhookConfigUpdateParamsWebhookEvent.ClassifyError,
            "classify.partial_success" =>
                WebhookConfigUpdateParamsWebhookEvent.ClassifyPartialSuccess,
            "classify.pending" => WebhookConfigUpdateParamsWebhookEvent.ClassifyPending,
            "classify.running" => WebhookConfigUpdateParamsWebhookEvent.ClassifyRunning,
            "classify.success" => WebhookConfigUpdateParamsWebhookEvent.ClassifySuccess,
            "extract.cancelled" => WebhookConfigUpdateParamsWebhookEvent.ExtractCancelled,
            "extract.error" => WebhookConfigUpdateParamsWebhookEvent.ExtractError,
            "extract.partial_success" =>
                WebhookConfigUpdateParamsWebhookEvent.ExtractPartialSuccess,
            "extract.pending" => WebhookConfigUpdateParamsWebhookEvent.ExtractPending,
            "extract.success" => WebhookConfigUpdateParamsWebhookEvent.ExtractSuccess,
            "parse.cancelled" => WebhookConfigUpdateParamsWebhookEvent.ParseCancelled,
            "parse.error" => WebhookConfigUpdateParamsWebhookEvent.ParseError,
            "parse.partial_success" => WebhookConfigUpdateParamsWebhookEvent.ParsePartialSuccess,
            "parse.pending" => WebhookConfigUpdateParamsWebhookEvent.ParsePending,
            "parse.running" => WebhookConfigUpdateParamsWebhookEvent.ParseRunning,
            "parse.success" => WebhookConfigUpdateParamsWebhookEvent.ParseSuccess,
            "sheets.cancelled" => WebhookConfigUpdateParamsWebhookEvent.SheetsCancelled,
            "sheets.error" => WebhookConfigUpdateParamsWebhookEvent.SheetsError,
            "sheets.partial_success" => WebhookConfigUpdateParamsWebhookEvent.SheetsPartialSuccess,
            "sheets.pending" => WebhookConfigUpdateParamsWebhookEvent.SheetsPending,
            "sheets.success" => WebhookConfigUpdateParamsWebhookEvent.SheetsSuccess,
            "split.cancelled" => WebhookConfigUpdateParamsWebhookEvent.SplitCancelled,
            "split.error" => WebhookConfigUpdateParamsWebhookEvent.SplitError,
            "split.pending" => WebhookConfigUpdateParamsWebhookEvent.SplitPending,
            "split.processing" => WebhookConfigUpdateParamsWebhookEvent.SplitProcessing,
            "split.success" => WebhookConfigUpdateParamsWebhookEvent.SplitSuccess,
            "unmapped_event" => WebhookConfigUpdateParamsWebhookEvent.UnmappedEvent,
            _ => (WebhookConfigUpdateParamsWebhookEvent)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookConfigUpdateParamsWebhookEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookConfigUpdateParamsWebhookEvent.BatchCancelled => "batch.cancelled",
                WebhookConfigUpdateParamsWebhookEvent.BatchError => "batch.error",
                WebhookConfigUpdateParamsWebhookEvent.BatchPending => "batch.pending",
                WebhookConfigUpdateParamsWebhookEvent.BatchRunning => "batch.running",
                WebhookConfigUpdateParamsWebhookEvent.BatchSuccess => "batch.success",
                WebhookConfigUpdateParamsWebhookEvent.ClassifyCancelled => "classify.cancelled",
                WebhookConfigUpdateParamsWebhookEvent.ClassifyError => "classify.error",
                WebhookConfigUpdateParamsWebhookEvent.ClassifyPartialSuccess =>
                    "classify.partial_success",
                WebhookConfigUpdateParamsWebhookEvent.ClassifyPending => "classify.pending",
                WebhookConfigUpdateParamsWebhookEvent.ClassifyRunning => "classify.running",
                WebhookConfigUpdateParamsWebhookEvent.ClassifySuccess => "classify.success",
                WebhookConfigUpdateParamsWebhookEvent.ExtractCancelled => "extract.cancelled",
                WebhookConfigUpdateParamsWebhookEvent.ExtractError => "extract.error",
                WebhookConfigUpdateParamsWebhookEvent.ExtractPartialSuccess =>
                    "extract.partial_success",
                WebhookConfigUpdateParamsWebhookEvent.ExtractPending => "extract.pending",
                WebhookConfigUpdateParamsWebhookEvent.ExtractSuccess => "extract.success",
                WebhookConfigUpdateParamsWebhookEvent.ParseCancelled => "parse.cancelled",
                WebhookConfigUpdateParamsWebhookEvent.ParseError => "parse.error",
                WebhookConfigUpdateParamsWebhookEvent.ParsePartialSuccess =>
                    "parse.partial_success",
                WebhookConfigUpdateParamsWebhookEvent.ParsePending => "parse.pending",
                WebhookConfigUpdateParamsWebhookEvent.ParseRunning => "parse.running",
                WebhookConfigUpdateParamsWebhookEvent.ParseSuccess => "parse.success",
                WebhookConfigUpdateParamsWebhookEvent.SheetsCancelled => "sheets.cancelled",
                WebhookConfigUpdateParamsWebhookEvent.SheetsError => "sheets.error",
                WebhookConfigUpdateParamsWebhookEvent.SheetsPartialSuccess =>
                    "sheets.partial_success",
                WebhookConfigUpdateParamsWebhookEvent.SheetsPending => "sheets.pending",
                WebhookConfigUpdateParamsWebhookEvent.SheetsSuccess => "sheets.success",
                WebhookConfigUpdateParamsWebhookEvent.SplitCancelled => "split.cancelled",
                WebhookConfigUpdateParamsWebhookEvent.SplitError => "split.error",
                WebhookConfigUpdateParamsWebhookEvent.SplitPending => "split.pending",
                WebhookConfigUpdateParamsWebhookEvent.SplitProcessing => "split.processing",
                WebhookConfigUpdateParamsWebhookEvent.SplitSuccess => "split.success",
                WebhookConfigUpdateParamsWebhookEvent.UnmappedEvent => "unmapped_event",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Updated output format.
/// </summary>
[JsonConverter(typeof(WebhookConfigUpdateParamsWebhookOutputFormatConverter))]
public enum WebhookConfigUpdateParamsWebhookOutputFormat
{
    Json,
    String,
}

sealed class WebhookConfigUpdateParamsWebhookOutputFormatConverter
    : JsonConverter<WebhookConfigUpdateParamsWebhookOutputFormat>
{
    public override WebhookConfigUpdateParamsWebhookOutputFormat Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "json" => WebhookConfigUpdateParamsWebhookOutputFormat.Json,
            "string" => WebhookConfigUpdateParamsWebhookOutputFormat.String,
            _ => (WebhookConfigUpdateParamsWebhookOutputFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookConfigUpdateParamsWebhookOutputFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookConfigUpdateParamsWebhookOutputFormat.Json => "json",
                WebhookConfigUpdateParamsWebhookOutputFormat.String => "string",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
