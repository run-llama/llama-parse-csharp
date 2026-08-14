using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Models.Pipelines;

namespace LlamaCloud.Models.Retrievers;

[JsonConverter(
    typeof(JsonModelConverter<CompositeRetrievalResult, CompositeRetrievalResultFromRaw>)
)]
public sealed record class CompositeRetrievalResult : JsonModel
{
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
    /// The retrieved nodes from the composite retrieval.
    /// </summary>
    public IReadOnlyList<global::LlamaCloud.Models.Retrievers.Node>? Nodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::LlamaCloud.Models.Retrievers.Node>
            >("nodes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::LlamaCloud.Models.Retrievers.Node>?>(
                "nodes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ImageNodes ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Nodes ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.PageFigureNodes ?? [])
        {
            item.Validate();
        }
    }

    public CompositeRetrievalResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CompositeRetrievalResult(CompositeRetrievalResult compositeRetrievalResult)
        : base(compositeRetrievalResult) { }
#pragma warning restore CS8618

    public CompositeRetrievalResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompositeRetrievalResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompositeRetrievalResultFromRaw.FromRawUnchecked"/>
    public static CompositeRetrievalResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CompositeRetrievalResultFromRaw : IFromRawJson<CompositeRetrievalResult>
{
    /// <inheritdoc/>
    public CompositeRetrievalResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CompositeRetrievalResult.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::LlamaCloud.Models.Retrievers.Node,
        global::LlamaCloud.Models.Retrievers.NodeFromRaw
    >)
)]
public sealed record class Node : JsonModel
{
    public required NodeNode NodeValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NodeNode>("node");
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
        this.NodeValue.Validate();
        _ = this.ClassName;
        _ = this.Score;
    }

    public Node() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Node(global::LlamaCloud.Models.Retrievers.Node node)
        : base(node) { }
#pragma warning restore CS8618

    public Node(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Node(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::LlamaCloud.Models.Retrievers.NodeFromRaw.FromRawUnchecked"/>
    public static global::LlamaCloud.Models.Retrievers.Node FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Node(NodeNode nodeValue)
        : this()
    {
        this.NodeValue = nodeValue;
    }
}

class NodeFromRaw : IFromRawJson<global::LlamaCloud.Models.Retrievers.Node>
{
    /// <inheritdoc/>
    public global::LlamaCloud.Models.Retrievers.Node FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::LlamaCloud.Models.Retrievers.Node.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<NodeNode, NodeNodeFromRaw>))]
public sealed record class NodeNode : JsonModel
{
    /// <summary>
    /// The ID of the retrieved node.
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
    /// The end character index of the retrieved node in the document
    /// </summary>
    public required long? EndCharIdx
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("end_char_idx");
        }
        init { this._rawData.Set("end_char_idx", value); }
    }

    /// <summary>
    /// The ID of the pipeline this node was retrieved from.
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
    /// The ID of the retriever this node was retrieved from.
    /// </summary>
    public required string RetrieverID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("retriever_id");
        }
        init { this._rawData.Set("retriever_id", value); }
    }

    /// <summary>
    /// The name of the retrieval pipeline this node was retrieved from.
    /// </summary>
    public required string RetrieverPipelineName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("retriever_pipeline_name");
        }
        init { this._rawData.Set("retriever_pipeline_name", value); }
    }

    /// <summary>
    /// The start character index of the retrieved node in the document
    /// </summary>
    public required long? StartCharIdx
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("start_char_idx");
        }
        init { this._rawData.Set("start_char_idx", value); }
    }

    /// <summary>
    /// The text of the retrieved node.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// Metadata associated with the retrieved node.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.EndCharIdx;
        _ = this.PipelineID;
        _ = this.RetrieverID;
        _ = this.RetrieverPipelineName;
        _ = this.StartCharIdx;
        _ = this.Text;
        _ = this.Metadata;
    }

    public NodeNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NodeNode(NodeNode nodeNode)
        : base(nodeNode) { }
#pragma warning restore CS8618

    public NodeNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NodeNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NodeNodeFromRaw.FromRawUnchecked"/>
    public static NodeNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NodeNodeFromRaw : IFromRawJson<NodeNode>
{
    /// <inheritdoc/>
    public NodeNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NodeNode.FromRawUnchecked(rawData);
}
