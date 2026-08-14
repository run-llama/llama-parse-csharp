using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines.Documents;

namespace LlamaIndex.LlamaCloud.Models.Pipelines;

/// <summary>
/// Schema for the result of an retrieval execution.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PipelineRetrieveResponse, PipelineRetrieveResponseFromRaw>)
)]
public sealed record class PipelineRetrieveResponse : JsonModel
{
    /// <summary>
    /// The ID of the pipeline that the query was retrieved against.
    /// </summary>
    public required string PipelineID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("pipeline_id");
        }
        init { this._rawData.Set("pipeline_id", value); }
    }

    /// <summary>
    /// The nodes retrieved by the pipeline for the given query.
    /// </summary>
    public required IReadOnlyList<RetrievalNode> RetrievalNodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RetrievalNode>>("retrieval_nodes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<RetrievalNode>>(
                "retrieval_nodes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? ClassName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("class_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("class_name", value);
        }
    }

    /// <summary>
    /// The image nodes retrieved by the pipeline for the given query. Deprecated
    /// - will soon be replaced with 'page_screenshot_nodes'.
    /// </summary>
    [Obsolete("deprecated")]
    public IReadOnlyList<PageScreenshotNodeWithScore>? ImageNodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PageScreenshotNodeWithScore>>(
                "image_nodes"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<PageScreenshotNodeWithScore>?>(
                "image_nodes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Metadata filters for vector stores.
    /// </summary>
    public MetadataFilters? InferredSearchFilters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MetadataFilters>("inferred_search_filters");
        }
        init { this._rawData.Set("inferred_search_filters", value); }
    }

    /// <summary>
    /// Metadata associated with the retrieval execution
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The page figure nodes retrieved by the pipeline for the given query.
    /// </summary>
    public IReadOnlyList<PageFigureNodeWithScore>? PageFigureNodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PageFigureNodeWithScore>>(
                "page_figure_nodes"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<PageFigureNodeWithScore>?>(
                "page_figure_nodes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The end-to-end latency for retrieval and reranking.
    /// </summary>
    public IReadOnlyDictionary<string, double>? RetrievalLatency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, double>>(
                "retrieval_latency"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, double>?>(
                "retrieval_latency",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PipelineID;
        foreach (var item in this.RetrievalNodes)
        {
            item.Validate();
        }
        _ = this.ClassName;
        foreach (var item in this.ImageNodes ?? [])
        {
            item.Validate();
        }
        this.InferredSearchFilters?.Validate();
        _ = this.Metadata;
        foreach (var item in this.PageFigureNodes ?? [])
        {
            item.Validate();
        }
        _ = this.RetrievalLatency;
    }

    public PipelineRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PipelineRetrieveResponse(PipelineRetrieveResponse pipelineRetrieveResponse)
        : base(pipelineRetrieveResponse) { }
#pragma warning restore CS8618

    public PipelineRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PipelineRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PipelineRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static PipelineRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PipelineRetrieveResponseFromRaw : IFromRawJson<PipelineRetrieveResponse>
{
    /// <inheritdoc/>
    public PipelineRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PipelineRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Same as NodeWithScore but type for node is a TextNode instead of BaseNode. FastAPI
/// doesn't accept abstract classes like BaseNode.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RetrievalNode, RetrievalNodeFromRaw>))]
public sealed record class RetrievalNode : JsonModel
{
    /// <summary>
    /// Provided for backward compatibility.
    /// </summary>
    public required TextNode Node
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TextNode>("node");
        }
        init { this._rawData.Set("node", value); }
    }

    public string? ClassName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("class_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("class_name", value);
        }
    }

    public double? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Node.Validate();
        _ = this.ClassName;
        _ = this.Score;
    }

    public RetrievalNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetrievalNode(RetrievalNode retrievalNode)
        : base(retrievalNode) { }
#pragma warning restore CS8618

    public RetrievalNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RetrievalNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RetrievalNodeFromRaw.FromRawUnchecked"/>
    public static RetrievalNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RetrievalNode(TextNode node)
        : this()
    {
        this.Node = node;
    }
}

class RetrievalNodeFromRaw : IFromRawJson<RetrievalNode>
{
    /// <inheritdoc/>
    public RetrievalNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RetrievalNode.FromRawUnchecked(rawData);
}
