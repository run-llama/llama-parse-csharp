using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Files;

namespace LlamaIndex.LlamaCloud.Models.Beta.Sheets;

/// <summary>
/// A spreadsheet parsing job.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SheetsJob, SheetsJobFromRaw>))]
public sealed record class SheetsJob : JsonModel
{
    /// <summary>
    /// The ID of the job
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
    /// Configuration applied to the parsing job (inline or resolved from a saved preset).
    /// </summary>
    public required SheetsParsingConfig Configuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SheetsParsingConfig>("configuration");
        }
        init { this._rawData.Set("configuration", value); }
    }

    /// <summary>
    /// When the job was created
    /// </summary>
    public required string CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The ID of the input file
    /// </summary>
    public required string? FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <summary>
    /// The ID of the project
    /// </summary>
    public required string ProjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("project_id");
        }
        init { this._rawData.Set("project_id", value); }
    }

    /// <summary>
    /// The status of the parsing job
    /// </summary>
    public required ApiEnum<string, SheetsJobStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SheetsJobStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// When the job was last updated
    /// </summary>
    public required string UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// The ID of the user
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <summary>
    /// Configuration for spreadsheet parsing and region extraction
    /// </summary>
    [Obsolete("deprecated")]
    public SheetsParsingConfig? Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SheetsParsingConfig>("config");
        }
        init { this._rawData.Set("config", value); }
    }

    /// <summary>
    /// The saved product configuration ID used at create time, if any.
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
    /// Any errors encountered
    /// </summary>
    public IReadOnlyList<string>? Errors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("errors");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "errors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Schema for a file.
    /// </summary>
    [Obsolete("deprecated")]
    public File? File
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<File>("file");
        }
        init { this._rawData.Set("file", value); }
    }

    /// <summary>
    /// Per-status entry timestamps. Returned only when requested via `?expand=metadata_state_transitions`.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? MetadataStateTransitions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata_state_transitions"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata_state_transitions",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Job-time parameters such as webhook configurations.
    /// </summary>
    public Parameters? Parameters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Parameters>("parameters");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("parameters", value);
        }
    }

    /// <summary>
    /// All extracted regions (populated when job is complete)
    /// </summary>
    public IReadOnlyList<Region>? Regions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Region>>("regions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Region>?>(
                "regions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether the job completed successfully
    /// </summary>
    public bool? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <summary>
    /// Metadata for each processed worksheet (populated when job is complete)
    /// </summary>
    public IReadOnlyList<WorksheetMetadata>? WorksheetMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WorksheetMetadata>>(
                "worksheet_metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<WorksheetMetadata>?>(
                "worksheet_metadata",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Configuration.Validate();
        _ = this.CreatedAt;
        _ = this.FileID;
        _ = this.ProjectID;
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.UserID;
        this.Config?.Validate();
        _ = this.ConfigurationID;
        _ = this.Errors;
        this.File?.Validate();
        _ = this.MetadataStateTransitions;
        this.Parameters?.Validate();
        foreach (var item in this.Regions ?? [])
        {
            item.Validate();
        }
        _ = this.Success;
        foreach (var item in this.WorksheetMetadata ?? [])
        {
            item.Validate();
        }
    }

    public SheetsJob() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SheetsJob(SheetsJob sheetsJob)
        : base(sheetsJob) { }
#pragma warning restore CS8618

    public SheetsJob(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SheetsJob(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SheetsJobFromRaw.FromRawUnchecked"/>
    public static SheetsJob FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SheetsJobFromRaw : IFromRawJson<SheetsJob>
{
    /// <inheritdoc/>
    public SheetsJob FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SheetsJob.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the parsing job
/// </summary>
[JsonConverter(typeof(SheetsJobStatusConverter))]
public enum SheetsJobStatus
{
    Cancelled,
    Error,
    PartialSuccess,
    Pending,
    Success,
}

sealed class SheetsJobStatusConverter : JsonConverter<SheetsJobStatus>
{
    public override SheetsJobStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CANCELLED" => SheetsJobStatus.Cancelled,
            "ERROR" => SheetsJobStatus.Error,
            "PARTIAL_SUCCESS" => SheetsJobStatus.PartialSuccess,
            "PENDING" => SheetsJobStatus.Pending,
            "SUCCESS" => SheetsJobStatus.Success,
            _ => (SheetsJobStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SheetsJobStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SheetsJobStatus.Cancelled => "CANCELLED",
                SheetsJobStatus.Error => "ERROR",
                SheetsJobStatus.PartialSuccess => "PARTIAL_SUCCESS",
                SheetsJobStatus.Pending => "PENDING",
                SheetsJobStatus.Success => "SUCCESS",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Job-time parameters such as webhook configurations.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Parameters, ParametersFromRaw>))]
public sealed record class Parameters : JsonModel
{
    /// <summary>
    /// Webhook configurations for job status notifications.
    /// </summary>
    public IReadOnlyList<ParametersWebhookConfiguration>? WebhookConfigurations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ParametersWebhookConfiguration>>(
                "webhook_configurations"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ParametersWebhookConfiguration>?>(
                "webhook_configurations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.WebhookConfigurations ?? [])
        {
            item.Validate();
        }
    }

    public Parameters() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Parameters(Parameters parameters)
        : base(parameters) { }
#pragma warning restore CS8618

    public Parameters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Parameters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParametersFromRaw.FromRawUnchecked"/>
    public static Parameters FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParametersFromRaw : IFromRawJson<Parameters>
{
    /// <inheritdoc/>
    public Parameters FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Parameters.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single outbound webhook endpoint.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ParametersWebhookConfiguration,
        ParametersWebhookConfigurationFromRaw
    >)
)]
public sealed record class ParametersWebhookConfiguration : JsonModel
{
    /// <summary>
    /// Events to subscribe to (e.g. 'parse.success', 'extract.error'). If null, all
    /// events are delivered.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ParametersWebhookConfigurationWebhookEvent>>? WebhookEvents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, ParametersWebhookConfigurationWebhookEvent>>
            >("webhook_events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<
                ApiEnum<string, ParametersWebhookConfigurationWebhookEvent>
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

    public ParametersWebhookConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParametersWebhookConfiguration(
        ParametersWebhookConfiguration parametersWebhookConfiguration
    )
        : base(parametersWebhookConfiguration) { }
#pragma warning restore CS8618

    public ParametersWebhookConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParametersWebhookConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParametersWebhookConfigurationFromRaw.FromRawUnchecked"/>
    public static ParametersWebhookConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParametersWebhookConfigurationFromRaw : IFromRawJson<ParametersWebhookConfiguration>
{
    /// <inheritdoc/>
    public ParametersWebhookConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ParametersWebhookConfiguration.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ParametersWebhookConfigurationWebhookEventConverter))]
public enum ParametersWebhookConfigurationWebhookEvent
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

sealed class ParametersWebhookConfigurationWebhookEventConverter
    : JsonConverter<ParametersWebhookConfigurationWebhookEvent>
{
    public override ParametersWebhookConfigurationWebhookEvent Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "batch.cancelled" => ParametersWebhookConfigurationWebhookEvent.BatchCancelled,
            "batch.error" => ParametersWebhookConfigurationWebhookEvent.BatchError,
            "batch.pending" => ParametersWebhookConfigurationWebhookEvent.BatchPending,
            "batch.running" => ParametersWebhookConfigurationWebhookEvent.BatchRunning,
            "batch.success" => ParametersWebhookConfigurationWebhookEvent.BatchSuccess,
            "classify.cancelled" => ParametersWebhookConfigurationWebhookEvent.ClassifyCancelled,
            "classify.error" => ParametersWebhookConfigurationWebhookEvent.ClassifyError,
            "classify.partial_success" =>
                ParametersWebhookConfigurationWebhookEvent.ClassifyPartialSuccess,
            "classify.pending" => ParametersWebhookConfigurationWebhookEvent.ClassifyPending,
            "classify.running" => ParametersWebhookConfigurationWebhookEvent.ClassifyRunning,
            "classify.success" => ParametersWebhookConfigurationWebhookEvent.ClassifySuccess,
            "extract.cancelled" => ParametersWebhookConfigurationWebhookEvent.ExtractCancelled,
            "extract.error" => ParametersWebhookConfigurationWebhookEvent.ExtractError,
            "extract.partial_success" =>
                ParametersWebhookConfigurationWebhookEvent.ExtractPartialSuccess,
            "extract.pending" => ParametersWebhookConfigurationWebhookEvent.ExtractPending,
            "extract.success" => ParametersWebhookConfigurationWebhookEvent.ExtractSuccess,
            "parse.cancelled" => ParametersWebhookConfigurationWebhookEvent.ParseCancelled,
            "parse.error" => ParametersWebhookConfigurationWebhookEvent.ParseError,
            "parse.partial_success" =>
                ParametersWebhookConfigurationWebhookEvent.ParsePartialSuccess,
            "parse.pending" => ParametersWebhookConfigurationWebhookEvent.ParsePending,
            "parse.running" => ParametersWebhookConfigurationWebhookEvent.ParseRunning,
            "parse.success" => ParametersWebhookConfigurationWebhookEvent.ParseSuccess,
            "sheets.cancelled" => ParametersWebhookConfigurationWebhookEvent.SheetsCancelled,
            "sheets.error" => ParametersWebhookConfigurationWebhookEvent.SheetsError,
            "sheets.partial_success" =>
                ParametersWebhookConfigurationWebhookEvent.SheetsPartialSuccess,
            "sheets.pending" => ParametersWebhookConfigurationWebhookEvent.SheetsPending,
            "sheets.success" => ParametersWebhookConfigurationWebhookEvent.SheetsSuccess,
            "split.cancelled" => ParametersWebhookConfigurationWebhookEvent.SplitCancelled,
            "split.error" => ParametersWebhookConfigurationWebhookEvent.SplitError,
            "split.pending" => ParametersWebhookConfigurationWebhookEvent.SplitPending,
            "split.processing" => ParametersWebhookConfigurationWebhookEvent.SplitProcessing,
            "split.success" => ParametersWebhookConfigurationWebhookEvent.SplitSuccess,
            "unmapped_event" => ParametersWebhookConfigurationWebhookEvent.UnmappedEvent,
            _ => (ParametersWebhookConfigurationWebhookEvent)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ParametersWebhookConfigurationWebhookEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ParametersWebhookConfigurationWebhookEvent.BatchCancelled => "batch.cancelled",
                ParametersWebhookConfigurationWebhookEvent.BatchError => "batch.error",
                ParametersWebhookConfigurationWebhookEvent.BatchPending => "batch.pending",
                ParametersWebhookConfigurationWebhookEvent.BatchRunning => "batch.running",
                ParametersWebhookConfigurationWebhookEvent.BatchSuccess => "batch.success",
                ParametersWebhookConfigurationWebhookEvent.ClassifyCancelled =>
                    "classify.cancelled",
                ParametersWebhookConfigurationWebhookEvent.ClassifyError => "classify.error",
                ParametersWebhookConfigurationWebhookEvent.ClassifyPartialSuccess =>
                    "classify.partial_success",
                ParametersWebhookConfigurationWebhookEvent.ClassifyPending => "classify.pending",
                ParametersWebhookConfigurationWebhookEvent.ClassifyRunning => "classify.running",
                ParametersWebhookConfigurationWebhookEvent.ClassifySuccess => "classify.success",
                ParametersWebhookConfigurationWebhookEvent.ExtractCancelled => "extract.cancelled",
                ParametersWebhookConfigurationWebhookEvent.ExtractError => "extract.error",
                ParametersWebhookConfigurationWebhookEvent.ExtractPartialSuccess =>
                    "extract.partial_success",
                ParametersWebhookConfigurationWebhookEvent.ExtractPending => "extract.pending",
                ParametersWebhookConfigurationWebhookEvent.ExtractSuccess => "extract.success",
                ParametersWebhookConfigurationWebhookEvent.ParseCancelled => "parse.cancelled",
                ParametersWebhookConfigurationWebhookEvent.ParseError => "parse.error",
                ParametersWebhookConfigurationWebhookEvent.ParsePartialSuccess =>
                    "parse.partial_success",
                ParametersWebhookConfigurationWebhookEvent.ParsePending => "parse.pending",
                ParametersWebhookConfigurationWebhookEvent.ParseRunning => "parse.running",
                ParametersWebhookConfigurationWebhookEvent.ParseSuccess => "parse.success",
                ParametersWebhookConfigurationWebhookEvent.SheetsCancelled => "sheets.cancelled",
                ParametersWebhookConfigurationWebhookEvent.SheetsError => "sheets.error",
                ParametersWebhookConfigurationWebhookEvent.SheetsPartialSuccess =>
                    "sheets.partial_success",
                ParametersWebhookConfigurationWebhookEvent.SheetsPending => "sheets.pending",
                ParametersWebhookConfigurationWebhookEvent.SheetsSuccess => "sheets.success",
                ParametersWebhookConfigurationWebhookEvent.SplitCancelled => "split.cancelled",
                ParametersWebhookConfigurationWebhookEvent.SplitError => "split.error",
                ParametersWebhookConfigurationWebhookEvent.SplitPending => "split.pending",
                ParametersWebhookConfigurationWebhookEvent.SplitProcessing => "split.processing",
                ParametersWebhookConfigurationWebhookEvent.SplitSuccess => "split.success",
                ParametersWebhookConfigurationWebhookEvent.UnmappedEvent => "unmapped_event",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A summary of a single extracted region from a spreadsheet
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Region, RegionFromRaw>))]
public sealed record class Region : JsonModel
{
    /// <summary>
    /// Location of the region in the spreadsheet
    /// </summary>
    public required string Location
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("location");
        }
        init { this._rawData.Set("location", value); }
    }

    /// <summary>
    /// Type of the extracted region
    /// </summary>
    public required string RegionType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("region_type");
        }
        init { this._rawData.Set("region_type", value); }
    }

    /// <summary>
    /// Worksheet name where region was found
    /// </summary>
    public required string SheetName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sheet_name");
        }
        init { this._rawData.Set("sheet_name", value); }
    }

    /// <summary>
    /// Generated description for the region
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Unique identifier for this region within the file
    /// </summary>
    public string? RegionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("region_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("region_id", value);
        }
    }

    /// <summary>
    /// Generated title for the region
    /// </summary>
    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Location;
        _ = this.RegionType;
        _ = this.SheetName;
        _ = this.Description;
        _ = this.RegionID;
        _ = this.Title;
    }

    public Region() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Region(Region region)
        : base(region) { }
#pragma warning restore CS8618

    public Region(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Region(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RegionFromRaw.FromRawUnchecked"/>
    public static Region FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RegionFromRaw : IFromRawJson<Region>
{
    /// <inheritdoc/>
    public Region FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Region.FromRawUnchecked(rawData);
}

/// <summary>
/// Metadata about a worksheet in a spreadsheet
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WorksheetMetadata, WorksheetMetadataFromRaw>))]
public sealed record class WorksheetMetadata : JsonModel
{
    /// <summary>
    /// Name of the worksheet
    /// </summary>
    public required string SheetName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sheet_name");
        }
        init { this._rawData.Set("sheet_name", value); }
    }

    /// <summary>
    /// Generated description of the worksheet
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Generated title for the worksheet
    /// </summary>
    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SheetName;
        _ = this.Description;
        _ = this.Title;
    }

    public WorksheetMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorksheetMetadata(WorksheetMetadata worksheetMetadata)
        : base(worksheetMetadata) { }
#pragma warning restore CS8618

    public WorksheetMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorksheetMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorksheetMetadataFromRaw.FromRawUnchecked"/>
    public static WorksheetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WorksheetMetadata(string sheetName)
        : this()
    {
        this.SheetName = sheetName;
    }
}

class WorksheetMetadataFromRaw : IFromRawJson<WorksheetMetadata>
{
    /// <inheritdoc/>
    public WorksheetMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WorksheetMetadata.FromRawUnchecked(rawData);
}
