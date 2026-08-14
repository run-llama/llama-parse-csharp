using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models;

[JsonConverter(
    typeof(JsonModelConverter<CloudGoogleDriveDataSource, CloudGoogleDriveDataSourceFromRaw>)
)]
public sealed record class CloudGoogleDriveDataSource : JsonModel
{
    /// <summary>
    /// The ID of the Google Drive folder to read from.
    /// </summary>
    public required string FolderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("folder_id");
        }
        init { this._rawData.Set("folder_id", value); }
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
    /// Human-readable name of the selected folder, for display.
    /// </summary>
    public string? FolderName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("folder_name");
        }
        init { this._rawData.Set("folder_name", value); }
    }

    /// <summary>
    /// A dictionary containing secret values
    /// </summary>
    public IReadOnlyDictionary<string, string>? ServiceAccountKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "service_account_key"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "service_account_key",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
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
        _ = this.FolderID;
        _ = this.ClassName;
        _ = this.FolderName;
        _ = this.ServiceAccountKey;
        _ = this.SupportsAccessControl;
    }

    public CloudGoogleDriveDataSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudGoogleDriveDataSource(CloudGoogleDriveDataSource cloudGoogleDriveDataSource)
        : base(cloudGoogleDriveDataSource) { }
#pragma warning restore CS8618

    public CloudGoogleDriveDataSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudGoogleDriveDataSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudGoogleDriveDataSourceFromRaw.FromRawUnchecked"/>
    public static CloudGoogleDriveDataSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CloudGoogleDriveDataSource(string folderID)
        : this()
    {
        this.FolderID = folderID;
    }
}

class CloudGoogleDriveDataSourceFromRaw : IFromRawJson<CloudGoogleDriveDataSource>
{
    /// <inheritdoc/>
    public CloudGoogleDriveDataSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CloudGoogleDriveDataSource.FromRawUnchecked(rawData);
}
