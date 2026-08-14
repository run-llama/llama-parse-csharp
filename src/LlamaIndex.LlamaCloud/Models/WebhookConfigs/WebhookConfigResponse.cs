using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;

namespace LlamaIndex.LlamaCloud.Models.WebhookConfigs;

/// <summary>
/// A stored webhook configuration. The signing secret is never included.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookConfigResponse, WebhookConfigResponseFromRaw>))]
public sealed record class WebhookConfigResponse : JsonModel
{
    /// <summary>
    /// Unique identifier for the webhook configuration.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Whether a signing secret is configured for this endpoint.
    /// </summary>
    public required bool HasSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_secret");
        }
        init { this._rawData.Set("has_secret", value); }
    }

    /// <summary>
    /// Owner tenant ID.
    /// </summary>
    public required string TenantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tenant_id");
        }
        init { this._rawData.Set("tenant_id", value); }
    }

    /// <summary>
    /// Owner tenant type.
    /// </summary>
    public JsonElement TenantType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("tenant_type");
        }
        init { this._rawData.Set("tenant_type", value); }
    }

    /// <summary>
    /// URL that receives webhook POST notifications.
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
    /// Creation datetime
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Update datetime
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Subscribed events (null = all events).
    /// </summary>
    public IReadOnlyList<ApiEnum<string, WebhookConfigResponseWebhookEvent>>? WebhookEvents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, WebhookConfigResponseWebhookEvent>>
            >("webhook_events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, WebhookConfigResponseWebhookEvent>>?>(
                "webhook_events",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Custom HTTP headers sent with each request.
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
    /// Response format sent to the webhook.
    /// </summary>
    public ApiEnum<string, WebhookConfigResponseWebhookOutputFormat>? WebhookOutputFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, WebhookConfigResponseWebhookOutputFormat>
            >("webhook_output_format");
        }
        init { this._rawData.Set("webhook_output_format", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.HasSecret;
        _ = this.TenantID;
        if (!JsonElement.DeepEquals(this.TenantType, JsonSerializer.SerializeToElement("project")))
        {
            throw new LlamaCloudInvalidDataException("Invalid value given for constant");
        }
        _ = this.WebhookUrl;
        _ = this.CreatedAt;
        _ = this.UpdatedAt;
        foreach (var item in this.WebhookEvents ?? [])
        {
            item.Validate();
        }
        _ = this.WebhookHeaders;
        this.WebhookOutputFormat?.Validate();
    }

    public WebhookConfigResponse()
    {
        this.TenantType = JsonSerializer.SerializeToElement("project");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookConfigResponse(WebhookConfigResponse webhookConfigResponse)
        : base(webhookConfigResponse) { }
#pragma warning restore CS8618

    public WebhookConfigResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.TenantType = JsonSerializer.SerializeToElement("project");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookConfigResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookConfigResponseFromRaw.FromRawUnchecked"/>
    public static WebhookConfigResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookConfigResponseFromRaw : IFromRawJson<WebhookConfigResponse>
{
    /// <inheritdoc/>
    public WebhookConfigResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookConfigResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(WebhookConfigResponseWebhookEventConverter))]
public enum WebhookConfigResponseWebhookEvent
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

sealed class WebhookConfigResponseWebhookEventConverter
    : JsonConverter<WebhookConfigResponseWebhookEvent>
{
    public override WebhookConfigResponseWebhookEvent Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "batch.cancelled" => WebhookConfigResponseWebhookEvent.BatchCancelled,
            "batch.error" => WebhookConfigResponseWebhookEvent.BatchError,
            "batch.pending" => WebhookConfigResponseWebhookEvent.BatchPending,
            "batch.running" => WebhookConfigResponseWebhookEvent.BatchRunning,
            "batch.success" => WebhookConfigResponseWebhookEvent.BatchSuccess,
            "classify.cancelled" => WebhookConfigResponseWebhookEvent.ClassifyCancelled,
            "classify.error" => WebhookConfigResponseWebhookEvent.ClassifyError,
            "classify.partial_success" => WebhookConfigResponseWebhookEvent.ClassifyPartialSuccess,
            "classify.pending" => WebhookConfigResponseWebhookEvent.ClassifyPending,
            "classify.running" => WebhookConfigResponseWebhookEvent.ClassifyRunning,
            "classify.success" => WebhookConfigResponseWebhookEvent.ClassifySuccess,
            "extract.cancelled" => WebhookConfigResponseWebhookEvent.ExtractCancelled,
            "extract.error" => WebhookConfigResponseWebhookEvent.ExtractError,
            "extract.partial_success" => WebhookConfigResponseWebhookEvent.ExtractPartialSuccess,
            "extract.pending" => WebhookConfigResponseWebhookEvent.ExtractPending,
            "extract.success" => WebhookConfigResponseWebhookEvent.ExtractSuccess,
            "parse.cancelled" => WebhookConfigResponseWebhookEvent.ParseCancelled,
            "parse.error" => WebhookConfigResponseWebhookEvent.ParseError,
            "parse.partial_success" => WebhookConfigResponseWebhookEvent.ParsePartialSuccess,
            "parse.pending" => WebhookConfigResponseWebhookEvent.ParsePending,
            "parse.running" => WebhookConfigResponseWebhookEvent.ParseRunning,
            "parse.success" => WebhookConfigResponseWebhookEvent.ParseSuccess,
            "sheets.cancelled" => WebhookConfigResponseWebhookEvent.SheetsCancelled,
            "sheets.error" => WebhookConfigResponseWebhookEvent.SheetsError,
            "sheets.partial_success" => WebhookConfigResponseWebhookEvent.SheetsPartialSuccess,
            "sheets.pending" => WebhookConfigResponseWebhookEvent.SheetsPending,
            "sheets.success" => WebhookConfigResponseWebhookEvent.SheetsSuccess,
            "split.cancelled" => WebhookConfigResponseWebhookEvent.SplitCancelled,
            "split.error" => WebhookConfigResponseWebhookEvent.SplitError,
            "split.pending" => WebhookConfigResponseWebhookEvent.SplitPending,
            "split.processing" => WebhookConfigResponseWebhookEvent.SplitProcessing,
            "split.success" => WebhookConfigResponseWebhookEvent.SplitSuccess,
            "unmapped_event" => WebhookConfigResponseWebhookEvent.UnmappedEvent,
            _ => (WebhookConfigResponseWebhookEvent)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookConfigResponseWebhookEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookConfigResponseWebhookEvent.BatchCancelled => "batch.cancelled",
                WebhookConfigResponseWebhookEvent.BatchError => "batch.error",
                WebhookConfigResponseWebhookEvent.BatchPending => "batch.pending",
                WebhookConfigResponseWebhookEvent.BatchRunning => "batch.running",
                WebhookConfigResponseWebhookEvent.BatchSuccess => "batch.success",
                WebhookConfigResponseWebhookEvent.ClassifyCancelled => "classify.cancelled",
                WebhookConfigResponseWebhookEvent.ClassifyError => "classify.error",
                WebhookConfigResponseWebhookEvent.ClassifyPartialSuccess =>
                    "classify.partial_success",
                WebhookConfigResponseWebhookEvent.ClassifyPending => "classify.pending",
                WebhookConfigResponseWebhookEvent.ClassifyRunning => "classify.running",
                WebhookConfigResponseWebhookEvent.ClassifySuccess => "classify.success",
                WebhookConfigResponseWebhookEvent.ExtractCancelled => "extract.cancelled",
                WebhookConfigResponseWebhookEvent.ExtractError => "extract.error",
                WebhookConfigResponseWebhookEvent.ExtractPartialSuccess =>
                    "extract.partial_success",
                WebhookConfigResponseWebhookEvent.ExtractPending => "extract.pending",
                WebhookConfigResponseWebhookEvent.ExtractSuccess => "extract.success",
                WebhookConfigResponseWebhookEvent.ParseCancelled => "parse.cancelled",
                WebhookConfigResponseWebhookEvent.ParseError => "parse.error",
                WebhookConfigResponseWebhookEvent.ParsePartialSuccess => "parse.partial_success",
                WebhookConfigResponseWebhookEvent.ParsePending => "parse.pending",
                WebhookConfigResponseWebhookEvent.ParseRunning => "parse.running",
                WebhookConfigResponseWebhookEvent.ParseSuccess => "parse.success",
                WebhookConfigResponseWebhookEvent.SheetsCancelled => "sheets.cancelled",
                WebhookConfigResponseWebhookEvent.SheetsError => "sheets.error",
                WebhookConfigResponseWebhookEvent.SheetsPartialSuccess => "sheets.partial_success",
                WebhookConfigResponseWebhookEvent.SheetsPending => "sheets.pending",
                WebhookConfigResponseWebhookEvent.SheetsSuccess => "sheets.success",
                WebhookConfigResponseWebhookEvent.SplitCancelled => "split.cancelled",
                WebhookConfigResponseWebhookEvent.SplitError => "split.error",
                WebhookConfigResponseWebhookEvent.SplitPending => "split.pending",
                WebhookConfigResponseWebhookEvent.SplitProcessing => "split.processing",
                WebhookConfigResponseWebhookEvent.SplitSuccess => "split.success",
                WebhookConfigResponseWebhookEvent.UnmappedEvent => "unmapped_event",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Response format sent to the webhook.
/// </summary>
[JsonConverter(typeof(WebhookConfigResponseWebhookOutputFormatConverter))]
public enum WebhookConfigResponseWebhookOutputFormat
{
    Json,
    String,
}

sealed class WebhookConfigResponseWebhookOutputFormatConverter
    : JsonConverter<WebhookConfigResponseWebhookOutputFormat>
{
    public override WebhookConfigResponseWebhookOutputFormat Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "json" => WebhookConfigResponseWebhookOutputFormat.Json,
            "string" => WebhookConfigResponseWebhookOutputFormat.String,
            _ => (WebhookConfigResponseWebhookOutputFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookConfigResponseWebhookOutputFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookConfigResponseWebhookOutputFormat.Json => "json",
                WebhookConfigResponseWebhookOutputFormat.String => "string",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
