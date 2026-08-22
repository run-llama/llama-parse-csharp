using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;

namespace LlamaCloud.Models.Classify;

/// <summary>
/// Response for a classify job.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ClassifyCancelResponse, ClassifyCancelResponseFromRaw>))]
public sealed record class ClassifyCancelResponse : JsonModel
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
    /// Classify configuration used for this job
    /// </summary>
    public required ClassifyConfiguration Configuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ClassifyConfiguration>("configuration");
        }
        init { this._rawData.Set("configuration", value); }
    }

    /// <summary>
    /// Whether the input was a file or parse job (FILE or PARSE_JOB)
    /// </summary>
    public required ApiEnum<string, ClassifyCancelResponseDocumentInputType> DocumentInputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ClassifyCancelResponseDocumentInputType>
            >("document_input_type");
        }
        init { this._rawData.Set("document_input_type", value); }
    }

    /// <summary>
    /// ID of the input file or parse job
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
    /// Project this job belongs to
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
    /// Current job status: PENDING, RUNNING, COMPLETED, FAILED, or CANCELLED
    /// </summary>
    public required ApiEnum<string, ClassifyCancelResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ClassifyCancelResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// User who created this job
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
    /// Product configuration ID
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
    /// Error message if job failed
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
    /// Associated parse job ID
    /// </summary>
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
    /// Result of classifying a document.
    /// </summary>
    public ClassifyResult? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ClassifyResult>("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <summary>
    /// Idempotency key
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Configuration.Validate();
        this.DocumentInputType.Validate();
        _ = this.FileInput;
        _ = this.ProjectID;
        this.Status.Validate();
        _ = this.UserID;
        _ = this.ConfigurationID;
        _ = this.CreatedAt;
        _ = this.ErrorMessage;
        _ = this.ParseJobID;
        this.Result?.Validate();
        _ = this.TransactionID;
        _ = this.UpdatedAt;
    }

    public ClassifyCancelResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClassifyCancelResponse(ClassifyCancelResponse classifyCancelResponse)
        : base(classifyCancelResponse) { }
#pragma warning restore CS8618

    public ClassifyCancelResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClassifyCancelResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClassifyCancelResponseFromRaw.FromRawUnchecked"/>
    public static ClassifyCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClassifyCancelResponseFromRaw : IFromRawJson<ClassifyCancelResponse>
{
    /// <inheritdoc/>
    public ClassifyCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClassifyCancelResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the input was a file or parse job (FILE or PARSE_JOB)
/// </summary>
[JsonConverter(typeof(ClassifyCancelResponseDocumentInputTypeConverter))]
public enum ClassifyCancelResponseDocumentInputType
{
    FileID,
    ParseJobID,
    Url,
}

sealed class ClassifyCancelResponseDocumentInputTypeConverter
    : JsonConverter<ClassifyCancelResponseDocumentInputType>
{
    public override ClassifyCancelResponseDocumentInputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file_id" => ClassifyCancelResponseDocumentInputType.FileID,
            "parse_job_id" => ClassifyCancelResponseDocumentInputType.ParseJobID,
            "url" => ClassifyCancelResponseDocumentInputType.Url,
            _ => (ClassifyCancelResponseDocumentInputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClassifyCancelResponseDocumentInputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ClassifyCancelResponseDocumentInputType.FileID => "file_id",
                ClassifyCancelResponseDocumentInputType.ParseJobID => "parse_job_id",
                ClassifyCancelResponseDocumentInputType.Url => "url",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Current job status: PENDING, RUNNING, COMPLETED, FAILED, or CANCELLED
/// </summary>
[JsonConverter(typeof(ClassifyCancelResponseStatusConverter))]
public enum ClassifyCancelResponseStatus
{
    Cancelled,
    Completed,
    Failed,
    Pending,
    Running,
}

sealed class ClassifyCancelResponseStatusConverter : JsonConverter<ClassifyCancelResponseStatus>
{
    public override ClassifyCancelResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CANCELLED" => ClassifyCancelResponseStatus.Cancelled,
            "COMPLETED" => ClassifyCancelResponseStatus.Completed,
            "FAILED" => ClassifyCancelResponseStatus.Failed,
            "PENDING" => ClassifyCancelResponseStatus.Pending,
            "RUNNING" => ClassifyCancelResponseStatus.Running,
            _ => (ClassifyCancelResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClassifyCancelResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ClassifyCancelResponseStatus.Cancelled => "CANCELLED",
                ClassifyCancelResponseStatus.Completed => "COMPLETED",
                ClassifyCancelResponseStatus.Failed => "FAILED",
                ClassifyCancelResponseStatus.Pending => "PENDING",
                ClassifyCancelResponseStatus.Running => "RUNNING",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
