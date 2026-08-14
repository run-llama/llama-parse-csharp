using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Beta.Split;

/// <summary>
/// A segment of the split document.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SplitSegmentResponse, SplitSegmentResponseFromRaw>))]
public sealed record class SplitSegmentResponse : JsonModel
{
    /// <summary>
    /// Category name this split belongs to.
    /// </summary>
    public required string Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Categorical confidence level. Valid values are: high, medium, low.
    /// </summary>
    public required string ConfidenceCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("confidence_category");
        }
        init { this._rawData.Set("confidence_category", value); }
    }

    /// <summary>
    /// 1-indexed page numbers in this split.
    /// </summary>
    public required IReadOnlyList<long> Pages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<long>>("pages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<long>>(
                "pages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Category;
        _ = this.ConfidenceCategory;
        _ = this.Pages;
    }

    public SplitSegmentResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitSegmentResponse(SplitSegmentResponse splitSegmentResponse)
        : base(splitSegmentResponse) { }
#pragma warning restore CS8618

    public SplitSegmentResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitSegmentResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitSegmentResponseFromRaw.FromRawUnchecked"/>
    public static SplitSegmentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SplitSegmentResponseFromRaw : IFromRawJson<SplitSegmentResponse>
{
    /// <inheritdoc/>
    public SplitSegmentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SplitSegmentResponse.FromRawUnchecked(rawData);
}
