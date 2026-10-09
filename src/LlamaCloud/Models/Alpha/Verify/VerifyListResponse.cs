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
[JsonConverter(typeof(JsonModelConverter<VerifyListResponse, VerifyListResponseFromRaw>))]
public sealed record class VerifyListResponse : JsonModel
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
    public required VerifyListResponseConfiguration Configuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VerifyListResponseConfiguration>("configuration");
        }
        init { this._rawData.Set("configuration", value); }
    }

    /// <summary>
    /// Type of the document input (FILE)
    /// </summary>
    public required ApiEnum<string, VerifyListResponseDocumentInputType> DocumentInputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, VerifyListResponseDocumentInputType>
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
    public required ApiEnum<string, VerifyListResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VerifyListResponseStatus>>(
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
    public VerifyListResponseResult? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyListResponseResult>("result");
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

    public VerifyListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyListResponse(VerifyListResponse verifyListResponse)
        : base(verifyListResponse) { }
#pragma warning restore CS8618

    public VerifyListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyListResponseFromRaw.FromRawUnchecked"/>
    public static VerifyListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyListResponseFromRaw : IFromRawJson<VerifyListResponse>
{
    /// <inheritdoc/>
    public VerifyListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VerifyListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Verify configuration used for this job
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyListResponseConfiguration,
        VerifyListResponseConfigurationFromRaw
    >)
)]
public sealed record class VerifyListResponseConfiguration : JsonModel
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
    public ApiEnum<string, VerifyListResponseConfigurationTier>? Tier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, VerifyListResponseConfigurationTier>
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

    public VerifyListResponseConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyListResponseConfiguration(
        VerifyListResponseConfiguration verifyListResponseConfiguration
    )
        : base(verifyListResponseConfiguration) { }
#pragma warning restore CS8618

    public VerifyListResponseConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyListResponseConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyListResponseConfigurationFromRaw.FromRawUnchecked"/>
    public static VerifyListResponseConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyListResponseConfigurationFromRaw : IFromRawJson<VerifyListResponseConfiguration>
{
    /// <inheritdoc/>
    public VerifyListResponseConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyListResponseConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Verify tier: 'fast' runs only the quick deterministic forensic checks (metadata,
/// content integrity, container structure, pixel statistics); 'agentic' (default)
/// runs the full pipeline including the learned detectors and the semantic review pass.
/// </summary>
[JsonConverter(typeof(VerifyListResponseConfigurationTierConverter))]
public enum VerifyListResponseConfigurationTier
{
    Agentic,
    Fast,
}

sealed class VerifyListResponseConfigurationTierConverter
    : JsonConverter<VerifyListResponseConfigurationTier>
{
    public override VerifyListResponseConfigurationTier Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agentic" => VerifyListResponseConfigurationTier.Agentic,
            "fast" => VerifyListResponseConfigurationTier.Fast,
            _ => (VerifyListResponseConfigurationTier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerifyListResponseConfigurationTier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerifyListResponseConfigurationTier.Agentic => "agentic",
                VerifyListResponseConfigurationTier.Fast => "fast",
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
[JsonConverter(typeof(VerifyListResponseDocumentInputTypeConverter))]
public enum VerifyListResponseDocumentInputType
{
    FileID,
    ParseJobID,
    Url,
}

sealed class VerifyListResponseDocumentInputTypeConverter
    : JsonConverter<VerifyListResponseDocumentInputType>
{
    public override VerifyListResponseDocumentInputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file_id" => VerifyListResponseDocumentInputType.FileID,
            "parse_job_id" => VerifyListResponseDocumentInputType.ParseJobID,
            "url" => VerifyListResponseDocumentInputType.Url,
            _ => (VerifyListResponseDocumentInputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerifyListResponseDocumentInputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerifyListResponseDocumentInputType.FileID => "file_id",
                VerifyListResponseDocumentInputType.ParseJobID => "parse_job_id",
                VerifyListResponseDocumentInputType.Url => "url",
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
[JsonConverter(typeof(VerifyListResponseStatusConverter))]
public enum VerifyListResponseStatus
{
    Cancelled,
    Completed,
    Failed,
    Pending,
    Running,
}

sealed class VerifyListResponseStatusConverter : JsonConverter<VerifyListResponseStatus>
{
    public override VerifyListResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CANCELLED" => VerifyListResponseStatus.Cancelled,
            "COMPLETED" => VerifyListResponseStatus.Completed,
            "FAILED" => VerifyListResponseStatus.Failed,
            "PENDING" => VerifyListResponseStatus.Pending,
            "RUNNING" => VerifyListResponseStatus.Running,
            _ => (VerifyListResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerifyListResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerifyListResponseStatus.Cancelled => "CANCELLED",
                VerifyListResponseStatus.Completed => "COMPLETED",
                VerifyListResponseStatus.Failed => "FAILED",
                VerifyListResponseStatus.Pending => "PENDING",
                VerifyListResponseStatus.Running => "RUNNING",
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
[JsonConverter(
    typeof(JsonModelConverter<VerifyListResponseResult, VerifyListResponseResultFromRaw>)
)]
public sealed record class VerifyListResponseResult : JsonModel
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
    public required ApiEnum<string, VerifyListResponseResultVerdict> Verdict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VerifyListResponseResultVerdict>>(
                "verdict"
            );
        }
        init { this._rawData.Set("verdict", value); }
    }

    /// <summary>
    /// Composite scores, each answering one question about the document
    /// </summary>
    public VerifyListResponseResultCompositeScores? CompositeScores
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyListResponseResultCompositeScores>(
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
    public IReadOnlyList<VerifyListResponseResultPageDimension>? PageDimensions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<VerifyListResponseResultPageDimension>
            >("page_dimensions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<VerifyListResponseResultPageDimension>?>(
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
    public IReadOnlyList<VerifyListResponseResultSuspectRegion>? SuspectRegions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<VerifyListResponseResultSuspectRegion>
            >("suspect_regions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<VerifyListResponseResultSuspectRegion>?>(
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

    public VerifyListResponseResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyListResponseResult(VerifyListResponseResult verifyListResponseResult)
        : base(verifyListResponseResult) { }
#pragma warning restore CS8618

    public VerifyListResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyListResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyListResponseResultFromRaw.FromRawUnchecked"/>
    public static VerifyListResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyListResponseResultFromRaw : IFromRawJson<VerifyListResponseResult>
{
    /// <inheritdoc/>
    public VerifyListResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyListResponseResult.FromRawUnchecked(rawData);
}

/// <summary>
/// Overall verdict for the document
/// </summary>
[JsonConverter(typeof(VerifyListResponseResultVerdictConverter))]
public enum VerifyListResponseResultVerdict
{
    Authentic,
    Doctored,
    LikelyDoctored,
    NoStrongSignal,
    Suspicious,
}

sealed class VerifyListResponseResultVerdictConverter
    : JsonConverter<VerifyListResponseResultVerdict>
{
    public override VerifyListResponseResultVerdict Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AUTHENTIC" => VerifyListResponseResultVerdict.Authentic,
            "DOCTORED" => VerifyListResponseResultVerdict.Doctored,
            "LIKELY_DOCTORED" => VerifyListResponseResultVerdict.LikelyDoctored,
            "NO_STRONG_SIGNAL" => VerifyListResponseResultVerdict.NoStrongSignal,
            "SUSPICIOUS" => VerifyListResponseResultVerdict.Suspicious,
            _ => (VerifyListResponseResultVerdict)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerifyListResponseResultVerdict value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerifyListResponseResultVerdict.Authentic => "AUTHENTIC",
                VerifyListResponseResultVerdict.Doctored => "DOCTORED",
                VerifyListResponseResultVerdict.LikelyDoctored => "LIKELY_DOCTORED",
                VerifyListResponseResultVerdict.NoStrongSignal => "NO_STRONG_SIGNAL",
                VerifyListResponseResultVerdict.Suspicious => "SUSPICIOUS",
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
        VerifyListResponseResultCompositeScores,
        VerifyListResponseResultCompositeScoresFromRaw
    >)
)]
public sealed record class VerifyListResponseResultCompositeScores : JsonModel
{
    /// <summary>
    /// Was this content synthesized by a generative model?
    /// </summary>
    public VerifyListResponseResultCompositeScoresAIGenerated? AIGenerated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyListResponseResultCompositeScoresAIGenerated>(
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
    public VerifyListResponseResultCompositeScoresDocumentCoherence? DocumentCoherence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyListResponseResultCompositeScoresDocumentCoherence>(
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
    public VerifyListResponseResultCompositeScoresDocumentMetadata? DocumentMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyListResponseResultCompositeScoresDocumentMetadata>(
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
    public VerifyListResponseResultCompositeScoresKnownFraud? KnownFraud
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyListResponseResultCompositeScoresKnownFraud>(
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
    public VerifyListResponseResultCompositeScoresManuallyEdited? ManuallyEdited
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyListResponseResultCompositeScoresManuallyEdited>(
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
    public VerifyListResponseResultCompositeScoresRecapture? Recapture
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyListResponseResultCompositeScoresRecapture>(
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

    public VerifyListResponseResultCompositeScores() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyListResponseResultCompositeScores(
        VerifyListResponseResultCompositeScores verifyListResponseResultCompositeScores
    )
        : base(verifyListResponseResultCompositeScores) { }
#pragma warning restore CS8618

    public VerifyListResponseResultCompositeScores(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyListResponseResultCompositeScores(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyListResponseResultCompositeScoresFromRaw.FromRawUnchecked"/>
    public static VerifyListResponseResultCompositeScores FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyListResponseResultCompositeScoresFromRaw
    : IFromRawJson<VerifyListResponseResultCompositeScores>
{
    /// <inheritdoc/>
    public VerifyListResponseResultCompositeScores FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyListResponseResultCompositeScores.FromRawUnchecked(rawData);
}

/// <summary>
/// Was this content synthesized by a generative model?
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyListResponseResultCompositeScoresAIGenerated,
        VerifyListResponseResultCompositeScoresAIGeneratedFromRaw
    >)
)]
public sealed record class VerifyListResponseResultCompositeScoresAIGenerated : JsonModel
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

    public VerifyListResponseResultCompositeScoresAIGenerated() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyListResponseResultCompositeScoresAIGenerated(
        VerifyListResponseResultCompositeScoresAIGenerated verifyListResponseResultCompositeScoresAIGenerated
    )
        : base(verifyListResponseResultCompositeScoresAIGenerated) { }
#pragma warning restore CS8618

    public VerifyListResponseResultCompositeScoresAIGenerated(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyListResponseResultCompositeScoresAIGenerated(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyListResponseResultCompositeScoresAIGeneratedFromRaw.FromRawUnchecked"/>
    public static VerifyListResponseResultCompositeScoresAIGenerated FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyListResponseResultCompositeScoresAIGeneratedFromRaw
    : IFromRawJson<VerifyListResponseResultCompositeScoresAIGenerated>
{
    /// <inheritdoc/>
    public VerifyListResponseResultCompositeScoresAIGenerated FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyListResponseResultCompositeScoresAIGenerated.FromRawUnchecked(rawData);
}

/// <summary>
/// Does the document's content agree with itself (checksums, arithmetic, machine-readable zones)?
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyListResponseResultCompositeScoresDocumentCoherence,
        VerifyListResponseResultCompositeScoresDocumentCoherenceFromRaw
    >)
)]
public sealed record class VerifyListResponseResultCompositeScoresDocumentCoherence : JsonModel
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

    public VerifyListResponseResultCompositeScoresDocumentCoherence() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyListResponseResultCompositeScoresDocumentCoherence(
        VerifyListResponseResultCompositeScoresDocumentCoherence verifyListResponseResultCompositeScoresDocumentCoherence
    )
        : base(verifyListResponseResultCompositeScoresDocumentCoherence) { }
#pragma warning restore CS8618

    public VerifyListResponseResultCompositeScoresDocumentCoherence(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyListResponseResultCompositeScoresDocumentCoherence(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyListResponseResultCompositeScoresDocumentCoherenceFromRaw.FromRawUnchecked"/>
    public static VerifyListResponseResultCompositeScoresDocumentCoherence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyListResponseResultCompositeScoresDocumentCoherenceFromRaw
    : IFromRawJson<VerifyListResponseResultCompositeScoresDocumentCoherence>
{
    /// <inheritdoc/>
    public VerifyListResponseResultCompositeScoresDocumentCoherence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyListResponseResultCompositeScoresDocumentCoherence.FromRawUnchecked(rawData);
}

/// <summary>
/// Does the file's provenance / toolchain history look suspicious? Advisory: individually
/// weak workflow-hygiene signals
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyListResponseResultCompositeScoresDocumentMetadata,
        VerifyListResponseResultCompositeScoresDocumentMetadataFromRaw
    >)
)]
public sealed record class VerifyListResponseResultCompositeScoresDocumentMetadata : JsonModel
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

    public VerifyListResponseResultCompositeScoresDocumentMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyListResponseResultCompositeScoresDocumentMetadata(
        VerifyListResponseResultCompositeScoresDocumentMetadata verifyListResponseResultCompositeScoresDocumentMetadata
    )
        : base(verifyListResponseResultCompositeScoresDocumentMetadata) { }
#pragma warning restore CS8618

    public VerifyListResponseResultCompositeScoresDocumentMetadata(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyListResponseResultCompositeScoresDocumentMetadata(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyListResponseResultCompositeScoresDocumentMetadataFromRaw.FromRawUnchecked"/>
    public static VerifyListResponseResultCompositeScoresDocumentMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyListResponseResultCompositeScoresDocumentMetadataFromRaw
    : IFromRawJson<VerifyListResponseResultCompositeScoresDocumentMetadata>
{
    /// <inheritdoc/>
    public VerifyListResponseResultCompositeScoresDocumentMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyListResponseResultCompositeScoresDocumentMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Has this asset (or its template) been seen in fraud before?
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyListResponseResultCompositeScoresKnownFraud,
        VerifyListResponseResultCompositeScoresKnownFraudFromRaw
    >)
)]
public sealed record class VerifyListResponseResultCompositeScoresKnownFraud : JsonModel
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

    public VerifyListResponseResultCompositeScoresKnownFraud() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyListResponseResultCompositeScoresKnownFraud(
        VerifyListResponseResultCompositeScoresKnownFraud verifyListResponseResultCompositeScoresKnownFraud
    )
        : base(verifyListResponseResultCompositeScoresKnownFraud) { }
#pragma warning restore CS8618

    public VerifyListResponseResultCompositeScoresKnownFraud(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyListResponseResultCompositeScoresKnownFraud(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyListResponseResultCompositeScoresKnownFraudFromRaw.FromRawUnchecked"/>
    public static VerifyListResponseResultCompositeScoresKnownFraud FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyListResponseResultCompositeScoresKnownFraudFromRaw
    : IFromRawJson<VerifyListResponseResultCompositeScoresKnownFraud>
{
    /// <inheritdoc/>
    public VerifyListResponseResultCompositeScoresKnownFraud FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyListResponseResultCompositeScoresKnownFraud.FromRawUnchecked(rawData);
}

/// <summary>
/// Was this document altered after creation (splice, retype, redact, inpaint)?
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyListResponseResultCompositeScoresManuallyEdited,
        VerifyListResponseResultCompositeScoresManuallyEditedFromRaw
    >)
)]
public sealed record class VerifyListResponseResultCompositeScoresManuallyEdited : JsonModel
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

    public VerifyListResponseResultCompositeScoresManuallyEdited() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyListResponseResultCompositeScoresManuallyEdited(
        VerifyListResponseResultCompositeScoresManuallyEdited verifyListResponseResultCompositeScoresManuallyEdited
    )
        : base(verifyListResponseResultCompositeScoresManuallyEdited) { }
#pragma warning restore CS8618

    public VerifyListResponseResultCompositeScoresManuallyEdited(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyListResponseResultCompositeScoresManuallyEdited(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyListResponseResultCompositeScoresManuallyEditedFromRaw.FromRawUnchecked"/>
    public static VerifyListResponseResultCompositeScoresManuallyEdited FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyListResponseResultCompositeScoresManuallyEditedFromRaw
    : IFromRawJson<VerifyListResponseResultCompositeScoresManuallyEdited>
{
    /// <inheritdoc/>
    public VerifyListResponseResultCompositeScoresManuallyEdited FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyListResponseResultCompositeScoresManuallyEdited.FromRawUnchecked(rawData);
}

/// <summary>
/// Was the document captured through a channel that destroys forensic evidence (photo
/// of a screen, print-then-rescan)?
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyListResponseResultCompositeScoresRecapture,
        VerifyListResponseResultCompositeScoresRecaptureFromRaw
    >)
)]
public sealed record class VerifyListResponseResultCompositeScoresRecapture : JsonModel
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

    public VerifyListResponseResultCompositeScoresRecapture() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyListResponseResultCompositeScoresRecapture(
        VerifyListResponseResultCompositeScoresRecapture verifyListResponseResultCompositeScoresRecapture
    )
        : base(verifyListResponseResultCompositeScoresRecapture) { }
#pragma warning restore CS8618

    public VerifyListResponseResultCompositeScoresRecapture(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyListResponseResultCompositeScoresRecapture(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyListResponseResultCompositeScoresRecaptureFromRaw.FromRawUnchecked"/>
    public static VerifyListResponseResultCompositeScoresRecapture FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyListResponseResultCompositeScoresRecaptureFromRaw
    : IFromRawJson<VerifyListResponseResultCompositeScoresRecapture>
{
    /// <inheritdoc/>
    public VerifyListResponseResultCompositeScoresRecapture FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyListResponseResultCompositeScoresRecapture.FromRawUnchecked(rawData);
}

/// <summary>
/// Rendered pixel size of a page — the coordinate space region bboxes use, so the
/// UI can scale the suspect-region overlay onto the displayed page.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyListResponseResultPageDimension,
        VerifyListResponseResultPageDimensionFromRaw
    >)
)]
public sealed record class VerifyListResponseResultPageDimension : JsonModel
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

    public VerifyListResponseResultPageDimension() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyListResponseResultPageDimension(
        VerifyListResponseResultPageDimension verifyListResponseResultPageDimension
    )
        : base(verifyListResponseResultPageDimension) { }
#pragma warning restore CS8618

    public VerifyListResponseResultPageDimension(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyListResponseResultPageDimension(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyListResponseResultPageDimensionFromRaw.FromRawUnchecked"/>
    public static VerifyListResponseResultPageDimension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyListResponseResultPageDimensionFromRaw
    : IFromRawJson<VerifyListResponseResultPageDimension>
{
    /// <inheritdoc/>
    public VerifyListResponseResultPageDimension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyListResponseResultPageDimension.FromRawUnchecked(rawData);
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
        VerifyListResponseResultSuspectRegion,
        VerifyListResponseResultSuspectRegionFromRaw
    >)
)]
public sealed record class VerifyListResponseResultSuspectRegion : JsonModel
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

    public VerifyListResponseResultSuspectRegion() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyListResponseResultSuspectRegion(
        VerifyListResponseResultSuspectRegion verifyListResponseResultSuspectRegion
    )
        : base(verifyListResponseResultSuspectRegion) { }
#pragma warning restore CS8618

    public VerifyListResponseResultSuspectRegion(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyListResponseResultSuspectRegion(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyListResponseResultSuspectRegionFromRaw.FromRawUnchecked"/>
    public static VerifyListResponseResultSuspectRegion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyListResponseResultSuspectRegionFromRaw
    : IFromRawJson<VerifyListResponseResultSuspectRegion>
{
    /// <inheritdoc/>
    public VerifyListResponseResultSuspectRegion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyListResponseResultSuspectRegion.FromRawUnchecked(rawData);
}
