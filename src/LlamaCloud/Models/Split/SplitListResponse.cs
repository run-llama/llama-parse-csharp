using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using Split = LlamaCloud.Models.Beta.Split;

namespace LlamaCloud.Models.Split;

/// <summary>
/// A split job.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SplitListResponse, SplitListResponseFromRaw>))]
public sealed record class SplitListResponse : JsonModel
{
    /// <summary>
    /// Unique identifier for the split job.
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
    /// Categories used for splitting.
    /// </summary>
    public required IReadOnlyList<Split::SplitCategory> Categories
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Split::SplitCategory>>(
                "categories"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<Split::SplitCategory>>(
                "categories",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether the input was a file or parse job
    /// </summary>
    public required ApiEnum<string, SplitListResponseDocumentInputType> DocumentInputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SplitListResponseDocumentInputType>
            >("document_input_type");
        }
        init { this._rawData.Set("document_input_type", value); }
    }

    /// <summary>
    /// File ID or parse job ID
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
    /// Project this job belongs to.
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
    /// Current job status. Valid values are: pending, processing, completed, failed, cancelled.
    /// </summary>
    public required string Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// User who created this job.
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
    /// Split version used for this job.
    /// </summary>
    public required string Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    /// <summary>
    /// Split configuration ID used for this job.
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
    /// Error message if the job failed.
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
    /// Saved parse configuration ID requested for this job, if any.
    /// </summary>
    public string? ParseConfigID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parse_config_id");
        }
        init { this._rawData.Set("parse_config_id", value); }
    }

    /// <summary>
    /// Parse tier requested for this job, if any.
    /// </summary>
    public string? ParseTier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parse_tier");
        }
        init { this._rawData.Set("parse_tier", value); }
    }

    /// <summary>
    /// Result of a completed split job.
    /// </summary>
    public Split::SplitResultResponse? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Split::SplitResultResponse>("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <summary>
    /// Strategy used for splitting.
    /// </summary>
    public SplitListResponseSplittingStrategy? SplittingStrategy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SplitListResponseSplittingStrategy>(
                "splitting_strategy"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("splitting_strategy", value);
        }
    }

    /// <summary>
    /// Page selection requested for this job, if any.
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
    /// Idempotency key scoped to the project, if one was provided.
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

    /// <summary>
    /// Advisory findings about the categories this job uses; empty when none.
    /// </summary>
    public IReadOnlyList<SplitListResponseWarning>? Warnings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SplitListResponseWarning>>(
                "warnings"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SplitListResponseWarning>?>(
                "warnings",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Categories)
        {
            item.Validate();
        }
        this.DocumentInputType.Validate();
        _ = this.FileInput;
        _ = this.ProjectID;
        _ = this.Status;
        _ = this.UserID;
        _ = this.Version;
        _ = this.ConfigurationID;
        _ = this.CreatedAt;
        _ = this.ErrorMessage;
        _ = this.ParseConfigID;
        _ = this.ParseTier;
        this.Result?.Validate();
        this.SplittingStrategy?.Validate();
        _ = this.TargetPages;
        _ = this.TransactionID;
        _ = this.UpdatedAt;
        foreach (var item in this.Warnings ?? [])
        {
            item.Validate();
        }
    }

    public SplitListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitListResponse(SplitListResponse splitListResponse)
        : base(splitListResponse) { }
#pragma warning restore CS8618

    public SplitListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitListResponseFromRaw.FromRawUnchecked"/>
    public static SplitListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SplitListResponseFromRaw : IFromRawJson<SplitListResponse>
{
    /// <inheritdoc/>
    public SplitListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SplitListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the input was a file or parse job
/// </summary>
[JsonConverter(typeof(SplitListResponseDocumentInputTypeConverter))]
public enum SplitListResponseDocumentInputType
{
    FileID,
    ParseJobID,
    Url,
}

sealed class SplitListResponseDocumentInputTypeConverter
    : JsonConverter<SplitListResponseDocumentInputType>
{
    public override SplitListResponseDocumentInputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file_id" => SplitListResponseDocumentInputType.FileID,
            "parse_job_id" => SplitListResponseDocumentInputType.ParseJobID,
            "url" => SplitListResponseDocumentInputType.Url,
            _ => (SplitListResponseDocumentInputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SplitListResponseDocumentInputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SplitListResponseDocumentInputType.FileID => "file_id",
                SplitListResponseDocumentInputType.ParseJobID => "parse_job_id",
                SplitListResponseDocumentInputType.Url => "url",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Strategy used for splitting.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SplitListResponseSplittingStrategy,
        SplitListResponseSplittingStrategyFromRaw
    >)
)]
public sealed record class SplitListResponseSplittingStrategy : JsonModel
{
    /// <summary>
    /// Controls handling of pages that don't match any category. 'include': pages
    /// can be grouped as 'uncategorized' and included in results. 'forbid': all
    /// pages must be assigned to a defined category. 'omit': pages can be classified
    /// as 'uncategorized' but are excluded from results.
    /// </summary>
    public ApiEnum<string, SplitListResponseSplittingStrategyAllowUncategorized>? AllowUncategorized
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SplitListResponseSplittingStrategyAllowUncategorized>
            >("allow_uncategorized");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_uncategorized", value);
        }
    }

    /// <summary>
    /// Free-form guidance for where segment boundaries are placed.
    /// </summary>
    public string? CustomInstructions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("custom_instructions");
        }
        init { this._rawData.Set("custom_instructions", value); }
    }

    /// <summary>
    /// Minimum pages per segment. Shorter segments are merged into an adjacent segment;
    /// 1 disables merging.
    /// </summary>
    public long? MinPagesPerSplit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("min_pages_per_split");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("min_pages_per_split", value);
        }
    }

    /// <summary>
    /// Where a new segment starts: document at each new document, category wherever
    /// the category changes. Unset means document. category requires version 1.3.0
    /// or later.
    /// </summary>
    public ApiEnum<string, SplitListResponseSplittingStrategySegmentBoundary>? SegmentBoundary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SplitListResponseSplittingStrategySegmentBoundary>
            >("segment_boundary");
        }
        init { this._rawData.Set("segment_boundary", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AllowUncategorized?.Validate();
        _ = this.CustomInstructions;
        _ = this.MinPagesPerSplit;
        this.SegmentBoundary?.Validate();
    }

    public SplitListResponseSplittingStrategy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitListResponseSplittingStrategy(
        SplitListResponseSplittingStrategy splitListResponseSplittingStrategy
    )
        : base(splitListResponseSplittingStrategy) { }
#pragma warning restore CS8618

    public SplitListResponseSplittingStrategy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitListResponseSplittingStrategy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitListResponseSplittingStrategyFromRaw.FromRawUnchecked"/>
    public static SplitListResponseSplittingStrategy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SplitListResponseSplittingStrategyFromRaw : IFromRawJson<SplitListResponseSplittingStrategy>
{
    /// <inheritdoc/>
    public SplitListResponseSplittingStrategy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SplitListResponseSplittingStrategy.FromRawUnchecked(rawData);
}

/// <summary>
/// Controls handling of pages that don't match any category. 'include': pages can
/// be grouped as 'uncategorized' and included in results. 'forbid': all pages must
/// be assigned to a defined category. 'omit': pages can be classified as 'uncategorized'
/// but are excluded from results.
/// </summary>
[JsonConverter(typeof(SplitListResponseSplittingStrategyAllowUncategorizedConverter))]
public enum SplitListResponseSplittingStrategyAllowUncategorized
{
    Forbid,
    Include,
    Omit,
}

sealed class SplitListResponseSplittingStrategyAllowUncategorizedConverter
    : JsonConverter<SplitListResponseSplittingStrategyAllowUncategorized>
{
    public override SplitListResponseSplittingStrategyAllowUncategorized Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "forbid" => SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
            "include" => SplitListResponseSplittingStrategyAllowUncategorized.Include,
            "omit" => SplitListResponseSplittingStrategyAllowUncategorized.Omit,
            _ => (SplitListResponseSplittingStrategyAllowUncategorized)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SplitListResponseSplittingStrategyAllowUncategorized value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SplitListResponseSplittingStrategyAllowUncategorized.Forbid => "forbid",
                SplitListResponseSplittingStrategyAllowUncategorized.Include => "include",
                SplitListResponseSplittingStrategyAllowUncategorized.Omit => "omit",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Where a new segment starts: document at each new document, category wherever
/// the category changes. Unset means document. category requires version 1.3.0 or later.
/// </summary>
[JsonConverter(typeof(SplitListResponseSplittingStrategySegmentBoundaryConverter))]
public enum SplitListResponseSplittingStrategySegmentBoundary
{
    Category,
    Document,
}

sealed class SplitListResponseSplittingStrategySegmentBoundaryConverter
    : JsonConverter<SplitListResponseSplittingStrategySegmentBoundary>
{
    public override SplitListResponseSplittingStrategySegmentBoundary Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "category" => SplitListResponseSplittingStrategySegmentBoundary.Category,
            "document" => SplitListResponseSplittingStrategySegmentBoundary.Document,
            _ => (SplitListResponseSplittingStrategySegmentBoundary)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SplitListResponseSplittingStrategySegmentBoundary value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SplitListResponseSplittingStrategySegmentBoundary.Category => "category",
                SplitListResponseSplittingStrategySegmentBoundary.Document => "document",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Advisory finding about split categories; the job still runs.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SplitListResponseWarning, SplitListResponseWarningFromRaw>)
)]
public sealed record class SplitListResponseWarning : JsonModel
{
    /// <summary>
    /// Names of the categories the warning concerns.
    /// </summary>
    public required IReadOnlyList<string> CategoryNames
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("category_names");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "category_names",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Rule that produced the warning.
    /// </summary>
    public required ApiEnum<string, SplitListResponseWarningCode> Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SplitListResponseWarningCode>>(
                "code"
            );
        }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// What is ambiguous and how to fix it.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CategoryNames;
        this.Code.Validate();
        _ = this.Message;
    }

    public SplitListResponseWarning() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitListResponseWarning(SplitListResponseWarning splitListResponseWarning)
        : base(splitListResponseWarning) { }
#pragma warning restore CS8618

    public SplitListResponseWarning(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitListResponseWarning(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitListResponseWarningFromRaw.FromRawUnchecked"/>
    public static SplitListResponseWarning FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SplitListResponseWarningFromRaw : IFromRawJson<SplitListResponseWarning>
{
    /// <inheritdoc/>
    public SplitListResponseWarning FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SplitListResponseWarning.FromRawUnchecked(rawData);
}

/// <summary>
/// Rule that produced the warning.
/// </summary>
[JsonConverter(typeof(SplitListResponseWarningCodeConverter))]
public enum SplitListResponseWarningCode
{
    CatchAllCategory,
    MissingDescription,
    NearDuplicateDescription,
    NearDuplicateName,
}

sealed class SplitListResponseWarningCodeConverter : JsonConverter<SplitListResponseWarningCode>
{
    public override SplitListResponseWarningCode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "catch_all_category" => SplitListResponseWarningCode.CatchAllCategory,
            "missing_description" => SplitListResponseWarningCode.MissingDescription,
            "near_duplicate_description" => SplitListResponseWarningCode.NearDuplicateDescription,
            "near_duplicate_name" => SplitListResponseWarningCode.NearDuplicateName,
            _ => (SplitListResponseWarningCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SplitListResponseWarningCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SplitListResponseWarningCode.CatchAllCategory => "catch_all_category",
                SplitListResponseWarningCode.MissingDescription => "missing_description",
                SplitListResponseWarningCode.NearDuplicateDescription =>
                    "near_duplicate_description",
                SplitListResponseWarningCode.NearDuplicateName => "near_duplicate_name",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
