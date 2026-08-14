using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Pipelines.Files;

/// <summary>
/// Paginated list of pipeline files.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileListPageResponse, FileListPageResponseFromRaw>))]
public sealed record class FileListPageResponse : JsonModel
{
    /// <summary>
    /// The files to list
    /// </summary>
    public required IReadOnlyList<PipelineFile> Files
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PipelineFile>>("files");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PipelineFile>>(
                "files",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The limit of the files
    /// </summary>
    public required long Limit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("limit");
        }
        init { this._rawData.Set("limit", value); }
    }

    /// <summary>
    /// The offset of the files
    /// </summary>
    public required long Offset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("offset");
        }
        init { this._rawData.Set("offset", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Files)
        {
            item.Validate();
        }
        _ = this.Limit;
        _ = this.Offset;
        _ = this.TotalCount;
    }

    public FileListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileListPageResponse(FileListPageResponse fileListPageResponse)
        : base(fileListPageResponse) { }
#pragma warning restore CS8618

    public FileListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileListPageResponseFromRaw.FromRawUnchecked"/>
    public static FileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileListPageResponseFromRaw : IFromRawJson<FileListPageResponse>
{
    /// <inheritdoc/>
    public FileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileListPageResponse.FromRawUnchecked(rawData);
}
