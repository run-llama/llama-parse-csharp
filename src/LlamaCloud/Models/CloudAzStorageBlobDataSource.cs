using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models;

[JsonConverter(
    typeof(JsonModelConverter<CloudAzStorageBlobDataSource, CloudAzStorageBlobDataSourceFromRaw>)
)]
public sealed record class CloudAzStorageBlobDataSource : JsonModel
{
    /// <summary>
    /// The Azure Storage Blob account URL to use for authentication.
    /// </summary>
    public required string AccountUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_url");
        }
        init { this._rawData.Set("account_url", value); }
    }

    /// <summary>
    /// The name of the Azure Storage Blob container to read from.
    /// </summary>
    public required string ContainerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("container_name");
        }
        init { this._rawData.Set("container_name", value); }
    }

    /// <summary>
    /// The Azure Storage Blob account key to use for authentication.
    /// </summary>
    public string? AccountKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_key");
        }
        init { this._rawData.Set("account_key", value); }
    }

    /// <summary>
    /// The Azure Storage Blob account name to use for authentication.
    /// </summary>
    public string? AccountName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_name");
        }
        init { this._rawData.Set("account_name", value); }
    }

    /// <summary>
    /// The blob name to read from.
    /// </summary>
    public string? Blob
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("blob");
        }
        init { this._rawData.Set("blob", value); }
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
    /// The Azure AD client ID to use for authentication.
    /// </summary>
    public string? ClientID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("client_id");
        }
        init { this._rawData.Set("client_id", value); }
    }

    /// <summary>
    /// The Azure AD client secret to use for authentication.
    /// </summary>
    public string? ClientSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("client_secret");
        }
        init { this._rawData.Set("client_secret", value); }
    }

    /// <summary>
    /// The prefix of the Azure Storage Blob objects to read from.
    /// </summary>
    public string? Prefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prefix");
        }
        init { this._rawData.Set("prefix", value); }
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
    /// The Azure AD tenant ID to use for authentication.
    /// </summary>
    public string? TenantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tenant_id");
        }
        init { this._rawData.Set("tenant_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountUrl;
        _ = this.ContainerName;
        _ = this.AccountKey;
        _ = this.AccountName;
        _ = this.Blob;
        _ = this.ClassName;
        _ = this.ClientID;
        _ = this.ClientSecret;
        _ = this.Prefix;
        _ = this.SupportsAccessControl;
        _ = this.TenantID;
    }

    public CloudAzStorageBlobDataSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudAzStorageBlobDataSource(CloudAzStorageBlobDataSource cloudAzStorageBlobDataSource)
        : base(cloudAzStorageBlobDataSource) { }
#pragma warning restore CS8618

    public CloudAzStorageBlobDataSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudAzStorageBlobDataSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudAzStorageBlobDataSourceFromRaw.FromRawUnchecked"/>
    public static CloudAzStorageBlobDataSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CloudAzStorageBlobDataSourceFromRaw : IFromRawJson<CloudAzStorageBlobDataSource>
{
    /// <inheritdoc/>
    public CloudAzStorageBlobDataSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CloudAzStorageBlobDataSource.FromRawUnchecked(rawData);
}
