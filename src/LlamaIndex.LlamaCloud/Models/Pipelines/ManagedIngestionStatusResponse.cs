using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Pipelines;

[JsonConverter(
    typeof(JsonModelConverter<
        ManagedIngestionStatusResponse,
        ManagedIngestionStatusResponseFromRaw
    >)
)]
public sealed record class ManagedIngestionStatusResponse : JsonModel
{
    /// <summary>
    /// Status of the ingestion.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Date of the deployment.
    /// </summary>
    public System::DateTimeOffset? DeploymentDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("deployment_date");
        }
        init { this._rawData.Set("deployment_date", value); }
    }

    /// <summary>
    /// When the status is effective
    /// </summary>
    public System::DateTimeOffset? EffectiveAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("effective_at");
        }
        init { this._rawData.Set("effective_at", value); }
    }

    /// <summary>
    /// List of errors that occurred during ingestion.
    /// </summary>
    public IReadOnlyList<Error>? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Error>>("error");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Error>?>(
                "error",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ID of the latest job.
    /// </summary>
    public string? JobID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("job_id");
        }
        init { this._rawData.Set("job_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
        _ = this.DeploymentDate;
        _ = this.EffectiveAt;
        foreach (var item in this.Error ?? [])
        {
            item.Validate();
        }
        _ = this.JobID;
    }

    public ManagedIngestionStatusResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ManagedIngestionStatusResponse(
        ManagedIngestionStatusResponse managedIngestionStatusResponse
    )
        : base(managedIngestionStatusResponse) { }
#pragma warning restore CS8618

    public ManagedIngestionStatusResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ManagedIngestionStatusResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ManagedIngestionStatusResponseFromRaw.FromRawUnchecked"/>
    public static ManagedIngestionStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ManagedIngestionStatusResponse(ApiEnum<string, Status> status)
        : this()
    {
        this.Status = status;
    }
}

class ManagedIngestionStatusResponseFromRaw : IFromRawJson<ManagedIngestionStatusResponse>
{
    /// <inheritdoc/>
    public ManagedIngestionStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ManagedIngestionStatusResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of the ingestion.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Cancelled,
    Error,
    InProgress,
    NotStarted,
    PartialSuccess,
    Success,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CANCELLED" => Status.Cancelled,
            "ERROR" => Status.Error,
            "IN_PROGRESS" => Status.InProgress,
            "NOT_STARTED" => Status.NotStarted,
            "PARTIAL_SUCCESS" => Status.PartialSuccess,
            "SUCCESS" => Status.Success,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Cancelled => "CANCELLED",
                Status.Error => "ERROR",
                Status.InProgress => "IN_PROGRESS",
                Status.NotStarted => "NOT_STARTED",
                Status.PartialSuccess => "PARTIAL_SUCCESS",
                Status.Success => "SUCCESS",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Error, ErrorFromRaw>))]
public sealed record class Error : JsonModel
{
    /// <summary>
    /// ID of the job that failed.
    /// </summary>
    public required string JobID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("job_id");
        }
        init { this._rawData.Set("job_id", value); }
    }

    /// <summary>
    /// List of errors that occurred during ingestion.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <summary>
    /// Name of the job that failed.
    /// </summary>
    public required ApiEnum<string, Step> Step
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Step>>("step");
        }
        init { this._rawData.Set("step", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.JobID;
        _ = this.Message;
        this.Step.Validate();
    }

    public Error() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Error(Error error)
        : base(error) { }
#pragma warning restore CS8618

    public Error(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Error(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ErrorFromRaw.FromRawUnchecked"/>
    public static Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ErrorFromRaw : IFromRawJson<Error>
{
    /// <inheritdoc/>
    public Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Error.FromRawUnchecked(rawData);
}

/// <summary>
/// Name of the job that failed.
/// </summary>
[JsonConverter(typeof(StepConverter))]
public enum Step
{
    DataSource,
    FileUpdater,
    Ingestion,
    ManagedIngestion,
    MetadataUpdate,
    Parse,
    Transform,
}

sealed class StepConverter : JsonConverter<Step>
{
    public override Step Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DATA_SOURCE" => Step.DataSource,
            "FILE_UPDATER" => Step.FileUpdater,
            "INGESTION" => Step.Ingestion,
            "MANAGED_INGESTION" => Step.ManagedIngestion,
            "METADATA_UPDATE" => Step.MetadataUpdate,
            "PARSE" => Step.Parse,
            "TRANSFORM" => Step.Transform,
            _ => (Step)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Step value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Step.DataSource => "DATA_SOURCE",
                Step.FileUpdater => "FILE_UPDATER",
                Step.Ingestion => "INGESTION",
                Step.ManagedIngestion => "MANAGED_INGESTION",
                Step.MetadataUpdate => "METADATA_UPDATE",
                Step.Parse => "PARSE",
                Step.Transform => "TRANSFORM",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
