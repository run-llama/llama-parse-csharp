using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;

namespace LlamaCloud.Models;

[JsonConverter(typeof(JsonModelConverter<CloudBoxDataSource, CloudBoxDataSourceFromRaw>))]
public sealed record class CloudBoxDataSource : JsonModel
{
    /// <summary>
    /// The type of authentication to use (Developer Token or CCG)
    /// </summary>
    public required ApiEnum<string, AuthenticationMechanism> AuthenticationMechanism
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AuthenticationMechanism>>(
                "authentication_mechanism"
            );
        }
        init { this._rawData.Set("authentication_mechanism", value); }
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
    /// Box API key used for identifying the application the user is authenticating with
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
    /// Box API secret used for making auth requests.
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
    /// Developer token for authentication if authentication_mechanism is 'developer_token'.
    /// </summary>
    public string? DeveloperToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("developer_token");
        }
        init { this._rawData.Set("developer_token", value); }
    }

    /// <summary>
    /// Box Enterprise ID, if provided authenticates as service.
    /// </summary>
    public string? EnterpriseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("enterprise_id");
        }
        init { this._rawData.Set("enterprise_id", value); }
    }

    /// <summary>
    /// The ID of the Box folder to read from.
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
    /// Box User ID, if provided authenticates as user.
    /// </summary>
    public string? UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AuthenticationMechanism.Validate();
        _ = this.ClassName;
        _ = this.ClientID;
        _ = this.ClientSecret;
        _ = this.DeveloperToken;
        _ = this.EnterpriseID;
        _ = this.FolderID;
        _ = this.SupportsAccessControl;
        _ = this.UserID;
    }

    public CloudBoxDataSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudBoxDataSource(CloudBoxDataSource cloudBoxDataSource)
        : base(cloudBoxDataSource) { }
#pragma warning restore CS8618

    public CloudBoxDataSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudBoxDataSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudBoxDataSourceFromRaw.FromRawUnchecked"/>
    public static CloudBoxDataSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CloudBoxDataSource(ApiEnum<string, AuthenticationMechanism> authenticationMechanism)
        : this()
    {
        this.AuthenticationMechanism = authenticationMechanism;
    }
}

class CloudBoxDataSourceFromRaw : IFromRawJson<CloudBoxDataSource>
{
    /// <inheritdoc/>
    public CloudBoxDataSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CloudBoxDataSource.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of authentication to use (Developer Token or CCG)
/// </summary>
[JsonConverter(typeof(AuthenticationMechanismConverter))]
public enum AuthenticationMechanism
{
    Ccg,
    DeveloperToken,
}

sealed class AuthenticationMechanismConverter : JsonConverter<AuthenticationMechanism>
{
    public override AuthenticationMechanism Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ccg" => AuthenticationMechanism.Ccg,
            "developer_token" => AuthenticationMechanism.DeveloperToken,
            _ => (AuthenticationMechanism)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AuthenticationMechanism value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AuthenticationMechanism.Ccg => "ccg",
                AuthenticationMechanism.DeveloperToken => "developer_token",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
