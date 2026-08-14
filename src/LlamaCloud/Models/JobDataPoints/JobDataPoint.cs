using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.JobDataPoints;

/// <summary>
/// A job data point.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JobDataPoint, JobDataPointFromRaw>))]
public sealed record class JobDataPoint : JsonModel
{
    /// <summary>
    /// Job ID.
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
    /// Created timestamp.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Custom tag.
    /// </summary>
    public required string CustomTag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("custom_tag");
        }
        init { this._rawData.Set("custom_tag", value); }
    }

    /// <summary>
    /// Project ID.
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
    /// Job status.
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
    /// Updated timestamp.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Error message, if any.
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
    /// Job state transition timestamps.
    /// </summary>
    public StateTransitions? StateTransitions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StateTransitions>("state_transitions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("state_transitions", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.CustomTag;
        _ = this.ProjectID;
        _ = this.Status;
        _ = this.UpdatedAt;
        _ = this.ErrorMessage;
        this.StateTransitions?.Validate();
    }

    public JobDataPoint() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobDataPoint(JobDataPoint jobDataPoint)
        : base(jobDataPoint) { }
#pragma warning restore CS8618

    public JobDataPoint(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JobDataPoint(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JobDataPointFromRaw.FromRawUnchecked"/>
    public static JobDataPoint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JobDataPointFromRaw : IFromRawJson<JobDataPoint>
{
    /// <inheritdoc/>
    public JobDataPoint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JobDataPoint.FromRawUnchecked(rawData);
}

/// <summary>
/// Job state transition timestamps.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StateTransitions, StateTransitionsFromRaw>))]
public sealed record class StateTransitions : JsonModel
{
    public DateTimeOffset? CancelledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("cancelled_at");
        }
        init { this._rawData.Set("cancelled_at", value); }
    }

    public DateTimeOffset? CompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("completed_at");
        }
        init { this._rawData.Set("completed_at", value); }
    }

    public DateTimeOffset? FailedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("failed_at");
        }
        init { this._rawData.Set("failed_at", value); }
    }

    public DateTimeOffset? PendingAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("pending_at");
        }
        init { this._rawData.Set("pending_at", value); }
    }

    public DateTimeOffset? RunningAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("running_at");
        }
        init { this._rawData.Set("running_at", value); }
    }

    public DateTimeOffset? ThrottledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("throttled_at");
        }
        init { this._rawData.Set("throttled_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CancelledAt;
        _ = this.CompletedAt;
        _ = this.FailedAt;
        _ = this.PendingAt;
        _ = this.RunningAt;
        _ = this.ThrottledAt;
    }

    public StateTransitions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StateTransitions(StateTransitions stateTransitions)
        : base(stateTransitions) { }
#pragma warning restore CS8618

    public StateTransitions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StateTransitions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StateTransitionsFromRaw.FromRawUnchecked"/>
    public static StateTransitions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StateTransitionsFromRaw : IFromRawJson<StateTransitions>
{
    /// <inheritdoc/>
    public StateTransitions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        StateTransitions.FromRawUnchecked(rawData);
}
