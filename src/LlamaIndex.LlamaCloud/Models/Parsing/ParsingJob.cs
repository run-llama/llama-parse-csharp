using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Parsing;

/// <summary>
/// A parse job (v1).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ParsingJob, ParsingJobFromRaw>))]
public sealed record class ParsingJob : JsonModel
{
    /// <summary>
    /// Unique parse job identifier
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
    /// Current job status
    /// </summary>
    public required ApiEnum<string, StatusEnum> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, StatusEnum>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Machine-readable error code when failed
    /// </summary>
    public string? ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <summary>
    /// Human-readable error details when failed
    /// </summary>
    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_message");
        }
        init { this._rawData.Set("error_message", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Status.Validate();
        _ = this.ErrorCode;
        _ = this.ErrorMessage;
    }

    public ParsingJob() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParsingJob(ParsingJob parsingJob)
        : base(parsingJob) { }
#pragma warning restore CS8618

    public ParsingJob(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParsingJob(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParsingJobFromRaw.FromRawUnchecked"/>
    public static ParsingJob FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParsingJobFromRaw : IFromRawJson<ParsingJob>
{
    /// <inheritdoc/>
    public ParsingJob FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ParsingJob.FromRawUnchecked(rawData);
}
