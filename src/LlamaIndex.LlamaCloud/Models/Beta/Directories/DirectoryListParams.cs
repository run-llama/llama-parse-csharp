using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Beta.Directories;

/// <summary>
/// List Directories
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DirectoryListParams : ParamsBase
{
    /// <summary>
    /// Include deleted directories.
    /// </summary>
    public bool? IncludeDeleted
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("include_deleted");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("include_deleted", value);
        }
    }

    /// <summary>
    /// Directory name to match.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("name");
        }
        init { this._rawQueryData.Set("name", value); }
    }

    public string? OrganizationID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("organization_id");
        }
        init { this._rawQueryData.Set("organization_id", value); }
    }

    public long? PageSize
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("page_size");
        }
        init { this._rawQueryData.Set("page_size", value); }
    }

    public string? PageToken
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("page_token");
        }
        init { this._rawQueryData.Set("page_token", value); }
    }

    public string? ProjectID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("project_id");
        }
        init { this._rawQueryData.Set("project_id", value); }
    }

    /// <summary>
    /// Directory type to include.
    /// </summary>
    public ApiEnum<string, DirectoryListParamsType>? Type
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, DirectoryListParamsType>>(
                "type"
            );
        }
        init { this._rawQueryData.Set("type", value); }
    }

    /// <summary>
    /// Filter by one or more directory types. Repeat the parameter for multiple values.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, TypeModel>>? Types
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<ApiEnum<string, TypeModel>>>(
                "types"
            );
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, TypeModel>>?>(
                "types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public DirectoryListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DirectoryListParams(DirectoryListParams directoryListParams)
        : base(directoryListParams) { }
#pragma warning restore CS8618

    public DirectoryListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DirectoryListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DirectoryListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(DirectoryListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/beta/directories"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Directory type to include.
/// </summary>
[JsonConverter(typeof(DirectoryListParamsTypeConverter))]
public enum DirectoryListParamsType
{
    Ephemeral,
    Index,
    User,
}

sealed class DirectoryListParamsTypeConverter : JsonConverter<DirectoryListParamsType>
{
    public override DirectoryListParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ephemeral" => DirectoryListParamsType.Ephemeral,
            "index" => DirectoryListParamsType.Index,
            "user" => DirectoryListParamsType.User,
            _ => (DirectoryListParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DirectoryListParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DirectoryListParamsType.Ephemeral => "ephemeral",
                DirectoryListParamsType.Index => "index",
                DirectoryListParamsType.User => "user",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TypeModelConverter))]
public enum TypeModel
{
    Ephemeral,
    Index,
    User,
}

sealed class TypeModelConverter : JsonConverter<TypeModel>
{
    public override TypeModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ephemeral" => TypeModel.Ephemeral,
            "index" => TypeModel.Index,
            "user" => TypeModel.User,
            _ => (TypeModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TypeModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TypeModel.Ephemeral => "ephemeral",
                TypeModel.Index => "index",
                TypeModel.User => "user",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
