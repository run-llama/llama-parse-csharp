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
/// Create a reusable webhook configuration for the current project.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WebhookConfigCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// URL to receive webhook POST notifications.
    /// </summary>
    public required string WebhookUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("webhook_url");
        }
        init { this._rawBodyData.Set("webhook_url", value); }
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
    /// Events to subscribe to. If null, all events are delivered. An empty list subscribes
    /// to nothing and is rejected.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, WebhookEvent>>? WebhookEvents
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, WebhookEvent>>
            >("webhook_events");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, WebhookEvent>>?>(
                "webhook_events",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Custom HTTP headers sent with each webhook request.
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
    /// Response format sent to the webhook: 'string' (default) or 'json'.
    /// </summary>
    public ApiEnum<string, WebhookOutputFormat>? WebhookOutputFormat
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, WebhookOutputFormat>>(
                "webhook_output_format"
            );
        }
        init { this._rawBodyData.Set("webhook_output_format", value); }
    }

    /// <summary>
    /// Shared secret used to sign deliveries to this endpoint. Write-only: it is
    /// never returned in responses.
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

    public WebhookConfigCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookConfigCreateParams(WebhookConfigCreateParams webhookConfigCreateParams)
        : base(webhookConfigCreateParams)
    {
        this._rawBodyData = new(webhookConfigCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WebhookConfigCreateParams(
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
    WebhookConfigCreateParams(
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
    public static WebhookConfigCreateParams FromRawUnchecked(
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

    public virtual bool Equals(WebhookConfigCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/beta/webhook-configs"
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

/// <summary>
/// Response format sent to the webhook: 'string' (default) or 'json'.
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
        Type typeToConvert,
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
