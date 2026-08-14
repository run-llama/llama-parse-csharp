using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using Split = LlamaIndex.LlamaCloud.Models.Beta.Split;

namespace LlamaIndex.LlamaCloud.Models.Split;

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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AllowUncategorized?.Validate();
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
