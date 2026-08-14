using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Parsing;

namespace LlamaIndex.LlamaCloud.Models.Classifier.Jobs;

/// <summary>
/// Parsing configuration for a classify job.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ClassifyParsingConfiguration, ClassifyParsingConfigurationFromRaw>)
)]
public sealed record class ClassifyParsingConfiguration : JsonModel
{
    /// <summary>
    /// The language to parse the files in
    /// </summary>
    public ApiEnum<string, ParsingLanguages>? Lang
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ParsingLanguages>>("lang");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lang", value);
        }
    }

    /// <summary>
    /// The maximum number of pages to parse
    /// </summary>
    public long? MaxPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_pages");
        }
        init { this._rawData.Set("max_pages", value); }
    }

    /// <summary>
    /// The pages to target for parsing (0-indexed, so first page is at 0)
    /// </summary>
    public IReadOnlyList<long>? TargetPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("target_pages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<long>?>(
                "target_pages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Lang?.Validate();
        _ = this.MaxPages;
        _ = this.TargetPages;
    }

    public ClassifyParsingConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClassifyParsingConfiguration(ClassifyParsingConfiguration classifyParsingConfiguration)
        : base(classifyParsingConfiguration) { }
#pragma warning restore CS8618

    public ClassifyParsingConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClassifyParsingConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClassifyParsingConfigurationFromRaw.FromRawUnchecked"/>
    public static ClassifyParsingConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClassifyParsingConfigurationFromRaw : IFromRawJson<ClassifyParsingConfiguration>
{
    /// <inheritdoc/>
    public ClassifyParsingConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClassifyParsingConfiguration.FromRawUnchecked(rawData);
}
