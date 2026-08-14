using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Pipelines.Documents;

/// <summary>
/// Counts of the documents in a pipeline, grouped by ingestion status.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DocumentGetStatusCountsResponse,
        DocumentGetStatusCountsResponseFromRaw
    >)
)]
public sealed record class DocumentGetStatusCountsResponse : JsonModel
{
    /// <summary>
    /// Number of documents per ingestion status; every status is present.
    /// </summary>
    public required IReadOnlyDictionary<string, long> Counts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, long>>("counts");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, long>>(
                "counts",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// ID of the pipeline the documents belong to.
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
    /// Total number of documents counted.
    /// </summary>
    public required long TotalCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_count");
        }
        init { this._rawData.Set("total_count", value); }
    }

    /// <summary>
    /// Data source the counts were restricted to.
    /// </summary>
    public string? DataSourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("data_source_id");
        }
        init { this._rawData.Set("data_source_id", value); }
    }

    /// <summary>
    /// File the counts were restricted to.
    /// </summary>
    public string? FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <summary>
    /// Whether only directly uploaded documents were counted.
    /// </summary>
    public bool? OnlyDirectUpload
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("only_direct_upload");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("only_direct_upload", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Counts;
        _ = this.PipelineID;
        _ = this.TotalCount;
        _ = this.DataSourceID;
        _ = this.FileID;
        _ = this.OnlyDirectUpload;
    }

    public DocumentGetStatusCountsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentGetStatusCountsResponse(
        DocumentGetStatusCountsResponse documentGetStatusCountsResponse
    )
        : base(documentGetStatusCountsResponse) { }
#pragma warning restore CS8618

    public DocumentGetStatusCountsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentGetStatusCountsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocumentGetStatusCountsResponseFromRaw.FromRawUnchecked"/>
    public static DocumentGetStatusCountsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DocumentGetStatusCountsResponseFromRaw : IFromRawJson<DocumentGetStatusCountsResponse>
{
    /// <inheritdoc/>
    public DocumentGetStatusCountsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DocumentGetStatusCountsResponse.FromRawUnchecked(rawData);
}
