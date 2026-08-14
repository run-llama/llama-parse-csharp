using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Pipelines.DataSources;

/// <summary>
/// Get the status of a data source for a pipeline.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
[Obsolete("deprecated")]
public record class DataSourceGetStatusParams : ParamsBase
{
    public required string PipelineID { get; init; }

    public string? DataSourceID { get; init; }

    public DataSourceGetStatusParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataSourceGetStatusParams(DataSourceGetStatusParams dataSourceGetStatusParams)
        : base(dataSourceGetStatusParams)
    {
        this.PipelineID = dataSourceGetStatusParams.PipelineID;
        this.DataSourceID = dataSourceGetStatusParams.DataSourceID;
    }
#pragma warning restore CS8618

    public DataSourceGetStatusParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataSourceGetStatusParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string pipelineID,
        string dataSourceID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.PipelineID = pipelineID;
        this.DataSourceID = dataSourceID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DataSourceGetStatusParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string pipelineID,
        string dataSourceID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            pipelineID,
            dataSourceID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["PipelineID"] = JsonSerializer.SerializeToElement(this.PipelineID),
                    ["DataSourceID"] = JsonSerializer.SerializeToElement(this.DataSourceID),
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

    public virtual bool Equals(DataSourceGetStatusParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.PipelineID.Equals(other.PipelineID)
            && (this.DataSourceID?.Equals(other.DataSourceID) ?? other.DataSourceID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/api/v1/pipelines/{0}/data-sources/{1}/status",
                    this.PipelineID,
                    this.DataSourceID
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
