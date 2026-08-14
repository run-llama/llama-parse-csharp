using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Pipelines;

/// <summary>
/// Page screenshot metadata with score
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PageScreenshotNodeWithScore, PageScreenshotNodeWithScoreFromRaw>)
)]
public sealed record class PageScreenshotNodeWithScore : JsonModel
{
    public required PageScreenshotNodeWithScoreNode Node
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PageScreenshotNodeWithScoreNode>("node");
        }
        init { this._rawData.Set("node", value); }
    }

    /// <summary>
    /// The score of the screenshot node
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Node.Validate();
        _ = this.Score;
        _ = this.ClassName;
    }

    public PageScreenshotNodeWithScore() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PageScreenshotNodeWithScore(PageScreenshotNodeWithScore pageScreenshotNodeWithScore)
        : base(pageScreenshotNodeWithScore) { }
#pragma warning restore CS8618

    public PageScreenshotNodeWithScore(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PageScreenshotNodeWithScore(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PageScreenshotNodeWithScoreFromRaw.FromRawUnchecked"/>
    public static PageScreenshotNodeWithScore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PageScreenshotNodeWithScoreFromRaw : IFromRawJson<PageScreenshotNodeWithScore>
{
    /// <inheritdoc/>
    public PageScreenshotNodeWithScore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PageScreenshotNodeWithScore.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PageScreenshotNodeWithScoreNode,
        PageScreenshotNodeWithScoreNodeFromRaw
    >)
)]
public sealed record class PageScreenshotNodeWithScoreNode : JsonModel
{
    /// <summary>
    /// The ID of the file that the page screenshot was taken from
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <summary>
    /// The size of the image in bytes
    /// </summary>
    public required long ImageSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("image_size");
        }
        init { this._rawData.Set("image_size", value); }
    }

    /// <summary>
    /// The index of the page for which the screenshot is taken (0-indexed)
    /// </summary>
    public required long PageIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page_index");
        }
        init { this._rawData.Set("page_index", value); }
    }

    /// <summary>
    /// Metadata for the screenshot
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
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
        _ = this.ImageSize;
        _ = this.PageIndex;
        _ = this.Metadata;
    }

    public PageScreenshotNodeWithScoreNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PageScreenshotNodeWithScoreNode(
        PageScreenshotNodeWithScoreNode pageScreenshotNodeWithScoreNode
    )
        : base(pageScreenshotNodeWithScoreNode) { }
#pragma warning restore CS8618

    public PageScreenshotNodeWithScoreNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PageScreenshotNodeWithScoreNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PageScreenshotNodeWithScoreNodeFromRaw.FromRawUnchecked"/>
    public static PageScreenshotNodeWithScoreNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PageScreenshotNodeWithScoreNodeFromRaw : IFromRawJson<PageScreenshotNodeWithScoreNode>
{
    /// <inheritdoc/>
    public PageScreenshotNodeWithScoreNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PageScreenshotNodeWithScoreNode.FromRawUnchecked(rawData);
}
