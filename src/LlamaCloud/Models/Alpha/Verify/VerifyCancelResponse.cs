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
[JsonConverter(typeof(JsonModelConverter<VerifyCancelResponse, VerifyCancelResponseFromRaw>))]
public sealed record class VerifyCancelResponse : JsonModel
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
    public required VerifyCancelResponseConfiguration Configuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VerifyCancelResponseConfiguration>(
                "configuration"
            );
        }
        init { this._rawData.Set("configuration", value); }
    }

    /// <summary>
    /// Type of the document input (FILE)
    /// </summary>
    public required ApiEnum<string, VerifyCancelResponseDocumentInputType> DocumentInputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, VerifyCancelResponseDocumentInputType>
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
    public required ApiEnum<string, VerifyCancelResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VerifyCancelResponseStatus>>(
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
    public VerifyCancelResponseResult? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyCancelResponseResult>("result");
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

    public VerifyCancelResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyCancelResponse(VerifyCancelResponse verifyCancelResponse)
        : base(verifyCancelResponse) { }
#pragma warning restore CS8618

    public VerifyCancelResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyCancelResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyCancelResponseFromRaw.FromRawUnchecked"/>
    public static VerifyCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyCancelResponseFromRaw : IFromRawJson<VerifyCancelResponse>
{
    /// <inheritdoc/>
    public VerifyCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyCancelResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Verify configuration used for this job
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyCancelResponseConfiguration,
        VerifyCancelResponseConfigurationFromRaw
    >)
)]
public sealed record class VerifyCancelResponseConfiguration : JsonModel
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
    public ApiEnum<string, VerifyCancelResponseConfigurationTier>? Tier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, VerifyCancelResponseConfigurationTier>
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

    public VerifyCancelResponseConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyCancelResponseConfiguration(
        VerifyCancelResponseConfiguration verifyCancelResponseConfiguration
    )
        : base(verifyCancelResponseConfiguration) { }
#pragma warning restore CS8618

    public VerifyCancelResponseConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyCancelResponseConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyCancelResponseConfigurationFromRaw.FromRawUnchecked"/>
    public static VerifyCancelResponseConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyCancelResponseConfigurationFromRaw : IFromRawJson<VerifyCancelResponseConfiguration>
{
    /// <inheritdoc/>
    public VerifyCancelResponseConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyCancelResponseConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Verify tier: 'fast' runs only the quick deterministic forensic checks (metadata,
/// content integrity, container structure, pixel statistics); 'agentic' (default)
/// runs the full pipeline including the learned detectors and the semantic review pass.
/// </summary>
[JsonConverter(typeof(VerifyCancelResponseConfigurationTierConverter))]
public enum VerifyCancelResponseConfigurationTier
{
    Agentic,
    Fast,
}

sealed class VerifyCancelResponseConfigurationTierConverter
    : JsonConverter<VerifyCancelResponseConfigurationTier>
{
    public override VerifyCancelResponseConfigurationTier Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agentic" => VerifyCancelResponseConfigurationTier.Agentic,
            "fast" => VerifyCancelResponseConfigurationTier.Fast,
            _ => (VerifyCancelResponseConfigurationTier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerifyCancelResponseConfigurationTier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerifyCancelResponseConfigurationTier.Agentic => "agentic",
                VerifyCancelResponseConfigurationTier.Fast => "fast",
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
[JsonConverter(typeof(VerifyCancelResponseDocumentInputTypeConverter))]
public enum VerifyCancelResponseDocumentInputType
{
    FileID,
    ParseJobID,
    Url,
}

sealed class VerifyCancelResponseDocumentInputTypeConverter
    : JsonConverter<VerifyCancelResponseDocumentInputType>
{
    public override VerifyCancelResponseDocumentInputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file_id" => VerifyCancelResponseDocumentInputType.FileID,
            "parse_job_id" => VerifyCancelResponseDocumentInputType.ParseJobID,
            "url" => VerifyCancelResponseDocumentInputType.Url,
            _ => (VerifyCancelResponseDocumentInputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerifyCancelResponseDocumentInputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerifyCancelResponseDocumentInputType.FileID => "file_id",
                VerifyCancelResponseDocumentInputType.ParseJobID => "parse_job_id",
                VerifyCancelResponseDocumentInputType.Url => "url",
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
[JsonConverter(typeof(VerifyCancelResponseStatusConverter))]
public enum VerifyCancelResponseStatus
{
    Cancelled,
    Completed,
    Failed,
    Pending,
    Running,
}

sealed class VerifyCancelResponseStatusConverter : JsonConverter<VerifyCancelResponseStatus>
{
    public override VerifyCancelResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CANCELLED" => VerifyCancelResponseStatus.Cancelled,
            "COMPLETED" => VerifyCancelResponseStatus.Completed,
            "FAILED" => VerifyCancelResponseStatus.Failed,
            "PENDING" => VerifyCancelResponseStatus.Pending,
            "RUNNING" => VerifyCancelResponseStatus.Running,
            _ => (VerifyCancelResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerifyCancelResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerifyCancelResponseStatus.Cancelled => "CANCELLED",
                VerifyCancelResponseStatus.Completed => "COMPLETED",
                VerifyCancelResponseStatus.Failed => "FAILED",
                VerifyCancelResponseStatus.Pending => "PENDING",
                VerifyCancelResponseStatus.Running => "RUNNING",
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
    typeof(JsonModelConverter<VerifyCancelResponseResult, VerifyCancelResponseResultFromRaw>)
)]
public sealed record class VerifyCancelResponseResult : JsonModel
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
    public required ApiEnum<string, VerifyCancelResponseResultVerdict> Verdict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, VerifyCancelResponseResultVerdict>
            >("verdict");
        }
        init { this._rawData.Set("verdict", value); }
    }

    /// <summary>
    /// Composite scores, each answering one question about the document
    /// </summary>
    public VerifyCancelResponseResultCompositeScores? CompositeScores
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyCancelResponseResultCompositeScores>(
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
    public IReadOnlyList<VerifyCancelResponseResultPageDimension>? PageDimensions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<VerifyCancelResponseResultPageDimension>
            >("page_dimensions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<VerifyCancelResponseResultPageDimension>?>(
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
    public IReadOnlyList<VerifyCancelResponseResultSuspectRegion>? SuspectRegions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<VerifyCancelResponseResultSuspectRegion>
            >("suspect_regions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<VerifyCancelResponseResultSuspectRegion>?>(
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

    public VerifyCancelResponseResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyCancelResponseResult(VerifyCancelResponseResult verifyCancelResponseResult)
        : base(verifyCancelResponseResult) { }
#pragma warning restore CS8618

    public VerifyCancelResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyCancelResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyCancelResponseResultFromRaw.FromRawUnchecked"/>
    public static VerifyCancelResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyCancelResponseResultFromRaw : IFromRawJson<VerifyCancelResponseResult>
{
    /// <inheritdoc/>
    public VerifyCancelResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyCancelResponseResult.FromRawUnchecked(rawData);
}

/// <summary>
/// Overall verdict for the document
/// </summary>
[JsonConverter(typeof(VerifyCancelResponseResultVerdictConverter))]
public enum VerifyCancelResponseResultVerdict
{
    Authentic,
    Doctored,
    LikelyDoctored,
    NoStrongSignal,
    Suspicious,
}

sealed class VerifyCancelResponseResultVerdictConverter
    : JsonConverter<VerifyCancelResponseResultVerdict>
{
    public override VerifyCancelResponseResultVerdict Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AUTHENTIC" => VerifyCancelResponseResultVerdict.Authentic,
            "DOCTORED" => VerifyCancelResponseResultVerdict.Doctored,
            "LIKELY_DOCTORED" => VerifyCancelResponseResultVerdict.LikelyDoctored,
            "NO_STRONG_SIGNAL" => VerifyCancelResponseResultVerdict.NoStrongSignal,
            "SUSPICIOUS" => VerifyCancelResponseResultVerdict.Suspicious,
            _ => (VerifyCancelResponseResultVerdict)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerifyCancelResponseResultVerdict value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerifyCancelResponseResultVerdict.Authentic => "AUTHENTIC",
                VerifyCancelResponseResultVerdict.Doctored => "DOCTORED",
                VerifyCancelResponseResultVerdict.LikelyDoctored => "LIKELY_DOCTORED",
                VerifyCancelResponseResultVerdict.NoStrongSignal => "NO_STRONG_SIGNAL",
                VerifyCancelResponseResultVerdict.Suspicious => "SUSPICIOUS",
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
        VerifyCancelResponseResultCompositeScores,
        VerifyCancelResponseResultCompositeScoresFromRaw
    >)
)]
public sealed record class VerifyCancelResponseResultCompositeScores : JsonModel
{
    /// <summary>
    /// Was this content synthesized by a generative model?
    /// </summary>
    public VerifyCancelResponseResultCompositeScoresAIGenerated? AIGenerated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyCancelResponseResultCompositeScoresAIGenerated>(
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
    public VerifyCancelResponseResultCompositeScoresDocumentCoherence? DocumentCoherence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyCancelResponseResultCompositeScoresDocumentCoherence>(
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
    public VerifyCancelResponseResultCompositeScoresDocumentMetadata? DocumentMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyCancelResponseResultCompositeScoresDocumentMetadata>(
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
    public VerifyCancelResponseResultCompositeScoresKnownFraud? KnownFraud
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyCancelResponseResultCompositeScoresKnownFraud>(
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
    public VerifyCancelResponseResultCompositeScoresManuallyEdited? ManuallyEdited
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyCancelResponseResultCompositeScoresManuallyEdited>(
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
    public VerifyCancelResponseResultCompositeScoresRecapture? Recapture
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyCancelResponseResultCompositeScoresRecapture>(
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

    public VerifyCancelResponseResultCompositeScores() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyCancelResponseResultCompositeScores(
        VerifyCancelResponseResultCompositeScores verifyCancelResponseResultCompositeScores
    )
        : base(verifyCancelResponseResultCompositeScores) { }
#pragma warning restore CS8618

    public VerifyCancelResponseResultCompositeScores(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyCancelResponseResultCompositeScores(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyCancelResponseResultCompositeScoresFromRaw.FromRawUnchecked"/>
    public static VerifyCancelResponseResultCompositeScores FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyCancelResponseResultCompositeScoresFromRaw
    : IFromRawJson<VerifyCancelResponseResultCompositeScores>
{
    /// <inheritdoc/>
    public VerifyCancelResponseResultCompositeScores FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyCancelResponseResultCompositeScores.FromRawUnchecked(rawData);
}

/// <summary>
/// Was this content synthesized by a generative model?
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyCancelResponseResultCompositeScoresAIGenerated,
        VerifyCancelResponseResultCompositeScoresAIGeneratedFromRaw
    >)
)]
public sealed record class VerifyCancelResponseResultCompositeScoresAIGenerated : JsonModel
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

    public VerifyCancelResponseResultCompositeScoresAIGenerated() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyCancelResponseResultCompositeScoresAIGenerated(
        VerifyCancelResponseResultCompositeScoresAIGenerated verifyCancelResponseResultCompositeScoresAIGenerated
    )
        : base(verifyCancelResponseResultCompositeScoresAIGenerated) { }
#pragma warning restore CS8618

    public VerifyCancelResponseResultCompositeScoresAIGenerated(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyCancelResponseResultCompositeScoresAIGenerated(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyCancelResponseResultCompositeScoresAIGeneratedFromRaw.FromRawUnchecked"/>
    public static VerifyCancelResponseResultCompositeScoresAIGenerated FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyCancelResponseResultCompositeScoresAIGeneratedFromRaw
    : IFromRawJson<VerifyCancelResponseResultCompositeScoresAIGenerated>
{
    /// <inheritdoc/>
    public VerifyCancelResponseResultCompositeScoresAIGenerated FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyCancelResponseResultCompositeScoresAIGenerated.FromRawUnchecked(rawData);
}

/// <summary>
/// Does the document's content agree with itself (checksums, arithmetic, machine-readable zones)?
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyCancelResponseResultCompositeScoresDocumentCoherence,
        VerifyCancelResponseResultCompositeScoresDocumentCoherenceFromRaw
    >)
)]
public sealed record class VerifyCancelResponseResultCompositeScoresDocumentCoherence : JsonModel
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

    public VerifyCancelResponseResultCompositeScoresDocumentCoherence() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyCancelResponseResultCompositeScoresDocumentCoherence(
        VerifyCancelResponseResultCompositeScoresDocumentCoherence verifyCancelResponseResultCompositeScoresDocumentCoherence
    )
        : base(verifyCancelResponseResultCompositeScoresDocumentCoherence) { }
#pragma warning restore CS8618

    public VerifyCancelResponseResultCompositeScoresDocumentCoherence(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyCancelResponseResultCompositeScoresDocumentCoherence(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyCancelResponseResultCompositeScoresDocumentCoherenceFromRaw.FromRawUnchecked"/>
    public static VerifyCancelResponseResultCompositeScoresDocumentCoherence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyCancelResponseResultCompositeScoresDocumentCoherenceFromRaw
    : IFromRawJson<VerifyCancelResponseResultCompositeScoresDocumentCoherence>
{
    /// <inheritdoc/>
    public VerifyCancelResponseResultCompositeScoresDocumentCoherence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyCancelResponseResultCompositeScoresDocumentCoherence.FromRawUnchecked(rawData);
}

/// <summary>
/// Does the file's provenance / toolchain history look suspicious? Advisory: individually
/// weak workflow-hygiene signals
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyCancelResponseResultCompositeScoresDocumentMetadata,
        VerifyCancelResponseResultCompositeScoresDocumentMetadataFromRaw
    >)
)]
public sealed record class VerifyCancelResponseResultCompositeScoresDocumentMetadata : JsonModel
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

    public VerifyCancelResponseResultCompositeScoresDocumentMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyCancelResponseResultCompositeScoresDocumentMetadata(
        VerifyCancelResponseResultCompositeScoresDocumentMetadata verifyCancelResponseResultCompositeScoresDocumentMetadata
    )
        : base(verifyCancelResponseResultCompositeScoresDocumentMetadata) { }
#pragma warning restore CS8618

    public VerifyCancelResponseResultCompositeScoresDocumentMetadata(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyCancelResponseResultCompositeScoresDocumentMetadata(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyCancelResponseResultCompositeScoresDocumentMetadataFromRaw.FromRawUnchecked"/>
    public static VerifyCancelResponseResultCompositeScoresDocumentMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyCancelResponseResultCompositeScoresDocumentMetadataFromRaw
    : IFromRawJson<VerifyCancelResponseResultCompositeScoresDocumentMetadata>
{
    /// <inheritdoc/>
    public VerifyCancelResponseResultCompositeScoresDocumentMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyCancelResponseResultCompositeScoresDocumentMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Has this asset (or its template) been seen in fraud before?
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyCancelResponseResultCompositeScoresKnownFraud,
        VerifyCancelResponseResultCompositeScoresKnownFraudFromRaw
    >)
)]
public sealed record class VerifyCancelResponseResultCompositeScoresKnownFraud : JsonModel
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

    public VerifyCancelResponseResultCompositeScoresKnownFraud() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyCancelResponseResultCompositeScoresKnownFraud(
        VerifyCancelResponseResultCompositeScoresKnownFraud verifyCancelResponseResultCompositeScoresKnownFraud
    )
        : base(verifyCancelResponseResultCompositeScoresKnownFraud) { }
#pragma warning restore CS8618

    public VerifyCancelResponseResultCompositeScoresKnownFraud(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyCancelResponseResultCompositeScoresKnownFraud(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyCancelResponseResultCompositeScoresKnownFraudFromRaw.FromRawUnchecked"/>
    public static VerifyCancelResponseResultCompositeScoresKnownFraud FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyCancelResponseResultCompositeScoresKnownFraudFromRaw
    : IFromRawJson<VerifyCancelResponseResultCompositeScoresKnownFraud>
{
    /// <inheritdoc/>
    public VerifyCancelResponseResultCompositeScoresKnownFraud FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyCancelResponseResultCompositeScoresKnownFraud.FromRawUnchecked(rawData);
}

/// <summary>
/// Was this document altered after creation (splice, retype, redact, inpaint)?
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyCancelResponseResultCompositeScoresManuallyEdited,
        VerifyCancelResponseResultCompositeScoresManuallyEditedFromRaw
    >)
)]
public sealed record class VerifyCancelResponseResultCompositeScoresManuallyEdited : JsonModel
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

    public VerifyCancelResponseResultCompositeScoresManuallyEdited() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyCancelResponseResultCompositeScoresManuallyEdited(
        VerifyCancelResponseResultCompositeScoresManuallyEdited verifyCancelResponseResultCompositeScoresManuallyEdited
    )
        : base(verifyCancelResponseResultCompositeScoresManuallyEdited) { }
#pragma warning restore CS8618

    public VerifyCancelResponseResultCompositeScoresManuallyEdited(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyCancelResponseResultCompositeScoresManuallyEdited(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyCancelResponseResultCompositeScoresManuallyEditedFromRaw.FromRawUnchecked"/>
    public static VerifyCancelResponseResultCompositeScoresManuallyEdited FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyCancelResponseResultCompositeScoresManuallyEditedFromRaw
    : IFromRawJson<VerifyCancelResponseResultCompositeScoresManuallyEdited>
{
    /// <inheritdoc/>
    public VerifyCancelResponseResultCompositeScoresManuallyEdited FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyCancelResponseResultCompositeScoresManuallyEdited.FromRawUnchecked(rawData);
}

/// <summary>
/// Was the document captured through a channel that destroys forensic evidence (photo
/// of a screen, print-then-rescan)?
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyCancelResponseResultCompositeScoresRecapture,
        VerifyCancelResponseResultCompositeScoresRecaptureFromRaw
    >)
)]
public sealed record class VerifyCancelResponseResultCompositeScoresRecapture : JsonModel
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

    public VerifyCancelResponseResultCompositeScoresRecapture() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyCancelResponseResultCompositeScoresRecapture(
        VerifyCancelResponseResultCompositeScoresRecapture verifyCancelResponseResultCompositeScoresRecapture
    )
        : base(verifyCancelResponseResultCompositeScoresRecapture) { }
#pragma warning restore CS8618

    public VerifyCancelResponseResultCompositeScoresRecapture(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyCancelResponseResultCompositeScoresRecapture(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyCancelResponseResultCompositeScoresRecaptureFromRaw.FromRawUnchecked"/>
    public static VerifyCancelResponseResultCompositeScoresRecapture FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyCancelResponseResultCompositeScoresRecaptureFromRaw
    : IFromRawJson<VerifyCancelResponseResultCompositeScoresRecapture>
{
    /// <inheritdoc/>
    public VerifyCancelResponseResultCompositeScoresRecapture FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyCancelResponseResultCompositeScoresRecapture.FromRawUnchecked(rawData);
}

/// <summary>
/// Rendered pixel size of a page — the coordinate space region bboxes use, so the
/// UI can scale the suspect-region overlay onto the displayed page.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyCancelResponseResultPageDimension,
        VerifyCancelResponseResultPageDimensionFromRaw
    >)
)]
public sealed record class VerifyCancelResponseResultPageDimension : JsonModel
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

    public VerifyCancelResponseResultPageDimension() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyCancelResponseResultPageDimension(
        VerifyCancelResponseResultPageDimension verifyCancelResponseResultPageDimension
    )
        : base(verifyCancelResponseResultPageDimension) { }
#pragma warning restore CS8618

    public VerifyCancelResponseResultPageDimension(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyCancelResponseResultPageDimension(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyCancelResponseResultPageDimensionFromRaw.FromRawUnchecked"/>
    public static VerifyCancelResponseResultPageDimension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyCancelResponseResultPageDimensionFromRaw
    : IFromRawJson<VerifyCancelResponseResultPageDimension>
{
    /// <inheritdoc/>
    public VerifyCancelResponseResultPageDimension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyCancelResponseResultPageDimension.FromRawUnchecked(rawData);
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
        VerifyCancelResponseResultSuspectRegion,
        VerifyCancelResponseResultSuspectRegionFromRaw
    >)
)]
public sealed record class VerifyCancelResponseResultSuspectRegion : JsonModel
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

    public VerifyCancelResponseResultSuspectRegion() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyCancelResponseResultSuspectRegion(
        VerifyCancelResponseResultSuspectRegion verifyCancelResponseResultSuspectRegion
    )
        : base(verifyCancelResponseResultSuspectRegion) { }
#pragma warning restore CS8618

    public VerifyCancelResponseResultSuspectRegion(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyCancelResponseResultSuspectRegion(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyCancelResponseResultSuspectRegionFromRaw.FromRawUnchecked"/>
    public static VerifyCancelResponseResultSuspectRegion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyCancelResponseResultSuspectRegionFromRaw
    : IFromRawJson<VerifyCancelResponseResultSuspectRegion>
{
    /// <inheritdoc/>
    public VerifyCancelResponseResultSuspectRegion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyCancelResponseResultSuspectRegion.FromRawUnchecked(rawData);
}
