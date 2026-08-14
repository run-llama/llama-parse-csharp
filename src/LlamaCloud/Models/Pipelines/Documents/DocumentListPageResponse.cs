using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Pipelines.Documents;

[JsonConverter(
    typeof(JsonModelConverter<DocumentListPageResponse, DocumentListPageResponseFromRaw>)
)]
public sealed record class DocumentListPageResponse : JsonModel
{
    /// <summary>
    /// The documents to list
    /// </summary>
    public required IReadOnlyList<CloudDocument> Documents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CloudDocument>>("documents");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CloudDocument>>(
                "documents",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The limit of the documents
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
    /// The offset of the documents
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
    /// The total number of documents
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
        foreach (var item in this.Documents)
        {
            item.Validate();
        }
        _ = this.Limit;
        _ = this.Offset;
        _ = this.TotalCount;
    }

    public DocumentListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentListPageResponse(DocumentListPageResponse documentListPageResponse)
        : base(documentListPageResponse) { }
#pragma warning restore CS8618

    public DocumentListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocumentListPageResponseFromRaw.FromRawUnchecked"/>
    public static DocumentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DocumentListPageResponseFromRaw : IFromRawJson<DocumentListPageResponse>
{
    /// <inheritdoc/>
    public DocumentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DocumentListPageResponse.FromRawUnchecked(rawData);
}
