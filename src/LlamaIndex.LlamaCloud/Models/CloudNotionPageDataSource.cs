using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models;

[JsonConverter(
    typeof(JsonModelConverter<CloudNotionPageDataSource, CloudNotionPageDataSourceFromRaw>)
)]
public sealed record class CloudNotionPageDataSource : JsonModel
{
    /// <summary>
    /// The integration token to use for authentication.
    /// </summary>
    public required string IntegrationToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("integration_token");
        }
        init { this._rawData.Set("integration_token", value); }
    }

    public string? ClassName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("class_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("class_name", value);
        }
    }

    /// <summary>
    /// The Notion Database Id to read content from.
    /// </summary>
    public string? DatabaseIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("database_ids");
        }
        init { this._rawData.Set("database_ids", value); }
    }

    /// <summary>
    /// The Page ID's of the Notion to read from.
    /// </summary>
    public string? PageIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("page_ids");
        }
        init { this._rawData.Set("page_ids", value); }
    }

    public bool? SupportsAccessControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("supports_access_control");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("supports_access_control", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IntegrationToken;
        _ = this.ClassName;
        _ = this.DatabaseIds;
        _ = this.PageIds;
        _ = this.SupportsAccessControl;
    }

    public CloudNotionPageDataSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudNotionPageDataSource(CloudNotionPageDataSource cloudNotionPageDataSource)
        : base(cloudNotionPageDataSource) { }
#pragma warning restore CS8618

    public CloudNotionPageDataSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudNotionPageDataSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudNotionPageDataSourceFromRaw.FromRawUnchecked"/>
    public static CloudNotionPageDataSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CloudNotionPageDataSource(string integrationToken)
        : this()
    {
        this.IntegrationToken = integrationToken;
    }
}

class CloudNotionPageDataSourceFromRaw : IFromRawJson<CloudNotionPageDataSource>
{
    /// <inheritdoc/>
    public CloudNotionPageDataSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CloudNotionPageDataSource.FromRawUnchecked(rawData);
}
