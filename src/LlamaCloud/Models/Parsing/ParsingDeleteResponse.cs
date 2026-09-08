using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Parsing;

/// <summary>
/// Confirmation that a parse job was deleted.
///
/// <para>A deleted job can no longer be fetched, so the response echoes back what
/// it was rather than pointing at it. Returning the identifiers instead of an empty
/// body lets a caller assert on the delete it just made without a follow-up request.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ParsingDeleteResponse, ParsingDeleteResponseFromRaw>))]
public sealed record class ParsingDeleteResponse : JsonModel
{
    /// <summary>
    /// Identifier of the deleted parse job
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
    /// Project the deleted job belonged to
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ProjectID;
    }

    public ParsingDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParsingDeleteResponse(ParsingDeleteResponse parsingDeleteResponse)
        : base(parsingDeleteResponse) { }
#pragma warning restore CS8618

    public ParsingDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParsingDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParsingDeleteResponseFromRaw.FromRawUnchecked"/>
    public static ParsingDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParsingDeleteResponseFromRaw : IFromRawJson<ParsingDeleteResponse>
{
    /// <inheritdoc/>
    public ParsingDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ParsingDeleteResponse.FromRawUnchecked(rawData);
}
