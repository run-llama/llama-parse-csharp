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
[JsonConverter(typeof(JsonModelConverter<BatchListResponse, BatchListResponseFromRaw>))]
public sealed record class BatchListResponse : JsonModel
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
    public required BatchListResponseConfig Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BatchListResponseConfig>("config");
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
    public required ApiEnum<string, BatchListResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BatchListResponseStatus>>(
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
    public IReadOnlyList<BatchListResponseResult>? Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BatchListResponseResult>>(
                "results"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BatchListResponseResult>?>(
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

    public BatchListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchListResponse(BatchListResponse batchListResponse)
        : base(batchListResponse) { }
#pragma warning restore CS8618

    public BatchListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchListResponseFromRaw.FromRawUnchecked"/>
    public static BatchListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchListResponseFromRaw : IFromRawJson<BatchListResponse>
{
    /// <inheritdoc/>
    public BatchListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Batch configuration snapshot.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchListResponseConfig, BatchListResponseConfigFromRaw>))]
public sealed record class BatchListResponseConfig : JsonModel
{
    /// <summary>
    /// Job to create for each file in the source directory.
    /// </summary>
    public required BatchListResponseConfigJob Job
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BatchListResponseConfigJob>("job");
        }
        init { this._rawData.Set("job", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Job.Validate();
    }

    public BatchListResponseConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchListResponseConfig(BatchListResponseConfig batchListResponseConfig)
        : base(batchListResponseConfig) { }
#pragma warning restore CS8618

    public BatchListResponseConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchListResponseConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchListResponseConfigFromRaw.FromRawUnchecked"/>
    public static BatchListResponseConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BatchListResponseConfig(BatchListResponseConfigJob job)
        : this()
    {
        this.Job = job;
    }
}

class BatchListResponseConfigFromRaw : IFromRawJson<BatchListResponseConfig>
{
    /// <inheritdoc/>
    public BatchListResponseConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BatchListResponseConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Job to create for each file in the source directory.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BatchListResponseConfigJob, BatchListResponseConfigJobFromRaw>)
)]
public sealed record class BatchListResponseConfigJob : JsonModel
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
    public required ApiEnum<string, BatchListResponseConfigJobType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BatchListResponseConfigJobType>>(
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

    public BatchListResponseConfigJob() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchListResponseConfigJob(BatchListResponseConfigJob batchListResponseConfigJob)
        : base(batchListResponseConfigJob) { }
#pragma warning restore CS8618

    public BatchListResponseConfigJob(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchListResponseConfigJob(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchListResponseConfigJobFromRaw.FromRawUnchecked"/>
    public static BatchListResponseConfigJob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchListResponseConfigJobFromRaw : IFromRawJson<BatchListResponseConfigJob>
{
    /// <inheritdoc/>
    public BatchListResponseConfigJob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BatchListResponseConfigJob.FromRawUnchecked(rawData);
}

/// <summary>
/// Product job type to run for each source directory file.
/// </summary>
[JsonConverter(typeof(BatchListResponseConfigJobTypeConverter))]
public enum BatchListResponseConfigJobType
{
    ParseV2,
    ExtractV2,
}

sealed class BatchListResponseConfigJobTypeConverter : JsonConverter<BatchListResponseConfigJobType>
{
    public override BatchListResponseConfigJobType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "parse_v2" => BatchListResponseConfigJobType.ParseV2,
            "extract_v2" => BatchListResponseConfigJobType.ExtractV2,
            _ => (BatchListResponseConfigJobType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BatchListResponseConfigJobType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BatchListResponseConfigJobType.ParseV2 => "parse_v2",
                BatchListResponseConfigJobType.ExtractV2 => "extract_v2",
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
[JsonConverter(typeof(BatchListResponseStatusConverter))]
public enum BatchListResponseStatus
{
    Cancelled,
    Completed,
    Failed,
    Pending,
    Running,
    Throttled,
}

sealed class BatchListResponseStatusConverter : JsonConverter<BatchListResponseStatus>
{
    public override BatchListResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CANCELLED" => BatchListResponseStatus.Cancelled,
            "COMPLETED" => BatchListResponseStatus.Completed,
            "FAILED" => BatchListResponseStatus.Failed,
            "PENDING" => BatchListResponseStatus.Pending,
            "RUNNING" => BatchListResponseStatus.Running,
            "THROTTLED" => BatchListResponseStatus.Throttled,
            _ => (BatchListResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BatchListResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BatchListResponseStatus.Cancelled => "CANCELLED",
                BatchListResponseStatus.Completed => "COMPLETED",
                BatchListResponseStatus.Failed => "FAILED",
                BatchListResponseStatus.Pending => "PENDING",
                BatchListResponseStatus.Running => "RUNNING",
                BatchListResponseStatus.Throttled => "THROTTLED",
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
[JsonConverter(typeof(JsonModelConverter<BatchListResponseResult, BatchListResponseResultFromRaw>))]
public sealed record class BatchListResponseResult : JsonModel
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
    public BatchListResponseResultJobReference? JobReference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BatchListResponseResultJobReference>(
                "job_reference"
            );
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

    public BatchListResponseResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchListResponseResult(BatchListResponseResult batchListResponseResult)
        : base(batchListResponseResult) { }
#pragma warning restore CS8618

    public BatchListResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchListResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchListResponseResultFromRaw.FromRawUnchecked"/>
    public static BatchListResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BatchListResponseResult(string sourceDirectoryFileID)
        : this()
    {
        this.SourceDirectoryFileID = sourceDirectoryFileID;
    }
}

class BatchListResponseResultFromRaw : IFromRawJson<BatchListResponseResult>
{
    /// <inheritdoc/>
    public BatchListResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BatchListResponseResult.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to a job produced by a batch.
///
/// <para>Example:     {         "type": "parse_v2",         "id": "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee"
///     }</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BatchListResponseResultJobReference,
        BatchListResponseResultJobReferenceFromRaw
    >)
)]
public sealed record class BatchListResponseResultJobReference : JsonModel
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
    public required ApiEnum<string, BatchListResponseResultJobReferenceType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BatchListResponseResultJobReferenceType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
    }

    public BatchListResponseResultJobReference() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchListResponseResultJobReference(
        BatchListResponseResultJobReference batchListResponseResultJobReference
    )
        : base(batchListResponseResultJobReference) { }
#pragma warning restore CS8618

    public BatchListResponseResultJobReference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchListResponseResultJobReference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchListResponseResultJobReferenceFromRaw.FromRawUnchecked"/>
    public static BatchListResponseResultJobReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchListResponseResultJobReferenceFromRaw : IFromRawJson<BatchListResponseResultJobReference>
{
    /// <inheritdoc/>
    public BatchListResponseResultJobReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BatchListResponseResultJobReference.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of job produced for the file.
/// </summary>
[JsonConverter(typeof(BatchListResponseResultJobReferenceTypeConverter))]
public enum BatchListResponseResultJobReferenceType
{
    ParseV2,
    ExtractV2,
}

sealed class BatchListResponseResultJobReferenceTypeConverter
    : JsonConverter<BatchListResponseResultJobReferenceType>
{
    public override BatchListResponseResultJobReferenceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "parse_v2" => BatchListResponseResultJobReferenceType.ParseV2,
            "extract_v2" => BatchListResponseResultJobReferenceType.ExtractV2,
            _ => (BatchListResponseResultJobReferenceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BatchListResponseResultJobReferenceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BatchListResponseResultJobReferenceType.ParseV2 => "parse_v2",
                BatchListResponseResultJobReferenceType.ExtractV2 => "extract_v2",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
