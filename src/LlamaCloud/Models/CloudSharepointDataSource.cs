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

[JsonConverter(
    typeof(JsonModelConverter<CloudSharepointDataSource, CloudSharepointDataSourceFromRaw>)
)]
public sealed record class CloudSharepointDataSource : JsonModel
{
    /// <summary>
    /// The client ID to use for authentication.
    /// </summary>
    public required string ClientID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("client_id");
        }
        init { this._rawData.Set("client_id", value); }
    }

    /// <summary>
    /// The client secret to use for authentication.
    /// </summary>
    public required string ClientSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("client_secret");
        }
        init { this._rawData.Set("client_secret", value); }
    }

    /// <summary>
    /// The tenant ID to use for authentication.
    /// </summary>
    public required string TenantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tenant_id");
        }
        init { this._rawData.Set("tenant_id", value); }
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
    /// The name of the Sharepoint drive to read from.
    /// </summary>
    public string? DriveName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("drive_name");
        }
        init { this._rawData.Set("drive_name", value); }
    }

    /// <summary>
    /// List of regex patterns for file paths to exclude. Files whose paths (including
    /// filename) match any pattern will be excluded. Example: ['/temp/', '/backup/',
    /// '\.git/', '\.tmp$', '^~']
    /// </summary>
    public IReadOnlyList<string>? ExcludePathPatterns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("exclude_path_patterns");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "exclude_path_patterns",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The ID of the Sharepoint folder to read from.
    /// </summary>
    public string? FolderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("folder_id");
        }
        init { this._rawData.Set("folder_id", value); }
    }

    /// <summary>
    /// The path of the Sharepoint folder to read from.
    /// </summary>
    public string? FolderPath
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("folder_path");
        }
        init { this._rawData.Set("folder_path", value); }
    }

    /// <summary>
    /// Whether to get permissions for the sharepoint site.
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
    /// List of regex patterns for file paths to include. Full paths (including filename)
    /// must match at least one pattern to be included. Example: ['/reports/', '/docs/.*\.pdf$', '^Report.*\.pdf$']
    /// </summary>
    public IReadOnlyList<string>? IncludePathPatterns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("include_path_patterns");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "include_path_patterns",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The list of required file extensions.
    /// </summary>
    public IReadOnlyList<string>? RequiredExts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("required_exts");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "required_exts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The ID of the SharePoint site to download from.
    /// </summary>
    public string? SiteID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("site_id");
        }
        init { this._rawData.Set("site_id", value); }
    }

    /// <summary>
    /// The name of the SharePoint site to download from.
    /// </summary>
    public string? SiteName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("site_name");
        }
        init { this._rawData.Set("site_name", value); }
    }

    public ApiEnum<bool, CloudSharepointDataSourceSupportsAccessControl>? SupportsAccessControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<bool, CloudSharepointDataSourceSupportsAccessControl>
            >("supports_access_control");
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
        _ = this.ClientID;
        _ = this.ClientSecret;
        _ = this.TenantID;
        _ = this.ClassName;
        _ = this.DriveName;
        _ = this.ExcludePathPatterns;
        _ = this.FolderID;
        _ = this.FolderPath;
        _ = this.GetPermissions;
        _ = this.IncludePathPatterns;
        _ = this.RequiredExts;
        _ = this.SiteID;
        _ = this.SiteName;
        this.SupportsAccessControl?.Validate();
    }

    public CloudSharepointDataSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudSharepointDataSource(CloudSharepointDataSource cloudSharepointDataSource)
        : base(cloudSharepointDataSource) { }
#pragma warning restore CS8618

    public CloudSharepointDataSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudSharepointDataSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudSharepointDataSourceFromRaw.FromRawUnchecked"/>
    public static CloudSharepointDataSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CloudSharepointDataSourceFromRaw : IFromRawJson<CloudSharepointDataSource>
{
    /// <inheritdoc/>
    public CloudSharepointDataSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CloudSharepointDataSource.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CloudSharepointDataSourceSupportsAccessControlConverter))]
public enum CloudSharepointDataSourceSupportsAccessControl
{
    True,
}

sealed class CloudSharepointDataSourceSupportsAccessControlConverter
    : JsonConverter<CloudSharepointDataSourceSupportsAccessControl>
{
    public override CloudSharepointDataSourceSupportsAccessControl Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => CloudSharepointDataSourceSupportsAccessControl.True,
            _ => (CloudSharepointDataSourceSupportsAccessControl)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CloudSharepointDataSourceSupportsAccessControl value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CloudSharepointDataSourceSupportsAccessControl.True => true,
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
