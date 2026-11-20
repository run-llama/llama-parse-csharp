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
[JsonConverter(typeof(JsonModelConverter<SplitGetResponse, SplitGetResponseFromRaw>))]
public sealed record class SplitGetResponse : JsonModel
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
    public required ApiEnum<string, SplitGetResponseDocumentInputType> DocumentInputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SplitGetResponseDocumentInputType>
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
    public SplitGetResponseSplittingStrategy? SplittingStrategy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SplitGetResponseSplittingStrategy>(
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
    public IReadOnlyList<SplitGetResponseWarning>? Warnings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SplitGetResponseWarning>>(
                "warnings"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SplitGetResponseWarning>?>(
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

    public SplitGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitGetResponse(SplitGetResponse splitGetResponse)
        : base(splitGetResponse) { }
#pragma warning restore CS8618

    public SplitGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitGetResponseFromRaw.FromRawUnchecked"/>
    public static SplitGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SplitGetResponseFromRaw : IFromRawJson<SplitGetResponse>
{
    /// <inheritdoc/>
    public SplitGetResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SplitGetResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the input was a file or parse job
/// </summary>
[JsonConverter(typeof(SplitGetResponseDocumentInputTypeConverter))]
public enum SplitGetResponseDocumentInputType
{
    FileID,
    ParseJobID,
    Url,
}

sealed class SplitGetResponseDocumentInputTypeConverter
    : JsonConverter<SplitGetResponseDocumentInputType>
{
    public override SplitGetResponseDocumentInputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file_id" => SplitGetResponseDocumentInputType.FileID,
            "parse_job_id" => SplitGetResponseDocumentInputType.ParseJobID,
            "url" => SplitGetResponseDocumentInputType.Url,
            _ => (SplitGetResponseDocumentInputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SplitGetResponseDocumentInputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SplitGetResponseDocumentInputType.FileID => "file_id",
                SplitGetResponseDocumentInputType.ParseJobID => "parse_job_id",
                SplitGetResponseDocumentInputType.Url => "url",
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
        SplitGetResponseSplittingStrategy,
        SplitGetResponseSplittingStrategyFromRaw
    >)
)]
public sealed record class SplitGetResponseSplittingStrategy : JsonModel
{
    /// <summary>
    /// Controls handling of pages that don't match any category. 'include': pages
    /// can be grouped as 'uncategorized' and included in results. 'forbid': all
    /// pages must be assigned to a defined category. 'omit': pages can be classified
    /// as 'uncategorized' but are excluded from results.
    /// </summary>
    public ApiEnum<string, SplitGetResponseSplittingStrategyAllowUncategorized>? AllowUncategorized
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SplitGetResponseSplittingStrategyAllowUncategorized>
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
    public ApiEnum<string, SplitGetResponseSplittingStrategySegmentBoundary>? SegmentBoundary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SplitGetResponseSplittingStrategySegmentBoundary>
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

    public SplitGetResponseSplittingStrategy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitGetResponseSplittingStrategy(
        SplitGetResponseSplittingStrategy splitGetResponseSplittingStrategy
    )
        : base(splitGetResponseSplittingStrategy) { }
#pragma warning restore CS8618

    public SplitGetResponseSplittingStrategy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitGetResponseSplittingStrategy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitGetResponseSplittingStrategyFromRaw.FromRawUnchecked"/>
    public static SplitGetResponseSplittingStrategy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SplitGetResponseSplittingStrategyFromRaw : IFromRawJson<SplitGetResponseSplittingStrategy>
{
    /// <inheritdoc/>
    public SplitGetResponseSplittingStrategy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SplitGetResponseSplittingStrategy.FromRawUnchecked(rawData);
}

/// <summary>
/// Controls handling of pages that don't match any category. 'include': pages can
/// be grouped as 'uncategorized' and included in results. 'forbid': all pages must
/// be assigned to a defined category. 'omit': pages can be classified as 'uncategorized'
/// but are excluded from results.
/// </summary>
[JsonConverter(typeof(SplitGetResponseSplittingStrategyAllowUncategorizedConverter))]
public enum SplitGetResponseSplittingStrategyAllowUncategorized
{
    Forbid,
    Include,
    Omit,
}

sealed class SplitGetResponseSplittingStrategyAllowUncategorizedConverter
    : JsonConverter<SplitGetResponseSplittingStrategyAllowUncategorized>
{
    public override SplitGetResponseSplittingStrategyAllowUncategorized Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "forbid" => SplitGetResponseSplittingStrategyAllowUncategorized.Forbid,
            "include" => SplitGetResponseSplittingStrategyAllowUncategorized.Include,
            "omit" => SplitGetResponseSplittingStrategyAllowUncategorized.Omit,
            _ => (SplitGetResponseSplittingStrategyAllowUncategorized)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SplitGetResponseSplittingStrategyAllowUncategorized value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SplitGetResponseSplittingStrategyAllowUncategorized.Forbid => "forbid",
                SplitGetResponseSplittingStrategyAllowUncategorized.Include => "include",
                SplitGetResponseSplittingStrategyAllowUncategorized.Omit => "omit",
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
[JsonConverter(typeof(SplitGetResponseSplittingStrategySegmentBoundaryConverter))]
public enum SplitGetResponseSplittingStrategySegmentBoundary
{
    Category,
    Document,
}

sealed class SplitGetResponseSplittingStrategySegmentBoundaryConverter
    : JsonConverter<SplitGetResponseSplittingStrategySegmentBoundary>
{
    public override SplitGetResponseSplittingStrategySegmentBoundary Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "category" => SplitGetResponseSplittingStrategySegmentBoundary.Category,
            "document" => SplitGetResponseSplittingStrategySegmentBoundary.Document,
            _ => (SplitGetResponseSplittingStrategySegmentBoundary)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SplitGetResponseSplittingStrategySegmentBoundary value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SplitGetResponseSplittingStrategySegmentBoundary.Category => "category",
                SplitGetResponseSplittingStrategySegmentBoundary.Document => "document",
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
[JsonConverter(typeof(JsonModelConverter<SplitGetResponseWarning, SplitGetResponseWarningFromRaw>))]
public sealed record class SplitGetResponseWarning : JsonModel
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
    public required ApiEnum<string, SplitGetResponseWarningCode> Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SplitGetResponseWarningCode>>(
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

    public SplitGetResponseWarning() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitGetResponseWarning(SplitGetResponseWarning splitGetResponseWarning)
        : base(splitGetResponseWarning) { }
#pragma warning restore CS8618

    public SplitGetResponseWarning(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitGetResponseWarning(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitGetResponseWarningFromRaw.FromRawUnchecked"/>
    public static SplitGetResponseWarning FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SplitGetResponseWarningFromRaw : IFromRawJson<SplitGetResponseWarning>
{
    /// <inheritdoc/>
    public SplitGetResponseWarning FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SplitGetResponseWarning.FromRawUnchecked(rawData);
}

/// <summary>
/// Rule that produced the warning.
/// </summary>
[JsonConverter(typeof(SplitGetResponseWarningCodeConverter))]
public enum SplitGetResponseWarningCode
{
    CatchAllCategory,
    MissingDescription,
    NearDuplicateDescription,
    NearDuplicateName,
}

sealed class SplitGetResponseWarningCodeConverter : JsonConverter<SplitGetResponseWarningCode>
{
    public override SplitGetResponseWarningCode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "catch_all_category" => SplitGetResponseWarningCode.CatchAllCategory,
            "missing_description" => SplitGetResponseWarningCode.MissingDescription,
            "near_duplicate_description" => SplitGetResponseWarningCode.NearDuplicateDescription,
            "near_duplicate_name" => SplitGetResponseWarningCode.NearDuplicateName,
            _ => (SplitGetResponseWarningCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SplitGetResponseWarningCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SplitGetResponseWarningCode.CatchAllCategory => "catch_all_category",
                SplitGetResponseWarningCode.MissingDescription => "missing_description",
                SplitGetResponseWarningCode.NearDuplicateDescription =>
                    "near_duplicate_description",
                SplitGetResponseWarningCode.NearDuplicateName => "near_duplicate_name",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
