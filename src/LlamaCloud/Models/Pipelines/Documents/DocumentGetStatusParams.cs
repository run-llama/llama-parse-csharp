using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Pipelines.Documents;

/// <summary>
/// Return a single document for a pipeline.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
[Obsolete("deprecated")]
public record class DocumentGetStatusParams : ParamsBase
{
    public required string PipelineID { get; init; }

    public string? DocumentID { get; init; }

    public DocumentGetStatusParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentGetStatusParams(DocumentGetStatusParams documentGetStatusParams)
        : base(documentGetStatusParams)
    {
        this.PipelineID = documentGetStatusParams.PipelineID;
        this.DocumentID = documentGetStatusParams.DocumentID;
    }
#pragma warning restore CS8618

    public DocumentGetStatusParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentGetStatusParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string pipelineID,
        string documentID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.PipelineID = pipelineID;
        this.DocumentID = documentID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DocumentGetStatusParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string pipelineID,
        string documentID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            pipelineID,
            documentID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["PipelineID"] = JsonSerializer.SerializeToElement(this.PipelineID),
                    ["DocumentID"] = JsonSerializer.SerializeToElement(this.DocumentID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(DocumentGetStatusParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.PipelineID.Equals(other.PipelineID)
            && (this.DocumentID?.Equals(other.DocumentID) ?? other.DocumentID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/api/v1/pipelines/{0}/documents/{1}/status",
                    this.PipelineID,
                    this.DocumentID
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
