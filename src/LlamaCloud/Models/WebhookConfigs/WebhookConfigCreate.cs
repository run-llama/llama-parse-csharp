using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;

namespace LlamaCloud.Models.WebhookConfigs;

/// <summary>
/// Request to create a stored webhook configuration.
///
/// <para>The owning tenant is taken from the request context (e.g. the project in
/// the path), not the body.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookConfigCreate, WebhookConfigCreateFromRaw>))]
public sealed record class WebhookConfigCreate : JsonModel
{
    /// <summary>
    /// URL to receive webhook POST notifications.
    /// </summary>
    public required string WebhookUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("webhook_url");
        }
        init { this._rawData.Set("webhook_url", value); }
    }

    /// <summary>
    /// Events to subscribe to. If null, all events are delivered. An empty list subscribes
    /// to nothing and is rejected.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, WebhookConfigCreateWebhookEvent>>? WebhookEvents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, WebhookConfigCreateWebhookEvent>>
            >("webhook_events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, WebhookConfigCreateWebhookEvent>>?>(
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
    /// Response format sent to the webhook: 'string' (default) or 'json'.
    /// </summary>
    public ApiEnum<string, WebhookConfigCreateWebhookOutputFormat>? WebhookOutputFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, WebhookConfigCreateWebhookOutputFormat>
            >("webhook_output_format");
        }
        init { this._rawData.Set("webhook_output_format", value); }
    }

    /// <summary>
    /// Shared secret used to sign deliveries to this endpoint. Write-only: it is
    /// never returned in responses.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.WebhookUrl;
        foreach (var item in this.WebhookEvents ?? [])
        {
            item.Validate();
        }
        _ = this.WebhookHeaders;
        this.WebhookOutputFormat?.Validate();
        _ = this.WebhookSigningSecret;
    }

    public WebhookConfigCreate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookConfigCreate(WebhookConfigCreate webhookConfigCreate)
        : base(webhookConfigCreate) { }
#pragma warning restore CS8618

    public WebhookConfigCreate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookConfigCreate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookConfigCreateFromRaw.FromRawUnchecked"/>
    public static WebhookConfigCreate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebhookConfigCreate(string webhookUrl)
        : this()
    {
        this.WebhookUrl = webhookUrl;
    }
}

class WebhookConfigCreateFromRaw : IFromRawJson<WebhookConfigCreate>
{
    /// <inheritdoc/>
    public WebhookConfigCreate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhookConfigCreate.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(WebhookConfigCreateWebhookEventConverter))]
public enum WebhookConfigCreateWebhookEvent
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

sealed class WebhookConfigCreateWebhookEventConverter
    : JsonConverter<WebhookConfigCreateWebhookEvent>
{
    public override WebhookConfigCreateWebhookEvent Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "batch.cancelled" => WebhookConfigCreateWebhookEvent.BatchCancelled,
            "batch.error" => WebhookConfigCreateWebhookEvent.BatchError,
            "batch.pending" => WebhookConfigCreateWebhookEvent.BatchPending,
            "batch.running" => WebhookConfigCreateWebhookEvent.BatchRunning,
            "batch.success" => WebhookConfigCreateWebhookEvent.BatchSuccess,
            "classify.cancelled" => WebhookConfigCreateWebhookEvent.ClassifyCancelled,
            "classify.error" => WebhookConfigCreateWebhookEvent.ClassifyError,
            "classify.partial_success" => WebhookConfigCreateWebhookEvent.ClassifyPartialSuccess,
            "classify.pending" => WebhookConfigCreateWebhookEvent.ClassifyPending,
            "classify.running" => WebhookConfigCreateWebhookEvent.ClassifyRunning,
            "classify.success" => WebhookConfigCreateWebhookEvent.ClassifySuccess,
            "extract.cancelled" => WebhookConfigCreateWebhookEvent.ExtractCancelled,
            "extract.error" => WebhookConfigCreateWebhookEvent.ExtractError,
            "extract.partial_success" => WebhookConfigCreateWebhookEvent.ExtractPartialSuccess,
            "extract.pending" => WebhookConfigCreateWebhookEvent.ExtractPending,
            "extract.success" => WebhookConfigCreateWebhookEvent.ExtractSuccess,
            "parse.cancelled" => WebhookConfigCreateWebhookEvent.ParseCancelled,
            "parse.error" => WebhookConfigCreateWebhookEvent.ParseError,
            "parse.partial_success" => WebhookConfigCreateWebhookEvent.ParsePartialSuccess,
            "parse.pending" => WebhookConfigCreateWebhookEvent.ParsePending,
            "parse.running" => WebhookConfigCreateWebhookEvent.ParseRunning,
            "parse.success" => WebhookConfigCreateWebhookEvent.ParseSuccess,
            "sheets.cancelled" => WebhookConfigCreateWebhookEvent.SheetsCancelled,
            "sheets.error" => WebhookConfigCreateWebhookEvent.SheetsError,
            "sheets.partial_success" => WebhookConfigCreateWebhookEvent.SheetsPartialSuccess,
            "sheets.pending" => WebhookConfigCreateWebhookEvent.SheetsPending,
            "sheets.success" => WebhookConfigCreateWebhookEvent.SheetsSuccess,
            "split.cancelled" => WebhookConfigCreateWebhookEvent.SplitCancelled,
            "split.error" => WebhookConfigCreateWebhookEvent.SplitError,
            "split.pending" => WebhookConfigCreateWebhookEvent.SplitPending,
            "split.processing" => WebhookConfigCreateWebhookEvent.SplitProcessing,
            "split.success" => WebhookConfigCreateWebhookEvent.SplitSuccess,
            "unmapped_event" => WebhookConfigCreateWebhookEvent.UnmappedEvent,
            _ => (WebhookConfigCreateWebhookEvent)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookConfigCreateWebhookEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookConfigCreateWebhookEvent.BatchCancelled => "batch.cancelled",
                WebhookConfigCreateWebhookEvent.BatchError => "batch.error",
                WebhookConfigCreateWebhookEvent.BatchPending => "batch.pending",
                WebhookConfigCreateWebhookEvent.BatchRunning => "batch.running",
                WebhookConfigCreateWebhookEvent.BatchSuccess => "batch.success",
                WebhookConfigCreateWebhookEvent.ClassifyCancelled => "classify.cancelled",
                WebhookConfigCreateWebhookEvent.ClassifyError => "classify.error",
                WebhookConfigCreateWebhookEvent.ClassifyPartialSuccess =>
                    "classify.partial_success",
                WebhookConfigCreateWebhookEvent.ClassifyPending => "classify.pending",
                WebhookConfigCreateWebhookEvent.ClassifyRunning => "classify.running",
                WebhookConfigCreateWebhookEvent.ClassifySuccess => "classify.success",
                WebhookConfigCreateWebhookEvent.ExtractCancelled => "extract.cancelled",
                WebhookConfigCreateWebhookEvent.ExtractError => "extract.error",
                WebhookConfigCreateWebhookEvent.ExtractPartialSuccess => "extract.partial_success",
                WebhookConfigCreateWebhookEvent.ExtractPending => "extract.pending",
                WebhookConfigCreateWebhookEvent.ExtractSuccess => "extract.success",
                WebhookConfigCreateWebhookEvent.ParseCancelled => "parse.cancelled",
                WebhookConfigCreateWebhookEvent.ParseError => "parse.error",
                WebhookConfigCreateWebhookEvent.ParsePartialSuccess => "parse.partial_success",
                WebhookConfigCreateWebhookEvent.ParsePending => "parse.pending",
                WebhookConfigCreateWebhookEvent.ParseRunning => "parse.running",
                WebhookConfigCreateWebhookEvent.ParseSuccess => "parse.success",
                WebhookConfigCreateWebhookEvent.SheetsCancelled => "sheets.cancelled",
                WebhookConfigCreateWebhookEvent.SheetsError => "sheets.error",
                WebhookConfigCreateWebhookEvent.SheetsPartialSuccess => "sheets.partial_success",
                WebhookConfigCreateWebhookEvent.SheetsPending => "sheets.pending",
                WebhookConfigCreateWebhookEvent.SheetsSuccess => "sheets.success",
                WebhookConfigCreateWebhookEvent.SplitCancelled => "split.cancelled",
                WebhookConfigCreateWebhookEvent.SplitError => "split.error",
                WebhookConfigCreateWebhookEvent.SplitPending => "split.pending",
                WebhookConfigCreateWebhookEvent.SplitProcessing => "split.processing",
                WebhookConfigCreateWebhookEvent.SplitSuccess => "split.success",
                WebhookConfigCreateWebhookEvent.UnmappedEvent => "unmapped_event",
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
[JsonConverter(typeof(WebhookConfigCreateWebhookOutputFormatConverter))]
public enum WebhookConfigCreateWebhookOutputFormat
{
    Json,
    String,
}

sealed class WebhookConfigCreateWebhookOutputFormatConverter
    : JsonConverter<WebhookConfigCreateWebhookOutputFormat>
{
    public override WebhookConfigCreateWebhookOutputFormat Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "json" => WebhookConfigCreateWebhookOutputFormat.Json,
            "string" => WebhookConfigCreateWebhookOutputFormat.String,
            _ => (WebhookConfigCreateWebhookOutputFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookConfigCreateWebhookOutputFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookConfigCreateWebhookOutputFormat.Json => "json",
                WebhookConfigCreateWebhookOutputFormat.String => "string",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
