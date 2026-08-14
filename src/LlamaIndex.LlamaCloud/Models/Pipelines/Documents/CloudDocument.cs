using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Pipelines.Documents;

/// <summary>
/// Cloud document stored in S3.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CloudDocument, CloudDocumentFromRaw>))]
public sealed record class CloudDocument : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required IReadOnlyDictionary<string, JsonElement> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    public IReadOnlyList<string>? ExcludedEmbedMetadataKeys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "excluded_embed_metadata_keys"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "excluded_embed_metadata_keys",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? ExcludedLlmMetadataKeys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "excluded_llm_metadata_keys"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "excluded_llm_metadata_keys",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// indices in the CloudDocument.text where a new page begins. e.g. Second page
    /// starts at index specified by page_positions[1].
    /// </summary>
    public IReadOnlyList<long>? PagePositions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("page_positions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<long>?>(
                "page_positions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? StatusMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "status_metadata"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "status_metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Metadata;
        _ = this.Text;
        _ = this.ExcludedEmbedMetadataKeys;
        _ = this.ExcludedLlmMetadataKeys;
        _ = this.PagePositions;
        _ = this.StatusMetadata;
    }

    public CloudDocument() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudDocument(CloudDocument cloudDocument)
        : base(cloudDocument) { }
#pragma warning restore CS8618

    public CloudDocument(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudDocument(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudDocumentFromRaw.FromRawUnchecked"/>
    public static CloudDocument FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CloudDocumentFromRaw : IFromRawJson<CloudDocument>
{
    /// <inheritdoc/>
    public CloudDocument FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CloudDocument.FromRawUnchecked(rawData);
}
