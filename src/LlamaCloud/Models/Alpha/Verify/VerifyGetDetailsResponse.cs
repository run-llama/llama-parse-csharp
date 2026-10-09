using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Alpha.Verify;

/// <summary>
/// Raw per-signal detail for a completed Verify job.
///
/// <para>Forensic drill-down behind the simplified result: the full evidence list,
/// per-family sub-scores, raw localized regions, and heatmap overlays.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<VerifyGetDetailsResponse, VerifyGetDetailsResponseFromRaw>)
)]
public sealed record class VerifyGetDetailsResponse : JsonModel
{
    /// <summary>
    /// ID of the Verify job
    /// </summary>
    public required string JobID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("job_id");
        }
        init { this._rawData.Set("job_id", value); }
    }

    /// <summary>
    /// Checks that could not run on this job (with the reason). A check listed here
    /// produced no findings because it could not run, not because the document is clean
    /// </summary>
    public IReadOnlyList<DegradedTool>? DegradedTools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DegradedTool>>("degraded_tools");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<DegradedTool>?>(
                "degraded_tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Evidence items produced by detection tools
    /// </summary>
    public IReadOnlyList<Evidence>? Evidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Evidence>>("evidence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Evidence>?>(
                "evidence",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Per-page forensic heatmap overlays as presigned image URLs
    /// </summary>
    public IReadOnlyList<Heatmap>? Heatmaps
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Heatmap>>("heatmaps");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Heatmap>?>(
                "heatmaps",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Rendered pixel size per page, so region bboxes can be scaled onto the page
    /// </summary>
    public IReadOnlyList<VerifyGetDetailsResponsePageDimension>? PageDimensions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<VerifyGetDetailsResponsePageDimension>
            >("page_dimensions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<VerifyGetDetailsResponsePageDimension>?>(
                "page_dimensions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Suspicious regions localized on rendered pages
    /// </summary>
    public IReadOnlyList<Region>? Regions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Region>>("regions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Region>?>(
                "regions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Per-family scores (metadata, ai_generation, splicing, copy_move, compression,
    /// noise, coherence, pdf_structure)
    /// </summary>
    public IReadOnlyDictionary<string, double>? SubScores
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, double>>("sub_scores");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, double>?>(
                "sub_scores",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.JobID;
        foreach (var item in this.DegradedTools ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Evidence ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Heatmaps ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.PageDimensions ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Regions ?? [])
        {
            item.Validate();
        }
        _ = this.SubScores;
    }

    public VerifyGetDetailsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyGetDetailsResponse(VerifyGetDetailsResponse verifyGetDetailsResponse)
        : base(verifyGetDetailsResponse) { }
#pragma warning restore CS8618

    public VerifyGetDetailsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyGetDetailsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyGetDetailsResponseFromRaw.FromRawUnchecked"/>
    public static VerifyGetDetailsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VerifyGetDetailsResponse(string jobID)
        : this()
    {
        this.JobID = jobID;
    }
}

class VerifyGetDetailsResponseFromRaw : IFromRawJson<VerifyGetDetailsResponse>
{
    /// <inheritdoc/>
    public VerifyGetDetailsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyGetDetailsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A check that was attempted but could not run on this job.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DegradedTool, DegradedToolFromRaw>))]
public sealed record class DegradedTool : JsonModel
{
    /// <summary>
    /// Name of the check
    /// </summary>
    public required string Tool
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tool");
        }
        init { this._rawData.Set("tool", value); }
    }

    /// <summary>
    /// Why the check could not run
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Tool;
        _ = this.Reason;
    }

    public DegradedTool() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DegradedTool(DegradedTool degradedTool)
        : base(degradedTool) { }
#pragma warning restore CS8618

    public DegradedTool(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DegradedTool(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DegradedToolFromRaw.FromRawUnchecked"/>
    public static DegradedTool FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DegradedTool(string tool)
        : this()
    {
        this.Tool = tool;
    }
}

class DegradedToolFromRaw : IFromRawJson<DegradedTool>
{
    /// <inheritdoc/>
    public DegradedTool FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DegradedTool.FromRawUnchecked(rawData);
}

/// <summary>
/// A single piece of evidence produced by a detection tool.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Evidence, EvidenceFromRaw>))]
public sealed record class Evidence : JsonModel
{
    /// <summary>
    /// Machine-readable evidence code
    /// </summary>
    public required string Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// Human-readable evidence detail
    /// </summary>
    public required string Detail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("detail");
        }
        init { this._rawData.Set("detail", value); }
    }

    /// <summary>
    /// Signal family (e.g. metadata, splicing, compression)
    /// </summary>
    public required string Family
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("family");
        }
        init { this._rawData.Set("family", value); }
    }

    /// <summary>
    /// Evidence strength score
    /// </summary>
    public required double Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    /// <summary>
    /// Tool that produced this evidence
    /// </summary>
    public required string Tool
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tool");
        }
        init { this._rawData.Set("tool", value); }
    }

    /// <summary>
    /// Tool-specific structured payload
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "data",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Whether this is hard (conclusive) evidence
    /// </summary>
    public bool? Hard
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hard");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hard", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Detail;
        _ = this.Family;
        _ = this.Score;
        _ = this.Tool;
        _ = this.Data;
        _ = this.Hard;
    }

    public Evidence() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Evidence(Evidence evidence)
        : base(evidence) { }
#pragma warning restore CS8618

    public Evidence(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Evidence(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EvidenceFromRaw.FromRawUnchecked"/>
    public static Evidence FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EvidenceFromRaw : IFromRawJson<Evidence>
{
    /// <inheritdoc/>
    public Evidence FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Evidence.FromRawUnchecked(rawData);
}

/// <summary>
/// A per-page forensic heatmap overlay, as a presigned image URL.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Heatmap, HeatmapFromRaw>))]
public sealed record class Heatmap : JsonModel
{
    /// <summary>
    /// The time at which the presigned URL expires
    /// </summary>
    public required DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// Producing signal, e.g. double_compression, ela, noise
    /// </summary>
    public required string Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("kind");
        }
        init { this._rawData.Set("kind", value); }
    }

    /// <summary>
    /// 0-based page index (0 for standalone images)
    /// </summary>
    public required long Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page");
        }
        init { this._rawData.Set("page", value); }
    }

    /// <summary>
    /// Presigned URL to the heatmap PNG (page overlay)
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Producing tool's max score (for ranking)
    /// </summary>
    public double? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("score", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExpiresAt;
        _ = this.Kind;
        _ = this.Page;
        _ = this.Url;
        _ = this.Score;
    }

    public Heatmap() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Heatmap(Heatmap heatmap)
        : base(heatmap) { }
#pragma warning restore CS8618

    public Heatmap(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Heatmap(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HeatmapFromRaw.FromRawUnchecked"/>
    public static Heatmap FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HeatmapFromRaw : IFromRawJson<Heatmap>
{
    /// <inheritdoc/>
    public Heatmap FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Heatmap.FromRawUnchecked(rawData);
}

/// <summary>
/// Rendered pixel size of a page — the coordinate space region bboxes use, so the
/// UI can scale the suspect-region overlay onto the displayed page.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerifyGetDetailsResponsePageDimension,
        VerifyGetDetailsResponsePageDimensionFromRaw
    >)
)]
public sealed record class VerifyGetDetailsResponsePageDimension : JsonModel
{
    /// <summary>
    /// Rendered page height in pixels
    /// </summary>
    public required long Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("height");
        }
        init { this._rawData.Set("height", value); }
    }

    /// <summary>
    /// 0-based page index (0 for standalone images)
    /// </summary>
    public required long Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page");
        }
        init { this._rawData.Set("page", value); }
    }

    /// <summary>
    /// Rendered page width in pixels
    /// </summary>
    public required long Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("width");
        }
        init { this._rawData.Set("width", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Height;
        _ = this.Page;
        _ = this.Width;
    }

    public VerifyGetDetailsResponsePageDimension() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyGetDetailsResponsePageDimension(
        VerifyGetDetailsResponsePageDimension verifyGetDetailsResponsePageDimension
    )
        : base(verifyGetDetailsResponsePageDimension) { }
#pragma warning restore CS8618

    public VerifyGetDetailsResponsePageDimension(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyGetDetailsResponsePageDimension(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifyGetDetailsResponsePageDimensionFromRaw.FromRawUnchecked"/>
    public static VerifyGetDetailsResponsePageDimension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifyGetDetailsResponsePageDimensionFromRaw
    : IFromRawJson<VerifyGetDetailsResponsePageDimension>
{
    /// <inheritdoc/>
    public VerifyGetDetailsResponsePageDimension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerifyGetDetailsResponsePageDimension.FromRawUnchecked(rawData);
}

/// <summary>
/// A suspicious region localized on a rendered page.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Region, RegionFromRaw>))]
public sealed record class Region : JsonModel
{
    /// <summary>
    /// Region bounding box as [x, y, w, h] in page-render pixels
    /// </summary>
    public required IReadOnlyList<long> Bbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<long>>("bbox");
        }
        init
        {
            this._rawData.Set<ImmutableArray<long>>("bbox", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Human-readable detail about the region
    /// </summary>
    public required string Detail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("detail");
        }
        init { this._rawData.Set("detail", value); }
    }

    /// <summary>
    /// Kind of anomaly detected in this region
    /// </summary>
    public required string Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("kind");
        }
        init { this._rawData.Set("kind", value); }
    }

    /// <summary>
    /// 0-based page index (0 for standalone images)
    /// </summary>
    public required long Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page");
        }
        init { this._rawData.Set("page", value); }
    }

    /// <summary>
    /// Region-level doctoring likelihood score
    /// </summary>
    public required double Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    /// <summary>
    /// Detector/tool that produced this region
    /// </summary>
    public required string Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// Whether this region is part of the small set of decisive evidence behind the
    /// verdict — the boxes a reviewer should look at first
    /// </summary>
    public bool? Primary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("primary");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("primary", value);
        }
    }

    /// <summary>
    /// Review status/verdict for this region
    /// </summary>
    public string? Review
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("review");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("review", value);
        }
    }

    /// <summary>
    /// Free-form review note for this region
    /// </summary>
    public string? ReviewNote
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("review_note");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("review_note", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Bbox;
        _ = this.Detail;
        _ = this.Kind;
        _ = this.Page;
        _ = this.Score;
        _ = this.Source;
        _ = this.Primary;
        _ = this.Review;
        _ = this.ReviewNote;
    }

    public Region() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Region(Region region)
        : base(region) { }
#pragma warning restore CS8618

    public Region(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Region(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RegionFromRaw.FromRawUnchecked"/>
    public static Region FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RegionFromRaw : IFromRawJson<Region>
{
    /// <inheritdoc/>
    public Region FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Region.FromRawUnchecked(rawData);
}
