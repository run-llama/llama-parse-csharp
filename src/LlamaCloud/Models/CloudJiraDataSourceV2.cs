using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;

namespace LlamaCloud.Models;

/// <summary>
/// Cloud Jira Data Source integrating JiraReaderV2.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CloudJiraDataSourceV2, CloudJiraDataSourceV2FromRaw>))]
public sealed record class CloudJiraDataSourceV2 : JsonModel
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
    /// The server url for Jira Cloud.
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
    /// The API Access Token used for Basic, PAT and OAuth2 authentication.
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

    /// <summary>
    /// Jira REST API version to use (2 or 3). 3 supports Atlassian Document Format (ADF).
    /// </summary>
    public ApiEnum<string, ApiVersion>? ApiVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ApiVersion>>("api_version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("api_version", value);
        }
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
    /// Fields to expand in the response.
    /// </summary>
    public string? Expand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("expand");
        }
        init { this._rawData.Set("expand", value); }
    }

    /// <summary>
    /// List of fields to retrieve from Jira. If None, retrieves all fields.
    /// </summary>
    public IReadOnlyList<string>? Fields
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("fields");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "fields",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether to fetch project role permissions and issue-level security
    /// </summary>
    public bool? GetPermissions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("get_permissions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("get_permissions", value);
        }
    }

    /// <summary>
    /// Rate limit for Jira API requests per minute.
    /// </summary>
    public long? RequestsPerMinute
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("requests_per_minute");
        }
        init { this._rawData.Set("requests_per_minute", value); }
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
        _ = this.ServerUrl;
        _ = this.ApiToken;
        this.ApiVersion?.Validate();
        _ = this.ClassName;
        _ = this.CloudID;
        _ = this.Email;
        _ = this.Expand;
        _ = this.Fields;
        _ = this.GetPermissions;
        _ = this.RequestsPerMinute;
        _ = this.SupportsAccessControl;
    }

    public CloudJiraDataSourceV2() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudJiraDataSourceV2(CloudJiraDataSourceV2 cloudJiraDataSourceV2)
        : base(cloudJiraDataSourceV2) { }
#pragma warning restore CS8618

    public CloudJiraDataSourceV2(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudJiraDataSourceV2(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudJiraDataSourceV2FromRaw.FromRawUnchecked"/>
    public static CloudJiraDataSourceV2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CloudJiraDataSourceV2FromRaw : IFromRawJson<CloudJiraDataSourceV2>
{
    /// <inheritdoc/>
    public CloudJiraDataSourceV2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CloudJiraDataSourceV2.FromRawUnchecked(rawData);
}

/// <summary>
/// Jira REST API version to use (2 or 3). 3 supports Atlassian Document Format (ADF).
/// </summary>
[JsonConverter(typeof(ApiVersionConverter))]
public enum ApiVersion
{
    V2,
    V3,
}

sealed class ApiVersionConverter : JsonConverter<ApiVersion>
{
    public override ApiVersion Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "2" => ApiVersion.V2,
            "3" => ApiVersion.V3,
            _ => (ApiVersion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApiVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ApiVersion.V2 => "2",
                ApiVersion.V3 => "3",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
