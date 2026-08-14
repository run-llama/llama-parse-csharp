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
[JsonConverter(typeof(JsonModelConverter<BatchCancelResponse, BatchCancelResponseFromRaw>))]
public sealed record class BatchCancelResponse : JsonModel
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
    public required BatchCancelResponseConfig Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BatchCancelResponseConfig>("config");
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
    public required ApiEnum<string, BatchCancelResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BatchCancelResponseStatus>>(
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
    public IReadOnlyList<BatchCancelResponseResult>? Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BatchCancelResponseResult>>(
                "results"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BatchCancelResponseResult>?>(
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

    public BatchCancelResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchCancelResponse(BatchCancelResponse batchCancelResponse)
        : base(batchCancelResponse) { }
#pragma warning restore CS8618

    public BatchCancelResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchCancelResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchCancelResponseFromRaw.FromRawUnchecked"/>
    public static BatchCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchCancelResponseFromRaw : IFromRawJson<BatchCancelResponse>
{
    /// <inheritdoc/>
    public BatchCancelResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchCancelResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Batch configuration snapshot.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BatchCancelResponseConfig, BatchCancelResponseConfigFromRaw>)
)]
public sealed record class BatchCancelResponseConfig : JsonModel
{
    /// <summary>
    /// Job to create for each file in the source directory.
    /// </summary>
    public required BatchCancelResponseConfigJob Job
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BatchCancelResponseConfigJob>("job");
        }
        init { this._rawData.Set("job", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Job.Validate();
    }

    public BatchCancelResponseConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchCancelResponseConfig(BatchCancelResponseConfig batchCancelResponseConfig)
        : base(batchCancelResponseConfig) { }
#pragma warning restore CS8618

    public BatchCancelResponseConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchCancelResponseConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchCancelResponseConfigFromRaw.FromRawUnchecked"/>
    public static BatchCancelResponseConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BatchCancelResponseConfig(BatchCancelResponseConfigJob job)
        : this()
    {
        this.Job = job;
    }
}

class BatchCancelResponseConfigFromRaw : IFromRawJson<BatchCancelResponseConfig>
{
    /// <inheritdoc/>
    public BatchCancelResponseConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BatchCancelResponseConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Job to create for each file in the source directory.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BatchCancelResponseConfigJob, BatchCancelResponseConfigJobFromRaw>)
)]
public sealed record class BatchCancelResponseConfigJob : JsonModel
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
    public required ApiEnum<string, BatchCancelResponseConfigJobType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BatchCancelResponseConfigJobType>>(
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

    public BatchCancelResponseConfigJob() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchCancelResponseConfigJob(BatchCancelResponseConfigJob batchCancelResponseConfigJob)
        : base(batchCancelResponseConfigJob) { }
#pragma warning restore CS8618

    public BatchCancelResponseConfigJob(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchCancelResponseConfigJob(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchCancelResponseConfigJobFromRaw.FromRawUnchecked"/>
    public static BatchCancelResponseConfigJob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchCancelResponseConfigJobFromRaw : IFromRawJson<BatchCancelResponseConfigJob>
{
    /// <inheritdoc/>
    public BatchCancelResponseConfigJob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BatchCancelResponseConfigJob.FromRawUnchecked(rawData);
}

/// <summary>
/// Product job type to run for each source directory file.
/// </summary>
[JsonConverter(typeof(BatchCancelResponseConfigJobTypeConverter))]
public enum BatchCancelResponseConfigJobType
{
    ParseV2,
    ExtractV2,
}

sealed class BatchCancelResponseConfigJobTypeConverter
    : JsonConverter<BatchCancelResponseConfigJobType>
{
    public override BatchCancelResponseConfigJobType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "parse_v2" => BatchCancelResponseConfigJobType.ParseV2,
            "extract_v2" => BatchCancelResponseConfigJobType.ExtractV2,
            _ => (BatchCancelResponseConfigJobType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BatchCancelResponseConfigJobType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BatchCancelResponseConfigJobType.ParseV2 => "parse_v2",
                BatchCancelResponseConfigJobType.ExtractV2 => "extract_v2",
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
[JsonConverter(typeof(BatchCancelResponseStatusConverter))]
public enum BatchCancelResponseStatus
{
    Cancelled,
    Completed,
    Failed,
    Pending,
    Running,
    Throttled,
}

sealed class BatchCancelResponseStatusConverter : JsonConverter<BatchCancelResponseStatus>
{
    public override BatchCancelResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CANCELLED" => BatchCancelResponseStatus.Cancelled,
            "COMPLETED" => BatchCancelResponseStatus.Completed,
            "FAILED" => BatchCancelResponseStatus.Failed,
            "PENDING" => BatchCancelResponseStatus.Pending,
            "RUNNING" => BatchCancelResponseStatus.Running,
            "THROTTLED" => BatchCancelResponseStatus.Throttled,
            _ => (BatchCancelResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BatchCancelResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BatchCancelResponseStatus.Cancelled => "CANCELLED",
                BatchCancelResponseStatus.Completed => "COMPLETED",
                BatchCancelResponseStatus.Failed => "FAILED",
                BatchCancelResponseStatus.Pending => "PENDING",
                BatchCancelResponseStatus.Running => "RUNNING",
                BatchCancelResponseStatus.Throttled => "THROTTLED",
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
[JsonConverter(
    typeof(JsonModelConverter<BatchCancelResponseResult, BatchCancelResponseResultFromRaw>)
)]
public sealed record class BatchCancelResponseResult : JsonModel
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
    public BatchCancelResponseResultJobReference? JobReference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BatchCancelResponseResultJobReference>(
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

    public BatchCancelResponseResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchCancelResponseResult(BatchCancelResponseResult batchCancelResponseResult)
        : base(batchCancelResponseResult) { }
#pragma warning restore CS8618

    public BatchCancelResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchCancelResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchCancelResponseResultFromRaw.FromRawUnchecked"/>
    public static BatchCancelResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BatchCancelResponseResult(string sourceDirectoryFileID)
        : this()
    {
        this.SourceDirectoryFileID = sourceDirectoryFileID;
    }
}

class BatchCancelResponseResultFromRaw : IFromRawJson<BatchCancelResponseResult>
{
    /// <inheritdoc/>
    public BatchCancelResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BatchCancelResponseResult.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to a job produced by a batch.
///
/// <para>Example:     {         "type": "parse_v2",         "id": "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee"
///     }</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BatchCancelResponseResultJobReference,
        BatchCancelResponseResultJobReferenceFromRaw
    >)
)]
public sealed record class BatchCancelResponseResultJobReference : JsonModel
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
    public required ApiEnum<string, BatchCancelResponseResultJobReferenceType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BatchCancelResponseResultJobReferenceType>
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

    public BatchCancelResponseResultJobReference() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchCancelResponseResultJobReference(
        BatchCancelResponseResultJobReference batchCancelResponseResultJobReference
    )
        : base(batchCancelResponseResultJobReference) { }
#pragma warning restore CS8618

    public BatchCancelResponseResultJobReference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchCancelResponseResultJobReference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchCancelResponseResultJobReferenceFromRaw.FromRawUnchecked"/>
    public static BatchCancelResponseResultJobReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchCancelResponseResultJobReferenceFromRaw
    : IFromRawJson<BatchCancelResponseResultJobReference>
{
    /// <inheritdoc/>
    public BatchCancelResponseResultJobReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BatchCancelResponseResultJobReference.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of job produced for the file.
/// </summary>
[JsonConverter(typeof(BatchCancelResponseResultJobReferenceTypeConverter))]
public enum BatchCancelResponseResultJobReferenceType
{
    ParseV2,
    ExtractV2,
}

sealed class BatchCancelResponseResultJobReferenceTypeConverter
    : JsonConverter<BatchCancelResponseResultJobReferenceType>
{
    public override BatchCancelResponseResultJobReferenceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "parse_v2" => BatchCancelResponseResultJobReferenceType.ParseV2,
            "extract_v2" => BatchCancelResponseResultJobReferenceType.ExtractV2,
            _ => (BatchCancelResponseResultJobReferenceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BatchCancelResponseResultJobReferenceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BatchCancelResponseResultJobReferenceType.ParseV2 => "parse_v2",
                BatchCancelResponseResultJobReferenceType.ExtractV2 => "extract_v2",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
