using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Retrievers;

[JsonConverter(typeof(JsonModelConverter<RetrieverCreate, RetrieverCreateFromRaw>))]
public sealed record class RetrieverCreate : JsonModel
{
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        foreach (var item in this.Pipelines ?? [])
        {
            item.Validate();
        }
    }

    public RetrieverCreate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetrieverCreate(RetrieverCreate retrieverCreate)
        : base(retrieverCreate) { }
#pragma warning restore CS8618

    public RetrieverCreate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RetrieverCreate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RetrieverCreateFromRaw.FromRawUnchecked"/>
    public static RetrieverCreate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RetrieverCreate(string name)
        : this()
    {
        this.Name = name;
    }
}

class RetrieverCreateFromRaw : IFromRawJson<RetrieverCreate>
{
    /// <inheritdoc/>
    public RetrieverCreate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RetrieverCreate.FromRawUnchecked(rawData);
}
