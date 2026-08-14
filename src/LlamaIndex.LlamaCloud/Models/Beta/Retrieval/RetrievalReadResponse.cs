using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Beta.Retrieval;

/// <summary>
/// File read result.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RetrievalReadResponse, RetrievalReadResponseFromRaw>))]
public sealed record class RetrievalReadResponse : JsonModel
{
    /// <summary>
    /// Parsed text content of the file.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
    }

    public RetrievalReadResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetrievalReadResponse(RetrievalReadResponse retrievalReadResponse)
        : base(retrievalReadResponse) { }
#pragma warning restore CS8618

    public RetrievalReadResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RetrievalReadResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RetrievalReadResponseFromRaw.FromRawUnchecked"/>
    public static RetrievalReadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RetrievalReadResponse(string content)
        : this()
    {
        this.Content = content;
    }
}

class RetrievalReadResponseFromRaw : IFromRawJson<RetrievalReadResponse>
{
    /// <inheritdoc/>
    public RetrievalReadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RetrievalReadResponse.FromRawUnchecked(rawData);
}
