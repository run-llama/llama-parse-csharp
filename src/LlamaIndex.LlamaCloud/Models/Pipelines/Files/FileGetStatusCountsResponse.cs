using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Pipelines.Files;

[JsonConverter(
    typeof(JsonModelConverter<FileGetStatusCountsResponse, FileGetStatusCountsResponseFromRaw>)
)]
public sealed record class FileGetStatusCountsResponse : JsonModel
{
    /// <summary>
    /// The counts of files by status
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
    /// The total number of files
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
    /// The ID of the data source that the files belong to
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
    /// Whether to only count manually uploaded files
    /// </summary>
    public bool? OnlyManuallyUploaded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("only_manually_uploaded");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("only_manually_uploaded", value);
        }
    }

    /// <summary>
    /// The ID of the pipeline that the files belong to
    /// </summary>
    public string? PipelineID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pipeline_id");
        }
        init { this._rawData.Set("pipeline_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Counts;
        _ = this.TotalCount;
        _ = this.DataSourceID;
        _ = this.OnlyManuallyUploaded;
        _ = this.PipelineID;
    }

    public FileGetStatusCountsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileGetStatusCountsResponse(FileGetStatusCountsResponse fileGetStatusCountsResponse)
        : base(fileGetStatusCountsResponse) { }
#pragma warning restore CS8618

    public FileGetStatusCountsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileGetStatusCountsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileGetStatusCountsResponseFromRaw.FromRawUnchecked"/>
    public static FileGetStatusCountsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileGetStatusCountsResponseFromRaw : IFromRawJson<FileGetStatusCountsResponse>
{
    /// <inheritdoc/>
    public FileGetStatusCountsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileGetStatusCountsResponse.FromRawUnchecked(rawData);
}
