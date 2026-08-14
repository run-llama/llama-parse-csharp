using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Beta.Directories.Files;

/// <summary>
/// Delete a directory file by `directory_file_id`; to resolve from `unique_id`,
/// list with a filter first.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FileDeleteParams : ParamsBase
{
    public required string DirectoryID { get; init; }

    public string? DirectoryFileID { get; init; }

    public string? OrganizationID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("organization_id");
        }
        init { this._rawQueryData.Set("organization_id", value); }
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

    public FileDeleteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileDeleteParams(FileDeleteParams fileDeleteParams)
        : base(fileDeleteParams)
    {
        this.DirectoryID = fileDeleteParams.DirectoryID;
        this.DirectoryFileID = fileDeleteParams.DirectoryFileID;
    }
#pragma warning restore CS8618

    public FileDeleteParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileDeleteParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string directoryID,
        string directoryFileID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.DirectoryID = directoryID;
        this.DirectoryFileID = directoryFileID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FileDeleteParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string directoryID,
        string directoryFileID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            directoryID,
            directoryFileID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["DirectoryID"] = JsonSerializer.SerializeToElement(this.DirectoryID),
                    ["DirectoryFileID"] = JsonSerializer.SerializeToElement(this.DirectoryFileID),
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

    public virtual bool Equals(FileDeleteParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.DirectoryID.Equals(other.DirectoryID)
            && (
                this.DirectoryFileID?.Equals(other.DirectoryFileID) ?? other.DirectoryFileID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/api/v1/beta/directories/{0}/files/{1}",
                    this.DirectoryID,
                    this.DirectoryFileID
                )
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
