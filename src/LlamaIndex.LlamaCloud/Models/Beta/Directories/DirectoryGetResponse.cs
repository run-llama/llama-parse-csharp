using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Beta.Directories;

/// <summary>
/// API response schema for a directory.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DirectoryGetResponse, DirectoryGetResponseFromRaw>))]
public sealed record class DirectoryGetResponse : JsonModel
{
    /// <summary>
    /// Unique identifier for the directory.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Human-readable name for the directory.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Project the directory belongs to.
    /// </summary>
    public required string ProjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("project_id");
        }
        init { this._rawData.Set("project_id", value); }
    }

    /// <summary>
    /// Connector Subscription whose files sync into this directory. Null for a directory
    /// populated by manual uploads.
    /// </summary>
    public string? ConnectorSubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("connector_subscription_id");
        }
        init { this._rawData.Set("connector_subscription_id", value); }
    }

    /// <summary>
    /// Creation datetime
    /// </summary>
    public System::DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Optional timestamp of when the directory was deleted. Null if not deleted.
    /// </summary>
    public System::DateTimeOffset? DeletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("deleted_at");
        }
        init { this._rawData.Set("deleted_at", value); }
    }

    /// <summary>
    /// Optional description shown to users.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// When this directory expires and is eligible for cleanup.
    /// </summary>
    public System::DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// Reserved system-managed metadata.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? SystemMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "system_metadata"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "system_metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Directory type: 'user', 'index', or 'ephemeral'.
    /// </summary>
    public ApiEnum<string, DirectoryGetResponseType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DirectoryGetResponseType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Update datetime
    /// </summary>
    public System::DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.ProjectID;
        _ = this.ConnectorSubscriptionID;
        _ = this.CreatedAt;
        _ = this.DeletedAt;
        _ = this.Description;
        _ = this.ExpiresAt;
        _ = this.SystemMetadata;
        this.Type?.Validate();
        _ = this.UpdatedAt;
    }

    public DirectoryGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DirectoryGetResponse(DirectoryGetResponse directoryGetResponse)
        : base(directoryGetResponse) { }
#pragma warning restore CS8618

    public DirectoryGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DirectoryGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DirectoryGetResponseFromRaw.FromRawUnchecked"/>
    public static DirectoryGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DirectoryGetResponseFromRaw : IFromRawJson<DirectoryGetResponse>
{
    /// <inheritdoc/>
    public DirectoryGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DirectoryGetResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Directory type: 'user', 'index', or 'ephemeral'.
/// </summary>
[JsonConverter(typeof(DirectoryGetResponseTypeConverter))]
public enum DirectoryGetResponseType
{
    Ephemeral,
    Index,
    User,
}

sealed class DirectoryGetResponseTypeConverter : JsonConverter<DirectoryGetResponseType>
{
    public override DirectoryGetResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ephemeral" => DirectoryGetResponseType.Ephemeral,
            "index" => DirectoryGetResponseType.Index,
            "user" => DirectoryGetResponseType.User,
            _ => (DirectoryGetResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DirectoryGetResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DirectoryGetResponseType.Ephemeral => "ephemeral",
                DirectoryGetResponseType.Index => "index",
                DirectoryGetResponseType.User => "user",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
