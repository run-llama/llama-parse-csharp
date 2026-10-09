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
[JsonConverter(typeof(JsonModelConverter<VerifyCreateResponse, VerifyCreateResponseFromRaw>))]
public sealed record class VerifyCreateResponse : JsonModel
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
    public required VerifyCreateResponseConfiguration Configuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VerifyCreateResponseConfiguration>(
                "configuration"
            );
        }
        init { this._rawData.Set("configuration", value); }
    }

    /// <summary>
    /// Type of the document input (FILE)
    /// </summary>
    public required ApiEnum<string, DocumentInputType> DocumentInputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DocumentInputType>>(
                "document_input_type"
            );
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
    public required ApiEnum<string, VerifyCreateResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VerifyCreateResponseStatus>>(
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
    public Result? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Result>("result");
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

    public VerifyCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyCreateResponse(VerifyCreateResponse verifyCreateResponse)
        : base(verifyCreateResponse) { }
#pragma warning restore CS8618

    public VerifyCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyCreateResponseFromRaw.FromRawUnchecked"/>
    public static VerifyCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyCreateResponseFromRaw : IFromRawJson<VerifyCreateResponse>
{
    /// <inheritdoc/>
    public VerifyCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Verify configuration used for this job
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyCreateResponseConfiguration,
        VerifyCreateResponseConfigurationFromRaw
    >)
)]
public sealed record class VerifyCreateResponseConfiguration : JsonModel
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
    public ApiEnum<string, VerifyCreateResponseConfigurationTier>? Tier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, VerifyCreateResponseConfigurationTier>
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

    public VerifyCreateResponseConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyCreateResponseConfiguration(
        VerifyCreateResponseConfiguration verifyCreateResponseConfiguration
    )
        : base(verifyCreateResponseConfiguration) { }
#pragma warning restore CS8618

    public VerifyCreateResponseConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyCreateResponseConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyCreateResponseConfigurationFromRaw.FromRawUnchecked"/>
    public static VerifyCreateResponseConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyCreateResponseConfigurationFromRaw : IFromRawJson<VerifyCreateResponseConfiguration>
{
    /// <inheritdoc/>
    public VerifyCreateResponseConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyCreateResponseConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Verify tier: 'fast' runs only the quick deterministic forensic checks (metadata,
/// content integrity, container structure, pixel statistics); 'agentic' (default)
/// runs the full pipeline including the learned detectors and the semantic review pass.
/// </summary>
[JsonConverter(typeof(VerifyCreateResponseConfigurationTierConverter))]
public enum VerifyCreateResponseConfigurationTier
{
    Agentic,
    Fast,
}

sealed class VerifyCreateResponseConfigurationTierConverter
    : JsonConverter<VerifyCreateResponseConfigurationTier>
{
    public override VerifyCreateResponseConfigurationTier Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agentic" => VerifyCreateResponseConfigurationTier.Agentic,
            "fast" => VerifyCreateResponseConfigurationTier.Fast,
            _ => (VerifyCreateResponseConfigurationTier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerifyCreateResponseConfigurationTier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerifyCreateResponseConfigurationTier.Agentic => "agentic",
                VerifyCreateResponseConfigurationTier.Fast => "fast",
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
[JsonConverter(typeof(DocumentInputTypeConverter))]
public enum DocumentInputType
{
    FileID,
    ParseJobID,
    Url,
}

sealed class DocumentInputTypeConverter : JsonConverter<DocumentInputType>
{
    public override DocumentInputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file_id" => DocumentInputType.FileID,
            "parse_job_id" => DocumentInputType.ParseJobID,
            "url" => DocumentInputType.Url,
            _ => (DocumentInputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DocumentInputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DocumentInputType.FileID => "file_id",
                DocumentInputType.ParseJobID => "parse_job_id",
                DocumentInputType.Url => "url",
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
[JsonConverter(typeof(VerifyCreateResponseStatusConverter))]
public enum VerifyCreateResponseStatus
{
    Cancelled,
    Completed,
    Failed,
    Pending,
    Running,
}

sealed class VerifyCreateResponseStatusConverter : JsonConverter<VerifyCreateResponseStatus>
{
    public override VerifyCreateResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CANCELLED" => VerifyCreateResponseStatus.Cancelled,
            "COMPLETED" => VerifyCreateResponseStatus.Completed,
            "FAILED" => VerifyCreateResponseStatus.Failed,
            "PENDING" => VerifyCreateResponseStatus.Pending,
            "RUNNING" => VerifyCreateResponseStatus.Running,
            _ => (VerifyCreateResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerifyCreateResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerifyCreateResponseStatus.Cancelled => "CANCELLED",
                VerifyCreateResponseStatus.Completed => "COMPLETED",
                VerifyCreateResponseStatus.Failed => "FAILED",
                VerifyCreateResponseStatus.Pending => "PENDING",
                VerifyCreateResponseStatus.Running => "RUNNING",
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
[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
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
    public required ApiEnum<string, Verdict> Verdict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Verdict>>("verdict");
        }
        init { this._rawData.Set("verdict", value); }
    }

    /// <summary>
    /// Composite scores, each answering one question about the document
    /// </summary>
    public CompositeScores? CompositeScores
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CompositeScores>("composite_scores");
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
    public IReadOnlyList<PageDimension>? PageDimensions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PageDimension>>(
                "page_dimensions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<PageDimension>?>(
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
    public IReadOnlyList<SuspectRegion>? SuspectRegions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SuspectRegion>>(
                "suspect_regions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SuspectRegion>?>(
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
}

class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}

/// <summary>
/// Overall verdict for the document
/// </summary>
[JsonConverter(typeof(VerdictConverter))]
public enum Verdict
{
    Authentic,
    Doctored,
    LikelyDoctored,
    NoStrongSignal,
    Suspicious,
}

sealed class VerdictConverter : JsonConverter<Verdict>
{
    public override Verdict Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AUTHENTIC" => Verdict.Authentic,
            "DOCTORED" => Verdict.Doctored,
            "LIKELY_DOCTORED" => Verdict.LikelyDoctored,
            "NO_STRONG_SIGNAL" => Verdict.NoStrongSignal,
            "SUSPICIOUS" => Verdict.Suspicious,
            _ => (Verdict)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Verdict value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Verdict.Authentic => "AUTHENTIC",
                Verdict.Doctored => "DOCTORED",
                Verdict.LikelyDoctored => "LIKELY_DOCTORED",
                Verdict.NoStrongSignal => "NO_STRONG_SIGNAL",
                Verdict.Suspicious => "SUSPICIOUS",
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
[JsonConverter(typeof(JsonModelConverter<CompositeScores, CompositeScoresFromRaw>))]
public sealed record class CompositeScores : JsonModel
{
    /// <summary>
    /// Was this content synthesized by a generative model?
    /// </summary>
    public AIGenerated? AIGenerated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AIGenerated>("ai_generated");
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
    public DocumentCoherence? DocumentCoherence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DocumentCoherence>("document_coherence");
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
    public DocumentMetadata? DocumentMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DocumentMetadata>("document_metadata");
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
    public KnownFraud? KnownFraud
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<KnownFraud>("known_fraud");
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
    public ManuallyEdited? ManuallyEdited
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ManuallyEdited>("manually_edited");
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
    public Recapture? Recapture
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Recapture>("recapture");
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

    public CompositeScores() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CompositeScores(CompositeScores compositeScores)
        : base(compositeScores) { }
#pragma warning restore CS8618

    public CompositeScores(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompositeScores(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompositeScoresFromRaw.FromRawUnchecked"/>
    public static CompositeScores FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CompositeScoresFromRaw : IFromRawJson<CompositeScores>
{
    /// <inheritdoc/>
    public CompositeScores FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CompositeScores.FromRawUnchecked(rawData);
}

/// <summary>
/// Was this content synthesized by a generative model?
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AIGenerated, AIGeneratedFromRaw>))]
public sealed record class AIGenerated : JsonModel
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

    public AIGenerated() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AIGenerated(AIGenerated aiGenerated)
        : base(aiGenerated) { }
#pragma warning restore CS8618

    public AIGenerated(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AIGenerated(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AIGeneratedFromRaw.FromRawUnchecked"/>
    public static AIGenerated FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AIGeneratedFromRaw : IFromRawJson<AIGenerated>
{
    /// <inheritdoc/>
    public AIGenerated FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AIGenerated.FromRawUnchecked(rawData);
}

/// <summary>
/// Does the document's content agree with itself (checksums, arithmetic, machine-readable zones)?
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DocumentCoherence, DocumentCoherenceFromRaw>))]
public sealed record class DocumentCoherence : JsonModel
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

    public DocumentCoherence() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentCoherence(DocumentCoherence documentCoherence)
        : base(documentCoherence) { }
#pragma warning restore CS8618

    public DocumentCoherence(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentCoherence(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocumentCoherenceFromRaw.FromRawUnchecked"/>
    public static DocumentCoherence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DocumentCoherenceFromRaw : IFromRawJson<DocumentCoherence>
{
    /// <inheritdoc/>
    public DocumentCoherence FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DocumentCoherence.FromRawUnchecked(rawData);
}

/// <summary>
/// Does the file's provenance / toolchain history look suspicious? Advisory: individually
/// weak workflow-hygiene signals
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DocumentMetadata, DocumentMetadataFromRaw>))]
public sealed record class DocumentMetadata : JsonModel
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

    public DocumentMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentMetadata(DocumentMetadata documentMetadata)
        : base(documentMetadata) { }
#pragma warning restore CS8618

    public DocumentMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocumentMetadataFromRaw.FromRawUnchecked"/>
    public static DocumentMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DocumentMetadataFromRaw : IFromRawJson<DocumentMetadata>
{
    /// <inheritdoc/>
    public DocumentMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DocumentMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Has this asset (or its template) been seen in fraud before?
/// </summary>
[JsonConverter(typeof(JsonModelConverter<KnownFraud, KnownFraudFromRaw>))]
public sealed record class KnownFraud : JsonModel
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

    public KnownFraud() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public KnownFraud(KnownFraud knownFraud)
        : base(knownFraud) { }
#pragma warning restore CS8618

    public KnownFraud(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    KnownFraud(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="KnownFraudFromRaw.FromRawUnchecked"/>
    public static KnownFraud FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class KnownFraudFromRaw : IFromRawJson<KnownFraud>
{
    /// <inheritdoc/>
    public KnownFraud FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        KnownFraud.FromRawUnchecked(rawData);
}

/// <summary>
/// Was this document altered after creation (splice, retype, redact, inpaint)?
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ManuallyEdited, ManuallyEditedFromRaw>))]
public sealed record class ManuallyEdited : JsonModel
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

    public ManuallyEdited() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ManuallyEdited(ManuallyEdited manuallyEdited)
        : base(manuallyEdited) { }
#pragma warning restore CS8618

    public ManuallyEdited(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ManuallyEdited(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ManuallyEditedFromRaw.FromRawUnchecked"/>
    public static ManuallyEdited FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ManuallyEditedFromRaw : IFromRawJson<ManuallyEdited>
{
    /// <inheritdoc/>
    public ManuallyEdited FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ManuallyEdited.FromRawUnchecked(rawData);
}

/// <summary>
/// Was the document captured through a channel that destroys forensic evidence (photo
/// of a screen, print-then-rescan)?
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Recapture, RecaptureFromRaw>))]
public sealed record class Recapture : JsonModel
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

    public Recapture() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Recapture(Recapture recapture)
        : base(recapture) { }
#pragma warning restore CS8618

    public Recapture(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Recapture(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecaptureFromRaw.FromRawUnchecked"/>
    public static Recapture FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RecaptureFromRaw : IFromRawJson<Recapture>
{
    /// <inheritdoc/>
    public Recapture FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Recapture.FromRawUnchecked(rawData);
}

/// <summary>
/// Rendered pixel size of a page — the coordinate space region bboxes use, so the
/// UI can scale the suspect-region overlay onto the displayed page.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PageDimension, PageDimensionFromRaw>))]
public sealed record class PageDimension : JsonModel
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

    public PageDimension() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PageDimension(PageDimension pageDimension)
        : base(pageDimension) { }
#pragma warning restore CS8618

    public PageDimension(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PageDimension(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PageDimensionFromRaw.FromRawUnchecked"/>
    public static PageDimension FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PageDimensionFromRaw : IFromRawJson<PageDimension>
{
    /// <inheritdoc/>
    public PageDimension FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PageDimension.FromRawUnchecked(rawData);
}

/// <summary>
/// A region that led to the suspected fraud, with why it is suspect.
///
/// <para>A curated, high-signal subset of ``regions``: reviewer-dismissed candidates
/// are dropped and the remainder is ranked by suspicion, so consumers can act on
/// ``verdict`` + ``confidence`` + this list without reading the raw signals.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SuspectRegion, SuspectRegionFromRaw>))]
public sealed record class SuspectRegion : JsonModel
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

    public SuspectRegion() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SuspectRegion(SuspectRegion suspectRegion)
        : base(suspectRegion) { }
#pragma warning restore CS8618

    public SuspectRegion(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SuspectRegion(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SuspectRegionFromRaw.FromRawUnchecked"/>
    public static SuspectRegion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SuspectRegionFromRaw : IFromRawJson<SuspectRegion>
{
    /// <inheritdoc/>
    public SuspectRegion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SuspectRegion.FromRawUnchecked(rawData);
}
