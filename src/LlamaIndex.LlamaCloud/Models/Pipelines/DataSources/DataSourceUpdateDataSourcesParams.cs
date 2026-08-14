using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Pipelines.DataSources;

/// <summary>
/// Add data sources to a pipeline.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
[Obsolete("deprecated")]
public record class DataSourceUpdateDataSourcesParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    public string? PipelineID { get; init; }

    public required IReadOnlyList<Body> Body
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClass<List<Body>>(
                this.RawBodyData,
                "RawBodyData"
            );
        }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    public DataSourceUpdateDataSourcesParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataSourceUpdateDataSourcesParams(
        DataSourceUpdateDataSourcesParams dataSourceUpdateDataSourcesParams
    )
        : base(dataSourceUpdateDataSourcesParams)
    {
        this.PipelineID = dataSourceUpdateDataSourcesParams.PipelineID;

        this.RawBodyData = dataSourceUpdateDataSourcesParams.RawBodyData;
    }
#pragma warning restore CS8618

    public DataSourceUpdateDataSourcesParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataSourceUpdateDataSourcesParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string pipelineID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
        this.PipelineID = pipelineID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DataSourceUpdateDataSourcesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string pipelineID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData,
            pipelineID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["PipelineID"] = JsonSerializer.SerializeToElement(this.PipelineID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(DataSourceUpdateDataSourcesParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.PipelineID?.Equals(other.PipelineID) ?? other.PipelineID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this.RawBodyData.Equals(other.RawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/api/v1/pipelines/{0}/data-sources", this.PipelineID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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

/// <summary>
/// Schema for creating an association between a data source and a pipeline.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Body, BodyFromRaw>))]
public sealed record class Body : JsonModel
{
    /// <summary>
    /// The ID of the data source.
    /// </summary>
    public required string DataSourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("data_source_id");
        }
        init { this._rawData.Set("data_source_id", value); }
    }

    /// <summary>
    /// The interval at which the data source should be synced. Valid values are:
    /// 21600, 43200, 86400
    /// </summary>
    public double? SyncInterval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("sync_interval");
        }
        init { this._rawData.Set("sync_interval", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DataSourceID;
        _ = this.SyncInterval;
    }

    public Body() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Body(Body body)
        : base(body) { }
#pragma warning restore CS8618

    public Body(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Body(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BodyFromRaw.FromRawUnchecked"/>
    public static Body FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Body(string dataSourceID)
        : this()
    {
        this.DataSourceID = dataSourceID;
    }
}

class BodyFromRaw : IFromRawJson<Body>
{
    /// <inheritdoc/>
    public Body FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Body.FromRawUnchecked(rawData);
}
