using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Beta.Retrieval;

/// <summary>
/// A file returned by find.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RetrievalFindResponse, RetrievalFindResponseFromRaw>))]
public sealed record class RetrievalFindResponse : JsonModel
{
    /// <summary>
    /// ID of the file.
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
    /// Display name of the file.
    /// </summary>
    public required string FileName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_name");
        }
        init { this._rawData.Set("file_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
        _ = this.FileName;
    }

    public RetrievalFindResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetrievalFindResponse(RetrievalFindResponse retrievalFindResponse)
        : base(retrievalFindResponse) { }
#pragma warning restore CS8618

    public RetrievalFindResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RetrievalFindResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RetrievalFindResponseFromRaw.FromRawUnchecked"/>
    public static RetrievalFindResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RetrievalFindResponseFromRaw : IFromRawJson<RetrievalFindResponse>
{
    /// <inheritdoc/>
    public RetrievalFindResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RetrievalFindResponse.FromRawUnchecked(rawData);
}
