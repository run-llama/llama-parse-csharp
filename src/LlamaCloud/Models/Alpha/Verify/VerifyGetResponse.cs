using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;

namespace LlamaCloud.Models.Alpha.Verify;

/// <summary>
/// Response for a Verify job.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VerifyGetResponse, VerifyGetResponseFromRaw>))]
public sealed record class VerifyGetResponse : JsonModel
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
    /// Verify configuration used for this job
    /// </summary>
    public required VerifyGetResponseConfiguration Configuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VerifyGetResponseConfiguration>("configuration");
        }
        init { this._rawData.Set("configuration", value); }
    }

    /// <summary>
    /// Type of the document input (FILE)
    /// </summary>
    public required ApiEnum<string, VerifyGetResponseDocumentInputType> DocumentInputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, VerifyGetResponseDocumentInputType>
            >("document_input_type");
        }
        init { this._rawData.Set("document_input_type", value); }
    }

    /// <summary>
    /// ID of the input file
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
    public required ApiEnum<string, VerifyGetResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VerifyGetResponseStatus>>(
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
    /// Result of a Verify (doctored-document) analysis.
    ///
    /// <para>Raw per-signal detail (evidence list, per-family sub-scores, raw regions,
    /// forensic heatmaps) is available separately via the job's details endpoint.</para>
    /// </summary>
    public VerifyGetResponseResult? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyGetResponseResult>("result");
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
        _ = this.CreatedAt;
        _ = this.ErrorMessage;
        this.Result?.Validate();
        _ = this.TransactionID;
        _ = this.UpdatedAt;
    }

    public VerifyGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyGetResponse(VerifyGetResponse verifyGetResponse)
        : base(verifyGetResponse) { }
#pragma warning restore CS8618

    public VerifyGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyGetResponseFromRaw.FromRawUnchecked"/>
    public static VerifyGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyGetResponseFromRaw : IFromRawJson<VerifyGetResponse>
{
    /// <inheritdoc/>
    public VerifyGetResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VerifyGetResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Verify configuration used for this job
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyGetResponseConfiguration,
        VerifyGetResponseConfigurationFromRaw
    >)
)]
public sealed record class VerifyGetResponseConfiguration : JsonModel
{
    /// <summary>
    /// Comma-separated page numbers or ranges to analyze (1-based). Omit to analyze
    /// all pages. Ignored for non-PDF inputs.
    /// </summary>
    public string? TargetPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("target_pages");
        }
        init { this._rawData.Set("target_pages", value); }
    }

    /// <summary>
    /// Verify tier: 'fast' runs only the quick deterministic forensic checks (metadata,
    /// content integrity, container structure, pixel statistics); 'agentic' (default)
    /// runs the full pipeline including the learned detectors and the semantic review pass.
    /// </summary>
    public ApiEnum<string, VerifyGetResponseConfigurationTier>? Tier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, VerifyGetResponseConfigurationTier>
            >("tier");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tier", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TargetPages;
        this.Tier?.Validate();
    }

    public VerifyGetResponseConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyGetResponseConfiguration(
        VerifyGetResponseConfiguration verifyGetResponseConfiguration
    )
        : base(verifyGetResponseConfiguration) { }
#pragma warning restore CS8618

    public VerifyGetResponseConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyGetResponseConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyGetResponseConfigurationFromRaw.FromRawUnchecked"/>
    public static VerifyGetResponseConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyGetResponseConfigurationFromRaw : IFromRawJson<VerifyGetResponseConfiguration>
{
    /// <inheritdoc/>
    public VerifyGetResponseConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyGetResponseConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Verify tier: 'fast' runs only the quick deterministic forensic checks (metadata,
/// content integrity, container structure, pixel statistics); 'agentic' (default)
/// runs the full pipeline including the learned detectors and the semantic review pass.
/// </summary>
[JsonConverter(typeof(VerifyGetResponseConfigurationTierConverter))]
public enum VerifyGetResponseConfigurationTier
{
    Agentic,
    Fast,
}

sealed class VerifyGetResponseConfigurationTierConverter
    : JsonConverter<VerifyGetResponseConfigurationTier>
{
    public override VerifyGetResponseConfigurationTier Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agentic" => VerifyGetResponseConfigurationTier.Agentic,
            "fast" => VerifyGetResponseConfigurationTier.Fast,
            _ => (VerifyGetResponseConfigurationTier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerifyGetResponseConfigurationTier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerifyGetResponseConfigurationTier.Agentic => "agentic",
                VerifyGetResponseConfigurationTier.Fast => "fast",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Type of the document input (FILE)
/// </summary>
[JsonConverter(typeof(VerifyGetResponseDocumentInputTypeConverter))]
public enum VerifyGetResponseDocumentInputType
{
    FileID,
    ParseJobID,
    Url,
}

sealed class VerifyGetResponseDocumentInputTypeConverter
    : JsonConverter<VerifyGetResponseDocumentInputType>
{
    public override VerifyGetResponseDocumentInputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file_id" => VerifyGetResponseDocumentInputType.FileID,
            "parse_job_id" => VerifyGetResponseDocumentInputType.ParseJobID,
            "url" => VerifyGetResponseDocumentInputType.Url,
            _ => (VerifyGetResponseDocumentInputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerifyGetResponseDocumentInputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerifyGetResponseDocumentInputType.FileID => "file_id",
                VerifyGetResponseDocumentInputType.ParseJobID => "parse_job_id",
                VerifyGetResponseDocumentInputType.Url => "url",
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
[JsonConverter(typeof(VerifyGetResponseStatusConverter))]
public enum VerifyGetResponseStatus
{
    Cancelled,
    Completed,
    Failed,
    Pending,
    Running,
}

sealed class VerifyGetResponseStatusConverter : JsonConverter<VerifyGetResponseStatus>
{
    public override VerifyGetResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CANCELLED" => VerifyGetResponseStatus.Cancelled,
            "COMPLETED" => VerifyGetResponseStatus.Completed,
            "FAILED" => VerifyGetResponseStatus.Failed,
            "PENDING" => VerifyGetResponseStatus.Pending,
            "RUNNING" => VerifyGetResponseStatus.Running,
            _ => (VerifyGetResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerifyGetResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerifyGetResponseStatus.Cancelled => "CANCELLED",
                VerifyGetResponseStatus.Completed => "COMPLETED",
                VerifyGetResponseStatus.Failed => "FAILED",
                VerifyGetResponseStatus.Pending => "PENDING",
                VerifyGetResponseStatus.Running => "RUNNING",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Result of a Verify (doctored-document) analysis.
///
/// <para>Raw per-signal detail (evidence list, per-family sub-scores, raw regions,
/// forensic heatmaps) is available separately via the job's details endpoint.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VerifyGetResponseResult, VerifyGetResponseResultFromRaw>))]
public sealed record class VerifyGetResponseResult : JsonModel
{
    /// <summary>
    /// Version of the detector that produced the result
    /// </summary>
    public required string DetectorVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("detector_version");
        }
        init { this._rawData.Set("detector_version", value); }
    }

    /// <summary>
    /// Overall doctoring likelihood (0 to 1)
    /// </summary>
    public required double OverallScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("overall_score");
        }
        init { this._rawData.Set("overall_score", value); }
    }

    /// <summary>
    /// Overall verdict for the document
    /// </summary>
    public required ApiEnum<string, VerifyGetResponseResultVerdict> Verdict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VerifyGetResponseResultVerdict>>(
                "verdict"
            );
        }
        init { this._rawData.Set("verdict", value); }
    }

    /// <summary>
    /// Composite scores, each answering one question about the document
    /// </summary>
    public VerifyGetResponseResultCompositeScores? CompositeScores
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyGetResponseResultCompositeScores>(
                "composite_scores"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("composite_scores", value);
        }
    }

    /// <summary>
    /// Confidence in the verdict (0 to 1): how firmly the detected signals support
    /// the verdict bucket, independent of the doctoring likelihood itself
    /// </summary>
    public double? Confidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("confidence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confidence", value);
        }
    }

    /// <summary>
    /// Error detail when the analysis could not complete
    /// </summary>
    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Number of analysed pages (1 for images/docx)
    /// </summary>
    public long? PageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("page_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("page_count", value);
        }
    }

    /// <summary>
    /// Rendered pixel size per page, so region bboxes can be scaled onto the page
    /// </summary>
    public IReadOnlyList<VerifyGetResponseResultPageDimension>? PageDimensions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<VerifyGetResponseResultPageDimension>
            >("page_dimensions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<VerifyGetResponseResultPageDimension>?>(
                "page_dimensions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Explanation of the verdict
    /// </summary>
    public string? Reasoning
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reasoning");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reasoning", value);
        }
    }

    /// <summary>
    /// Regions that led to the suspected fraud, ranked most-suspect first, each with
    /// an explanation of what makes it suspect
    /// </summary>
    public IReadOnlyList<VerifyGetResponseResultSuspectRegion>? SuspectRegions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<VerifyGetResponseResultSuspectRegion>
            >("suspect_regions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<VerifyGetResponseResultSuspectRegion>?>(
                "suspect_regions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Likelihood (0 to 1) that the document is wholly generated or fabricated rather
    /// than a capture of a real document. Null for jobs completed before this score
    /// was introduced
    /// </summary>
    public double? SyntheticScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("synthetic_score");
        }
        init { this._rawData.Set("synthetic_score", value); }
    }

    /// <summary>
    /// Likelihood (0 to 1) that a real captured document was locally edited — a
    /// genuine capture with regions altered after the fact. Null for jobs completed
    /// before this score was introduced
    /// </summary>
    public double? TamperingScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("tampering_score");
        }
        init { this._rawData.Set("tampering_score", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DetectorVersion;
        _ = this.OverallScore;
        this.Verdict.Validate();
        this.CompositeScores?.Validate();
        _ = this.Confidence;
        _ = this.Error;
        _ = this.PageCount;
        foreach (var item in this.PageDimensions ?? [])
        {
            item.Validate();
        }
        _ = this.Reasoning;
        foreach (var item in this.SuspectRegions ?? [])
        {
            item.Validate();
        }
        _ = this.SyntheticScore;
        _ = this.TamperingScore;
    }

    public VerifyGetResponseResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyGetResponseResult(VerifyGetResponseResult verifyGetResponseResult)
        : base(verifyGetResponseResult) { }
#pragma warning restore CS8618

    public VerifyGetResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyGetResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyGetResponseResultFromRaw.FromRawUnchecked"/>
    public static VerifyGetResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyGetResponseResultFromRaw : IFromRawJson<VerifyGetResponseResult>
{
    /// <inheritdoc/>
    public VerifyGetResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyGetResponseResult.FromRawUnchecked(rawData);
}

/// <summary>
/// Overall verdict for the document
/// </summary>
[JsonConverter(typeof(VerifyGetResponseResultVerdictConverter))]
public enum VerifyGetResponseResultVerdict
{
    Authentic,
    Doctored,
    LikelyDoctored,
    NoStrongSignal,
    Suspicious,
}

sealed class VerifyGetResponseResultVerdictConverter : JsonConverter<VerifyGetResponseResultVerdict>
{
    public override VerifyGetResponseResultVerdict Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AUTHENTIC" => VerifyGetResponseResultVerdict.Authentic,
            "DOCTORED" => VerifyGetResponseResultVerdict.Doctored,
            "LIKELY_DOCTORED" => VerifyGetResponseResultVerdict.LikelyDoctored,
            "NO_STRONG_SIGNAL" => VerifyGetResponseResultVerdict.NoStrongSignal,
            "SUSPICIOUS" => VerifyGetResponseResultVerdict.Suspicious,
            _ => (VerifyGetResponseResultVerdict)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerifyGetResponseResultVerdict value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerifyGetResponseResultVerdict.Authentic => "AUTHENTIC",
                VerifyGetResponseResultVerdict.Doctored => "DOCTORED",
                VerifyGetResponseResultVerdict.LikelyDoctored => "LIKELY_DOCTORED",
                VerifyGetResponseResultVerdict.NoStrongSignal => "NO_STRONG_SIGNAL",
                VerifyGetResponseResultVerdict.Suspicious => "SUSPICIOUS",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Composite scores, each answering one question about the document
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyGetResponseResultCompositeScores,
        VerifyGetResponseResultCompositeScoresFromRaw
    >)
)]
public sealed record class VerifyGetResponseResultCompositeScores : JsonModel
{
    /// <summary>
    /// Was this content synthesized by a generative model?
    /// </summary>
    public VerifyGetResponseResultCompositeScoresAIGenerated? AIGenerated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyGetResponseResultCompositeScoresAIGenerated>(
                "ai_generated"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ai_generated", value);
        }
    }

    /// <summary>
    /// Does the document's content agree with itself (checksums, arithmetic, machine-readable zones)?
    /// </summary>
    public VerifyGetResponseResultCompositeScoresDocumentCoherence? DocumentCoherence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyGetResponseResultCompositeScoresDocumentCoherence>(
                "document_coherence"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("document_coherence", value);
        }
    }

    /// <summary>
    /// Does the file's provenance / toolchain history look suspicious? Advisory:
    /// individually weak workflow-hygiene signals
    /// </summary>
    public VerifyGetResponseResultCompositeScoresDocumentMetadata? DocumentMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyGetResponseResultCompositeScoresDocumentMetadata>(
                "document_metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("document_metadata", value);
        }
    }

    /// <summary>
    /// Has this asset (or its template) been seen in fraud before?
    /// </summary>
    public VerifyGetResponseResultCompositeScoresKnownFraud? KnownFraud
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyGetResponseResultCompositeScoresKnownFraud>(
                "known_fraud"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("known_fraud", value);
        }
    }

    /// <summary>
    /// Was this document altered after creation (splice, retype, redact, inpaint)?
    /// </summary>
    public VerifyGetResponseResultCompositeScoresManuallyEdited? ManuallyEdited
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyGetResponseResultCompositeScoresManuallyEdited>(
                "manually_edited"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("manually_edited", value);
        }
    }

    /// <summary>
    /// Was the document captured through a channel that destroys forensic evidence
    /// (photo of a screen, print-then-rescan)?
    /// </summary>
    public VerifyGetResponseResultCompositeScoresRecapture? Recapture
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyGetResponseResultCompositeScoresRecapture>(
                "recapture"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("recapture", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AIGenerated?.Validate();
        this.DocumentCoherence?.Validate();
        this.DocumentMetadata?.Validate();
        this.KnownFraud?.Validate();
        this.ManuallyEdited?.Validate();
        this.Recapture?.Validate();
    }

    public VerifyGetResponseResultCompositeScores() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyGetResponseResultCompositeScores(
        VerifyGetResponseResultCompositeScores verifyGetResponseResultCompositeScores
    )
        : base(verifyGetResponseResultCompositeScores) { }
#pragma warning restore CS8618

    public VerifyGetResponseResultCompositeScores(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyGetResponseResultCompositeScores(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyGetResponseResultCompositeScoresFromRaw.FromRawUnchecked"/>
    public static VerifyGetResponseResultCompositeScores FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyGetResponseResultCompositeScoresFromRaw
    : IFromRawJson<VerifyGetResponseResultCompositeScores>
{
    /// <inheritdoc/>
    public VerifyGetResponseResultCompositeScores FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyGetResponseResultCompositeScores.FromRawUnchecked(rawData);
}

/// <summary>
/// Was this content synthesized by a generative model?
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyGetResponseResultCompositeScoresAIGenerated,
        VerifyGetResponseResultCompositeScoresAIGeneratedFromRaw
    >)
)]
public sealed record class VerifyGetResponseResultCompositeScoresAIGenerated : JsonModel
{
    /// <summary>
    /// Whether the checks feeding this composite ran on this document. When false
    /// the document was not checked for this — not cleared of it
    /// </summary>
    public bool? Applicable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("applicable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("applicable", value);
        }
    }

    /// <summary>
    /// Score (0 to 1); null when the composite was not applicable
    /// </summary>
    public double? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Applicable;
        _ = this.Score;
    }

    public VerifyGetResponseResultCompositeScoresAIGenerated() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyGetResponseResultCompositeScoresAIGenerated(
        VerifyGetResponseResultCompositeScoresAIGenerated verifyGetResponseResultCompositeScoresAIGenerated
    )
        : base(verifyGetResponseResultCompositeScoresAIGenerated) { }
#pragma warning restore CS8618

    public VerifyGetResponseResultCompositeScoresAIGenerated(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyGetResponseResultCompositeScoresAIGenerated(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyGetResponseResultCompositeScoresAIGeneratedFromRaw.FromRawUnchecked"/>
    public static VerifyGetResponseResultCompositeScoresAIGenerated FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyGetResponseResultCompositeScoresAIGeneratedFromRaw
    : IFromRawJson<VerifyGetResponseResultCompositeScoresAIGenerated>
{
    /// <inheritdoc/>
    public VerifyGetResponseResultCompositeScoresAIGenerated FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyGetResponseResultCompositeScoresAIGenerated.FromRawUnchecked(rawData);
}

/// <summary>
/// Does the document's content agree with itself (checksums, arithmetic, machine-readable zones)?
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyGetResponseResultCompositeScoresDocumentCoherence,
        VerifyGetResponseResultCompositeScoresDocumentCoherenceFromRaw
    >)
)]
public sealed record class VerifyGetResponseResultCompositeScoresDocumentCoherence : JsonModel
{
    /// <summary>
    /// Whether the checks feeding this composite ran on this document. When false
    /// the document was not checked for this — not cleared of it
    /// </summary>
    public bool? Applicable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("applicable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("applicable", value);
        }
    }

    /// <summary>
    /// Score (0 to 1); null when the composite was not applicable
    /// </summary>
    public double? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Applicable;
        _ = this.Score;
    }

    public VerifyGetResponseResultCompositeScoresDocumentCoherence() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyGetResponseResultCompositeScoresDocumentCoherence(
        VerifyGetResponseResultCompositeScoresDocumentCoherence verifyGetResponseResultCompositeScoresDocumentCoherence
    )
        : base(verifyGetResponseResultCompositeScoresDocumentCoherence) { }
#pragma warning restore CS8618

    public VerifyGetResponseResultCompositeScoresDocumentCoherence(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyGetResponseResultCompositeScoresDocumentCoherence(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyGetResponseResultCompositeScoresDocumentCoherenceFromRaw.FromRawUnchecked"/>
    public static VerifyGetResponseResultCompositeScoresDocumentCoherence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyGetResponseResultCompositeScoresDocumentCoherenceFromRaw
    : IFromRawJson<VerifyGetResponseResultCompositeScoresDocumentCoherence>
{
    /// <inheritdoc/>
    public VerifyGetResponseResultCompositeScoresDocumentCoherence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyGetResponseResultCompositeScoresDocumentCoherence.FromRawUnchecked(rawData);
}

/// <summary>
/// Does the file's provenance / toolchain history look suspicious? Advisory: individually
/// weak workflow-hygiene signals
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyGetResponseResultCompositeScoresDocumentMetadata,
        VerifyGetResponseResultCompositeScoresDocumentMetadataFromRaw
    >)
)]
public sealed record class VerifyGetResponseResultCompositeScoresDocumentMetadata : JsonModel
{
    /// <summary>
    /// Whether the checks feeding this composite ran on this document. When false
    /// the document was not checked for this — not cleared of it
    /// </summary>
    public bool? Applicable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("applicable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("applicable", value);
        }
    }

    /// <summary>
    /// Score (0 to 1); null when the composite was not applicable
    /// </summary>
    public double? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Applicable;
        _ = this.Score;
    }

    public VerifyGetResponseResultCompositeScoresDocumentMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyGetResponseResultCompositeScoresDocumentMetadata(
        VerifyGetResponseResultCompositeScoresDocumentMetadata verifyGetResponseResultCompositeScoresDocumentMetadata
    )
        : base(verifyGetResponseResultCompositeScoresDocumentMetadata) { }
#pragma warning restore CS8618

    public VerifyGetResponseResultCompositeScoresDocumentMetadata(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyGetResponseResultCompositeScoresDocumentMetadata(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyGetResponseResultCompositeScoresDocumentMetadataFromRaw.FromRawUnchecked"/>
    public static VerifyGetResponseResultCompositeScoresDocumentMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyGetResponseResultCompositeScoresDocumentMetadataFromRaw
    : IFromRawJson<VerifyGetResponseResultCompositeScoresDocumentMetadata>
{
    /// <inheritdoc/>
    public VerifyGetResponseResultCompositeScoresDocumentMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyGetResponseResultCompositeScoresDocumentMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Has this asset (or its template) been seen in fraud before?
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyGetResponseResultCompositeScoresKnownFraud,
        VerifyGetResponseResultCompositeScoresKnownFraudFromRaw
    >)
)]
public sealed record class VerifyGetResponseResultCompositeScoresKnownFraud : JsonModel
{
    /// <summary>
    /// Whether the checks feeding this composite ran on this document. When false
    /// the document was not checked for this — not cleared of it
    /// </summary>
    public bool? Applicable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("applicable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("applicable", value);
        }
    }

    /// <summary>
    /// Score (0 to 1); null when the composite was not applicable
    /// </summary>
    public double? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Applicable;
        _ = this.Score;
    }

    public VerifyGetResponseResultCompositeScoresKnownFraud() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyGetResponseResultCompositeScoresKnownFraud(
        VerifyGetResponseResultCompositeScoresKnownFraud verifyGetResponseResultCompositeScoresKnownFraud
    )
        : base(verifyGetResponseResultCompositeScoresKnownFraud) { }
#pragma warning restore CS8618

    public VerifyGetResponseResultCompositeScoresKnownFraud(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyGetResponseResultCompositeScoresKnownFraud(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyGetResponseResultCompositeScoresKnownFraudFromRaw.FromRawUnchecked"/>
    public static VerifyGetResponseResultCompositeScoresKnownFraud FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyGetResponseResultCompositeScoresKnownFraudFromRaw
    : IFromRawJson<VerifyGetResponseResultCompositeScoresKnownFraud>
{
    /// <inheritdoc/>
    public VerifyGetResponseResultCompositeScoresKnownFraud FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyGetResponseResultCompositeScoresKnownFraud.FromRawUnchecked(rawData);
}

/// <summary>
/// Was this document altered after creation (splice, retype, redact, inpaint)?
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyGetResponseResultCompositeScoresManuallyEdited,
        VerifyGetResponseResultCompositeScoresManuallyEditedFromRaw
    >)
)]
public sealed record class VerifyGetResponseResultCompositeScoresManuallyEdited : JsonModel
{
    /// <summary>
    /// Whether the checks feeding this composite ran on this document. When false
    /// the document was not checked for this — not cleared of it
    /// </summary>
    public bool? Applicable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("applicable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("applicable", value);
        }
    }

    /// <summary>
    /// Score (0 to 1); null when the composite was not applicable
    /// </summary>
    public double? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Applicable;
        _ = this.Score;
    }

    public VerifyGetResponseResultCompositeScoresManuallyEdited() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyGetResponseResultCompositeScoresManuallyEdited(
        VerifyGetResponseResultCompositeScoresManuallyEdited verifyGetResponseResultCompositeScoresManuallyEdited
    )
        : base(verifyGetResponseResultCompositeScoresManuallyEdited) { }
#pragma warning restore CS8618

    public VerifyGetResponseResultCompositeScoresManuallyEdited(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyGetResponseResultCompositeScoresManuallyEdited(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyGetResponseResultCompositeScoresManuallyEditedFromRaw.FromRawUnchecked"/>
    public static VerifyGetResponseResultCompositeScoresManuallyEdited FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyGetResponseResultCompositeScoresManuallyEditedFromRaw
    : IFromRawJson<VerifyGetResponseResultCompositeScoresManuallyEdited>
{
    /// <inheritdoc/>
    public VerifyGetResponseResultCompositeScoresManuallyEdited FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyGetResponseResultCompositeScoresManuallyEdited.FromRawUnchecked(rawData);
}

/// <summary>
/// Was the document captured through a channel that destroys forensic evidence (photo
/// of a screen, print-then-rescan)?
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyGetResponseResultCompositeScoresRecapture,
        VerifyGetResponseResultCompositeScoresRecaptureFromRaw
    >)
)]
public sealed record class VerifyGetResponseResultCompositeScoresRecapture : JsonModel
{
    /// <summary>
    /// Whether the checks feeding this composite ran on this document. When false
    /// the document was not checked for this — not cleared of it
    /// </summary>
    public bool? Applicable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("applicable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("applicable", value);
        }
    }

    /// <summary>
    /// Score (0 to 1); null when the composite was not applicable
    /// </summary>
    public double? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Applicable;
        _ = this.Score;
    }

    public VerifyGetResponseResultCompositeScoresRecapture() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyGetResponseResultCompositeScoresRecapture(
        VerifyGetResponseResultCompositeScoresRecapture verifyGetResponseResultCompositeScoresRecapture
    )
        : base(verifyGetResponseResultCompositeScoresRecapture) { }
#pragma warning restore CS8618

    public VerifyGetResponseResultCompositeScoresRecapture(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyGetResponseResultCompositeScoresRecapture(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyGetResponseResultCompositeScoresRecaptureFromRaw.FromRawUnchecked"/>
    public static VerifyGetResponseResultCompositeScoresRecapture FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyGetResponseResultCompositeScoresRecaptureFromRaw
    : IFromRawJson<VerifyGetResponseResultCompositeScoresRecapture>
{
    /// <inheritdoc/>
    public VerifyGetResponseResultCompositeScoresRecapture FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyGetResponseResultCompositeScoresRecapture.FromRawUnchecked(rawData);
}

/// <summary>
/// Rendered pixel size of a page — the coordinate space region bboxes use, so the
/// UI can scale the suspect-region overlay onto the displayed page.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyGetResponseResultPageDimension,
        VerifyGetResponseResultPageDimensionFromRaw
    >)
)]
public sealed record class VerifyGetResponseResultPageDimension : JsonModel
{
    /// <summary>
    /// Rendered page height in pixels
    /// </summary>
    public required long Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("height");
        }
        init { this._rawData.Set("height", value); }
    }

    /// <summary>
    /// 0-based page index (0 for standalone images)
    /// </summary>
    public required long Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page");
        }
        init { this._rawData.Set("page", value); }
    }

    /// <summary>
    /// Rendered page width in pixels
    /// </summary>
    public required long Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("width");
        }
        init { this._rawData.Set("width", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Height;
        _ = this.Page;
        _ = this.Width;
    }

    public VerifyGetResponseResultPageDimension() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyGetResponseResultPageDimension(
        VerifyGetResponseResultPageDimension verifyGetResponseResultPageDimension
    )
        : base(verifyGetResponseResultPageDimension) { }
#pragma warning restore CS8618

    public VerifyGetResponseResultPageDimension(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyGetResponseResultPageDimension(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyGetResponseResultPageDimensionFromRaw.FromRawUnchecked"/>
    public static VerifyGetResponseResultPageDimension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyGetResponseResultPageDimensionFromRaw
    : IFromRawJson<VerifyGetResponseResultPageDimension>
{
    /// <inheritdoc/>
    public VerifyGetResponseResultPageDimension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyGetResponseResultPageDimension.FromRawUnchecked(rawData);
}

/// <summary>
/// A region that led to the suspected fraud, with why it is suspect.
///
/// <para>A curated, high-signal subset of ``regions``: reviewer-dismissed candidates
/// are dropped and the remainder is ranked by suspicion, so consumers can act on
/// ``verdict`` + ``confidence`` + this list without reading the raw signals.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyGetResponseResultSuspectRegion,
        VerifyGetResponseResultSuspectRegionFromRaw
    >)
)]
public sealed record class VerifyGetResponseResultSuspectRegion : JsonModel
{
    /// <summary>
    /// Region bounding box as [x, y, w, h] in page-render pixels
    /// </summary>
    public required IReadOnlyList<long> Bbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<long>>("bbox");
        }
        init
        {
            this._rawData.Set<ImmutableArray<long>>("bbox", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Human-readable explanation of what makes this region suspect
    /// </summary>
    public required string Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <summary>
    /// Kind of anomaly detected in this region
    /// </summary>
    public required string Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("kind");
        }
        init { this._rawData.Set("kind", value); }
    }

    /// <summary>
    /// 0-based page index (0 for standalone images)
    /// </summary>
    public required long Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page");
        }
        init { this._rawData.Set("page", value); }
    }

    /// <summary>
    /// Suspicion score for this region (0 to 1)
    /// </summary>
    public required double Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    /// <summary>
    /// Detector that flagged this region
    /// </summary>
    public required string Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// Whether this region is part of the small set of decisive evidence behind the
    /// verdict — the boxes a reviewer should look at first
    /// </summary>
    public bool? Primary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("primary");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("primary", value);
        }
    }

    /// <summary>
    /// Automated reviewer verdict for this region (confirmed, dismissed, unsure,
    /// or empty). A dismissed region can still be surfaced when it is the only place
    /// to look; this label says how to read it
    /// </summary>
    public string? Review
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("review");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("review", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Bbox;
        _ = this.Explanation;
        _ = this.Kind;
        _ = this.Page;
        _ = this.Score;
        _ = this.Source;
        _ = this.Primary;
        _ = this.Review;
    }

    public VerifyGetResponseResultSuspectRegion() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyGetResponseResultSuspectRegion(
        VerifyGetResponseResultSuspectRegion verifyGetResponseResultSuspectRegion
    )
        : base(verifyGetResponseResultSuspectRegion) { }
#pragma warning restore CS8618

    public VerifyGetResponseResultSuspectRegion(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyGetResponseResultSuspectRegion(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyGetResponseResultSuspectRegionFromRaw.FromRawUnchecked"/>
    public static VerifyGetResponseResultSuspectRegion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyGetResponseResultSuspectRegionFromRaw
    : IFromRawJson<VerifyGetResponseResultSuspectRegion>
{
    /// <inheritdoc/>
    public VerifyGetResponseResultSuspectRegion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyGetResponseResultSuspectRegion.FromRawUnchecked(rawData);
}
