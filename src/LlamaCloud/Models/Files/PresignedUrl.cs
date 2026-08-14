using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Files;

/// <summary>
/// Schema for a presigned URL.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PresignedUrl, PresignedUrlFromRaw>))]
public sealed record class PresignedUrl : JsonModel
{
    /// <summary>
    /// The time at which the presigned URL expires
    /// </summary>
    public required DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// A presigned URL for IO operations against a private file
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Form fields for a presigned POST request
    /// </summary>
    public IReadOnlyDictionary<string, string>? FormFields
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("form_fields");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "form_fields",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExpiresAt;
        _ = this.Url;
        _ = this.FormFields;
    }

    public PresignedUrl() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PresignedUrl(PresignedUrl presignedUrl)
        : base(presignedUrl) { }
#pragma warning restore CS8618

    public PresignedUrl(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PresignedUrl(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PresignedUrlFromRaw.FromRawUnchecked"/>
    public static PresignedUrl FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PresignedUrlFromRaw : IFromRawJson<PresignedUrl>
{
    /// <inheritdoc/>
    public PresignedUrl FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PresignedUrl.FromRawUnchecked(rawData);
}
