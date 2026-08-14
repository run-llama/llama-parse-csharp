using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Classifier.Jobs;

/// <summary>
/// A rule for classifying documents - v0 simplified version.
///
/// <para>This represents a single classification rule that will be applied to documents.
/// All rules are content-based and use natural language descriptions.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ClassifierRule, ClassifierRuleFromRaw>))]
public sealed record class ClassifierRule : JsonModel
{
    /// <summary>
    /// Natural language description of what to classify. Be specific about the content
    /// characteristics that identify this document type.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The document type to assign when this rule matches (e.g., 'invoice', 'receipt', 'contract')
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Type;
    }

    public ClassifierRule() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClassifierRule(ClassifierRule classifierRule)
        : base(classifierRule) { }
#pragma warning restore CS8618

    public ClassifierRule(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClassifierRule(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClassifierRuleFromRaw.FromRawUnchecked"/>
    public static ClassifierRule FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClassifierRuleFromRaw : IFromRawJson<ClassifierRule>
{
    /// <inheritdoc/>
    public ClassifierRule FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ClassifierRule.FromRawUnchecked(rawData);
}
