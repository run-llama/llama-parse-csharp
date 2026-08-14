using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Beta.Retrieval;

/// <summary>
/// A single grep match within a file.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RetrievalGrepResponse, RetrievalGrepResponseFromRaw>))]
public sealed record class RetrievalGrepResponse : JsonModel
{
    /// <summary>
    /// Matched text content.
    /// </summary>
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// End character offset of the match.
    /// </summary>
    public required long EndChar
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("end_char");
        }
        init { this._rawData.Set("end_char", value); }
    }

    /// <summary>
    /// Start character offset of the match.
    /// </summary>
    public required long StartChar
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("start_char");
        }
        init { this._rawData.Set("start_char", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        _ = this.EndChar;
        _ = this.StartChar;
    }

    public RetrievalGrepResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetrievalGrepResponse(RetrievalGrepResponse retrievalGrepResponse)
        : base(retrievalGrepResponse) { }
#pragma warning restore CS8618

    public RetrievalGrepResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RetrievalGrepResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RetrievalGrepResponseFromRaw.FromRawUnchecked"/>
    public static RetrievalGrepResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RetrievalGrepResponseFromRaw : IFromRawJson<RetrievalGrepResponse>
{
    /// <inheritdoc/>
    public RetrievalGrepResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RetrievalGrepResponse.FromRawUnchecked(rawData);
}
