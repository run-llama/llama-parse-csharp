using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Beta.Split;

/// <summary>
/// Result of a completed split job.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SplitResultResponse, SplitResultResponseFromRaw>))]
public sealed record class SplitResultResponse : JsonModel
{
    /// <summary>
    /// List of document segments.
    /// </summary>
    public required IReadOnlyList<SplitSegmentResponse> Segments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SplitSegmentResponse>>("segments");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SplitSegmentResponse>>(
                "segments",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Segments)
        {
            item.Validate();
        }
    }

    public SplitResultResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitResultResponse(SplitResultResponse splitResultResponse)
        : base(splitResultResponse) { }
#pragma warning restore CS8618

    public SplitResultResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitResultResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitResultResponseFromRaw.FromRawUnchecked"/>
    public static SplitResultResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SplitResultResponse(IReadOnlyList<SplitSegmentResponse> segments)
        : this()
    {
        this.Segments = segments;
    }
}

class SplitResultResponseFromRaw : IFromRawJson<SplitResultResponse>
{
    /// <inheritdoc/>
    public SplitResultResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SplitResultResponse.FromRawUnchecked(rawData);
}
