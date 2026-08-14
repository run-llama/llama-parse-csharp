using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Retrievers;

/// <summary>
/// An entity that retrieves context nodes from several sub RetrieverTools.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RetrieverRetriever, RetrieverRetrieverFromRaw>))]
public sealed record class RetrieverRetriever : JsonModel
{
    /// <summary>
    /// Unique identifier
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
    /// A name for the retriever tool. Will default to the pipeline name if not provided.
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
    /// The ID of the project this retriever resides in.
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
    /// Creation datetime
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The pipelines this retriever uses.
    /// </summary>
    public IReadOnlyList<RetrieverPipeline>? Pipelines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RetrieverPipeline>>("pipelines");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<RetrieverPipeline>?>(
                "pipelines",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Update datetime
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.ProjectID;
        _ = this.CreatedAt;
        foreach (var item in this.Pipelines ?? [])
        {
            item.Validate();
        }
        _ = this.UpdatedAt;
    }

    public RetrieverRetriever() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetrieverRetriever(RetrieverRetriever retrieverRetriever)
        : base(retrieverRetriever) { }
#pragma warning restore CS8618

    public RetrieverRetriever(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RetrieverRetriever(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RetrieverRetrieverFromRaw.FromRawUnchecked"/>
    public static RetrieverRetriever FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RetrieverRetrieverFromRaw : IFromRawJson<RetrieverRetriever>
{
    /// <inheritdoc/>
    public RetrieverRetriever FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RetrieverRetriever.FromRawUnchecked(rawData);
}
