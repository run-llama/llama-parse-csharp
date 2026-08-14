using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Batches;

/// <summary>
/// A top-level batch.
///
/// <para>Example:     {         "id": "bat-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
///         "project_id": "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",         "source_directory_id":
/// "dir-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",         "config": {             "job":
/// {                 "type": "parse_v2",                 "configuration_id": "cfg-PARSE_AGENTIC"
///             }         },         "status": "COMPLETED",         "results": [
///             {                 "source_directory_file_id": "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
///                 "job_reference": {                     "type": "parse_v2",
///                  "id": "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee"
///     },                 "error_message": null             }         ]     }</para>
///
/// <para>Batch-level ``FAILED`` means the orchestration failed and cannot provide
/// a reliable per-file result set. ``results`` is only populated when explicitly
/// requested with ``expand=results`` and may be ``null`` while a batch is still running.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchCreateResponse, BatchCreateResponseFromRaw>))]
public sealed record class BatchCreateResponse : JsonModel
{
    /// <summary>
    /// Unique identifier
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
    /// Batch configuration snapshot.
    /// </summary>
    public required BatchCreateResponseConfig Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BatchCreateResponseConfig>("config");
        }
        init { this._rawData.Set("config", value); }
    }

    /// <summary>
    /// Project this batch belongs to.
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
    /// Directory being processed.
    /// </summary>
    public required string SourceDirectoryID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source_directory_id");
        }
        init { this._rawData.Set("source_directory_id", value); }
    }

    /// <summary>
    /// Current batch status.
    /// </summary>
    public required ApiEnum<string, BatchCreateResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BatchCreateResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Creation datetime
    /// </summary>
    public System::DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Expanded per-file result mappings. Null unless requested with expand=results,
    /// or while the batch is still running.
    /// </summary>
    public IReadOnlyList<Result>? Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Result>>("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Result>?>(
                "results",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Update datetime
    /// </summary>
    public System::DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Config.Validate();
        _ = this.ProjectID;
        _ = this.SourceDirectoryID;
        this.Status.Validate();
        _ = this.CreatedAt;
        foreach (var item in this.Results ?? [])
        {
            item.Validate();
        }
        _ = this.UpdatedAt;
    }

    public BatchCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchCreateResponse(BatchCreateResponse batchCreateResponse)
        : base(batchCreateResponse) { }
#pragma warning restore CS8618

    public BatchCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchCreateResponseFromRaw.FromRawUnchecked"/>
    public static BatchCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchCreateResponseFromRaw : IFromRawJson<BatchCreateResponse>
{
    /// <inheritdoc/>
    public BatchCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Batch configuration snapshot.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BatchCreateResponseConfig, BatchCreateResponseConfigFromRaw>)
)]
public sealed record class BatchCreateResponseConfig : JsonModel
{
    /// <summary>
    /// Job to create for each file in the source directory.
    /// </summary>
    public required BatchCreateResponseConfigJob Job
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BatchCreateResponseConfigJob>("job");
        }
        init { this._rawData.Set("job", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Job.Validate();
    }

    public BatchCreateResponseConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchCreateResponseConfig(BatchCreateResponseConfig batchCreateResponseConfig)
        : base(batchCreateResponseConfig) { }
#pragma warning restore CS8618

    public BatchCreateResponseConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchCreateResponseConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchCreateResponseConfigFromRaw.FromRawUnchecked"/>
    public static BatchCreateResponseConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BatchCreateResponseConfig(BatchCreateResponseConfigJob job)
        : this()
    {
        this.Job = job;
    }
}

class BatchCreateResponseConfigFromRaw : IFromRawJson<BatchCreateResponseConfig>
{
    /// <inheritdoc/>
    public BatchCreateResponseConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BatchCreateResponseConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Job to create for each file in the source directory.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BatchCreateResponseConfigJob, BatchCreateResponseConfigJobFromRaw>)
)]
public sealed record class BatchCreateResponseConfigJob : JsonModel
{
    /// <summary>
    /// Product configuration ID or built-in preset ID matching the job type.
    /// </summary>
    public required string ConfigurationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("configuration_id");
        }
        init { this._rawData.Set("configuration_id", value); }
    }

    /// <summary>
    /// Product job type to run for each source directory file.
    /// </summary>
    public required ApiEnum<string, BatchCreateResponseConfigJobType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BatchCreateResponseConfigJobType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConfigurationID;
        this.Type.Validate();
    }

    public BatchCreateResponseConfigJob() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchCreateResponseConfigJob(BatchCreateResponseConfigJob batchCreateResponseConfigJob)
        : base(batchCreateResponseConfigJob) { }
#pragma warning restore CS8618

    public BatchCreateResponseConfigJob(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchCreateResponseConfigJob(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchCreateResponseConfigJobFromRaw.FromRawUnchecked"/>
    public static BatchCreateResponseConfigJob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchCreateResponseConfigJobFromRaw : IFromRawJson<BatchCreateResponseConfigJob>
{
    /// <inheritdoc/>
    public BatchCreateResponseConfigJob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BatchCreateResponseConfigJob.FromRawUnchecked(rawData);
}

/// <summary>
/// Product job type to run for each source directory file.
/// </summary>
[JsonConverter(typeof(BatchCreateResponseConfigJobTypeConverter))]
public enum BatchCreateResponseConfigJobType
{
    ParseV2,
    ExtractV2,
}

sealed class BatchCreateResponseConfigJobTypeConverter
    : JsonConverter<BatchCreateResponseConfigJobType>
{
    public override BatchCreateResponseConfigJobType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "parse_v2" => BatchCreateResponseConfigJobType.ParseV2,
            "extract_v2" => BatchCreateResponseConfigJobType.ExtractV2,
            _ => (BatchCreateResponseConfigJobType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BatchCreateResponseConfigJobType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BatchCreateResponseConfigJobType.ParseV2 => "parse_v2",
                BatchCreateResponseConfigJobType.ExtractV2 => "extract_v2",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Current batch status.
/// </summary>
[JsonConverter(typeof(BatchCreateResponseStatusConverter))]
public enum BatchCreateResponseStatus
{
    Cancelled,
    Completed,
    Failed,
    Pending,
    Running,
    Throttled,
}

sealed class BatchCreateResponseStatusConverter : JsonConverter<BatchCreateResponseStatus>
{
    public override BatchCreateResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CANCELLED" => BatchCreateResponseStatus.Cancelled,
            "COMPLETED" => BatchCreateResponseStatus.Completed,
            "FAILED" => BatchCreateResponseStatus.Failed,
            "PENDING" => BatchCreateResponseStatus.Pending,
            "RUNNING" => BatchCreateResponseStatus.Running,
            "THROTTLED" => BatchCreateResponseStatus.Throttled,
            _ => (BatchCreateResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BatchCreateResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BatchCreateResponseStatus.Cancelled => "CANCELLED",
                BatchCreateResponseStatus.Completed => "COMPLETED",
                BatchCreateResponseStatus.Failed => "FAILED",
                BatchCreateResponseStatus.Pending => "PENDING",
                BatchCreateResponseStatus.Running => "RUNNING",
                BatchCreateResponseStatus.Throttled => "THROTTLED",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Result projection for one source directory file in a batch.
///
/// <para>Example:     {         "source_directory_file_id": "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
///         "job_reference": {             "type": "parse_v2",             "id": "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee"
///         },         "error_message": null     }</para>
///
/// <para>This is a projection of directory-sync state, not a separate child resource
/// that callers need to create. The source directory file ID is the stable correlation
/// key. Underlying job progress and failures should be resolved through the referenced
/// product job endpoint.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    /// <summary>
    /// Source directory file processed by this batch.
    /// </summary>
    public required string SourceDirectoryFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source_directory_file_id");
        }
        init { this._rawData.Set("source_directory_file_id", value); }
    }

    /// <summary>
    /// Batch-level mapping error if the system could not create or associate a job
    /// for this source file.
    /// </summary>
    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_message");
        }
        init { this._rawData.Set("error_message", value); }
    }

    /// <summary>
    /// Reference to a job produced by a batch.
    ///
    /// <para>Example:     {         "type": "parse_v2",         "id": "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee"
    ///     }</para>
    /// </summary>
    public JobReference? JobReference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JobReference>("job_reference");
        }
        init { this._rawData.Set("job_reference", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SourceDirectoryFileID;
        _ = this.ErrorMessage;
        this.JobReference?.Validate();
    }

    public Result() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result(Result result)
        : base(result) { }
#pragma warning restore CS8618

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Result(string sourceDirectoryFileID)
        : this()
    {
        this.SourceDirectoryFileID = sourceDirectoryFileID;
    }
}

class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to a job produced by a batch.
///
/// <para>Example:     {         "type": "parse_v2",         "id": "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee"
///     }</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JobReference, JobReferenceFromRaw>))]
public sealed record class JobReference : JsonModel
{
    /// <summary>
    /// Job ID, such as a parse job ID.
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
    /// Type of job produced for the file.
    /// </summary>
    public required ApiEnum<string, JobReferenceType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JobReferenceType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
    }

    public JobReference() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobReference(JobReference jobReference)
        : base(jobReference) { }
#pragma warning restore CS8618

    public JobReference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JobReference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JobReferenceFromRaw.FromRawUnchecked"/>
    public static JobReference FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JobReferenceFromRaw : IFromRawJson<JobReference>
{
    /// <inheritdoc/>
    public JobReference FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JobReference.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of job produced for the file.
/// </summary>
[JsonConverter(typeof(JobReferenceTypeConverter))]
public enum JobReferenceType
{
    ParseV2,
    ExtractV2,
}

sealed class JobReferenceTypeConverter : JsonConverter<JobReferenceType>
{
    public override JobReferenceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "parse_v2" => JobReferenceType.ParseV2,
            "extract_v2" => JobReferenceType.ExtractV2,
            _ => (JobReferenceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JobReferenceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JobReferenceType.ParseV2 => "parse_v2",
                JobReferenceType.ExtractV2 => "extract_v2",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
