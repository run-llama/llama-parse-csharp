using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Files;

/// <summary>
/// Paginated list of files.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileQueryResponse, FileQueryResponseFromRaw>))]
public sealed record class FileQueryResponse : JsonModel
{
    /// <summary>
    /// The list of items.
    /// </summary>
    public required IReadOnlyList<Item> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Item>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Item>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A token, which can be sent as page_token to retrieve the next page. If this
    /// field is omitted, there are no subsequent pages.
    /// </summary>
    public string? NextPageToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_page_token");
        }
        init { this._rawData.Set("next_page_token", value); }
    }

    /// <summary>
    /// The total number of items available. This is only populated when specifically
    /// requested. The value may be an estimate and can be used for display purposes only.
    /// </summary>
    public long? TotalSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_size");
        }
        init { this._rawData.Set("total_size", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.NextPageToken;
        _ = this.TotalSize;
    }

    public FileQueryResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileQueryResponse(FileQueryResponse fileQueryResponse)
        : base(fileQueryResponse) { }
#pragma warning restore CS8618

    public FileQueryResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileQueryResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileQueryResponseFromRaw.FromRawUnchecked"/>
    public static FileQueryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FileQueryResponse(IReadOnlyList<Item> items)
        : this()
    {
        this.Items = items;
    }
}

class FileQueryResponseFromRaw : IFromRawJson<FileQueryResponse>
{
    /// <inheritdoc/>
    public FileQueryResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileQueryResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// An uploaded file.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : JsonModel
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

    public Item() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Item(Item item)
        : base(item) { }
#pragma warning restore CS8618

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemFromRaw.FromRawUnchecked"/>
    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRawJson<Item>
{
    /// <inheritdoc/>
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}
