using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Files;

/// <summary>
/// An uploaded file.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileCreateResponse, FileCreateResponseFromRaw>))]
public sealed record class FileCreateResponse : JsonModel
{
    /// <summary>
    /// Unique file identifier
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
    /// File name including extension
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
    /// Project this file belongs to
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
    /// Schema for a presigned URL.
    /// </summary>
    public PresignedUrl? DownloadUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PresignedUrl>("download_url");
        }
        init { this._rawData.Set("download_url", value); }
    }

    /// <summary>
    /// When the file expires and may be automatically removed. Null means no expiration.
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// Optional ID for correlating with an external system
    /// </summary>
    public string? ExternalFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_file_id");
        }
        init { this._rawData.Set("external_file_id", value); }
    }

    /// <summary>
    /// File extension (pdf, docx, png, etc.)
    /// </summary>
    public string? FileType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("file_type");
        }
        init { this._rawData.Set("file_type", value); }
    }

    /// <summary>
    /// When the file was last modified (ISO 8601)
    /// </summary>
    public DateTimeOffset? LastModifiedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("last_modified_at");
        }
        init { this._rawData.Set("last_modified_at", value); }
    }

    /// <summary>
    /// How the file will be used: user_data, parse, extract, classify, split, sheet,
    /// or agent_app
    /// </summary>
    public string? Purpose
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("purpose");
        }
        init { this._rawData.Set("purpose", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.ProjectID;
        this.DownloadUrl?.Validate();
        _ = this.ExpiresAt;
        _ = this.ExternalFileID;
        _ = this.FileType;
        _ = this.LastModifiedAt;
        _ = this.Purpose;
    }

    public FileCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileCreateResponse(FileCreateResponse fileCreateResponse)
        : base(fileCreateResponse) { }
#pragma warning restore CS8618

    public FileCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileCreateResponseFromRaw.FromRawUnchecked"/>
    public static FileCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileCreateResponseFromRaw : IFromRawJson<FileCreateResponse>
{
    /// <inheritdoc/>
    public FileCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileCreateResponse.FromRawUnchecked(rawData);
}
