using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Pipelines.Images;

[JsonConverter(
    typeof(JsonModelConverter<
        ImageListPageScreenshotsResponse,
        ImageListPageScreenshotsResponseFromRaw
    >)
)]
public sealed record class ImageListPageScreenshotsResponse : JsonModel
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

    public ImageListPageScreenshotsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageListPageScreenshotsResponse(
        ImageListPageScreenshotsResponse imageListPageScreenshotsResponse
    )
        : base(imageListPageScreenshotsResponse) { }
#pragma warning restore CS8618

    public ImageListPageScreenshotsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageListPageScreenshotsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageListPageScreenshotsResponseFromRaw.FromRawUnchecked"/>
    public static ImageListPageScreenshotsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageListPageScreenshotsResponseFromRaw : IFromRawJson<ImageListPageScreenshotsResponse>
{
    /// <inheritdoc/>
    public ImageListPageScreenshotsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ImageListPageScreenshotsResponse.FromRawUnchecked(rawData);
}
