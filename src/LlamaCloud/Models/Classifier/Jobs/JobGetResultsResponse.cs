using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Classifier.Jobs;

/// <summary>
/// Response model for the classify endpoint following AIP-132 pagination standard.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JobGetResultsResponse, JobGetResultsResponseFromRaw>))]
public sealed record class JobGetResultsResponse : JsonModel
{
    /// <summary>
    /// The list of items.
    /// </summary>
    public required IReadOnlyList<Item> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Item>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Item>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A token, which can be sent as page_token to retrieve the next page. If this
    /// field is omitted, there are no subsequent pages.
    /// </summary>
    public string? NextPageToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_page_token");
        }
        init { this._rawData.Set("next_page_token", value); }
    }

    /// <summary>
    /// The total number of items available. This is only populated when specifically
    /// requested. The value may be an estimate and can be used for display purposes only.
    /// </summary>
    public long? TotalSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_size");
        }
        init { this._rawData.Set("total_size", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.NextPageToken;
        _ = this.TotalSize;
    }

    public JobGetResultsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobGetResultsResponse(JobGetResultsResponse jobGetResultsResponse)
        : base(jobGetResultsResponse) { }
#pragma warning restore CS8618

    public JobGetResultsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JobGetResultsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JobGetResultsResponseFromRaw.FromRawUnchecked"/>
    public static JobGetResultsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public JobGetResultsResponse(IReadOnlyList<Item> items)
        : this()
    {
        this.Items = items;
    }
}

class JobGetResultsResponseFromRaw : IFromRawJson<JobGetResultsResponse>
{
    /// <inheritdoc/>
    public JobGetResultsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JobGetResultsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A file classification.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : JsonModel
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
    /// The ID of the classify job
    /// </summary>
    public required string ClassifyJobID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("classify_job_id");
        }
        init { this._rawData.Set("classify_job_id", value); }
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
    /// The ID of the classified file
    /// </summary>
    public string? FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <summary>
    /// Result of classifying a single file.
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
        _ = this.ClassifyJobID;
        _ = this.CreatedAt;
        _ = this.FileID;
        this.Result?.Validate();
        _ = this.UpdatedAt;
    }

    public Item() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Item(Item item)
        : base(item) { }
#pragma warning restore CS8618

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemFromRaw.FromRawUnchecked"/>
    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRawJson<Item>
{
    /// <inheritdoc/>
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}

/// <summary>
/// Result of classifying a single file.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    /// <summary>
    /// Confidence score of the classification (0.0-1.0)
    /// </summary>
    public required double Confidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("confidence");
        }
        init { this._rawData.Set("confidence", value); }
    }

    /// <summary>
    /// Step-by-step explanation of why this classification was chosen and the confidence
    /// score assigned
    /// </summary>
    public required string Reasoning
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reasoning");
        }
        init { this._rawData.Set("reasoning", value); }
    }

    /// <summary>
    /// The document type that best matches, or null if no match.
    /// </summary>
    public required string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Confidence;
        _ = this.Reasoning;
        _ = this.Type;
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
