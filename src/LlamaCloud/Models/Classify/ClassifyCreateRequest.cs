using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;

namespace LlamaCloud.Models.Classify;

/// <summary>
/// Request to create a classify job.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ClassifyCreateRequest, ClassifyCreateRequestFromRaw>))]
public sealed record class ClassifyCreateRequest : JsonModel
{
    /// <summary>
    /// Configuration for a classify job.
    /// </summary>
    public ClassifyConfiguration? Configuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ClassifyConfiguration>("configuration");
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
    /// Deprecated: use file_input instead
    /// </summary>
    [Obsolete("deprecated")]
    public string? FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <summary>
    /// File ID or parse job ID to classify
    /// </summary>
    public string? FileInput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("file_input");
        }
        init { this._rawData.Set("file_input", value); }
    }

    /// <summary>
    /// Deprecated: use file_input instead
    /// </summary>
    [Obsolete("deprecated")]
    public string? ParseJobID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parse_job_id");
        }
        init { this._rawData.Set("parse_job_id", value); }
    }

    /// <summary>
    /// Idempotency key scoped to the project. Reusing a key returns the original
    /// job; the new request body is ignored.
    /// </summary>
    public string? TransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transaction_id");
        }
        init { this._rawData.Set("transaction_id", value); }
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
    public IReadOnlyList<ClassifyCreateRequestWebhookConfiguration>? WebhookConfigurations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ClassifyCreateRequestWebhookConfiguration>
            >("webhook_configurations");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ClassifyCreateRequestWebhookConfiguration>?>(
                "webhook_configurations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Configuration?.Validate();
        _ = this.ConfigurationID;
        _ = this.FileID;
        _ = this.FileInput;
        _ = this.ParseJobID;
        _ = this.TransactionID;
        _ = this.WebhookConfigurationIds;
        foreach (var item in this.WebhookConfigurations ?? [])
        {
            item.Validate();
        }
    }

    public ClassifyCreateRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClassifyCreateRequest(ClassifyCreateRequest classifyCreateRequest)
        : base(classifyCreateRequest) { }
#pragma warning restore CS8618

    public ClassifyCreateRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClassifyCreateRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClassifyCreateRequestFromRaw.FromRawUnchecked"/>
    public static ClassifyCreateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClassifyCreateRequestFromRaw : IFromRawJson<ClassifyCreateRequest>
{
    /// <inheritdoc/>
    public ClassifyCreateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClassifyCreateRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single outbound webhook endpoint.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ClassifyCreateRequestWebhookConfiguration,
        ClassifyCreateRequestWebhookConfigurationFromRaw
    >)
)]
public sealed record class ClassifyCreateRequestWebhookConfiguration : JsonModel
{
    /// <summary>
    /// Events to subscribe to (e.g. 'parse.success', 'extract.error'). If null, all
    /// events are delivered.
    /// </summary>
    public IReadOnlyList<
        ApiEnum<string, ClassifyCreateRequestWebhookConfigurationWebhookEvent>
    >? WebhookEvents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<
                    ApiEnum<string, ClassifyCreateRequestWebhookConfigurationWebhookEvent>
                >
            >("webhook_events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<
                ApiEnum<string, ClassifyCreateRequestWebhookConfigurationWebhookEvent>
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

    public ClassifyCreateRequestWebhookConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClassifyCreateRequestWebhookConfiguration(
        ClassifyCreateRequestWebhookConfiguration classifyCreateRequestWebhookConfiguration
    )
        : base(classifyCreateRequestWebhookConfiguration) { }
#pragma warning restore CS8618

    public ClassifyCreateRequestWebhookConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClassifyCreateRequestWebhookConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClassifyCreateRequestWebhookConfigurationFromRaw.FromRawUnchecked"/>
    public static ClassifyCreateRequestWebhookConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClassifyCreateRequestWebhookConfigurationFromRaw
    : IFromRawJson<ClassifyCreateRequestWebhookConfiguration>
{
    /// <inheritdoc/>
    public ClassifyCreateRequestWebhookConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClassifyCreateRequestWebhookConfiguration.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ClassifyCreateRequestWebhookConfigurationWebhookEventConverter))]
public enum ClassifyCreateRequestWebhookConfigurationWebhookEvent
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

sealed class ClassifyCreateRequestWebhookConfigurationWebhookEventConverter
    : JsonConverter<ClassifyCreateRequestWebhookConfigurationWebhookEvent>
{
    public override ClassifyCreateRequestWebhookConfigurationWebhookEvent Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "batch.cancelled" =>
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchCancelled,
            "batch.error" => ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchError,
            "batch.pending" => ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchPending,
            "batch.running" => ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchRunning,
            "batch.success" => ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchSuccess,
            "classify.cancelled" =>
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyCancelled,
            "classify.error" => ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyError,
            "classify.partial_success" =>
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyPartialSuccess,
            "classify.pending" =>
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyPending,
            "classify.running" =>
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyRunning,
            "classify.success" =>
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifySuccess,
            "extract.cancelled" =>
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractCancelled,
            "extract.error" => ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractError,
            "extract.partial_success" =>
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractPartialSuccess,
            "extract.pending" =>
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractPending,
            "extract.success" =>
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractSuccess,
            "parse.cancelled" =>
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseCancelled,
            "parse.error" => ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseError,
            "parse.partial_success" =>
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParsePartialSuccess,
            "parse.pending" => ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParsePending,
            "parse.running" => ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseRunning,
            "parse.success" => ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseSuccess,
            "sheets.cancelled" =>
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsCancelled,
            "sheets.error" => ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsError,
            "sheets.partial_success" =>
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsPartialSuccess,
            "sheets.pending" => ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsPending,
            "sheets.success" => ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsSuccess,
            "split.cancelled" =>
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitCancelled,
            "split.error" => ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitError,
            "split.pending" => ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitPending,
            "split.processing" =>
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitProcessing,
            "split.success" => ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitSuccess,
            "unmapped_event" => ClassifyCreateRequestWebhookConfigurationWebhookEvent.UnmappedEvent,
            _ => (ClassifyCreateRequestWebhookConfigurationWebhookEvent)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClassifyCreateRequestWebhookConfigurationWebhookEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchCancelled =>
                    "batch.cancelled",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchError => "batch.error",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchPending =>
                    "batch.pending",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchRunning =>
                    "batch.running",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchSuccess =>
                    "batch.success",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyCancelled =>
                    "classify.cancelled",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyError =>
                    "classify.error",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyPartialSuccess =>
                    "classify.partial_success",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyPending =>
                    "classify.pending",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyRunning =>
                    "classify.running",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifySuccess =>
                    "classify.success",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractCancelled =>
                    "extract.cancelled",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractError =>
                    "extract.error",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractPartialSuccess =>
                    "extract.partial_success",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractPending =>
                    "extract.pending",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractSuccess =>
                    "extract.success",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseCancelled =>
                    "parse.cancelled",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseError => "parse.error",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParsePartialSuccess =>
                    "parse.partial_success",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParsePending =>
                    "parse.pending",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseRunning =>
                    "parse.running",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseSuccess =>
                    "parse.success",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsCancelled =>
                    "sheets.cancelled",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsError => "sheets.error",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsPartialSuccess =>
                    "sheets.partial_success",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsPending =>
                    "sheets.pending",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsSuccess =>
                    "sheets.success",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitCancelled =>
                    "split.cancelled",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitError => "split.error",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitPending =>
                    "split.pending",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitProcessing =>
                    "split.processing",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitSuccess =>
                    "split.success",
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.UnmappedEvent =>
                    "unmapped_event",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
