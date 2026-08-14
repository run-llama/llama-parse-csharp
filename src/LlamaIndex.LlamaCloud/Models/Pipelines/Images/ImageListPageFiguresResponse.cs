using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Pipelines.Images;

[JsonConverter(
    typeof(JsonModelConverter<ImageListPageFiguresResponse, ImageListPageFiguresResponseFromRaw>)
)]
public sealed record class ImageListPageFiguresResponse : JsonModel
{
    /// <summary>
    /// The confidence of the figure
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
    /// The name of the figure
    /// </summary>
    public required string FigureName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("figure_name");
        }
        init { this._rawData.Set("figure_name", value); }
    }

    /// <summary>
    /// The size of the figure in bytes
    /// </summary>
    public required long FigureSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("figure_size");
        }
        init { this._rawData.Set("figure_size", value); }
    }

    /// <summary>
    /// The ID of the file that the figure was taken from
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
    /// The index of the page for which the figure is taken (0-indexed)
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
    /// Whether the figure is likely to be noise
    /// </summary>
    public bool? IsLikelyNoise
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_likely_noise");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_likely_noise", value);
        }
    }

    /// <summary>
    /// Metadata for the figure
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
        _ = this.Confidence;
        _ = this.FigureName;
        _ = this.FigureSize;
        _ = this.FileID;
        _ = this.PageIndex;
        _ = this.IsLikelyNoise;
        _ = this.Metadata;
    }

    public ImageListPageFiguresResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageListPageFiguresResponse(ImageListPageFiguresResponse imageListPageFiguresResponse)
        : base(imageListPageFiguresResponse) { }
#pragma warning restore CS8618

    public ImageListPageFiguresResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageListPageFiguresResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageListPageFiguresResponseFromRaw.FromRawUnchecked"/>
    public static ImageListPageFiguresResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageListPageFiguresResponseFromRaw : IFromRawJson<ImageListPageFiguresResponse>
{
    /// <inheritdoc/>
    public ImageListPageFiguresResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ImageListPageFiguresResponse.FromRawUnchecked(rawData);
}
