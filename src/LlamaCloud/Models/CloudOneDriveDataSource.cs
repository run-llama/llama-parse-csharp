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

[JsonConverter(typeof(JsonModelConverter<CloudOneDriveDataSource, CloudOneDriveDataSourceFromRaw>))]
public sealed record class CloudOneDriveDataSource : JsonModel
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

    /// <summary>
    /// The user principal name to use for authentication.
    /// </summary>
    public required string UserPrincipalName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("user_principal_name");
        }
        init { this._rawData.Set("user_principal_name", value); }
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
    /// The ID of the OneDrive folder to read from.
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
    /// The path of the OneDrive folder to read from.
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

    public ApiEnum<bool, SupportsAccessControl>? SupportsAccessControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<bool, SupportsAccessControl>>(
                "supports_access_control"
            );
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
        _ = this.UserPrincipalName;
        _ = this.ClassName;
        _ = this.FolderID;
        _ = this.FolderPath;
        _ = this.RequiredExts;
        this.SupportsAccessControl?.Validate();
    }

    public CloudOneDriveDataSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudOneDriveDataSource(CloudOneDriveDataSource cloudOneDriveDataSource)
        : base(cloudOneDriveDataSource) { }
#pragma warning restore CS8618

    public CloudOneDriveDataSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudOneDriveDataSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudOneDriveDataSourceFromRaw.FromRawUnchecked"/>
    public static CloudOneDriveDataSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CloudOneDriveDataSourceFromRaw : IFromRawJson<CloudOneDriveDataSource>
{
    /// <inheritdoc/>
    public CloudOneDriveDataSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CloudOneDriveDataSource.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SupportsAccessControlConverter))]
public enum SupportsAccessControl
{
    True,
}

sealed class SupportsAccessControlConverter : JsonConverter<SupportsAccessControl>
{
    public override SupportsAccessControl Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => SupportsAccessControl.True,
            _ => (SupportsAccessControl)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SupportsAccessControl value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SupportsAccessControl.True => true,
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
