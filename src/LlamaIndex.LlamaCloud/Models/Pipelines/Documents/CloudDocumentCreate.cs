using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Pipelines.Documents;

/// <summary>
/// Create a new cloud document.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CloudDocumentCreate, CloudDocumentCreateFromRaw>))]
public sealed record class CloudDocumentCreate : JsonModel
{
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

    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Metadata;
        _ = this.Text;
        _ = this.ID;
        _ = this.ExcludedEmbedMetadataKeys;
        _ = this.ExcludedLlmMetadataKeys;
        _ = this.PagePositions;
    }

    public CloudDocumentCreate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudDocumentCreate(CloudDocumentCreate cloudDocumentCreate)
        : base(cloudDocumentCreate) { }
#pragma warning restore CS8618

    public CloudDocumentCreate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudDocumentCreate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudDocumentCreateFromRaw.FromRawUnchecked"/>
    public static CloudDocumentCreate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CloudDocumentCreateFromRaw : IFromRawJson<CloudDocumentCreate>
{
    /// <inheritdoc/>
    public CloudDocumentCreate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CloudDocumentCreate.FromRawUnchecked(rawData);
}
