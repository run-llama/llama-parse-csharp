using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models;

[JsonConverter(
    typeof(JsonModelConverter<CloudConfluenceDataSource, CloudConfluenceDataSourceFromRaw>)
)]
public sealed record class CloudConfluenceDataSource : JsonModel
{
    /// <summary>
    /// Type of Authentication for connecting to Confluence APIs.
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
    /// The server URL of the Confluence instance.
    /// </summary>
    public required string ServerUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("server_url");
        }
        init { this._rawData.Set("server_url", value); }
    }

    /// <summary>
    /// The API token to use for authentication.
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
    /// The CQL query to use for fetching pages.
    /// </summary>
    public string? Cql
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cql");
        }
        init { this._rawData.Set("cql", value); }
    }

    /// <summary>
    /// Configuration for handling failures during processing. Key-value object controlling
    /// failure handling behaviors.
    ///
    /// <para>Example: {   "skip_list_failures": true }</para>
    ///
    /// <para>Currently supports: - skip_list_failures: Skip failed batches/lists
    /// and continue processing</para>
    /// </summary>
    public FailureHandlingConfig? FailureHandling
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FailureHandlingConfig>("failure_handling");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("failure_handling", value);
        }
    }

    /// <summary>
    /// Whether to index restricted pages.
    /// </summary>
    public bool? IndexRestrictedPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("index_restricted_pages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("index_restricted_pages", value);
        }
    }

    /// <summary>
    /// Whether to keep the markdown format.
    /// </summary>
    public bool? KeepMarkdownFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("keep_markdown_format");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("keep_markdown_format", value);
        }
    }

    /// <summary>
    /// The label to use for fetching pages.
    /// </summary>
    public string? Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("label");
        }
        init { this._rawData.Set("label", value); }
    }

    /// <summary>
    /// The page IDs of the Confluence to read from.
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

    /// <summary>
    /// The space key to read from.
    /// </summary>
    public string? SpaceKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("space_key");
        }
        init { this._rawData.Set("space_key", value); }
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

    /// <summary>
    /// Whether to fetch space-level permissions (allowed users/groups) and attach
    /// them to document metadata for access control. Disable for Confluence Server/Data
    /// Center versions whose permission APIs are unavailable (e.g. the JSON-RPC
    /// API removed in Data Center 9.2.6+), which otherwise surface as 401 errors
    /// during sync.
    /// </summary>
    public bool? SyncPermissions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("sync_permissions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sync_permissions", value);
        }
    }

    /// <summary>
    /// The username to use for authentication.
    /// </summary>
    public string? UserName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_name");
        }
        init { this._rawData.Set("user_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AuthenticationMechanism;
        _ = this.ServerUrl;
        _ = this.ApiToken;
        _ = this.ClassName;
        _ = this.Cql;
        this.FailureHandling?.Validate();
        _ = this.IndexRestrictedPages;
        _ = this.KeepMarkdownFormat;
        _ = this.Label;
        _ = this.PageIds;
        _ = this.SpaceKey;
        _ = this.SupportsAccessControl;
        _ = this.SyncPermissions;
        _ = this.UserName;
    }

    public CloudConfluenceDataSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudConfluenceDataSource(CloudConfluenceDataSource cloudConfluenceDataSource)
        : base(cloudConfluenceDataSource) { }
#pragma warning restore CS8618

    public CloudConfluenceDataSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudConfluenceDataSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudConfluenceDataSourceFromRaw.FromRawUnchecked"/>
    public static CloudConfluenceDataSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CloudConfluenceDataSourceFromRaw : IFromRawJson<CloudConfluenceDataSource>
{
    /// <inheritdoc/>
    public CloudConfluenceDataSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CloudConfluenceDataSource.FromRawUnchecked(rawData);
}
