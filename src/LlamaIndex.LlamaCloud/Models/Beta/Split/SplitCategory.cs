using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Beta.Split;

/// <summary>
/// Category definition for document splitting.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SplitCategory, SplitCategoryFromRaw>))]
public sealed record class SplitCategory : JsonModel
{
    /// <summary>
    /// Name of the category.
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
    /// Optional description of what content belongs in this category.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Description;
    }

    public SplitCategory() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitCategory(SplitCategory splitCategory)
        : base(splitCategory) { }
#pragma warning restore CS8618

    public SplitCategory(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitCategory(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitCategoryFromRaw.FromRawUnchecked"/>
    public static SplitCategory FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SplitCategory(string name)
        : this()
    {
        this.Name = name;
    }
}

class SplitCategoryFromRaw : IFromRawJson<SplitCategory>
{
    /// <inheritdoc/>
    public SplitCategory FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SplitCategory.FromRawUnchecked(rawData);
}
