using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Extract;

/// <summary>
/// Extraction metadata.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExtractJobMetadata, ExtractJobMetadataFromRaw>))]
public sealed record class ExtractJobMetadata : JsonModel
{
    /// <summary>
    /// Metadata for extracted fields including document, page, and row level info.
    /// </summary>
    public ExtractedFieldMetadata? FieldMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExtractedFieldMetadata>("field_metadata");
        }
        init { this._rawData.Set("field_metadata", value); }
    }

    /// <summary>
    /// Reference to the ParseJob ID used for parsing
    /// </summary>
    public string? ParseJobID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parse_job_id");
        }
        init { this._rawData.Set("parse_job_id", value); }
    }

    /// <summary>
    /// Parse tier used for parsing the document
    /// </summary>
    public string? ParseTier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parse_tier");
        }
        init { this._rawData.Set("parse_tier", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FieldMetadata?.Validate();
        _ = this.ParseJobID;
        _ = this.ParseTier;
    }

    public ExtractJobMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractJobMetadata(ExtractJobMetadata extractJobMetadata)
        : base(extractJobMetadata) { }
#pragma warning restore CS8618

    public ExtractJobMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractJobMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractJobMetadataFromRaw.FromRawUnchecked"/>
    public static ExtractJobMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractJobMetadataFromRaw : IFromRawJson<ExtractJobMetadata>
{
    /// <inheritdoc/>
    public ExtractJobMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExtractJobMetadata.FromRawUnchecked(rawData);
}
