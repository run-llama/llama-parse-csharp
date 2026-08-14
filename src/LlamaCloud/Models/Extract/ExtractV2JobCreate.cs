using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;

namespace LlamaCloud.Models.Extract;

/// <summary>
/// Request to create an extraction job. Provide configuration_id or inline configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExtractV2JobCreate, ExtractV2JobCreateFromRaw>))]
public sealed record class ExtractV2JobCreate : JsonModel
{
    /// <summary>
    /// File ID or parse job ID to extract from
    /// </summary>
    public required string FileInput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_input");
        }
        init { this._rawData.Set("file_input", value); }
    }

    /// <summary>
    /// Extract configuration combining parse and extract settings.
    /// </summary>
    public ExtractConfiguration? Configuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExtractConfiguration>("configuration");
        }
        init { this._rawData.Set("configuration", value); }
    }

    /// <summary>
    /// Saved configuration ID
    /// </summary>
    public string? ConfigurationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("configuration_id");
        }
        init { this._rawData.Set("configuration_id", value); }
    }

    /// <summary>
    /// IDs of saved webhook configurations to notify for this job.
    /// </summary>
    public IReadOnlyList<string>? WebhookConfigurationIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "webhook_configuration_ids"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "webhook_configuration_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Outbound webhook endpoints to notify on job status changes
    /// </summary>
    public IReadOnlyList<ExtractV2JobCreateWebhookConfiguration>? WebhookConfigurations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ExtractV2JobCreateWebhookConfiguration>
            >("webhook_configurations");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ExtractV2JobCreateWebhookConfiguration>?>(
                "webhook_configurations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileInput;
        this.Configuration?.Validate();
        _ = this.ConfigurationID;
        _ = this.WebhookConfigurationIds;
        foreach (var item in this.WebhookConfigurations ?? [])
        {
            item.Validate();
        }
    }

    public ExtractV2JobCreate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractV2JobCreate(ExtractV2JobCreate extractV2JobCreate)
        : base(extractV2JobCreate) { }
#pragma warning restore CS8618

    public ExtractV2JobCreate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractV2JobCreate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractV2JobCreateFromRaw.FromRawUnchecked"/>
    public static ExtractV2JobCreate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExtractV2JobCreate(string fileInput)
        : this()
    {
        this.FileInput = fileInput;
    }
}

class ExtractV2JobCreateFromRaw : IFromRawJson<ExtractV2JobCreate>
{
    /// <inheritdoc/>
    public ExtractV2JobCreate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExtractV2JobCreate.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single outbound webhook endpoint.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ExtractV2JobCreateWebhookConfiguration,
        ExtractV2JobCreateWebhookConfigurationFromRaw
    >)
)]
public sealed record class ExtractV2JobCreateWebhookConfiguration : JsonModel
{
    /// <summary>
    /// Events to subscribe to (e.g. 'parse.success', 'extract.error'). If null, all
    /// events are delivered.
    /// </summary>
    public IReadOnlyList<
        ApiEnum<string, ExtractV2JobCreateWebhookConfigurationWebhookEvent>
    >? WebhookEvents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, ExtractV2JobCreateWebhookConfigurationWebhookEvent>>
            >("webhook_events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<
                ApiEnum<string, ExtractV2JobCreateWebhookConfigurationWebhookEvent>
            >?>("webhook_events", value == null ? null : ImmutableArray.ToImmutableArray(value));
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

    public ExtractV2JobCreateWebhookConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractV2JobCreateWebhookConfiguration(
        ExtractV2JobCreateWebhookConfiguration extractV2JobCreateWebhookConfiguration
    )
        : base(extractV2JobCreateWebhookConfiguration) { }
#pragma warning restore CS8618

    public ExtractV2JobCreateWebhookConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractV2JobCreateWebhookConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractV2JobCreateWebhookConfigurationFromRaw.FromRawUnchecked"/>
    public static ExtractV2JobCreateWebhookConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractV2JobCreateWebhookConfigurationFromRaw
    : IFromRawJson<ExtractV2JobCreateWebhookConfiguration>
{
    /// <inheritdoc/>
    public ExtractV2JobCreateWebhookConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtractV2JobCreateWebhookConfiguration.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ExtractV2JobCreateWebhookConfigurationWebhookEventConverter))]
public enum ExtractV2JobCreateWebhookConfigurationWebhookEvent
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

sealed class ExtractV2JobCreateWebhookConfigurationWebhookEventConverter
    : JsonConverter<ExtractV2JobCreateWebhookConfigurationWebhookEvent>
{
    public override ExtractV2JobCreateWebhookConfigurationWebhookEvent Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "batch.cancelled" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchCancelled,
            "batch.error" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchError,
            "batch.pending" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchPending,
            "batch.running" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchRunning,
            "batch.success" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchSuccess,
            "classify.cancelled" =>
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyCancelled,
            "classify.error" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyError,
            "classify.partial_success" =>
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyPartialSuccess,
            "classify.pending" =>
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyPending,
            "classify.running" =>
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyRunning,
            "classify.success" =>
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifySuccess,
            "extract.cancelled" =>
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractCancelled,
            "extract.error" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractError,
            "extract.partial_success" =>
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractPartialSuccess,
            "extract.pending" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractPending,
            "extract.success" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractSuccess,
            "parse.cancelled" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseCancelled,
            "parse.error" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseError,
            "parse.partial_success" =>
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParsePartialSuccess,
            "parse.pending" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParsePending,
            "parse.running" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseRunning,
            "parse.success" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseSuccess,
            "sheets.cancelled" =>
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsCancelled,
            "sheets.error" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsError,
            "sheets.partial_success" =>
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsPartialSuccess,
            "sheets.pending" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsPending,
            "sheets.success" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsSuccess,
            "split.cancelled" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitCancelled,
            "split.error" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitError,
            "split.pending" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitPending,
            "split.processing" =>
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitProcessing,
            "split.success" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitSuccess,
            "unmapped_event" => ExtractV2JobCreateWebhookConfigurationWebhookEvent.UnmappedEvent,
            _ => (ExtractV2JobCreateWebhookConfigurationWebhookEvent)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractV2JobCreateWebhookConfigurationWebhookEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchCancelled =>
                    "batch.cancelled",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchError => "batch.error",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchPending => "batch.pending",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchRunning => "batch.running",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchSuccess => "batch.success",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyCancelled =>
                    "classify.cancelled",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyError =>
                    "classify.error",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyPartialSuccess =>
                    "classify.partial_success",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyPending =>
                    "classify.pending",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyRunning =>
                    "classify.running",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifySuccess =>
                    "classify.success",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractCancelled =>
                    "extract.cancelled",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractError => "extract.error",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractPartialSuccess =>
                    "extract.partial_success",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractPending =>
                    "extract.pending",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractSuccess =>
                    "extract.success",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseCancelled =>
                    "parse.cancelled",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseError => "parse.error",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParsePartialSuccess =>
                    "parse.partial_success",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParsePending => "parse.pending",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseRunning => "parse.running",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseSuccess => "parse.success",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsCancelled =>
                    "sheets.cancelled",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsError => "sheets.error",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsPartialSuccess =>
                    "sheets.partial_success",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsPending =>
                    "sheets.pending",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsSuccess =>
                    "sheets.success",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitCancelled =>
                    "split.cancelled",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitError => "split.error",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitPending => "split.pending",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitProcessing =>
                    "split.processing",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitSuccess => "split.success",
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.UnmappedEvent =>
                    "unmapped_event",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
