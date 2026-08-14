using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models;

/// <summary>
/// Cloud Jira Data Source integrating JiraReader.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CloudJiraDataSource, CloudJiraDataSourceFromRaw>))]
public sealed record class CloudJiraDataSource : JsonModel
{
    /// <summary>
    /// Type of Authentication for connecting to Jira APIs.
    /// </summary>
    public required string AuthenticationMechanism
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("authentication_mechanism");
        }
        init { this._rawData.Set("authentication_mechanism", value); }
    }

    /// <summary>
    /// JQL (Jira Query Language) query to search.
    /// </summary>
    public required string Query
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("query");
        }
        init { this._rawData.Set("query", value); }
    }

    /// <summary>
    /// The API/ Access Token used for Basic, PAT and OAuth2 authentication.
    /// </summary>
    public string? ApiToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("api_token");
        }
        init { this._rawData.Set("api_token", value); }
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
    /// The cloud ID, used in case of OAuth2.
    /// </summary>
    public string? CloudID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cloud_id");
        }
        init { this._rawData.Set("cloud_id", value); }
    }

    /// <summary>
    /// The email address to use for authentication.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// The server url for Jira Cloud.
    /// </summary>
    public string? ServerUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("server_url");
        }
        init { this._rawData.Set("server_url", value); }
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
        _ = this.AuthenticationMechanism;
        _ = this.Query;
        _ = this.ApiToken;
        _ = this.ClassName;
        _ = this.CloudID;
        _ = this.Email;
        _ = this.ServerUrl;
        _ = this.SupportsAccessControl;
    }

    public CloudJiraDataSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudJiraDataSource(CloudJiraDataSource cloudJiraDataSource)
        : base(cloudJiraDataSource) { }
#pragma warning restore CS8618

    public CloudJiraDataSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudJiraDataSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudJiraDataSourceFromRaw.FromRawUnchecked"/>
    public static CloudJiraDataSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CloudJiraDataSourceFromRaw : IFromRawJson<CloudJiraDataSource>
{
    /// <inheritdoc/>
    public CloudJiraDataSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CloudJiraDataSource.FromRawUnchecked(rawData);
}
