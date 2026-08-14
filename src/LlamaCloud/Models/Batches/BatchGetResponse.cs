using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Batches;

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
[JsonConverter(typeof(JsonModelConverter<BatchGetResponse, BatchGetResponseFromRaw>))]
public sealed record class BatchGetResponse : JsonModel
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
    public required BatchGetResponseConfig Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BatchGetResponseConfig>("config");
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
    public required ApiEnum<string, BatchGetResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BatchGetResponseStatus>>("status");
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
    public IReadOnlyList<BatchGetResponseResult>? Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BatchGetResponseResult>>(
                "results"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BatchGetResponseResult>?>(
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

    public BatchGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchGetResponse(BatchGetResponse batchGetResponse)
        : base(batchGetResponse) { }
#pragma warning restore CS8618

    public BatchGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchGetResponseFromRaw.FromRawUnchecked"/>
    public static BatchGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchGetResponseFromRaw : IFromRawJson<BatchGetResponse>
{
    /// <inheritdoc/>
    public BatchGetResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchGetResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Batch configuration snapshot.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchGetResponseConfig, BatchGetResponseConfigFromRaw>))]
public sealed record class BatchGetResponseConfig : JsonModel
{
    /// <summary>
    /// Job to create for each file in the source directory.
    /// </summary>
    public required BatchGetResponseConfigJob Job
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BatchGetResponseConfigJob>("job");
        }
        init { this._rawData.Set("job", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Job.Validate();
    }

    public BatchGetResponseConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchGetResponseConfig(BatchGetResponseConfig batchGetResponseConfig)
        : base(batchGetResponseConfig) { }
#pragma warning restore CS8618

    public BatchGetResponseConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchGetResponseConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchGetResponseConfigFromRaw.FromRawUnchecked"/>
    public static BatchGetResponseConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BatchGetResponseConfig(BatchGetResponseConfigJob job)
        : this()
    {
        this.Job = job;
    }
}

class BatchGetResponseConfigFromRaw : IFromRawJson<BatchGetResponseConfig>
{
    /// <inheritdoc/>
    public BatchGetResponseConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BatchGetResponseConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Job to create for each file in the source directory.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BatchGetResponseConfigJob, BatchGetResponseConfigJobFromRaw>)
)]
public sealed record class BatchGetResponseConfigJob : JsonModel
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
    public required ApiEnum<string, BatchGetResponseConfigJobType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BatchGetResponseConfigJobType>>(
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

    public BatchGetResponseConfigJob() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchGetResponseConfigJob(BatchGetResponseConfigJob batchGetResponseConfigJob)
        : base(batchGetResponseConfigJob) { }
#pragma warning restore CS8618

    public BatchGetResponseConfigJob(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchGetResponseConfigJob(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchGetResponseConfigJobFromRaw.FromRawUnchecked"/>
    public static BatchGetResponseConfigJob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchGetResponseConfigJobFromRaw : IFromRawJson<BatchGetResponseConfigJob>
{
    /// <inheritdoc/>
    public BatchGetResponseConfigJob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BatchGetResponseConfigJob.FromRawUnchecked(rawData);
}

/// <summary>
/// Product job type to run for each source directory file.
/// </summary>
[JsonConverter(typeof(BatchGetResponseConfigJobTypeConverter))]
public enum BatchGetResponseConfigJobType
{
    ParseV2,
    ExtractV2,
}

sealed class BatchGetResponseConfigJobTypeConverter : JsonConverter<BatchGetResponseConfigJobType>
{
    public override BatchGetResponseConfigJobType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "parse_v2" => BatchGetResponseConfigJobType.ParseV2,
            "extract_v2" => BatchGetResponseConfigJobType.ExtractV2,
            _ => (BatchGetResponseConfigJobType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BatchGetResponseConfigJobType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BatchGetResponseConfigJobType.ParseV2 => "parse_v2",
                BatchGetResponseConfigJobType.ExtractV2 => "extract_v2",
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
[JsonConverter(typeof(BatchGetResponseStatusConverter))]
public enum BatchGetResponseStatus
{
    Cancelled,
    Completed,
    Failed,
    Pending,
    Running,
    Throttled,
}

sealed class BatchGetResponseStatusConverter : JsonConverter<BatchGetResponseStatus>
{
    public override BatchGetResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CANCELLED" => BatchGetResponseStatus.Cancelled,
            "COMPLETED" => BatchGetResponseStatus.Completed,
            "FAILED" => BatchGetResponseStatus.Failed,
            "PENDING" => BatchGetResponseStatus.Pending,
            "RUNNING" => BatchGetResponseStatus.Running,
            "THROTTLED" => BatchGetResponseStatus.Throttled,
            _ => (BatchGetResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BatchGetResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BatchGetResponseStatus.Cancelled => "CANCELLED",
                BatchGetResponseStatus.Completed => "COMPLETED",
                BatchGetResponseStatus.Failed => "FAILED",
                BatchGetResponseStatus.Pending => "PENDING",
                BatchGetResponseStatus.Running => "RUNNING",
                BatchGetResponseStatus.Throttled => "THROTTLED",
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
[JsonConverter(typeof(JsonModelConverter<BatchGetResponseResult, BatchGetResponseResultFromRaw>))]
public sealed record class BatchGetResponseResult : JsonModel
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
    public BatchGetResponseResultJobReference? JobReference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BatchGetResponseResultJobReference>(
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

    public BatchGetResponseResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchGetResponseResult(BatchGetResponseResult batchGetResponseResult)
        : base(batchGetResponseResult) { }
#pragma warning restore CS8618

    public BatchGetResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchGetResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchGetResponseResultFromRaw.FromRawUnchecked"/>
    public static BatchGetResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BatchGetResponseResult(string sourceDirectoryFileID)
        : this()
    {
        this.SourceDirectoryFileID = sourceDirectoryFileID;
    }
}

class BatchGetResponseResultFromRaw : IFromRawJson<BatchGetResponseResult>
{
    /// <inheritdoc/>
    public BatchGetResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BatchGetResponseResult.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to a job produced by a batch.
///
/// <para>Example:     {         "type": "parse_v2",         "id": "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee"
///     }</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BatchGetResponseResultJobReference,
        BatchGetResponseResultJobReferenceFromRaw
    >)
)]
public sealed record class BatchGetResponseResultJobReference : JsonModel
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
    public required ApiEnum<string, BatchGetResponseResultJobReferenceType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BatchGetResponseResultJobReferenceType>
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

    public BatchGetResponseResultJobReference() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchGetResponseResultJobReference(
        BatchGetResponseResultJobReference batchGetResponseResultJobReference
    )
        : base(batchGetResponseResultJobReference) { }
#pragma warning restore CS8618

    public BatchGetResponseResultJobReference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchGetResponseResultJobReference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchGetResponseResultJobReferenceFromRaw.FromRawUnchecked"/>
    public static BatchGetResponseResultJobReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchGetResponseResultJobReferenceFromRaw : IFromRawJson<BatchGetResponseResultJobReference>
{
    /// <inheritdoc/>
    public BatchGetResponseResultJobReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BatchGetResponseResultJobReference.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of job produced for the file.
/// </summary>
[JsonConverter(typeof(BatchGetResponseResultJobReferenceTypeConverter))]
public enum BatchGetResponseResultJobReferenceType
{
    ParseV2,
    ExtractV2,
}

sealed class BatchGetResponseResultJobReferenceTypeConverter
    : JsonConverter<BatchGetResponseResultJobReferenceType>
{
    public override BatchGetResponseResultJobReferenceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "parse_v2" => BatchGetResponseResultJobReferenceType.ParseV2,
            "extract_v2" => BatchGetResponseResultJobReferenceType.ExtractV2,
            _ => (BatchGetResponseResultJobReferenceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BatchGetResponseResultJobReferenceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BatchGetResponseResultJobReferenceType.ParseV2 => "parse_v2",
                BatchGetResponseResultJobReferenceType.ExtractV2 => "extract_v2",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
