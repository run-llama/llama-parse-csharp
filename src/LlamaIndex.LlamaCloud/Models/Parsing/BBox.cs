using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Parsing;

/// <summary>
/// Bounding box with coordinates and optional metadata.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BBox, BBoxFromRaw>))]
public sealed record class BBox : JsonModel
{
    /// <summary>
    /// Height of the bounding box
    /// </summary>
    public required double H
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("h");
        }
        init { this._rawData.Set("h", value); }
    }

    /// <summary>
    /// Width of the bounding box
    /// </summary>
    public required double W
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("w");
        }
        init { this._rawData.Set("w", value); }
    }

    /// <summary>
    /// X coordinate of the bounding box
    /// </summary>
    public required double X
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("x");
        }
        init { this._rawData.Set("x", value); }
    }

    /// <summary>
    /// Y coordinate of the bounding box
    /// </summary>
    public required double Y
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("y");
        }
        init { this._rawData.Set("y", value); }
    }

    /// <summary>
    /// Confidence score
    /// </summary>
    public double? Confidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("confidence");
        }
        init { this._rawData.Set("confidence", value); }
    }

    /// <summary>
    /// End index in the text
    /// </summary>
    public long? EndIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("end_index");
        }
        init { this._rawData.Set("end_index", value); }
    }

    /// <summary>
    /// Label for the bounding box
    /// </summary>
    public string? Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("label");
        }
        init { this._rawData.Set("label", value); }
    }

    /// <summary>
    /// Optional visual text rotation angle in degrees. Omitted when unrotated.
    /// </summary>
    public double? R
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("r");
        }
        init { this._rawData.Set("r", value); }
    }

    /// <summary>
    /// Start index in the text
    /// </summary>
    public long? StartIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("start_index");
        }
        init { this._rawData.Set("start_index", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.H;
        _ = this.W;
        _ = this.X;
        _ = this.Y;
        _ = this.Confidence;
        _ = this.EndIndex;
        _ = this.Label;
        _ = this.R;
        _ = this.StartIndex;
    }

    public BBox() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BBox(BBox bBox)
        : base(bBox) { }
#pragma warning restore CS8618

    public BBox(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BBox(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BBoxFromRaw.FromRawUnchecked"/>
    public static BBox FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BBoxFromRaw : IFromRawJson<BBox>
{
    /// <inheritdoc/>
    public BBox FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BBox.FromRawUnchecked(rawData);
}
