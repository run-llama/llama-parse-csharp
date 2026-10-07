using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Beta.Attachments;

/// <summary>
/// Metadata for a single file attachment.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AttachmentListResponse, AttachmentListResponseFromRaw>))]
public sealed record class AttachmentListResponse : JsonModel
{
    /// <summary>
    /// Name of the attachment
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
    /// Size of the attachment in bytes
    /// </summary>
    public required long Size
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("size");
        }
        init { this._rawData.Set("size", value); }
    }

    /// <summary>
    /// When the attachment was last modified
    /// </summary>
    public DateTimeOffset? LastModified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("last_modified");
        }
        init { this._rawData.Set("last_modified", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Size;
        _ = this.LastModified;
    }

    public AttachmentListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AttachmentListResponse(AttachmentListResponse attachmentListResponse)
        : base(attachmentListResponse) { }
#pragma warning restore CS8618

    public AttachmentListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AttachmentListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttachmentListResponseFromRaw.FromRawUnchecked"/>
    public static AttachmentListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AttachmentListResponseFromRaw : IFromRawJson<AttachmentListResponse>
{
    /// <inheritdoc/>
    public AttachmentListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AttachmentListResponse.FromRawUnchecked(rawData);
}
