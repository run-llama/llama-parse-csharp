using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Beta.Split;

/// <summary>
/// Beta response — uses nested document_input object.
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
    /// Document that was split.
    /// </summary>
    public required SplitDocumentInput DocumentInput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SplitDocumentInput>("document_input");
        }
        init { this._rawData.Set("document_input", value); }
    }

    /// <summary>
    /// Project ID this job belongs to.
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
    /// Current status of the job. Valid values are: pending, processing, completed,
    /// failed, cancelled.
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
    /// User ID who created this job.
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
        this.DocumentInput.Validate();
        _ = this.ProjectID;
        _ = this.Status;
        _ = this.UserID;
        _ = this.ConfigurationID;
        _ = this.CreatedAt;
        _ = this.ErrorMessage;
        this.Result?.Validate();
        _ = this.UpdatedAt;
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
