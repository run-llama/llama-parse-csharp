using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines;

namespace LlamaIndex.LlamaCloud.Models.Retrievers;

[JsonConverter(typeof(JsonModelConverter<RetrieverPipeline, RetrieverPipelineFromRaw>))]
public sealed record class RetrieverPipeline : JsonModel
{
    /// <summary>
    /// A description of the retriever tool.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// A name for the retriever tool. Will default to the pipeline name if not provided.
    /// </summary>
    public required string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The ID of the pipeline this tool uses.
    /// </summary>
    public required string PipelineID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("pipeline_id");
        }
        init { this._rawData.Set("pipeline_id", value); }
    }

    /// <summary>
    /// Parameters for retrieval configuration.
    /// </summary>
    public PresetRetrievalParams? PresetRetrievalParameters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PresetRetrievalParams>(
                "preset_retrieval_parameters"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("preset_retrieval_parameters", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Name;
        _ = this.PipelineID;
        this.PresetRetrievalParameters?.Validate();
    }

    public RetrieverPipeline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetrieverPipeline(RetrieverPipeline retrieverPipeline)
        : base(retrieverPipeline) { }
#pragma warning restore CS8618

    public RetrieverPipeline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RetrieverPipeline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RetrieverPipelineFromRaw.FromRawUnchecked"/>
    public static RetrieverPipeline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RetrieverPipelineFromRaw : IFromRawJson<RetrieverPipeline>
{
    /// <inheritdoc/>
    public RetrieverPipeline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RetrieverPipeline.FromRawUnchecked(rawData);
}
