using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Classifier.Jobs;

/// <summary>
/// Paginated list of classify jobs.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JobListPageResponse, JobListPageResponseFromRaw>))]
public sealed record class JobListPageResponse : JsonModel
{
    /// <summary>
    /// The list of items.
    /// </summary>
    public required IReadOnlyList<ClassifyJob> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ClassifyJob>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ClassifyJob>>(
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

    public JobListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobListPageResponse(JobListPageResponse jobListPageResponse)
        : base(jobListPageResponse) { }
#pragma warning restore CS8618

    public JobListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JobListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JobListPageResponseFromRaw.FromRawUnchecked"/>
    public static JobListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public JobListPageResponse(IReadOnlyList<ClassifyJob> items)
        : this()
    {
        this.Items = items;
    }
}

class JobListPageResponseFromRaw : IFromRawJson<JobListPageResponse>
{
    /// <inheritdoc/>
    public JobListPageResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JobListPageResponse.FromRawUnchecked(rawData);
}
