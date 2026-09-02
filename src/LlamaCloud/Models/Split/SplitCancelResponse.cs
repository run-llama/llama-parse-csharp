using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Beta.Split;

namespace LlamaCloud.Models.Split;

/// <summary>
/// A split job.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SplitCancelResponse, SplitCancelResponseFromRaw>))]
public sealed record class SplitCancelResponse : JsonModel
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
    public required IReadOnlyList<SplitCategory> Categories
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SplitCategory>>("categories");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SplitCategory>>(
                "categories",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether the input was a file or parse job
    /// </summary>
    public required ApiEnum<string, SplitCancelResponseDocumentInputType> DocumentInputType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SplitCancelResponseDocumentInputType>
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
    /// Result of a completed split job.
    /// </summary>
    public SplitResultResponse? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SplitResultResponse>("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <summary>
    /// Strategy used for splitting.
    /// </summary>
    public SplitCancelResponseSplittingStrategy? SplittingStrategy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SplitCancelResponseSplittingStrategy>(
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
        _ = this.ConfigurationID;
        _ = this.CreatedAt;
        _ = this.ErrorMessage;
        this.Result?.Validate();
        this.SplittingStrategy?.Validate();
        _ = this.TransactionID;
        _ = this.UpdatedAt;
    }

    public SplitCancelResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitCancelResponse(SplitCancelResponse splitCancelResponse)
        : base(splitCancelResponse) { }
#pragma warning restore CS8618

    public SplitCancelResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitCancelResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitCancelResponseFromRaw.FromRawUnchecked"/>
    public static SplitCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SplitCancelResponseFromRaw : IFromRawJson<SplitCancelResponse>
{
    /// <inheritdoc/>
    public SplitCancelResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SplitCancelResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the input was a file or parse job
/// </summary>
[JsonConverter(typeof(SplitCancelResponseDocumentInputTypeConverter))]
public enum SplitCancelResponseDocumentInputType
{
    FileID,
    ParseJobID,
    Url,
}

sealed class SplitCancelResponseDocumentInputTypeConverter
    : JsonConverter<SplitCancelResponseDocumentInputType>
{
    public override SplitCancelResponseDocumentInputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file_id" => SplitCancelResponseDocumentInputType.FileID,
            "parse_job_id" => SplitCancelResponseDocumentInputType.ParseJobID,
            "url" => SplitCancelResponseDocumentInputType.Url,
            _ => (SplitCancelResponseDocumentInputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SplitCancelResponseDocumentInputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SplitCancelResponseDocumentInputType.FileID => "file_id",
                SplitCancelResponseDocumentInputType.ParseJobID => "parse_job_id",
                SplitCancelResponseDocumentInputType.Url => "url",
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
        SplitCancelResponseSplittingStrategy,
        SplitCancelResponseSplittingStrategyFromRaw
    >)
)]
public sealed record class SplitCancelResponseSplittingStrategy : JsonModel
{
    /// <summary>
    /// Controls handling of pages that don't match any category. 'include': pages
    /// can be grouped as 'uncategorized' and included in results. 'forbid': all
    /// pages must be assigned to a defined category. 'omit': pages can be classified
    /// as 'uncategorized' but are excluded from results.
    /// </summary>
    public ApiEnum<
        string,
        SplitCancelResponseSplittingStrategyAllowUncategorized
    >? AllowUncategorized
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SplitCancelResponseSplittingStrategyAllowUncategorized>
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AllowUncategorized?.Validate();
        _ = this.CustomInstructions;
        _ = this.MinPagesPerSplit;
    }

    public SplitCancelResponseSplittingStrategy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitCancelResponseSplittingStrategy(
        SplitCancelResponseSplittingStrategy splitCancelResponseSplittingStrategy
    )
        : base(splitCancelResponseSplittingStrategy) { }
#pragma warning restore CS8618

    public SplitCancelResponseSplittingStrategy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitCancelResponseSplittingStrategy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitCancelResponseSplittingStrategyFromRaw.FromRawUnchecked"/>
    public static SplitCancelResponseSplittingStrategy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SplitCancelResponseSplittingStrategyFromRaw
    : IFromRawJson<SplitCancelResponseSplittingStrategy>
{
    /// <inheritdoc/>
    public SplitCancelResponseSplittingStrategy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SplitCancelResponseSplittingStrategy.FromRawUnchecked(rawData);
}

/// <summary>
/// Controls handling of pages that don't match any category. 'include': pages can
/// be grouped as 'uncategorized' and included in results. 'forbid': all pages must
/// be assigned to a defined category. 'omit': pages can be classified as 'uncategorized'
/// but are excluded from results.
/// </summary>
[JsonConverter(typeof(SplitCancelResponseSplittingStrategyAllowUncategorizedConverter))]
public enum SplitCancelResponseSplittingStrategyAllowUncategorized
{
    Forbid,
    Include,
    Omit,
}

sealed class SplitCancelResponseSplittingStrategyAllowUncategorizedConverter
    : JsonConverter<SplitCancelResponseSplittingStrategyAllowUncategorized>
{
    public override SplitCancelResponseSplittingStrategyAllowUncategorized Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "forbid" => SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
            "include" => SplitCancelResponseSplittingStrategyAllowUncategorized.Include,
            "omit" => SplitCancelResponseSplittingStrategyAllowUncategorized.Omit,
            _ => (SplitCancelResponseSplittingStrategyAllowUncategorized)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SplitCancelResponseSplittingStrategyAllowUncategorized value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid => "forbid",
                SplitCancelResponseSplittingStrategyAllowUncategorized.Include => "include",
                SplitCancelResponseSplittingStrategyAllowUncategorized.Omit => "omit",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
